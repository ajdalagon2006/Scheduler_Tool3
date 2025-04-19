Imports System.Data.SQLite
Imports System.Media

Public Class calendar
    'Modified to add/edit notes to calendar using a form
    Private CalendarInfo As MonthlyCalendarInfo
    Private Notes As List(Of String)
    Private NotesDates As List(Of DateTime)
    Private Holidays As Dictionary(Of DateTime, String)

#Region "Form Initialization"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CalendarInfo = New MonthlyCalendarInfo(Now.Year, Now.Month)
        Notes = New List(Of String)
        NotesDates = New List(Of DateTime)
        Holidays = New Dictionary(Of DateTime, String)

        ' Update database schema first - adds alarm fields
        DbConnection.UpdateDatabaseSchema()

        ' Set up the UI
        SizeContainers()
        CreateMonthYearLabel()
        SizeMonthYearLabel()
        CreateDaysOfWeekLabels()
        SizeDaysOfWeekLabels()
        CreateDaysControls()
        SizeDaysControls()
        PopulateCalendarInfo()

        ' Load data
        LoadHolidays()
        LoadNotesFromDatabase()

        ' Set up the alarm timer
        AlarmTimer.Interval = 60000 ' Check every minute
        AlarmTimer.Start()
    End Sub

#End Region

