' Ralf Mouthaan
' University of Cambridge
' November 2019
'
' Class to control Basler camera

Option Explicit On
Option Strict On

Public Class clsBaslerCamera
    Inherits clsCamera

    Private cam As Basler.Pylon.Camera
    Private _ImageWidth As Integer
    Private _ImageHeight As Integer

    Public Sub New(ByVal CameraID As Integer, Optional ByRef _portSLMClock As IO.Ports.SerialPort = Nothing)
        _strInstrumentName = "Basler Camera"
    End Sub

    Public Overrides Sub Startup(Optional bolShow As Boolean = False)

        If bolConnectionOpen = True Then Exit Sub

        Dim grabresult As Basler.Pylon.IGrabResult

        'Camera startup
        cam = New Basler.Pylon.Camera
        AddHandler cam.CameraOpened, AddressOf Basler.Pylon.Configuration.SoftwareTrigger
        cam.Open()

        cam.StreamGrabber.Start(Basler.Pylon.GrabStrategy.OneByOne, Basler.Pylon.GrabLoop.ProvidedByUser)
        cam.ExecuteSoftwareTrigger()
        grabresult = cam.StreamGrabber.RetrieveResult(500, Basler.Pylon.TimeoutHandling.ThrowException)
        cam.StreamGrabber.Stop()
        If grabresult.GrabSucceeded Then
            _ImageWidth = grabresult.Width
            _ImageHeight = grabresult.Height
        Else
            Call Err.Raise(-1, "Basler Camera", "Error Grabbing image")
        End If
        grabresult.Dispose()

        'Base startup
        MyBase.Startup()

    End Sub
    Public Overrides Sub Shutdown()
        If bolConnectionOpen = False Then Exit Sub
        cam.Close()
        MyBase.Shutdown()
    End Sub
    Public Overrides ReadOnly Property ImageWidth As Integer
        Get
            Return _ImageWidth
        End Get
    End Property
    Public Overrides ReadOnly Property ImageHeight As Integer
        Get
            Return _ImageHeight
        End Get
    End Property

    Public Overrides Property Exposure As Double
        Get
            If bolConnectionOpen = False Then Startup()
            Return cam.Parameters(Basler.Pylon.PLCamera.ExposureTime).GetValue() / 1000
        End Get
        Set(value As Double)
            If bolConnectionOpen = False Then Startup()
            cam.Parameters(Basler.Pylon.PLCamera.ExposureTime).SetValue(value * 1000)
        End Set
    End Property

    Public Overrides Sub SaveImage(Filename As String)
        Throw New NotImplementedException()
    End Sub

    Public Overrides Function GetIntegerImage(Optional NoFrames As Integer = -1) As Integer(,)

        Dim grabresult As Basler.Pylon.IGrabResult = Nothing
        Dim bData As Byte()
        Dim iData As Integer(,)
        Dim bf As Runtime.Serialization.Formatters.Binary.BinaryFormatter
        Dim ms As IO.MemoryStream
        Dim i As Integer

        cam.StreamGrabber.Start(Basler.Pylon.GrabStrategy.OneByOne, Basler.Pylon.GrabLoop.ProvidedByUser)
        cam.ExecuteSoftwareTrigger()
        grabresult = cam.StreamGrabber.RetrieveResult(500, Basler.Pylon.TimeoutHandling.ThrowException)
        cam.StreamGrabber.Stop()

        If grabresult.GrabSucceeded = False Then
            Call Err.Raise(-1, "Basler Camera", "Error Grabbing image")
        End If

        _ImageWidth = grabresult.Width
        _ImageHeight = grabresult.Height

        'Convert PixelData object to byte array
        bf = New Runtime.Serialization.Formatters.Binary.BinaryFormatter
        ms = New IO.MemoryStream
        bf.Serialize(ms, grabresult.PixelData)
        bData = ms.ToArray()

        'Convert byte array to integer array
        ReDim iData(ImageWidth - 1, ImageHeight - 1)
        For i = 0 To ImageWidth - 1
            For j = 0 To ImageHeight - 1
                iData(i, j) = bData(j * ImageWidth + i)
            Next
        Next

        grabresult.Dispose()
        ms.Dispose()

        Return iData

    End Function
End Class
