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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Home))
        Me.Panelmenu = New System.Windows.Forms.Panel()
        Me.lbluser = New System.Windows.Forms.Label()
        Me.viewbtn = New FontAwesome.Sharp.IconButton()
        Me.homebtn = New FontAwesome.Sharp.IconButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblFormTitle = New System.Windows.Forms.Label()
        Me.homecurrenticon = New FontAwesome.Sharp.IconPictureBox()
        Me.Paneldesktop = New System.Windows.Forms.Panel()
        Me.pnlWelcome = New System.Windows.Forms.Panel()
        Me.lblDateTime = New System.Windows.Forms.Label()
        Me.lblQuote = New System.Windows.Forms.Label()
        Me.lblQuoteAuthor = New System.Windows.Forms.Label()
        Me.pnlQuickTask = New System.Windows.Forms.Panel()
        Me.lblQuickTask = New System.Windows.Forms.Label()
        Me.lblTaskTitle = New System.Windows.Forms.Label()
        Me.txtTaskTitle = New System.Windows.Forms.TextBox()
        Me.lblTaskDate = New System.Windows.Forms.Label()
        Me.dtpTaskDate = New System.Windows.Forms.DateTimePicker()
        Me.lblTaskCategory = New System.Windows.Forms.Label()
        Me.cmbTaskCategory = New System.Windows.Forms.ComboBox()
        Me.btnAddTask = New System.Windows.Forms.Button()
        Me.pnlTodayAgenda = New System.Windows.Forms.Panel()
        Me.lblTodayAgenda = New System.Windows.Forms.Label()
        Me.lblTaskCount = New System.Windows.Forms.Label()
        Me.flpTaskList = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnViewAllTasks = New System.Windows.Forms.Button()
        Me.pnlUpcomingTask = New System.Windows.Forms.Panel()
        Me.lblNextTask = New System.Windows.Forms.Label()
        Me.lblUpcomingTaskTitle = New System.Windows.Forms.Label()
        Me.lblUpcomingTaskTime = New System.Windows.Forms.Label()
        Me.lblCountdown = New System.Windows.Forms.Label()
        Me.prgTaskProgress = New System.Windows.Forms.ProgressBar()
        Me.pnlStatistics = New System.Windows.Forms.Panel()
        Me.lblStatistics = New System.Windows.Forms.Label()
        Me.lblCompletionRate = New System.Windows.Forms.Label()
        Me.lblTasksThisWeek = New System.Windows.Forms.Label()
        Me.lblTasksCompleted = New System.Windows.Forms.Label()
        Me.timerClock = New System.Windows.Forms.Timer(Me.components)
        Me.Panelmenu.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.homecurrenticon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Paneldesktop.SuspendLayout()
        Me.pnlWelcome.SuspendLayout()
        Me.pnlQuickTask.SuspendLayout()
        Me.pnlTodayAgenda.SuspendLayout()
        Me.pnlUpcomingTask.SuspendLayout()
        Me.pnlStatistics.SuspendLayout()
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
        Me.Panelmenu.Size = New System.Drawing.Size(1191, 58)
        Me.Panelmenu.TabIndex = 0
        '
        'lbluser
        '
        Me.lbluser.AutoSize = True
        Me.lbluser.Font = New System.Drawing.Font("Microsoft YaHei", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbluser.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.lbluser.Location = New System.Drawing.Point(464, 8)
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
        Me.Panel2.Size = New System.Drawing.Size(158, 601)
        Me.Panel2.TabIndex = 1
        '
        'lblFormTitle
        '
        Me.lblFormTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.lblFormTitle.Location = New System.Drawing.Point(6, 142)
        Me.lblFormTitle.Name = "lblFormTitle"
        Me.lblFormTitle.Size = New System.Drawing.Size(146, 28)
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
        Me.homecurrenticon.IconSize = 158
        Me.homecurrenticon.Location = New System.Drawing.Point(0, 0)
        Me.homecurrenticon.Name = "homecurrenticon"
        Me.homecurrenticon.Size = New System.Drawing.Size(158, 158)
        Me.homecurrenticon.TabIndex = 0
        Me.homecurrenticon.TabStop = False
        '
        'Paneldesktop
        '
        Me.Paneldesktop.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Paneldesktop.Controls.Add(Me.pnlWelcome)
        Me.Paneldesktop.Controls.Add(Me.pnlQuickTask)
        Me.Paneldesktop.Controls.Add(Me.pnlTodayAgenda)
        Me.Paneldesktop.Controls.Add(Me.pnlUpcomingTask)
        Me.Paneldesktop.Controls.Add(Me.pnlStatistics)
        Me.Paneldesktop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Paneldesktop.Location = New System.Drawing.Point(158, 58)
        Me.Paneldesktop.Name = "Paneldesktop"
        Me.Paneldesktop.Size = New System.Drawing.Size(1033, 601)
        Me.Paneldesktop.TabIndex = 2
        '
        'pnlWelcome
        '
        Me.pnlWelcome.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlWelcome.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.pnlWelcome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlWelcome.Controls.Add(Me.lblDateTime)
        Me.pnlWelcome.Controls.Add(Me.lblQuote)
        Me.pnlWelcome.Controls.Add(Me.lblQuoteAuthor)
        Me.pnlWelcome.Location = New System.Drawing.Point(20, 20)
        Me.pnlWelcome.Name = "pnlWelcome"
        Me.pnlWelcome.Size = New System.Drawing.Size(993, 100)
        Me.pnlWelcome.TabIndex = 0
        '
        'lblDateTime
        '
        Me.lblDateTime.AutoSize = True
        Me.lblDateTime.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateTime.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.lblDateTime.Location = New System.Drawing.Point(15, 15)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.Size = New System.Drawing.Size(268, 25)
        Me.lblDateTime.TabIndex = 0
        Me.lblDateTime.Text = "Saturday, April 19, 2025 | 07:16"
        '
        'lblQuote
        '
        Me.lblQuote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblQuote.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuote.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.lblQuote.Location = New System.Drawing.Point(15, 50)
        Me.lblQuote.Name = "lblQuote"
        Me.lblQuote.Size = New System.Drawing.Size(719, 20)
        Me.lblQuote.TabIndex = 1
        Me.lblQuote.Text = "The key is not to prioritize what's on your schedule, but to schedule your priori" &
    "ties."
        '
        'lblQuoteAuthor
        '
        Me.lblQuoteAuthor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblQuoteAuthor.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuoteAuthor.ForeColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.lblQuoteAuthor.Location = New System.Drawing.Point(740, 53)
        Me.lblQuoteAuthor.Name = "lblQuoteAuthor"
        Me.lblQuoteAuthor.Size = New System.Drawing.Size(235, 17)
        Me.lblQuoteAuthor.TabIndex = 2
        Me.lblQuoteAuthor.Text = "- Stephen Covey"
        Me.lblQuoteAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlQuickTask
        '
        Me.pnlQuickTask.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlQuickTask.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.pnlQuickTask.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlQuickTask.Controls.Add(Me.lblQuickTask)
        Me.pnlQuickTask.Controls.Add(Me.lblTaskTitle)
        Me.pnlQuickTask.Controls.Add(Me.txtTaskTitle)
        Me.pnlQuickTask.Controls.Add(Me.lblTaskDate)
        Me.pnlQuickTask.Controls.Add(Me.dtpTaskDate)
        Me.pnlQuickTask.Controls.Add(Me.lblTaskCategory)
        Me.pnlQuickTask.Controls.Add(Me.cmbTaskCategory)
        Me.pnlQuickTask.Controls.Add(Me.btnAddTask)
        Me.pnlQuickTask.Location = New System.Drawing.Point(673, 130)
        Me.pnlQuickTask.Name = "pnlQuickTask"
        Me.pnlQuickTask.Size = New System.Drawing.Size(340, 220)
        Me.pnlQuickTask.TabIndex = 1
        '
        'lblQuickTask
        '
        Me.lblQuickTask.AutoSize = True
        Me.lblQuickTask.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuickTask.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.lblQuickTask.Location = New System.Drawing.Point(15, 15)
        Me.lblQuickTask.Name = "lblQuickTask"
        Me.lblQuickTask.Size = New System.Drawing.Size(148, 25)
        Me.lblQuickTask.TabIndex = 0
        Me.lblQuickTask.Text = "Quick Add Task"
        '
        'lblTaskTitle
        '
        Me.lblTaskTitle.AutoSize = True
        Me.lblTaskTitle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTaskTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.lblTaskTitle.Location = New System.Drawing.Point(15, 55)
        Me.lblTaskTitle.Name = "lblTaskTitle"
        Me.lblTaskTitle.Size = New System.Drawing.Size(32, 17)
        Me.lblTaskTitle.TabIndex = 1
        Me.lblTaskTitle.Text = "Title"
        '
        'txtTaskTitle
        '
        Me.txtTaskTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTaskTitle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTaskTitle.Location = New System.Drawing.Point(15, 75)
        Me.txtTaskTitle.Name = "txtTaskTitle"
        Me.txtTaskTitle.Size = New System.Drawing.Size(310, 25)
        Me.txtTaskTitle.TabIndex = 2
        Me.txtTaskTitle.Text = "Enter task title here..."
        '
        'lblTaskDate
        '
        Me.lblTaskDate.AutoSize = True
        Me.lblTaskDate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTaskDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.lblTaskDate.Location = New System.Drawing.Point(15, 110)
        Me.lblTaskDate.Name = "lblTaskDate"
        Me.lblTaskDate.Size = New System.Drawing.Size(35, 17)
        Me.lblTaskDate.TabIndex = 3
        Me.lblTaskDate.Text = "Date"
        '
        'dtpTaskDate
        '
        Me.dtpTaskDate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTaskDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTaskDate.Location = New System.Drawing.Point(15, 130)
        Me.dtpTaskDate.Name = "dtpTaskDate"
        Me.dtpTaskDate.Size = New System.Drawing.Size(150, 25)
        Me.dtpTaskDate.TabIndex = 4
        '
        'lblTaskCategory
        '
        Me.lblTaskCategory.AutoSize = True
        Me.lblTaskCategory.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTaskCategory.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.lblTaskCategory.Location = New System.Drawing.Point(175, 110)
        Me.lblTaskCategory.Name = "lblTaskCategory"
        Me.lblTaskCategory.Size = New System.Drawing.Size(61, 17)
        Me.lblTaskCategory.TabIndex = 5
        Me.lblTaskCategory.Text = "Category"
        '
        'cmbTaskCategory
        '
        Me.cmbTaskCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTaskCategory.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTaskCategory.FormattingEnabled = True
        Me.cmbTaskCategory.Items.AddRange(New Object() {"Event", "School Works"})
        Me.cmbTaskCategory.Location = New System.Drawing.Point(175, 130)
        Me.cmbTaskCategory.Name = "cmbTaskCategory"
        Me.cmbTaskCategory.Size = New System.Drawing.Size(150, 25)
        Me.cmbTaskCategory.TabIndex = 6
        '
        'btnAddTask
        '
        Me.btnAddTask.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddTask.BackColor = System.Drawing.Color.FromArgb(CType(CType(76, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.btnAddTask.FlatAppearance.BorderSize = 0
        Me.btnAddTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddTask.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddTask.ForeColor = System.Drawing.Color.White
        Me.btnAddTask.Location = New System.Drawing.Point(15, 170)
        Me.btnAddTask.Name = "btnAddTask"
        Me.btnAddTask.Size = New System.Drawing.Size(310, 35)
        Me.btnAddTask.TabIndex = 7
        Me.btnAddTask.Text = "Add Task"
        Me.btnAddTask.UseVisualStyleBackColor = False
        '
        'pnlTodayAgenda
        '
        Me.pnlTodayAgenda.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.pnlTodayAgenda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTodayAgenda.Controls.Add(Me.lblTodayAgenda)
        Me.pnlTodayAgenda.Controls.Add(Me.lblTaskCount)
        Me.pnlTodayAgenda.Controls.Add(Me.flpTaskList)
        Me.pnlTodayAgenda.Controls.Add(Me.btnViewAllTasks)
        Me.pnlTodayAgenda.Location = New System.Drawing.Point(20, 130)
        Me.pnlTodayAgenda.Name = "pnlTodayAgenda"
        Me.pnlTodayAgenda.Size = New System.Drawing.Size(640, 290)
        Me.pnlTodayAgenda.TabIndex = 2
        '
        'lblTodayAgenda
        '
        Me.lblTodayAgenda.AutoSize = True
        Me.lblTodayAgenda.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTodayAgenda.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.lblTodayAgenda.Location = New System.Drawing.Point(15, 15)
        Me.lblTodayAgenda.Name = "lblTodayAgenda"
        Me.lblTodayAgenda.Size = New System.Drawing.Size(152, 25)
        Me.lblTodayAgenda.TabIndex = 0
        Me.lblTodayAgenda.Text = "Today's Agenda"
        '
        'lblTaskCount
        '
        Me.lblTaskCount.AutoSize = True
        Me.lblTaskCount.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTaskCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.lblTaskCount.Location = New System.Drawing.Point(170, 18)
        Me.lblTaskCount.Name = "lblTaskCount"
        Me.lblTaskCount.Size = New System.Drawing.Size(128, 20)
        Me.lblTaskCount.TabIndex = 1
        Me.lblTaskCount.Text = "(3 tasks for today)"
        '
        'flpTaskList
        '
        Me.flpTaskList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpTaskList.AutoScroll = True
        Me.flpTaskList.BackColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.flpTaskList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.flpTaskList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flpTaskList.Location = New System.Drawing.Point(15, 50)
        Me.flpTaskList.Name = "flpTaskList"
        Me.flpTaskList.Size = New System.Drawing.Size(608, 190)
        Me.flpTaskList.TabIndex = 2
        Me.flpTaskList.WrapContents = False
        '
        'btnViewAllTasks
        '
        Me.btnViewAllTasks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnViewAllTasks.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(86, Byte), Integer))
        Me.btnViewAllTasks.FlatAppearance.BorderSize = 0
        Me.btnViewAllTasks.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewAllTasks.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewAllTasks.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.btnViewAllTasks.Location = New System.Drawing.Point(255, 250)
        Me.btnViewAllTasks.Name = "btnViewAllTasks"
        Me.btnViewAllTasks.Size = New System.Drawing.Size(120, 30)
        Me.btnViewAllTasks.TabIndex = 3
        Me.btnViewAllTasks.Text = "View Calendar"
        Me.btnViewAllTasks.UseVisualStyleBackColor = False
        '
        'pnlUpcomingTask
        '
        Me.pnlUpcomingTask.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlUpcomingTask.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.pnlUpcomingTask.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlUpcomingTask.Controls.Add(Me.lblNextTask)
        Me.pnlUpcomingTask.Controls.Add(Me.lblUpcomingTaskTitle)
        Me.pnlUpcomingTask.Controls.Add(Me.lblUpcomingTaskTime)
        Me.pnlUpcomingTask.Controls.Add(Me.lblCountdown)
        Me.pnlUpcomingTask.Controls.Add(Me.prgTaskProgress)
        Me.pnlUpcomingTask.Location = New System.Drawing.Point(674, 360)
        Me.pnlUpcomingTask.Name = "pnlUpcomingTask"
        Me.pnlUpcomingTask.Size = New System.Drawing.Size(339, 120)
        Me.pnlUpcomingTask.TabIndex = 3
        '
        'lblNextTask
        '
        Me.lblNextTask.AutoSize = True
        Me.lblNextTask.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNextTask.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.lblNextTask.Location = New System.Drawing.Point(15, 15)
        Me.lblNextTask.Name = "lblNextTask"
        Me.lblNextTask.Size = New System.Drawing.Size(94, 21)
        Me.lblNextTask.TabIndex = 0
        Me.lblNextTask.Text = "Next Event"
        '
        'lblUpcomingTaskTitle
        '
        Me.lblUpcomingTaskTitle.AutoSize = True
        Me.lblUpcomingTaskTitle.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpcomingTaskTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.lblUpcomingTaskTitle.Location = New System.Drawing.Point(15, 45)
        Me.lblUpcomingTaskTitle.Name = "lblUpcomingTaskTitle"
        Me.lblUpcomingTaskTitle.Size = New System.Drawing.Size(117, 20)
        Me.lblUpcomingTaskTitle.TabIndex = 1
        Me.lblUpcomingTaskTitle.Text = "Meeting with A"
        '
        'lblUpcomingTaskTime
        '
        Me.lblUpcomingTaskTime.AutoSize = True
        Me.lblUpcomingTaskTime.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUpcomingTaskTime.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.lblUpcomingTaskTime.Location = New System.Drawing.Point(15, 68)
        Me.lblUpcomingTaskTime.Name = "lblUpcomingTaskTime"
        Me.lblUpcomingTaskTime.Size = New System.Drawing.Size(137, 17)
        Me.lblUpcomingTaskTime.TabIndex = 2
        Me.lblUpcomingTaskTime.Text = "Today at 08:30 - 09:30"
        '
        'lblCountdown
        '
        Me.lblCountdown.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCountdown.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountdown.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.lblCountdown.Location = New System.Drawing.Point(189, 45)
        Me.lblCountdown.Name = "lblCountdown"
        Me.lblCountdown.Size = New System.Drawing.Size(135, 20)
        Me.lblCountdown.TabIndex = 3
        Me.lblCountdown.Text = "In 1h 14m"
        Me.lblCountdown.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'prgTaskProgress
        '
        Me.prgTaskProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prgTaskProgress.Location = New System.Drawing.Point(15, 95)
        Me.prgTaskProgress.Name = "prgTaskProgress"
        Me.prgTaskProgress.Size = New System.Drawing.Size(309, 10)
        Me.prgTaskProgress.TabIndex = 4
        Me.prgTaskProgress.Value = 45
        '
        'pnlStatistics
        '
        Me.pnlStatistics.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlStatistics.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(67, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.pnlStatistics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlStatistics.Controls.Add(Me.lblStatistics)
        Me.pnlStatistics.Controls.Add(Me.lblCompletionRate)
        Me.pnlStatistics.Controls.Add(Me.lblTasksThisWeek)
        Me.pnlStatistics.Controls.Add(Me.lblTasksCompleted)
        Me.pnlStatistics.Location = New System.Drawing.Point(20, 426)
        Me.pnlStatistics.Name = "pnlStatistics"
        Me.pnlStatistics.Size = New System.Drawing.Size(993, 100)
        Me.pnlStatistics.TabIndex = 4
        '
        'lblStatistics
        '
        Me.lblStatistics.AutoSize = True
        Me.lblStatistics.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatistics.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.lblStatistics.Location = New System.Drawing.Point(15, 15)
        Me.lblStatistics.Name = "lblStatistics"
        Me.lblStatistics.Size = New System.Drawing.Size(89, 25)
        Me.lblStatistics.TabIndex = 0
        Me.lblStatistics.Text = "Statistics"
        '
        'lblCompletionRate
        '
        Me.lblCompletionRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCompletionRate.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompletionRate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.lblCompletionRate.Location = New System.Drawing.Point(734, 60)
        Me.lblCompletionRate.Name = "lblCompletionRate"
        Me.lblCompletionRate.Size = New System.Drawing.Size(244, 20)
        Me.lblCompletionRate.TabIndex = 3
        Me.lblCompletionRate.Text = "85% completion rate this week"
        Me.lblCompletionRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTasksThisWeek
        '
        Me.lblTasksThisWeek.AutoSize = True
        Me.lblTasksThisWeek.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTasksThisWeek.ForeColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.lblTasksThisWeek.Location = New System.Drawing.Point(15, 60)
        Me.lblTasksThisWeek.Name = "lblTasksThisWeek"
        Me.lblTasksThisWeek.Size = New System.Drawing.Size(184, 20)
        Me.lblTasksThisWeek.TabIndex = 1
        Me.lblTasksThisWeek.Text = "12 tasks planned this week"
        '
        'lblTasksCompleted
        '
        Me.lblTasksCompleted.AutoSize = True
        Me.lblTasksCompleted.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTasksCompleted.ForeColor = System.Drawing.Color.FromArgb(CType(CType(172, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.lblTasksCompleted.Location = New System.Drawing.Point(202, 60)
        Me.lblTasksCompleted.Name = "lblTasksCompleted"
        Me.lblTasksCompleted.Size = New System.Drawing.Size(147, 20)
        Me.lblTasksCompleted.TabIndex = 2
        Me.lblTasksCompleted.Text = "(8 already complete)"
        '
        'timerClock
        '
        Me.timerClock.Enabled = True
        Me.timerClock.Interval = 1000
        '
        'Home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1191, 659)
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
        Me.pnlWelcome.ResumeLayout(False)
        Me.pnlWelcome.PerformLayout()
        Me.pnlQuickTask.ResumeLayout(False)
        Me.pnlQuickTask.PerformLayout()
        Me.pnlTodayAgenda.ResumeLayout(False)
        Me.pnlTodayAgenda.PerformLayout()
        Me.pnlUpcomingTask.ResumeLayout(False)
        Me.pnlUpcomingTask.PerformLayout()
        Me.pnlStatistics.ResumeLayout(False)
        Me.pnlStatistics.PerformLayout()
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

    ' New components
    Friend WithEvents pnlWelcome As Panel
    Friend WithEvents lblDateTime As Label
    Friend WithEvents lblQuote As Label
    Friend WithEvents lblQuoteAuthor As Label
    Friend WithEvents timerClock As Timer

    Friend WithEvents pnlQuickTask As Panel
    Friend WithEvents lblQuickTask As Label
    Friend WithEvents txtTaskTitle As TextBox
    Friend WithEvents dtpTaskDate As DateTimePicker
    Friend WithEvents cmbTaskCategory As ComboBox
    Friend WithEvents btnAddTask As Button
    Friend WithEvents lblTaskTitle As Label
    Friend WithEvents lblTaskDate As Label
    Friend WithEvents lblTaskCategory As Label

    Friend WithEvents pnlTodayAgenda As Panel
    Friend WithEvents lblTodayAgenda As Label
    Friend WithEvents lblTaskCount As Label
    Friend WithEvents flpTaskList As FlowLayoutPanel
    Friend WithEvents btnViewAllTasks As Button

    Friend WithEvents pnlUpcomingTask As Panel
    Friend WithEvents lblNextTask As Label
    Friend WithEvents lblUpcomingTaskTitle As Label
    Friend WithEvents lblUpcomingTaskTime As Label
    Friend WithEvents lblCountdown As Label
    Friend WithEvents prgTaskProgress As ProgressBar

    Friend WithEvents pnlStatistics As Panel
    Friend WithEvents lblStatistics As Label
    Friend WithEvents lblCompletionRate As Label
    Friend WithEvents lblTasksThisWeek As Label
    Friend WithEvents lblTasksCompleted As Label
End Class