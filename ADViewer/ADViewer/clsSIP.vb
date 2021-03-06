﻿Imports System.ComponentModel
Imports System.Net
Imports System.Text
Imports LumiSoft.Net
Imports LumiSoft.Net.SIP.Stack

Public Class clsSIP
    Implements INotifyPropertyChanged

    Public Event PropertyChanged(sender As Object, e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

    Private _useragent As String = "ADViewer SIP Module"
    Private _localaddress As String = GetLocalIPAddress()
    Private _localport As Integer = 5060

    Dim sipstack As SIP_Stack
    Dim sipregistration As SIP_UA_Registration

    Dim lasturi As String
    Dim lasttimestamp As Date

    Private Sub NotifyPropertyChanged(propertyName As String)
        Me.OnPropertyChanged(New PropertyChangedEventArgs(propertyName))
    End Sub

    Protected Overridable Sub OnPropertyChanged(e As PropertyChangedEventArgs)
        RaiseEvent PropertyChanged(Me, e)
    End Sub

    Sub New()

    End Sub

    Public Sub Register()
        If String.IsNullOrEmpty(preferences.SipRegistrationName) Or String.IsNullOrEmpty(preferences.SipServer) Then Exit Sub

        sipstack = New SIP_Stack
        sipstack.UserAgent = _useragent
        sipstack.BindInfo = {New IPBindInfo(_localaddress, preferences.SipProtocol, IPAddress.Parse(_localaddress), _localport)}
        sipstack.Credentials.Clear()
        sipstack.Credentials.Add(New NetworkCredential(preferences.SipUsername, preferences.SipPassword, preferences.SipDomain))
        sipstack.Realm = preferences.SipDomain
        sipstack.Start()

        AddHandler sipstack.Error, AddressOf sipstack_Error
        AddHandler sipstack.RequestReceived, AddressOf sipstack_RequestReceived

        Dim registrarServer = SIP_Uri.Parse("sip:" & preferences.SipServer & ":5060")
        Dim aor = preferences.SipRegistrationName & "@" & preferences.SipServer
        Dim contact As AbsoluteUri = AbsoluteUri.Parse("sip:" & preferences.SipRegistrationName & "@" & _localaddress & ":" & _localport & ";transport=" & LCase(preferences.SipProtocol.ToString))

        sipregistration = sipstack.CreateRegistration(registrarServer, aor, contact, 3600)

        AddHandler sipregistration.Error, AddressOf sipregistration_Error
        AddHandler sipregistration.StateChanged, AddressOf sipregistration_StateChanged

        sipregistration.BeginRegister(True)

        NotifyPropertyChanged("StackState")
        NotifyPropertyChanged("RegistrationState")
        NotifyPropertyChanged("Image")
        NotifyPropertyChanged("Status")
    End Sub

    Public Sub Unregister()
        RemoveHandler sipregistration.Error, AddressOf sipregistration_Error
        RemoveHandler sipregistration.StateChanged, AddressOf sipregistration_StateChanged

        If sipstack Is Nothing Or sipregistration Is Nothing Then Exit Sub
        If sipregistration.State = SIP_UA_RegistrationState.Registered Then sipregistration.BeginUnregister(True)
        If sipstack.State = SIP_StackState.Started Then sipstack.Stop()

        sipregistration = Nothing
        sipstack = Nothing

        NotifyPropertyChanged("StackState")
        NotifyPropertyChanged("RegistrationState")
        NotifyPropertyChanged("Image")
        NotifyPropertyChanged("Status")
    End Sub

    Private Sub sipstack_Error(sender As Object, e As ExceptionEventArgs)
        'ThrowException(e.Exception, "sipstack_Error")
        NotifyPropertyChanged("StackState")
    End Sub

    Private Sub sipstack_RequestReceived(sender As Object, e As SIP_RequestReceivedEventArgs)
        Dim displayname As String = Encoding.UTF8.GetString(Encoding.GetEncoding(1251).GetBytes(e.Request.From.Address.DisplayName))
        Dim uri As String = e.Request.From.Address.Uri.Value
        Dim data As String = Encoding.UTF8.GetString(e.Request.Data)

        If Not lasturi = uri OrElse (Now - lasttimestamp).TotalSeconds > 10 Then
            Log("SIP invite recieved: " & displayname & " <" & uri & ">" & vbCrLf & data)
            ThrowSIPInformation(e.Request)
            lasturi = uri
            lasttimestamp = Now
        End If
    End Sub

    Private Sub sipregistration_Error(sender As Object, e As SIP_ResponseReceivedEventArgs)
        'ThrowCustomException(e.Response.ReasonPhrase)
        'NotifyPropertyChanged("RegistrationState")
        'NotifyPropertyChanged("Image")
    End Sub

    Private Sub sipregistration_StateChanged(sender As Object, e As EventArgs)
        Log("SIP registration state changed: " & CType(sender, SIP_UA_Registration).State.ToString)
        NotifyPropertyChanged("RegistrationState")
        NotifyPropertyChanged("Image")
        NotifyPropertyChanged("Status")
    End Sub

    Public ReadOnly Property Image() As BitmapImage
        Get
            Dim _image As String = ""

            If sipregistration Is Nothing Then
                _image = "img/phone_error.png"
            Else
                If sipregistration.State = SIP_UA_RegistrationState.Disposed Then
                    _image = "img/phone_error.png"
                ElseIf sipregistration.State = SIP_UA_RegistrationState.Error Then
                    _image = "img/phone_error.png"
                ElseIf sipregistration.State = SIP_UA_RegistrationState.Registered Then
                    _image = "img/phone_registered.png"
                ElseIf sipregistration.State = SIP_UA_RegistrationState.Registering Then
                    _image = "img/phone_registering.png"
                ElseIf sipregistration.State = SIP_UA_RegistrationState.Unregistered Then
                    _image = "img/phone_error.png"
                Else
                    _image = "img/question.png"
                End If
            End If

            Return New BitmapImage(New Uri("pack://application:,,,/" & _image))
        End Get
    End Property

    Public ReadOnly Property Status() As String
        Get
            If sipregistration Is Nothing Then
                Return "Не существует"
            Else
                If sipregistration.State = SIP_UA_RegistrationState.Disposed Then
                    Return "Подключение закрыто"
                ElseIf sipregistration.State = SIP_UA_RegistrationState.Error Then
                    Return "Ошибка регистрации"
                ElseIf sipregistration.State = SIP_UA_RegistrationState.Registered Then
                    Return "Зарегистрировано: " & sipregistration.AOR
                ElseIf sipregistration.State = SIP_UA_RegistrationState.Registering Then
                    Return "Регистрация..."
                ElseIf sipregistration.State = SIP_UA_RegistrationState.Unregistered Then
                    Return "Регистрация отменена"
                Else
                    Return "Так не бывает"
                End If
            End If
        End Get
    End Property

    Public ReadOnly Property StackState As String
        Get
            If sipstack IsNot Nothing Then
                Return sipstack.State.ToString
            Else
                Return "Unknown"
            End If
        End Get
    End Property

    Public ReadOnly Property RegistrationState As String
        Get
            If sipregistration IsNot Nothing Then
                Return sipregistration.State.ToString
            Else
                Return "Unknown"
            End If
        End Get
    End Property


End Class
