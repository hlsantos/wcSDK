<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.outputTabPage = New System.Windows.Forms.TabPage
        Me.lbOutput = New System.Windows.Forms.ListBox
        Me.srcTextBox = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnPickWcc = New System.Windows.Forms.Button
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnCompile = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.errorAddress = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.wccOptionListBox = New System.Windows.Forms.CheckedListBox
        Me.TabControl1.SuspendLayout()
        Me.outputTabPage.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.outputTabPage)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TabControl1.Location = New System.Drawing.Point(0, 161)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(472, 227)
        Me.TabControl1.TabIndex = 0
        '
        'outputTabPage
        '
        Me.outputTabPage.Controls.Add(Me.lbOutput)
        Me.outputTabPage.Location = New System.Drawing.Point(4, 22)
        Me.outputTabPage.Name = "outputTabPage"
        Me.outputTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.outputTabPage.Size = New System.Drawing.Size(464, 201)
        Me.outputTabPage.TabIndex = 0
        Me.outputTabPage.Text = "Output"
        Me.outputTabPage.UseVisualStyleBackColor = True
        '
        'lbOutput
        '
        Me.lbOutput.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbOutput.FormattingEnabled = True
        Me.lbOutput.Location = New System.Drawing.Point(3, 3)
        Me.lbOutput.Name = "lbOutput"
        Me.lbOutput.Size = New System.Drawing.Size(458, 186)
        Me.lbOutput.TabIndex = 0
        '
        'srcTextBox
        '
        Me.srcTextBox.Location = New System.Drawing.Point(15, 25)
        Me.srcTextBox.Name = "srcTextBox"
        Me.srcTextBox.Size = New System.Drawing.Size(191, 20)
        Me.srcTextBox.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Source File Name"
        '
        'btnPickWcc
        '
        Me.btnPickWcc.Location = New System.Drawing.Point(212, 25)
        Me.btnPickWcc.Name = "btnPickWcc"
        Me.btnPickWcc.Size = New System.Drawing.Size(27, 23)
        Me.btnPickWcc.TabIndex = 3
        Me.btnPickWcc.Text = "..."
        Me.btnPickWcc.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnCompile)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.errorAddress)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.wccOptionListBox)
        Me.Panel1.Controls.Add(Me.btnPickWcc)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.srcTextBox)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(472, 116)
        Me.Panel1.TabIndex = 4
        '
        'btnCompile
        '
        Me.btnCompile.Location = New System.Drawing.Point(15, 90)
        Me.btnCompile.Name = "btnCompile"
        Me.btnCompile.Size = New System.Drawing.Size(75, 23)
        Me.btnCompile.TabIndex = 8
        Me.btnCompile.Text = "Compile"
        Me.btnCompile.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(392, 93)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(76, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Find Error"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'errorAddress
        '
        Me.errorAddress.Location = New System.Drawing.Point(338, 95)
        Me.errorAddress.Name = "errorAddress"
        Me.errorAddress.Size = New System.Drawing.Size(48, 20)
        Me.errorAddress.TabIndex = 6
        Me.errorAddress.Text = "errorAddress"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(303, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Compiler Options"
        '
        'wccOptionListBox
        '
        Me.wccOptionListBox.BackColor = System.Drawing.SystemColors.Info
        Me.wccOptionListBox.CheckOnClick = True
        Me.wccOptionListBox.Items.AddRange(New Object() {"Create MAP File", "Create RPT (Report) File"})
        Me.wccOptionListBox.Location = New System.Drawing.Point(306, 25)
        Me.wccOptionListBox.Name = "wccOptionListBox"
        Me.wccOptionListBox.Size = New System.Drawing.Size(159, 34)
        Me.wccOptionListBox.TabIndex = 4
        '
        'form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(472, 388)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "form1"
        Me.Text = "wccCompiler"
        Me.TabControl1.ResumeLayout(False)
        Me.outputTabPage.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents outputTabPage As System.Windows.Forms.TabPage
    Friend WithEvents srcTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnPickWcc As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents wccOptionListBox As System.Windows.Forms.CheckedListBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents errorAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbOutput As System.Windows.Forms.ListBox
    Friend WithEvents btnCompile As System.Windows.Forms.Button

End Class
