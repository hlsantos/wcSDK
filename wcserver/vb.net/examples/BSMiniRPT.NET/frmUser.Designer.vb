<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmUser
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
    Public WithEvents _lblUsers_8 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUser))
        Me.cmdUserCancel = New System.Windows.Forms.Button
        Me.cmdUserUpdate = New System.Windows.Forms.Button
        Me.txtUserDataPhone = New System.Windows.Forms.TextBox
        Me.txtUserPhone = New System.Windows.Forms.TextBox
        Me.txtUserCountry = New System.Windows.Forms.TextBox
        Me.txtUserZip = New System.Windows.Forms.TextBox
        Me.txtUserState = New System.Windows.Forms.TextBox
        Me.txtUserCity = New System.Windows.Forms.TextBox
        Me.txtUserAddress2 = New System.Windows.Forms.TextBox
        Me.txtUserAddress1 = New System.Windows.Forms.TextBox
        Me.txtUserFrom = New System.Windows.Forms.TextBox
        Me.txtUserRealName = New System.Windows.Forms.TextBox
        Me.txtUserID = New System.Windows.Forms.TextBox
        Me.txtUserName = New System.Windows.Forms.TextBox
        Me._lblUsers_11 = New System.Windows.Forms.Label
        Me._lblUsers_10 = New System.Windows.Forms.Label
        Me._lblUsers_9 = New System.Windows.Forms.Label
        Me._lblUsers_8 = New System.Windows.Forms.Label
        Me._lblUsers_7 = New System.Windows.Forms.Label
        Me._lblUsers_6 = New System.Windows.Forms.Label
        Me._lblUsers_5 = New System.Windows.Forms.Label
        Me._lblUsers_4 = New System.Windows.Forms.Label
        Me._lblUsers_3 = New System.Windows.Forms.Label
        Me._lblUsers_2 = New System.Windows.Forms.Label
        Me._lblUsers_1 = New System.Windows.Forms.Label
        Me._lblUsers_0 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmdUserCancel
        '
        Me.cmdUserCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdUserCancel.Location = New System.Drawing.Point(248, 264)
        Me.cmdUserCancel.Name = "cmdUserCancel"
        Me.cmdUserCancel.Size = New System.Drawing.Size(105, 33)
        Me.cmdUserCancel.TabIndex = 13
        Me.cmdUserCancel.Text = "&Cancel"
        Me.cmdUserCancel.UseVisualStyleBackColor = True
        '
        'cmdUserUpdate
        '
        Me.cmdUserUpdate.Location = New System.Drawing.Point(136, 264)
        Me.cmdUserUpdate.Name = "cmdUserUpdate"
        Me.cmdUserUpdate.Size = New System.Drawing.Size(105, 33)
        Me.cmdUserUpdate.TabIndex = 12
        Me.cmdUserUpdate.Text = "&Update User"
        Me.cmdUserUpdate.UseVisualStyleBackColor = True
        '
        'txtUserDataPhone
        '
        Me.txtUserDataPhone.Location = New System.Drawing.Point(84, 232)
        Me.txtUserDataPhone.MaxLength = 0
        Me.txtUserDataPhone.Name = "txtUserDataPhone"
        Me.txtUserDataPhone.Size = New System.Drawing.Size(269, 19)
        Me.txtUserDataPhone.TabIndex = 11
        '
        'txtUserPhone
        '
        Me.txtUserPhone.Location = New System.Drawing.Point(84, 208)
        Me.txtUserPhone.MaxLength = 0
        Me.txtUserPhone.Name = "txtUserPhone"
        Me.txtUserPhone.Size = New System.Drawing.Size(269, 19)
        Me.txtUserPhone.TabIndex = 10
        '
        'txtUserCountry
        '
        Me.txtUserCountry.Location = New System.Drawing.Point(84, 176)
        Me.txtUserCountry.MaxLength = 0
        Me.txtUserCountry.Name = "txtUserCountry"
        Me.txtUserCountry.Size = New System.Drawing.Size(269, 19)
        Me.txtUserCountry.TabIndex = 9
        '
        'txtUserZip
        '
        Me.txtUserZip.Location = New System.Drawing.Point(280, 152)
        Me.txtUserZip.MaxLength = 0
        Me.txtUserZip.Name = "txtUserZip"
        Me.txtUserZip.Size = New System.Drawing.Size(73, 19)
        Me.txtUserZip.TabIndex = 8
        '
        'txtUserState
        '
        Me.txtUserState.Location = New System.Drawing.Point(84, 152)
        Me.txtUserState.MaxLength = 0
        Me.txtUserState.Name = "txtUserState"
        Me.txtUserState.Size = New System.Drawing.Size(133, 19)
        Me.txtUserState.TabIndex = 7
        '
        'txtUserCity
        '
        Me.txtUserCity.Location = New System.Drawing.Point(84, 128)
        Me.txtUserCity.MaxLength = 0
        Me.txtUserCity.Name = "txtUserCity"
        Me.txtUserCity.Size = New System.Drawing.Size(269, 19)
        Me.txtUserCity.TabIndex = 6
        '
        'txtUserAddress2
        '
        Me.txtUserAddress2.Location = New System.Drawing.Point(84, 104)
        Me.txtUserAddress2.MaxLength = 0
        Me.txtUserAddress2.Name = "txtUserAddress2"
        Me.txtUserAddress2.Size = New System.Drawing.Size(269, 19)
        Me.txtUserAddress2.TabIndex = 5
        '
        'txtUserAddress1
        '
        Me.txtUserAddress1.Location = New System.Drawing.Point(84, 80)
        Me.txtUserAddress1.MaxLength = 0
        Me.txtUserAddress1.Name = "txtUserAddress1"
        Me.txtUserAddress1.Size = New System.Drawing.Size(269, 19)
        Me.txtUserAddress1.TabIndex = 4
        '
        'txtUserFrom
        '
        Me.txtUserFrom.Location = New System.Drawing.Point(84, 56)
        Me.txtUserFrom.MaxLength = 0
        Me.txtUserFrom.Name = "txtUserFrom"
        Me.txtUserFrom.Size = New System.Drawing.Size(269, 19)
        Me.txtUserFrom.TabIndex = 3
        '
        'txtUserRealName
        '
        Me.txtUserRealName.Location = New System.Drawing.Point(84, 32)
        Me.txtUserRealName.MaxLength = 0
        Me.txtUserRealName.Name = "txtUserRealName"
        Me.txtUserRealName.Size = New System.Drawing.Size(269, 19)
        Me.txtUserRealName.TabIndex = 2
        '
        'txtUserID
        '
        Me.txtUserID.Location = New System.Drawing.Point(296, 8)
        Me.txtUserID.MaxLength = 0
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.ReadOnly = True
        Me.txtUserID.Size = New System.Drawing.Size(57, 19)
        Me.txtUserID.TabIndex = 1
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(84, 8)
        Me.txtUserName.MaxLength = 0
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(165, 19)
        Me.txtUserName.TabIndex = 0
        '
        '_lblUsers_11
        '
        Me._lblUsers_11.Location = New System.Drawing.Point(8, 232)
        Me._lblUsers_11.Name = "_lblUsers_11"
        Me._lblUsers_11.Size = New System.Drawing.Size(70, 17)
        Me._lblUsers_11.TabIndex = 25
        Me._lblUsers_11.Text = "Data:"
        Me._lblUsers_11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '_lblUsers_10
        '
        Me._lblUsers_10.Location = New System.Drawing.Point(8, 208)
        Me._lblUsers_10.Name = "_lblUsers_10"
        Me._lblUsers_10.Size = New System.Drawing.Size(70, 17)
        Me._lblUsers_10.TabIndex = 24
        Me._lblUsers_10.Text = "Phone:"
        Me._lblUsers_10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '_lblUsers_9
        '
        Me._lblUsers_9.Location = New System.Drawing.Point(8, 176)
        Me._lblUsers_9.Name = "_lblUsers_9"
        Me._lblUsers_9.Size = New System.Drawing.Size(70, 17)
        Me._lblUsers_9.TabIndex = 23
        Me._lblUsers_9.Text = "Country:"
        Me._lblUsers_9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '_lblUsers_8
        '
        Me._lblUsers_8.BackColor = System.Drawing.Color.Transparent
        Me._lblUsers_8.Cursor = System.Windows.Forms.Cursors.Default
        Me._lblUsers_8.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._lblUsers_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._lblUsers_8.Location = New System.Drawing.Point(216, 152)
        Me._lblUsers_8.Name = "_lblUsers_8"
        Me._lblUsers_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._lblUsers_8.Size = New System.Drawing.Size(57, 17)
        Me._lblUsers_8.TabIndex = 22
        Me._lblUsers_8.Text = "Zip:"
        Me._lblUsers_8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        '_lblUsers_7
        '
        Me._lblUsers_7.Location = New System.Drawing.Point(8, 152)
        Me._lblUsers_7.Name = "_lblUsers_7"
        Me._lblUsers_7.Size = New System.Drawing.Size(70, 17)
        Me._lblUsers_7.TabIndex = 21
        Me._lblUsers_7.Text = "State:"
        Me._lblUsers_7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '_lblUsers_6
        '
        Me._lblUsers_6.Location = New System.Drawing.Point(8, 128)
        Me._lblUsers_6.Name = "_lblUsers_6"
        Me._lblUsers_6.Size = New System.Drawing.Size(70, 17)
        Me._lblUsers_6.TabIndex = 20
        Me._lblUsers_6.Text = "City:"
        Me._lblUsers_6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '_lblUsers_5
        '
        Me._lblUsers_5.Location = New System.Drawing.Point(8, 104)
        Me._lblUsers_5.Name = "_lblUsers_5"
        Me._lblUsers_5.Size = New System.Drawing.Size(70, 17)
        Me._lblUsers_5.TabIndex = 19
        Me._lblUsers_5.Text = "Address2:"
        Me._lblUsers_5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '_lblUsers_4
        '
        Me._lblUsers_4.Location = New System.Drawing.Point(8, 80)
        Me._lblUsers_4.Name = "_lblUsers_4"
        Me._lblUsers_4.Size = New System.Drawing.Size(70, 17)
        Me._lblUsers_4.TabIndex = 18
        Me._lblUsers_4.Text = "Address1:"
        Me._lblUsers_4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '_lblUsers_3
        '
        Me._lblUsers_3.Location = New System.Drawing.Point(8, 56)
        Me._lblUsers_3.Name = "_lblUsers_3"
        Me._lblUsers_3.Size = New System.Drawing.Size(70, 17)
        Me._lblUsers_3.TabIndex = 17
        Me._lblUsers_3.Text = "From:"
        Me._lblUsers_3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '_lblUsers_2
        '
        Me._lblUsers_2.Location = New System.Drawing.Point(8, 32)
        Me._lblUsers_2.Name = "_lblUsers_2"
        Me._lblUsers_2.Size = New System.Drawing.Size(70, 17)
        Me._lblUsers_2.TabIndex = 16
        Me._lblUsers_2.Text = "Real Name:"
        Me._lblUsers_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '_lblUsers_1
        '
        Me._lblUsers_1.Location = New System.Drawing.Point(232, 8)
        Me._lblUsers_1.Name = "_lblUsers_1"
        Me._lblUsers_1.Size = New System.Drawing.Size(57, 17)
        Me._lblUsers_1.TabIndex = 15
        Me._lblUsers_1.Text = "ID:"
        Me._lblUsers_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        '_lblUsers_0
        '
        Me._lblUsers_0.Location = New System.Drawing.Point(8, 8)
        Me._lblUsers_0.Name = "_lblUsers_0"
        Me._lblUsers_0.Size = New System.Drawing.Size(70, 17)
        Me._lblUsers_0.TabIndex = 14
        Me._lblUsers_0.Text = "Name:"
        Me._lblUsers_0.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdUserCancel
        Me.ClientSize = New System.Drawing.Size(362, 306)
        Me.Controls.Add(Me.cmdUserCancel)
        Me.Controls.Add(Me.cmdUserUpdate)
        Me.Controls.Add(Me.txtUserDataPhone)
        Me.Controls.Add(Me.txtUserPhone)
        Me.Controls.Add(Me.txtUserCountry)
        Me.Controls.Add(Me.txtUserZip)
        Me.Controls.Add(Me.txtUserState)
        Me.Controls.Add(Me.txtUserCity)
        Me.Controls.Add(Me.txtUserAddress2)
        Me.Controls.Add(Me.txtUserAddress1)
        Me.Controls.Add(Me.txtUserFrom)
        Me.Controls.Add(Me.txtUserRealName)
        Me.Controls.Add(Me.txtUserID)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me._lblUsers_11)
        Me.Controls.Add(Me._lblUsers_10)
        Me.Controls.Add(Me._lblUsers_9)
        Me.Controls.Add(Me._lblUsers_8)
        Me.Controls.Add(Me._lblUsers_7)
        Me.Controls.Add(Me._lblUsers_6)
        Me.Controls.Add(Me._lblUsers_5)
        Me.Controls.Add(Me._lblUsers_4)
        Me.Controls.Add(Me._lblUsers_3)
        Me.Controls.Add(Me._lblUsers_2)
        Me.Controls.Add(Me._lblUsers_1)
        Me.Controls.Add(Me._lblUsers_0)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "WINS Users"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents _lblUsers_11 As System.Windows.Forms.Label
    Private WithEvents _lblUsers_10 As System.Windows.Forms.Label
    Private WithEvents _lblUsers_9 As System.Windows.Forms.Label
    Private WithEvents _lblUsers_7 As System.Windows.Forms.Label
    Private WithEvents _lblUsers_6 As System.Windows.Forms.Label
    Private WithEvents _lblUsers_5 As System.Windows.Forms.Label
    Private WithEvents _lblUsers_4 As System.Windows.Forms.Label
    Private WithEvents _lblUsers_3 As System.Windows.Forms.Label
    Private WithEvents _lblUsers_2 As System.Windows.Forms.Label
    Private WithEvents _lblUsers_1 As System.Windows.Forms.Label
    Private WithEvents _lblUsers_0 As System.Windows.Forms.Label
    Private WithEvents cmdUserCancel As System.Windows.Forms.Button
    Private WithEvents cmdUserUpdate As System.Windows.Forms.Button
    Private WithEvents txtUserDataPhone As System.Windows.Forms.TextBox
    Private WithEvents txtUserPhone As System.Windows.Forms.TextBox
    Private WithEvents txtUserCountry As System.Windows.Forms.TextBox
    Private WithEvents txtUserZip As System.Windows.Forms.TextBox
    Private WithEvents txtUserState As System.Windows.Forms.TextBox
    Private WithEvents txtUserCity As System.Windows.Forms.TextBox
    Private WithEvents txtUserAddress2 As System.Windows.Forms.TextBox
    Private WithEvents txtUserAddress1 As System.Windows.Forms.TextBox
    Private WithEvents txtUserFrom As System.Windows.Forms.TextBox
    Private WithEvents txtUserRealName As System.Windows.Forms.TextBox
    Private WithEvents txtUserID As System.Windows.Forms.TextBox
    Private WithEvents txtUserName As System.Windows.Forms.TextBox
#End Region 
End Class