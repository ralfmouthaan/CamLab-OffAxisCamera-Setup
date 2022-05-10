' Ralf Mouthaan
' University of Cambridge
' November 2018
'
' Measurement setup class

Public Module Globals

    Public MeasurementSetup As clsMeasurementSetup

End Module

Public Class clsMeasurementSetup

    Private bolRunning As Boolean

    Private _SLMClock As IO.Ports.SerialPort
    Public InputCamera As clsThorlabsCamDC
    Public OutputCameraPol1 As clsThorlabsCamDC
    Public OutputCameraPol2 As clsThorlabsCamDC
    Public Property SLMClock As IO.Ports.SerialPort
        Get
            Return _SLMClock
        End Get
        Set(value As IO.Ports.SerialPort)

            _SLMClock = value
            InputCamera.portSLMClock = value
            OutputCameraPol1.portSLMClock = value
            OutputCameraPol2.portSLMClock = value

        End Set
    End Property

    Public Sub New()

        If IO.File.Exists("D:\RPM Data Files\Input Camera.txt") Then
            InputCamera = New clsThorlabsCamDC("D:\RPM Data Files\Input Camera.txt")
        Else
            InputCamera = New clsThorlabsCamDC
        End If
        If IO.File.Exists("D:\RPM Data Files\Output Camera Pol 1.txt") Then
            OutputCameraPol1 = New clsThorlabsCamDC("D:\RPM Data Files\Output Camera Pol 1.txt")
        Else
            OutputCameraPol1 = New clsThorlabsCamDC
        End If
        If IO.File.Exists("D:\RPM Data Files\Output Camera Pol 2.txt") Then
            OutputCameraPol2 = New clsThorlabsCamDC("D:\RPM Data Files\Output Camera Pol 2.txt")
        Else
            OutputCameraPol2 = New clsThorlabsCamDC
        End If

        InputCamera._strInstrumentName = "Input Camera"
        OutputCameraPol1._strInstrumentName = "Output Camera - Polarisation 1"
        OutputCameraPol2._strInstrumentName = "Output Camera - Polarisation 2"

        bolRunning = False

    End Sub

    Public Sub StartUp()

        If bolRunning = True Then Exit Sub

        If SLMClock IsNot Nothing Then SLMClock.Open()
        If InputCamera IsNot Nothing Then InputCamera.Startup(False)
        If OutputCameraPol1 IsNot Nothing Then OutputCameraPol1.Startup(False)
        If OutputCameraPol2 IsNot Nothing Then OutputCameraPol2.Startup(False)
        bolRunning = True

        If InputCamera IsNot Nothing Then InputCamera.Exposure = 6.86
        If OutputCameraPol1 IsNot Nothing Then OutputCameraPol1.Exposure = 6.86
        If OutputCameraPol2 IsNot Nothing Then OutputCameraPol2.Exposure = 6.86

    End Sub
    Public Sub ShutDown()

        If bolRunning = False Then Exit Sub

        If SLMClock IsNot Nothing Then SLMClock.Close()
        If InputCamera IsNot Nothing Then InputCamera.Shutdown()
        If OutputCameraPol1 IsNot Nothing Then OutputCameraPol1.Shutdown()
        If OutputCameraPol2 IsNot Nothing Then OutputCameraPol2.Shutdown()

        bolRunning = False

    End Sub

End Class