#Region "UI Layout Methods"

    Private Sub SizeContainers()

        Dim daysHeight As Integer
        Dim daysYStart As Integer

        MonthYearContainer.Size = New Size(ClientSize.Width, 55)
        MonthYearContainer.Location = New Point(0, 0)
        DaysOfWeekContainer.Size = New Size(ClientSize.Width, 30)
        DaysOfWeekContainer.Location = New Point(0, MonthYearContainer.Height)

        daysHeight = (ClientSize.Height - MonthYearContainer.Height - DaysOfWeekContainer.Height) / 6
        daysYStart = MonthYearContainer.Height + DaysOfWeekContainer.Height

        DaysRow0Container.Size = New Size(ClientSize.Width, daysHeight)
        DaysRow0Container.Location = New Point(0, daysYStart)
        DaysRow1Container.Size = New Size(ClientSize.Width, daysHeight)
        DaysRow1Container.Location = New Point(0, daysYStart + (daysHeight))
        DaysRow2Container.Size = New Size(ClientSize.Width, daysHeight)
        DaysRow2Container.Location = New Point(0, daysYStart + (daysHeight * 2))
        DaysRow3Container.Size = New Size(ClientSize.Width, daysHeight)
        DaysRow3Container.Location = New Point(0, daysYStart + (daysHeight * 3))
        DaysRow4Container.Size = New Size(ClientSize.Width, daysHeight)
        DaysRow4Container.Location = New Point(0, daysYStart + (daysHeight * 4))
        DaysRow5Container.Size = New Size(ClientSize.Width, daysHeight)
        DaysRow5Container.Location = New Point(0, daysYStart + (daysHeight * 5))

    End Sub

    Private Sub CreateMonthYearLabel()
        Dim label As Label = New Label()

        label.Name = "LblMonthYear"
        label.Font = New Font("Segoe UI", 20, FontStyle.Bold)
        label.AutoSize = True
        label.Text = "Month Year"

        MonthYearContainer.Controls.Add(label)
    End Sub


    Private Sub SizeMonthYearLabel()

        Dim x As Integer
        Dim y As Integer
        Dim label As Label

        If MonthYearContainer.Controls.Count > 0 Then

            label = MonthYearContainer.Controls.Find("LblMonthYear", False).First
            x = (MonthYearContainer.Width - label.Width) / 2
            y = (MonthYearContainer.Height - label.Height) / 2
            label.Location = New Point(x, y)

        End If

    End Sub

    Private Sub CreateDaysOfWeekLabels()
        Dim label As Label
        Dim days As String() = New String(6) {"Sunday", "Monday", "Tuesday",
       "Wednesday", "Thursday", "Friday", "Saturday"}

        For i = 0 To 6
            label = New Label
            label.Name = String.Format("Lbl{0}", days(i))
            label.Text = days(i)
            label.AutoSize = False
            label.Font = New Font("Segoe UI", 11, FontStyle.Regular)
            label.TextAlign = ContentAlignment.MiddleCenter
            DaysOfWeekContainer.Controls.Add(label)
        Next
    End Sub

    Private Sub SizeDaysOfWeekLabels()
        SizeWidthEqually(DaysOfWeekContainer)
    End Sub

    Private Sub SizeWidthEqually(ByVal c As Control)
        Dim width As Integer
        Dim x As Integer

        If c.Controls.Count = 0 Then
            Return
        End If

        width = c.Width / c.Controls.Count

        For Each control As Control In c.Controls
            control.Height = c.Height
            control.Width = width
            control.Location = New Point(x, 0)
            x += width
        Next
    End Sub

    Private Sub CreateDaysControls()
        Dim dayPanel As Panel
        Dim dayOfMonthLbl As Label

        For rowIndex = 0 To 5
            For colIndex = 0 To 6
                dayPanel = New Panel
                dayPanel.Name = String.Format("PnlDay{0}{1}", rowIndex, colIndex)
                AddHandler dayPanel.MouseDoubleClick, AddressOf Day_DoubleClick
                dayOfMonthLbl = New Label
                dayOfMonthLbl.Name = String.Format("LblDayOfMonth{0}{1}", rowIndex, colIndex)
                dayOfMonthLbl.Text = dayOfMonthLbl.Name
                dayOfMonthLbl.Font = New Font("Segoe UI", 9, FontStyle.Regular)
                dayOfMonthLbl.Location = New Point(5, 5)
                dayOfMonthLbl.AutoSize = True
                AddHandler dayOfMonthLbl.MouseDoubleClick, AddressOf Day_DoubleClick
                dayPanel.Controls.Add(dayOfMonthLbl)

                Select Case rowIndex
                    Case 0
                        DaysRow0Container.Controls.Add(dayPanel)
                    Case 1
                        DaysRow1Container.Controls.Add(dayPanel)
                    Case 2
                        DaysRow2Container.Controls.Add(dayPanel)
                    Case 3
                        DaysRow3Container.Controls.Add(dayPanel)
                    Case 4
                        DaysRow4Container.Controls.Add(dayPanel)
                    Case 5
                        DaysRow5Container.Controls.Add(dayPanel)
                End Select
            Next
        Next
    End Sub

    Private Sub SizeDaysControls()
        SizeWidthEqually(DaysRow0Container)
        SizeWidthEqually(DaysRow1Container)
        SizeWidthEqually(DaysRow2Container)
        SizeWidthEqually(DaysRow3Container)
        SizeWidthEqually(DaysRow4Container)
        SizeWidthEqually(DaysRow5Container)
    End Sub

    Private Sub PopulateCalendarInfo()
        Dim label As Control
        Dim labelName As String

        label = MonthYearContainer.Controls.Find("LblMonthYear", False).First
        label.Text = String.Format("{0} {1}", MonthName(CalendarInfo.Month), CalendarInfo.Year)

        For rowIndex = 0 To 5
            For colIndex = 0 To 6
                labelName = String.Format("LblDayOfMonth{0}{1}", rowIndex, colIndex)
                label = Me.Controls.Find(labelName, True).First
                label.Text = CalendarInfo.DayInMonth(rowIndex, colIndex)

                If CalendarInfo.IsActiveMonth(rowIndex, colIndex) Then
                    label.ForeColor = Color.Black
                Else
                    label.ForeColor = Color.Gray
                End If

                If CalendarInfo.IsToday(rowIndex, colIndex) Then
                    label.ForeColor = Color.Red
                End If
            Next
        Next
    End Sub

#End Region

