' Ralf Mouthaan
' University of Cambridge
' November 2018
'
' Control to display complex 2D arrays in an imagebox.

Option Explicit On
Option Strict On

Public Class ctrlComplexImagebox

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        bolShowMagnitude = True
        pViewport1.X = 0
        pViewport1.Y = 0
        pViewport2.X = 0
        pViewport2.Y = 0

        lbl.Text = ""

    End Sub

#Region "Image Display"

    Private _bolShowMagnitude As Boolean
    Private _bolShowPhase As Boolean
    Private _bolShowMagnitudePhase As Boolean
    Private _bolShowLogMagnitude As Boolean

    Public Property bolShowMagnitude As Boolean
        Get
            Return _bolShowMagnitude
        End Get
        Set(value As Boolean)
            _bolShowMagnitude = value
            _bolShowPhase = Not value
            _bolShowMagnitudePhase = Not value
            _bolShowLogMagnitude = Not value
        End Set
    End Property
    Public Property bolShowPhase As Boolean
        Get
            Return _bolShowPhase
        End Get
        Set(value As Boolean)
            _bolShowPhase = value
            _bolShowMagnitude = Not value
            _bolShowMagnitudePhase = Not value
            _bolShowLogMagnitude = Not value
        End Set
    End Property
    Public Property bolShowMagnitudePhase As Boolean
        Get
            Return _bolShowMagnitudePhase
        End Get
        Set(value As Boolean)
            _bolShowMagnitudePhase = value
            _bolShowMagnitude = Not value
            _bolShowPhase = Not value
            _bolShowLogMagnitude = Not value
        End Set
    End Property
    Public Property bolShowLogMagnitude As Boolean
        Get
            Return _bolShowLogMagnitude
        End Get
        Set(value As Boolean)
            _bolShowPhase = Not value
            _bolShowMagnitude = Not value
            _bolShowMagnitudePhase = Not value
            _bolShowLogMagnitude = value
        End Set
    End Property

    Public Sub RefreshImage()

        If Data Is Nothing Then Exit Sub

        Dim bmdataLockedBits As Imaging.BitmapData
        Dim bLockedBits() As Byte
        Dim z As Integer
        Dim maxmag As Double
        Dim bmap As Bitmap

        maxmag = MaxMagnitude()
        If maxmag = 0 Then maxmag = 1

        bmap = New Bitmap(DataWidth, DataHeight)

        'Lock bits
        bmdataLockedBits = bmap.LockBits(New Rectangle(0, 0, DataWidth, DataHeight),
                                            Imaging.ImageLockMode.ReadWrite, Imaging.PixelFormat.Format24bppRgb)
        ReDim bLockedBits(bmdataLockedBits.Stride * bmdataLockedBits.Height - 1)
        Runtime.InteropServices.Marshal.Copy(bmdataLockedBits.Scan0, bLockedBits, 0, bmdataLockedBits.Stride * bmdataLockedBits.Height)

        'Update bits
        For i = Viewport.Left To Viewport.Right - 1
            For j = Viewport.Top To Viewport.Bottom - 1
                z = j * bmdataLockedBits.Stride + i * 3

                If bolShowMagnitude = True Then
                    bLockedBits(z) = CByte(Data(i, j).Magnitude / maxmag * 255)
                    bLockedBits(z + 1) = bLockedBits(z)
                    bLockedBits(z + 2) = bLockedBits(z)
                ElseIf bolShowPhase = True Then
                    bLockedBits(z) = CByte((Data(i, j).Phase + Math.PI) * 255 / 2 / Math.PI)
                    bLockedBits(z + 1) = bLockedBits(z)
                    bLockedBits(z + 2) = bLockedBits(z)
                ElseIf bolShowMagnitudePhase = True Then
                    bLockedBits(z) = CByte(Math.Max(0, Data(i, j).Real) * 255 / maxmag)
                    bLockedBits(z + 1) = CByte((-Math.Min(0, Data(i, j).Real) + Math.Max(0, Data(i, j).Imaginary)) * 255 / Math.Sqrt(2) / maxmag)
                    bLockedBits(z + 2) = CByte((-Math.Min(0, Data(i, j).Real) - Math.Min(0, Data(i, j).Imaginary)) * 255 / Math.Sqrt(2) / maxmag)
                ElseIf bolShowLogMagnitude = True Then
                    bLockedBits(z) = CByte(Math.Log10(Data(i, j).Magnitude / maxmag * 10) * 255)
                    bLockedBits(z + 1) = bLockedBits(z)
                    bLockedBits(z + 2) = bLockedBits(z)
                End If
            Next
        Next

        'Unlock bits
        Runtime.InteropServices.Marshal.Copy(bLockedBits, 0, bmdataLockedBits.Scan0, bLockedBits.Length)
        bmap.UnlockBits(bmdataLockedBits)

        picbox.Image = bmap

    End Sub

