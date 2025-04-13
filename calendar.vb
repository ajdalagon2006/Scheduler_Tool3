Imports System.Data.SQLite

Public Class calendar

    'Modified to add/edit notes to calendar using a form

    Private CalendarInfo As MonthlyCalendarInfo
    Private Notes As List(Of String)
    Private NotesDates As List(Of DateTime)
    Private TasksPanel As Panel
    Private WithEvents AlarmTimer As New Timer()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CalendarInfo = New MonthlyCalendarInfo(Now.Year, Now.Month)
        Notes = New List(Of String)
        NotesDates = New List(Of DateTime)

        ' Create a panel to display tasks when clicking a date
        CreateTasksPanel()

        SizeContainers()
        CreateMonthYearLabel()
        SizeMonthYearLabel()
        CreateDaysOfWeekLabels()
        SizeDaysOfWeekLabels()
        CreateDaysControls()
        SizeDaysControls()
        PopulateCalendarInfo()

        ' Load tasks from database
        LoadTasksFromDatabase()

        ' Load holidays and highlight them
        LoadHolidays()

        ' Set up alarm timer to check every minute
        AlarmTimer.Interval = 60000 ' 1 minute
        AlarmTimer.Start()
    End Sub

    Private Sub CreateTasksPanel()
        TasksPanel = New Panel()
        TasksPanel.BackColor = Color.FromArgb(246, 243, 220)
        TasksPanel.BorderStyle = BorderStyle.FixedSingle
        TasksPanel.Visible = False
        TasksPanel.AutoScroll = True

        Me.Controls.Add(TasksPanel)
        TasksPanel.BringToFront()
    End Sub

    Private Sub GetSQLiteConnection() As SQLiteConnection
        Dim connectionString As String = "Data Source=Appdatabase.db;Version=3;"
        Dim connection As New SQLiteConnection(connectionString)
        connection.Open()
        Return connection
    End Sub

    Private Sub SizeContainers()
        ' Existing code...

        ' Size the tasks panel
        TasksPanel.Size = New Size(300, 300)
        TasksPanel.Location = New Point((ClientSize.Width - TasksPanel.Width) / 2,
                                       (ClientSize.Height - TasksPanel.Height) / 2)
    End Sub

    Private Sub Form1_ClientSizeChanged(sender As Object, e As EventArgs) Handles MyBase.ClientSizeChanged
        SizeContainers()
        SizeMonthYearLabel()
        SizeDaysOfWeekLabels()
        SizeDaysControls()
    End Sub

    ' Existing code...

    Private Sub LoadTasksFromDatabase()
        Try
            Dim connection = GetConnection()
            connection.Open()

            Dim startDate As DateTime = CalendarInfo.DateInYear(0, 0) ' First date in grid
            Dim endDate As DateTime = CalendarInfo.DateInYear(5, 6)   ' Last date in grid

            Dim command As New SQLiteCommand(
                "SELECT * FROM Task WHERE date BETWEEN @startDate AND @endDate ORDER BY date",
                connection)

            command.Parameters.AddWithValue("@startDate", startDate.ToString("yyyy-MM-dd"))
            command.Parameters.AddWithValue("@endDate", endDate.ToString("yyyy-MM-dd"))

            Dim reader As SQLiteDataReader = command.ExecuteReader()

            While reader.Read()
                Dim taskDate As DateTime = DateTime.Parse(reader("date").ToString())
                Dim taskName As String = reader("todoname").ToString()

                ' Add to Notes and NotesDates lists for compatibility with existing code
                Notes.Add(taskName)
                NotesDates.Add(taskDate)
            End While

            reader.Close()
            connection.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading tasks: " & ex.Message)
        End Try

        ' After loading, display them on the calendar
        ShowMonthNotes()
    End Sub

    'Find and display all notes in calendar range
    Private Sub ShowMonthNotes()
        ' Existing code...
    End Sub

    ' Display tasks for the selected date in the tasks panel
    Private Sub DisplayTasksForDate(selectedDate As DateTime)
        TasksPanel.Controls.Clear()

        Dim headerLabel As New Label()
        headerLabel.Text = "Tasks for " & selectedDate.ToString("MMMM d, yyyy")
        headerLabel.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        headerLabel.AutoSize = True
        headerLabel.Location = New Point(10, 10)
        TasksPanel.Controls.Add(headerLabel)

        Dim closeButton As New Button()
        closeButton.Text = "X"
        closeButton.Size = New Size(25, 25)
        closeButton.Location = New Point(TasksPanel.Width - 35, 5)
        closeButton.FlatStyle = FlatStyle.Flat
        AddHandler closeButton.Click, AddressOf CloseTasksPanel
        TasksPanel.Controls.Add(closeButton)

        ' Get tasks for the selected date from database
        Dim y As Integer = 50
        Try
            Dim connection = GetConnection()
            connection.Open()

            Dim command As New SQLiteCommand(
                "SELECT * FROM Task WHERE date = @date ORDER BY has_alarm DESC",
                connection)

            command.Parameters.AddWithValue("@date", selectedDate.ToString("yyyy-MM-dd"))

            Dim reader As SQLiteDataReader = command.ExecuteReader()
            Dim taskCount As Integer = 0

            While reader.Read()
                Dim taskName As String = reader("todoname").ToString()
                Dim category As String = reader("category").ToString()
                Dim hasAlarm As Boolean = Convert.ToBoolean(reader("has_alarm"))

                ' Create panel for each task
                Dim taskPanel As New Panel()
                taskPanel.BorderStyle = BorderStyle.FixedSingle
                taskPanel.Size = New Size(TasksPanel.Width - 30, 60)
                taskPanel.Location = New Point(10, y)

                ' Task name
                Dim taskNameLabel As New Label()
                taskNameLabel.Text = taskName
                taskNameLabel.Font = New Font("Segoe UI", 10, FontStyle.Bold)
                taskNameLabel.AutoSize = True
                taskNameLabel.Location = New Point(5, 5)
                taskPanel.Controls.Add(taskNameLabel)

                ' Task category
                Dim categoryLabel As New Label()
                categoryLabel.Text = category
                categoryLabel.AutoSize = True
                categoryLabel.Location = New Point(5, 25)
                taskPanel.Controls.Add(categoryLabel)

                ' Alarm indicator if task has alarm
                If hasAlarm Then
                    Dim alarmLabel As New Label()
                    alarmLabel.Text = "⏰ " & If(reader("alarm_time") IsNot DBNull.Value,
                                               DateTime.Parse(reader("alarm_time").ToString()).ToString("h:mm tt"),
                                               "")
                    alarmLabel.AutoSize = True
                    alarmLabel.ForeColor = Color.Red
                    alarmLabel.Location = New Point(taskPanel.Width - 100, 5)
                    taskPanel.Controls.Add(alarmLabel)
                End If

                ' Add edit button
                Dim editButton As New Button()
                editButton.Text = "Edit"
                editButton.Size = New Size(50, 25)
                editButton.Location = New Point(taskPanel.Width - 120, taskPanel.Height - 30)
                editButton.Tag = New KeyValuePair(Of String, DateTime)(taskName, selectedDate)
                AddHandler editButton.Click, AddressOf EditTask_Click
                taskPanel.Controls.Add(editButton)

                ' Add delete button
                Dim deleteButton As New Button()
                deleteButton.Text = "Delete"
                deleteButton.Size = New Size(50, 25)
                deleteButton.Location = New Point(taskPanel.Width - 60, taskPanel.Height - 30)
                deleteButton.Tag = New KeyValuePair(Of String, DateTime)(taskName, selectedDate)
                AddHandler deleteButton.Click, AddressOf DeleteTask_Click
                taskPanel.Controls.Add(deleteButton)

                TasksPanel.Controls.Add(taskPanel)

                y += taskPanel.Height + 10
                taskCount += 1
            End While

            reader.Close()
            connection.Close()

            If taskCount = 0 Then
                Dim noTasksLabel As New Label()
                noTasksLabel.Text = "No tasks for this date."
                noTasksLabel.AutoSize = True
                noTasksLabel.Location = New Point(10, 50)
                TasksPanel.Controls.Add(noTasksLabel)
            End If

        Catch ex As Exception
            MessageBox.Show("Error displaying tasks: " & ex.Message)
        End Try

        ' Add new task button
        Dim addButton As New Button()
        addButton.Text = "Add New Task"
        addButton.Size = New Size(120, 30)
        addButton.Location = New Point((TasksPanel.Width - 120) / 2, y + 10)
        addButton.Tag = selectedDate
        AddHandler addButton.Click, AddressOf AddNewTask_Click
        TasksPanel.Controls.Add(addButton)

        TasksPanel.Visible = True
    End Sub

    Private Sub CloseTasksPanel(sender As Object, e As EventArgs)
        TasksPanel.Visible = False
    End Sub

    Private Sub EditTask_Click(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim data As KeyValuePair(Of String, DateTime) = DirectCast(btn.Tag, KeyValuePair(Of String, DateTime))
        Dim taskName As String = data.Key
        Dim taskDate As DateTime = data.Value

        ' Open task edit form
        Dim taskForm As New Task(taskDate, taskName)
        taskForm.ShowDialog()

        If taskForm.DataSaved Then
            ' Reload tasks from database and refresh display
            Notes.Clear()
            NotesDates.Clear()
            RemoveMonthNotes()
            LoadTasksFromDatabase()
            DisplayTasksForDate(taskDate)
        End If
    End Sub

    Private Sub DeleteTask_Click(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim data As KeyValuePair(Of String, DateTime) = DirectCast(btn.Tag, KeyValuePair(Of String, DateTime))
        Dim taskName As String = data.Key
        Dim taskDate As DateTime = data.Value

        If MessageBox.Show("Are you sure you want to delete this task?", "Confirm Delete",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                Dim connection = GetConnection()
                connection.Open()

                Dim command As New SQLiteCommand(
                    "DELETE FROM Tasks WHERE date = @date AND todoname = @todoname",
                    connection)

                command.Parameters.AddWithValue("@date", taskDate.ToString("yyyy-MM-dd"))
                command.Parameters.AddWithValue("@todoname", taskName)
                command.ExecuteNonQuery()

                connection.Close()

                ' Reload tasks from database and refresh display
                Notes.Clear()
                NotesDates.Clear()
                RemoveMonthNotes()
                LoadTasksFromDatabase()
                DisplayTasksForDate(taskDate)
            Catch ex As Exception
                MessageBox.Show("Error deleting task: " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub AddNewTask_Click(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim taskDate As DateTime = DirectCast(btn.Tag, DateTime)

        ' Open task creation form
        Dim taskForm As New Task(taskDate)
        taskForm.ShowDialog()

        If taskForm.DataSaved Then
            ' Reload tasks from database and refresh display
            Notes.Clear()
            NotesDates.Clear()
            RemoveMonthNotes()
            LoadTasksFromDatabase()
            DisplayTasksForDate(taskDate)
        End If
    End Sub

    'Add/Edit note in list and refresh calendar - modified to show tasks panel
    Private Sub Day_DoubleClick(ByVal sender As Object, e As MouseEventArgs)
        Dim rowIndex As Integer
        Dim columnIndex As Integer
        Dim control As Control

        control = TryCast(sender, Control)
        rowIndex = ExtractFirstDigit(control.Name)
        columnIndex = ExtractLastDigit(control.Name)
        Dim selectedDate As DateTime = CalendarInfo.DateInYear(rowIndex, columnIndex)

        ' Display tasks panel for the selected date
        DisplayTasksForDate(selectedDate)
    End Sub

    ' Rest of the code...

    ' Alarm checking logic
    Private Sub AlarmTimer_Tick(sender As Object, e As EventArgs) Handles AlarmTimer.Tick
        CheckForAlarms()
    End Sub

    Private Sub CheckForAlarms()
        Try
            Dim currentDateTime = DateTime.Now
            Dim currentDateTimeStr = currentDateTime.ToString("yyyy-MM-dd HH:mm")

            ' Check within a minute window
            Dim connection = GetConnection()
            connection.Open()

            ' Find alarms that should trigger within the current minute
            Dim command As New SQLiteCommand(
                "SELECT * FROM Tasks WHERE has_alarm = 1 AND " &
                "strftime('%Y-%m-%d %H:%M', alarm_time) = @currentTime",
                connection)

            command.Parameters.AddWithValue("@currentTime", currentDateTime.ToString("yyyy-MM-dd HH:mm"))

            Dim reader As SQLiteDataReader = command.ExecuteReader()

            While reader.Read()
                Dim taskName As String = reader("todoname").ToString()
                Dim taskComment As String = If(reader("comment") IsNot DBNull.Value, reader("comment").ToString(), "")
                Dim soundFile As String = If(reader("alarm_sound") IsNot DBNull.Value, reader("alarm_sound").ToString(), "default.wav")

                ' Play alarm sound
                PlayAlarmSound(soundFile)

                ' Show notification
                ShowAlarmNotification(taskName, taskComment)
            End While

            reader.Close()
            connection.Close()

        Catch ex As Exception
            ' Log error but don't show message box as this runs in background
            Console.WriteLine("Error checking alarms: " & ex.Message)
        End Try
    End Sub

    Private Sub PlayAlarmSound(soundFile As String)
        Try
            If Not System.IO.File.Exists(soundFile) AndAlso Not soundFile = "default.wav" Then
                ' Fall back to default sound
                soundFile = "default.wav"
            End If

            ' Use My.Computer.Audio.Play for sound playback
            If soundFile = "default.wav" Then
                ' Use system sound
                My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
            Else
                ' Play custom sound file
                My.Computer.Audio.Play(soundFile, AudioPlayMode.Background)
            End If
        Catch ex As Exception
            ' Fall back to system sound if there's an error
            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
        End Try
    End Sub

    Private Sub ShowAlarmNotification(taskName As String, taskComment As String)
        ' Create notification form
        Dim notification As New AlarmNotification(taskName, taskComment)
        notification.Show()
    End Sub

    ' Holiday handling logic
    Private Sub LoadHolidays()
        ' First, let's add some default holidays
        AddDefaultHolidays()

        ' Then load custom holidays from database if you have them
        LoadCustomHolidays()

        ' Highlight holiday dates on calendar
        HighlightHolidays()
    End Sub

    Private Sub AddDefaultHolidays()
        ' Add some common Philippine holidays as an example
        Dim holidaysList As New List(Of KeyValuePair(Of DateTime, String))

        ' Add holidays for current year
        Dim currentYear As Integer = CalendarInfo.Year

        ' Fixed holidays
        holidaysList.Add(New KeyValuePair(Of DateTime, String)(New DateTime(currentYear, 1, 1), "New Year's Day"))
        holidaysList.Add(New KeyValuePair(Of DateTime, String)(New DateTime(currentYear, 4, 9), "Araw ng Kagitingan"))
        holidaysList.Add(New KeyValuePair(Of DateTime, String)(New DateTime(currentYear, 5, 1), "Labor Day"))
        holidaysList.Add(New KeyValuePair(Of DateTime, String)(New DateTime(currentYear, 6, 12), "Independence Day"))
        holidaysList.Add(New KeyValuePair(Of DateTime, String)(New DateTime(currentYear, 8, 30), "National Heroes Day"))
        holidaysList.Add(New KeyValuePair(Of DateTime, String)(New DateTime(currentYear, 11, 30), "Bonifacio Day"))
        holidaysList.Add(New KeyValuePair(Of DateTime, String)(New DateTime(currentYear, 12, 25), "Christmas Day"))
        holidaysList.Add(New KeyValuePair(Of DateTime, String)(New DateTime(currentYear, 12, 30), "Rizal Day"))

        ' Save to database
        Try
            Dim connection = GetConnection()
            connection.Open()

            ' First, create the table if it doesn't exist
            Dim createTableCmd As New SQLiteCommand(
                "CREATE TABLE IF NOT EXISTS Holidays (date TEXT PRIMARY KEY, name TEXT NOT NULL)",
                connection)
            createTableCmd.ExecuteNonQuery()

            ' Insert holidays
            For Each holiday In holidaysList
                Dim command As New SQLiteCommand(
                    "INSERT OR IGNORE INTO Holidays (date, name) VALUES (@date, @name)",
                    connection)

                command.Parameters.AddWithValue("@date", holiday.Key.ToString("yyyy-MM-dd"))
                command.Parameters.AddWithValue("@name", holiday.Value)
                command.ExecuteNonQuery()
            Next

            connection.Close()
        Catch ex As Exception
            MessageBox.Show("Error adding default holidays: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadCustomHolidays()
        ' Load custom holidays from database if you want to implement this feature
    End Sub

    Private Sub HighlightHolidays()
        Try
            Dim connection = GetConnection()
            connection.Open()

            Dim startDate As DateTime = CalendarInfo.DateInYear(0, 0) ' First date in grid
            Dim endDate As DateTime = CalendarInfo.DateInYear(5, 6)   ' Last date in grid

            Dim command As New SQLiteCommand(
                "SELECT * FROM Holidays WHERE date BETWEEN @startDate AND @endDate",
                connection)

            command.Parameters.AddWithValue("@startDate", startDate.ToString("yyyy-MM-dd"))
            command.Parameters.AddWithValue("@endDate", endDate.ToString("yyyy-MM-dd"))

            Dim reader As SQLiteDataReader = command.ExecuteReader()

            While reader.Read()
                Dim holidayDate As DateTime = DateTime.Parse(reader("date").ToString())
                Dim holidayName As String = reader("name").ToString()

                ' Find the grid position for this date
                If CalendarInfo.DateExists(holidayDate) Then
                    Dim row As Integer = CalendarInfo.DateRow(holidayDate)
                    Dim col As Integer = CalendarInfo.DateColumn(holidayDate)

                    ' Highlight the date by modifying the panel or adding an indicator
                    HighlightDateAsHoliday(row, col, holidayName)
                End If
            End While

            reader.Close()
            connection.Close()
        Catch ex As Exception
            MessageBox.Show("Error highlighting holidays: " & ex.Message)
        End Try
    End Sub

    Private Sub HighlightDateAsHoliday(rowIndex As Integer, colIndex As Integer, holidayName As String)
        ' Find the panel for this day
        Dim panelName As String = String.Format("PnlDay{0}{1}", rowIndex, colIndex)
        Dim panel As Panel = Controls.Find(panelName, True).FirstOrDefault()

        If panel IsNot Nothing Then
            ' Add holiday indicator
            Dim indicator As New Label()
            indicator.Name = "LblHoliday" & rowIndex & colIndex
            indicator.Text = "🎉" ' Holiday emoji
            indicator.ForeColor = Color.Red
            indicator.BackColor = Color.LightYellow
            indicator.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            indicator.Size = New Size(20, 20)
            indicator.Location = New Point(panel.Width - 25, 2)
            indicator.TextAlign = ContentAlignment.MiddleCenter
            indicator.ToolTipText = holidayName

            ' Add tooltip for the holiday name
            Dim toolTip As New ToolTip()
            toolTip.SetToolTip(indicator, holidayName)

            panel.Controls.Add(indicator)
        End If
    End Sub
End Class