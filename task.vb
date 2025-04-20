Imports System.Data.SQLite
Imports System.IO

Public Class Task
    Public DataSaved As Boolean
    Public NewNote As String
    Private IsEdit As Boolean
    Private SelectedDate As DateTime
    Private OriginalNote As String
    Private openSoundDialog As New OpenFileDialog()

    Public Sub New(d As DateTime)
        InitializeComponent()

        IsEdit = False
        SelectedDate = d
        SetupOpenFileDialog()
    End Sub

    Public Sub New(d As DateTime, text As String)
        InitializeComponent()

        IsEdit = True
        SelectedDate = d
        OriginalNote = text
        SetupOpenFileDialog()
    End Sub

    Private Sub SetupOpenFileDialog()
        openSoundDialog.Filter = "Sound Files (*.wav;*.mp3)|*.wav;*.mp3|All files (*.*)|*.*"
        openSoundDialog.Title = "Select Alarm Sound"
    End Sub

    Private Sub Task_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataSaved = False
        date1.Value = SelectedDate

        If Not IsEdit Then
            date1.MinDate = DateTime.Now.Date

            ' If the provided date is in the past
            If IsDateInPast(SelectedDate) Then
                date1.Value = DateTime.Now.Date
                SelectedDate = date1.Value
            End If
        End If

        ' Set time pickers based on current time
        Dim currentTime As DateTime = DateTime.Now
        Dim roundedHour As Integer = currentTime.Hour
        Dim roundedMinute As Integer = If(currentTime.Minute < 30, 0, 30)

        ' Format the time string for the combobox
        Dim timeFormat As String = If(roundedHour = 0, "12", If(roundedHour > 12, (roundedHour - 12).ToString(), roundedHour.ToString())) & ":" &
                              If(roundedMinute = 0, "00", "30") & " " & If(roundedHour < 12, "AM", "PM")

        ' Find and select the closest time in the combobox
        For i As Integer = 0 To cmbStartTime.Items.Count - 1
            If cmbStartTime.Items(i).ToString() = timeFormat Then
                cmbStartTime.SelectedIndex = i
                cmbEndTime.SelectedIndex = Math.Min(i + 2, cmbEndTime.Items.Count - 1) ' Default to 1 hour later
                Exit For
            End If
        Next

        ' Set timePicker for alarms
        timePicker.Value = currentTime

        ' Disable alarm settings by default
        pnlAlarmSettings.Enabled = False

        If IsEdit Then
            Me.Text = "Edit Event"
            todobox.Text = OriginalNote
            todobox.SelectAll()

            ' Load task data if editing
            LoadTaskData()
        Else
            Me.Text = "Add Event"
            todobox.Text = "Add a title"
            todobox.SelectAll()
            comsecbox.Text = "Add a description or attach documents"
            e1.Checked = True ' Default to Event
        End If
    End Sub

    Private Sub todobox_Enter(sender As Object, e As EventArgs) Handles todobox.Enter
        If todobox.Text = "Add a title" Then
            todobox.Text = ""
        End If
    End Sub

    Private Sub todobox_Leave(sender As Object, e As EventArgs) Handles todobox.Leave
        If String.IsNullOrWhiteSpace(todobox.Text) Then
            todobox.Text = "Add a title"
        End If
    End Sub

    Private Sub comsecbox_Enter(sender As Object, e As EventArgs) Handles comsecbox.Enter
        If comsecbox.Text = "Add a description or attach documents" Then
            comsecbox.Text = ""
        End If
    End Sub

    Private Sub comsecbox_Leave(sender As Object, e As EventArgs) Handles comsecbox.Leave
        If String.IsNullOrWhiteSpace(comsecbox.Text) Then
            comsecbox.Text = "Add a description or attach documents"
        End If
    End Sub

    ' Updated alarm checkbox handler:
    Private Sub chkAlarm_CheckedChanged(sender As Object, e As EventArgs) Handles chkAlarm.CheckedChanged
        pnlAlarmSettings.Enabled = chkAlarm.Checked
    End Sub

    ' Update the buttons:
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveTask()
        If DataSaved Then
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DataSaved = False
        Me.Close()
    End Sub
    Private Sub LoadTaskData()
        Try
            Using connection As SQLiteConnection = DbConnection.GetConnection()
                ' First check if the columns exist in the Task table
                Dim colCmd As New SQLiteCommand("PRAGMA table_info(Task)", connection)
                Dim colReader As SQLiteDataReader = colCmd.ExecuteReader()

                Dim hasAlarmColumn As Boolean = False
                Dim hasAlarmTimeColumn As Boolean = False
                Dim hasAlarmSoundColumn As Boolean = False

                While colReader.Read()
                    Dim colName As String = colReader("name").ToString().ToLower()
                    If colName = "has_alarm" Then hasAlarmColumn = True
                    If colName = "alarm_time" Then hasAlarmTimeColumn = True
                    If colName = "alarm_sound" Then hasAlarmSoundColumn = True
                End While
                colReader.Close()

                ' Now load the task data
                Dim command As New SQLiteCommand("SELECT * FROM Task WHERE todoname = @todoname AND Date = @date", connection)
                command.Parameters.AddWithValue("@todoname", OriginalNote)
                command.Parameters.AddWithValue("@date", SelectedDate.ToString("yyyy-MM-dd"))

                Using reader As SQLiteDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        ' Load task details (Note: your database uses "Comment" with capital C)
                        comsecbox.Text = reader("Comment").ToString()

                        ' Set category
                        Dim category As String = reader("category").ToString()
                        If category = "Event" Then
                            e1.Checked = True
                        Else
                            s1.Checked = True
                        End If

                        ' Load alarm settings if columns exist
                        If hasAlarmColumn Then
                            Dim hasAlarm As Boolean = Convert.ToBoolean(reader("has_alarm"))
                            chkAlarm.Checked = hasAlarm
                            pnlAlarmSettings.Enabled = hasAlarm

                            If hasAlarm And hasAlarmTimeColumn Then
                                ' Load alarm time if available
                                If Not IsDBNull(reader("alarm_time")) Then
                                    Dim alarmTime As DateTime
                                    If DateTime.TryParse(reader("alarm_time").ToString(), alarmTime) Then
                                        timePicker.Value = alarmTime
                                    End If
                                End If

                                ' Load custom sound file if available
                                If hasAlarmSoundColumn AndAlso Not IsDBNull(reader("alarm_sound")) Then
                                    txtSoundFile.Text = reader("alarm_sound").ToString()
                                End If
                            End If
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading task data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SaveTask()
        ' Check for empty title
        If String.IsNullOrWhiteSpace(todobox.Text) OrElse todobox.Text = "Add a title" Then
            MessageBox.Show("Task name cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Only check the date if this is a new task (not editing an existing one)
        If Not IsEdit AndAlso IsDateInPast(date1.Value) Then
            MessageBox.Show("Cannot create tasks for past dates.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using connection As SQLiteConnection = DbConnection.GetSQLiteConnection()
                ' Try to find existing task with same name on same date
                Dim taskName As String = todobox.Text.Trim()
                Dim checkCmd As New SQLiteCommand(
                "SELECT COUNT(*) FROM Task WHERE todoname = @name AND Date = @date", connection)
                checkCmd.Parameters.AddWithValue("@name", taskName)
                checkCmd.Parameters.AddWithValue("@date", date1.Value.ToString("yyyy-MM-dd"))

                ' If a task with this name exists (and we're not editing it), make the name unique
                Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                If count > 0 AndAlso (Not IsEdit OrElse taskName <> OriginalNote) Then
                    ' Get the current time for the task
                    Dim timeStr As String = ""
                    If cmbStartTime.SelectedItem IsNot Nothing Then
                        timeStr = cmbStartTime.SelectedItem.ToString()
                    ElseIf chkAlarm.Checked Then
                        timeStr = timePicker.Value.ToString("h:mm tt")
                    End If

                    ' Append time or a random number to make name unique
                    If Not String.IsNullOrEmpty(timeStr) Then
                        taskName = taskName & " (" & timeStr & ")"
                    Else
                        taskName = taskName & " (" & DateTime.Now.ToString("h:mm:ss") & ")"
                    End If
                End If

                ' Continue with existing save logic
                Dim command As SQLiteCommand

                If IsEdit Then
                    command = New SQLiteCommand(
                "UPDATE Task SET 
                todoname = @todoname, 
                Comment = @comment, 
                category = @category,
                has_alarm = @hasAlarm,
                alarm_time = @alarmTime,
                alarm_sound = @alarmSound
                WHERE todoname = @originalName AND Date = @date", connection)

                    command.Parameters.AddWithValue("@originalName", OriginalNote)
                Else
                    command = New SQLiteCommand(
                "INSERT INTO Task 
                (todoname, Comment, Date, category, has_alarm, alarm_time, alarm_sound) 
                VALUES 
                (@todoname, @comment, @date, @category, @hasAlarm, @alarmTime, @alarmSound)", connection)
                End If

                ' Clean up comment text if it's the default placeholder
                Dim commentText As String = comsecbox.Text
                If commentText = "Add a description or attach documents" Then
                    commentText = ""
                End If

                command.Parameters.AddWithValue("@todoname", taskName) ' Use potentially modified taskName
                command.Parameters.AddWithValue("@comment", commentText)
                command.Parameters.AddWithValue("@date", date1.Value.ToString("yyyy-MM-dd"))
                command.Parameters.AddWithValue("@category", If(e1.Checked, "Event", "School Works"))
                command.Parameters.AddWithValue("@hasAlarm", chkAlarm.Checked)

                If chkAlarm.Checked Then
                    ' Combine the selected date with the time from timePicker
                    Dim alarmTime As New DateTime(
                date1.Value.Year,
                date1.Value.Month,
                date1.Value.Day,
                timePicker.Value.Hour,
                timePicker.Value.Minute,
                0)

                    command.Parameters.AddWithValue("@alarmTime", alarmTime.ToString("yyyy-MM-dd HH:mm:ss"))
                    command.Parameters.AddWithValue("@alarmSound", txtSoundFile.Text)
                Else
                    command.Parameters.AddWithValue("@alarmTime", DBNull.Value)
                    command.Parameters.AddWithValue("@alarmSound", "default.wav")
                End If

                command.ExecuteNonQuery()

                DataSaved = True
                NewNote = taskName ' Return the task name
            End Using
        Catch ex As Exception
            MessageBox.Show("Error saving task: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DataSaved = False
        End Try
    End Sub

    Private Function IsDateInPast(dateToCheck As DateTime) As Boolean
        ' Compare only the date parts 
        Return dateToCheck.Date < DateTime.Now.Date
    End Function

    Private Sub date1_ValueChanged(sender As Object, e As EventArgs) Handles date1.ValueChanged
        ' Check if selected date is in the past
        If IsDateInPast(date1.Value) Then
            MessageBox.Show("Cannot create tasks for past dates. Please select today or a future date.",
                       "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            ' Reset to current date
            date1.Value = DateTime.Now.Date
        End If
    End Sub



    Private Sub btnBrowseSound_Click(sender As Object, e As EventArgs) Handles btnBrowseSound.Click
        If openSoundDialog.ShowDialog() = DialogResult.OK Then
            txtSoundFile.Text = openSoundDialog.FileName
        End If
    End Sub
End Class