<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class Form1
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
    Public WithEvents textMainFile As System.Windows.Forms.TextBox
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents LabelTotalLines As System.Windows.Forms.Label
	Public WithEvents LabelStatus As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Command2 = New System.Windows.Forms.Button
        Me.CommandCompile = New System.Windows.Forms.Button
        Me.textMainFile = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.LabelTotalLines = New System.Windows.Forms.Label
        Me.LabelStatus = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtOutput = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Command2
        '
        Me.Command2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Command2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Command2.Location = New System.Drawing.Point(436, 54)
        Me.Command2.Name = "Command2"
        Me.Command2.Size = New System.Drawing.Size(89, 23)
        Me.Command2.TabIndex = 3
        Me.Command2.Text = "&Stop"
        Me.Command2.UseVisualStyleBackColor = True
        '
        'CommandCompile
        '
        Me.CommandCompile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CommandCompile.Cursor = System.Windows.Forms.Cursors.Default
        Me.CommandCompile.Location = New System.Drawing.Point(341, 54)
        Me.CommandCompile.Name = "CommandCompile"
        Me.CommandCompile.Size = New System.Drawing.Size(89, 23)
        Me.CommandCompile.TabIndex = 2
        Me.CommandCompile.Text = "&Compile"
        Me.CommandCompile.UseVisualStyleBackColor = True
        '
        'textMainFile
        '
        Me.textMainFile.AcceptsReturn = True
        Me.textMainFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textMainFile.BackColor = System.Drawing.SystemColors.Window
        Me.textMainFile.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.textMainFile.ForeColor = System.Drawing.SystemColors.WindowText
        Me.textMainFile.Location = New System.Drawing.Point(8, 30)
        Me.textMainFile.MaxLength = 0
        Me.textMainFile.Name = "textMainFile"
        Me.textMainFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.textMainFile.Size = New System.Drawing.Size(517, 21)
        Me.textMainFile.TabIndex = 1
        Me.textMainFile.Text = "K:\Programming\wcCODE\TestDate.wcc"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(296, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Total Lines:"
        '
        'LabelTotalLines
        '
        Me.LabelTotalLines.AutoSize = True
        Me.LabelTotalLines.BackColor = System.Drawing.SystemColors.Control
        Me.LabelTotalLines.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabelTotalLines.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelTotalLines.Location = New System.Drawing.Point(360, 97)
        Me.LabelTotalLines.Name = "LabelTotalLines"
        Me.LabelTotalLines.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabelTotalLines.Size = New System.Drawing.Size(90, 13)
        Me.LabelTotalLines.TabIndex = 5
        Me.LabelTotalLines.Text = "[Nothing Loaded]"
        '
        'LabelStatus
        '
        Me.LabelStatus.BackColor = System.Drawing.SystemColors.Info
        Me.LabelStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.LabelStatus.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelStatus.Location = New System.Drawing.Point(8, 97)
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabelStatus.Size = New System.Drawing.Size(209, 16)
        Me.LabelStatus.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(129, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Main Compile File"
        '
        'txtOutput
        '
        Me.txtOutput.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOutput.Location = New System.Drawing.Point(6, 125)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtOutput.Size = New System.Drawing.Size(519, 334)
        Me.txtOutput.TabIndex = 8
        Me.txtOutput.WordWrap = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(531, 461)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.Command2)
        Me.Controls.Add(Me.CommandCompile)
        Me.Controls.Add(Me.textMainFile)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LabelTotalLines)
        Me.Controls.Add(Me.LabelStatus)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "Form1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtOutput As System.Windows.Forms.TextBox
    Private WithEvents Command2 As System.Windows.Forms.Button
    Private WithEvents CommandCompile As System.Windows.Forms.Button
#End Region
End Class