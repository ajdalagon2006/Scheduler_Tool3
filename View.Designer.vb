<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class View
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(View))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblmonth = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.nextbtn = New System.Windows.Forms.Button()
        Me.btntoday = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.f1days = New System.Windows.Forms.FlowLayoutPanel()
        Me.f1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.link = New System.Windows.Forms.LinkLabel()
        Me.ShowToastNotification = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.Link2 = New System.Windows.Forms.LinkLabel()
        Me.Link3 = New System.Windows.Forms.LinkLabel()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.f1days.SuspendLayout()
        Me.f1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Panel1.Controls.Add(Me.lblmonth)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(915, 78)
        Me.Panel1.TabIndex = 0
        '
        'lblmonth
        '
        Me.lblmonth.Font = New System.Drawing.Font("Modern No. 20", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmonth.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.lblmonth.Location = New System.Drawing.Point(0, 0)
        Me.lblmonth.Name = "lblmonth"
        Me.lblmonth.Size = New System.Drawing.Size(344, 78)
        Me.lblmonth.TabIndex = 1
        Me.lblmonth.Text = "March, 2025"
        Me.lblmonth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.nextbtn)
        Me.Panel2.Controls.Add(Me.btntoday)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(716, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(199, 78)
        Me.Panel2.TabIndex = 0
        '
        'nextbtn
        '
        Me.nextbtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nextbtn.Location = New System.Drawing.Point(109, 19)
        Me.nextbtn.Name = "nextbtn"
        Me.nextbtn.Size = New System.Drawing.Size(61, 40)
        Me.nextbtn.TabIndex = 2
        Me.nextbtn.Text = ">"
        Me.nextbtn.UseVisualStyleBackColor = True
        '
        'btntoday
        '
        Me.btntoday.Location = New System.Drawing.Point(23, 19)
        Me.btntoday.Name = "btntoday"
        Me.btntoday.Size = New System.Drawing.Size(65, 40)
        Me.btntoday.TabIndex = 1
        Me.btntoday.Text = "Today"
        Me.btntoday.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 78)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(915, 37)
        Me.Panel3.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(779, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(126, 37)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Saturday"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(669, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 37)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Friday"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(517, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(126, 37)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Thursday"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(385, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(126, 37)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Wednesday"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(264, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(126, 37)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Tuesday"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(132, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(126, 37)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Monday"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 37)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Sunday"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'f1days
        '
        Me.f1days.AutoScroll = True
        Me.f1days.Controls.Add(Me.f1)
        Me.f1days.Dock = System.Windows.Forms.DockStyle.Fill
        Me.f1days.Location = New System.Drawing.Point(0, 115)
        Me.f1days.Name = "f1days"
        Me.f1days.Size = New System.Drawing.Size(915, 544)
        Me.f1days.TabIndex = 2
        '
        'f1
        '
        Me.f1.BackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(208, Byte), Integer))
        Me.f1.Controls.Add(Me.Label9)
        Me.f1.Controls.Add(Me.link)
        Me.f1.Controls.Add(Me.Link2)
        Me.f1.Controls.Add(Me.Link3)
        Me.f1.Location = New System.Drawing.Point(3, 3)
        Me.f1.Name = "f1"
        Me.f1.Size = New System.Drawing.Size(123, 95)
        Me.f1.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Label9.Location = New System.Drawing.Point(3, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(120, 23)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "1"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'link
        '
        Me.link.AutoSize = True
        Me.link.Location = New System.Drawing.Point(3, 23)
        Me.link.Name = "link"
        Me.link.Size = New System.Drawing.Size(59, 13)
        Me.link.TabIndex = 1
        Me.link.TabStop = True
        Me.link.Text = "LinkLabel1"
        '
        'ShowToastNotification
        '
        Me.ShowToastNotification.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ShowToastNotification.Text = "NotifyIcon1"
        Me.ShowToastNotification.Visible = True
        '
        'Link2
        '
        Me.Link2.AutoSize = True
        Me.Link2.Location = New System.Drawing.Point(3, 36)
        Me.Link2.Name = "Link2"
        Me.Link2.Size = New System.Drawing.Size(59, 13)
        Me.Link2.TabIndex = 2
        Me.Link2.TabStop = True
        Me.Link2.Text = "LinkLabel1"
        '
        'Link3
        '
        Me.Link3.AutoSize = True
        Me.Link3.Location = New System.Drawing.Point(3, 49)
        Me.Link3.Name = "Link3"
        Me.Link3.Size = New System.Drawing.Size(59, 13)
        Me.Link3.TabIndex = 3
        Me.Link3.TabStop = True
        Me.Link3.Text = "LinkLabel1"
        '
        'View
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(915, 659)
        Me.Controls.Add(Me.f1days)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "View"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Timely Task"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.f1days.ResumeLayout(False)
        Me.f1.ResumeLayout(False)
        Me.f1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblmonth As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents nextbtn As Button
    Friend WithEvents btntoday As Button
    Friend WithEvents f1days As FlowLayoutPanel
    Friend WithEvents f1 As FlowLayoutPanel
    Friend WithEvents Label9 As Label
    Friend WithEvents link As LinkLabel
    Friend WithEvents ShowToastNotification As NotifyIcon
    Friend WithEvents Link2 As LinkLabel
    Friend WithEvents Link3 As LinkLabel
End Class
