' Ralf Mouthaan
' University of Cambridge
' June 2019

Option Explicit On
Option Strict On

Imports System.ComponentModel

Public Class frmMain

    Private ActiveCamera As clsThorlabsCamDC

#Region "Startup + Shutdown"
    Private Sub frmMain_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        cmbTriggerMode.SelectedIndex = 0

        MeasurementSetup = New clsMeasurementSetup
        Call ActiveCameraChanged(sender, e)
        Call PlaneChanged(sender, e)
        Call ViewportChanged()

    End Sub
    Private Sub frmMain_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        MeasurementSetup.ShutDown()
    End Sub
#End Region

#Region "Image Capture"

    Private bolContinuousCapture As Boolean

    Private Sub cmdRefreshImage_Click(sender As Object, e As EventArgs) Handles cmdSingleCapture.Click

        DisableControls()
        ActiveCamera.Startup()
        ActiveCamera.GetIntegerImage() 'Sometimes first image is junk.
        Call PlaneChanged(sender, e)

        ActiveCamera.ImagePaddedWidth = CInt(nudImagePaddedWidth.Value)
        ActiveCamera.FFTPaddedWidth = CInt(nudFFTPaddedWidth.Value)

        ' Use camera to obtain correct image
        If radCameraImage.Checked Then
            picImagebox.IntegerData = ActiveCamera.GetIntegerImage
        ElseIf radFFTCameraImage.Checked = True Then
            picImagebox.Data = ActiveCamera.GetOffAxisFFTImage()
        ElseIf radComplexCameraImage.Checked = True Then
            picImagebox.Data = ActiveCamera.GetOffAxisComplexImage()
        End If

        'Refresh imagebox
        picImagebox.RefreshImage()
        picImagebox.Visible = True

        ActiveCamera.Shutdown()
        EnableControls()

    End Sub
    Private Sub cmdStartContinuous_Click(sender As Object, e As EventArgs) Handles cmdStartContinuous.Click

        ActiveCamera.Startup()
        Call PlaneChanged(sender, e) 'Ensures viewport is correct

        bolContinuousCapture = True

        'Turn off controls, except for stop continuous capture button
        grpbxCamera.Enabled = False
        grpbxCameraProperties.Enabled = False
        grpbxPlane.Enabled = False
        grpbxSave.Enabled = False
        cmdStartContinuous.Enabled = False
        cmdStopContinuous.Enabled = True
        Application.DoEvents()

        picImagebox.Visible = True

        ActiveCamera.ImagePaddedWidth = CInt(nudImagePaddedWidth.Value)
        ActiveCamera.FFTPaddedWidth = CInt(nudFFTPaddedWidth.Value)

        While bolContinuousCapture = True

            ' Use camera to obtain correct image
            If radCameraImage.Checked Then
                picImagebox.IntegerData = ActiveCamera.GetIntegerImage
            ElseIf radFFTCameraImage.Checked = True Then
                picImagebox.Data = ActiveCamera.GetOffAxisFFTImage()
            ElseIf radComplexCameraImage.Checked = True Then
                picImagebox.Data = ActiveCamera.GetOffAxisComplexImage()
            End If

            'Refresh imagebox
            picImagebox.RefreshImage()
            Application.DoEvents()

        End While

        'Turn on controls, turn off stop continuous capture button
        grpbxCamera.Enabled = True
        grpbxCameraProperties.Enabled = True
        grpbxPlane.Enabled = True
        grpbxSave.Enabled = True
        cmdStartContinuous.Enabled = True
        cmdStopContinuous.Enabled = False

        ActiveCamera.Shutdown()

    End Sub
    Private Sub cmdStopContinuous_Click(sender As Object, e As EventArgs) Handles cmdStopContinuous.Click
        bolContinuousCapture = False
    End Sub
#End Region

#Region "Enable + Disable Controls"
    Private Sub DisableControls()

        grpbxCamera.Enabled = False
        grpbxCameraProperties.Enabled = False
        grpbxPlane.Enabled = False
        grpbxSave.Enabled = False
        grpbxSetup.Enabled = False
        grpbxImageCapture.Enabled = False
        Application.DoEvents()

    End Sub
    Private Sub EnableControls()

        grpbxCamera.Enabled = True
        grpbxCameraProperties.Enabled = True
        grpbxPlane.Enabled = True
        grpbxSave.Enabled = True
        grpbxSetup.Enabled = True
        grpbxImageCapture.Enabled = True
        Application.DoEvents()

    End Sub
    Private Sub EnDisAbleCameraControls()

        If ActiveCamera.bolActive = False Then
            chkCameraActive.Checked = False
            nudCameraID.Enabled = False
            cmbTriggerMode.Enabled = False
            nudExposure.Enabled = False
            cmdAutoExposure.Enabled = False
            cmbArduinoPort.Enabled = False
            grpbxPlane.Enabled = False
            grpbxImageCapture.Enabled = False
        Else
            chkCameraActive.Checked = True
            nudCameraID.Enabled = True
            cmbTriggerMode.Enabled = True
            nudExposure.Enabled = True
            chkCameraActive.Checked = True
            cmdAutoExposure.Enabled = True
            If ActiveCamera.intTriggerMode = 2 Then
                cmbArduinoPort.Enabled = True
            Else
                cmbArduinoPort.Enabled = False
            End If
            grpbxPlane.Enabled = True
            grpbxImageCapture.Enabled = True
            cmdStartContinuous.Enabled = True
            cmdStopContinuous.Enabled = False
        End If

    End Sub
