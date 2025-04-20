<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class forgot
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(forgot))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.emailbox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.codebox = New System.Windows.Forms.TextBox()
        Me.resetbtn = New System.Windows.Forms.Button()
        Me.cancelbtn = New System.Windows.Forms.Button()
        Me.lblInstructions = New System.Windows.Forms.Label()
        Me.toolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(120, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(198, 27)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Forgot Password"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(37, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 18)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Enter Username"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'emailbox
        '
        Me.emailbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.emailbox.Location = New System.Drawing.Point(173, 82)
        Me.emailbox.Name = "emailbox"
        Me.emailbox.Size = New System.Drawing.Size(204, 22)
        Me.emailbox.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(37, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 18)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Enter Birthday"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'codebox
        '
        Me.codebox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.codebox.Location = New System.Drawing.Point(173, 117)
        Me.codebox.Name = "codebox"
        Me.codebox.Size = New System.Drawing.Size(204, 22)
        Me.codebox.TabIndex = 15
        '
        'resetbtn
        '
        Me.resetbtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.resetbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.resetbtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.resetbtn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.resetbtn.Location = New System.Drawing.Point(138, 170)
        Me.resetbtn.Name = "resetbtn"
        Me.resetbtn.Size = New System.Drawing.Size(90, 28)
        Me.resetbtn.TabIndex = 17
        Me.resetbtn.Text = "Reset"
        Me.resetbtn.UseVisualStyleBackColor = False
        '
        'cancelbtn
        '
        Me.cancelbtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.cancelbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelbtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cancelbtn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.cancelbtn.Location = New System.Drawing.Point(252, 170)
        Me.cancelbtn.Name = "cancelbtn"
        Me.cancelbtn.Size = New System.Drawing.Size(90, 28)
        Me.cancelbtn.TabIndex = 18
        Me.cancelbtn.Text = "Cancel"
        Me.cancelbtn.UseVisualStyleBackColor = False
        '
        'lblInstructions
        '
        Me.lblInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstructions.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.lblInstructions.Location = New System.Drawing.Point(40, 40)
        Me.lblInstructions.Name = "lblInstructions"
        Me.lblInstructions.Size = New System.Drawing.Size(380, 35)
        Me.lblInstructions.TabIndex = 19
        Me.lblInstructions.Text = "Please enter your username and birthday to verify your identity and reset your pa" &
    "ssword."
        Me.lblInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'toolTip1
        '
        Me.toolTip1.AutoPopDelay = 5000
        Me.toolTip1.InitialDelay = 500
        Me.toolTip1.ReshowDelay = 100
        '
        'forgot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(46, Byte), Integer), CType(CType(53, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(459, 220)
        Me.Controls.Add(Me.lblInstructions)
        Me.Controls.Add(Me.cancelbtn)
        Me.Controls.Add(Me.resetbtn)
        Me.Controls.Add(Me.codebox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.emailbox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "forgot"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Timely Task"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents emailbox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents codebox As TextBox
    Friend WithEvents resetbtn As Button
    Friend WithEvents cancelbtn As Button
    Friend WithEvents lblInstructions As Label
    Friend WithEvents toolTip1 As ToolTip
End Class