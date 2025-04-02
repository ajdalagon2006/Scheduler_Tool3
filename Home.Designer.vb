<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Home
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Home))
        Me.Panelmenu = New System.Windows.Forms.Panel()
        Me.lbluser = New System.Windows.Forms.Label()
        Me.viewbtn = New FontAwesome.Sharp.IconButton()
        Me.homebtn = New FontAwesome.Sharp.IconButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblFormTitle = New System.Windows.Forms.Label()
        Me.homecurrenticon = New FontAwesome.Sharp.IconPictureBox()
        Me.Paneldesktop = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panelmenu.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.homecurrenticon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Paneldesktop.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panelmenu
        '
        Me.Panelmenu.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Panelmenu.Controls.Add(Me.lbluser)
        Me.Panelmenu.Controls.Add(Me.viewbtn)
        Me.Panelmenu.Controls.Add(Me.homebtn)
        Me.Panelmenu.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panelmenu.Location = New System.Drawing.Point(0, 0)
        Me.Panelmenu.Name = "Panelmenu"
        Me.Panelmenu.Size = New System.Drawing.Size(1083, 58)
        Me.Panelmenu.TabIndex = 0
        '
        'lbluser
        '
        Me.lbluser.AutoSize = True
        Me.lbluser.Font = New System.Drawing.Font("Microsoft YaHei", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbluser.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.lbluser.Location = New System.Drawing.Point(410, 8)
        Me.lbluser.Name = "lbluser"
        Me.lbluser.Size = New System.Drawing.Size(263, 42)
        Me.lbluser.TabIndex = 2
        Me.lbluser.Text = "Welcome User!"
        '
        'viewbtn
        '
        Me.viewbtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.viewbtn.Dock = System.Windows.Forms.DockStyle.Left
        Me.viewbtn.FlatAppearance.BorderSize = 0
        Me.viewbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.viewbtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.viewbtn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.viewbtn.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt
        Me.viewbtn.IconColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.viewbtn.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.viewbtn.Location = New System.Drawing.Point(164, 0)
        Me.viewbtn.Name = "viewbtn"
        Me.viewbtn.Padding = New System.Windows.Forms.Padding(10, 0, 20, 0)
        Me.viewbtn.Size = New System.Drawing.Size(221, 58)
        Me.viewbtn.TabIndex = 1
        Me.viewbtn.Text = "Calendar View"
        Me.viewbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.viewbtn.UseVisualStyleBackColor = False
        '
        'homebtn
        '
        Me.homebtn.Dock = System.Windows.Forms.DockStyle.Left
        Me.homebtn.FlatAppearance.BorderSize = 0
        Me.homebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.homebtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.homebtn.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.homebtn.IconChar = FontAwesome.Sharp.IconChar.HomeUser
        Me.homebtn.IconColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.homebtn.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.homebtn.Location = New System.Drawing.Point(0, 0)
        Me.homebtn.Name = "homebtn"
        Me.homebtn.Padding = New System.Windows.Forms.Padding(10, 0, 20, 0)
        Me.homebtn.Size = New System.Drawing.Size(164, 58)
        Me.homebtn.TabIndex = 0
        Me.homebtn.Text = "Home"
        Me.homebtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.homebtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.homebtn.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Panel2.Controls.Add(Me.lblFormTitle)
        Me.Panel2.Controls.Add(Me.homecurrenticon)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 58)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(201, 658)
        Me.Panel2.TabIndex = 1
        '
        'lblFormTitle
        '
        Me.lblFormTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.lblFormTitle.Location = New System.Drawing.Point(27, 156)
        Me.lblFormTitle.Name = "lblFormTitle"
        Me.lblFormTitle.Size = New System.Drawing.Size(146, 54)
        Me.lblFormTitle.TabIndex = 1
        Me.lblFormTitle.Text = "Home"
        Me.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'homecurrenticon
        '
        Me.homecurrenticon.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.homecurrenticon.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.homecurrenticon.IconChar = FontAwesome.Sharp.IconChar.HomeUser
        Me.homecurrenticon.IconColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.homecurrenticon.IconFont = FontAwesome.Sharp.IconFont.[Auto]
        Me.homecurrenticon.IconSize = 181
        Me.homecurrenticon.Location = New System.Drawing.Point(10, 0)
        Me.homecurrenticon.Name = "homecurrenticon"
        Me.homecurrenticon.Size = New System.Drawing.Size(181, 197)
        Me.homecurrenticon.TabIndex = 0
        Me.homecurrenticon.TabStop = False
        '
        'Paneldesktop
        '
        Me.Paneldesktop.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Paneldesktop.Controls.Add(Me.Button1)
        Me.Paneldesktop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Paneldesktop.Location = New System.Drawing.Point(201, 58)
        Me.Paneldesktop.Name = "Paneldesktop"
        Me.Paneldesktop.Size = New System.Drawing.Size(882, 658)
        Me.Paneldesktop.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft YaHei", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(6, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 56)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "+"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1083, 716)
        Me.Controls.Add(Me.Paneldesktop)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panelmenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Home"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Timely Task"
        Me.Panelmenu.ResumeLayout(False)
        Me.Panelmenu.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.homecurrenticon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Paneldesktop.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panelmenu As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Paneldesktop As Panel
    Friend WithEvents viewbtn As FontAwesome.Sharp.IconButton
    Friend WithEvents homebtn As FontAwesome.Sharp.IconButton
    Friend WithEvents homecurrenticon As FontAwesome.Sharp.IconPictureBox
    Friend WithEvents lblFormTitle As Label
    Friend WithEvents lbluser As Label
    Friend WithEvents Button1 As Button
End Class
