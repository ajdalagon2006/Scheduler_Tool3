<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class signup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(signup))
        Me.upbtn = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.showbtn = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.IconPictureBox1 = New FontAwesome.Sharp.IconPictureBox()
        Me.userbox = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.IconPictureBox2 = New FontAwesome.Sharp.IconPictureBox()
        Me.passbox = New System.Windows.Forms.TextBox()
        Me.cancelbtn = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.IconPictureBox3 = New FontAwesome.Sharp.IconPictureBox()
        Me.bday = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.m1 = New System.Windows.Forms.RadioButton()
        Me.f1 = New System.Windows.Forms.RadioButton()
        Me.Panel1.SuspendLayout()
        CType(Me.IconPictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.IconPictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.IconPictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'upbtn
        '
        Me.upbtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.upbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.upbtn.Location = New System.Drawing.Point(96, 337)
        Me.upbtn.Name = "upbtn"
        Me.upbtn.Size = New System.Drawing.Size(252, 36)
        Me.upbtn.TabIndex = 15
        Me.upbtn.Text = "Sign Up"
        Me.upbtn.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(170, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 27)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Sign Up"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'showbtn
        '
        Me.showbtn.AutoSize = True
        Me.showbtn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.showbtn.Location = New System.Drawing.Point(287, 304)
        Me.showbtn.Name = "showbtn"
        Me.showbtn.Size = New System.Drawing.Size(102, 17)
        Me.showbtn.TabIndex = 20
        Me.showbtn.Text = "Show Password"
        Me.showbtn.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.IconPictureBox1)
        Me.Panel1.Controls.Add(Me.userbox)
        Me.Panel1.Location = New System.Drawing.Point(90, 103)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(261, 44)
        Me.Panel1.TabIndex = 21
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
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.IconPictureBox2)
        Me.Panel2.Controls.Add(Me.passbox)
        Me.Panel2.Location = New System.Drawing.Point(90, 153)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(261, 45)
        Me.Panel2.TabIndex = 14
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
        'cancelbtn
        '
        Me.cancelbtn.Location = New System.Drawing.Point(96, 379)
        Me.cancelbtn.Name = "cancelbtn"
        Me.cancelbtn.Size = New System.Drawing.Size(252, 36)
        Me.cancelbtn.TabIndex = 22
        Me.cancelbtn.Text = "Cancel"
        Me.cancelbtn.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.IconPictureBox3)
        Me.Panel3.Controls.Add(Me.bday)
        Me.Panel3.Location = New System.Drawing.Point(90, 204)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(154, 45)
        Me.Panel3.TabIndex = 23
        '
        'IconPictureBox3
        '
        Me.IconPictureBox3.BackColor = System.Drawing.Color.White
        Me.IconPictureBox3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.IconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt
        Me.IconPictureBox3.IconColor = System.Drawing.SystemColors.ControlText
        Me.IconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconPictureBox3.IconSize = 31
        Me.IconPictureBox3.Location = New System.Drawing.Point(6, 6)
        Me.IconPictureBox3.Name = "IconPictureBox3"
        Me.IconPictureBox3.Size = New System.Drawing.Size(37, 31)
        Me.IconPictureBox3.TabIndex = 7
        Me.IconPictureBox3.TabStop = False
        '
        'bday
        '
        Me.bday.CustomFormat = "MM/dd/yyyy"
        Me.bday.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.bday.Location = New System.Drawing.Point(48, 12)
        Me.bday.Name = "bday"
        Me.bday.Size = New System.Drawing.Size(102, 20)
        Me.bday.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(98, Byte), Integer), CType(CType(47, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(85, 252)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 28)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Gender"
        '
        'm1
        '
        Me.m1.AutoSize = True
        Me.m1.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.m1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.m1.Location = New System.Drawing.Point(178, 253)
        Me.m1.Name = "m1"
        Me.m1.Size = New System.Drawing.Size(64, 23)
        Me.m1.TabIndex = 25
        Me.m1.TabStop = True
        Me.m1.Text = "Male"
        Me.m1.UseVisualStyleBackColor = True
        '
        'f1
        '
        Me.f1.AutoSize = True
        Me.f1.Font = New System.Drawing.Font("Microsoft YaHei", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.f1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.f1.Location = New System.Drawing.Point(248, 252)
        Me.f1.Name = "f1"
        Me.f1.Size = New System.Drawing.Size(81, 23)
        Me.f1.TabIndex = 26
        Me.f1.TabStop = True
        Me.f1.Text = "Female"
        Me.f1.UseVisualStyleBackColor = True
        '
        'signup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(440, 475)
        Me.Controls.Add(Me.f1)
        Me.Controls.Add(Me.m1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.cancelbtn)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.showbtn)
        Me.Controls.Add(Me.upbtn)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "signup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Timely Task"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.IconPictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.IconPictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.IconPictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents upbtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents showbtn As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents IconPictureBox1 As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents userbox As TextBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents IconPictureBox2 As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents passbox As TextBox
    Friend WithEvents cancelbtn As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents bday As DateTimePicker
    Friend WithEvents IconPictureBox3 As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents m1 As RadioButton
    Friend WithEvents f1 As RadioButton
End Class