#End Region

#Region "Form Events"
    Private Sub CameraActiveChanged(sender As Object, e As EventArgs) Handles chkCameraActive.CheckedChanged

        If MeasurementSetup Is Nothing Then Exit Sub
        ActiveCamera.bolActive = chkCameraActive.Checked
        EnDisAbleCameraControls()

    End Sub
    Private Sub CameraIDChanged(sender As Object, e As EventArgs) Handles nudCameraID.ValueChanged

        If MeasurementSetup Is Nothing Then Exit Sub
        ActiveCamera.intCameraID = CInt(nudCameraID.Value)

    End Sub
    Private Sub CameraTriggerModeChanged(sender As Object, e As EventArgs) Handles cmbTriggerMode.SelectedValueChanged

        If MeasurementSetup Is Nothing Then Exit Sub
        ActiveCamera.intTriggerMode = cmbTriggerMode.SelectedIndex

        If cmbTriggerMode.SelectedIndex = 2 Then
            cmbArduinoPort.Enabled = True
            cmbArduinoPort.Items.Clear()
            cmbArduinoPort.Items.AddRange(IO.Ports.SerialPort.GetPortNames)
            If cmbArduinoPort.Items.Count > 0 Then
                cmbArduinoPort.SelectedIndex = 0
            End If
        Else
            cmbArduinoPort.Enabled = False
            cmbArduinoPort.Items.Clear()
        End If

    End Sub
    Private Sub ArduinoCommPortChanged(sender As Object, e As EventArgs) Handles cmbArduinoPort.SelectedValueChanged

        If MeasurementSetup Is Nothing Then Exit Sub
        MeasurementSetup.SLMClock = New IO.Ports.SerialPort(cmbArduinoPort.SelectedItem.ToString)

    End Sub
    Private Sub ActiveCameraChanged(sender As Object, e As EventArgs) Handles _
            radInputCamera.CheckedChanged, radOutputCameraPol1.CheckedChanged, radOutputCameraPol2.CheckedChanged

        If MeasurementSetup Is Nothing Then Exit Sub

        picImagebox.Data = Nothing
        picImagebox.Visible = False

        'Switch to new camera
        If radInputCamera.Checked = True Then
            ActiveCamera = MeasurementSetup.InputCamera
        ElseIf radOutputCameraPol1.Checked = True Then
            ActiveCamera = MeasurementSetup.OutputCameraPol1
        ElseIf radOutputCameraPol2.Checked = True Then
            ActiveCamera = MeasurementSetup.OutputCameraPol2
        End If

        'Update camera settings
        nudCameraID.Value = ActiveCamera.intCameraID
        cmbTriggerMode.SelectedIndex = ActiveCamera.intTriggerMode
        nudExposure.Value = CDec(ActiveCamera.Exposure)
        If cmbTriggerMode.SelectedIndex = 2 Then
            cmbArduinoPort.SelectedValue = ActiveCamera.portSLMClock.PortName
        End If
        chkCameraActive.Checked = ActiveCamera.bolActive
        nudFFTPaddedWidth.Value = CDec(ActiveCamera.FFTPaddedWidth)
        nudImagePaddedWidth.Value = CDec(ActiveCamera.ImagePaddedWidth)

        Call EnDisAbleCameraControls()
        Call PlaneChanged(sender, e)

        'Set back to regular camera image
        radCameraImage.Checked = True

    End Sub
    Private Sub PlaneChanged(sender As Object, e As EventArgs) Handles _
            radCameraImage.CheckedChanged, radFFTCameraImage.CheckedChanged, radComplexCameraImage.CheckedChanged, radComplexImage.CheckedChanged

        If MeasurementSetup Is Nothing Then Exit Sub

        picImagebox.Data = Nothing
        picImagebox.Visible = False

        'Switch to new camera
        If radCameraImage.Checked = True Then
            picImagebox.Viewport = ActiveCamera.OffAxisImageViewport 'Doing this already refreshes image
        ElseIf radFFTCameraImage.Checked = True Then
            picImagebox.Viewport = ActiveCamera.OffAxisFFTViewport  'Doing this already refreshes image
        ElseIf radComplexCameraImage.Checked = True Then
            If ActiveCamera.FFTPaddedWidth > ActiveCamera.OffAxisFFTViewport.Width And ActiveCamera.FFTPaddedWidth > ActiveCamera.OffAxisFFTViewport.Height Then
                picImagebox.Viewport = New Rectangle With
                    {.X = 0, .Y = 0, .Width = ActiveCamera.FFTPaddedWidth, .Height = ActiveCamera.FFTPaddedWidth}
            Else
                picImagebox.Viewport = New Rectangle With
                    {.X = 0, .Y = 0, .Width = ActiveCamera.OffAxisFFTViewport.Width, .Height = ActiveCamera.OffAxisFFTViewport.Height}  'Doing this already refreshes image
            End If
        End If

    End Sub
    Private Sub ExposureTimeChanged(sender As Object, e As EventArgs) Handles nudExposure.ValueChanged
        If MeasurementSetup Is Nothing Then Exit Sub
        ActiveCamera.Exposure = nudExposure.Value
        picImagebox.Data = Nothing
        picImagebox.Visible = False
        nudExposure.ForeColor = Color.Black
    End Sub
    Private Sub ViewportChanged() Handles picImagebox.ViewPortChanged

        If ActiveCamera Is Nothing Then Exit Sub

        If radCameraImage.Checked = True Then
            ActiveCamera.OffAxisImageViewport = picImagebox.Viewport
        ElseIf radFFTCameraImage.Checked = True Then
            ActiveCamera.OffAxisFFTViewport = picImagebox.Viewport
        End If

    End Sub
    Private Sub cmdAutoExposure_Click(sender As Object, e As EventArgs) Handles cmdAutoExposure.Click

        ActiveCamera.Exposure = 6.86

        Dim Img(,) As Integer
        Dim max As Integer

        While True

            Img = ActiveCamera.GetIntegerImage

            For i = ActiveCamera.OffAxisImageViewport.Left To ActiveCamera.OffAxisImageViewport.Right - 1
                For j = ActiveCamera.OffAxisImageViewport.Top To ActiveCamera.OffAxisImageViewport.Bottom - 1
                    If Img(i, j) > max Then max = Img(i, j)
                Next
            Next

            If max >= 180 Then
                Exit While
            Else
                ActiveCamera.Exposure += 6.86
            End If

            If ActiveCamera.Exposure > 100 Then
                ActiveCamera.Exposure = 100
                Exit While
            End If

        End While

        If max = 255 Then nudExposure.ForeColor = Color.Red
        If ActiveCamera.Exposure > 100 Then nudExposure.ForeColor = Color.Red

        nudExposure.Value = CDec(ActiveCamera.Exposure)

    End Sub