#Region "Database Methods"

    Private Sub LoadNotesFromDatabase()
        Try
            Using connection As SQLiteConnection = DbConnection.GetSQLiteConnection()
                ' First day in calendar
                Dim startDate = CalendarInfo.DateInYear(0, 0)
                ' Last day in calendar
                Dim endDate = CalendarInfo.DateInYear(5, 6)

                Dim command As New SQLiteCommand(
                    "SELECT * FROM Task WHERE Date BETWEEN @startDate AND @endDate",
                    connection)

                command.Parameters.AddWithValue("@startDate", startDate.ToString("yyyy-MM-dd"))
                command.Parameters.AddWithValue("@endDate", endDate.ToString("yyyy-MM-dd"))

                Using reader As SQLiteDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim taskDate As DateTime
                        If DateTime.TryParse(reader("Date").ToString(), taskDate) Then
                            Dim taskName As String = reader("todoname").ToString()

                            ' Add to our lists for display
                            Notes.Add(taskName)
                            NotesDates.Add(taskDate)
                        End If
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

            Using connection As SQLiteConnection = DbConnection.GetSQLiteConnection()
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
            Using connection As SQLiteConnection = DbConnection.GetSQLiteConnection()
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

    Private Sub CheckForAlarms()
        Try
            Using connection As SQLiteConnection = DbConnection.GetConnection()
                ' First check if has_alarm column exists
                Dim colCmd As New SQLiteCommand("PRAGMA table_info(Task)", connection)
                Dim colReader As SQLiteDataReader = colCmd.ExecuteReader()

                Dim hasAlarmCol As Boolean = False
                Dim hasAlarmTimeCol As Boolean = False
                Dim hasAlarmSoundCol As Boolean = False

                While colReader.Read()
                    Dim colName As String = colReader("name").ToString().ToLower()
                    If colName = "has_alarm" Then hasAlarmCol = True
                    If colName = "alarm_time" Then hasAlarmTimeCol = True
                    If colName = "alarm_sound" Then hasAlarmSoundCol = True
                End While
                colReader.Close()

                ' Only proceed if the required columns exist
                If hasAlarmCol AndAlso hasAlarmTimeCol Then
                    ' Get current time
                    Dim currentTime As DateTime = DateTime.Now
                    Dim currentTimeString As String = currentTime.ToString("yyyy-MM-dd HH:mm")

                    ' Find alarms that should trigger now (within the minute)
                    Dim command As New SQLiteCommand(
                    "SELECT * FROM Task WHERE has_alarm = 1 AND strftime('%Y-%m-%d %H:%M', alarm_time) = @currentTime",
                    connection)

                    command.Parameters.AddWithValue("@currentTime", currentTimeString)

                    Using reader As SQLiteDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim taskName As String = reader("todoname").ToString()
                            Dim taskDesc As String = If(reader("Comment") IsNot DBNull.Value, reader("Comment").ToString(), "")

                            ' Get sound file if specified
                            Dim soundFile As String = "default.wav"
                            If hasAlarmSoundCol AndAlso Not IsDBNull(reader("alarm_sound")) Then
                                soundFile = reader("alarm_sound").ToString()
                            End If

                            ' Show notification
                            ShowAlarmNotification(taskName, taskDesc)

                            ' Play sound
                            PlayAlarmSound(soundFile)
                        End While
                    End Using
                End If
            End Using
        Catch ex As Exception
            ' Log error but don't show message box as this runs in background
            Console.WriteLine("Error checking alarms: " & ex.Message)
        End Try
    End Sub

#End Region

#Region "Display Methods"

    Private Sub ShowMonthNotes()
        Dim columnIndex As Integer
        Dim rowIndex As Integer
        Dim noteIndex As Integer = 0
        Dim panel As Panel
        Dim label As Label
        Dim panelName As String
        Dim searchDate As DateTime
        Dim endingSearchDate As DateTime

        searchDate = CalendarInfo.DateInYear(0, 0) 'first date in grid
        endingSearchDate = CalendarInfo.DateInYear(5, 6) 'last date in grid

        While searchDate <= endingSearchDate
            noteIndex = NotesDates.FindIndex(Function(x) x = searchDate)

            If noteIndex > -1 Then
                columnIndex = CalendarInfo.DateColumn(searchDate)
                rowIndex = CalendarInfo.DateRow(searchDate)
                panelName = String.Format("PnlDay{0}{1}", rowIndex, columnIndex)
                panel = Controls.Find(panelName, True).FirstOrDefault()

                If panel IsNot Nothing Then
                    label = New Label
                    label.Name = String.Format("LblNote{0}{1}", rowIndex, columnIndex)
                    label.Tag = noteIndex 'use noteIndex as tag id
                    label.BackColor = Color.LightGreen
                    label.Font = New Font("Segoe UI", 10, FontStyle.Regular)
                    label.ContextMenuStrip = ContextMenuStrip1 'assign context menu
                    label.Width = panel.Width

                    label.Text = Notes(noteIndex)
                    label.TextAlign = ContentAlignment.MiddleCenter
                    label.Location = New Point(0, 25)
                    AddHandler label.MouseDoubleClick, AddressOf Day_DoubleClick 'doubleclick
                    panel.Controls.Add(label)
                End If
            End If

            searchDate = searchDate.AddDays(1)
        End While
    End Sub

    Private Sub RemoveMonthNotes()
        ' Remove all note labels from the calendar
        For rowIndex = 0 To 5
            For colIndex = 0 To 6
                Dim panelName As String = String.Format("PnlDay{0}{1}", rowIndex, colIndex)
                Dim panel As Panel = Controls.Find(panelName, True).FirstOrDefault()

                If panel IsNot Nothing Then
                    ' Find all note labels (they start with "LblNote")
                    Dim controlsToRemove As New List(Of Control)

                    For Each ctrl As Control In panel.Controls
                        If TypeOf ctrl Is Label AndAlso ctrl.Name.StartsWith("LblNote") Then
                            controlsToRemove.Add(ctrl)
                        End If
                    Next

                    ' Remove and dispose them
                    For Each ctrl As Control In controlsToRemove
                        panel.Controls.Remove(ctrl)
                        ctrl.Dispose()
                    Next
                End If
            Next
        Next
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

            Using connection As SQLiteConnection = DbConnection.GetSQLiteConnection()
                ' First check if alarm columns exist
                Dim colCmd As New SQLiteCommand("PRAGMA table_info(Task)", connection)
                Dim colReader As SQLiteDataReader = colCmd.ExecuteReader()

                Dim hasAlarmCol As Boolean = False
                Dim hasAlarmTimeCol As Boolean = False

                While colReader.Read()
                    Dim colName As String = colReader("name").ToString().ToLower()
                    If colName = "has_alarm" Then hasAlarmCol = True
                    If colName = "alarm_time" Then hasAlarmTimeCol = True
                End While
                colReader.Close()

                ' Now proceed with task loading
                Dim command As New SQLiteCommand(
                    "SELECT * FROM Task WHERE Date = @date",
                    connection)

                command.Parameters.AddWithValue("@date", selectedDate.ToString("yyyy-MM-dd"))

                Using reader As SQLiteDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim taskName As String = reader("todoname").ToString()
                        Dim category As String = reader("category").ToString()

                        Dim hasAlarm As Boolean = False
                        Dim alarmTime As String = ""

                        ' Use the column information we gathered earlier
                        If hasAlarmCol Then
                            hasAlarm = Convert.ToBoolean(reader("has_alarm"))
                            If hasAlarm AndAlso hasAlarmTimeCol AndAlso Not IsDBNull(reader("alarm_time")) Then
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

