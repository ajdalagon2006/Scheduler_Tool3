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
        ' Enable/disable alarm settings panel based on checkbox
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
        If String.IsNullOrWhiteSpace(todobox.Text) OrElse todobox.Text = "Add a title" Then
            MessageBox.Show("Task name cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            ' Make sure schema is updated before saving
            DbConnection.UpdateDatabaseSchema()

            Using connection As SQLiteConnection = DbConnection.GetSQLiteConnection()
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

                command.Parameters.AddWithValue("@todoname", todobox.Text)
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
                NewNote = todobox.Text
            End Using
        Catch ex As Exception
            MessageBox.Show("Error saving task: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DataSaved = False
        End Try
    End Sub

    Private Sub createbtn_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveTask()
        If DataSaved Then
            Me.Close()
        End If
    End Sub

    Private Sub Cancelbtn_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DataSaved = False
        Me.Close()
    End Sub

    Private Sub btnBrowseSound_Click(sender As Object, e As EventArgs) Handles btnBrowseSound.Click
        If openSoundDialog.ShowDialog() = DialogResult.OK Then
            txtSoundFile.Text = openSoundDialog.FileName
        End If
    End Sub
End Class