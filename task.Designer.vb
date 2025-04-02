<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class task
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.todobox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.comsecbox = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.date1 = New System.Windows.Forms.DateTimePicker()
        Me.IconPictureBox1 = New FontAwesome.Sharp.IconPictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.e1 = New System.Windows.Forms.RadioButton()
        Me.s1 = New System.Windows.Forms.RadioButton()
        Me.createbtn = New System.Windows.Forms.Button()
        Me.Cancelbtn = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.IconPictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "To do"
        '
        'todobox
        '
        Me.todobox.Location = New System.Drawing.Point(68, 72)
        Me.todobox.Name = "todobox"
        Me.todobox.Size = New System.Drawing.Size(324, 20)
        Me.todobox.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(12, 109)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 22)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Comment"
        '
        'comsecbox
        '
        Me.comsecbox.Location = New System.Drawing.Point(108, 109)
        Me.comsecbox.Multiline = True
        Me.comsecbox.Name = "comsecbox"
        Me.comsecbox.Size = New System.Drawing.Size(284, 78)
        Me.comsecbox.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.date1)
        Me.Panel1.Controls.Add(Me.IconPictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(16, 193)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(335, 48)
        Me.Panel1.TabIndex = 4
        '
        'date1
        '
        Me.date1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date1.Location = New System.Drawing.Point(52, 11)
        Me.date1.Name = "date1"
        Me.date1.Size = New System.Drawing.Size(280, 24)
        Me.date1.TabIndex = 1
        '
        'IconPictureBox1
        '
        Me.IconPictureBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.IconPictureBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.IconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt
        Me.IconPictureBox1.IconColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.IconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.IconPictureBox1.IconSize = 42
        Me.IconPictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.IconPictureBox1.Name = "IconPictureBox1"
        Me.IconPictureBox1.Size = New System.Drawing.Size(43, 42)
        Me.IconPictureBox1.TabIndex = 0
        Me.IconPictureBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(12, 259)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 22)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Select Catergory"
        '
        'e1
        '
        Me.e1.AutoSize = True
        Me.e1.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.e1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.e1.Location = New System.Drawing.Point(162, 257)
        Me.e1.Name = "e1"
        Me.e1.Size = New System.Drawing.Size(72, 26)
        Me.e1.TabIndex = 6
        Me.e1.TabStop = True
        Me.e1.Text = "Event"
        Me.e1.UseVisualStyleBackColor = True
        '
        's1
        '
        Me.s1.AutoSize = True
        Me.s1.Font = New System.Drawing.Font("Microsoft YaHei UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.s1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.s1.Location = New System.Drawing.Point(240, 257)
        Me.s1.Name = "s1"
        Me.s1.Size = New System.Drawing.Size(141, 26)
        Me.s1.TabIndex = 7
        Me.s1.TabStop = True
        Me.s1.Text = "School Works"
        Me.s1.UseVisualStyleBackColor = True
        '
        'createbtn
        '
        Me.createbtn.Location = New System.Drawing.Point(91, 346)
        Me.createbtn.Name = "createbtn"
        Me.createbtn.Size = New System.Drawing.Size(222, 35)
        Me.createbtn.TabIndex = 8
        Me.createbtn.Text = "Create"
        Me.createbtn.UseVisualStyleBackColor = True
        '
        'Cancelbtn
        '
        Me.Cancelbtn.Location = New System.Drawing.Point(91, 387)
        Me.Cancelbtn.Name = "Cancelbtn"
        Me.Cancelbtn.Size = New System.Drawing.Size(222, 35)
        Me.Cancelbtn.TabIndex = 9
        Me.Cancelbtn.Text = "Cancel"
        Me.Cancelbtn.UseVisualStyleBackColor = True
        '
        'task
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(404, 450)
        Me.Controls.Add(Me.Cancelbtn)
        Me.Controls.Add(Me.createbtn)
        Me.Controls.Add(Me.s1)
        Me.Controls.Add(Me.e1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.comsecbox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.todobox)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.Name = "task"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "task"
        Me.Panel1.ResumeLayout(False)
        CType(Me.IconPictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents todobox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents comsecbox As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents IconPictureBox1 As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents date1 As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents e1 As RadioButton
    Friend WithEvents s1 As RadioButton
    Friend WithEvents createbtn As Button
    Friend WithEvents Cancelbtn As Button
End Class
