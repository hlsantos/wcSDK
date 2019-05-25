<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmFile
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
    Public WithEvents lblFile9 As System.Windows.Forms.Label
    Public WithEvents lblFile8 As System.Windows.Forms.Label
    Public WithEvents lblFile7 As System.Windows.Forms.Label
    Public WithEvents lblFile6 As System.Windows.Forms.Label
    Public WithEvents lblFile5 As System.Windows.Forms.Label
    Public WithEvents lblFile4 As System.Windows.Forms.Label
    Public WithEvents lblFile3 As System.Windows.Forms.Label
    Public WithEvents lblFile2 As System.Windows.Forms.Label
    Public WithEvents lblFile1 As System.Windows.Forms.Label
    Public WithEvents lblFStatus As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFile))
        Me.cmdFilesClose = New System.Windows.Forms.Button
        Me.txtFileDescription = New System.Windows.Forms.TextBox
        Me.txtFileDownloads = New System.Windows.Forms.TextBox
        Me.txtFileLastAccess = New System.Windows.Forms.TextBox
        Me.txtFileDate = New System.Windows.Forms.TextBox
        Me.txtFilePassword = New System.Windows.Forms.TextBox
        Me.txtFileUploader = New System.Windows.Forms.TextBox
        Me.txtFileSize = New System.Windows.Forms.TextBox
        Me.txtFileName = New System.Windows.Forms.TextBox
        Me.txtFileArea = New System.Windows.Forms.TextBox
        Me.lblFile9 = New System.Windows.Forms.Label
        Me.lblFile8 = New System.Windows.Forms.Label
        Me.lblFile7 = New System.Windows.Forms.Label
        Me.lblFile6 = New System.Windows.Forms.Label
        Me.lblFile5 = New System.Windows.Forms.Label
        Me.lblFile4 = New System.Windows.Forms.Label
        Me.lblFile3 = New System.Windows.Forms.Label
        Me.lblFile2 = New System.Windows.Forms.Label
        Me.lblFile1 = New System.Windows.Forms.Label
        Me.lblFStatus = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmdFilesClose
        '
        Me.cmdFilesClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdFilesClose.Location = New System.Drawing.Point(272, 328)
        Me.cmdFilesClose.Name = "cmdFilesClose"
        Me.cmdFilesClose.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdFilesClose.Size = New System.Drawing.Size(81, 33)
        Me.cmdFilesClose.TabIndex = 19
        Me.cmdFilesClose.Text = "&Close"
        Me.cmdFilesClose.UseVisualStyleBackColor = True
        '
        'txtFileDescription
        '
        Me.txtFileDescription.AcceptsReturn = True
        Me.txtFileDescription.Location = New System.Drawing.Point(93, 224)
        Me.txtFileDescription.Multiline = True
        Me.txtFileDescription.Name = "txtFileDescription"
        Me.txtFileDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtFileDescription.Size = New System.Drawing.Size(260, 91)
        Me.txtFileDescription.TabIndex = 8
        Me.txtFileDescription.WordWrap = False
        '
        'txtFileDownloads
        '
        Me.txtFileDownloads.Location = New System.Drawing.Point(93, 200)
        Me.txtFileDownloads.Name = "txtFileDownloads"
        Me.txtFileDownloads.Size = New System.Drawing.Size(260, 21)
        Me.txtFileDownloads.TabIndex = 7
        '
        'txtFileLastAccess
        '
        Me.txtFileLastAccess.Location = New System.Drawing.Point(93, 176)
        Me.txtFileLastAccess.Name = "txtFileLastAccess"
        Me.txtFileLastAccess.Size = New System.Drawing.Size(260, 21)
        Me.txtFileLastAccess.TabIndex = 6
        '
        'txtFileDate
        '
        Me.txtFileDate.Location = New System.Drawing.Point(93, 152)
        Me.txtFileDate.Name = "txtFileDate"
        Me.txtFileDate.Size = New System.Drawing.Size(260, 21)
        Me.txtFileDate.TabIndex = 5
        '
        'txtFilePassword
        '
        Me.txtFilePassword.Location = New System.Drawing.Point(93, 128)
        Me.txtFilePassword.Name = "txtFilePassword"
        Me.txtFilePassword.Size = New System.Drawing.Size(260, 21)
        Me.txtFilePassword.TabIndex = 4
        '
        'txtFileUploader
        '
        Me.txtFileUploader.Location = New System.Drawing.Point(93, 104)
        Me.txtFileUploader.Name = "txtFileUploader"
        Me.txtFileUploader.Size = New System.Drawing.Size(260, 21)
        Me.txtFileUploader.TabIndex = 3
        '
        'txtFileSize
        '
        Me.txtFileSize.Location = New System.Drawing.Point(93, 80)
        Me.txtFileSize.Name = "txtFileSize"
        Me.txtFileSize.Size = New System.Drawing.Size(260, 21)
        Me.txtFileSize.TabIndex = 2
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(93, 56)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(260, 21)
        Me.txtFileName.TabIndex = 1
        '
        'txtFileArea
        '
        Me.txtFileArea.Location = New System.Drawing.Point(93, 32)
        Me.txtFileArea.Name = "txtFileArea"
        Me.txtFileArea.Size = New System.Drawing.Size(260, 21)
        Me.txtFileArea.TabIndex = 0
        '
        'lblFile9
        '
        Me.lblFile9.Location = New System.Drawing.Point(8, 224)
        Me.lblFile9.Name = "lblFile9"
        Me.lblFile9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFile9.Size = New System.Drawing.Size(79, 17)
        Me.lblFile9.TabIndex = 18
        Me.lblFile9.Text = "Description:"
        Me.lblFile9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFile8
        '
        Me.lblFile8.Location = New System.Drawing.Point(8, 200)
        Me.lblFile8.Name = "lblFile8"
        Me.lblFile8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFile8.Size = New System.Drawing.Size(79, 17)
        Me.lblFile8.TabIndex = 17
        Me.lblFile8.Text = "Downloads:"
        Me.lblFile8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFile7
        '
        Me.lblFile7.Location = New System.Drawing.Point(8, 176)
        Me.lblFile7.Name = "lblFile7"
        Me.lblFile7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFile7.Size = New System.Drawing.Size(79, 17)
        Me.lblFile7.TabIndex = 16
        Me.lblFile7.Text = "Last Access:"
        Me.lblFile7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFile6
        '
        Me.lblFile6.Location = New System.Drawing.Point(8, 152)
        Me.lblFile6.Name = "lblFile6"
        Me.lblFile6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFile6.Size = New System.Drawing.Size(79, 17)
        Me.lblFile6.TabIndex = 15
        Me.lblFile6.Text = "File Date:"
        Me.lblFile6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFile5
        '
        Me.lblFile5.Location = New System.Drawing.Point(8, 128)
        Me.lblFile5.Name = "lblFile5"
        Me.lblFile5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFile5.Size = New System.Drawing.Size(79, 17)
        Me.lblFile5.TabIndex = 14
        Me.lblFile5.Text = "Password:"
        Me.lblFile5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFile4
        '
        Me.lblFile4.Location = New System.Drawing.Point(8, 104)
        Me.lblFile4.Name = "lblFile4"
        Me.lblFile4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFile4.Size = New System.Drawing.Size(79, 17)
        Me.lblFile4.TabIndex = 13
        Me.lblFile4.Text = "Uploader:"
        Me.lblFile4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFile3
        '
        Me.lblFile3.Location = New System.Drawing.Point(8, 80)
        Me.lblFile3.Name = "lblFile3"
        Me.lblFile3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFile3.Size = New System.Drawing.Size(79, 17)
        Me.lblFile3.TabIndex = 12
        Me.lblFile3.Text = "File Size:"
        Me.lblFile3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFile2
        '
        Me.lblFile2.Location = New System.Drawing.Point(8, 56)
        Me.lblFile2.Name = "lblFile2"
        Me.lblFile2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFile2.Size = New System.Drawing.Size(79, 17)
        Me.lblFile2.TabIndex = 11
        Me.lblFile2.Text = "File Name:"
        Me.lblFile2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFile1
        '
        Me.lblFile1.Location = New System.Drawing.Point(8, 32)
        Me.lblFile1.Name = "lblFile1"
        Me.lblFile1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFile1.Size = New System.Drawing.Size(79, 17)
        Me.lblFile1.TabIndex = 10
        Me.lblFile1.Text = "Area:"
        Me.lblFile1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFStatus
        '
        Me.lblFStatus.BackColor = System.Drawing.SystemColors.Highlight
        Me.lblFStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblFStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFStatus.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblFStatus.Location = New System.Drawing.Point(8, 8)
        Me.lblFStatus.Name = "lblFStatus"
        Me.lblFStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblFStatus.Size = New System.Drawing.Size(345, 17)
        Me.lblFStatus.TabIndex = 9
        Me.lblFStatus.Text = "**File DOES NOT Exist on disk**"
        Me.lblFStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.cmdFilesClose
        Me.ClientSize = New System.Drawing.Size(361, 370)
        Me.Controls.Add(Me.cmdFilesClose)
        Me.Controls.Add(Me.txtFileDescription)
        Me.Controls.Add(Me.txtFileDownloads)
        Me.Controls.Add(Me.txtFileLastAccess)
        Me.Controls.Add(Me.txtFileDate)
        Me.Controls.Add(Me.txtFilePassword)
        Me.Controls.Add(Me.txtFileUploader)
        Me.Controls.Add(Me.txtFileSize)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.txtFileArea)
        Me.Controls.Add(Me.lblFile9)
        Me.Controls.Add(Me.lblFile8)
        Me.Controls.Add(Me.lblFile7)
        Me.Controls.Add(Me.lblFile6)
        Me.Controls.Add(Me.lblFile5)
        Me.Controls.Add(Me.lblFile4)
        Me.Controls.Add(Me.lblFile3)
        Me.Controls.Add(Me.lblFile2)
        Me.Controls.Add(Me.lblFile1)
        Me.Controls.Add(Me.lblFStatus)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFile"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "WINS Files"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents cmdFilesClose As System.Windows.Forms.Button
    Private WithEvents txtFileDescription As System.Windows.Forms.TextBox
    Private WithEvents txtFileDownloads As System.Windows.Forms.TextBox
    Private WithEvents txtFileLastAccess As System.Windows.Forms.TextBox
    Private WithEvents txtFileDate As System.Windows.Forms.TextBox
    Private WithEvents txtFilePassword As System.Windows.Forms.TextBox
    Private WithEvents txtFileUploader As System.Windows.Forms.TextBox
    Private WithEvents txtFileSize As System.Windows.Forms.TextBox
    Private WithEvents txtFileName As System.Windows.Forms.TextBox
    Private WithEvents txtFileArea As System.Windows.Forms.TextBox
#End Region 
End Class