Imports System.Data.SQLite
Imports System.Media

Public Class calendar

    'Modified to add/edit notes to calendar using a form
    Private CalendarInfo As MonthlyCalendarInfo
    Private Notes As List(Of String)
    Private NotesDates As List(Of DateTime)
    Private Holidays As Dictionary(Of DateTime, String)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CalendarInfo = New MonthlyCalendarInfo(Now.Year, Now.Month)
        Notes = New List(Of String)
        NotesDates = New List(Of DateTime)
        Holidays = New Dictionary(Of DateTime, String)

        ' Set up the UI
        SizeContainers()
        CreateMonthYearLabel()
        SizeMonthYearLabel()
        CreateDaysOfWeekLabels()
        SizeDaysOfWeekLabels()
        CreateDaysControls()
        SizeDaysControls()
        PopulateCalendarInfo()

        ' Initialize new features
        InitializeDatabase()
        LoadHolidays()
        LoadNotesFromDatabase()

        ' Set up the alarm timer
        AlarmTimer.Interval = 60000 ' Check every minute
        AlarmTimer.Start()
    End Sub

    Private Sub InitializeDatabase()
        Try
            Using connection As SQLiteConnection = GetSQLiteConnection()
                ' Create Tasks table if it doesn't exist
                Dim createTasksTable As New SQLiteCommand(
                    "CREATE TABLE IF NOT EXISTS Tasks (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        todoname TEXT NOT NULL,
                        comment TEXT,
                        date TEXT NOT NULL,
                        category TEXT NOT NULL,
                        has_alarm INTEGER DEFAULT 0,
                        alarm_time TEXT,
                        alarm_sound TEXT DEFAULT 'default.wav'
                    )", connection)
                createTasksTable.ExecuteNonQuery()

                ' Create Holidays table if it doesn't exist
                Dim createHolidaysTable As New SQLiteCommand(
                    "CREATE TABLE IF NOT EXISTS Holidays (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        date TEXT NOT NULL,
                        name TEXT NOT NULL,
                        is_recurring INTEGER DEFAULT 0,
                        color TEXT DEFAULT 'Red'
                    )", connection)
                createHolidaysTable.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error initializing database: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetSQLiteConnection() As SQLiteConnection
        Dim connectionString As String = "Data Source=Appdatabase.db;Version=3;"
        Dim connection As New SQLiteConnection(connectionString)
        connection.Open()
        Return connection
    End Function

    Private Sub LoadNotesFromDatabase()
        Try
            Using connection As SQLiteConnection = GetSQLiteConnection()
                ' First day in calendar
                Dim startDate = CalendarInfo.DateInYear(0, 0)
                ' Last day in calendar
                Dim endDate = CalendarInfo.DateInYear(5, 6)

                Dim command As New SQLiteCommand(
                    "SELECT * FROM Tasks WHERE date BETWEEN @startDate AND @endDate",
                    connection)

                command.Parameters.AddWithValue("@startDate", startDate.ToString("yyyy-MM-dd"))
                command.Parameters.AddWithValue("@endDate", endDate.ToString("yyyy-MM-dd"))

                Using reader As SQLiteDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim taskDate As DateTime = DateTime.Parse(reader("date").ToString())
                        Dim taskName As String = reader("todoname").ToString()

                        ' Add to our lists for display
                        Notes.Add(taskName)
                        NotesDates.Add(taskDate)
                    End While
                End Using
            End Using

            ' Show the notes on calendar
            ShowMonthNotes()
        Catch ex As Exception
            ' Table might not exist yet
            Console.WriteLine("Error loading notes: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadHolidays()
        Try
            AddDefaultHolidays()

            Using connection As SQLiteConnection = GetSQLiteConnection()
                ' First day in calendar
                Dim startDate = CalendarInfo.DateInYear(0, 0)
                ' Last day in calendar
                Dim endDate = CalendarInfo.DateInYear(5, 6)

                Dim command As New SQLiteCommand(
                    "SELECT * FROM Holidays WHERE date BETWEEN @startDate AND @endDate",
                    connection)

                command.Parameters.AddWithValue("@startDate", startDate.ToString("yyyy-MM-dd"))
                command.Parameters.AddWithValue("@endDate", endDate.ToString("yyyy-MM-dd"))

                Using reader As SQLiteDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim holidayDate As DateTime = DateTime.Parse(reader("date").ToString())
                        Dim holidayName As String = reader("name").ToString()

                        Holidays(holidayDate) = holidayName
                    End While
                End Using
            End Using

            ' Highlight holidays on calendar
            HighlightHolidays()
        Catch ex As Exception
            ' Table might not exist yet
            Console.WriteLine("Error loading holidays: " & ex.Message)
        End Try
    End Sub

    Private Sub AddDefaultHolidays()
        Try
            Using connection As SQLiteConnection = GetSQLiteConnection()
                ' Current year
                Dim currentYear As Integer = CalendarInfo.Year

                ' List of default holidays
                Dim defaultHolidays As New List(Of Tuple(Of DateTime, String))()
                defaultHolidays.Add(New Tuple(Of DateTime, String)(New DateTime(currentYear, 1, 1), "New Year's Day"))
                defaultHolidays.Add(New Tuple(Of DateTime, String)(New DateTime(currentYear, 5, 1), "Labor Day"))
                defaultHolidays.Add(New Tuple(Of DateTime, String)(New DateTime(currentYear, 6, 12), "Independence Day"))
                defaultHolidays.Add(New Tuple(Of DateTime, String)(New DateTime(currentYear, 12, 25), "Christmas Day"))
                defaultHolidays.Add(New Tuple(Of DateTime, String)(New DateTime(currentYear, 12, 30), "Rizal Day"))

                ' Insert holidays if they don't exist
                For Each holiday In defaultHolidays
                    Dim command As New SQLiteCommand(
                        "INSERT OR IGNORE INTO Holidays (date, name, is_recurring) VALUES (@date, @name, 1)",
                        connection)

                    command.Parameters.AddWithValue("@date", holiday.Item1.ToString("yyyy-MM-dd"))
                    command.Parameters.AddWithValue("@name", holiday.Item2)
                    command.ExecuteNonQuery()
                Next
            End Using
        Catch ex As Exception
            Console.WriteLine("Error adding default holidays: " & ex.Message)
        End Try
    End Sub

    Private Sub HighlightHolidays()
        For Each holiday In Holidays
            Dim holidayDate As DateTime = holiday.Key
            Dim holidayName As String = holiday.Value

            ' Find the position on the calendar
            If CalendarInfo.DateExists(holidayDate) Then
                Dim row As Integer = CalendarInfo.DateRow(holidayDate)
                Dim col As Integer = CalendarInfo.DateColumn(holidayDate)

                ' Find the panel for this date
                Dim panelName As String = String.Format("PnlDay{0}{1}", row, col)
                Dim panel As Panel = Controls.Find(panelName, True).FirstOrDefault()

                If panel IsNot Nothing Then
                    ' Create a holiday indicator
                    Dim indicatorLabel As New Label()
                    indicatorLabel.Name = String.Format("LblHoliday{0}{1}", row, col)
                    indicatorLabel.Text = "🎉" ' Holiday emoji
                    indicatorLabel.ForeColor = Color.Red
                    indicatorLabel.BackColor = Color.FromArgb(255, 255, 200) ' Light yellow
                    indicatorLabel.Size = New Size(20, 20)
                    indicatorLabel.Location = New Point(panel.Width - 25, 5)
                    indicatorLabel.TextAlign = ContentAlignment.MiddleCenter

                    ' Add tooltip for holiday name
                    Dim toolTip As New ToolTip()
                    toolTip.SetToolTip(indicatorLabel, holidayName)

                    panel.Controls.Add(indicatorLabel)
                End If
            End If
        Next
    End Sub

    Private Sub SizeContainers()
        ' Existing code...

        ' Also size the TasksPanel properly
        TasksPanel.Size = New Size(300, 300)
        TasksPanel.Location = New Point((ClientSize.Width - TasksPanel.Width) / 2,
                                       (ClientSize.Height - TasksPanel.Height) / 2)
    End Sub

    ' Rest of your existing code...

    'Add/Edit note in list and refresh calendar
    Private Sub Day_DoubleClick(ByVal sender As Object, e As MouseEventArgs)
        Dim rowIndex As Integer
        Dim columnIndex As Integer
        Dim control As Control

        control = TryCast(sender, Control)
        rowIndex = ExtractFirstDigit(control.Name)
        columnIndex = ExtractLastDigit(control.Name)
        Dim selectedDate As DateTime = CalendarInfo.DateInYear(rowIndex, columnIndex)

        ' Display the tasks panel instead of directly showing the task form
        DisplayTasksForDate(selectedDate)
    End Sub

    Private Sub DisplayTasksForDate(selectedDate As DateTime)
        ' Clear existing controls
        TasksPanel.Controls.Clear()

        ' Create panel header
        Dim headerLabel As New Label()
        headerLabel.Text = "Tasks for " & selectedDate.ToString("MMMM d, yyyy")
        headerLabel.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        headerLabel.AutoSize = True
        headerLabel.Location = New Point(10, 10)
        TasksPanel.Controls.Add(headerLabel)

        ' Add close button
        Dim closeButton As New Button()
        closeButton.Text = "×"
        closeButton.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        closeButton.FlatStyle = FlatStyle.Flat
        closeButton.Size = New Size(30, 30)
        closeButton.Location = New Point(TasksPanel.Width - 40, 5)
        AddHandler closeButton.Click, Sub(s, args) TasksPanel.Visible = False
        TasksPanel.Controls.Add(closeButton)

        ' Check if this date is a holiday
        If Holidays.ContainsKey(selectedDate) Then
            Dim holidayLabel As New Label()
            holidayLabel.Text = "Holiday: " & Holidays(selectedDate)
            holidayLabel.ForeColor = Color.Red
            holidayLabel.Font = New Font("Segoe UI", 10, FontStyle.Italic)
            holidayLabel.AutoSize = True
            holidayLabel.Location = New Point(10, 40)
            TasksPanel.Controls.Add(holidayLabel)
        End If

        ' Load and display tasks
        Try
            Dim tasks As New List(Of Tuple(Of String, String, Boolean, String))() ' Name, Category, HasAlarm, AlarmTime

            Using connection As SQLiteConnection = GetSQLiteConnection()
                Dim command As New SQLiteCommand(
                    "SELECT * FROM Tasks WHERE date = @date ORDER BY has_alarm DESC",
                    connection)

                command.Parameters.AddWithValue("@date", selectedDate.ToString("yyyy-MM-dd"))

                Using reader As SQLiteDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim taskName As String = reader("todoname").ToString()
                        Dim category As String = reader("category").ToString()

                        Dim hasAlarm As Boolean = False
                        Dim alarmTime As String = ""

                        If reader.Table.Columns.Contains("has_alarm") Then
                            hasAlarm = Convert.ToBoolean(reader("has_alarm"))
                            If hasAlarm AndAlso Not IsDBNull(reader("alarm_time")) Then
                                Dim dt As DateTime
                                If DateTime.TryParse(reader("alarm_time").ToString(), dt) Then
                                    alarmTime = dt.ToString("h:mm tt")
                                End If
                            End If
                        End If

                        tasks.Add(New Tuple(Of String, String, Boolean, String)(taskName, category, hasAlarm, alarmTime))
                    End While
                End Using
            End Using

            ' Display tasks in the panel
            Dim yPosition As Integer = If(Holidays.ContainsKey(selectedDate), 70, 50)

            If tasks.Count = 0 Then
                ' Show "No tasks" message
                Dim noTasksLabel As New Label()
                noTasksLabel.Text = "No tasks for this date."
                noTasksLabel.Font = New Font("Segoe UI", 9, FontStyle.Italic)
                noTasksLabel.AutoSize = True
                noTasksLabel.Location = New Point(10, yPosition)
                TasksPanel.Controls.Add(noTasksLabel)
                yPosition += 30
            Else
                ' Display each task
                For Each task In tasks
                    ' Create a task panel
                    Dim taskPanel As New Panel()
                    taskPanel.BorderStyle = BorderStyle.FixedSingle
                    taskPanel.Size = New Size(TasksPanel.Width - 20, 60)
                    taskPanel.Location = New Point(10, yPosition)

                    ' Task name
                    Dim taskNameLabel As New Label()
                    taskNameLabel.Text = task.Item1
                    taskNameLabel.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                    taskNameLabel.AutoSize = True
                    taskNameLabel.Location = New Point(5, 5)
                    taskPanel.Controls.Add(taskNameLabel)

                    ' Category
                    Dim categoryLabel As New Label()
                    categoryLabel.Text = task.Item2
                    categoryLabel.AutoSize = True
                    categoryLabel.Location = New Point(5, 25)
                    taskPanel.Controls.Add(categoryLabel)

                    ' Show alarm indicator if task has alarm
                    If task.Item3 Then
                        Dim alarmIndicator As New Label()
                        alarmIndicator.Text = "⏰ " & task.Item4
                        alarmIndicator.ForeColor = Color.Red
                        alarmIndicator.AutoSize = True
                        alarmIndicator.Location = New Point(taskPanel.Width - 100, 5)
                        taskPanel.Controls.Add(alarmIndicator)
                    End If

                    ' Edit button
                    Dim editButton As New Button()
                    editButton.Text = "Edit"
                    editButton.Size = New Size(50, 23)
                    editButton.Location = New Point(taskPanel.Width - 115, 30)
                    editButton.Tag = task.Item1 ' Store task name in tag
                    AddHandler editButton.Click, Sub(s, args)
                                                     EditTask(selectedDate, DirectCast(DirectCast(s, Button).Tag, String))
                                                 End Sub
                    taskPanel.Controls.Add(editButton)

                    ' Delete button
                    Dim deleteButton As New Button()
                    deleteButton.Text = "Delete"
                    deleteButton.Size = New Size(50, 23)
                    deleteButton.Location = New Point(taskPanel.Width - 60, 30)
                    deleteButton.Tag = task.Item1 ' Store task name in tag
                    AddHandler deleteButton.Click, Sub(s, args)
                                                       DeleteTask(selectedDate, DirectCast(DirectCast(s, Button).Tag, String))
                                                   End Sub
                    taskPanel.Controls.Add(deleteButton)

                    TasksPanel.Controls.Add(taskPanel)
                    yPosition += taskPanel.Height + 5
                Next
            End If

            ' Add "New Task" button at the bottom
            Dim addButton As New Button()
            addButton.Text = "Add New Task"
            addButton.Size = New Size(120, 30)
            addButton.Location = New Point((TasksPanel.Width - 120) / 2, yPosition + 10)
            addButton.Tag = selectedDate
            AddHandler addButton.Click, Sub(s, args)
                                            AddNewTask(DirectCast(DirectCast(s, Button).Tag, DateTime))
                                        End Sub
            TasksPanel.Controls.Add(addButton)
        Catch ex As Exception
            MessageBox.Show("Error displaying tasks: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' Make the panel visible
        TasksPanel.Visible = True
    End Sub

    Private Sub AddNewTask(selectedDate As DateTime)
        Dim taskForm As New Task(selectedDate)
        taskForm.ShowDialog()

        If taskForm.DataSaved Then
            ' Refresh tasks display
            Notes.Clear()
            NotesDates.Clear()
            RemoveMonthNotes()
            LoadNotesFromDatabase()
            DisplayTasksForDate(selectedDate)
        End If
    End Sub

    Private Sub EditTask(selectedDate As DateTime, taskName As String)
        Dim taskForm As New Task(selectedDate, taskName)
        taskForm.ShowDialog()

        If taskForm.DataSaved Then
            ' Refresh tasks display
            Notes.Clear()
            NotesDates.Clear()
            RemoveMonthNotes()
            LoadNotesFromDatabase()
            DisplayTasksForDate(selectedDate)
        End If
    End Sub

    Private Sub DeleteTask(selectedDate As DateTime, taskName As String)
        If MessageBox.Show("Are you sure you want to delete this task?", "Confirm Delete",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                Using connection As SQLiteConnection = GetSQLiteConnection()
                    Dim command As New SQLiteCommand(
                        "DELETE FROM Tasks WHERE date = @date AND todoname = @taskName",
                        connection)

                    command.Parameters.AddWithValue("@date", selectedDate.ToString("yyyy-MM-dd"))
                    command.Parameters.AddWithValue("@taskName", taskName)
                    command.ExecuteNonQuery()
                End Using

                ' Refresh tasks display
                Notes.Clear()
                NotesDates.Clear()
                RemoveMonthNotes()
                LoadNotesFromDatabase()
                DisplayTasksForDate(selectedDate)
            Catch ex As Exception
                MessageBox.Show("Error deleting task: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' Alarm checking functionality
    Private Sub AlarmTimer_Tick(sender As Object, e As EventArgs) Handles AlarmTimer.Tick
        CheckForAlarms()
    End Sub

    Private Sub CheckForAlarms()
        Try
            Using connection As SQLiteConnection = GetSQLiteConnection()
                ' Get current time
                Dim currentTime As DateTime = DateTime.Now
                Dim currentTimeString As String = currentTime.ToString("yyyy-MM-dd HH:mm")

                ' Find alarms that should trigger now (within the minute)
                Dim command As New SQLiteCommand(
                    "SELECT * FROM Tasks WHERE has_alarm = 1 AND strftime('%Y-%m-%d %H:%M', alarm_time) = @currentTime",
                    connection)

                command.Parameters.AddWithValue("@currentTime", currentTimeString)

                Using reader As SQLiteDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim taskName As String = reader("todoname").ToString()
                        Dim taskDesc As String = If(reader("comment") IsNot DBNull.Value, reader("comment").ToString(), "")

                        ' Get sound file if specified
                        Dim soundFile As String = "default.wav"
                        If reader.Table.Columns.Contains("alarm_sound") AndAlso Not IsDBNull(reader("alarm_sound")) Then
                            soundFile = reader("alarm_sound").ToString()
                        End If

                        ' Show notification
                        ShowAlarmNotification(taskName, taskDesc)

                        ' Play sound
                        PlayAlarmSound(soundFile)
                    End While
                End Using
            End Using
        Catch ex As Exception
            ' Log error but don't show message box as this runs in background
            Console.WriteLine("Error checking alarms: " & ex.Message)
        End Try
    End Sub

    Private Sub ShowAlarmNotification(taskName As String, taskDesc As String)
        Dim notification As New AlarmNotification(taskName, taskDesc)
        notification.Show()
    End Sub

    Private Sub PlayAlarmSound(soundFile As String)
        Try
            If soundFile = "default.wav" OrElse Not System.IO.File.Exists(soundFile) Then
                ' Play system sound
                My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
            Else
                ' Play custom sound file
                My.Computer.Audio.Play(soundFile, AudioPlayMode.Background)
            End If
        Catch ex As Exception
            ' Fall back to system sound if there's an error
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
        End Try
    End Sub

    ' Existing code and methods...
End Class