﻿Imports EmberAPI

Public Class genericMediaSources
    Implements Interfaces.EmberExternalModule

    Private fMediaSources As frmMediaSources

    Public Property Enabled() As Boolean Implements EmberAPI.Interfaces.EmberExternalModule.Enabled
        Get
            Return True
        End Get
        Set(ByVal value As Boolean)
        End Set
    End Property

    Public Event GenericEvent(ByVal mType As EmberAPI.Enums.ModuleEventType, ByRef _params As System.Collections.Generic.List(Of Object)) Implements EmberAPI.Interfaces.EmberExternalModule.GenericEvent

    Public Sub Init(ByVal sAssemblyName As String) Implements EmberAPI.Interfaces.EmberExternalModule.Init

    End Sub

    Public Function InjectSetup() As EmberAPI.Containers.SettingsPanel Implements EmberAPI.Interfaces.EmberExternalModule.InjectSetup
        Dim SPanel As New Containers.SettingsPanel
        Me.fMediaSources = New frmMediaSources
        SPanel.Name = Master.eLang.GetString(61, "Media Sources Editor")
        SPanel.Text = Master.eLang.GetString(61, "Media Sources Editor")
        SPanel.Prefix = "MediaSourcesEditor_"
        SPanel.Type = Master.eLang.GetString(822, "Miscellaneous")
        SPanel.ImageIndex = -1
        SPanel.Image = My.Resources.MediaSourcesEditor
        SPanel.Order = 100
        SPanel.Panel = Me.fMediaSources.pnlGenres
        AddHandler Me.fMediaSources.ModuleSettingsChanged, AddressOf Handle_ModuleSettingsChanged
        Return SPanel
    End Function

    Private Sub Handle_ModuleSettingsChanged()
        RaiseEvent ModuleSettingsChanged()
    End Sub
    Public ReadOnly Property ModuleName() As String Implements EmberAPI.Interfaces.EmberExternalModule.ModuleName
        Get
            Return "Media Sources Editor"
        End Get
    End Property

    Public Event ModuleSettingsChanged() Implements EmberAPI.Interfaces.EmberExternalModule.ModuleSettingsChanged

    Public Event ModuleSetupChanged(ByVal Name As String, ByVal State As Boolean, ByVal diffOrder As Integer) Implements EmberAPI.Interfaces.EmberExternalModule.ModuleSetupChanged

    Public ReadOnly Property ModuleType() As System.Collections.Generic.List(Of EmberAPI.Enums.ModuleEventType) Implements EmberAPI.Interfaces.EmberExternalModule.ModuleType
        Get
            Return New List(Of Enums.ModuleEventType)(New Enums.ModuleEventType() {Enums.ModuleEventType.Generic})
        End Get
    End Property

    Public ReadOnly Property ModuleVersion() As String Implements EmberAPI.Interfaces.EmberExternalModule.ModuleVersion
        Get
            Return FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly.Location).FileVersion.ToString
        End Get
    End Property

    Public Function RunGeneric(ByVal mType As EmberAPI.Enums.ModuleEventType, ByRef _params As System.Collections.Generic.List(Of Object), ByRef _refparam As Object) As EmberAPI.Interfaces.ModuleResult Implements EmberAPI.Interfaces.EmberExternalModule.RunGeneric

    End Function

    Public Sub SaveSetup(ByVal DoDispose As Boolean) Implements EmberAPI.Interfaces.EmberExternalModule.SaveSetup
        If Not fMediaSources Is Nothing Then fMediaSources.SaveChanges()
    End Sub
End Class
