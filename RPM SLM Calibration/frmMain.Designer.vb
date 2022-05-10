<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.grpbxCameraProperties = New System.Windows.Forms.GroupBox()
        Me.cmdAutoExposure = New System.Windows.Forms.Button()
        Me.cmbArduinoPort = New System.Windows.Forms.ComboBox()
        Me.lblArduinoPort = New System.Windows.Forms.Label()
        Me.nudCameraID = New System.Windows.Forms.NumericUpDown()
        Me.lblCameraID = New System.Windows.Forms.Label()
        Me.cmbTriggerMode = New System.Windows.Forms.ComboBox()
        Me.lblTriggerMode = New System.Windows.Forms.Label()
        Me.chkCameraActive = New System.Windows.Forms.CheckBox()
        Me.nudExposure = New System.Windows.Forms.NumericUpDown()
        Me.cmdExposure = New System.Windows.Forms.Label()
        Me.radComplexCameraImage = New System.Windows.Forms.RadioButton()
        Me.radFFTCameraImage = New System.Windows.Forms.RadioButton()
        Me.radCameraImage = New System.Windows.Forms.RadioButton()
        Me.radInputCamera = New System.Windows.Forms.RadioButton()
        Me.radOutputCameraPol2 = New System.Windows.Forms.RadioButton()
        Me.radOutputCameraPol1 = New System.Windows.Forms.RadioButton()
        Me.radComplexImage = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.radSingleInputPolarisation = New System.Windows.Forms.RadioButton()
        Me.radFFTBackgroundField = New System.Windows.Forms.RadioButton()
        Me.cmdSaveCamera = New System.Windows.Forms.Button()
        Me.cmdLoadCamera = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.grpbxCamera = New System.Windows.Forms.GroupBox()
        Me.grpbxPlane = New System.Windows.Forms.GroupBox()
        Me.grpbxImageCapture = New System.Windows.Forms.GroupBox()
        Me.cmdStopContinuous = New System.Windows.Forms.Button()
        Me.cmdStartContinuous = New System.Windows.Forms.Button()
        Me.cmdSingleCapture = New System.Windows.Forms.Button()
        Me.grpbxSetup = New System.Windows.Forms.GroupBox()
        Me.grpbxSave = New System.Windows.Forms.GroupBox()
        Me.grpbxFFT = New System.Windows.Forms.GroupBox()
        Me.nudFFTPaddedWidth = New System.Windows.Forms.NumericUpDown()
        Me.lblFFTPaddedWidth = New System.Windows.Forms.Label()
        Me.nudImagePaddedWidth = New System.Windows.Forms.NumericUpDown()
        Me.lblImagePaddedWidth = New System.Windows.Forms.Label()
        Me.picImagebox = New RPM_SLM_Calibration.ctrlComplexImagebox()
        Me.grpbxCameraProperties.SuspendLayout()
        CType(Me.nudCameraID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudExposure, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpbxCamera.SuspendLayout()
        Me.grpbxPlane.SuspendLayout()
        Me.grpbxImageCapture.SuspendLayout()
        Me.grpbxSave.SuspendLayout()
        Me.grpbxFFT.SuspendLayout()
        CType(Me.nudFFTPaddedWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudImagePaddedWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpbxCameraProperties
        '
        Me.grpbxCameraProperties.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpbxCameraProperties.Controls.Add(Me.cmdAutoExposure)
        Me.grpbxCameraProperties.Controls.Add(Me.cmbArduinoPort)
        Me.grpbxCameraProperties.Controls.Add(Me.lblArduinoPort)
        Me.grpbxCameraProperties.Controls.Add(Me.nudCameraID)
        Me.grpbxCameraProperties.Controls.Add(Me.lblCameraID)
        Me.grpbxCameraProperties.Controls.Add(Me.cmbTriggerMode)
        Me.grpbxCameraProperties.Controls.Add(Me.lblTriggerMode)
        Me.grpbxCameraProperties.Controls.Add(Me.chkCameraActive)
        Me.grpbxCameraProperties.Controls.Add(Me.nudExposure)
        Me.grpbxCameraProperties.Controls.Add(Me.cmdExposure)
        Me.grpbxCameraProperties.Location = New System.Drawing.Point(860, 118)
        Me.grpbxCameraProperties.Name = "grpbxCameraProperties"
        Me.grpbxCameraProperties.Size = New System.Drawing.Size(323, 165)
        Me.grpbxCameraProperties.TabIndex = 1
        Me.grpbxCameraProperties.TabStop = False
        Me.grpbxCameraProperties.Text = "Setup"
        '
        'cmdAutoExposure
        '
        Me.cmdAutoExposure.Location = New System.Drawing.Point(219, 74)
        Me.cmdAutoExposure.Name = "cmdAutoExposure"
        Me.cmdAutoExposure.Size = New System.Drawing.Size(75, 23)
        Me.cmdAutoExposure.TabIndex = 9
        Me.cmdAutoExposure.Text = "Auto"
        Me.cmdAutoExposure.UseVisualStyleBackColor = True
        '
        'cmbArduinoPort
        '
        Me.cmbArduinoPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbArduinoPort.FormattingEnabled = True
        Me.cmbArduinoPort.Location = New System.Drawing.Point(93, 130)
        Me.cmbArduinoPort.Name = "cmbArduinoPort"
        Me.cmbArduinoPort.Size = New System.Drawing.Size(121, 21)
        Me.cmbArduinoPort.TabIndex = 8
        '
        'lblArduinoPort
        '
        Me.lblArduinoPort.AutoSize = True
        Me.lblArduinoPort.Location = New System.Drawing.Point(19, 133)
        Me.lblArduinoPort.Name = "lblArduinoPort"
        Me.lblArduinoPort.Size = New System.Drawing.Size(68, 13)
        Me.lblArduinoPort.TabIndex = 7
        Me.lblArduinoPort.Text = "Arduino Port:"
        '
        'nudCameraID
        '
        Me.nudCameraID.Location = New System.Drawing.Point(93, 51)
        Me.nudCameraID.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudCameraID.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudCameraID.Name = "nudCameraID"
        Me.nudCameraID.Size = New System.Drawing.Size(120, 20)
        Me.nudCameraID.TabIndex = 6
        Me.nudCameraID.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblCameraID
        '
        Me.lblCameraID.AutoSize = True
        Me.lblCameraID.Location = New System.Drawing.Point(27, 51)
        Me.lblCameraID.Name = "lblCameraID"
        Me.lblCameraID.Size = New System.Drawing.Size(60, 13)
        Me.lblCameraID.TabIndex = 5
        Me.lblCameraID.Text = "Camera ID:"
        '
        'cmbTriggerMode
        '
        Me.cmbTriggerMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTriggerMode.FormattingEnabled = True
        Me.cmbTriggerMode.Items.AddRange(New Object() {"Free Run", "Hirose", "Arduino"})
        Me.cmbTriggerMode.Location = New System.Drawing.Point(93, 103)
        Me.cmbTriggerMode.Name = "cmbTriggerMode"
        Me.cmbTriggerMode.Size = New System.Drawing.Size(120, 21)
        Me.cmbTriggerMode.TabIndex = 4
        '
        'lblTriggerMode
        '
        Me.lblTriggerMode.AutoSize = True
        Me.lblTriggerMode.Location = New System.Drawing.Point(15, 106)
        Me.lblTriggerMode.Name = "lblTriggerMode"
        Me.lblTriggerMode.Size = New System.Drawing.Size(73, 13)
        Me.lblTriggerMode.TabIndex = 3
        Me.lblTriggerMode.Text = "Trigger Mode:"
        '
        'chkCameraActive
        '
        Me.chkCameraActive.AutoSize = True
        Me.chkCameraActive.Location = New System.Drawing.Point(7, 19)
        Me.chkCameraActive.Name = "chkCameraActive"
        Me.chkCameraActive.Size = New System.Drawing.Size(95, 17)
        Me.chkCameraActive.TabIndex = 2
        Me.chkCameraActive.Text = "Camera Active"
        Me.chkCameraActive.UseVisualStyleBackColor = True
        '
        'nudExposure
        '
        Me.nudExposure.DecimalPlaces = 2
        Me.nudExposure.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.nudExposure.Location = New System.Drawing.Point(93, 77)
        Me.nudExposure.Minimum = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.nudExposure.Name = "nudExposure"
        Me.nudExposure.Size = New System.Drawing.Size(120, 20)
        Me.nudExposure.TabIndex = 1
        Me.nudExposure.Value = New Decimal(New Integer() {1, 0, 0, 131072})
        '
        'cmdExposure
        '
        Me.cmdExposure.AutoSize = True
        Me.cmdExposure.Location = New System.Drawing.Point(33, 79)
        Me.cmdExposure.Name = "cmdExposure"
        Me.cmdExposure.Size = New System.Drawing.Size(54, 13)
        Me.cmdExposure.TabIndex = 0
        Me.cmdExposure.Text = "Exposure:"
        '
        'radComplexCameraImage
        '
        Me.radComplexCameraImage.AutoSize = True
        Me.radComplexCameraImage.Location = New System.Drawing.Point(7, 65)
        Me.radComplexCameraImage.Name = "radComplexCameraImage"
        Me.radComplexCameraImage.Size = New System.Drawing.Size(136, 17)
        Me.radComplexCameraImage.TabIndex = 2
        Me.radComplexCameraImage.Text = "Complex Camera Image"
        Me.radComplexCameraImage.UseVisualStyleBackColor = True
        '
        'radFFTCameraImage
        '
        Me.radFFTCameraImage.AutoSize = True
        Me.radFFTCameraImage.Location = New System.Drawing.Point(7, 42)
        Me.radFFTCameraImage.Name = "radFFTCameraImage"
        Me.radFFTCameraImage.Size = New System.Drawing.Size(115, 17)
        Me.radFFTCameraImage.TabIndex = 1
        Me.radFFTCameraImage.Text = "FFT Camera Image"
        Me.radFFTCameraImage.UseVisualStyleBackColor = True
        '
        'radCameraImage
        '
        Me.radCameraImage.AutoSize = True
        Me.radCameraImage.Checked = True
        Me.radCameraImage.Location = New System.Drawing.Point(7, 19)
        Me.radCameraImage.Name = "radCameraImage"
        Me.radCameraImage.Size = New System.Drawing.Size(93, 17)
        Me.radCameraImage.TabIndex = 0
        Me.radCameraImage.TabStop = True
        Me.radCameraImage.Text = "Camera Image"
        Me.radCameraImage.UseVisualStyleBackColor = True
        '
        'radInputCamera
        '
        Me.radInputCamera.AutoSize = True
        Me.radInputCamera.Checked = True
        Me.radInputCamera.Location = New System.Drawing.Point(7, 19)
        Me.radInputCamera.Name = "radInputCamera"
        Me.radInputCamera.Size = New System.Drawing.Size(88, 17)
        Me.radInputCamera.TabIndex = 3
        Me.radInputCamera.TabStop = True
        Me.radInputCamera.Text = "Input Camera"
        Me.radInputCamera.UseVisualStyleBackColor = True
        '
        'radOutputCameraPol2
        '
        Me.radOutputCameraPol2.AutoSize = True
        Me.radOutputCameraPol2.Location = New System.Drawing.Point(7, 63)
        Me.radOutputCameraPol2.Name = "radOutputCameraPol2"
        Me.radOutputCameraPol2.Size = New System.Drawing.Size(168, 17)
        Me.radOutputCameraPol2.TabIndex = 5
        Me.radOutputCameraPol2.TabStop = True
        Me.radOutputCameraPol2.Text = "Output Camera - Polarisation 2"
        Me.radOutputCameraPol2.UseVisualStyleBackColor = True
        '
        'radOutputCameraPol1
        '
        Me.radOutputCameraPol1.AutoSize = True
        Me.radOutputCameraPol1.Location = New System.Drawing.Point(7, 42)
        Me.radOutputCameraPol1.Name = "radOutputCameraPol1"
        Me.radOutputCameraPol1.Size = New System.Drawing.Size(168, 17)
        Me.radOutputCameraPol1.TabIndex = 4
        Me.radOutputCameraPol1.TabStop = True
        Me.radOutputCameraPol1.Text = "Output Camera - Polarisation 1"
        Me.radOutputCameraPol1.UseVisualStyleBackColor = True
        '
        'radComplexImage
        '
        Me.radComplexImage.AutoSize = True
        Me.radComplexImage.Location = New System.Drawing.Point(3, 49)
        Me.radComplexImage.Name = "radComplexImage"
        Me.radComplexImage.Size = New System.Drawing.Size(136, 17)
        Me.radComplexImage.TabIndex = 2
        Me.radComplexImage.Text = "Complex Camera Image"
        Me.radComplexImage.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(169, 26)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(130, 17)
        Me.RadioButton1.TabIndex = 4
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "FFT Background Field"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'radSingleInputPolarisation
        '
        Me.radSingleInputPolarisation.AutoSize = True
        Me.radSingleInputPolarisation.Checked = True
        Me.radSingleInputPolarisation.Location = New System.Drawing.Point(3, 3)
        Me.radSingleInputPolarisation.Name = "radSingleInputPolarisation"
        Me.radSingleInputPolarisation.Size = New System.Drawing.Size(138, 17)
        Me.radSingleInputPolarisation.TabIndex = 0
        Me.radSingleInputPolarisation.TabStop = True
        Me.radSingleInputPolarisation.Text = "Single Polarisation"
        Me.radSingleInputPolarisation.UseVisualStyleBackColor = True
        '
        'radFFTBackgroundField
        '
        Me.radFFTBackgroundField.AutoSize = True
        Me.radFFTBackgroundField.Location = New System.Drawing.Point(169, 26)
        Me.radFFTBackgroundField.Name = "radFFTBackgroundField"
        Me.radFFTBackgroundField.Size = New System.Drawing.Size(105, 17)
        Me.radFFTBackgroundField.TabIndex = 4
        Me.radFFTBackgroundField.TabStop = True
        Me.radFFTBackgroundField.Text = "FFT Background"
        Me.radFFTBackgroundField.UseVisualStyleBackColor = True
        '
        'cmdSaveCamera
        '
        Me.cmdSaveCamera.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSaveCamera.Location = New System.Drawing.Point(7, 19)
        Me.cmdSaveCamera.Name = "cmdSaveCamera"
        Me.cmdSaveCamera.Size = New System.Drawing.Size(140, 30)
        Me.cmdSaveCamera.TabIndex = 2
        Me.cmdSaveCamera.Text = "Save Cameras"
        Me.cmdSaveCamera.UseVisualStyleBackColor = True
        '
        'cmdLoadCamera
        '
        Me.cmdLoadCamera.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdLoadCamera.Location = New System.Drawing.Point(177, 19)
        Me.cmdLoadCamera.Name = "cmdLoadCamera"
        Me.cmdLoadCamera.Size = New System.Drawing.Size(140, 30)
        Me.cmdLoadCamera.TabIndex = 3
        Me.cmdLoadCamera.Text = "Load Cameras"
        Me.cmdLoadCamera.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(866, 283)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(140, 30)
        Me.cmdSave.TabIndex = 2
        Me.cmdSave.Text = "Save Camera"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'grpbxCamera
        '
        Me.grpbxCamera.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpbxCamera.Controls.Add(Me.radInputCamera)
        Me.grpbxCamera.Controls.Add(Me.radOutputCameraPol2)
        Me.grpbxCamera.Controls.Add(Me.radOutputCameraPol1)
        Me.grpbxCamera.Location = New System.Drawing.Point(860, 12)
        Me.grpbxCamera.Name = "grpbxCamera"
        Me.grpbxCamera.Size = New System.Drawing.Size(323, 100)
        Me.grpbxCamera.TabIndex = 4
        Me.grpbxCamera.TabStop = False
        Me.grpbxCamera.Text = "Camera"
        '
        'grpbxPlane
        '
        Me.grpbxPlane.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpbxPlane.Controls.Add(Me.radComplexCameraImage)
        Me.grpbxPlane.Controls.Add(Me.radFFTCameraImage)
        Me.grpbxPlane.Controls.Add(Me.radCameraImage)
        Me.grpbxPlane.Location = New System.Drawing.Point(860, 368)
        Me.grpbxPlane.Name = "grpbxPlane"
        Me.grpbxPlane.Size = New System.Drawing.Size(323, 91)
        Me.grpbxPlane.TabIndex = 5
        Me.grpbxPlane.TabStop = False
        Me.grpbxPlane.Text = "Plane"
        '
        'grpbxImageCapture
        '
        Me.grpbxImageCapture.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpbxImageCapture.Controls.Add(Me.cmdStopContinuous)
        Me.grpbxImageCapture.Controls.Add(Me.cmdStartContinuous)
        Me.grpbxImageCapture.Controls.Add(Me.cmdSingleCapture)
        Me.grpbxImageCapture.Location = New System.Drawing.Point(860, 465)
        Me.grpbxImageCapture.Name = "grpbxImageCapture"
        Me.grpbxImageCapture.Size = New System.Drawing.Size(323, 82)
        Me.grpbxImageCapture.TabIndex = 6
        Me.grpbxImageCapture.TabStop = False
        Me.grpbxImageCapture.Text = "Image Capture"
        '
        'cmdStopContinuous
        '
        Me.cmdStopContinuous.Location = New System.Drawing.Point(178, 50)
        Me.cmdStopContinuous.Name = "cmdStopContinuous"
        Me.cmdStopContinuous.Size = New System.Drawing.Size(139, 23)
        Me.cmdStopContinuous.TabIndex = 2
        Me.cmdStopContinuous.Text = "Stop Continuous Capture"
        Me.cmdStopContinuous.UseVisualStyleBackColor = True
        '
        'cmdStartContinuous
        '
        Me.cmdStartContinuous.Location = New System.Drawing.Point(4, 50)
        Me.cmdStartContinuous.Name = "cmdStartContinuous"
        Me.cmdStartContinuous.Size = New System.Drawing.Size(139, 23)
        Me.cmdStartContinuous.TabIndex = 1
        Me.cmdStartContinuous.Text = "Start Continuous Capture"
        Me.cmdStartContinuous.UseVisualStyleBackColor = True
        '
        'cmdSingleCapture
        '
        Me.cmdSingleCapture.Location = New System.Drawing.Point(104, 19)
        Me.cmdSingleCapture.Name = "cmdSingleCapture"
        Me.cmdSingleCapture.Size = New System.Drawing.Size(109, 25)
        Me.cmdSingleCapture.TabIndex = 0
        Me.cmdSingleCapture.Text = "Single Capture"
        Me.cmdSingleCapture.UseVisualStyleBackColor = True
        '
        'grpbxSetup
        '
        Me.grpbxSetup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpbxSetup.Location = New System.Drawing.Point(859, 12)
        Me.grpbxSetup.Name = "grpbxSetup"
        Me.grpbxSetup.Size = New System.Drawing.Size(323, 399)
        Me.grpbxSetup.TabIndex = 1
        Me.grpbxSetup.TabStop = False
        Me.grpbxSetup.Text = "Setup"
        '
        'grpbxSave
        '
        Me.grpbxSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpbxSave.Controls.Add(Me.cmdSaveCamera)
        Me.grpbxSave.Controls.Add(Me.cmdLoadCamera)
        Me.grpbxSave.Location = New System.Drawing.Point(860, 553)
        Me.grpbxSave.Name = "grpbxSave"
        Me.grpbxSave.Size = New System.Drawing.Size(323, 60)
        Me.grpbxSave.TabIndex = 7
        Me.grpbxSave.TabStop = False
        Me.grpbxSave.Text = "Save"
        '
        'grpbxFFT
        '
        Me.grpbxFFT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpbxFFT.Controls.Add(Me.nudFFTPaddedWidth)
        Me.grpbxFFT.Controls.Add(Me.lblFFTPaddedWidth)
        Me.grpbxFFT.Controls.Add(Me.nudImagePaddedWidth)
        Me.grpbxFFT.Controls.Add(Me.lblImagePaddedWidth)
        Me.grpbxFFT.Location = New System.Drawing.Point(860, 289)
        Me.grpbxFFT.Name = "grpbxFFT"
        Me.grpbxFFT.Size = New System.Drawing.Size(323, 73)
        Me.grpbxFFT.TabIndex = 8
        Me.grpbxFFT.TabStop = False
        Me.grpbxFFT.Text = "FFT"
        '
        'nudFFTPaddedWidth
        '
        Me.nudFFTPaddedWidth.Location = New System.Drawing.Point(136, 45)
        Me.nudFFTPaddedWidth.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudFFTPaddedWidth.Name = "nudFFTPaddedWidth"
        Me.nudFFTPaddedWidth.Size = New System.Drawing.Size(120, 20)
        Me.nudFFTPaddedWidth.TabIndex = 8
        Me.nudFFTPaddedWidth.Value = New Decimal(New Integer() {200, 0, 0, 0})
        '
        'lblFFTPaddedWidth
        '
        Me.lblFFTPaddedWidth.AutoSize = True
        Me.lblFFTPaddedWidth.Location = New System.Drawing.Point(20, 47)
        Me.lblFFTPaddedWidth.Name = "lblFFTPaddedWidth"
        Me.lblFFTPaddedWidth.Size = New System.Drawing.Size(100, 13)
        Me.lblFFTPaddedWidth.TabIndex = 7
        Me.lblFFTPaddedWidth.Text = "FFT Padded Width:"
        '
        'nudImagePaddedWidth
        '
        Me.nudImagePaddedWidth.Location = New System.Drawing.Point(136, 19)
        Me.nudImagePaddedWidth.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudImagePaddedWidth.Name = "nudImagePaddedWidth"
        Me.nudImagePaddedWidth.Size = New System.Drawing.Size(120, 20)
        Me.nudImagePaddedWidth.TabIndex = 6
        '
        'lblImagePaddedWidth
        '
        Me.lblImagePaddedWidth.AutoSize = True
        Me.lblImagePaddedWidth.Location = New System.Drawing.Point(20, 21)
        Me.lblImagePaddedWidth.Name = "lblImagePaddedWidth"
        Me.lblImagePaddedWidth.Size = New System.Drawing.Size(110, 13)
        Me.lblImagePaddedWidth.TabIndex = 5
        Me.lblImagePaddedWidth.Text = "Image Padded Width:"
        '
        'picImagebox
        '
        Me.picImagebox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picImagebox.AutoScroll = True
        Me.picImagebox.bolShowLogMagnitude = True
        Me.picImagebox.bolShowMagnitude = True
        Me.picImagebox.bolShowMagnitudePhase = True
        Me.picImagebox.bolShowPhase = False
        Me.picImagebox.Data = Nothing
        Me.picImagebox.Location = New System.Drawing.Point(12, 12)
        Me.picImagebox.Name = "picImagebox"
        Me.picImagebox.Size = New System.Drawing.Size(842, 464)
        Me.picImagebox.TabIndex = 0
        Me.picImagebox.Viewport = New System.Drawing.Rectangle(0, 0, 0, 0)
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1195, 623)
        Me.Controls.Add(Me.grpbxFFT)
        Me.Controls.Add(Me.grpbxSave)
        Me.Controls.Add(Me.grpbxImageCapture)
        Me.Controls.Add(Me.grpbxPlane)
        Me.Controls.Add(Me.grpbxCamera)
        Me.Controls.Add(Me.grpbxCameraProperties)
        Me.Controls.Add(Me.picImagebox)
        Me.Name = "frmMain"
        Me.Text = "RPM Camera Setup"
        Me.grpbxCameraProperties.ResumeLayout(False)
        Me.grpbxCameraProperties.PerformLayout()
        CType(Me.nudCameraID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudExposure, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpbxCamera.ResumeLayout(False)
        Me.grpbxCamera.PerformLayout()
        Me.grpbxPlane.ResumeLayout(False)
        Me.grpbxPlane.PerformLayout()
        Me.grpbxImageCapture.ResumeLayout(False)
        Me.grpbxSave.ResumeLayout(False)
        Me.grpbxFFT.ResumeLayout(False)
        Me.grpbxFFT.PerformLayout()
        CType(Me.nudFFTPaddedWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudImagePaddedWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents picImagebox As ctrlComplexImagebox
    Friend WithEvents grpbxCameraProperties As GroupBox
    Friend WithEvents radOutputCameraPol2 As RadioButton
    Friend WithEvents radOutputCameraPol1 As RadioButton
    Friend WithEvents radInputCamera As RadioButton
    Friend WithEvents radComplexCameraImage As RadioButton
    Friend WithEvents radFFTCameraImage As RadioButton
    Friend WithEvents radCameraImage As RadioButton
    Friend WithEvents radComplexImage As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents radSingleInputPolarisation As RadioButton
    Friend WithEvents radFFTBackgroundField As RadioButton
    Friend WithEvents cmdSaveCamera As Button
    Friend WithEvents cmdLoadCamera As Button
    Friend WithEvents cmdSave As Button
    Friend WithEvents grpbxCamera As GroupBox
    Friend WithEvents grpbxPlane As GroupBox
    Friend WithEvents grpbxImageCapture As GroupBox
    Friend WithEvents grpbxSetup As GroupBox
    Friend WithEvents cmdSingleCapture As Button
    Friend WithEvents cmdStopContinuous As Button
    Friend WithEvents cmdStartContinuous As Button
    Friend WithEvents grpbxSave As GroupBox
    Friend WithEvents cmdExposure As Label
    Friend WithEvents cmbArduinoPort As ComboBox
    Friend WithEvents lblArduinoPort As Label
    Friend WithEvents nudCameraID As NumericUpDown
    Friend WithEvents lblCameraID As Label
    Friend WithEvents cmbTriggerMode As ComboBox
    Friend WithEvents lblTriggerMode As Label
    Friend WithEvents chkCameraActive As CheckBox
    Friend WithEvents nudExposure As NumericUpDown
    Friend WithEvents cmdAutoExposure As Button
    Friend WithEvents grpbxFFT As GroupBox
    Friend WithEvents nudImagePaddedWidth As NumericUpDown
    Friend WithEvents lblImagePaddedWidth As Label
    Friend WithEvents nudFFTPaddedWidth As NumericUpDown
    Friend WithEvents lblFFTPaddedWidth As Label
End Class
