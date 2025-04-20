Imports FontAwesome.Sharp
Imports Microsoft.VisualBasic.ApplicationServices
Imports System.Data.SQLite

Public Class Home
    Private userId As Integer

#Region "UI Design"
    ' Constructor accepting user ID
    Public Sub New(userId As Integer)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.userId = userId
        topBorderBtn = New Panel()
        topBorderBtn.Size = New Size(7, 60)
        Panelmenu.Controls.Add(topBorderBtn)
    End Sub

    Private Sub Home0_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        topBorderBtn = New Panel()
        topBorderBtn.Size = New Size(7, 60)
        Panelmenu.Controls.Add(topBorderBtn)

        Dim username As String = GetUsername()
        SetUsername(username)
        Me.AutoScroll = True
    End Sub


    Public Sub SetUsername(user As String)
        username = user
        If String.IsNullOrEmpty(username) Then
            lbluser.Text = "Welcome User!"
        Else
            lbluser.Text = $"Welcome Back {username}!"
        End If
    End Sub

    Private Function GetUsername() As String
        Dim username As String = String.Empty
        Dim conn As New SQLiteConnection("Data Source=D:\Scheduler_Tool\bin\Debug\Appdatabase.db;Version=3;")
        Try
            conn.Open()
            Dim cmd As New SQLiteCommand("SELECT Username FROM Userdatabase WHERE ID = @id", conn)
            cmd.Parameters.AddWithValue("@id", userId)
            Dim reader As SQLiteDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                username = reader("Username").ToString()
            End If
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error retrieving username: " & ex.Message)
        Finally
            conn.Close()
        End Try
        Return username
    End Function

    'Fields
    Private currentBtn As IconButton
    Private topBorderBtn As Panel
    Private currentChildForm As Form

    'Methods
    Private Sub ActivateButton(senderBtn As Object, customcolor As Color)
        DisableButton()
        If senderBtn IsNot Nothing Then
            'Button
            currentBtn = CType(senderBtn, IconButton)
            currentBtn.BackColor = Color.FromArgb(54, 57, 66)
            currentBtn.ForeColor = customcolor
            currentBtn.TextAlign = ContentAlignment.MiddleRight
            currentBtn.IconColor = customcolor
            currentBtn.ImageAlign = ContentAlignment.MiddleCenter
            currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage
            'top border button
            topBorderBtn.BackColor = customcolor
            topBorderBtn.BackColor = Color.FromArgb(54, 57, 66)
            topBorderBtn.Location = New Point(0, currentBtn.Location.Y)
            topBorderBtn.Visible = True
            topBorderBtn.BringToFront()
            'current form icon
            homecurrenticon.IconChar = currentBtn.IconChar
            homecurrenticon.IconColor = customcolor
        End If
    End Sub

    Private Sub OpenChildForm(childForm As Form)
        'Open Only Form 
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
        End If
        currentChildForm = childForm
        'end
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        Paneldesktop.Controls.Add(childForm)
        Paneldesktop.Tag = childForm
        childForm.BringToFront()
        childForm.Show()
        lblFormTitle.Text = childForm.Text
    End Sub

    Private Sub DisableButton()
        If currentBtn IsNot Nothing Then
            currentBtn.BackColor = Color.FromArgb(43, 46, 53)
            currentBtn.ForeColor = Color.FromArgb(226, 234, 247)
            currentBtn.IconColor = Color.FromArgb(226, 234, 247)
            currentBtn.TextAlign = ContentAlignment.MiddleCenter
            currentBtn.ImageAlign = ContentAlignment.MiddleRight
            currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        End If
    End Sub
#End Region