#End Region

#Region "Data"
    Private _Data(,) As Numerics.Complex
    Public Property Data As Numerics.Complex(,)
        Get
            Return _Data
        End Get
        Set(value As Numerics.Complex(,))
            _Data = value
            If Data Is Nothing Then Exit Property
            If Viewport.Width > Data.GetLength(0) Or Viewport.Height > Data.GetLength(1) Then
                Viewport = New Rectangle(0, 0, value.GetLength(0), value.GetLength(1))
            End If
        End Set
    End Property
    Public Property DataElement(ByVal i As Integer, j As Integer) As Numerics.Complex
        Get

            If _Data Is Nothing Then Call Err.Raise(-1, "Complex Imagebox", "Ensure a data array is declared")
            If i > DataWidth Then Call Err.Raise(-1, "Complex Imagebox", "Index out of bounds")
            If j > DataHeight Then Call Err.Raise(-1, "Complex Imagebox", "Index out of bounds")

            Return _Data(i, j)
        End Get
        Set(value As Numerics.Complex)

            If _Data Is Nothing Then Call Err.Raise(-1, "Complex Imagebox", "Ensure a data array is declared")
            If i > DataWidth Then Call Err.Raise(-1, "Complex Imagebox", "Index out of bounds")
            If j > DataHeight Then Call Err.Raise(-1, "Complex Imagebox", "Index out of bounds")

            _Data(i, j) = value
        End Set
    End Property
    Public ReadOnly Property DataWidth As Integer
        Get

            If _Data Is Nothing Then Return 0

            Return _Data.GetLength(0)

        End Get
    End Property
    Public ReadOnly Property DataHeight As Integer
        Get

            If _Data Is Nothing Then Return 0

            Return _Data.GetLength(1)

        End Get
    End Property
    Public ReadOnly Property MaxMagnitude As Double
        Get

            If _Data Is Nothing Then Call Err.Raise(-1, "Complex Imagebox", "Ensure a data array is declared")

            Dim RetVal As Double = 0

            For i = Viewport.Left To Viewport.Right - 1
                For j = Viewport.Top To Viewport.Bottom - 1
                    If Data(i, j).Magnitude > RetVal Then
                        RetVal = Data(i, j).Magnitude
                    End If
                Next
            Next

            Return RetVal

        End Get
    End Property
    Public Property IntegerData() As Integer(,)
        Get
            Dim RetVal(DataWidth - 1, DataHeight - 1) As Integer

            For i = 0 To DataWidth - 1
                For j = 0 To DataHeight - 1
                    RetVal(i, j) = CInt(Data(i, j).Real)
                Next
            Next

            Return RetVal
        End Get
        Set(value As Integer(,))

            ReDim Data(value.GetLength(0) - 1, value.GetLength(1) - 1)

            For i = 0 To DataWidth - 1
                For j = 0 To DataHeight - 1
                    Data(i, j) = New Numerics.Complex(value(i, j), 0)
                Next
            Next

            If Viewport.Width > Data.GetLength(0) Or Viewport.Height > Data.GetLength(1) Then
                Viewport = New Rectangle(0, 0, value.GetLength(0), value.GetLength(1))
            End If

        End Set
    End Property
    Public Property DoubleData() As Double(,)
        Get
            Dim RetVal(DataWidth - 1, DataHeight - 1) As Double

            For i = 0 To DataWidth - 1
                For j = 0 To DataHeight - 1
                    RetVal(i, j) = CInt(Data(i, j).Real)
                Next
            Next

            Return RetVal
        End Get
        Set(value As Double(,))

            ReDim Data(value.GetLength(0) - 1, value.GetLength(1) - 1)

            For i = 0 To DataWidth - 1
                For j = 0 To DataHeight - 1
                    Data(i, j) = New Numerics.Complex(value(i, j), 0)
                Next
            Next

            If Viewport.Width > Data.GetLength(0) Or Viewport.Height > Data.GetLength(1) Then
                Viewport = New Rectangle(0, 0, value.GetLength(0), value.GetLength(1))
            End If

        End Set
    End Property
    Public ReadOnly Property LogData As Double(,)
        Get

            Dim RetVal(DataWidth - 1, DataHeight - 1) As Double
            For i = 0 To DataWidth - 1
                For j = 0 To DataHeight - 1
                    RetVal(i, j) = Math.Log10(Data(i, j).Magnitude)
                Next
            Next

            Return RetVal

        End Get
    End Property
