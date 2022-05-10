<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ctrlComplexImagebox
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.lbl = New System.Windows.Forms.Label()
        Me.panPic = New System.Windows.Forms.Panel()
        Me.picbox = New System.Windows.Forms.PictureBox()
        Me.panPic.SuspendLayout()
        CType(Me.picbox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.ForeColor = System.Drawing.Color.Lime
        Me.lbl.Location = New System.Drawing.Point(3, 3)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(17, 13)
        Me.lbl.TabIndex = 2
        Me.lbl.Text = "lbl"
        '
        'panPic
        '
        Me.panPic.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panPic.AutoScroll = True
        Me.panPic.Controls.Add(Me.picbox)
        Me.panPic.Location = New System.Drawing.Point(0, 19)
        Me.panPic.Name = "panPic"
        Me.panPic.Size = New System.Drawing.Size(426, 378)
        Me.panPic.TabIndex = 3
        '
        'picbox
        '
        Me.picbox.Location = New System.Drawing.Point(6, 3)
        Me.picbox.Name = "picbox"
        Me.picbox.Size = New System.Drawing.Size(416, 370)
        Me.picbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picbox.TabIndex = 2
        Me.picbox.TabStop = False
        '
        'ctrlComplexImagebox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.Controls.Add(Me.panPic)
        Me.Controls.Add(Me.lbl)
        Me.Name = "ctrlComplexImagebox"
        Me.Size = New System.Drawing.Size(429, 426)
        Me.panPic.ResumeLayout(False)
        Me.panPic.PerformLayout()
        CType(Me.picbox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl As Label
    Friend WithEvents panPic As Panel
    Friend WithEvents picbox As PictureBox
End Class
