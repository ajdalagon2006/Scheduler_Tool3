Imports System.Data.SQLite
Imports System.Media
Imports NAudio.Wave

Public Class calendar
    'Modified to add/edit notes to calendar using a form
    Private CalendarInfo As MonthlyCalendarInfo
    Private Notes As List(Of String)
    Private NotesDates As List(Of DateTime)
    Private NotesCategories As List(Of String)
    Private Holidays As Dictionary(Of DateTime, String)
    Private CurrentCategoryFilter As String = "All Categories"
    Private ShowOnlyUpcoming As Boolean = True
    Private ShowHolidaysFlag As Boolean = True
    Private DefaultSoundFile As String = "default.wav"
    Private IsInitialized As Boolean = False
    Private ActiveSoundPlayer As SoundPlayer = Nothing
    Private ActiveMediaPlayer As Object = Nothing
    Private DefaultSoundEnabled As Boolean = True
    Private WithEvents TaskCleanupTimer As New Timer()

#Region "Form Initialization"



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        CalendarInfo = New MonthlyCalendarInfo(Now.Year, Now.Month)
        Notes = New List(Of String)
        NotesDates = New List(Of DateTime)
        NotesCategories = New List(Of String)
        Holidays = New Dictionary(Of DateTime, String)

        ' Update database schema first - adds alarm fields and tags support
        DbConnection.UpdateDatabaseSchema()
        DbConnection.UpdateDatabaseSchemaForTags()

        ' Set up the UI
        SizeContainers()
        CreateMonthYearLabel()
        SizeMonthYearLabel()
        CreateDaysOfWeekLabels()
        SizeDaysOfWeekLabels()
        CreateDaysControls()
        SizeDaysControls()
        PopulateCalendarInfo()

        ' Set default values for filters
        cmbCategoryFilter.SelectedIndex = 0 ' All Categories
        chkShowUpcoming.Checked = True
        chkShowHolidays.Checked = True

        ' Load data
        LoadHolidays()
        LoadNotesFromDatabase()
        RefreshUpcomingEventsPanel()

        ' Set up the alarm timer
        AlarmTimer.Interval = 60000 ' Check every minute
        AlarmTimer.Start()

        ' Update status bar
        UpdateStatusBar("Calendar loaded successfully")
        ' Setup auto-delete timer (runs every 5 minutes)

        TaskCleanupTimer.Interval = 300000 ' 5 minutes
        TaskCleanupTimer.Enabled = True

        ' Run once at startup to clean existing completed tasks
        DeleteCompletedTasks()
    End Sub

    Private Sub UpdateStatusBar(message As String)
        lblStatus.Text = message
    End Sub



#End Region

#Region "UI Layout Methods"

    Private Sub calendar_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        ' Resize all UI elements to fit the new window size
        SizeContainers()
        SizeMonthYearLabel()
        SizeDaysOfWeekLabels()
        SizeDaysControls()

        ' Re-center the tasks panel if it's visible
        If TasksPanel.Visible Then
            TasksPanel.Location = New Point((ClientSize.Width - TasksPanel.Width) \ 2,
                                       (ClientSize.Height - TasksPanel.Height) \ 2)
        End If
    End Sub

    Private Sub SizeContainers()
        ' Resize the form to accommodate the side panel for upcoming events
        Me.Width = 1000

        Dim daysHeight As Integer
        Dim daysYStart As Integer

        MonthYearContainer.Size = New Size(ClientSize.Width - 220, 55)
        MonthYearContainer.Location = New Point(0, 0)
        DaysOfWeekContainer.Size = New Size(ClientSize.Width - 220, 30)
        DaysOfWeekContainer.Location = New Point(0, MonthYearContainer.Height)

        daysHeight = (ClientSize.Height - MonthYearContainer.Height - DaysOfWeekContainer.Height - statusStrip1.Height) / 6
        daysYStart = MonthYearContainer.Height + DaysOfWeekContainer.Height

        DaysRow0Container.Size = New Size(ClientSize.Width - 220, daysHeight)
        DaysRow0Container.Location = New Point(0, daysYStart)
        DaysRow1Container.Size = New Size(ClientSize.Width - 220, daysHeight)
        DaysRow1Container.Location = New Point(0, daysYStart + (daysHeight))
        DaysRow2Container.Size = New Size(ClientSize.Width - 220, daysHeight)
        DaysRow2Container.Location = New Point(0, daysYStart + (daysHeight * 2))
        DaysRow3Container.Size = New Size(ClientSize.Width - 220, daysHeight)
        DaysRow3Container.Location = New Point(0, daysYStart + (daysHeight * 3))
        DaysRow4Container.Size = New Size(ClientSize.Width - 220, daysHeight)
        DaysRow4Container.Location = New Point(0, daysYStart + (daysHeight * 4))
        DaysRow5Container.Size = New Size(ClientSize.Width - 220, daysHeight)
        DaysRow5Container.Location = New Point(0, daysYStart + (daysHeight * 5))

        ' Position the upcoming events panel
        pnlCalendarControls.Location = New Point(ClientSize.Width - 205, 9)
        lblUpcomingEvents.Location = New Point(ClientSize.Width - 205, 112)
        pnlUpcomingEvents.Location = New Point(ClientSize.Width - 205, 134)
        pnlUpcomingEvents.Height = ClientSize.Height - 134 - statusStrip1.Height
    End Sub

    Private Sub CreateMonthYearLabel()
        ' Now handled by designer
        lblCurrentMonth.Text = String.Format("{0} {1}", MonthName(CalendarInfo.Month), CalendarInfo.Year)
    End Sub

    Private Sub SizeMonthYearLabel()
        ' Now handled by designer
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
        ' Update month-year display
        lblCurrentMonth.Text = String.Format("{0} {1}", MonthName(CalendarInfo.Month), CalendarInfo.Year)

        For rowIndex = 0 To 5
            For colIndex = 0 To 6
                Dim labelName As String = String.Format("LblDayOfMonth{0}{1}", rowIndex, colIndex)
                Dim label As Label = Me.Controls.Find(labelName, True).First

                label.Text = CalendarInfo.DayInMonth(rowIndex, colIndex)

                If CalendarInfo.IsActiveMonth(rowIndex, colIndex) Then
                    label.ForeColor = Color.Black
                Else
                    label.ForeColor = Color.Gray
                End If

                If CalendarInfo.IsToday(rowIndex, colIndex) Then
                    label.ForeColor = Color.Red
                    label.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                Else
                    label.Font = New Font("Segoe UI", 9, FontStyle.Regular)
                End If
            Next
        Next
    End Sub