#End Region

#Region "Save + Load Camera"
    Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSaveCamera.Click

        If MeasurementSetup.InputCamera IsNot Nothing AndAlso MeasurementSetup.InputCamera.bolActive = True Then
            MeasurementSetup.InputCamera.Save("D:\RPM Data Files\Input Camera.txt")
        End If
        If MeasurementSetup.OutputCameraPol1 IsNot Nothing AndAlso MeasurementSetup.OutputCameraPol1.bolActive = True Then
            MeasurementSetup.OutputCameraPol1.Save("D:\RPM Data Files\Output Camera Pol 1.txt")
        End If
        If MeasurementSetup.OutputCameraPol2 IsNot Nothing AndAlso MeasurementSetup.OutputCameraPol2.bolActive = True Then
            MeasurementSetup.OutputCameraPol2.Save("D:\RPM Data Files\Output Camera Pol 2.txt")
        End If

    End Sub
    Private Sub cmdLoadCamera_Click(sender As Object, e As EventArgs) Handles cmdLoadCamera.Click

        MeasurementSetup.ShutDown()
        MeasurementSetup = New clsMeasurementSetup

        Call ActiveCameraChanged(sender, e)
        Call PlaneChanged(sender, e)
        Call ViewportChanged()

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Closing

        MeasurementSetup.ShutDown()

    End Sub

    Private Sub nudFFTPaddedWidth_ValueChanged(sender As Object, e As EventArgs) Handles nudFFTPaddedWidth.ValueChanged, nudImagePaddedWidth.ValueChanged

        If ActiveCamera Is Nothing Then Exit Sub

        ActiveCamera.FFTPaddedWidth = CInt(nudFFTPaddedWidth.Value)
        ActiveCamera.ImagePaddedWidth = CInt(nudImagePaddedWidth.Value)

    End Sub

#End Region

End Class