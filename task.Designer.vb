<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Task
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
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.pnlAlarmSettings = New System.Windows.Forms.Panel()
        Me.lblCustomSound = New System.Windows.Forms.Label()
        Me.btnBrowseSound = New System.Windows.Forms.Button()
        Me.txtSoundFile = New System.Windows.Forms.TextBox()
        Me.timePicker = New System.Windows.Forms.DateTimePicker()
        Me.chkAlarm = New System.Windows.Forms.CheckBox()
        Me.pnlTimeSettings = New System.Windows.Forms.Panel()
        Me.chkAllDay = New System.Windows.Forms.CheckBox()
        Me.cmbEndTime = New System.Windows.Forms.ComboBox()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.cmbStartTime = New System.Windows.Forms.ComboBox()
        Me.date1 = New System.Windows.Forms.DateTimePicker()
        Me.pnlCategory = New System.Windows.Forms.Panel()
        Me.s1 = New System.Windows.Forms.RadioButton()
        Me.e1 = New System.Windows.Forms.RadioButton()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.comsecbox = New System.Windows.Forms.TextBox()
        Me.todobox = New System.Windows.Forms.TextBox()
        Me.pnlHeader.SuspendLayout()
        Me.pnlMain.SuspendLayout()
        Me.pnlAlarmSettings.SuspendLayout()
        Me.pnlTimeSettings.SuspendLayout()
        Me.pnlCategory.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlHeader.Controls.Add(Me.btnCancel)
        Me.pnlHeader.Controls.Add(Me.btnSave)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(500, 50)
        Me.pnlHeader.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(330, 10)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(70, 28)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(410, 10)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(70, 28)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'pnlMain
        '
        Me.pnlMain.BackColor = System.Drawing.Color.White
        Me.pnlMain.Controls.Add(Me.pnlAlarmSettings)
        Me.pnlMain.Controls.Add(Me.chkAlarm)
        Me.pnlMain.Controls.Add(Me.pnlTimeSettings)
        Me.pnlMain.Controls.Add(Me.pnlCategory)
        Me.pnlMain.Controls.Add(Me.comsecbox)
        Me.pnlMain.Controls.Add(Me.todobox)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 50)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlMain.Size = New System.Drawing.Size(500, 450)
        Me.pnlMain.TabIndex = 1
        '
        'pnlAlarmSettings
        '
        Me.pnlAlarmSettings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlAlarmSettings.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlAlarmSettings.Controls.Add(Me.lblCustomSound)
        Me.pnlAlarmSettings.Controls.Add(Me.btnBrowseSound)
        Me.pnlAlarmSettings.Controls.Add(Me.txtSoundFile)
        Me.pnlAlarmSettings.Controls.Add(Me.timePicker)
        Me.pnlAlarmSettings.Location = New System.Drawing.Point(20, 290)
        Me.pnlAlarmSettings.Name = "pnlAlarmSettings"
        Me.pnlAlarmSettings.Size = New System.Drawing.Size(460, 110)
        Me.pnlAlarmSettings.TabIndex = 5
        '
        'lblCustomSound
        '
        Me.lblCustomSound.AutoSize = True
        Me.lblCustomSound.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomSound.Location = New System.Drawing.Point(10, 50)
        Me.lblCustomSound.Name = "lblCustomSound"
        Me.lblCustomSound.Size = New System.Drawing.Size(89, 15)
        Me.lblCustomSound.TabIndex = 3
        Me.lblCustomSound.Text = "Custom Sound:"
        '
        'btnBrowseSound
        '
        Me.btnBrowseSound.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowseSound.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnBrowseSound.FlatAppearance.BorderColor = System.Drawing.Color.LightGray
        Me.btnBrowseSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowseSound.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowseSound.Location = New System.Drawing.Point(377, 70)
        Me.btnBrowseSound.Name = "btnBrowseSound"
        Me.btnBrowseSound.Size = New System.Drawing.Size(70, 25)
        Me.btnBrowseSound.TabIndex = 2
        Me.btnBrowseSound.Text = "Browse..."
        Me.btnBrowseSound.UseVisualStyleBackColor = False
        '
        'txtSoundFile
        '
        Me.txtSoundFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSoundFile.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSoundFile.Location = New System.Drawing.Point(13, 70)
        Me.txtSoundFile.Name = "txtSoundFile"
        Me.txtSoundFile.Size = New System.Drawing.Size(358, 23)
        Me.txtSoundFile.TabIndex = 1
        Me.txtSoundFile.Text = "default.wav"
        '
        'timePicker
        '
        Me.timePicker.CustomFormat = "h:mm tt"
        Me.timePicker.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.timePicker.Location = New System.Drawing.Point(13, 15)
        Me.timePicker.Name = "timePicker"
        Me.timePicker.ShowUpDown = True
        Me.timePicker.Size = New System.Drawing.Size(100, 23)
        Me.timePicker.TabIndex = 0
        '
        'chkAlarm
        '
        Me.chkAlarm.AutoSize = True
        Me.chkAlarm.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAlarm.Location = New System.Drawing.Point(20, 260)
        Me.chkAlarm.Name = "chkAlarm"
        Me.chkAlarm.Size = New System.Drawing.Size(101, 21)
        Me.chkAlarm.TabIndex = 4
        Me.chkAlarm.Text = "Set an Alarm"
        Me.chkAlarm.UseVisualStyleBackColor = True
        '
        'pnlTimeSettings
        '
        Me.pnlTimeSettings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTimeSettings.BackColor = System.Drawing.Color.White
        Me.pnlTimeSettings.Controls.Add(Me.chkAllDay)
        Me.pnlTimeSettings.Controls.Add(Me.cmbEndTime)
        Me.pnlTimeSettings.Controls.Add(Me.lblTo)
        Me.pnlTimeSettings.Controls.Add(Me.cmbStartTime)
        Me.pnlTimeSettings.Controls.Add(Me.date1)
        Me.pnlTimeSettings.Location = New System.Drawing.Point(20, 185)
        Me.pnlTimeSettings.Name = "pnlTimeSettings"
        Me.pnlTimeSettings.Size = New System.Drawing.Size(460, 35)
        Me.pnlTimeSettings.TabIndex = 2
        '
        'chkAllDay
        '
        Me.chkAllDay.AutoSize = True
        Me.chkAllDay.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAllDay.Location = New System.Drawing.Point(380, 8)
        Me.chkAllDay.Name = "chkAllDay"
        Me.chkAllDay.Size = New System.Drawing.Size(62, 19)
        Me.chkAllDay.TabIndex = 4
        Me.chkAllDay.Text = "All day"
        Me.chkAllDay.UseVisualStyleBackColor = True
        '
        'cmbEndTime
        '
        Me.cmbEndTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEndTime.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEndTime.FormattingEnabled = True
        Me.cmbEndTime.Items.AddRange(New Object() {"12:00 AM", "12:30 AM", "1:00 AM", "1:30 AM", "2:00 AM", "2:30 AM", "3:00 AM", "3:30 AM", "4:00 AM", "4:30 AM", "5:00 AM", "5:30 AM", "6:00 AM", "6:30 AM", "7:00 AM", "7:30 AM", "8:00 AM", "8:30 AM", "9:00 AM", "9:30 AM", "10:00 AM", "10:30 AM", "11:00 AM", "11:30 AM", "12:00 PM", "12:30 PM", "1:00 PM", "1:30 PM", "2:00 PM", "2:30 PM", "3:00 PM", "3:30 PM", "4:00 PM", "4:30 PM", "5:00 PM", "5:30 PM", "6:00 PM", "6:30 PM", "7:00 PM", "7:30 PM", "8:00 PM", "8:30 PM", "9:00 PM", "9:30 PM", "10:00 PM", "10:30 PM", "11:00 PM", "11:30 PM"})
        Me.cmbEndTime.Location = New System.Drawing.Point(290, 6)
        Me.cmbEndTime.Name = "cmbEndTime"
        Me.cmbEndTime.Size = New System.Drawing.Size(85, 23)
        Me.cmbEndTime.TabIndex = 3
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTo.Location = New System.Drawing.Point(272, 9)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(18, 15)
        Me.lblTo.TabIndex = 2
        Me.lblTo.Text = "to"
        '
        'cmbStartTime
        '
        Me.cmbStartTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStartTime.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbStartTime.FormattingEnabled = True
        Me.cmbStartTime.Items.AddRange(New Object() {"12:00 AM", "12:30 AM", "1:00 AM", "1:30 AM", "2:00 AM", "2:30 AM", "3:00 AM", "3:30 AM", "4:00 AM", "4:30 AM", "5:00 AM", "5:30 AM", "6:00 AM", "6:30 AM", "7:00 AM", "7:30 AM", "8:00 AM", "8:30 AM", "9:00 AM", "9:30 AM", "10:00 AM", "10:30 AM", "11:00 AM", "11:30 AM", "12:00 PM", "12:30 PM", "1:00 PM", "1:30 PM", "2:00 PM", "2:30 PM", "3:00 PM", "3:30 PM", "4:00 PM", "4:30 PM", "5:00 PM", "5:30 PM", "6:00 PM", "6:30 PM", "7:00 PM", "7:30 PM", "8:00 PM", "8:30 PM", "9:00 PM", "9:30 PM", "10:00 PM", "10:30 PM", "11:00 PM", "11:30 PM"})
        Me.cmbStartTime.Location = New System.Drawing.Point(180, 6)
        Me.cmbStartTime.Name = "cmbStartTime"
        Me.cmbStartTime.Size = New System.Drawing.Size(85, 23)
        Me.cmbStartTime.TabIndex = 1
        '
        'date1
        '
        Me.date1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.date1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.date1.Location = New System.Drawing.Point(5, 6)
        Me.date1.Name = "date1"
        Me.date1.Size = New System.Drawing.Size(165, 23)
        Me.date1.TabIndex = 0
        '
        'pnlCategory
        '
        Me.pnlCategory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCategory.BackColor = System.Drawing.Color.White
        Me.pnlCategory.Controls.Add(Me.s1)
        Me.pnlCategory.Controls.Add(Me.e1)
        Me.pnlCategory.Controls.Add(Me.lblCategory)
        Me.pnlCategory.Location = New System.Drawing.Point(20, 225)
        Me.pnlCategory.Name = "pnlCategory"
        Me.pnlCategory.Size = New System.Drawing.Size(460, 30)
        Me.pnlCategory.TabIndex = 3
        '
        's1
        '
        Me.s1.AutoSize = True
        Me.s1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.s1.Location = New System.Drawing.Point(213, 5)
        Me.s1.Name = "s1"
        Me.s1.Size = New System.Drawing.Size(97, 19)
        Me.s1.TabIndex = 2
        Me.s1.Text = "School Works"
        Me.s1.UseVisualStyleBackColor = True
        '
        'e1
        '
        Me.e1.AutoSize = True
        Me.e1.Checked = True
        Me.e1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.e1.Location = New System.Drawing.Point(151, 5)
        Me.e1.Name = "e1"
        Me.e1.Size = New System.Drawing.Size(54, 19)
        Me.e1.TabIndex = 1
        Me.e1.TabStop = True
        Me.e1.Text = "Event"
        Me.e1.UseVisualStyleBackColor = True
        '
        'lblCategory
        '
        Me.lblCategory.AutoSize = True
        Me.lblCategory.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCategory.Location = New System.Drawing.Point(5, 7)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(92, 15)
        Me.lblCategory.TabIndex = 0
        Me.lblCategory.Text = "Select Category:"
        '
        'comsecbox
        '
        Me.comsecbox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.comsecbox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comsecbox.Location = New System.Drawing.Point(20, 85)
        Me.comsecbox.Multiline = True
        Me.comsecbox.Name = "comsecbox"
        Me.comsecbox.Size = New System.Drawing.Size(460, 95)
        Me.comsecbox.TabIndex = 1
        Me.comsecbox.Text = "Add a description " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'todobox
        '
        Me.todobox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.todobox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.todobox.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.todobox.Location = New System.Drawing.Point(20, 25)
        Me.todobox.Name = "todobox"
        Me.todobox.Size = New System.Drawing.Size(460, 26)
        Me.todobox.TabIndex = 0
        Me.todobox.Text = "Add a title"
        '
        'Task
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(500, 500)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlMain)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Task"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.pnlAlarmSettings.ResumeLayout(False)
        Me.pnlAlarmSettings.PerformLayout()
        Me.pnlTimeSettings.ResumeLayout(False)
        Me.pnlTimeSettings.PerformLayout()
        Me.pnlCategory.ResumeLayout(False)
        Me.pnlCategory.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents pnlMain As Panel
    Friend WithEvents todobox As TextBox
    Friend WithEvents comsecbox As TextBox
    Friend WithEvents pnlTimeSettings As Panel
    Friend WithEvents date1 As DateTimePicker
    Friend WithEvents cmbStartTime As ComboBox
    Friend WithEvents lblTo As Label
    Friend WithEvents cmbEndTime As ComboBox
    Friend WithEvents chkAllDay As CheckBox
    Friend WithEvents pnlCategory As Panel
    Friend WithEvents lblCategory As Label
    Friend WithEvents e1 As RadioButton
    Friend WithEvents s1 As RadioButton
    Friend WithEvents chkAlarm As CheckBox
    Friend WithEvents pnlAlarmSettings As Panel
    Friend WithEvents timePicker As DateTimePicker
    Friend WithEvents lblCustomSound As Label
    Friend WithEvents btnBrowseSound As Button
    Friend WithEvents txtSoundFile As TextBox
End Class