﻿Imports System.Collections.Specialized
Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Markup
Imports System.Windows.Threading
Imports Microsoft.VisualBasic.ApplicationServices

Module mdlMain

    <STAThread>
    Sub Main()
        Try
            Dim manager As New SingleInstanceManager()
            manager.Run({""})
        Catch ex As Exception
            IMsgBox(ex.Message & vbCrLf & ex.StackTrace, "Sub Main", vbOKOnly, vbExclamation)
        End Try
    End Sub

End Module

Public Class SingleInstanceManager
    Inherits WindowsFormsApplicationBase
    Private app As SingleInstanceApplication

    Public Sub New()
        Me.IsSingleInstance = True
    End Sub

    Protected Overrides Function OnStartup(e As Microsoft.VisualBasic.ApplicationServices.StartupEventArgs) As Boolean
        ' First time app is launched
        Try
            app = New SingleInstanceApplication()
            app.Run()
            Return False
        Catch ex As Exception
            IMsgBox(ex.Message & vbCrLf & ex.StackTrace, "OnStartup", vbOKOnly, vbExclamation)
            Return False
        End Try
    End Function

    Protected Overrides Sub OnStartupNextInstance(eventArgs As StartupNextInstanceEventArgs)
        Try
            MyBase.OnStartupNextInstance(eventArgs)
            app.Activate()
        Catch ex As Exception
            IMsgBox(ex.Message & vbCrLf & ex.StackTrace, "OnStartupNextInstance", vbOKOnly, vbExclamation)
        End Try
    End Sub
End Class

Public Class SingleInstanceApplication
    Inherits Application

    Public Shared WithEvents nicon As New Forms.NotifyIcon
    Public Shared ctxmenu As New Forms.ContextMenu({New Forms.MenuItem("Выход", AddressOf ni_ContextMenuExit)})
    Public Shared WithEvents tsocErrorLog As New clsThreadSafeObservableCollection(Of clsErrorLog)

    Protected Overrides Sub OnStartup(e As System.Windows.StartupEventArgs)
        MyBase.OnStartup(e)
        Try
            ' unhandled exception handler
            AddHandler Dispatcher.UnhandledException, AddressOf Dispatcher_UnhandledException
            AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf AppDomain_CurrentDomain_UnhandledException

            ' notify icon initialization
            nicon.Icon = New Icon(Application.GetResourceStream(New Uri("img/app.ico", UriKind.Relative)).Stream)
            nicon.Text = "NetViewer"
            nicon.ContextMenu = ctxmenu
            nicon.Visible = True

            ' command line args
            Dim commandlineargs() As String = Environment.GetCommandLineArgs()
            Dim minimizedstart As Boolean = False
            For Each cl In commandlineargs
                If cl = "-minimized" Or cl = "/minimized" Then
                    minimizedstart = True
                End If
            Next

            If Not minimizedstart Then
                ' loading splash screen
                Dim splash As New SplashScreen("img/splash.png")
                splash.Show(True, True)
            End If

            ' setting localization
            FrameworkElement.LanguageProperty.OverrideMetadata(GetType(FrameworkElement), New FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)))

            ' preferences setup
            preferences = New clsPreferences

            ' load hosts from sqlite etc...
            AppInitialize()

            If Not minimizedstart Then
                ' loading main form
                wndMainActivate()
            End If

        Catch ex As Exception
            IMsgBox(ex.Message & vbCrLf & ex.StackTrace, "Application.OnStartup", vbOKOnly, vbExclamation)
        End Try
    End Sub

    Public Sub Activate()
        wndMainActivate()
    End Sub

    Protected Overrides Sub OnExit(e As ExitEventArgs)
        MyBase.OnExit(e)
        Try
            ' notify icon deinitialization
            nicon.Visible = False

            ' save preferences
            preferences.SavePreferences()

            ' removing unhandled exception handler
            RemoveHandler Dispatcher.UnhandledException, AddressOf Dispatcher_UnhandledException
        Catch ex As Exception

        End Try
    End Sub

    Sub New()
        InitializeComponent()
    End Sub


    Private Shared Sub ni_ContextMenuExit(sender As Object, e As EventArgs)
        Current.Shutdown()
    End Sub

    Private Shared Sub ni_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles nicon.MouseClick
        If e.Button = Forms.MouseButtons.Left Then
            wndMainActivate()
        End If
    End Sub

    Public Shared Sub wndMainActivate()
        Try
            Dim w As wndMain

            If Application.Current.Windows.Count > 0 Then
                w = Nothing
                For Each wnd In Application.Current.Windows
                    If GetType(wndMain) Is wnd.GetType Then
                        w = wnd

                        w.Show()
                        w.Activate()

                        If w.WindowState = WindowState.Minimized Then w.WindowState = WindowState.Normal

                        w.Topmost = True
                        w.Topmost = False
                    End If
                Next
                If w Is Nothing Then w = New wndMain
            Else
                w = New wndMain

                w.Show()
                w.Activate()

                If w.WindowState = WindowState.Minimized Then w.WindowState = WindowState.Normal

                w.Topmost = True
                w.Topmost = False
            End If
        Catch ex As Exception
            ThrowException(ex, "wndMainActivate")
        End Try
    End Sub

    Public Shared Sub Dispatcher_UnhandledException(ByVal sender As Object, ByVal e As DispatcherUnhandledExceptionEventArgs)
        ThrowException(e.Exception, "Необработанное исключение")
        e.Handled = True
    End Sub

    Public Shared Sub AppDomain_CurrentDomain_UnhandledException(sender As Object, e As Object)
        Dim ex = TryCast(e, UnhandledExceptionEventArgs)
        If ex IsNot Nothing Then
            ThrowException(ex.Exception, "Необработанное исключение")
        Else
            ThrowCustomException("Необработанное исключение")
        End If
    End Sub

    Private Shared Sub tsocErrorLog_CollectionChanged(sender As Object, e As NotifyCollectionChangedEventArgs) Handles tsocErrorLog.CollectionChanged
        Dim w As wndError

        For Each wnd As Window In Application.Current.Windows
            If GetType(wndError) Is wnd.GetType Then
                w = wnd
                w.Show()
                w.Activate()
                If w.WindowState = WindowState.Minimized Then w.WindowState = WindowState.Normal
                Exit Sub
            End If
        Next

        w = New wndError
        w.Show()
    End Sub

End Class
