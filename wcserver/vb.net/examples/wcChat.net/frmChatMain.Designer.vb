<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChatMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChatMain))
        Me.ToolStripContainer1 = New System.Windows.Forms.ToolStripContainer
        Me.ssChat = New System.Windows.Forms.StatusStrip
        Me.scMain = New System.Windows.Forms.SplitContainer
        Me.scChat = New System.Windows.Forms.SplitContainer
        Me.rtbChatLog = New System.Windows.Forms.RichTextBox
        Me.ToolStripContainer2 = New System.Windows.Forms.ToolStripContainer
        Me.txtChatMsg = New System.Windows.Forms.TextBox
        Me.tsChatMsg = New System.Windows.Forms.ToolStrip
        Me.tsbSendMsg = New System.Windows.Forms.ToolStripButton
        Me.tabUsers = New System.Windows.Forms.TabControl
        Me.tpChat = New System.Windows.Forms.TabPage
        Me.lvwUsers = New System.Windows.Forms.ListView
        Me.chUserName = New System.Windows.Forms.ColumnHeader
        Me.chUserNode = New System.Windows.Forms.ColumnHeader
        Me.chChannel = New System.Windows.Forms.ColumnHeader
        Me.imgChat = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbJoinPersonalChannel = New System.Windows.Forms.ToolStripButton
        Me.tpChannels = New System.Windows.Forms.TabPage
        Me.lvwChannels = New System.Windows.Forms.ListView
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip
        Me.tsbJoinChannel = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbRefreshChannels = New System.Windows.Forms.ToolStripButton
        Me.tpServer = New System.Windows.Forms.TabPage
        Me.lvwServerUsers = New System.Windows.Forms.ListView
        Me.chSName = New System.Windows.Forms.ColumnHeader
        Me.chSNode = New System.Windows.Forms.ColumnHeader
        Me.chSActivity = New System.Windows.Forms.ColumnHeader
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip
        Me.tsbUserPage = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbUserRecycle = New System.Windows.Forms.ToolStripButton
        Me.msChat = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveChatLogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ContentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tsChatMain = New System.Windows.Forms.ToolStrip
        Me.tsbMain = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbClear = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbExit = New System.Windows.Forms.ToolStripButton
        Me.fsdChat = New System.Windows.Forms.SaveFileDialog
        Me.BottomToolStripPanel = New System.Windows.Forms.ToolStripPanel
        Me.TopToolStripPanel = New System.Windows.Forms.ToolStripPanel
        Me.RightToolStripPanel = New System.Windows.Forms.ToolStripPanel
        Me.LeftToolStripPanel = New System.Windows.Forms.ToolStripPanel
        Me.ContentPanel = New System.Windows.Forms.ToolStripContentPanel
        Me.ToolStripContainer1.BottomToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.ContentPanel.SuspendLayout()
        Me.ToolStripContainer1.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer1.SuspendLayout()
        Me.scMain.Panel1.SuspendLayout()
        Me.scMain.Panel2.SuspendLayout()
        Me.scMain.SuspendLayout()
        Me.scChat.Panel1.SuspendLayout()
        Me.scChat.Panel2.SuspendLayout()
        Me.scChat.SuspendLayout()
        Me.ToolStripContainer2.ContentPanel.SuspendLayout()
        Me.ToolStripContainer2.TopToolStripPanel.SuspendLayout()
        Me.ToolStripContainer2.SuspendLayout()
        Me.tsChatMsg.SuspendLayout()
        Me.tabUsers.SuspendLayout()
        Me.tpChat.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.tpChannels.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.tpServer.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.msChat.SuspendLayout()
        Me.tsChatMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripContainer1
        '
        '
        'ToolStripContainer1.BottomToolStripPanel
        '
        Me.ToolStripContainer1.BottomToolStripPanel.Controls.Add(Me.ssChat)
        '
        'ToolStripContainer1.ContentPanel
        '
        Me.ToolStripContainer1.ContentPanel.Controls.Add(Me.scMain)
        Me.ToolStripContainer1.ContentPanel.Size = New System.Drawing.Size(722, 361)
        Me.ToolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer1.Name = "ToolStripContainer1"
        Me.ToolStripContainer1.Size = New System.Drawing.Size(722, 432)
        Me.ToolStripContainer1.TabIndex = 0
        Me.ToolStripContainer1.Text = "ToolStripContainer1"
        '
        'ToolStripContainer1.TopToolStripPanel
        '
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.msChat)
        Me.ToolStripContainer1.TopToolStripPanel.Controls.Add(Me.tsChatMain)
        '
        'ssChat
        '
        Me.ssChat.Dock = System.Windows.Forms.DockStyle.None
        Me.ssChat.Location = New System.Drawing.Point(0, 0)
        Me.ssChat.Name = "ssChat"
        Me.ssChat.Size = New System.Drawing.Size(722, 22)
        Me.ssChat.TabIndex = 0
        '
        'scMain
        '
        Me.scMain.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.scMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scMain.Location = New System.Drawing.Point(0, 0)
        Me.scMain.Name = "scMain"
        '
        'scMain.Panel1
        '
        Me.scMain.Panel1.Controls.Add(Me.scChat)
        '
        'scMain.Panel2
        '
        Me.scMain.Panel2.Controls.Add(Me.tabUsers)
        Me.scMain.Size = New System.Drawing.Size(722, 361)
        Me.scMain.SplitterDistance = 479
        Me.scMain.TabIndex = 0
        '
        'scChat
        '
        Me.scChat.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.scChat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scChat.Location = New System.Drawing.Point(0, 0)
        Me.scChat.Name = "scChat"
        Me.scChat.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'scChat.Panel1
        '
        Me.scChat.Panel1.Controls.Add(Me.rtbChatLog)
        '
        'scChat.Panel2
        '
        Me.scChat.Panel2.Controls.Add(Me.ToolStripContainer2)
        Me.scChat.Size = New System.Drawing.Size(479, 361)
        Me.scChat.SplitterDistance = 251
        Me.scChat.TabIndex = 0
        '
        'rtbChatLog
        '
        Me.rtbChatLog.BackColor = System.Drawing.Color.Black
        Me.rtbChatLog.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbChatLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtbChatLog.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbChatLog.Location = New System.Drawing.Point(0, 0)
        Me.rtbChatLog.Name = "rtbChatLog"
        Me.rtbChatLog.ReadOnly = True
        Me.rtbChatLog.ShowSelectionMargin = True
        Me.rtbChatLog.Size = New System.Drawing.Size(479, 251)
        Me.rtbChatLog.TabIndex = 0
        Me.rtbChatLog.Text = ""
        '
        'ToolStripContainer2
        '
        '
        'ToolStripContainer2.ContentPanel
        '
        Me.ToolStripContainer2.ContentPanel.Controls.Add(Me.txtChatMsg)
        Me.ToolStripContainer2.ContentPanel.Size = New System.Drawing.Size(479, 81)
        Me.ToolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripContainer2.Name = "ToolStripContainer2"
        Me.ToolStripContainer2.Size = New System.Drawing.Size(479, 106)
        Me.ToolStripContainer2.TabIndex = 0
        Me.ToolStripContainer2.Text = "ToolStripContainer2"
        '
        'ToolStripContainer2.TopToolStripPanel
        '
        Me.ToolStripContainer2.TopToolStripPanel.Controls.Add(Me.tsChatMsg)
        '
        'txtChatMsg
        '
        Me.txtChatMsg.AcceptsReturn = True
        Me.txtChatMsg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtChatMsg.Location = New System.Drawing.Point(0, 0)
        Me.txtChatMsg.MaxLength = 256
        Me.txtChatMsg.Multiline = True
        Me.txtChatMsg.Name = "txtChatMsg"
        Me.txtChatMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtChatMsg.Size = New System.Drawing.Size(479, 81)
        Me.txtChatMsg.TabIndex = 0
        '
        'tsChatMsg
        '
        Me.tsChatMsg.Dock = System.Windows.Forms.DockStyle.None
        Me.tsChatMsg.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsChatMsg.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.tsChatMsg.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSendMsg})
        Me.tsChatMsg.Location = New System.Drawing.Point(0, 0)
        Me.tsChatMsg.Name = "tsChatMsg"
        Me.tsChatMsg.Size = New System.Drawing.Size(479, 25)
        Me.tsChatMsg.Stretch = True
        Me.tsChatMsg.TabIndex = 0
        '
        'tsbSendMsg
        '
        Me.tsbSendMsg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSendMsg.Image = Global.wcChat.NET.My.Resources.Resources.mailnew
        Me.tsbSendMsg.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSendMsg.Name = "tsbSendMsg"
        Me.tsbSendMsg.Size = New System.Drawing.Size(23, 22)
        Me.tsbSendMsg.Text = "Send your chat message"
        '
        'tabUsers
        '
        Me.tabUsers.Controls.Add(Me.tpChat)
        Me.tabUsers.Controls.Add(Me.tpChannels)
        Me.tabUsers.Controls.Add(Me.tpServer)
        Me.tabUsers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabUsers.ImageList = Me.imgChat
        Me.tabUsers.Location = New System.Drawing.Point(0, 0)
        Me.tabUsers.Name = "tabUsers"
        Me.tabUsers.SelectedIndex = 0
        Me.tabUsers.Size = New System.Drawing.Size(239, 361)
        Me.tabUsers.TabIndex = 0
        '
        'tpChat
        '
        Me.tpChat.Controls.Add(Me.lvwUsers)
        Me.tpChat.Controls.Add(Me.ToolStrip1)
        Me.tpChat.ImageIndex = 0
        Me.tpChat.Location = New System.Drawing.Point(4, 23)
        Me.tpChat.Name = "tpChat"
        Me.tpChat.Padding = New System.Windows.Forms.Padding(3)
        Me.tpChat.Size = New System.Drawing.Size(231, 334)
        Me.tpChat.TabIndex = 0
        Me.tpChat.Text = "Chat"
        Me.tpChat.UseVisualStyleBackColor = True
        '
        'lvwUsers
        '
        Me.lvwUsers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwUsers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chUserName, Me.chUserNode, Me.chChannel})
        Me.lvwUsers.FullRowSelect = True
        Me.lvwUsers.GridLines = True
        Me.lvwUsers.HideSelection = False
        Me.lvwUsers.Location = New System.Drawing.Point(3, 31)
        Me.lvwUsers.MultiSelect = False
        Me.lvwUsers.Name = "lvwUsers"
        Me.lvwUsers.Size = New System.Drawing.Size(225, 300)
        Me.lvwUsers.SmallImageList = Me.imgChat
        Me.lvwUsers.TabIndex = 1
        Me.lvwUsers.UseCompatibleStateImageBehavior = False
        Me.lvwUsers.View = System.Windows.Forms.View.Details
        '
        'chUserName
        '
        Me.chUserName.Text = "Name"
        Me.chUserName.Width = 97
        '
        'chUserNode
        '
        Me.chUserNode.Text = "connectionID"
        Me.chUserNode.Width = 0
        '
        'chChannel
        '
        Me.chChannel.Text = "Channel"
        Me.chChannel.Width = 94
        '
        'imgChat
        '
        Me.imgChat.ImageStream = CType(resources.GetObject("imgChat.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgChat.TransparentColor = System.Drawing.Color.Transparent
        Me.imgChat.Images.SetKeyName(0, "user3.png")
        Me.imgChat.Images.SetKeyName(1, "user2new.png")
        Me.imgChat.Images.SetKeyName(2, "addressBook.png")
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbJoinPersonalChannel})
        Me.ToolStrip1.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(225, 25)
        Me.ToolStrip1.TabIndex = 4
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbJoinPersonalChannel
        '
        Me.tsbJoinPersonalChannel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbJoinPersonalChannel.Image = Global.wcChat.NET.My.Resources.Resources.usereditgreen
        Me.tsbJoinPersonalChannel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbJoinPersonalChannel.Name = "tsbJoinPersonalChannel"
        Me.tsbJoinPersonalChannel.Size = New System.Drawing.Size(23, 22)
        Me.tsbJoinPersonalChannel.Text = "Join the selected users personal channel"
        '
        'tpChannels
        '
        Me.tpChannels.Controls.Add(Me.lvwChannels)
        Me.tpChannels.Controls.Add(Me.ToolStrip2)
        Me.tpChannels.ImageIndex = 2
        Me.tpChannels.Location = New System.Drawing.Point(4, 23)
        Me.tpChannels.Name = "tpChannels"
        Me.tpChannels.Size = New System.Drawing.Size(231, 334)
        Me.tpChannels.TabIndex = 2
        Me.tpChannels.Text = "Channels"
        Me.tpChannels.UseVisualStyleBackColor = True
        '
        'lvwChannels
        '
        Me.lvwChannels.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwChannels.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvwChannels.FullRowSelect = True
        Me.lvwChannels.GridLines = True
        Me.lvwChannels.HideSelection = False
        Me.lvwChannels.Location = New System.Drawing.Point(3, 28)
        Me.lvwChannels.MultiSelect = False
        Me.lvwChannels.Name = "lvwChannels"
        Me.lvwChannels.Size = New System.Drawing.Size(225, 303)
        Me.lvwChannels.SmallImageList = Me.imgChat
        Me.lvwChannels.TabIndex = 2
        Me.lvwChannels.UseCompatibleStateImageBehavior = False
        Me.lvwChannels.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Channel"
        Me.ColumnHeader3.Width = 194
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ChannelName"
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "ObjectID"
        Me.ColumnHeader2.Width = 0
        '
        'ToolStrip2
        '
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbJoinChannel, Me.ToolStripSeparator3, Me.tsbRefreshChannels})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(231, 25)
        Me.ToolStrip2.TabIndex = 4
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'tsbJoinChannel
        '
        Me.tsbJoinChannel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbJoinChannel.Image = Global.wcChat.NET.My.Resources.Resources.recordnew
        Me.tsbJoinChannel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbJoinChannel.Name = "tsbJoinChannel"
        Me.tsbJoinChannel.Size = New System.Drawing.Size(23, 22)
        Me.tsbJoinChannel.Text = "Join the selected channel"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tsbRefreshChannels
        '
        Me.tsbRefreshChannels.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRefreshChannels.Image = Global.wcChat.NET.My.Resources.Resources.Recycle
        Me.tsbRefreshChannels.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRefreshChannels.Name = "tsbRefreshChannels"
        Me.tsbRefreshChannels.Size = New System.Drawing.Size(23, 22)
        Me.tsbRefreshChannels.Text = "Refresh the channel list"
        '
        'tpServer
        '
        Me.tpServer.Controls.Add(Me.lvwServerUsers)
        Me.tpServer.Controls.Add(Me.ToolStrip3)
        Me.tpServer.ImageIndex = 1
        Me.tpServer.Location = New System.Drawing.Point(4, 23)
        Me.tpServer.Name = "tpServer"
        Me.tpServer.Padding = New System.Windows.Forms.Padding(3)
        Me.tpServer.Size = New System.Drawing.Size(231, 334)
        Me.tpServer.TabIndex = 1
        Me.tpServer.Text = "Online"
        Me.tpServer.UseVisualStyleBackColor = True
        '
        'lvwServerUsers
        '
        Me.lvwServerUsers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvwServerUsers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chSName, Me.chSNode, Me.chSActivity})
        Me.lvwServerUsers.FullRowSelect = True
        Me.lvwServerUsers.GridLines = True
        Me.lvwServerUsers.HideSelection = False
        Me.lvwServerUsers.Location = New System.Drawing.Point(3, 31)
        Me.lvwServerUsers.MultiSelect = False
        Me.lvwServerUsers.Name = "lvwServerUsers"
        Me.lvwServerUsers.Size = New System.Drawing.Size(225, 300)
        Me.lvwServerUsers.SmallImageList = Me.imgChat
        Me.lvwServerUsers.TabIndex = 2
        Me.lvwServerUsers.UseCompatibleStateImageBehavior = False
        Me.lvwServerUsers.View = System.Windows.Forms.View.Details
        '
        'chSName
        '
        Me.chSName.Text = "Name"
        Me.chSName.Width = 82
        '
        'chSNode
        '
        Me.chSNode.Text = "Node"
        Me.chSNode.Width = 43
        '
        'chSActivity
        '
        Me.chSActivity.Text = "Activity"
        Me.chSActivity.Width = 70
        '
        'ToolStrip3
        '
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbUserPage, Me.ToolStripSeparator4, Me.tsbUserRecycle})
        Me.ToolStrip3.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(225, 25)
        Me.ToolStrip3.TabIndex = 5
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'tsbUserPage
        '
        Me.tsbUserPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbUserPage.Image = Global.wcChat.NET.My.Resources.Resources.Bell
        Me.tsbUserPage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbUserPage.Name = "tsbUserPage"
        Me.tsbUserPage.Size = New System.Drawing.Size(23, 22)
        Me.tsbUserPage.Text = "Page the selected user"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tsbUserRecycle
        '
        Me.tsbUserRecycle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbUserRecycle.Image = Global.wcChat.NET.My.Resources.Resources.Recycle
        Me.tsbUserRecycle.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbUserRecycle.Name = "tsbUserRecycle"
        Me.tsbUserRecycle.Size = New System.Drawing.Size(23, 22)
        Me.tsbUserRecycle.Text = "Refresh the user list"
        '
        'msChat
        '
        Me.msChat.Dock = System.Windows.Forms.DockStyle.None
        Me.msChat.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msChat.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.msChat.Location = New System.Drawing.Point(0, 0)
        Me.msChat.Name = "msChat"
        Me.msChat.Size = New System.Drawing.Size(722, 24)
        Me.msChat.TabIndex = 0
        Me.msChat.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveChatLogToolStripMenuItem, Me.ToolStripMenuItem2, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(36, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'SaveChatLogToolStripMenuItem
        '
        Me.SaveChatLogToolStripMenuItem.Name = "SaveChatLogToolStripMenuItem"
        Me.SaveChatLogToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.SaveChatLogToolStripMenuItem.Text = "&Save Chat Log"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(146, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContentsToolStripMenuItem, Me.ToolStripMenuItem1, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(42, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'ContentsToolStripMenuItem
        '
        Me.ContentsToolStripMenuItem.Name = "ContentsToolStripMenuItem"
        Me.ContentsToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.ContentsToolStripMenuItem.Text = "&Contents"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(121, 6)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'tsChatMain
        '
        Me.tsChatMain.Dock = System.Windows.Forms.DockStyle.None
        Me.tsChatMain.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsChatMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbMain, Me.ToolStripSeparator1, Me.tsbClear, Me.ToolStripSeparator2, Me.tsbExit})
        Me.tsChatMain.Location = New System.Drawing.Point(0, 24)
        Me.tsChatMain.Name = "tsChatMain"
        Me.tsChatMain.Size = New System.Drawing.Size(722, 25)
        Me.tsChatMain.Stretch = True
        Me.tsChatMain.TabIndex = 1
        '
        'tsbMain
        '
        Me.tsbMain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbMain.Image = Global.wcChat.NET.My.Resources.Resources.pen
        Me.tsbMain.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbMain.Name = "tsbMain"
        Me.tsbMain.Size = New System.Drawing.Size(23, 22)
        Me.tsbMain.Text = "Go to the main channel"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbClear
        '
        Me.tsbClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbClear.Image = Global.wcChat.NET.My.Resources.Resources.lcdScreen
        Me.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbClear.Name = "tsbClear"
        Me.tsbClear.Size = New System.Drawing.Size(23, 22)
        Me.tsbClear.Text = "Clear the chat window"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsbExit
        '
        Me.tsbExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbExit.Image = Global.wcChat.NET.My.Resources.Resources._exit
        Me.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExit.Name = "tsbExit"
        Me.tsbExit.Size = New System.Drawing.Size(23, 22)
        Me.tsbExit.Text = "Exit wcChat .NET"
        '
        'fsdChat
        '
        Me.fsdChat.DefaultExt = "RTF"
        Me.fsdChat.Filter = "Rich text format|*.rtf"
        Me.fsdChat.Title = "Save your chat log"
        '
        'BottomToolStripPanel
        '
        Me.BottomToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.BottomToolStripPanel.Name = "BottomToolStripPanel"
        Me.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.BottomToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.BottomToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'TopToolStripPanel
        '
        Me.TopToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.TopToolStripPanel.Name = "TopToolStripPanel"
        Me.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.TopToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.TopToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'RightToolStripPanel
        '
        Me.RightToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.RightToolStripPanel.Name = "RightToolStripPanel"
        Me.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.RightToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.RightToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'LeftToolStripPanel
        '
        Me.LeftToolStripPanel.Location = New System.Drawing.Point(0, 0)
        Me.LeftToolStripPanel.Name = "LeftToolStripPanel"
        Me.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal
        Me.LeftToolStripPanel.RowMargin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.LeftToolStripPanel.Size = New System.Drawing.Size(0, 0)
        '
        'ContentPanel
        '
        Me.ContentPanel.Size = New System.Drawing.Size(225, 328)
        '
        'frmChatMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(722, 432)
        Me.Controls.Add(Me.ToolStripContainer1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.msChat
        Me.Name = "frmChatMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "wcChat - Winserver .NET Chat example"
        Me.ToolStripContainer1.BottomToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.BottomToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer1.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer1.ResumeLayout(False)
        Me.ToolStripContainer1.PerformLayout()
        Me.scMain.Panel1.ResumeLayout(False)
        Me.scMain.Panel2.ResumeLayout(False)
        Me.scMain.ResumeLayout(False)
        Me.scChat.Panel1.ResumeLayout(False)
        Me.scChat.Panel2.ResumeLayout(False)
        Me.scChat.ResumeLayout(False)
        Me.ToolStripContainer2.ContentPanel.ResumeLayout(False)
        Me.ToolStripContainer2.ContentPanel.PerformLayout()
        Me.ToolStripContainer2.TopToolStripPanel.ResumeLayout(False)
        Me.ToolStripContainer2.TopToolStripPanel.PerformLayout()
        Me.ToolStripContainer2.ResumeLayout(False)
        Me.ToolStripContainer2.PerformLayout()
        Me.tsChatMsg.ResumeLayout(False)
        Me.tsChatMsg.PerformLayout()
        Me.tabUsers.ResumeLayout(False)
        Me.tpChat.ResumeLayout(False)
        Me.tpChat.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.tpChannels.ResumeLayout(False)
        Me.tpChannels.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.tpServer.ResumeLayout(False)
        Me.tpServer.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.msChat.ResumeLayout(False)
        Me.msChat.PerformLayout()
        Me.tsChatMain.ResumeLayout(False)
        Me.tsChatMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStripContainer1 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents ssChat As System.Windows.Forms.StatusStrip
    Friend WithEvents scMain As System.Windows.Forms.SplitContainer
    Friend WithEvents scChat As System.Windows.Forms.SplitContainer
    Friend WithEvents msChat As System.Windows.Forms.MenuStrip
    Friend WithEvents tsChatMain As System.Windows.Forms.ToolStrip
    Friend WithEvents rtbChatLog As System.Windows.Forms.RichTextBox
    Friend WithEvents ToolStripContainer2 As System.Windows.Forms.ToolStripContainer
    Friend WithEvents txtChatMsg As System.Windows.Forms.TextBox
    Friend WithEvents tsChatMsg As System.Windows.Forms.ToolStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveChatLogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents imgChat As System.Windows.Forms.ImageList
    Friend WithEvents tsbSendMsg As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbMain As System.Windows.Forms.ToolStripButton
    Friend WithEvents tabUsers As System.Windows.Forms.TabControl
    Friend WithEvents tpChat As System.Windows.Forms.TabPage
    Friend WithEvents tpServer As System.Windows.Forms.TabPage
    Friend WithEvents lvwServerUsers As System.Windows.Forms.ListView
    Friend WithEvents chSName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chSNode As System.Windows.Forms.ColumnHeader
    Friend WithEvents chSActivity As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbClear As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents fsdChat As System.Windows.Forms.SaveFileDialog
    Friend WithEvents tpChannels As System.Windows.Forms.TabPage
    Friend WithEvents lvwChannels As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvwUsers As System.Windows.Forms.ListView
    Friend WithEvents chUserName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chUserNode As System.Windows.Forms.ColumnHeader
    Friend WithEvents chChannel As System.Windows.Forms.ColumnHeader
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents BottomToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents TopToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents RightToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents LeftToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents ContentPanel As System.Windows.Forms.ToolStripContentPanel
    Friend WithEvents tsbJoinPersonalChannel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip3 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbUserPage As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbJoinChannel As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbRefreshChannels As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbUserRecycle As System.Windows.Forms.ToolStripButton

End Class
