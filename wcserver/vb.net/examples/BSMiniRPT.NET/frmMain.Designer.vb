<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmMain
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
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.tabMain = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me._fraNavigation_0 = New System.Windows.Forms.GroupBox
        Me.txtMaxUserCount = New System.Windows.Forms.TextBox
        Me.txtTotalCalls = New System.Windows.Forms.TextBox
        Me.txtTotalUsers = New System.Windows.Forms.TextBox
        Me.txtTotalFiles = New System.Windows.Forms.TextBox
        Me.txtTotalUsersOn = New System.Windows.Forms.TextBox
        Me.txtTotalMsgs = New System.Windows.Forms.TextBox
        Me.txtLanguages = New System.Windows.Forms.TextBox
        Me.txtDoors = New System.Windows.Forms.TextBox
        Me.txtFileGroups = New System.Windows.Forms.TextBox
        Me.txtActiveFileAreas = New System.Windows.Forms.TextBox
        Me.txtConfGroups = New System.Windows.Forms.TextBox
        Me.txtActiveConfs = New System.Windows.Forms.TextBox
        Me.txtTotalSecurity = New System.Windows.Forms.TextBox
        Me.txtTotalFileAreas = New System.Windows.Forms.TextBox
        Me.txtTotalConfs = New System.Windows.Forms.TextBox
        Me.txtServerBuild = New System.Windows.Forms.TextBox
        Me.txtRegNum = New System.Windows.Forms.TextBox
        Me.txtFirstCall = New System.Windows.Forms.TextBox
        Me.txtSysop = New System.Windows.Forms.TextBox
        Me.txtSystemName = New System.Windows.Forms.TextBox
        Me._lblTitle_1 = New System.Windows.Forms.Label
        Me._lblInfo_4 = New System.Windows.Forms.Label
        Me._lblInfo_3 = New System.Windows.Forms.Label
        Me._lblInfo_2 = New System.Windows.Forms.Label
        Me._lblInfo_1 = New System.Windows.Forms.Label
        Me._lblCaption_20 = New System.Windows.Forms.Label
        Me._lblCaption_19 = New System.Windows.Forms.Label
        Me._lblCaption_18 = New System.Windows.Forms.Label
        Me._lblCaption_17 = New System.Windows.Forms.Label
        Me._lblCaption_16 = New System.Windows.Forms.Label
        Me._lblCaption_15 = New System.Windows.Forms.Label
        Me._lblCaption_14 = New System.Windows.Forms.Label
        Me._lblCaption_13 = New System.Windows.Forms.Label
        Me._lblCaption_12 = New System.Windows.Forms.Label
        Me._lblCaption_11 = New System.Windows.Forms.Label
        Me._lblCaption_10 = New System.Windows.Forms.Label
        Me._lblCaption_9 = New System.Windows.Forms.Label
        Me._lblCaption_8 = New System.Windows.Forms.Label
        Me._lblCaption_7 = New System.Windows.Forms.Label
        Me._lblCaption_0 = New System.Windows.Forms.Label
        Me._lblCaption_1 = New System.Windows.Forms.Label
        Me._lblCaption_2 = New System.Windows.Forms.Label
        Me._lblCaption_3 = New System.Windows.Forms.Label
        Me._lblCaption_4 = New System.Windows.Forms.Label
        Me._lblCaption_5 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me._fraNavigation_1 = New System.Windows.Forms.GroupBox
        Me.lvwUsers = New System.Windows.Forms.ListView
        Me.ColumnHeader12 = New System.Windows.Forms.ColumnHeader(0)
        Me.ColumnHeader13 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader14 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader15 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader16 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader17 = New System.Windows.Forms.ColumnHeader
        Me.imglMain = New System.Windows.Forms.ImageList(Me.components)
        Me.pbUsers = New System.Windows.Forms.ProgressBar
        Me.cmdUsersRefresh = New System.Windows.Forms.Button
        Me.cmdUsersOpen = New System.Windows.Forms.Button
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me._fraNavigation_2 = New System.Windows.Forms.GroupBox
        Me.pbMsgs = New System.Windows.Forms.ProgressBar
        Me.lvwMsgs = New System.Windows.Forms.ListView
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader(1)
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader10 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader11 = New System.Windows.Forms.ColumnHeader
        Me.txtMSGBody = New System.Windows.Forms.TextBox
        Me.cmdMsgDelete = New System.Windows.Forms.Button
        Me.cmdMsgNew = New System.Windows.Forms.Button
        Me.cmbMAreas = New System.Windows.Forms.ComboBox
        Me.cmdMsgRefresh = New System.Windows.Forms.Button
        Me.cmdMsgOpen = New System.Windows.Forms.Button
        Me.cmbMGroups = New System.Windows.Forms.ComboBox
        Me._lblMessages_1 = New System.Windows.Forms.Label
        Me._lblMessages_0 = New System.Windows.Forms.Label
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me._fraNavigation_3 = New System.Windows.Forms.GroupBox
        Me.pbFiles = New System.Windows.Forms.ProgressBar
        Me.lvwFiles = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader(2)
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.txtFileDesc = New System.Windows.Forms.TextBox
        Me.cmbFGroup = New System.Windows.Forms.ComboBox
        Me.cmdFileOpen = New System.Windows.Forms.Button
        Me.cmdFileRefresh = New System.Windows.Forms.Button
        Me.cmbFArea = New System.Windows.Forms.ComboBox
        Me._lblFiles_1 = New System.Windows.Forms.Label
        Me._lblFiles_0 = New System.Windows.Forms.Label
        Me.tabMain.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me._fraNavigation_0.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me._fraNavigation_1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me._fraNavigation_2.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me._fraNavigation_3.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.TabPage1)
        Me.tabMain.Controls.Add(Me.TabPage2)
        Me.tabMain.Controls.Add(Me.TabPage3)
        Me.tabMain.Controls.Add(Me.TabPage4)
        Me.tabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMain.Location = New System.Drawing.Point(0, 0)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(609, 500)
        Me.tabMain.TabIndex = 14
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me._fraNavigation_0)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(601, 474)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Tag = "INFO"
        Me.TabPage1.Text = "Information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        '_fraNavigation_0
        '
        Me._fraNavigation_0.Controls.Add(Me.txtMaxUserCount)
        Me._fraNavigation_0.Controls.Add(Me.txtTotalCalls)
        Me._fraNavigation_0.Controls.Add(Me.txtTotalUsers)
        Me._fraNavigation_0.Controls.Add(Me.txtTotalFiles)
        Me._fraNavigation_0.Controls.Add(Me.txtTotalUsersOn)
        Me._fraNavigation_0.Controls.Add(Me.txtTotalMsgs)
        Me._fraNavigation_0.Controls.Add(Me.txtLanguages)
        Me._fraNavigation_0.Controls.Add(Me.txtDoors)
        Me._fraNavigation_0.Controls.Add(Me.txtFileGroups)
        Me._fraNavigation_0.Controls.Add(Me.txtActiveFileAreas)
        Me._fraNavigation_0.Controls.Add(Me.txtConfGroups)
        Me._fraNavigation_0.Controls.Add(Me.txtActiveConfs)
        Me._fraNavigation_0.Controls.Add(Me.txtTotalSecurity)
        Me._fraNavigation_0.Controls.Add(Me.txtTotalFileAreas)
        Me._fraNavigation_0.Controls.Add(Me.txtTotalConfs)
        Me._fraNavigation_0.Controls.Add(Me.txtServerBuild)
        Me._fraNavigation_0.Controls.Add(Me.txtRegNum)
        Me._fraNavigation_0.Controls.Add(Me.txtFirstCall)
        Me._fraNavigation_0.Controls.Add(Me.txtSysop)
        Me._fraNavigation_0.Controls.Add(Me.txtSystemName)
        Me._fraNavigation_0.Controls.Add(Me._lblTitle_1)
        Me._fraNavigation_0.Controls.Add(Me._lblInfo_4)
        Me._fraNavigation_0.Controls.Add(Me._lblInfo_3)
        Me._fraNavigation_0.Controls.Add(Me._lblInfo_2)
        Me._fraNavigation_0.Controls.Add(Me._lblInfo_1)
        Me._fraNavigation_0.Controls.Add(Me._lblCaption_20)
        Me._fraNavigation_0.Controls.Add(Me._lblCaption_19)
        Me._fraNavigation_0.Controls.Add(Me._lblCaption_18)
        Me._fraNavigation_0.Controls.Add(Me._lblCaption_17)
        Me._fraNavigation_0.Controls.Add(Me._lblCaption_16)
        Me._fraNavigation_0.Controls.Add(Me._lblCaption_15)
        Me._fraNavigation_0.Controls.Add(Me._lblCaption_14)
        Me._fraNavigation_0.Controls.Add(Me._lblCaption_13)
        Me._fraNavigation_0.Controls.Add(Me._lblCaption_12)
        Me._fraNavigation_0.Controls.Add(Me._lblCaption_11)
        Me._fraNavigation_0.Controls.Add(Me._lblCaption_10)
        Me._fraNavigation_0.Controls.Add(Me._lblCaption_9)
        Me._fraNavigation_0.Controls.Add(Me._lblCaption_8)
        Me._fraNavigation_0.Controls.Add(Me._lblCaption_7)
        Me._fraNavigation_0.Controls.Add(Me._lblCaption_0)
        Me._fraNavigation_0.Controls.Add(Me._lblCaption_1)
        Me._fraNavigation_0.Controls.Add(Me._lblCaption_2)
        Me._fraNavigation_0.Controls.Add(Me._lblCaption_3)
        Me._fraNavigation_0.Controls.Add(Me._lblCaption_4)
        Me._fraNavigation_0.Controls.Add(Me._lblCaption_5)
        Me._fraNavigation_0.Dock = System.Windows.Forms.DockStyle.Fill
        Me._fraNavigation_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._fraNavigation_0.Location = New System.Drawing.Point(3, 3)
        Me._fraNavigation_0.Name = "_fraNavigation_0"
        Me._fraNavigation_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._fraNavigation_0.Size = New System.Drawing.Size(595, 468)
        Me._fraNavigation_0.TabIndex = 14
        Me._fraNavigation_0.TabStop = False
        '
        'txtMaxUserCount
        '
        Me.txtMaxUserCount.Location = New System.Drawing.Point(473, 343)
        Me.txtMaxUserCount.Name = "txtMaxUserCount"
        Me.txtMaxUserCount.ReadOnly = True
        Me.txtMaxUserCount.Size = New System.Drawing.Size(87, 21)
        Me.txtMaxUserCount.TabIndex = 83
        '
        'txtTotalCalls
        '
        Me.txtTotalCalls.Location = New System.Drawing.Point(473, 316)
        Me.txtTotalCalls.Name = "txtTotalCalls"
        Me.txtTotalCalls.ReadOnly = True
        Me.txtTotalCalls.Size = New System.Drawing.Size(87, 21)
        Me.txtTotalCalls.TabIndex = 82
        '
        'txtTotalUsers
        '
        Me.txtTotalUsers.Location = New System.Drawing.Point(283, 343)
        Me.txtTotalUsers.Name = "txtTotalUsers"
        Me.txtTotalUsers.ReadOnly = True
        Me.txtTotalUsers.Size = New System.Drawing.Size(87, 21)
        Me.txtTotalUsers.TabIndex = 81
        '
        'txtTotalFiles
        '
        Me.txtTotalFiles.Location = New System.Drawing.Point(283, 316)
        Me.txtTotalFiles.Name = "txtTotalFiles"
        Me.txtTotalFiles.ReadOnly = True
        Me.txtTotalFiles.Size = New System.Drawing.Size(87, 21)
        Me.txtTotalFiles.TabIndex = 80
        '
        'txtTotalUsersOn
        '
        Me.txtTotalUsersOn.Location = New System.Drawing.Point(93, 343)
        Me.txtTotalUsersOn.Name = "txtTotalUsersOn"
        Me.txtTotalUsersOn.ReadOnly = True
        Me.txtTotalUsersOn.Size = New System.Drawing.Size(87, 21)
        Me.txtTotalUsersOn.TabIndex = 79
        '
        'txtTotalMsgs
        '
        Me.txtTotalMsgs.Location = New System.Drawing.Point(93, 316)
        Me.txtTotalMsgs.Name = "txtTotalMsgs"
        Me.txtTotalMsgs.ReadOnly = True
        Me.txtTotalMsgs.Size = New System.Drawing.Size(87, 21)
        Me.txtTotalMsgs.TabIndex = 78
        '
        'txtLanguages
        '
        Me.txtLanguages.Location = New System.Drawing.Point(473, 272)
        Me.txtLanguages.Name = "txtLanguages"
        Me.txtLanguages.ReadOnly = True
        Me.txtLanguages.Size = New System.Drawing.Size(87, 21)
        Me.txtLanguages.TabIndex = 77
        '
        'txtDoors
        '
        Me.txtDoors.Location = New System.Drawing.Point(473, 246)
        Me.txtDoors.Name = "txtDoors"
        Me.txtDoors.ReadOnly = True
        Me.txtDoors.Size = New System.Drawing.Size(87, 21)
        Me.txtDoors.TabIndex = 76
        '
        'txtFileGroups
        '
        Me.txtFileGroups.Location = New System.Drawing.Point(283, 272)
        Me.txtFileGroups.Name = "txtFileGroups"
        Me.txtFileGroups.ReadOnly = True
        Me.txtFileGroups.Size = New System.Drawing.Size(87, 21)
        Me.txtFileGroups.TabIndex = 75
        '
        'txtActiveFileAreas
        '
        Me.txtActiveFileAreas.Location = New System.Drawing.Point(283, 246)
        Me.txtActiveFileAreas.Name = "txtActiveFileAreas"
        Me.txtActiveFileAreas.ReadOnly = True
        Me.txtActiveFileAreas.Size = New System.Drawing.Size(87, 21)
        Me.txtActiveFileAreas.TabIndex = 74
        '
        'txtConfGroups
        '
        Me.txtConfGroups.Location = New System.Drawing.Point(93, 272)
        Me.txtConfGroups.Name = "txtConfGroups"
        Me.txtConfGroups.ReadOnly = True
        Me.txtConfGroups.Size = New System.Drawing.Size(87, 21)
        Me.txtConfGroups.TabIndex = 73
        '
        'txtActiveConfs
        '
        Me.txtActiveConfs.Location = New System.Drawing.Point(93, 246)
        Me.txtActiveConfs.Name = "txtActiveConfs"
        Me.txtActiveConfs.ReadOnly = True
        Me.txtActiveConfs.Size = New System.Drawing.Size(87, 21)
        Me.txtActiveConfs.TabIndex = 72
        '
        'txtTotalSecurity
        '
        Me.txtTotalSecurity.Location = New System.Drawing.Point(473, 219)
        Me.txtTotalSecurity.Name = "txtTotalSecurity"
        Me.txtTotalSecurity.ReadOnly = True
        Me.txtTotalSecurity.Size = New System.Drawing.Size(87, 21)
        Me.txtTotalSecurity.TabIndex = 71
        '
        'txtTotalFileAreas
        '
        Me.txtTotalFileAreas.Location = New System.Drawing.Point(283, 219)
        Me.txtTotalFileAreas.Name = "txtTotalFileAreas"
        Me.txtTotalFileAreas.ReadOnly = True
        Me.txtTotalFileAreas.Size = New System.Drawing.Size(87, 21)
        Me.txtTotalFileAreas.TabIndex = 70
        '
        'txtTotalConfs
        '
        Me.txtTotalConfs.Location = New System.Drawing.Point(93, 219)
        Me.txtTotalConfs.Name = "txtTotalConfs"
        Me.txtTotalConfs.ReadOnly = True
        Me.txtTotalConfs.Size = New System.Drawing.Size(87, 21)
        Me.txtTotalConfs.TabIndex = 69
        '
        'txtServerBuild
        '
        Me.txtServerBuild.Location = New System.Drawing.Point(388, 150)
        Me.txtServerBuild.Name = "txtServerBuild"
        Me.txtServerBuild.ReadOnly = True
        Me.txtServerBuild.Size = New System.Drawing.Size(167, 21)
        Me.txtServerBuild.TabIndex = 68
        '
        'txtRegNum
        '
        Me.txtRegNum.Location = New System.Drawing.Point(388, 120)
        Me.txtRegNum.Name = "txtRegNum"
        Me.txtRegNum.ReadOnly = True
        Me.txtRegNum.Size = New System.Drawing.Size(167, 21)
        Me.txtRegNum.TabIndex = 67
        '
        'txtFirstCall
        '
        Me.txtFirstCall.Location = New System.Drawing.Point(115, 177)
        Me.txtFirstCall.Name = "txtFirstCall"
        Me.txtFirstCall.ReadOnly = True
        Me.txtFirstCall.Size = New System.Drawing.Size(167, 21)
        Me.txtFirstCall.TabIndex = 66
        '
        'txtSysop
        '
        Me.txtSysop.Location = New System.Drawing.Point(115, 150)
        Me.txtSysop.Name = "txtSysop"
        Me.txtSysop.ReadOnly = True
        Me.txtSysop.Size = New System.Drawing.Size(167, 21)
        Me.txtSysop.TabIndex = 65
        '
        'txtSystemName
        '
        Me.txtSystemName.Location = New System.Drawing.Point(115, 120)
        Me.txtSystemName.Name = "txtSystemName"
        Me.txtSystemName.ReadOnly = True
        Me.txtSystemName.Size = New System.Drawing.Size(167, 21)
        Me.txtSystemName.TabIndex = 64
        '
        '_lblTitle_1
        '
        Me._lblTitle_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblTitle_1.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblTitle_1.ForeColor = System.Drawing.Color.Black
        Me._lblTitle_1.Location = New System.Drawing.Point(16, 35)
        Me._lblTitle_1.Name = "_lblTitle_1"
        Me._lblTitle_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblTitle_1.Size = New System.Drawing.Size(553, 41)
        Me._lblTitle_1.TabIndex = 61
        Me._lblTitle_1.Text = "bsMini Reports VB .NET Example"
        Me._lblTitle_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblInfo_4
        '
        Me._lblInfo_4.AutoSize = True
        Me._lblInfo_4.BackColor = System.Drawing.Color.Transparent
        Me._lblInfo_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblInfo_4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblInfo_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblInfo_4.Location = New System.Drawing.Point(411, 162)
        Me._lblInfo_4.Name = "_lblInfo_4"
        Me._lblInfo_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblInfo_4.Size = New System.Drawing.Size(0, 13)
        Me._lblInfo_4.TabIndex = 38
        '
        '_lblInfo_3
        '
        Me._lblInfo_3.AutoSize = True
        Me._lblInfo_3.BackColor = System.Drawing.Color.Transparent
        Me._lblInfo_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblInfo_3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblInfo_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblInfo_3.Location = New System.Drawing.Point(411, 146)
        Me._lblInfo_3.Name = "_lblInfo_3"
        Me._lblInfo_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblInfo_3.Size = New System.Drawing.Size(0, 13)
        Me._lblInfo_3.TabIndex = 37
        '
        '_lblInfo_2
        '
        Me._lblInfo_2.AutoSize = True
        Me._lblInfo_2.BackColor = System.Drawing.Color.Transparent
        Me._lblInfo_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblInfo_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblInfo_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblInfo_2.Location = New System.Drawing.Point(139, 178)
        Me._lblInfo_2.Name = "_lblInfo_2"
        Me._lblInfo_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblInfo_2.Size = New System.Drawing.Size(0, 13)
        Me._lblInfo_2.TabIndex = 36
        '
        '_lblInfo_1
        '
        Me._lblInfo_1.AutoSize = True
        Me._lblInfo_1.BackColor = System.Drawing.Color.Transparent
        Me._lblInfo_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblInfo_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblInfo_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblInfo_1.Location = New System.Drawing.Point(139, 162)
        Me._lblInfo_1.Name = "_lblInfo_1"
        Me._lblInfo_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblInfo_1.Size = New System.Drawing.Size(0, 13)
        Me._lblInfo_1.TabIndex = 35
        '
        '_lblCaption_20
        '
        Me._lblCaption_20.AutoSize = True
        Me._lblCaption_20.BackColor = System.Drawing.Color.Transparent
        Me._lblCaption_20.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblCaption_20.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblCaption_20.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblCaption_20.Location = New System.Drawing.Point(390, 222)
        Me._lblCaption_20.Name = "_lblCaption_20"
        Me._lblCaption_20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblCaption_20.Size = New System.Drawing.Size(77, 13)
        Me._lblCaption_20.TabIndex = 33
        Me._lblCaption_20.Text = "Total Security:"
        Me._lblCaption_20.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblCaption_19
        '
        Me._lblCaption_19.AutoSize = True
        Me._lblCaption_19.BackColor = System.Drawing.Color.Transparent
        Me._lblCaption_19.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblCaption_19.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblCaption_19.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblCaption_19.Location = New System.Drawing.Point(375, 249)
        Me._lblCaption_19.Name = "_lblCaption_19"
        Me._lblCaption_19.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblCaption_19.Size = New System.Drawing.Size(92, 13)
        Me._lblCaption_19.TabIndex = 32
        Me._lblCaption_19.Text = "Number of Doors:"
        Me._lblCaption_19.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblCaption_18
        '
        Me._lblCaption_18.AutoSize = True
        Me._lblCaption_18.BackColor = System.Drawing.Color.Transparent
        Me._lblCaption_18.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblCaption_18.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblCaption_18.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblCaption_18.Location = New System.Drawing.Point(404, 275)
        Me._lblCaption_18.Name = "_lblCaption_18"
        Me._lblCaption_18.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblCaption_18.Size = New System.Drawing.Size(63, 13)
        Me._lblCaption_18.TabIndex = 31
        Me._lblCaption_18.Text = "Languages:"
        Me._lblCaption_18.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblCaption_17
        '
        Me._lblCaption_17.AutoSize = True
        Me._lblCaption_17.BackColor = System.Drawing.Color.Transparent
        Me._lblCaption_17.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblCaption_17.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblCaption_17.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblCaption_17.Location = New System.Drawing.Point(193, 222)
        Me._lblCaption_17.Name = "_lblCaption_17"
        Me._lblCaption_17.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblCaption_17.Size = New System.Drawing.Size(84, 13)
        Me._lblCaption_17.TabIndex = 30
        Me._lblCaption_17.Text = "Total File areas:"
        Me._lblCaption_17.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblCaption_16
        '
        Me._lblCaption_16.AutoSize = True
        Me._lblCaption_16.BackColor = System.Drawing.Color.Transparent
        Me._lblCaption_16.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblCaption_16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblCaption_16.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblCaption_16.Location = New System.Drawing.Point(186, 250)
        Me._lblCaption_16.Name = "_lblCaption_16"
        Me._lblCaption_16.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblCaption_16.Size = New System.Drawing.Size(91, 13)
        Me._lblCaption_16.TabIndex = 29
        Me._lblCaption_16.Text = "Active File Areas:"
        Me._lblCaption_16.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblCaption_15
        '
        Me._lblCaption_15.AutoSize = True
        Me._lblCaption_15.BackColor = System.Drawing.Color.Transparent
        Me._lblCaption_15.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblCaption_15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblCaption_15.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblCaption_15.Location = New System.Drawing.Point(187, 275)
        Me._lblCaption_15.Name = "_lblCaption_15"
        Me._lblCaption_15.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblCaption_15.Size = New System.Drawing.Size(90, 13)
        Me._lblCaption_15.TabIndex = 28
        Me._lblCaption_15.Text = "File Area Groups:"
        Me._lblCaption_15.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblCaption_14
        '
        Me._lblCaption_14.AutoSize = True
        Me._lblCaption_14.BackColor = System.Drawing.Color.Transparent
        Me._lblCaption_14.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblCaption_14.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblCaption_14.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblCaption_14.Location = New System.Drawing.Point(297, 123)
        Me._lblCaption_14.Name = "_lblCaption_14"
        Me._lblCaption_14.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblCaption_14.Size = New System.Drawing.Size(93, 13)
        Me._lblCaption_14.TabIndex = 27
        Me._lblCaption_14.Text = "Registration Num:"
        Me._lblCaption_14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblCaption_13
        '
        Me._lblCaption_13.AutoSize = True
        Me._lblCaption_13.BackColor = System.Drawing.Color.Transparent
        Me._lblCaption_13.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblCaption_13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblCaption_13.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblCaption_13.Location = New System.Drawing.Point(322, 153)
        Me._lblCaption_13.Name = "_lblCaption_13"
        Me._lblCaption_13.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblCaption_13.Size = New System.Drawing.Size(68, 13)
        Me._lblCaption_13.TabIndex = 26
        Me._lblCaption_13.Text = "Server Build:"
        Me._lblCaption_13.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblCaption_12
        '
        Me._lblCaption_12.AutoSize = True
        Me._lblCaption_12.BackColor = System.Drawing.Color.Transparent
        Me._lblCaption_12.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblCaption_12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblCaption_12.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblCaption_12.Location = New System.Drawing.Point(407, 319)
        Me._lblCaption_12.Name = "_lblCaption_12"
        Me._lblCaption_12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblCaption_12.Size = New System.Drawing.Size(60, 13)
        Me._lblCaption_12.TabIndex = 25
        Me._lblCaption_12.Text = "Total Calls:"
        Me._lblCaption_12.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblCaption_11
        '
        Me._lblCaption_11.AutoSize = True
        Me._lblCaption_11.BackColor = System.Drawing.Color.Transparent
        Me._lblCaption_11.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblCaption_11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblCaption_11.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblCaption_11.Location = New System.Drawing.Point(379, 346)
        Me._lblCaption_11.Name = "_lblCaption_11"
        Me._lblCaption_11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblCaption_11.Size = New System.Drawing.Size(88, 13)
        Me._lblCaption_11.TabIndex = 24
        Me._lblCaption_11.Text = "Max User Count:"
        Me._lblCaption_11.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblCaption_10
        '
        Me._lblCaption_10.AutoSize = True
        Me._lblCaption_10.BackColor = System.Drawing.Color.Transparent
        Me._lblCaption_10.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblCaption_10.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblCaption_10.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblCaption_10.Location = New System.Drawing.Point(218, 319)
        Me._lblCaption_10.Name = "_lblCaption_10"
        Me._lblCaption_10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblCaption_10.Size = New System.Drawing.Size(59, 13)
        Me._lblCaption_10.TabIndex = 23
        Me._lblCaption_10.Text = "Total Files:"
        Me._lblCaption_10.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblCaption_9
        '
        Me._lblCaption_9.AutoSize = True
        Me._lblCaption_9.BackColor = System.Drawing.Color.Transparent
        Me._lblCaption_9.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblCaption_9.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblCaption_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblCaption_9.Location = New System.Drawing.Point(212, 346)
        Me._lblCaption_9.Name = "_lblCaption_9"
        Me._lblCaption_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblCaption_9.Size = New System.Drawing.Size(65, 13)
        Me._lblCaption_9.TabIndex = 22
        Me._lblCaption_9.Text = "Total Users:"
        Me._lblCaption_9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblCaption_8
        '
        Me._lblCaption_8.AutoSize = True
        Me._lblCaption_8.BackColor = System.Drawing.Color.Transparent
        Me._lblCaption_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblCaption_8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblCaption_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblCaption_8.Location = New System.Drawing.Point(2, 319)
        Me._lblCaption_8.Name = "_lblCaption_8"
        Me._lblCaption_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblCaption_8.Size = New System.Drawing.Size(85, 13)
        Me._lblCaption_8.TabIndex = 21
        Me._lblCaption_8.Text = "Total Messages:"
        Me._lblCaption_8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblCaption_7
        '
        Me._lblCaption_7.AutoSize = True
        Me._lblCaption_7.BackColor = System.Drawing.Color.Transparent
        Me._lblCaption_7.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblCaption_7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblCaption_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblCaption_7.Location = New System.Drawing.Point(7, 343)
        Me._lblCaption_7.Name = "_lblCaption_7"
        Me._lblCaption_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblCaption_7.Size = New System.Drawing.Size(82, 13)
        Me._lblCaption_7.TabIndex = 20
        Me._lblCaption_7.Text = "Total Users On:"
        Me._lblCaption_7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblCaption_0
        '
        Me._lblCaption_0.AutoSize = True
        Me._lblCaption_0.BackColor = System.Drawing.Color.Transparent
        Me._lblCaption_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblCaption_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblCaption_0.Location = New System.Drawing.Point(33, 123)
        Me._lblCaption_0.Name = "_lblCaption_0"
        Me._lblCaption_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblCaption_0.Size = New System.Drawing.Size(76, 13)
        Me._lblCaption_0.TabIndex = 19
        Me._lblCaption_0.Text = "System Name:"
        Me._lblCaption_0.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblCaption_1
        '
        Me._lblCaption_1.AutoSize = True
        Me._lblCaption_1.BackColor = System.Drawing.Color.Transparent
        Me._lblCaption_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblCaption_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblCaption_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblCaption_1.Location = New System.Drawing.Point(37, 153)
        Me._lblCaption_1.Name = "_lblCaption_1"
        Me._lblCaption_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblCaption_1.Size = New System.Drawing.Size(72, 13)
        Me._lblCaption_1.TabIndex = 18
        Me._lblCaption_1.Text = "SysOp Name:"
        Me._lblCaption_1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblCaption_2
        '
        Me._lblCaption_2.AutoSize = True
        Me._lblCaption_2.BackColor = System.Drawing.Color.Transparent
        Me._lblCaption_2.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblCaption_2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblCaption_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblCaption_2.Location = New System.Drawing.Point(19, 177)
        Me._lblCaption_2.Name = "_lblCaption_2"
        Me._lblCaption_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblCaption_2.Size = New System.Drawing.Size(90, 13)
        Me._lblCaption_2.TabIndex = 17
        Me._lblCaption_2.Text = "First System Call:"
        Me._lblCaption_2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblCaption_3
        '
        Me._lblCaption_3.AutoSize = True
        Me._lblCaption_3.BackColor = System.Drawing.Color.Transparent
        Me._lblCaption_3.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblCaption_3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblCaption_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblCaption_3.Location = New System.Drawing.Point(21, 222)
        Me._lblCaption_3.Name = "_lblCaption_3"
        Me._lblCaption_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblCaption_3.Size = New System.Drawing.Size(66, 13)
        Me._lblCaption_3.TabIndex = 16
        Me._lblCaption_3.Text = "Total Confs:"
        Me._lblCaption_3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblCaption_4
        '
        Me._lblCaption_4.AutoSize = True
        Me._lblCaption_4.BackColor = System.Drawing.Color.Transparent
        Me._lblCaption_4.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblCaption_4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblCaption_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblCaption_4.Location = New System.Drawing.Point(15, 250)
        Me._lblCaption_4.Name = "_lblCaption_4"
        Me._lblCaption_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblCaption_4.Size = New System.Drawing.Size(72, 13)
        Me._lblCaption_4.TabIndex = 15
        Me._lblCaption_4.Text = "Active Confs:"
        Me._lblCaption_4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblCaption_5
        '
        Me._lblCaption_5.AutoSize = True
        Me._lblCaption_5.BackColor = System.Drawing.Color.Transparent
        Me._lblCaption_5.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblCaption_5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblCaption_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblCaption_5.Location = New System.Drawing.Point(16, 275)
        Me._lblCaption_5.Name = "_lblCaption_5"
        Me._lblCaption_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblCaption_5.Size = New System.Drawing.Size(71, 13)
        Me._lblCaption_5.TabIndex = 14
        Me._lblCaption_5.Text = "Conf Groups:"
        Me._lblCaption_5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me._fraNavigation_1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(601, 474)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Tag = "USERS"
        Me.TabPage2.Text = "Users"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        '_fraNavigation_1
        '
        Me._fraNavigation_1.Controls.Add(Me.lvwUsers)
        Me._fraNavigation_1.Controls.Add(Me.pbUsers)
        Me._fraNavigation_1.Controls.Add(Me.cmdUsersRefresh)
        Me._fraNavigation_1.Controls.Add(Me.cmdUsersOpen)
        Me._fraNavigation_1.Dock = System.Windows.Forms.DockStyle.Fill
        Me._fraNavigation_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._fraNavigation_1.Location = New System.Drawing.Point(3, 3)
        Me._fraNavigation_1.Name = "_fraNavigation_1"
        Me._fraNavigation_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._fraNavigation_1.Size = New System.Drawing.Size(595, 468)
        Me._fraNavigation_1.TabIndex = 10
        Me._fraNavigation_1.TabStop = False
        '
        'lvwUsers
        '
        Me.lvwUsers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwUsers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader17})
        Me.lvwUsers.FullRowSelect = True
        Me.lvwUsers.GridLines = True
        Me.lvwUsers.HideSelection = False
        Me.lvwUsers.Location = New System.Drawing.Point(8, 33)
        Me.lvwUsers.MultiSelect = False
        Me.lvwUsers.Name = "lvwUsers"
        Me.lvwUsers.Size = New System.Drawing.Size(577, 404)
        Me.lvwUsers.SmallImageList = Me.imglMain
        Me.lvwUsers.TabIndex = 75
        Me.lvwUsers.UseCompatibleStateImageBehavior = False
        Me.lvwUsers.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Text = "Login"
        Me.ColumnHeader12.Width = 100
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Text = "ID"
        Me.ColumnHeader13.Width = 35
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = "Real Name"
        Me.ColumnHeader14.Width = 100
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = "Primary Profile"
        Me.ColumnHeader15.Width = 100
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = "First Call"
        Me.ColumnHeader16.Width = 100
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = "Last Call"
        Me.ColumnHeader17.Width = 100
        '
        'imglMain
        '
        Me.imglMain.ImageStream = CType(resources.GetObject("imglMain.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imglMain.TransparentColor = System.Drawing.Color.Transparent
        Me.imglMain.Images.SetKeyName(0, "user business male 1.ico")
        Me.imglMain.Images.SetKeyName(1, "Email Read.ico")
        Me.imglMain.Images.SetKeyName(2, "document 1.ico")
        '
        'pbUsers
        '
        Me.pbUsers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbUsers.Location = New System.Drawing.Point(8, 12)
        Me.pbUsers.Name = "pbUsers"
        Me.pbUsers.Size = New System.Drawing.Size(577, 14)
        Me.pbUsers.TabIndex = 74
        '
        'cmdUsersRefresh
        '
        Me.cmdUsersRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUsersRefresh.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdUsersRefresh.Location = New System.Drawing.Point(417, 441)
        Me.cmdUsersRefresh.Name = "cmdUsersRefresh"
        Me.cmdUsersRefresh.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdUsersRefresh.Size = New System.Drawing.Size(81, 25)
        Me.cmdUsersRefresh.TabIndex = 55
        Me.cmdUsersRefresh.Text = "&Refresh"
        Me.cmdUsersRefresh.UseVisualStyleBackColor = True
        '
        'cmdUsersOpen
        '
        Me.cmdUsersOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUsersOpen.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdUsersOpen.Location = New System.Drawing.Point(504, 441)
        Me.cmdUsersOpen.Name = "cmdUsersOpen"
        Me.cmdUsersOpen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdUsersOpen.Size = New System.Drawing.Size(81, 25)
        Me.cmdUsersOpen.TabIndex = 54
        Me.cmdUsersOpen.Text = "&Open"
        Me.cmdUsersOpen.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me._fraNavigation_2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(601, 473)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Tag = "MSGS"
        Me.TabPage3.Text = "Messages"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        '_fraNavigation_2
        '
        Me._fraNavigation_2.Controls.Add(Me.pbMsgs)
        Me._fraNavigation_2.Controls.Add(Me.lvwMsgs)
        Me._fraNavigation_2.Controls.Add(Me.txtMSGBody)
        Me._fraNavigation_2.Controls.Add(Me.cmdMsgDelete)
        Me._fraNavigation_2.Controls.Add(Me.cmdMsgNew)
        Me._fraNavigation_2.Controls.Add(Me.cmbMAreas)
        Me._fraNavigation_2.Controls.Add(Me.cmdMsgRefresh)
        Me._fraNavigation_2.Controls.Add(Me.cmdMsgOpen)
        Me._fraNavigation_2.Controls.Add(Me.cmbMGroups)
        Me._fraNavigation_2.Controls.Add(Me._lblMessages_1)
        Me._fraNavigation_2.Controls.Add(Me._lblMessages_0)
        Me._fraNavigation_2.Dock = System.Windows.Forms.DockStyle.Fill
        Me._fraNavigation_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._fraNavigation_2.Location = New System.Drawing.Point(3, 3)
        Me._fraNavigation_2.Name = "_fraNavigation_2"
        Me._fraNavigation_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._fraNavigation_2.Size = New System.Drawing.Size(595, 467)
        Me._fraNavigation_2.TabIndex = 11
        Me._fraNavigation_2.TabStop = False
        '
        'pbMsgs
        '
        Me.pbMsgs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbMsgs.Location = New System.Drawing.Point(8, 44)
        Me.pbMsgs.Name = "pbMsgs"
        Me.pbMsgs.Size = New System.Drawing.Size(577, 14)
        Me.pbMsgs.TabIndex = 73
        '
        'lvwMsgs
        '
        Me.lvwMsgs.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwMsgs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11})
        Me.lvwMsgs.FullRowSelect = True
        Me.lvwMsgs.GridLines = True
        Me.lvwMsgs.HideSelection = False
        Me.lvwMsgs.Location = New System.Drawing.Point(8, 63)
        Me.lvwMsgs.MultiSelect = False
        Me.lvwMsgs.Name = "lvwMsgs"
        Me.lvwMsgs.Size = New System.Drawing.Size(577, 219)
        Me.lvwMsgs.SmallImageList = Me.imglMain
        Me.lvwMsgs.TabIndex = 72
        Me.lvwMsgs.UseCompatibleStateImageBehavior = False
        Me.lvwMsgs.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "To"
        Me.ColumnHeader6.Width = 100
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "From"
        Me.ColumnHeader7.Width = 100
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Subject"
        Me.ColumnHeader8.Width = 100
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Date"
        Me.ColumnHeader9.Width = 100
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "ID"
        Me.ColumnHeader10.Width = 100
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Conf"
        Me.ColumnHeader11.Width = 50
        '
        'txtMSGBody
        '
        Me.txtMSGBody.AcceptsReturn = True
        Me.txtMSGBody.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMSGBody.Location = New System.Drawing.Point(8, 288)
        Me.txtMSGBody.MaxLength = 0
        Me.txtMSGBody.Multiline = True
        Me.txtMSGBody.Name = "txtMSGBody"
        Me.txtMSGBody.ReadOnly = True
        Me.txtMSGBody.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtMSGBody.Size = New System.Drawing.Size(577, 145)
        Me.txtMSGBody.TabIndex = 3
        Me.txtMSGBody.WordWrap = False
        '
        'cmdMsgDelete
        '
        Me.cmdMsgDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdMsgDelete.BackColor = System.Drawing.SystemColors.Control
        Me.cmdMsgDelete.Location = New System.Drawing.Point(87, 439)
        Me.cmdMsgDelete.Name = "cmdMsgDelete"
        Me.cmdMsgDelete.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdMsgDelete.Size = New System.Drawing.Size(73, 25)
        Me.cmdMsgDelete.TabIndex = 5
        Me.cmdMsgDelete.Text = "&Delete"
        Me.cmdMsgDelete.UseVisualStyleBackColor = True
        '
        'cmdMsgNew
        '
        Me.cmdMsgNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdMsgNew.BackColor = System.Drawing.SystemColors.Control
        Me.cmdMsgNew.Location = New System.Drawing.Point(8, 439)
        Me.cmdMsgNew.Name = "cmdMsgNew"
        Me.cmdMsgNew.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdMsgNew.Size = New System.Drawing.Size(73, 25)
        Me.cmdMsgNew.TabIndex = 4
        Me.cmdMsgNew.Text = "&New"
        Me.cmdMsgNew.UseVisualStyleBackColor = True
        '
        'cmbMAreas
        '
        Me.cmbMAreas.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbMAreas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMAreas.Location = New System.Drawing.Point(344, 16)
        Me.cmbMAreas.Name = "cmbMAreas"
        Me.cmbMAreas.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbMAreas.Size = New System.Drawing.Size(241, 21)
        Me.cmbMAreas.TabIndex = 1
        '
        'cmdMsgRefresh
        '
        Me.cmdMsgRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdMsgRefresh.BackColor = System.Drawing.SystemColors.Control
        Me.cmdMsgRefresh.Location = New System.Drawing.Point(433, 439)
        Me.cmdMsgRefresh.Name = "cmdMsgRefresh"
        Me.cmdMsgRefresh.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdMsgRefresh.Size = New System.Drawing.Size(73, 25)
        Me.cmdMsgRefresh.TabIndex = 6
        Me.cmdMsgRefresh.Text = "&Refresh"
        Me.cmdMsgRefresh.UseVisualStyleBackColor = True
        '
        'cmdMsgOpen
        '
        Me.cmdMsgOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdMsgOpen.BackColor = System.Drawing.SystemColors.Control
        Me.cmdMsgOpen.Location = New System.Drawing.Point(512, 439)
        Me.cmdMsgOpen.Name = "cmdMsgOpen"
        Me.cmdMsgOpen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdMsgOpen.Size = New System.Drawing.Size(73, 25)
        Me.cmdMsgOpen.TabIndex = 7
        Me.cmdMsgOpen.Text = "&Open"
        Me.cmdMsgOpen.UseVisualStyleBackColor = True
        '
        'cmbMGroups
        '
        Me.cmbMGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMGroups.Location = New System.Drawing.Point(64, 16)
        Me.cmbMGroups.Name = "cmbMGroups"
        Me.cmbMGroups.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbMGroups.Size = New System.Drawing.Size(225, 21)
        Me.cmbMGroups.TabIndex = 0
        '
        '_lblMessages_1
        '
        Me._lblMessages_1.Location = New System.Drawing.Point(8, 16)
        Me._lblMessages_1.Name = "_lblMessages_1"
        Me._lblMessages_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMessages_1.Size = New System.Drawing.Size(41, 17)
        Me._lblMessages_1.TabIndex = 59
        Me._lblMessages_1.Text = "Group:"
        Me._lblMessages_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblMessages_0
        '
        Me._lblMessages_0.Location = New System.Drawing.Point(296, 16)
        Me._lblMessages_0.Name = "_lblMessages_0"
        Me._lblMessages_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblMessages_0.Size = New System.Drawing.Size(41, 17)
        Me._lblMessages_0.TabIndex = 58
        Me._lblMessages_0.Text = "Area:"
        Me._lblMessages_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me._fraNavigation_3)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(601, 473)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Tag = "FILES"
        Me.TabPage4.Text = "Files"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        '_fraNavigation_3
        '
        Me._fraNavigation_3.Controls.Add(Me.pbFiles)
        Me._fraNavigation_3.Controls.Add(Me.lvwFiles)
        Me._fraNavigation_3.Controls.Add(Me.txtFileDesc)
        Me._fraNavigation_3.Controls.Add(Me.cmbFGroup)
        Me._fraNavigation_3.Controls.Add(Me.cmdFileOpen)
        Me._fraNavigation_3.Controls.Add(Me.cmdFileRefresh)
        Me._fraNavigation_3.Controls.Add(Me.cmbFArea)
        Me._fraNavigation_3.Controls.Add(Me._lblFiles_1)
        Me._fraNavigation_3.Controls.Add(Me._lblFiles_0)
        Me._fraNavigation_3.Dock = System.Windows.Forms.DockStyle.Fill
        Me._fraNavigation_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._fraNavigation_3.Location = New System.Drawing.Point(3, 3)
        Me._fraNavigation_3.Name = "_fraNavigation_3"
        Me._fraNavigation_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._fraNavigation_3.Size = New System.Drawing.Size(595, 467)
        Me._fraNavigation_3.TabIndex = 12
        Me._fraNavigation_3.TabStop = False
        '
        'pbFiles
        '
        Me.pbFiles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbFiles.Location = New System.Drawing.Point(8, 43)
        Me.pbFiles.Name = "pbFiles"
        Me.pbFiles.Size = New System.Drawing.Size(577, 14)
        Me.pbFiles.TabIndex = 72
        '
        'lvwFiles
        '
        Me.lvwFiles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5})
        Me.lvwFiles.FullRowSelect = True
        Me.lvwFiles.GridLines = True
        Me.lvwFiles.HideSelection = False
        Me.lvwFiles.Location = New System.Drawing.Point(8, 63)
        Me.lvwFiles.MultiSelect = False
        Me.lvwFiles.Name = "lvwFiles"
        Me.lvwFiles.Size = New System.Drawing.Size(577, 219)
        Me.lvwFiles.SmallImageList = Me.imglMain
        Me.lvwFiles.TabIndex = 71
        Me.lvwFiles.UseCompatibleStateImageBehavior = False
        Me.lvwFiles.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "File Name"
        Me.ColumnHeader1.Width = 100
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Area"
        Me.ColumnHeader2.Width = 50
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Date"
        Me.ColumnHeader3.Width = 100
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Uploader"
        Me.ColumnHeader4.Width = 100
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Description"
        Me.ColumnHeader5.Width = 200
        '
        'txtFileDesc
        '
        Me.txtFileDesc.AcceptsReturn = True
        Me.txtFileDesc.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFileDesc.Location = New System.Drawing.Point(8, 288)
        Me.txtFileDesc.MaxLength = 0
        Me.txtFileDesc.Multiline = True
        Me.txtFileDesc.Name = "txtFileDesc"
        Me.txtFileDesc.ReadOnly = True
        Me.txtFileDesc.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtFileDesc.Size = New System.Drawing.Size(577, 145)
        Me.txtFileDesc.TabIndex = 70
        Me.txtFileDesc.WordWrap = False
        '
        'cmbFGroup
        '
        Me.cmbFGroup.BackColor = System.Drawing.SystemColors.Window
        Me.cmbFGroup.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbFGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFGroup.Location = New System.Drawing.Point(64, 16)
        Me.cmbFGroup.Name = "cmbFGroup"
        Me.cmbFGroup.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbFGroup.Size = New System.Drawing.Size(225, 21)
        Me.cmbFGroup.TabIndex = 65
        '
        'cmdFileOpen
        '
        Me.cmdFileOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFileOpen.BackColor = System.Drawing.SystemColors.Control
        Me.cmdFileOpen.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdFileOpen.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFileOpen.Location = New System.Drawing.Point(512, 440)
        Me.cmdFileOpen.Name = "cmdFileOpen"
        Me.cmdFileOpen.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdFileOpen.Size = New System.Drawing.Size(73, 25)
        Me.cmdFileOpen.TabIndex = 64
        Me.cmdFileOpen.Text = "&Open"
        Me.cmdFileOpen.UseVisualStyleBackColor = True
        '
        'cmdFileRefresh
        '
        Me.cmdFileRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdFileRefresh.BackColor = System.Drawing.SystemColors.Control
        Me.cmdFileRefresh.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdFileRefresh.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFileRefresh.Location = New System.Drawing.Point(433, 440)
        Me.cmdFileRefresh.Name = "cmdFileRefresh"
        Me.cmdFileRefresh.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdFileRefresh.Size = New System.Drawing.Size(73, 25)
        Me.cmdFileRefresh.TabIndex = 63
        Me.cmdFileRefresh.Text = "&Refresh"
        Me.cmdFileRefresh.UseVisualStyleBackColor = True
        '
        'cmbFArea
        '
        Me.cmbFArea.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbFArea.BackColor = System.Drawing.SystemColors.Window
        Me.cmbFArea.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbFArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFArea.Location = New System.Drawing.Point(344, 16)
        Me.cmbFArea.Name = "cmbFArea"
        Me.cmbFArea.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbFArea.Size = New System.Drawing.Size(241, 21)
        Me.cmbFArea.TabIndex = 62
        '
        '_lblFiles_1
        '
        Me._lblFiles_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblFiles_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblFiles_1.Location = New System.Drawing.Point(296, 16)
        Me._lblFiles_1.Name = "_lblFiles_1"
        Me._lblFiles_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblFiles_1.Size = New System.Drawing.Size(41, 17)
        Me._lblFiles_1.TabIndex = 69
        Me._lblFiles_1.Text = "Area:"
        Me._lblFiles_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        '_lblFiles_0
        '
        Me._lblFiles_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblFiles_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblFiles_0.Location = New System.Drawing.Point(8, 16)
        Me._lblFiles_0.Name = "_lblFiles_0"
        Me._lblFiles_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblFiles_0.Size = New System.Drawing.Size(41, 17)
        Me._lblFiles_0.TabIndex = 68
        Me._lblFiles_0.Text = "Group:"
        Me._lblFiles_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(609, 500)
        Me.Controls.Add(Me.tabMain)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 22)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BSMiniRPT's"
        Me.tabMain.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me._fraNavigation_0.ResumeLayout(False)
        Me._fraNavigation_0.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me._fraNavigation_1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me._fraNavigation_2.ResumeLayout(False)
        Me._fraNavigation_2.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me._fraNavigation_3.ResumeLayout(False)
        Me._fraNavigation_3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Public WithEvents _fraNavigation_0 As System.Windows.Forms.GroupBox
    Public WithEvents _lblTitle_1 As System.Windows.Forms.Label
    Public WithEvents _lblInfo_4 As System.Windows.Forms.Label
    Public WithEvents _lblInfo_3 As System.Windows.Forms.Label
    Public WithEvents _lblInfo_2 As System.Windows.Forms.Label
    Public WithEvents _lblInfo_1 As System.Windows.Forms.Label
    Public WithEvents _lblCaption_20 As System.Windows.Forms.Label
    Public WithEvents _lblCaption_19 As System.Windows.Forms.Label
    Public WithEvents _lblCaption_18 As System.Windows.Forms.Label
    Public WithEvents _lblCaption_17 As System.Windows.Forms.Label
    Public WithEvents _lblCaption_16 As System.Windows.Forms.Label
    Public WithEvents _lblCaption_15 As System.Windows.Forms.Label
    Public WithEvents _lblCaption_14 As System.Windows.Forms.Label
    Public WithEvents _lblCaption_13 As System.Windows.Forms.Label
    Public WithEvents _lblCaption_12 As System.Windows.Forms.Label
    Public WithEvents _lblCaption_11 As System.Windows.Forms.Label
    Public WithEvents _lblCaption_10 As System.Windows.Forms.Label
    Public WithEvents _lblCaption_9 As System.Windows.Forms.Label
    Public WithEvents _lblCaption_8 As System.Windows.Forms.Label
    Public WithEvents _lblCaption_7 As System.Windows.Forms.Label
    Public WithEvents _lblCaption_0 As System.Windows.Forms.Label
    Public WithEvents _lblCaption_1 As System.Windows.Forms.Label
    Public WithEvents _lblCaption_2 As System.Windows.Forms.Label
    Public WithEvents _lblCaption_3 As System.Windows.Forms.Label
    Public WithEvents _lblCaption_4 As System.Windows.Forms.Label
    Public WithEvents _lblCaption_5 As System.Windows.Forms.Label
    Public WithEvents _fraNavigation_1 As System.Windows.Forms.GroupBox
    Public WithEvents cmdUsersRefresh As System.Windows.Forms.Button
    Public WithEvents cmdUsersOpen As System.Windows.Forms.Button
    Public WithEvents _fraNavigation_2 As System.Windows.Forms.GroupBox
    Public WithEvents cmdMsgDelete As System.Windows.Forms.Button
    Public WithEvents cmdMsgNew As System.Windows.Forms.Button
    Public WithEvents cmbMAreas As System.Windows.Forms.ComboBox
    Public WithEvents cmdMsgRefresh As System.Windows.Forms.Button
    Public WithEvents cmdMsgOpen As System.Windows.Forms.Button
    Public WithEvents cmbMGroups As System.Windows.Forms.ComboBox
    Public WithEvents _lblMessages_1 As System.Windows.Forms.Label
    Public WithEvents _lblMessages_0 As System.Windows.Forms.Label
    Public WithEvents _fraNavigation_3 As System.Windows.Forms.GroupBox
    Public WithEvents cmbFGroup As System.Windows.Forms.ComboBox
    Public WithEvents cmdFileOpen As System.Windows.Forms.Button
    Public WithEvents cmdFileRefresh As System.Windows.Forms.Button
    Public WithEvents cmbFArea As System.Windows.Forms.ComboBox
    Public WithEvents _lblFiles_1 As System.Windows.Forms.Label
    Public WithEvents _lblFiles_0 As System.Windows.Forms.Label
    Friend WithEvents txtFirstCall As System.Windows.Forms.TextBox
    Friend WithEvents txtSysop As System.Windows.Forms.TextBox
    Friend WithEvents txtSystemName As System.Windows.Forms.TextBox
    Friend WithEvents txtConfGroups As System.Windows.Forms.TextBox
    Friend WithEvents txtActiveConfs As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalSecurity As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalFileAreas As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalConfs As System.Windows.Forms.TextBox
    Friend WithEvents txtServerBuild As System.Windows.Forms.TextBox
    Friend WithEvents txtRegNum As System.Windows.Forms.TextBox
    Friend WithEvents txtMaxUserCount As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalCalls As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalUsers As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalFiles As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalUsersOn As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalMsgs As System.Windows.Forms.TextBox
    Friend WithEvents txtLanguages As System.Windows.Forms.TextBox
    Friend WithEvents txtDoors As System.Windows.Forms.TextBox
    Friend WithEvents txtFileGroups As System.Windows.Forms.TextBox
    Friend WithEvents txtActiveFileAreas As System.Windows.Forms.TextBox
    Friend WithEvents lvwFiles As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents pbFiles As System.Windows.Forms.ProgressBar
    Friend WithEvents lvwMsgs As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents pbMsgs As System.Windows.Forms.ProgressBar
    Friend WithEvents lvwUsers As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents pbUsers As System.Windows.Forms.ProgressBar
    Friend WithEvents imglMain As System.Windows.Forms.ImageList
    Private WithEvents txtMSGBody As System.Windows.Forms.TextBox
    Private WithEvents txtFileDesc As System.Windows.Forms.TextBox
#End Region 
End Class