#Region "Database Connection"
    Private username As String

    ' Date/Time updates
    Private Sub timerClock_Tick(sender As Object, e As EventArgs) Handles timerClock.Tick
        lblDateTime.Text = DateTime.Now.ToString("dddd, MMMM d, yyyy | HH:mm")
        UpdateCountdown()
    End Sub

    ' Task management
    Private Sub LoadTodaysTasks()
        flpTaskList.Controls.Clear()

        Try
            Using connection As SQLiteConnection = DbConnection.GetSQLiteConnection()
                ' Query for today's tasks
                Dim command As New SQLiteCommand(
                "SELECT * FROM Task WHERE Date = @today ORDER BY alarm_time",
                connection)

                command.Parameters.AddWithValue("@today", DateTime.Now.ToString("yyyy-MM-dd"))

                Dim taskCount As Integer = 0

                Using reader As SQLiteDataReader = command.ExecuteReader()
                    While reader.Read()
                        taskCount += 1

                        ' Create task item panel
                        Dim taskPanel As New Panel()
                        taskPanel.Size = New Size(580, 50)
                        taskPanel.BackColor = Color.FromArgb(74, 77, 86)
                        taskPanel.Margin = New Padding(3, 3, 3, 3)

                        ' Task title
                        Dim lblTitle As New Label()
                        lblTitle.Text = reader("todoname").ToString()
                        lblTitle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
                        lblTitle.ForeColor = Color.FromArgb(219, 209, 236)
                        lblTitle.Location = New Point(10, 5)
                        lblTitle.AutoSize = True
                        taskPanel.Controls.Add(lblTitle)

                        ' Task category
                        Dim lblCategory As New Label()
                        lblCategory.Text = reader("category").ToString()
                        lblCategory.Font = New Font("Segoe UI", 8, FontStyle.Regular)
                        lblCategory.ForeColor = Color.FromArgb(190, 190, 190)
                        lblCategory.Location = New Point(10, 28)
                        lblCategory.AutoSize = True
                        taskPanel.Controls.Add(lblCategory)

                        ' Add buttons
                        Dim btnEdit As New Button()
                        btnEdit.Text = "Edit"
                        btnEdit.Size = New Size(50, 25)
                        btnEdit.Location = New Point(430, 12)
                        btnEdit.FlatStyle = FlatStyle.Flat
                        btnEdit.BackColor = Color.FromArgb(80, 100, 120)
                        btnEdit.ForeColor = Color.White
                        btnEdit.Tag = reader("todoname").ToString()
                        AddHandler btnEdit.Click, AddressOf EditTaskFromHome
                        taskPanel.Controls.Add(btnEdit)

                        Dim btnComplete As New Button()
                        btnComplete.Text = "✓"
                        btnComplete.Size = New Size(25, 25)
                        btnComplete.Location = New Point(485, 12)
                        btnComplete.FlatStyle = FlatStyle.Flat
                        btnComplete.BackColor = Color.FromArgb(76, 175, 80)
                        btnComplete.ForeColor = Color.White
                        btnComplete.Tag = reader("todoname").ToString()
                        AddHandler btnComplete.Click, AddressOf CompleteTask
                        taskPanel.Controls.Add(btnComplete)

                        ' Time info if alarm is set
                        If Not IsDBNull(reader("has_alarm")) AndAlso Convert.ToBoolean(reader("has_alarm")) Then
                            If Not IsDBNull(reader("alarm_time")) Then
                                Dim alarmTime As DateTime
                                If DateTime.TryParse(reader("alarm_time").ToString(), alarmTime) Then
                                    Dim lblTime As New Label()
                                    lblTime.Text = alarmTime.ToString("HH:mm")
                                    lblTime.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                                    lblTime.ForeColor = Color.FromArgb(172, 190, 238)
                                    lblTime.Location = New Point(350, 15)
                                    lblTime.AutoSize = True
                                    taskPanel.Controls.Add(lblTime)
                                End If
                            End If
                        End If

                        ' Add to flow layout
                        flpTaskList.Controls.Add(taskPanel)
                    End While
                End Using

                ' Update task count
                lblTaskCount.Text = $"({taskCount} tasks for today)"

                ' Show message if no tasks
                If taskCount = 0 Then
                    Dim noTasksLabel As New Label()
                    noTasksLabel.Text = "No tasks scheduled for today."
                    noTasksLabel.Font = New Font("Segoe UI", 12, FontStyle.Italic)
                    noTasksLabel.ForeColor = Color.FromArgb(200, 200, 200)
                    noTasksLabel.AutoSize = True
                    noTasksLabel.Location = New Point(15, 15)

                    Dim emptyPanel As New Panel()
                    emptyPanel.Size = New Size(580, 50)
                    emptyPanel.Controls.Add(noTasksLabel)
                    flpTaskList.Controls.Add(emptyPanel)
                End If
            End Using
        Catch ex As Exception
            ' Show error
            Dim errorLabel As New Label()
            errorLabel.Text = "Error loading tasks: " & ex.Message
            errorLabel.Font = New Font("Segoe UI", 9, FontStyle.Italic)
            errorLabel.ForeColor = Color.FromArgb(255, 100, 100)
            errorLabel.AutoSize = True

            Dim errorPanel As New Panel()
            errorPanel.Size = New Size(580, 50)
            errorPanel.Controls.Add(errorLabel)
            flpTaskList.Controls.Add(errorPanel)
        End Try
    End Sub

    ' Find the next upcoming event
    Private Sub LoadUpcomingTask()
        Try
            Using connection As SQLiteConnection = DbConnection.GetSQLiteConnection()
                Dim command As New SQLiteCommand(
                "SELECT * FROM Task 
                 WHERE Date >= @today AND has_alarm = 1 
                 ORDER BY alarm_time ASC LIMIT 1",
                connection)

                command.Parameters.AddWithValue("@today", DateTime.Now.ToString("yyyy-MM-dd"))

                Using reader As SQLiteDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        lblUpcomingTaskTitle.Text = reader("todoname").ToString()

                        Dim taskDate As DateTime = DateTime.Parse(reader("Date").ToString())
                        Dim dayStr As String = If(taskDate.Date = DateTime.Today, "Today",
                                          If(taskDate.Date = DateTime.Today.AddDays(1), "Tomorrow",
                                             taskDate.ToString("MMM d")))

                        Dim alarmTime As DateTime
                        If Not IsDBNull(reader("alarm_time")) AndAlso DateTime.TryParse(reader("alarm_time").ToString(), alarmTime) Then
                            lblUpcomingTaskTime.Text = $"{dayStr} at {alarmTime.ToString("HH:mm")}"

                            ' Calculate progress
                            Dim timeSpan = alarmTime - DateTime.Now
                            If timeSpan.TotalMinutes > 0 AndAlso timeSpan.TotalHours < 24 Then
                                lblCountdown.Text = $"In {timeSpan.Hours}h {timeSpan.Minutes}m"

                                ' Progress calculation 
                                Dim progressPercentage As Integer = Math.Max(0, 100 - CInt((timeSpan.TotalHours / 24) * 100))
                                prgTaskProgress.Value = progressPercentage
                            Else
                                lblCountdown.Text = If(timeSpan.TotalMinutes <= 0, "Now!", dayStr)
                                prgTaskProgress.Value = If(timeSpan.TotalMinutes <= 0, 100, 0)
                            End If
                        End If
                    Else
                        ' No upcoming task
                        lblUpcomingTaskTitle.Text = "No upcoming tasks"
                        lblUpcomingTaskTime.Text = "Add a task to get started"
                        lblCountdown.Text = ""
                        prgTaskProgress.Value = 0
                    End If
                End Using
            End Using
        Catch ex As Exception
            lblUpcomingTaskTitle.Text = "Error loading upcoming task"
            lblUpcomingTaskTime.Text = ex.Message
            lblCountdown.Text = ""
        End Try
    End Sub

    Private Sub UpdateCountdown()
        ' Update the countdown timer for upcoming task
        If lblUpcomingTaskTitle.Text <> "No upcoming tasks" Then
            LoadUpcomingTask()
        End If
    End Sub

    Private Sub LoadStatistics()
        Try
            Using connection As SQLiteConnection = DbConnection.GetSQLiteConnection()
                ' Count all tasks for this week
                Dim startOfWeek = DateTime.Today.AddDays(-(CInt(DateTime.Today.DayOfWeek)))
                Dim endOfWeek = startOfWeek.AddDays(6)

                Dim countCmd As New SQLiteCommand(
                "SELECT COUNT(*) FROM Task 
                 WHERE Date BETWEEN @start AND @end",
                connection)
                countCmd.Parameters.AddWithValue("@start", startOfWeek.ToString("yyyy-MM-dd"))
                countCmd.Parameters.AddWithValue("@end", endOfWeek.ToString("yyyy-MM-dd"))

                Dim totalTasks As Integer = Convert.ToInt32(countCmd.ExecuteScalar())

                ' Count completed tasks
                Dim completedCmd As New SQLiteCommand(
                "SELECT COUNT(*) FROM Task 
                 WHERE Date BETWEEN @start AND @end AND completed = 1",
                connection)
                completedCmd.Parameters.AddWithValue("@start", startOfWeek.ToString("yyyy-MM-dd"))
                completedCmd.Parameters.AddWithValue("@end", endOfWeek.ToString("yyyy-MM-dd"))

                ' For demonstration, using a hardcoded value:
                Dim completedTasks As Integer = 8

                ' Update labels
                lblTasksThisWeek.Text = $"{totalTasks} tasks planned this week"
                lblTasksCompleted.Text = $"({completedTasks} already complete)"

                ' Calculate completion rate
                If totalTasks > 0 Then
                    Dim rate As Integer = CInt((completedTasks / totalTasks) * 100)
                    lblCompletionRate.Text = $"{rate}% completion rate this week"
                Else
                    lblCompletionRate.Text = "No tasks this week"
                End If
            End Using
        Catch ex As Exception
            lblTasksThisWeek.Text = "Statistics unavailable"
            lblCompletionRate.Text = ""
        End Try
    End Sub

    ' Quick task creation
    Private Sub btnAddTask_Click(sender As Object, e As EventArgs) Handles btnAddTask.Click
        If String.IsNullOrWhiteSpace(txtTaskTitle.Text) OrElse txtTaskTitle.Text = "Enter task title here..." Then
            MessageBox.Show("Please enter a task title", "Missing title", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If cmbTaskCategory.SelectedIndex = -1 Then
            cmbTaskCategory.SelectedIndex = 0 ' Default to first option
        End If

        Try
            ' Make sure schema is updated before saving
            DbConnection.UpdateDatabaseSchema()

            Using connection As SQLiteConnection = DbConnection.GetSQLiteConnection()
                Dim command As New SQLiteCommand(
                "INSERT INTO Task 
                 (todoname, Comment, Date, category, has_alarm, alarm_time, alarm_sound) 
                 VALUES 
                 (@todoname, @comment, @date, @category, @hasAlarm, @alarmTime, @alarmSound)",
                 connection)

                command.Parameters.AddWithValue("@todoname", txtTaskTitle.Text)
                command.Parameters.AddWithValue("@comment", "")
                command.Parameters.AddWithValue("@date", dtpTaskDate.Value.ToString("yyyy-MM-dd"))
                command.Parameters.AddWithValue("@category", cmbTaskCategory.Text)
                command.Parameters.AddWithValue("@hasAlarm", False)
                command.Parameters.AddWithValue("@alarmTime", DBNull.Value)
                command.Parameters.AddWithValue("@alarmSound", "default.wav")

                command.ExecuteNonQuery()

                MessageBox.Show("Task added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' Clear fields
                txtTaskTitle.Text = "Enter task title here..."
                dtpTaskDate.Value = DateTime.Today.AddDays(1)

                ' Refresh the task list
                LoadTodaysTasks()
                LoadUpcomingTask()
                LoadStatistics()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error adding task: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "Placeholder Text"
    ' Event handlers for placeholder text
    Private Sub txtTaskTitle_Enter(sender As Object, e As EventArgs) Handles txtTaskTitle.Enter
        If txtTaskTitle.Text = "Enter task title here..." Then
            txtTaskTitle.Text = ""
        End If
    End Sub

    Private Sub txtTaskTitle_Leave(sender As Object, e As EventArgs) Handles txtTaskTitle.Leave
        If String.IsNullOrWhiteSpace(txtTaskTitle.Text) Then
            txtTaskTitle.Text = "Enter task title here..."
        End If
    End Sub

    ' Edit task from home page
    Private Sub EditTaskFromHome(sender As Object, e As EventArgs)
        Dim btn = DirectCast(sender, Button)
        Dim taskName As String = btn.Tag.ToString()
        Dim taskForm As New Task(DateTime.Today, taskName)
        taskForm.ShowDialog()

        If taskForm.DataSaved Then
            LoadTodaysTasks()
            LoadUpcomingTask()
            LoadStatistics()
        End If
    End Sub

    ' Complete a task
    Private Sub CompleteTask(sender As Object, e As EventArgs)
        Dim btn = DirectCast(sender, Button)
        Dim taskName As String = btn.Tag.ToString()

        ' Ask for confirmation
        Dim result = MessageBox.Show("Mark task as completed?", "Complete Task",
                                 MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Using connection As SQLiteConnection = DbConnection.GetSQLiteConnection()
                    ' Currently just deleting the task, but you could update a 'completed' field if you add that column
                    Dim command As New SQLiteCommand(
                    "DELETE FROM Task WHERE todoname = @name AND Date = @date", connection)

                    command.Parameters.AddWithValue("@name", taskName)
                    command.Parameters.AddWithValue("@date", DateTime.Today.ToString("yyyy-MM-dd"))

                    command.ExecuteNonQuery()

                    ' Refresh the displays
                    LoadTodaysTasks()
                    LoadUpcomingTask()
                    LoadStatistics()
                End Using
            Catch ex As Exception
                MessageBox.Show("Error completing task: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' Home page initialization
    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Your existing code here...

        ' Initialize components
        lblDateTime.Text = DateTime.Now.ToString("dddd, MMMM d, yyyy | HH:mm")

        ' Set quotes
        Dim quotes As New List(Of Tuple(Of String, String))()
        quotes.Add(New Tuple(Of String, String)("The key is not to prioritize what's on your schedule, but to schedule your priorities.", "Stephen Covey"))
        quotes.Add(New Tuple(Of String, String)("Time management is about life management.", "Idowu Koyenikan"))
        quotes.Add(New Tuple(Of String, String)("The bad news is time flies. The good news is you're the pilot.", "Michael Altshuler"))
        quotes.Add(New Tuple(Of String, String)("A goal without a plan is just a wish.", "Antoine de Saint-Exupéry"))
        quotes.Add(New Tuple(Of String, String)("You'll never find time for anything. If you want time, you must make it.", "Charles Buxton"))

        ' Select random quote
        Dim random As New Random()
        Dim quoteIndex As Integer = random.Next(0, quotes.Count)
        lblQuote.Text = quotes(quoteIndex).Item1
        lblQuoteAuthor.Text = "- " & quotes(quoteIndex).Item2

        ' Setup Quick Task form
        dtpTaskDate.Value = DateTime.Today.AddDays(1)
        txtTaskTitle.Text = "Enter task title here..."
        cmbTaskCategory.SelectedIndex = 0

        ' Load data
        LoadTodaysTasks()
        LoadUpcomingTask()
        LoadStatistics()

        ' Start the clock timer
        timerClock.Start()
    End Sub

    ' Calendar view button
    Private Sub btnViewAllTasks_Click(sender As Object, e As EventArgs) Handles btnViewAllTasks.Click
        ' Same as clicking the Calendar View button
        viewbtn_Click(viewbtn, EventArgs.Empty)
    End Sub

    ' Quick task add button (replacing original Button1 functionality)
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim addEditForm As New Task(DateTime.Now)
        addEditForm.ShowDialog()

        ' Refresh when the task form closes (if data was saved)
        If addEditForm.DataSaved Then
            LoadTodaysTasks()
            LoadUpcomingTask()
            LoadStatistics()
        End If
    End Sub



    Private Sub Home_Click(sender As Object, e As EventArgs) Handles homebtn.Click
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
        End If
        Reset()
    End Sub

    Private Sub Reset()
        DisableButton()
        topBorderBtn.Visible = False
        homecurrenticon.IconChar = IconChar.HomeUser
        lblFormTitle.Text = "Home"
    End Sub

    Private Sub viewbtn_Click(sender As Object, e As EventArgs) Handles viewbtn.Click
        ActivateButton(sender, btncolor.color1)
        OpenChildForm(New calendar)
        lblFormTitle.Text = "Calendar View"
    End Sub
#End Region


End Class