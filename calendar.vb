Imports System.Data.SQLite

Public Class calendar

    'Modified to add/edit notes to calendar using a form

    Private CalendarInfo As MonthlyCalendarInfo
    Private Notes As List(Of String)
    Private NotesDates As List(Of DateTime)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CalendarInfo = New MonthlyCalendarInfo(Now.Year, Now.Month)
        Notes = New List(Of String)
        NotesDates = New List(Of DateTime)
        SizeContainers()
        CreateMonthYearLabel()
        SizeMonthYearLabel()
        CreateDaysOfWeekLabels()
        SizeDaysOfWeekLabels()
        CreateDaysControls()
        SizeDaysControls()
        PopulateCalendarInfo()
        'CreateTestData()

    End Sub


    Private Function GetSQLiteConnection() As SQLiteConnection
        Dim connectionString As String = "Data Source=Appdatabase.db;Version=3;"
        Dim connection As New SQLiteConnection(connectionString)
        connection.Open()
        Return connection
    End Function

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

    Private Sub Form1_ClientSizeChanged(sender As Object, e As EventArgs) Handles MyBase.ClientSizeChanged
        SizeContainers()
        SizeMonthYearLabel()
        SizeDaysOfWeekLabels()
        SizeDaysControls()
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

    'Create day panels and day of month labels
    Private Sub CreateDaysControls()

        Dim dayPanel As Panel
        Dim dayOfMonthLbl As Label

        For rowIndex = 0 To 5
            For colIndex = 0 To 6
                dayPanel = New Panel
                dayPanel.Name = String.Format("PnlDay{0}{1}", rowIndex, colIndex)
                AddHandler dayPanel.MouseDoubleClick, AddressOf Day_DoubleClick 'doubleclick
                dayOfMonthLbl = New Label
                dayOfMonthLbl.Name = String.Format("LblDayOfMonth{0}{1}", rowIndex, colIndex)
                dayOfMonthLbl.Text = dayOfMonthLbl.Name
                dayOfMonthLbl.Font = New Font("Segoe UI", 9, FontStyle.Regular)
                AddHandler dayOfMonthLbl.MouseDoubleClick, AddressOf Day_DoubleClick 'doubleclick
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

    'Go to new month and refresh calendar
    Private Sub MonthYearContainer_Click(sender As Object, e As EventArgs) Handles MonthYearContainer.Click

    End Sub

    'Add/Edit note in list and refresh calendar
    Private Sub Day_DoubleClick(ByVal sender As Object, e As MouseEventArgs)

        Dim rowIndex As Integer
        Dim columnIndex As Integer
        Dim noteIndex As Integer
        Dim selectedDate As DateTime
        Dim isEdit As Boolean
        Dim control As Control
        Dim form As Task

        control = TryCast(sender, Control)
        rowIndex = ExtractFirstDigit(control.Name)
        columnIndex = ExtractLastDigit(control.Name)
        selectedDate = CalendarInfo.DateInYear(rowIndex, columnIndex)
        noteIndex = NotesDates.FindIndex(Function(x) x = selectedDate)

        If noteIndex > -1 Then
            isEdit = True
            form = New Task(selectedDate, Notes(noteIndex))
        Else
            isEdit = False
            form = New Task(selectedDate)
        End If

        form.ShowDialog()

        If Not form.DataSaved Then
            Return
        End If

        If (isEdit) Then
            Notes(noteIndex) = form.NewNote
        Else
            Notes.Add(form.NewNote)
            NotesDates.Add(selectedDate)
        End If

        RemoveMonthNotes()
        ShowMonthNotes()

    End Sub

    'Find first digit in string
    Public Function ExtractFirstDigit(value As String)

        For Each character As Char In value

            If Char.IsDigit(character) Then
                Return Integer.Parse(character.ToString())
            End If

        Next

        Return -1

    End Function

    'Find last digit in string
    Public Function ExtractLastDigit(value As String)

        Dim character As Char

        For i As Integer = value.Length - 1 To 0 Step -1

            character = value(i)

            If Char.IsDigit(character) Then
                Return Integer.Parse(character.ToString())
            End If

        Next

        Return -1

    End Function

    'Find and display all notes in calendar range
    Private Sub ShowMonthNotes()

        Dim columnIndex As Integer
        Dim rowIndex As Integer
        Dim noteIndex As Integer = 0
        Dim panel As Panel
        Dim label As Label
        Dim panelName As String
        Dim searchDate
        Dim endingSearchDate

        searchDate = CalendarInfo.DateInYear(0, 0) 'first date in grid
        endingSearchDate = CalendarInfo.DateInYear(5, 6) 'last date in grid

        While searchDate <= endingSearchDate

            noteIndex = NotesDates.FindIndex(Function(x) x = searchDate)

            If noteIndex > -1 Then

                columnIndex = CalendarInfo.DateColumn(searchDate)
                rowIndex = CalendarInfo.DateRow(searchDate)
                panelName = String.Format("PnlDay{0}{1}", rowIndex, columnIndex)
                panel = Controls.Find(panelName, True).First

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

            searchDate = searchDate.AddDays(1)

        End While

    End Sub

    'Remove notes from calendar 
    Private Sub RemoveMonthNotes()

        Dim dayPanel As Panel
        Dim dayPanelName

        For rowIndex = 0 To 5
            For colIndex = 0 To 6

                dayPanelName = String.Format("PnlDay{0}{1}", rowIndex, colIndex)
                dayPanel = Controls.Find(dayPanelName, True).FirstOrDefault

                For Each control As Control In dayPanel.Controls
                    If control.Name.Contains("LblNote") Then
                        RemoveHandler control.MouseDoubleClick, AddressOf Day_DoubleClick
                        dayPanel.Controls.Remove(control)
                    End If
                Next

            Next
        Next

    End Sub

    'Delete selected note from list and refresh calendar
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click

        Dim menuItem As ToolStripMenuItem
        Dim menuStrip As ContextMenuStrip
        Dim control As New Control
        Dim noteIndex As Integer

        menuItem = TryCast(sender, ToolStripMenuItem)
        menuStrip = TryCast(menuItem.GetCurrentParent, ContextMenuStrip)
        control = menuStrip.SourceControl

        noteIndex = CInt(control.Tag)
        Notes.RemoveAt(noteIndex)
        NotesDates.RemoveAt(noteIndex)

        RemoveMonthNotes()
        ShowMonthNotes()

    End Sub

End Class
