﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AlarmNotification))
        Me.panelHeader = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.panelBody = New System.Windows.Forms.Panel()
        Me.lblTaskName = New System.Windows.Forms.Label()
        Me.btnSnooze = New System.Windows.Forms.Button()
        Me.lblTaskDescription = New System.Windows.Forms.Label()
        Me.btnDismiss = New System.Windows.Forms.Button()
        Me.timerFade = New System.Windows.Forms.Timer(Me.components)
        Me.panelHeader.SuspendLayout()
        Me.panelBody.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelHeader
        '
        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.panelHeader.Controls.Add(Me.lblTitle)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(0, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(400, 40)
        Me.panelHeader.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(12, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(139, 21)
        Me.lblTitle.TabIndex = 1
        Me.lblTitle.Text = "Reminder Alarm!"
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
        Me.panelBody.TabIndex = 1
        '
        'lblTaskName
        '
        Me.lblTaskName.AutoSize = True
        Me.lblTaskName.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTaskName.Location = New System.Drawing.Point(12, 10)
        Me.lblTaskName.Name = "lblTaskName"
        Me.lblTaskName.Size = New System.Drawing.Size(87, 21)
        Me.lblTaskName.TabIndex = 1
        Me.lblTaskName.Text = "Task Name"
        '
        'btnSnooze
        '
        Me.btnSnooze.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSnooze.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnSnooze.Location = New System.Drawing.Point(214, 110)
        Me.btnSnooze.Name = "btnSnooze"
        Me.btnSnooze.Size = New System.Drawing.Size(84, 30)
        Me.btnSnooze.TabIndex = 4
        Me.btnSnooze.Text = "Snooze"
        Me.btnSnooze.UseVisualStyleBackColor = True
        '
        'lblTaskDescription
        '
        Me.lblTaskDescription.Font = New System.Drawing.Font("Segoe UI", 9.75!)
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
        Me.btnDismiss.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnDismiss.ForeColor = System.Drawing.Color.White
        Me.btnDismiss.Location = New System.Drawing.Point(304, 110)
        Me.btnDismiss.Name = "btnDismiss"
        Me.btnDismiss.Size = New System.Drawing.Size(84, 30)
        Me.btnDismiss.TabIndex = 3
        Me.btnDismiss.Text = "Dismiss"
        Me.btnDismiss.UseVisualStyleBackColor = False
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
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AlarmNotification"
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
    Friend WithEvents panelBody As Panel
    Friend WithEvents lblTaskName As Label
    Friend WithEvents btnSnooze As Button
    Friend WithEvents lblTaskDescription As Label
    Friend WithEvents btnDismiss As Button
    Friend WithEvents timerFade As Timer
End Class