#End Region

#Region "Load and Save"
    Public Sub LoadFromFile(ByVal Filename As String)

        'This is rather dirty, but repeated regexes seem to be slow in VB.NET.
        'I make a number of assumptions about the structure of the file here.

        If IO.File.Exists(Filename) = False Then Exit Sub
        Dim reader As New IO.StreamReader(Filename)
        Dim str As String = ""
        Dim splitstr1 As String(), splitstr2() As String
        Dim RowCount As Integer
        Dim i As Integer, j As Integer
        Dim bolRealIsNegative As Boolean

        'Find total number of lines in file
        RowCount = 0
        While reader.EndOfStream = False
            str = reader.ReadLine()
            RowCount += 1
        End While
        splitstr1 = Split(str, vbTab)

        'Redim real and imag arrays
        ReDim _Data(splitstr1.Count - 1, RowCount - 1)

        'Populate real and imag arrays
        reader = New IO.StreamReader(Filename)
        j = -1
        While reader.EndOfStream = False

            splitstr1 = Split(reader.ReadLine(), vbTab)
            j += 1

            For i = 0 To splitstr1.Count - 1
                If splitstr1(i) = "" Then Continue For

                splitstr1(i) = splitstr1(i).Replace("i", "")

                If splitstr1(i).StartsWith("-") = True Then
                    bolRealIsNegative = True
                    splitstr1(i) = splitstr1(i).Remove(0, 1)
                Else
                    bolRealIsNegative = False
                End If

                If splitstr1(i).Contains("+") Then
                    splitstr2 = Split(splitstr1(i), "+")
                    _Data(i, j) = New Numerics.Complex(CDbl(splitstr2(0)), CDbl(splitstr2(1)))
                ElseIf splitstr1(i).Contains("-") Then
                    splitstr2 = Split(splitstr1(i), "-")
                    _Data(i, j) = New Numerics.Complex(CDbl(splitstr2(0)), -CDbl(splitstr2(1)))
                End If

                If bolRealIsNegative = True Then
                    _Data(i, j) = -_Data(i, j)
                End If

            Next

        End While
        reader.Close()

        pViewport1.X = 0
        pViewport1.Y = 0
        pViewport2.X = DataWidth - 1
        pViewport2.Y = DataHeight - 1

        'Refresh picture
        RefreshImage()

    End Sub
    Private Sub SaveAsTXT()

        Dim dlg As New SaveFileDialog
        Dim Filename As String
        Dim writer As IO.StreamWriter

        ' Get dialogbox
        dlg.OverwritePrompt = True
        dlg.Title = "Save as TXT"
        If dlg.ShowDialog <> vbOK Then Exit Sub
        Filename = dlg.FileName
        If dlg.FileName = "" Then Exit Sub
        If Filename.EndsWith(".txt") = False Then Filename = Filename + ".txt"

        ' Save data
        writer = New IO.StreamWriter(Filename)
        For j = Viewport.Top To Viewport.Bottom - 1
            For i = Viewport.Left To Viewport.Right - 1
                writer.Write(_Data(i, j).Real)
                If _Data(i, j).Imaginary >= 0 Then writer.Write("+")
                writer.Write(_Data(i, j).Imaginary)
                writer.Write("i")
                writer.Write(vbTab)
            Next
            writer.WriteLine()
        Next
        writer.Close()

    End Sub
    Private Sub SaveAsBMP()

        Dim dlg As New SaveFileDialog
        Dim Filename As String

        ' Get dialogbox
        dlg.OverwritePrompt = True
        dlg.Title = "Save as TXT"
        If dlg.ShowDialog <> vbOK Then Exit Sub
        Filename = dlg.FileName
        If dlg.FileName = "" Then Exit Sub
        If Filename.EndsWith(".bmp") = False Then Filename = Filename + ".bmp"

        Dim CroppedImage As New Bitmap(Viewport.Width, Viewport.Height)
        Dim grp As Graphics = Graphics.FromImage(CroppedImage)
        grp.DrawImage(picbox.Image, New Rectangle(0, 0, Viewport.Width, Viewport.Height), Viewport, GraphicsUnit.Pixel)
        CroppedImage.Save(Filename)

    End Sub
