﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Этот код создан программой.
'     Исполняемая версия:4.0.30319.42000
'
'     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
'     повторной генерации кода.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'Этот класс создан автоматически классом StronglyTypedResourceBuilder
    'с помощью такого средства, как ResGen или Visual Studio.
    'Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    'с параметром /str или перестройте свой проект VS.
    '''<summary>
    '''  Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("ADViewer.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Перезаписывает свойство CurrentUICulture текущего потока для всех
        '''  обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property about() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("about", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Icon, аналогичного (Значок).
        '''</summary>
        Friend ReadOnly Property app() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("app", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Icon, аналогичного (Значок).
        '''</summary>
        Friend ReadOnly Property computer() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("computer", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Icon, аналогичного (Значок).
        '''</summary>
        Friend ReadOnly Property computer_blocked() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("computer_blocked", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Icon, аналогичного (Значок).
        '''</summary>
        Friend ReadOnly Property computer_expired() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("computer_expired", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property computer_image() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("computer_image", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Icon, аналогичного (Значок).
        '''</summary>
        Friend ReadOnly Property contact() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("contact", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property contact_image() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("contact_image", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Icon, аналогичного (Значок).
        '''</summary>
        Friend ReadOnly Property container() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("container", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property critical() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("critical", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Icon, аналогичного (Значок).
        '''</summary>
        Friend ReadOnly Property domain() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("domain", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property exclamation() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("exclamation", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Icon, аналогичного (Значок).
        '''</summary>
        Friend ReadOnly Property group() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("group", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Icon, аналогичного (Значок).
        '''</summary>
        Friend ReadOnly Property group_distribution() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("group_distribution", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property group_image() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("group_image", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property information() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("information", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property loading() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("loading", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Icon, аналогичного (Значок).
        '''</summary>
        Friend ReadOnly Property log() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("log", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Icon, аналогичного (Значок).
        '''</summary>
        Friend ReadOnly Property object_unknown() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("object_unknown", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Icon, аналогичного (Значок).
        '''</summary>
        Friend ReadOnly Property organizationalunit() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("organizationalunit", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Icon, аналогичного (Значок).
        '''</summary>
        Friend ReadOnly Property phone() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("phone", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property phone_error() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("phone_error", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property phone_registered() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("phone_registered", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property phone_registering() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("phone_registering", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Icon, аналогичного (Значок).
        '''</summary>
        Friend ReadOnly Property properties() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("properties", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property question() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("question", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Icon, аналогичного (Значок).
        '''</summary>
        Friend ReadOnly Property ready() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("ready", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Icon, аналогичного (Значок).
        '''</summary>
        Friend ReadOnly Property refresh() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("refresh", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property splash() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("splash", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Icon, аналогичного (Значок).
        '''</summary>
        Friend ReadOnly Property user() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("user", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Icon, аналогичного (Значок).
        '''</summary>
        Friend ReadOnly Property user_blocked() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("user_blocked", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Icon, аналогичного (Значок).
        '''</summary>
        Friend ReadOnly Property user_expired() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("user_expired", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  Поиск локализованного ресурса типа System.Drawing.Icon, аналогичного (Значок).
        '''</summary>
        Friend ReadOnly Property warning() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("warning", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
    End Module
End Namespace