#End Region

#Region "Task Management Methods"

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
                Using connection As SQLiteConnection = DbConnection.GetConnection()
                    Dim command As New SQLiteCommand(
                        "DELETE FROM Task WHERE Date = @date AND todoname = @taskName",
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

#End Region

#Region "Event Handlers"

    Private Sub AlarmTimer_Tick(sender As Object, e As EventArgs) Handles AlarmTimer.Tick
        CheckForAlarms()
    End Sub

    Private Sub Day_DoubleClick(ByVal sender As Object, e As MouseEventArgs)
        Dim rowIndex As Integer
        Dim columnIndex As Integer
        Dim control As Control = TryCast(sender, Control)

        If control Is Nothing Then Return

        rowIndex = ExtractFirstDigit(control.Name)
        columnIndex = ExtractLastDigit(control.Name)

        Try
            Dim selectedDate As DateTime = CalendarInfo.DateInYear(rowIndex, columnIndex)
            ' Display the tasks panel instead of directly showing the task form
            DisplayTasksForDate(selectedDate)
        Catch ex As Exception
            Console.WriteLine("Error in Day_DoubleClick: " & ex.Message)
        End Try
    End Sub

#End Region

#Region "Helper Methods"

    Private Function ExtractFirstDigit(controlName As String) As Integer
        ' Extract the first digit from a control name (e.g. "PnlDay23" would return 2)
        For i As Integer = 0 To controlName.Length - 1
            If Char.IsDigit(controlName(i)) Then
                Return Integer.Parse(controlName(i).ToString())
            End If
        Next
        Return 0
    End Function

    Private Function ExtractLastDigit(controlName As String) As Integer
        ' Extract the last digit from a control name (e.g. "PnlDay23" would return 3)
        For i As Integer = controlName.Length - 1 To 0 Step -1
            If Char.IsDigit(controlName(i)) Then
                Return Integer.Parse(controlName(i).ToString())
            End If
        Next
        Return 0
    End Function

    Private Sub ShowAlarmNotification(taskName As String, taskDesc As String)
        Try
            ' Create and show notification form
            Dim notification As New AlarmNotification(taskName, taskDesc)
            notification.Show()
        Catch ex As Exception
            ' Fallback to simple message box if notification form fails
            MessageBox.Show("Task Reminder: " & taskName & vbCrLf & taskDesc,
                       "Task Alarm", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
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


#End Region
End Class