#End Region

#Region "Picbox Event Handlers"

    Private bolMouseDown As Boolean
    Private pViewport1 As Point
    Private pViewport2 As Point

    Public Event ViewPortChanged()

    Public Property Viewport As Rectangle
        Get

            Dim x1 As Integer, width As Integer, y1 As Integer, height As Integer

            'Determine rectangle corners
            If pViewport1.X < pViewport2.X Then
                x1 = pViewport1.X
                width = pViewport2.X - pViewport1.X
            Else
                x1 = pViewport2.X
                width = pViewport1.X - pViewport2.X
            End If

            If pViewport1.Y < pViewport2.Y Then
                y1 = pViewport1.Y
                height = pViewport2.Y - pViewport1.Y
            Else
                y1 = pViewport2.Y
                height = pViewport1.Y - pViewport2.Y
            End If

            Return New Rectangle(x1, y1, width, height)

        End Get
        Set(value As Rectangle)

            pViewport1.X = value.Left
            pViewport1.Y = value.Top
            pViewport2.X = value.Right
            pViewport2.Y = value.Bottom

            Call RefreshImage()

            'RaiseEvent ViewPortChanged()

        End Set
    End Property
    Private Sub picbox_MouseUp(sender As Object, e As MouseEventArgs) Handles picbox.MouseUp

        If e.Button = MouseButtons.Left Then
            bolMouseDown = False
            Call RefreshImage()
            RaiseEvent ViewPortChanged()
        End If

        If e.Button = MouseButtons.Right Then

            Dim cms As New ContextMenuStrip
            Dim cmsItem As ToolStripItem

            cmsItem = cms.Items.Add("View Magnitude")
            AddHandler cmsItem.Click, Sub()
                                          bolShowMagnitude = True
                                          RefreshImage()
                                      End Sub
            cmsItem = cms.Items.Add("View Phase")
            AddHandler cmsItem.Click, Sub()
                                          bolShowPhase = True
                                          RefreshImage()
                                      End Sub
            cmsItem = cms.Items.Add("View Magnitude && Phase")
            AddHandler cmsItem.Click, Sub()
                                          bolShowMagnitudePhase = True
                                          RefreshImage()
                                      End Sub
            cmsItem = cms.Items.Add("View Log Magnitude")
            AddHandler cmsItem.Click, Sub()
                                          bolShowLogMagnitude = True
                                          RefreshImage()
                                      End Sub

            cms.Items.Add(New ToolStripSeparator)

            cmsItem = cms.Items.Add("Save as BMP")
            AddHandler cmsItem.Click, Sub()
                                          SaveAsBMP()
                                      End Sub
            cmsItem = cms.Items.Add("Save as TXT")
            AddHandler cmsItem.Click, Sub()
                                          SaveAsTXT()
                                      End Sub

            cms.Show(picbox, e.Location)

        End If

    End Sub
    Private Sub picbox_MouseDown(sender As Object, e As MouseEventArgs) Handles picbox.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            bolMouseDown = True
            pViewport1 = New Point(e.X, e.Y)
        End If
    End Sub
    Private Sub picbox_MouseMove(sender As Object, e As MouseEventArgs) Handles picbox.MouseMove
        If bolMouseDown = True Then
            pViewport2 = New Point(pViewport1.X + CInt(Math.Round((e.X - pViewport1.X) / 2) * 2), pViewport1.Y + CInt(Math.Round((e.Y - pViewport1.Y) / 2) * 2))
            picbox.Refresh()
            lbl.Text = "Viewport Width = " + (pViewport2.X - pViewport1.X).ToString + "; Viewport Height = " + (pViewport2.Y - pViewport1.Y).ToString & "; Max = " & MaxMagnitude.ToString
        End If
    End Sub
    Private Sub picbox_Paint(sender As Object, e As PaintEventArgs) Handles picbox.Paint

        Dim g As Graphics = e.Graphics

        'Error checks
        If bolMouseDown = False Then Exit Sub
        If Viewport.Width = 0 Then Exit Sub
        If Viewport.Height = 0 Then Exit Sub

        g.DrawRectangle(New Pen(Color.Green), Viewport)

    End Sub

#End Region

End Class