#End Region

#Region "Database Methods"


    Private Sub LoadNotesFromDatabase(Optional filterCategory As String = "All Categories")
        Try
            ' Check if CalendarInfo is initialized
            If CalendarInfo Is Nothing Then
                ' Initialize CalendarInfo with current month/year
                CalendarInfo = New MonthlyCalendarInfo(Now.Year, Now.Month)
                UpdateStatusBar("Re-initializing calendar information")
            End If

            ' Clear existing data
            If Notes Is Nothing Then
                Notes = New List(Of String)
            Else
                Notes.Clear()
            End If

            If NotesDates Is Nothing Then
                NotesDates = New List(Of DateTime)
            Else
                NotesDates.Clear()
            End If

            If NotesCategories Is Nothing Then
                NotesCategories = New List(Of String)
            Else
                NotesCategories.Clear()
            End If

            RemoveMonthNotes()

            Using connection As SQLiteConnection = DbConnection.GetSQLiteConnection()
                ' First day in calendar
                Dim startDate = CalendarInfo.DateInYear(0, 0)
                ' Last day in calendar
                Dim endDate = CalendarInfo.DateInYear(5, 6)

                ' [Rest of the method remains the same]

            End Using

            ' Show the notes on calendar
            ShowMonthNotes()

            ' Refresh the upcoming events panel
            RefreshUpcomingEventsPanel()

            UpdateStatusBar(String.Format("Loaded {0} events", Notes.Count))
        Catch ex As Exception
            ' Table might not exist yet or other error
            Console.WriteLine("Error loading notes: " & ex.Message)
            UpdateStatusBar("Error loading events: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadHolidays()
        Try
            If Not ShowHolidaysFlag Then
                ' Skip loading holidays if not showing them
                Return
            End If

            ' Check if Holidays is initialized
            If Holidays Is Nothing Then
                Holidays = New Dictionary(Of DateTime, String)
                UpdateStatusBar("Re-initializing holidays collection")
            Else
                ' Clear existing holidays
                Holidays.Clear()
            End If

            ' Add default holidays
            AddDefaultHolidays()

            ' Rest of method remains the same...

        Catch ex As Exception
            ' Table might not exist yet
            Console.WriteLine("Error loading holidays: " & ex.Message)
            UpdateStatusBar("Error loading holidays: " & ex.Message)
        End Try
    End Sub

    Private Sub AddDefaultHolidays()
        Try
            Using connection As SQLiteConnection = DbConnection.GetSQLiteConnection()
                ' Check if Holidays table exists
                Dim checkCmd = New SQLiteCommand(
                "SELECT name FROM sqlite_master WHERE type='table' AND name='Holidays'",
                connection)

                If checkCmd.ExecuteScalar() Is Nothing Then
                    ' Create Holidays table if it doesn't exist
                    Dim createCmd = New SQLiteCommand(
                    "CREATE TABLE Holidays (id INTEGER PRIMARY KEY AUTOINCREMENT, " &
                    "date TEXT, name TEXT, is_recurring INTEGER DEFAULT 0)",
                    connection)
                    createCmd.ExecuteNonQuery()
                End If

                ' Current year - force to 2025 as per user's specification
                Dim currentYear As Integer = 2025

                ' Clear existing holidays for clean reload
                Dim clearCmd = New SQLiteCommand("DELETE FROM Holidays", connection)
                clearCmd.ExecuteNonQuery()

                ' List of holidays - specifically including the user's requested holidays
                Dim allHolidays As New List(Of Tuple(Of DateTime, String))()

                ' April holidays - user requested these specific ones
                allHolidays.Add(New Tuple(Of DateTime, String)(New DateTime(2025, 4, 16), "	The Day of Valor (Regular Holiday)"))
                allHolidays.Add(New Tuple(Of DateTime, String)(New DateTime(2025, 4, 17), "	Maundy Thursday (Regular Holiday)"))
                allHolidays.Add(New Tuple(Of DateTime, String)(New DateTime(2025, 4, 18), "Good Friday (Regular Holiday)"))
                allHolidays.Add(New Tuple(Of DateTime, String)(New DateTime(2025, 4, 19), "Black Saturday (Special Non-working Holiday)"))
                allHolidays.Add(New Tuple(Of DateTime, String)(New DateTime(2025, 4, 20), "Easter Sunday (Observance)"))

                ' May holiday - user requested this specific one
                allHolidays.Add(New Tuple(Of DateTime, String)(New DateTime(2025, 5, 1), "Labor Day (Regular Holiday)"))

                ' Other common holidays
                allHolidays.Add(New Tuple(Of DateTime, String)(New DateTime(2025, 1, 1), "New Year's Day"))
                allHolidays.Add(New Tuple(Of DateTime, String)(New DateTime(2025, 6, 12), "Independence Day"))
                allHolidays.Add(New Tuple(Of DateTime, String)(New DateTime(2025, 8, 30), "National Heroes Day"))
                allHolidays.Add(New Tuple(Of DateTime, String)(New DateTime(2025, 11, 1), "All Saints' Day"))
                allHolidays.Add(New Tuple(Of DateTime, String)(New DateTime(2025, 12, 25), "Christmas Day"))
                allHolidays.Add(New Tuple(Of DateTime, String)(New DateTime(2025, 12, 30), "Rizal Day"))

                ' Insert holidays
                For Each holiday In allHolidays
                    Dim command As New SQLiteCommand(
                    "INSERT INTO Holidays (date, name, is_recurring) VALUES (@date, @name, 1)",
                    connection)

                    command.Parameters.AddWithValue("@date", holiday.Item1.ToString("yyyy-MM-dd"))
                    command.Parameters.AddWithValue("@name", holiday.Item2)
                    command.ExecuteNonQuery()

                    ' Add to in-memory collection
                    Holidays(holiday.Item1) = holiday.Item2
                Next

                ' Force refresh holiday display
                HighlightHolidays()

                ' Log success
                Console.WriteLine($"Successfully added {allHolidays.Count} holidays to calendar")
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
                            Dim category As String = If(reader("category") IsNot DBNull.Value, reader("category").ToString(), "")

                            ' Get sound file if specified
                            Dim soundFile As String = "default.wav"
                            If hasAlarmSoundCol AndAlso Not IsDBNull(reader("alarm_sound")) Then
                                soundFile = reader("alarm_sound").ToString()
                            End If

                            ' Show notification
                            ShowAlarmNotification(taskName, taskDesc, category)

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

    Private Sub CleanupCompletedTasks()
        Try
            ' Get current time
            Dim currentTime As DateTime = DateTime.Now

            ' Open database connection
            Using connection As SQLiteConnection = DbConnection.GetSQLiteConnection()
                ' Find tasks that have ended (compare with current time)
                Dim query As String = "SELECT TaskID, TaskDate, TaskTime, TaskDuration, Title FROM Tasks " &
                                 "WHERE TaskDate || ' ' || TaskTime < @currentDateTime"

                Using command As New SQLiteCommand(query, connection)
                    ' Format current time as expected in the database
                    command.Parameters.AddWithValue("@currentDateTime", currentTime.ToString("yyyy-MM-dd HH:mm"))

                    ' Get tasks to delete
                    Dim tasksToDelete As New List(Of Integer)

                    Using reader As SQLiteDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim taskId As Integer = reader.GetInt32(0)
                            Dim title As String = reader.GetString(4)

                            ' Add to deletion list
                            tasksToDelete.Add(taskId)

                            ' Log for debugging
                            Console.WriteLine($"Auto-deleting completed task: {title} (ID: {taskId})")
                        End While
                    End Using

                    ' Delete the tasks
                    If tasksToDelete.Count > 0 Then
                        For Each taskId As Integer In tasksToDelete
                            DeleteTask(taskId)
                        Next

                        ' Update UI
                        UpdateStatusBar($"{tasksToDelete.Count} completed tasks automatically removed")

                        ' Refresh calendar display
                        LoadNotesFromDatabase()
                        RefreshUpcomingEventsPanel()
                    End If
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error during auto-cleanup: " & ex.Message)
        End Try
    End Sub

    ' Method to delete a single task
    Private Sub DeleteTask(taskId As Integer)
        Try
            Using connection As SQLiteConnection = DbConnection.GetSQLiteConnection()
                Dim deleteQuery As String = "DELETE FROM Tasks WHERE TaskID = @taskId"

                Using command As New SQLiteCommand(deleteQuery, connection)
                    command.Parameters.AddWithValue("@taskId", taskId)
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine($"Error deleting task {taskId}: {ex.Message}")
        End Try
    End Sub

    Private Sub AddCustomHoliday(holidayDate As DateTime, holidayName As String)
        Try
            Using connection As SQLiteConnection = DbConnection.GetSQLiteConnection()
                Dim command As New SQLiteCommand(
                "INSERT OR REPLACE INTO Holidays (date, name, is_recurring) VALUES (@date, @name, 1)",
                connection)

                command.Parameters.AddWithValue("@date", holidayDate.ToString("yyyy-MM-dd"))
                command.Parameters.AddWithValue("@name", holidayName)
                command.ExecuteNonQuery()

                ' Also add to in-memory collection for immediate display
                Holidays(holidayDate) = holidayName

                ' Refresh the calendar display
                HighlightHolidays()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error adding holiday: {ex.Message}", "Error",
                      MessageBoxButtons.OK, MessageBoxIcon.Error)
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

                    ' Set color based on category
                    Dim category As String = NotesCategories(noteIndex)
                    Select Case category.ToLower()
                        Case "personal"
                            label.BackColor = Color.LightBlue
                        Case "deadline"
                            label.BackColor = Color.LightCoral
                        Case "holiday"
                            label.BackColor = Color.LightYellow
                        Case "meeting"
                            label.BackColor = Color.LightGreen
                        Case Else
                            label.BackColor = Color.LightGray
                    End Select

                    label.ForeColor = Color.Black
                    label.Font = New Font("Segoe UI", 8, FontStyle.Regular)
                    label.ContextMenuStrip = ContextMenuStrip1 'assign context menu
                    label.Width = panel.Width

                    ' Truncate text if too long
                    Dim noteText As String = Notes(noteIndex)
                    If noteText.Length > 15 Then
                        noteText = noteText.Substring(0, 12) & "..."
                    End If
                    label.Text = noteText

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
        ' First clear any existing holiday indicators
        RemoveHolidayIndicators()

        If Not ShowHolidaysFlag Then
            Return
        End If

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
                    ' Make the day number red and bold
                    For Each ctrl As Control In panel.Controls
                        If TypeOf ctrl Is Label AndAlso ctrl.Name.StartsWith("LblDayOfMonth") Then
                            Dim dayLabel As Label = DirectCast(ctrl, Label)
                            dayLabel.ForeColor = Color.Red
                            dayLabel.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                            Exit For
                        End If
                    Next

                    ' Change the panel background color for holidays
                    panel.BackColor = Color.FromArgb(255, 235, 235)  ' Light red background

                    ' Create a holiday label at the bottom
                    Dim holidayLabel As New Label()
                    holidayLabel.Name = String.Format("LblHolidayText{0}{1}", row, col)
                    holidayLabel.Text = "HOLIDAY"
                    holidayLabel.ForeColor = Color.Red
                    holidayLabel.BackColor = Color.Transparent
                    holidayLabel.Font = New Font("Segoe UI", 7, FontStyle.Bold)
                    holidayLabel.Size = New Size(panel.Width, 15)
                    holidayLabel.Location = New Point(0, panel.Height - 15)
                    holidayLabel.TextAlign = ContentAlignment.MiddleCenter
                    panel.Controls.Add(holidayLabel)

                    ' Create a holiday indicator
                    Dim indicatorLabel As New Label()
                    indicatorLabel.Name = String.Format("LblHoliday{0}{1}", row, col)
                    indicatorLabel.Text = "🎉" ' Holiday emoji
                    indicatorLabel.ForeColor = Color.Red
                    indicatorLabel.Font = New Font("Segoe UI", 12, FontStyle.Bold)
                    indicatorLabel.Size = New Size(25, 25)
                    indicatorLabel.Location = New Point(panel.Width - 27, 2)
                    indicatorLabel.TextAlign = ContentAlignment.MiddleCenter

                    ' Add tooltip for holiday name
                    Dim toolTip As New ToolTip()
                    toolTip.SetToolTip(indicatorLabel, holidayName)
                    toolTip.SetToolTip(holidayLabel, holidayName)

                    panel.Controls.Add(indicatorLabel)
                End If
            End If
        Next
    End Sub

    Private Sub RemoveHolidayIndicators()
        ' Remove all holiday indicators
        For rowIndex = 0 To 5
            For colIndex = 0 To 6
                Dim panelName As String = String.Format("PnlDay{0}{1}", rowIndex, colIndex)
                Dim panel As Panel = Controls.Find(panelName, True).FirstOrDefault()

                If panel IsNot Nothing Then
                    ' Reset background color
                    Select Case rowIndex
                        Case 0
                            panel.BackColor = DaysRow0Container.BackColor
                        Case 1
                            panel.BackColor = DaysRow1Container.BackColor
                        Case 2
                            panel.BackColor = DaysRow2Container.BackColor
                        Case 3
                            panel.BackColor = DaysRow3Container.BackColor
                        Case 4
                            panel.BackColor = DaysRow4Container.BackColor
                        Case 5
                            panel.BackColor = DaysRow5Container.BackColor
                    End Select

                    ' Find all holiday indicators (they start with "LblHoliday")
                    Dim controlsToRemove As New List(Of Control)

                    For Each ctrl As Control In panel.Controls
                        If TypeOf ctrl Is Label AndAlso ctrl.Name.StartsWith("LblHoliday") Then
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
            ' Use this dictionary to track unique task names to prevent duplicates
            Dim uniqueTasks As New Dictionary(Of String, Tuple(Of String, String, Boolean, String))()

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

                        ' Skip if we've already added this task - fixes duplication
                        If uniqueTasks.ContainsKey(taskName) Then
                            Continue While
                        End If

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

                        ' Add to unique tasks dictionary
                        uniqueTasks.Add(taskName, New Tuple(Of String, String, Boolean, String)(taskName, category, hasAlarm, alarmTime))
                    End While
                End Using
            End Using

            ' Display tasks in the panel
            Dim yPosition As Integer = If(Holidays.ContainsKey(selectedDate), 70, 50)

            If uniqueTasks.Count = 0 Then
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
                For Each task In uniqueTasks.Values
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

    Private Sub RefreshUpcomingEventsPanel()
        Try
            ' Clear existing events
            While pnlUpcomingEvents.Controls.Count > 0
                pnlUpcomingEvents.Controls(0).Dispose()
            End While

            ' Dictionary to track unique events and prevent duplicates
            Dim uniqueEvents As New Dictionary(Of String, Tuple(Of String, DateTime, String))()

            Using connection As SQLiteConnection = DbConnection.GetSQLiteConnection()
                ' Get current date
                Dim currentDate As DateTime = DateTime.Now.Date

                ' Get tasks for the next 7 days
                Dim command As New SQLiteCommand(
                "SELECT * FROM Task WHERE Date >= @startDate AND Date <= @endDate ORDER BY Date",
                connection)

                command.Parameters.AddWithValue("@startDate", currentDate.ToString("yyyy-MM-dd"))
                command.Parameters.AddWithValue("@endDate", currentDate.AddDays(7).ToString("yyyy-MM-dd"))

                Using reader As SQLiteDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim taskName As String = reader("todoname").ToString()
                        Dim taskDate As DateTime = DateTime.Parse(reader("Date").ToString())
                        Dim category As String = reader("category").ToString()

                        ' Create a unique key using date and task name
                        Dim uniqueKey As String = $"{taskDate.ToString("yyyy-MM-dd")}_{taskName}"

                        ' Only add if this is a unique task (prevents duplicates)
                        If Not uniqueEvents.ContainsKey(uniqueKey) Then
                            uniqueEvents.Add(uniqueKey, New Tuple(Of String, DateTime, String)(taskName, taskDate, category))
                        End If
                    End While
                End Using
            End Using

            ' Display the events in the panel
            Dim yPos As Integer = 10

            If uniqueEvents.Count = 0 Then
                ' Show "No upcoming events" message
                Dim lblNoEvents As New Label()
                lblNoEvents.Text = "No upcoming events"
                lblNoEvents.AutoSize = True
                lblNoEvents.Location = New Point(10, yPos)
                pnlUpcomingEvents.Controls.Add(lblNoEvents)
            Else
                ' Group events by date
                Dim eventsByDate = From ev In uniqueEvents.Values
                                   Group By dateKey = ev.Item2.Date Into dateGroup = Group
                                   Order By dateKey

                ' Process each date
                For Each dateGroup In eventsByDate
                    ' Add date header
                    Dim lblDate As New Label()
                    lblDate.Text = dateGroup.dateKey.ToString("dddd, MMM d")
                    lblDate.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                    lblDate.AutoSize = True
                    lblDate.Location = New Point(10, yPos)
                    pnlUpcomingEvents.Controls.Add(lblDate)
                    yPos += 22

                    ' Add each event for this date
                    For Each ev In dateGroup.dateGroup
                        ' Task name
                        Dim lblTask As New Label()
                        lblTask.Text = ev.Item1
                        lblTask.AutoSize = True
                        lblTask.Location = New Point(15, yPos)
                        pnlUpcomingEvents.Controls.Add(lblTask)
                        yPos += 18

                        ' Category
                        Dim lblCategory As New Label()
                        lblCategory.Text = ev.Item3
                        lblCategory.ForeColor = Color.Gray
                        lblCategory.AutoSize = True
                        lblCategory.Location = New Point(20, yPos)
                        pnlUpcomingEvents.Controls.Add(lblCategory)
                        yPos += 25  ' Larger gap after category
                    Next
                Next
            End If

        Catch ex As Exception
            ' Log error but don't show message as this refreshes in background
            Console.WriteLine("Error refreshing upcoming events: " & ex.Message)
        End Try
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
            NotesCategories.Clear()
            RemoveMonthNotes()
            LoadNotesFromDatabase(CurrentCategoryFilter)
            DisplayTasksForDate(selectedDate)

            ' Refresh upcoming events panel
            RefreshUpcomingEventsPanel()
        End If
    End Sub

    Private Sub EditTask(selectedDate As DateTime, taskName As String)
        Dim taskForm As New Task(selectedDate, taskName)
        taskForm.ShowDialog()

        If taskForm.DataSaved Then
            ' Refresh tasks display
            Notes.Clear()
            NotesDates.Clear()
            NotesCategories.Clear()
            RemoveMonthNotes()
            LoadNotesFromDatabase(CurrentCategoryFilter)
            DisplayTasksForDate(selectedDate)

            ' Refresh upcoming events panel
            RefreshUpcomingEventsPanel()
        End If
    End Sub

    Private Sub DeleteTask(selectedDate As DateTime, taskName As String)
        If MessageBox.Show("Are you sure you want to delete this task?", "Confirm Delete",
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try
                Using connection As SQLiteConnection = DbConnection.GetConnection()
                    ' First get the task ID to delete associated tags
                    Dim getIdCmd As New SQLiteCommand(
                        "SELECT id FROM Task WHERE Date = @date AND todoname = @taskName",
                        connection)

                    getIdCmd.Parameters.AddWithValue("@date", selectedDate.ToString("yyyy-MM-dd"))
                    getIdCmd.Parameters.AddWithValue("@taskName", taskName)

                    Dim taskId As Object = getIdCmd.ExecuteScalar()

                    If taskId IsNot Nothing Then
                        ' Delete task tags first
                        Dim deleteTagsCmd As New SQLiteCommand(
                            "DELETE FROM TaskTags WHERE task_id = @taskId",
                            connection)
                        deleteTagsCmd.Parameters.AddWithValue("@taskId", taskId)
                        deleteTagsCmd.ExecuteNonQuery()
                    End If

                    ' Now delete the task
                    Dim deleteTaskCmd As New SQLiteCommand(
                        "DELETE FROM Task WHERE Date = @date AND todoname = @taskName",
                        connection)

                    deleteTaskCmd.Parameters.AddWithValue("@date", selectedDate.ToString("yyyy-MM-dd"))
                    deleteTaskCmd.Parameters.AddWithValue("@taskName", taskName)
                    deleteTaskCmd.ExecuteNonQuery()
                End Using

                ' Refresh tasks display
                Notes.Clear()
                NotesDates.Clear()
                NotesCategories.Clear()
                RemoveMonthNotes()
                LoadNotesFromDatabase(CurrentCategoryFilter)
                DisplayTasksForDate(selectedDate)

                ' Refresh upcoming events panel
                RefreshUpcomingEventsPanel()

                UpdateStatusBar("Task deleted: " & taskName)
            Catch ex As Exception
                MessageBox.Show("Error deleting task: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                UpdateStatusBar("Error deleting task")
            End Try
        End If
    End Sub

    ' Simple method to delete completed tasks
    Private Sub DeleteCompletedTasks()
        Try
            Using connection As SQLiteConnection = DbConnection.GetSQLiteConnection()
                ' Find and delete tasks that have passed their time
                Dim query As String =
                "DELETE FROM Tasks WHERE datetime(TaskDate || ' ' || TaskTime) < datetime('now', 'localtime')"

                Using command As New SQLiteCommand(query, connection)
                    Dim rowsDeleted As Integer = command.ExecuteNonQuery()

                    ' Only update UI if tasks were actually deleted
                    If rowsDeleted > 0 Then
                        ' Refresh the calendar display
                        LoadNotesFromDatabase()
                        RefreshUpcomingEventsPanel()
                    End If
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Error auto-deleting tasks: " & ex.Message)
        End Try
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub TaskCleanupTimer_Tick(sender As Object, e As EventArgs) Handles TaskCleanupTimer.Tick
        DeleteCompletedTasks()
    End Sub

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
            UpdateStatusBar("Error displaying tasks")
        End Try
    End Sub

    Private Sub chkShowUpcoming_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowUpcoming.CheckedChanged
        ' Reload notes based on filter setting
        ShowOnlyUpcoming = chkShowUpcoming.Checked

        ' Add null checks before clearing collections
        If Notes Is Nothing Then
            Notes = New List(Of String)
        Else
            Notes.Clear()
        End If

        If NotesDates Is Nothing Then
            NotesDates = New List(Of DateTime)
        Else
            NotesDates.Clear()
        End If

        If NotesCategories Is Nothing Then
            NotesCategories = New List(Of String)
        Else
            NotesCategories.Clear()
        End If

        RemoveMonthNotes()
        LoadNotesFromDatabase(CurrentCategoryFilter)

        UpdateStatusBar(If(ShowOnlyUpcoming, "Showing only upcoming events", "Showing all events"))
    End Sub

    Private Sub chkShowHolidays_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowHolidays.CheckedChanged
        ' Toggle holiday display
        ShowHolidaysFlag = chkShowHolidays.Checked

        ' Clear and reload holidays
        RemoveHolidayIndicators()
        If ShowHolidaysFlag Then
            LoadHolidays()
            UpdateStatusBar("Showing holidays")
        Else
            Holidays.Clear()
            UpdateStatusBar("Hiding holidays")
        End If
    End Sub

    Private Sub cmbCategoryFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoryFilter.SelectedIndexChanged
        ' Update the filter and reload data
        CurrentCategoryFilter = cmbCategoryFilter.SelectedItem.ToString()
        Notes.Clear()
        NotesDates.Clear()
        NotesCategories.Clear()
        RemoveMonthNotes()
        LoadNotesFromDatabase(CurrentCategoryFilter)

        UpdateStatusBar("Filtering by category: " & CurrentCategoryFilter)
    End Sub

    Private Sub btnPrevMonth_Click(sender As Object, e As EventArgs) Handles btnPrevMonth.Click
        ' Navigate to previous month
        CalendarInfo = CalendarInfo.PreviousMonth()

        ' Clear and reload calendar data
        Notes.Clear()
        NotesDates.Clear()
        NotesCategories.Clear()
        RemoveMonthNotes()
        RemoveHolidayIndicators()
        PopulateCalendarInfo()
        LoadHolidays()
        LoadNotesFromDatabase(CurrentCategoryFilter)

        UpdateStatusBar("Navigated to " & MonthName(CalendarInfo.Month) & " " & CalendarInfo.Year)
    End Sub

    Private Sub btnNextMonth_Click(sender As Object, e As EventArgs) Handles btnNextMonth.Click
        ' Navigate to next month
        CalendarInfo = CalendarInfo.NextMonth()

        ' Clear and reload calendar data
        Notes.Clear()
        NotesDates.Clear()
        NotesCategories.Clear()
        RemoveMonthNotes()
        RemoveHolidayIndicators()
        PopulateCalendarInfo()
        LoadHolidays()
        LoadNotesFromDatabase(CurrentCategoryFilter)

        UpdateStatusBar("Navigated to " & MonthName(CalendarInfo.Month) & " " & CalendarInfo.Year)
    End Sub

    Private Sub EditEventToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditEventToolStripMenuItem.Click
        Try
            Dim label As Label = TryCast(ContextMenuStrip1.SourceControl, Label)
            If label IsNot Nothing AndAlso TypeOf label.Tag Is Integer Then
                Dim noteIndex As Integer = CInt(label.Tag)

                If noteIndex >= 0 AndAlso noteIndex < NotesDates.Count Then
                    Dim taskDate As DateTime = NotesDates(noteIndex)
                    Dim taskName As String = Notes(noteIndex)

                    EditTask(taskDate, taskName)
                End If
            End If
        Catch ex As Exception
            Console.WriteLine("Error editing event: " & ex.Message)
            UpdateStatusBar("Error editing event")
        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            Dim label As Label = TryCast(ContextMenuStrip1.SourceControl, Label)
            If label IsNot Nothing AndAlso TypeOf label.Tag Is Integer Then
                Dim noteIndex As Integer = CInt(label.Tag)

                If noteIndex >= 0 AndAlso noteIndex < NotesDates.Count Then
                    Dim taskDate As DateTime = NotesDates(noteIndex)
                    Dim taskName As String = Notes(noteIndex)

                    DeleteTask(taskDate, taskName)
                End If
            End If
        Catch ex As Exception
            Console.WriteLine("Error deleting event: " & ex.Message)
            UpdateStatusBar("Error deleting event")
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

    Private Sub ShowAlarmNotification(taskName As String, taskDesc As String, category As String)
        Try
            ' Create and show notification form
            Dim notification As New AlarmNotification(taskName, taskDesc)

            ' Set background color based on category
            Select Case category.ToLower()
                Case "personal"
                    notification.BackColor = Color.FromArgb(230, 242, 255) ' Light blue
                Case "deadline"
                    notification.BackColor = Color.FromArgb(255, 230, 230) ' Light red
                Case "holiday"
                    notification.BackColor = Color.FromArgb(255, 252, 220) ' Light yellow
                Case "meeting"
                    notification.BackColor = Color.FromArgb(230, 255, 230) ' Light green
            End Select

            notification.Show()
        Catch ex As Exception
            ' Fallback to simple message box if notification form fails
            MessageBox.Show("Task Reminder: " & taskName & vbCrLf & taskDesc,
                       "Task Alarm", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub PlayAlarmSound(soundFile As String)
        Try
            ' Stop any currently playing sounds first
            StopAlarmSound()

            If soundFile = "default.wav" OrElse Not System.IO.File.Exists(soundFile) Then
                ' Play system sound multiple times for emphasis
                For i As Integer = 0 To 2
                    My.Computer.Audio.PlaySystemSound(SystemSounds.Exclamation)
                    System.Threading.Thread.Sleep(800)
                Next
            Else
                ' Check file extension
                Dim fileExtension As String = System.IO.Path.GetExtension(soundFile).ToLower()

                If fileExtension = ".wav" Then
                    ' Play WAV file using SoundPlayer (can be stopped)
                    ActiveSoundPlayer = New SoundPlayer(soundFile)
                    ActiveSoundPlayer.PlayLooping() ' Play in a loop until explicitly stopped
                Else
                    ' For MP3 files, use Windows Media Player
                    Try
                        ActiveMediaPlayer = CreateObject("WMPlayer.OCX.7")
                        ActiveMediaPlayer.URL = soundFile
                        ActiveMediaPlayer.settings.setMode("loop", True) ' Loop playback
                        ActiveMediaPlayer.controls.play()
                    Catch ex As Exception
                        ' Fall back to system sound if WMP fails
                        My.Computer.Audio.PlaySystemSound(SystemSounds.Exclamation)
                    End Try
                End If
            End If
        Catch ex As Exception
            ' Last resort fallback
            My.Computer.Audio.PlaySystemSound(SystemSounds.Exclamation)
        End Try
    End Sub

    ' Add this new method to stop sounds
    Public Sub StopAlarmSound()
        ' Stop WAV player if active
        If ActiveSoundPlayer IsNot Nothing Then
            ActiveSoundPlayer.Stop()
            ActiveSoundPlayer.Dispose()
            ActiveSoundPlayer = Nothing
        End If

        ' Stop media player if active
        If ActiveMediaPlayer IsNot Nothing Then
            Try
                ActiveMediaPlayer.controls.stop()
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ActiveMediaPlayer)
            Catch ex As Exception
                ' Ignore errors during cleanup
            End Try
            ActiveMediaPlayer = Nothing
        End If
    End Sub

    ' Helper method to play system sounds
    Private Sub PlaySystemSound()
        For i As Integer = 0 To 2
            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
            System.Threading.Thread.Sleep(800)
        Next
    End Sub

    Public Sub SetDefaultAlarmSound(soundFilePath As String)
        If String.IsNullOrEmpty(soundFilePath) Then
            DefaultSoundEnabled = False
            DefaultSoundFile = "default.wav"
            UpdateStatusBar("Default sound: System sound")
        ElseIf System.IO.File.Exists(soundFilePath) Then
            DefaultSoundFile = soundFilePath
            DefaultSoundEnabled = True
            UpdateStatusBar("Default sound: " & System.IO.Path.GetFileName(soundFilePath))
        Else
            MessageBox.Show("Sound file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        ' Save to settings
        My.Settings.DefaultAlarmSound = If(DefaultSoundEnabled, soundFilePath, "")
        My.Settings.Save()
    End Sub

#End Region

End Class

