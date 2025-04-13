<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AlarmNotification
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
        Me.panelHeader = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblTaskName = New System.Windows.Forms.Label()
        Me.lblTaskDescription = New System.Windows.Forms.Label()
        Me.btnDismiss = New System.Windows.Forms.Button()
        Me.btnSnooze = New System.Windows.Forms.Button()
        Me.panelBody = New System.Windows.Forms.Panel()
        Me.timerFade = New System.Windows.Forms.Timer(Me.components)
        Me.panelHeader.SuspendLayout()
        Me.panelBody.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.lblTitle)
        Me.panelHeader.Controls.Add(Me.btnClose)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(400, 40)
        Me.panelHeader.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(12, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(138, 21)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "Reminder Alarm!"
        '
        'btnClose
        '
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(360, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 40)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "✕"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblTaskName
        '
        Me.lblTaskName.AutoSize = True
        Me.lblTaskName.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTaskName.Location = New System.Drawing.Point(12, 10)
        Me.lblTaskName.Name = "lblTaskName"
        Me.lblTaskName.Size = New System.Drawing.Size(86, 21)
        Me.lblTaskName.TabIndex = 1
        Me.lblTaskName.Text = "Task Name"
        '
        'lblTaskDescription
        '
        Me.lblTaskDescription.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTaskDescription.Location = New System.Drawing.Point(13, 40)
        Me.lblTaskDescription.Name = "lblTaskDescription"
        Me.lblTaskDescription.Size = New System.Drawing.Size(375, 60)
        Me.lblTaskDescription.TabIndex = 2
        Me.lblTaskDescription.Text = "Task description goes here."
        '
        'btnDismiss
        '
        Me.btnDismiss.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.btnDismiss.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDismiss.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDismiss.ForeColor = System.Drawing.Color.White
        Me.btnDismiss.Location = New System.Drawing.Point(304, 110)
        Me.btnDismiss.Name = "btnDismiss"
        Me.btnDismiss.Size = New System.Drawing.Size(84, 30)
        Me.btnDismiss.TabIndex = 3
        Me.btnDismiss.Text = "Dismiss"
        Me.btnDismiss.UseVisualStyleBackColor = False
        '
        'btnSnooze
        '
        Me.btnSnooze.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSnooze.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSnooze.Location = New System.Drawing.Point(214, 110)
        Me.btnSnooze.Name = "btnSnooze"
        Me.btnSnooze.Size = New System.Drawing.Size(84, 30)
        Me.btnSnooze.TabIndex = 4
        Me.btnSnooze.Text = "Snooze"
        Me.btnSnooze.UseVisualStyleBackColor = True
        '
        'panelBody
        '
        Me.panelBody.BackColor = System.Drawing.Color.White
        Me.panelBody.Controls.Add(Me.lblTaskName)
        Me.panelBody.Controls.Add(Me.btnSnooze)
        Me.panelBody.Controls.Add(Me.lblTaskDescription)
        Me.panelBody.Controls.Add(Me.btnDismiss)
        Me.panelBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelBody.Location = New System.Drawing.Point(0, 40)
        Me.panelBody.Name = "panelBody"
        Me.panelBody.Size = New System.Drawing.Size(400, 150)
        Me.panelBody.TabIndex = 5
        '
        'timerFade
        '
        Me.timerFade.Interval = 50
        '
        'AlarmNotification
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 190)
        Me.Controls.Add(Me.panelBody)
        Me.Controls.Add(Me.panelHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "AlarmNotification"
        Me.Opacity = 0.95R
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Alarm"
        Me.TopMost = True
        Me.panelHeader.ResumeLayout(False)
        Me.panelHeader.PerformLayout()
        Me.panelBody.ResumeLayout(False)
        Me.panelBody.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents lblTaskName As Label
    Friend WithEvents lblTaskDescription As Label
    Friend WithEvents btnDismiss As Button
    Friend WithEvents btnSnooze As Button
    Friend WithEvents panelBody As Panel
    Friend WithEvents timerFade As Timer
End Class