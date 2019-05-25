<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class mainform
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
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public pickFileOpen As System.Windows.Forms.OpenFileDialog
	Public WithEvents btnFindError As System.Windows.Forms.Button
	Public WithEvents cbRptFile As System.Windows.Forms.CheckBox
	Public WithEvents cbMapFile As System.Windows.Forms.CheckBox
	Public WithEvents btnPickWCC As System.Windows.Forms.Button
	Public WithEvents btnClear As System.Windows.Forms.Button
	Public WithEvents List1 As System.Windows.Forms.ListBox
	Public WithEvents CommandCompile As System.Windows.Forms.Button
	Public WithEvents textMainFile As System.Windows.Forms.TextBox
	Public WithEvents cbDebug As System.Windows.Forms.CheckBox
	Public WithEvents Frame1 As System.Windows.Forms.GroupBox
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents LabelTotalLines As System.Windows.Forms.Label
	Public WithEvents LabelStatus As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(mainform))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.pickFileOpen = New System.Windows.Forms.OpenFileDialog
		Me.btnFindError = New System.Windows.Forms.Button
		Me.cbRptFile = New System.Windows.Forms.CheckBox
		Me.cbMapFile = New System.Windows.Forms.CheckBox
		Me.btnPickWCC = New System.Windows.Forms.Button
		Me.btnClear = New System.Windows.Forms.Button
		Me.List1 = New System.Windows.Forms.ListBox
		Me.CommandCompile = New System.Windows.Forms.Button
		Me.textMainFile = New System.Windows.Forms.TextBox
		Me.Frame1 = New System.Windows.Forms.GroupBox
		Me.cbDebug = New System.Windows.Forms.CheckBox
		Me.Label2 = New System.Windows.Forms.Label
		Me.LabelTotalLines = New System.Windows.Forms.Label
		Me.LabelStatus = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.Frame1.SuspendLayout()
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Text = "wccCompiler"
		Me.ClientSize = New System.Drawing.Size(527, 419)
		Me.Location = New System.Drawing.Point(3, 22)
		Me.MaximizeBox = False
		Me.MinimizeBox = False
		Me.ShowInTaskbar = False
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "mainform"
		Me.btnFindError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnFindError.Text = "Find Error"
		Me.btnFindError.Size = New System.Drawing.Size(73, 25)
		Me.btnFindError.Location = New System.Drawing.Point(96, 72)
		Me.btnFindError.TabIndex = 13
		Me.btnFindError.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnFindError.BackColor = System.Drawing.SystemColors.Control
		Me.btnFindError.CausesValidation = True
		Me.btnFindError.Enabled = True
		Me.btnFindError.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnFindError.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnFindError.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnFindError.TabStop = True
		Me.btnFindError.Name = "btnFindError"
		Me.cbRptFile.Text = "Create RPT file"
		Me.cbRptFile.Size = New System.Drawing.Size(113, 17)
		Me.cbRptFile.Location = New System.Drawing.Point(392, 64)
		Me.cbRptFile.TabIndex = 10
		Me.cbRptFile.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbRptFile.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.cbRptFile.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.cbRptFile.BackColor = System.Drawing.SystemColors.Control
		Me.cbRptFile.CausesValidation = True
		Me.cbRptFile.Enabled = True
		Me.cbRptFile.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cbRptFile.Cursor = System.Windows.Forms.Cursors.Default
		Me.cbRptFile.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cbRptFile.Appearance = System.Windows.Forms.Appearance.Normal
		Me.cbRptFile.TabStop = True
		Me.cbRptFile.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.cbRptFile.Visible = True
		Me.cbRptFile.Name = "cbRptFile"
		Me.cbMapFile.Text = "Create MAP file"
		Me.cbMapFile.Size = New System.Drawing.Size(113, 17)
		Me.cbMapFile.Location = New System.Drawing.Point(392, 48)
		Me.cbMapFile.TabIndex = 9
		Me.cbMapFile.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbMapFile.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.cbMapFile.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.cbMapFile.BackColor = System.Drawing.SystemColors.Control
		Me.cbMapFile.CausesValidation = True
		Me.cbMapFile.Enabled = True
		Me.cbMapFile.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cbMapFile.Cursor = System.Windows.Forms.Cursors.Default
		Me.cbMapFile.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cbMapFile.Appearance = System.Windows.Forms.Appearance.Normal
		Me.cbMapFile.TabStop = True
		Me.cbMapFile.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.cbMapFile.Visible = True
		Me.cbMapFile.Name = "cbMapFile"
		Me.btnPickWCC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnPickWCC.Text = "..."
		Me.btnPickWCC.Size = New System.Drawing.Size(25, 17)
		Me.btnPickWCC.Location = New System.Drawing.Point(224, 32)
		Me.btnPickWCC.TabIndex = 8
		Me.btnPickWCC.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnPickWCC.BackColor = System.Drawing.SystemColors.Control
		Me.btnPickWCC.CausesValidation = True
		Me.btnPickWCC.Enabled = True
		Me.btnPickWCC.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnPickWCC.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnPickWCC.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnPickWCC.TabStop = True
		Me.btnPickWCC.Name = "btnPickWCC"
		Me.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.btnClear.Text = "Clear"
		Me.btnClear.Size = New System.Drawing.Size(89, 25)
		Me.btnClear.Location = New System.Drawing.Point(432, 152)
		Me.btnClear.TabIndex = 7
		Me.btnClear.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.btnClear.BackColor = System.Drawing.SystemColors.Control
		Me.btnClear.CausesValidation = True
		Me.btnClear.Enabled = True
		Me.btnClear.ForeColor = System.Drawing.SystemColors.ControlText
		Me.btnClear.Cursor = System.Windows.Forms.Cursors.Default
		Me.btnClear.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.btnClear.TabStop = True
		Me.btnClear.Name = "btnClear"
		Me.List1.Size = New System.Drawing.Size(513, 228)
		Me.List1.Location = New System.Drawing.Point(8, 184)
		Me.List1.TabIndex = 6
		Me.List1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.List1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.List1.BackColor = System.Drawing.SystemColors.Window
		Me.List1.CausesValidation = True
		Me.List1.Enabled = True
		Me.List1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.List1.IntegralHeight = True
		Me.List1.Cursor = System.Windows.Forms.Cursors.Default
		Me.List1.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.List1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.List1.Sorted = False
		Me.List1.TabStop = True
		Me.List1.Visible = True
		Me.List1.MultiColumn = False
		Me.List1.Name = "List1"
		Me.CommandCompile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CommandCompile.Text = "Compile"
		Me.CommandCompile.Size = New System.Drawing.Size(73, 25)
		Me.CommandCompile.Location = New System.Drawing.Point(8, 72)
		Me.CommandCompile.TabIndex = 2
		Me.CommandCompile.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CommandCompile.BackColor = System.Drawing.SystemColors.Control
		Me.CommandCompile.CausesValidation = True
		Me.CommandCompile.Enabled = True
		Me.CommandCompile.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CommandCompile.Cursor = System.Windows.Forms.Cursors.Default
		Me.CommandCompile.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CommandCompile.TabStop = True
		Me.CommandCompile.Name = "CommandCompile"
		Me.textMainFile.AutoSize = False
		Me.textMainFile.Size = New System.Drawing.Size(209, 19)
		Me.textMainFile.Location = New System.Drawing.Point(8, 32)
		Me.textMainFile.TabIndex = 1
		Me.textMainFile.Text = "ListUsers.wcc"
		Me.textMainFile.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.textMainFile.AcceptsReturn = True
		Me.textMainFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.textMainFile.BackColor = System.Drawing.SystemColors.Window
		Me.textMainFile.CausesValidation = True
		Me.textMainFile.Enabled = True
		Me.textMainFile.ForeColor = System.Drawing.SystemColors.WindowText
		Me.textMainFile.HideSelection = True
		Me.textMainFile.ReadOnly = False
		Me.textMainFile.Maxlength = 0
		Me.textMainFile.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.textMainFile.MultiLine = False
		Me.textMainFile.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.textMainFile.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.textMainFile.TabStop = True
		Me.textMainFile.Visible = True
		Me.textMainFile.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.textMainFile.Name = "textMainFile"
		Me.Frame1.Text = "Compiler Options"
		Me.Frame1.Size = New System.Drawing.Size(137, 81)
		Me.Frame1.Location = New System.Drawing.Point(384, 24)
		Me.Frame1.TabIndex = 11
		Me.Frame1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Frame1.BackColor = System.Drawing.SystemColors.Control
		Me.Frame1.Enabled = True
		Me.Frame1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Frame1.Visible = True
		Me.Frame1.Name = "Frame1"
		Me.cbDebug.Text = "Debug Compile"
		Me.cbDebug.Size = New System.Drawing.Size(105, 17)
		Me.cbDebug.Location = New System.Drawing.Point(8, 56)
		Me.cbDebug.TabIndex = 12
		Me.cbDebug.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cbDebug.CheckAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.cbDebug.FlatStyle = System.Windows.Forms.FlatStyle.Standard
		Me.cbDebug.BackColor = System.Drawing.SystemColors.Control
		Me.cbDebug.CausesValidation = True
		Me.cbDebug.Enabled = True
		Me.cbDebug.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cbDebug.Cursor = System.Windows.Forms.Cursors.Default
		Me.cbDebug.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cbDebug.Appearance = System.Windows.Forms.Appearance.Normal
		Me.cbDebug.TabStop = True
		Me.cbDebug.CheckState = System.Windows.Forms.CheckState.Unchecked
		Me.cbDebug.Visible = True
		Me.cbDebug.Name = "cbDebug"
		Me.Label2.Text = "Total Lines:"
		Me.Label2.Size = New System.Drawing.Size(57, 17)
		Me.Label2.Location = New System.Drawing.Point(8, 160)
		Me.Label2.TabIndex = 5
		Me.Label2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.SystemColors.Control
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.LabelTotalLines.Text = "LabelTotalLines"
		Me.LabelTotalLines.Size = New System.Drawing.Size(73, 17)
		Me.LabelTotalLines.Location = New System.Drawing.Point(72, 160)
		Me.LabelTotalLines.TabIndex = 4
		Me.LabelTotalLines.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelTotalLines.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.LabelTotalLines.BackColor = System.Drawing.SystemColors.Control
		Me.LabelTotalLines.Enabled = True
		Me.LabelTotalLines.ForeColor = System.Drawing.SystemColors.ControlText
		Me.LabelTotalLines.Cursor = System.Windows.Forms.Cursors.Default
		Me.LabelTotalLines.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.LabelTotalLines.UseMnemonic = True
		Me.LabelTotalLines.Visible = True
		Me.LabelTotalLines.AutoSize = False
		Me.LabelTotalLines.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.LabelTotalLines.Name = "LabelTotalLines"
		Me.LabelStatus.BackColor = System.Drawing.SystemColors.Info
		Me.LabelStatus.Text = "LabelStatus"
		Me.LabelStatus.Size = New System.Drawing.Size(513, 17)
		Me.LabelStatus.Location = New System.Drawing.Point(8, 120)
		Me.LabelStatus.TabIndex = 3
		Me.LabelStatus.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelStatus.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.LabelStatus.Enabled = True
		Me.LabelStatus.ForeColor = System.Drawing.SystemColors.ControlText
		Me.LabelStatus.Cursor = System.Windows.Forms.Cursors.Default
		Me.LabelStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.LabelStatus.UseMnemonic = True
		Me.LabelStatus.Visible = True
		Me.LabelStatus.AutoSize = False
		Me.LabelStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.LabelStatus.Name = "LabelStatus"
		Me.Label1.Text = "Mail Compile File"
		Me.Label1.Size = New System.Drawing.Size(129, 17)
		Me.Label1.Location = New System.Drawing.Point(8, 16)
		Me.Label1.TabIndex = 0
		Me.Label1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
		Me.Controls.Add(btnFindError)
		Me.Controls.Add(cbRptFile)
		Me.Controls.Add(cbMapFile)
		Me.Controls.Add(btnPickWCC)
		Me.Controls.Add(btnClear)
		Me.Controls.Add(List1)
		Me.Controls.Add(CommandCompile)
		Me.Controls.Add(textMainFile)
		Me.Controls.Add(Frame1)
		Me.Controls.Add(Label2)
		Me.Controls.Add(LabelTotalLines)
		Me.Controls.Add(LabelStatus)
		Me.Controls.Add(Label1)
		Me.Frame1.Controls.Add(cbDebug)
		Me.Frame1.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class