<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class signin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(signin))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.userbox = New System.Windows.Forms.TextBox()
        Me.Loginbtn = New System.Windows.Forms.Button()
        Me.forgotlink = New System.Windows.Forms.LinkLabel()
        Me.uplink = New System.Windows.Forms.LinkLabel()
        Me.showbtn = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.IconPictureBox1 = New FontAwesome.Sharp.IconPictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.IconPictureBox2 = New FontAwesome.Sharp.IconPictureBox()
        Me.passbox = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.IconPictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.IconPictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(111, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 56)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Log in"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'userbox
        '
        Me.userbox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.userbox.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.userbox.ForeColor = System.Drawing.Color.Black
        Me.userbox.Location = New System.Drawing.Point(48, 11)
        Me.userbox.Name = "userbox"
        Me.userbox.Size = New System.Drawing.Size(210, 21)
        Me.userbox.TabIndex = 4
        '
        'Loginbtn
        '
        Me.Loginbtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.Loginbtn.ForeColor = System.Drawing.Color.Black
        Me.Loginbtn.Location = New System.Drawing.Point(119, 327)
        Me.Loginbtn.Name = "Loginbtn"
        Me.Loginbtn.Size = New System.Drawing.Size(138, 36)
        Me.Loginbtn.TabIndex = 7
        Me.Loginbtn.Text = "Log in"
        Me.Loginbtn.UseVisualStyleBackColor = False
        '
        'forgotlink
        '
        Me.forgotlink.AutoSize = True
        Me.forgotlink.Location = New System.Drawing.Point(16, 350)
        Me.forgotlink.Name = "forgotlink"
        Me.forgotlink.Size = New System.Drawing.Size(86, 13)
        Me.forgotlink.TabIndex = 8
        Me.forgotlink.TabStop = True
        Me.forgotlink.Text = "Forgot Account?"
        '
        'uplink
        '
        Me.uplink.AutoSize = True
        Me.uplink.Location = New System.Drawing.Point(16, 327)
        Me.uplink.Name = "uplink"
        Me.uplink.Size = New System.Drawing.Size(48, 13)
        Me.uplink.TabIndex = 9
        Me.uplink.TabStop = True
        Me.uplink.Text = "Sign Up "
        '
        'showbtn
        '
        Me.showbtn.AutoSize = True
        Me.showbtn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.showbtn.Location = New System.Drawing.Point(222, 262)
        Me.showbtn.Name = "showbtn"
        Me.showbtn.Size = New System.Drawing.Size(102, 17)
        Me.showbtn.TabIndex = 10
        Me.showbtn.Text = "Show Password"
        Me.showbtn.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.IconPictureBox1)
        Me.Panel1.Controls.Add(Me.userbox)
        Me.Panel1.Location = New System.Drawing.Point(58, 140)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(261, 44)
        Me.Panel1.TabIndex = 11
        '
        'IconPictureBox1
        '
        Me.IconPictureBox1.BackColor = System.Drawing.Color.White
        Me.IconPictureBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.IconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.UserAlt
        Me.IconPictureBox1.IconColor = System.Drawing.SystemColors.ControlText
        Me.IconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconPictureBox1.IconSize = 31
        Me.IconPictureBox1.Location = New System.Drawing.Point(6, 6)
        Me.IconPictureBox1.Name = "IconPictureBox1"
        Me.IconPictureBox1.Size = New System.Drawing.Size(37, 31)
        Me.IconPictureBox1.TabIndex = 13
        Me.IconPictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.IconPictureBox2)
        Me.Panel2.Controls.Add(Me.passbox)
        Me.Panel2.Location = New System.Drawing.Point(58, 211)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(261, 45)
        Me.Panel2.TabIndex = 12
        '
        'IconPictureBox2
        '
        Me.IconPictureBox2.BackColor = System.Drawing.Color.White
        Me.IconPictureBox2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.IconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Lock
        Me.IconPictureBox2.IconColor = System.Drawing.SystemColors.ControlText
        Me.IconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconPictureBox2.IconSize = 31
        Me.IconPictureBox2.Location = New System.Drawing.Point(6, 6)
        Me.IconPictureBox2.Name = "IconPictureBox2"
        Me.IconPictureBox2.Size = New System.Drawing.Size(37, 31)
        Me.IconPictureBox2.TabIndex = 6
        Me.IconPictureBox2.TabStop = False
        '
        'passbox
        '
        Me.passbox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.passbox.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.passbox.ForeColor = System.Drawing.Color.Black
        Me.passbox.Location = New System.Drawing.Point(48, 10)
        Me.passbox.Name = "passbox"
        Me.passbox.Size = New System.Drawing.Size(210, 21)
        Me.passbox.TabIndex = 5
        Me.passbox.UseSystemPasswordChar = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(119, 369)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(138, 36)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Close App"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'signin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(376, 469)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.showbtn)
        Me.Controls.Add(Me.uplink)
        Me.Controls.Add(Me.forgotlink)
        Me.Controls.Add(Me.Loginbtn)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "signin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Timely Task"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.IconPictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.IconPictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents userbox As TextBox
    Friend WithEvents Loginbtn As Button
    Friend WithEvents forgotlink As LinkLabel
    Friend WithEvents uplink As LinkLabel
    Friend WithEvents showbtn As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents passbox As TextBox
    Friend WithEvents IconPictureBox1 As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents IconPictureBox2 As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents Button1 As Button
End Class
