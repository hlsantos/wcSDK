<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmMSG
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
    Public WithEvents picMTools As System.Windows.Forms.Panel
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMSG))
        Me.picMTools = New System.Windows.Forms.Panel
        Me.chkRR = New System.Windows.Forms.CheckBox
        Me.chkPVT = New System.Windows.Forms.CheckBox
        Me.cmdSEND = New System.Windows.Forms.Button
        Me.txtMSGBody = New System.Windows.Forms.TextBox
        Me.txtMsgSubject = New System.Windows.Forms.TextBox
        Me.txtMsgFrom = New System.Windows.Forms.TextBox
        Me.txtMsgTo = New System.Windows.Forms.TextBox
        Me.lblMsg3 = New System.Windows.Forms.Label
        Me.lblMsg2 = New System.Windows.Forms.Label
        Me.lblMsg1 = New System.Windows.Forms.Label
        Me.stbMsg = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.picMTools.SuspendLayout()
        Me.stbMsg.SuspendLayout()
        Me.SuspendLayout()
        '
        'picMTools
        '
        Me.picMTools.BackColor = System.Drawing.SystemColors.Control
        Me.picMTools.Controls.Add(Me.chkRR)
        Me.picMTools.Controls.Add(Me.chkPVT)
        Me.picMTools.Controls.Add(Me.cmdSEND)
        Me.picMTools.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picMTools.Location = New System.Drawing.Point(0, 398)
        Me.picMTools.Name = "picMTools"
        Me.picMTools.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picMTools.Size = New System.Drawing.Size(441, 41)
        Me.picMTools.TabIndex = 8
        Me.picMTools.TabStop = True
        '
        'chkRR
        '
        Me.chkRR.Enabled = False
        Me.chkRR.Location = New System.Drawing.Point(173, 14)
        Me.chkRR.Name = "chkRR"
        Me.chkRR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkRR.Size = New System.Drawing.Size(105, 17)
        Me.chkRR.TabIndex = 11
        Me.chkRR.Text = "Return Receipt?"
        Me.chkRR.UseVisualStyleBackColor = True
        '
        'chkPVT
        '
        Me.chkPVT.Enabled = False
        Me.chkPVT.Location = New System.Drawing.Point(88, 14)
        Me.chkPVT.Name = "chkPVT"
        Me.chkPVT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkPVT.Size = New System.Drawing.Size(68, 17)
        Me.chkPVT.TabIndex = 10
        Me.chkPVT.Text = "Private"
        Me.chkPVT.UseVisualStyleBackColor = True
        '
        'cmdSEND
        '
        Me.cmdSEND.Location = New System.Drawing.Point(8, 8)
        Me.cmdSEND.Name = "cmdSEND"
        Me.cmdSEND.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdSEND.Size = New System.Drawing.Size(73, 25)
        Me.cmdSEND.TabIndex = 9
        Me.cmdSEND.Text = "&Send"
        Me.cmdSEND.UseVisualStyleBackColor = True
        '
        'txtMSGBody
        '
        Me.txtMSGBody.AcceptsReturn = True
        Me.txtMSGBody.Location = New System.Drawing.Point(8, 83)
        Me.txtMSGBody.MaxLength = 0
        Me.txtMSGBody.Multiline = True
        Me.txtMSGBody.Name = "txtMSGBody"
        Me.txtMSGBody.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMSGBody.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMSGBody.Size = New System.Drawing.Size(425, 309)
        Me.txtMSGBody.TabIndex = 3
        '
        'txtMsgSubject
        '
        Me.txtMsgSubject.AcceptsReturn = True
        Me.txtMsgSubject.Location = New System.Drawing.Point(64, 56)
        Me.txtMsgSubject.MaxLength = 0
        Me.txtMsgSubject.Name = "txtMsgSubject"
        Me.txtMsgSubject.ReadOnly = True
        Me.txtMsgSubject.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMsgSubject.Size = New System.Drawing.Size(369, 21)
        Me.txtMsgSubject.TabIndex = 2
        '
        'txtMsgFrom
        '
        Me.txtMsgFrom.AcceptsReturn = True
        Me.txtMsgFrom.Location = New System.Drawing.Point(64, 32)
        Me.txtMsgFrom.MaxLength = 0
        Me.txtMsgFrom.Name = "txtMsgFrom"
        Me.txtMsgFrom.ReadOnly = True
        Me.txtMsgFrom.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMsgFrom.Size = New System.Drawing.Size(369, 21)
        Me.txtMsgFrom.TabIndex = 1
        '
        'txtMsgTo
        '
        Me.txtMsgTo.AcceptsReturn = True
        Me.txtMsgTo.Location = New System.Drawing.Point(64, 8)
        Me.txtMsgTo.MaxLength = 0
        Me.txtMsgTo.Name = "txtMsgTo"
        Me.txtMsgTo.ReadOnly = True
        Me.txtMsgTo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMsgTo.Size = New System.Drawing.Size(369, 21)
        Me.txtMsgTo.TabIndex = 0
        '
        'lblMsg3
        '
        Me.lblMsg3.Location = New System.Drawing.Point(8, 56)
        Me.lblMsg3.Name = "lblMsg3"
        Me.lblMsg3.Size = New System.Drawing.Size(49, 17)
        Me.lblMsg3.TabIndex = 6
        Me.lblMsg3.Text = "Subject:"
        Me.lblMsg3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMsg2
        '
        Me.lblMsg2.Location = New System.Drawing.Point(8, 32)
        Me.lblMsg2.Name = "lblMsg2"
        Me.lblMsg2.Size = New System.Drawing.Size(49, 17)
        Me.lblMsg2.TabIndex = 5
        Me.lblMsg2.Text = "From:"
        Me.lblMsg2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMsg1
        '
        Me.lblMsg1.Location = New System.Drawing.Point(8, 8)
        Me.lblMsg1.Name = "lblMsg1"
        Me.lblMsg1.Size = New System.Drawing.Size(49, 17)
        Me.lblMsg1.TabIndex = 4
        Me.lblMsg1.Text = "To:"
        Me.lblMsg1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'stbMsg
        '
        Me.stbMsg.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3})
        Me.stbMsg.Location = New System.Drawing.Point(0, 439)
        Me.stbMsg.Name = "stbMsg"
        Me.stbMsg.Size = New System.Drawing.Size(441, 22)
        Me.stbMsg.TabIndex = 9
        Me.stbMsg.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Enabled = False
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(131, 17)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "PVT"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Enabled = False
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(131, 17)
        Me.ToolStripStatusLabel2.Spring = True
        Me.ToolStripStatusLabel2.Text = "RCPT"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Enabled = False
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(131, 17)
        Me.ToolStripStatusLabel3.Spring = True
        Me.ToolStripStatusLabel3.Text = "READ"
        '
        'frmMSG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(441, 461)
        Me.Controls.Add(Me.stbMsg)
        Me.Controls.Add(Me.picMTools)
        Me.Controls.Add(Me.txtMSGBody)
        Me.Controls.Add(Me.txtMsgSubject)
        Me.Controls.Add(Me.txtMsgFrom)
        Me.Controls.Add(Me.txtMsgTo)
        Me.Controls.Add(Me.lblMsg3)
        Me.Controls.Add(Me.lblMsg2)
        Me.Controls.Add(Me.lblMsg1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMSG"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "WINS Messages"
        Me.picMTools.ResumeLayout(False)
        Me.stbMsg.ResumeLayout(False)
        Me.stbMsg.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblMsg3 As System.Windows.Forms.Label
    Private WithEvents lblMsg2 As System.Windows.Forms.Label
    Private WithEvents lblMsg1 As System.Windows.Forms.Label
    Private WithEvents chkRR As System.Windows.Forms.CheckBox
    Private WithEvents chkPVT As System.Windows.Forms.CheckBox
    Private WithEvents cmdSEND As System.Windows.Forms.Button
    Private WithEvents txtMSGBody As System.Windows.Forms.TextBox
    Private WithEvents txtMsgSubject As System.Windows.Forms.TextBox
    Private WithEvents txtMsgFrom As System.Windows.Forms.TextBox
    Private WithEvents txtMsgTo As System.Windows.Forms.TextBox
    Friend WithEvents stbMsg As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
#End Region 
End Class