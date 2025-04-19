<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class calendar
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
        Me.DaysRow5Container = New System.Windows.Forms.Panel()
        Me.DaysRow4Container = New System.Windows.Forms.Panel()
        Me.DaysRow3Container = New System.Windows.Forms.Panel()
        Me.DaysRow2Container = New System.Windows.Forms.Panel()
        Me.DaysRow1Container = New System.Windows.Forms.Panel()
        Me.DaysRow0Container = New System.Windows.Forms.Panel()
        Me.DaysOfWeekContainer = New System.Windows.Forms.Panel()
        Me.MonthYearContainer = New System.Windows.Forms.Panel()
        Me.lblCurrentMonth = New System.Windows.Forms.Label()
        Me.btnNextMonth = New System.Windows.Forms.Button()
        Me.btnPrevMonth = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditEventToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TasksPanel = New System.Windows.Forms.Panel()
        Me.AlarmTimer = New System.Windows.Forms.Timer(Me.components)
        Me.chkShowUpcoming = New System.Windows.Forms.CheckBox()
        Me.pnlCalendarControls = New System.Windows.Forms.Panel()
        Me.cmbCategoryFilter = New System.Windows.Forms.ComboBox()
        Me.lblCategoryFilter = New System.Windows.Forms.Label()
        Me.chkShowHolidays = New System.Windows.Forms.CheckBox()
        Me.statusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblUpcomingEvents = New System.Windows.Forms.Label()
        Me.pnlUpcomingEvents = New System.Windows.Forms.Panel()
        Me.MonthYearContainer.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.pnlCalendarControls.SuspendLayout()
        Me.statusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DaysRow5Container
        '
        Me.DaysRow5Container.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.DaysRow5Container.Location = New System.Drawing.Point(22, 391)
        Me.DaysRow5Container.Name = "DaysRow5Container"
        Me.DaysRow5Container.Size = New System.Drawing.Size(757, 50)
        Me.DaysRow5Container.TabIndex = 14
        '
        'DaysRow4Container
        '
        Me.DaysRow4Container.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(201, Byte), Integer))
        Me.DaysRow4Container.Location = New System.Drawing.Point(22, 334)
        Me.DaysRow4Container.Name = "DaysRow4Container"
        Me.DaysRow4Container.Size = New System.Drawing.Size(757, 50)
        Me.DaysRow4Container.TabIndex = 13
        '
        'DaysRow3Container
        '
        Me.DaysRow3Container.BackColor = System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.DaysRow3Container.Location = New System.Drawing.Point(21, 277)
        Me.DaysRow3Container.Name = "DaysRow3Container"
        Me.DaysRow3Container.Size = New System.Drawing.Size(757, 50)
        Me.DaysRow3Container.TabIndex = 12
        '
        'DaysRow2Container
        '
        Me.DaysRow2Container.BackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.DaysRow2Container.Location = New System.Drawing.Point(21, 220)
        Me.DaysRow2Container.Name = "DaysRow2Container"
        Me.DaysRow2Container.Size = New System.Drawing.Size(757, 50)
        Me.DaysRow2Container.TabIndex = 10
        '
        'DaysRow1Container
        '
        Me.DaysRow1Container.BackColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.DaysRow1Container.Location = New System.Drawing.Point(21, 163)
        Me.DaysRow1Container.Name = "DaysRow1Container"
        Me.DaysRow1Container.Size = New System.Drawing.Size(757, 50)
        Me.DaysRow1Container.TabIndex = 11
        '
        'DaysRow0Container
        '
        Me.DaysRow0Container.BackColor = System.Drawing.Color.FromArgb(CType(CType(104, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.DaysRow0Container.Location = New System.Drawing.Point(22, 106)
        Me.DaysRow0Container.Name = "DaysRow0Container"
        Me.DaysRow0Container.Size = New System.Drawing.Size(757, 50)
        Me.DaysRow0Container.TabIndex = 9
        '
        'DaysOfWeekContainer
        '
        Me.DaysOfWeekContainer.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DaysOfWeekContainer.Location = New System.Drawing.Point(22, 66)
        Me.DaysOfWeekContainer.Name = "DaysOfWeekContainer"
        Me.DaysOfWeekContainer.Size = New System.Drawing.Size(757, 30)
        Me.DaysOfWeekContainer.TabIndex = 8
        '
        'MonthYearContainer
        '
        Me.MonthYearContainer.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.MonthYearContainer.Controls.Add(Me.lblCurrentMonth)
        Me.MonthYearContainer.Controls.Add(Me.btnNextMonth)
        Me.MonthYearContainer.Controls.Add(Me.btnPrevMonth)
        Me.MonthYearContainer.Location = New System.Drawing.Point(21, 9)
        Me.MonthYearContainer.Name = "MonthYearContainer"
        Me.MonthYearContainer.Size = New System.Drawing.Size(757, 50)
        Me.MonthYearContainer.TabIndex = 7
        '
        'lblCurrentMonth
        '
        Me.lblCurrentMonth.AutoSize = True
        Me.lblCurrentMonth.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblCurrentMonth.Location = New System.Drawing.Point(307, 9)
        Me.lblCurrentMonth.Name = "lblCurrentMonth"
        Me.lblCurrentMonth.Size = New System.Drawing.Size(133, 32)
        Me.lblCurrentMonth.TabIndex = 2
        Me.lblCurrentMonth.Text = "April 2025"
        Me.lblCurrentMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnNextMonth
        '
        Me.btnNextMonth.FlatAppearance.BorderSize = 0
        Me.btnNextMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNextMonth.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold)
        Me.btnNextMonth.Location = New System.Drawing.Point(710, 9)
        Me.btnNextMonth.Name = "btnNextMonth"
        Me.btnNextMonth.Size = New System.Drawing.Size(40, 32)
        Me.btnNextMonth.TabIndex = 1
        Me.btnNextMonth.Text = ">"
        Me.btnNextMonth.UseVisualStyleBackColor = True
        '
        'btnPrevMonth
        '
        Me.btnPrevMonth.FlatAppearance.BorderSize = 0
        Me.btnPrevMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrevMonth.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold)
        Me.btnPrevMonth.Location = New System.Drawing.Point(9, 9)
        Me.btnPrevMonth.Name = "btnPrevMonth"
        Me.btnPrevMonth.Size = New System.Drawing.Size(40, 32)
        Me.btnPrevMonth.TabIndex = 0
        Me.btnPrevMonth.Text = "<"
        Me.btnPrevMonth.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditEventToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(127, 48)
        '
        'EditEventToolStripMenuItem
        '
        Me.EditEventToolStripMenuItem.Name = "EditEventToolStripMenuItem"
        Me.EditEventToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.EditEventToolStripMenuItem.Text = "Edit Event"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'TasksPanel
        '
        Me.TasksPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TasksPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TasksPanel.Location = New System.Drawing.Point(250, 75)
        Me.TasksPanel.Name = "TasksPanel"
        Me.TasksPanel.Size = New System.Drawing.Size(300, 300)
        Me.TasksPanel.TabIndex = 15
        Me.TasksPanel.Visible = False
        '
        'AlarmTimer
        '
        Me.AlarmTimer.Interval = 60000
        '
        'chkShowUpcoming
        '
        Me.chkShowUpcoming.AutoSize = True
        Me.chkShowUpcoming.Checked = True
        Me.chkShowUpcoming.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowUpcoming.Location = New System.Drawing.Point(15, 12)
        Me.chkShowUpcoming.Name = "chkShowUpcoming"
        Me.chkShowUpcoming.Size = New System.Drawing.Size(159, 17)
        Me.chkShowUpcoming.TabIndex = 16
        Me.chkShowUpcoming.Text = "Show only upcoming events"
        Me.chkShowUpcoming.UseVisualStyleBackColor = True
        '
        'pnlCalendarControls
        '
        Me.pnlCalendarControls.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlCalendarControls.Controls.Add(Me.cmbCategoryFilter)
        Me.pnlCalendarControls.Controls.Add(Me.lblCategoryFilter)
        Me.pnlCalendarControls.Controls.Add(Me.chkShowHolidays)
        Me.pnlCalendarControls.Controls.Add(Me.chkShowUpcoming)
        Me.pnlCalendarControls.Location = New System.Drawing.Point(795, 9)
        Me.pnlCalendarControls.Name = "pnlCalendarControls"
        Me.pnlCalendarControls.Size = New System.Drawing.Size(200, 100)
        Me.pnlCalendarControls.TabIndex = 18
        '
        'cmbCategoryFilter
        '
        Me.cmbCategoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCategoryFilter.FormattingEnabled = True
        Me.cmbCategoryFilter.Items.AddRange(New Object() {"All Categories", "Personal", "Deadline", "Holiday", "Meeting", "Other"})
        Me.cmbCategoryFilter.Location = New System.Drawing.Point(15, 71)
        Me.cmbCategoryFilter.Name = "cmbCategoryFilter"
        Me.cmbCategoryFilter.Size = New System.Drawing.Size(170, 21)
        Me.cmbCategoryFilter.TabIndex = 19
        '
        'lblCategoryFilter
        '
        Me.lblCategoryFilter.AutoSize = True
        Me.lblCategoryFilter.Location = New System.Drawing.Point(13, 55)
        Me.lblCategoryFilter.Name = "lblCategoryFilter"
        Me.lblCategoryFilter.Size = New System.Drawing.Size(87, 13)
        Me.lblCategoryFilter.TabIndex = 18
        Me.lblCategoryFilter.Text = "Filter by category"
        '
        'chkShowHolidays
        '
        Me.chkShowHolidays.AutoSize = True
        Me.chkShowHolidays.Checked = True
        Me.chkShowHolidays.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowHolidays.Location = New System.Drawing.Point(15, 35)
        Me.chkShowHolidays.Name = "chkShowHolidays"
        Me.chkShowHolidays.Size = New System.Drawing.Size(94, 17)
        Me.chkShowHolidays.TabIndex = 17
        Me.chkShowHolidays.Text = "Show holidays"
        Me.chkShowHolidays.UseVisualStyleBackColor = True
        '
        'statusStrip1
        '
        Me.statusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.statusStrip1.Location = New System.Drawing.Point(0, 452)
        Me.statusStrip1.Name = "statusStrip1"
        Me.statusStrip1.Size = New System.Drawing.Size(1000, 22)
        Me.statusStrip1.TabIndex = 19
        Me.statusStrip1.Text = "statusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(39, 17)
        Me.lblStatus.Text = "Ready"
        '
        'lblUpcomingEvents
        '
        Me.lblUpcomingEvents.AutoSize = True
        Me.lblUpcomingEvents.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpcomingEvents.Location = New System.Drawing.Point(795, 112)
        Me.lblUpcomingEvents.Name = "lblUpcomingEvents"
        Me.lblUpcomingEvents.Size = New System.Drawing.Size(119, 17)
        Me.lblUpcomingEvents.TabIndex = 20
        Me.lblUpcomingEvents.Text = "Upcoming Events:"
        '
        'pnlUpcomingEvents
        '
        Me.pnlUpcomingEvents.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlUpcomingEvents.AutoScroll = True
        Me.pnlUpcomingEvents.BackColor = System.Drawing.Color.White
        Me.pnlUpcomingEvents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlUpcomingEvents.Location = New System.Drawing.Point(795, 134)
        Me.pnlUpcomingEvents.Name = "pnlUpcomingEvents"
        Me.pnlUpcomingEvents.Size = New System.Drawing.Size(200, 307)
        Me.pnlUpcomingEvents.TabIndex = 21
        '
        'calendar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 474)
        Me.Controls.Add(Me.pnlUpcomingEvents)
        Me.Controls.Add(Me.lblUpcomingEvents)
        Me.Controls.Add(Me.statusStrip1)
        Me.Controls.Add(Me.pnlCalendarControls)
        Me.Controls.Add(Me.TasksPanel)
        Me.Controls.Add(Me.DaysRow5Container)
        Me.Controls.Add(Me.DaysRow4Container)
        Me.Controls.Add(Me.DaysRow3Container)
        Me.Controls.Add(Me.DaysRow2Container)
        Me.Controls.Add(Me.DaysRow1Container)
        Me.Controls.Add(Me.DaysRow0Container)
        Me.Controls.Add(Me.DaysOfWeekContainer)
        Me.Controls.Add(Me.MonthYearContainer)
        Me.Name = "calendar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Calendar Scheduler"
        Me.MonthYearContainer.ResumeLayout(False)
        Me.MonthYearContainer.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.pnlCalendarControls.ResumeLayout(False)
        Me.pnlCalendarControls.PerformLayout()
        Me.statusStrip1.ResumeLayout(False)
        Me.statusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DaysRow5Container As Panel
    Friend WithEvents DaysRow4Container As Panel
    Friend WithEvents DaysRow3Container As Panel
    Friend WithEvents DaysRow2Container As Panel
    Friend WithEvents DaysRow1Container As Panel
    Friend WithEvents DaysRow0Container As Panel
    Friend WithEvents DaysOfWeekContainer As Panel
    Friend WithEvents MonthYearContainer As Panel
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TasksPanel As Panel
    Friend WithEvents AlarmTimer As Timer
    Friend WithEvents chkShowUpcoming As CheckBox
    Friend WithEvents pnlCalendarControls As Panel
    Friend WithEvents cmbCategoryFilter As ComboBox
    Friend WithEvents lblCategoryFilter As Label
    Friend WithEvents chkShowHolidays As CheckBox
    Friend WithEvents statusStrip1 As StatusStrip
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents lblUpcomingEvents As Label
    Friend WithEvents pnlUpcomingEvents As Panel
    Friend WithEvents btnPrevMonth As Button
    Friend WithEvents btnNextMonth As Button
    Friend WithEvents lblCurrentMonth As Label
    Friend WithEvents EditEventToolStripMenuItem As ToolStripMenuItem
End Class