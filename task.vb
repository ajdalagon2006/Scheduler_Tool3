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
        timePicker.Value = DateTime.Now

        ' Disable alarm settings by default
        grpAlarm.Enabled = False

        If IsEdit Then
            Me.Text = "Edit"
            todobox.Text = OriginalNote

            ' Load task data if editing
            LoadTaskData()
        Else
            Me.Text = "Add"
            todobox.Clear()
            comsecbox.Clear()
            e1.Checked = True ' Default to Event
        End If
    End Sub

    Private Sub LoadTaskData()
        Try
            ' First ensure the Tasks table exists
            CreateTasksTableIfNeeded()

            Using connection As SQLiteConnection = GetSQLiteConnection()
                Dim command As New SQLiteCommand("SELECT * FROM Tasks WHERE todoname = @todoname AND date = @date", connection)
                command.Parameters.AddWithValue("@todoname", OriginalNote)
                command.Parameters.AddWithValue("@date", SelectedDate.ToString("yyyy-MM-dd"))

                Using reader As SQLiteDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        ' Load task details
                        comsecbox.Text = reader("comment").ToString()

                        ' Set category
                        Dim category As String = reader("category").ToString()
                        If category = "Event" Then
                            e1.Checked = True
                        Else
                            s1.Checked = True
                        End If

                        ' Load alarm settings if they exist
                        If reader.Table.Columns.Contains("has_alarm") Then
                            Dim hasAlarm As Boolean = Convert.ToBoolean(reader("has_alarm"))
                            chkAlarm.Checked = hasAlarm
                            grpAlarm.Enabled = hasAlarm

                            If hasAlarm Then
                                ' Load alarm time if available
                                If Not IsDBNull(reader("alarm_time")) Then
                                    Dim alarmTime As DateTime
                                    If DateTime.TryParse(reader("alarm_time").ToString(), alarmTime) Then
                                        timePicker.Value = alarmTime
                                    End If
                                End If

                                ' Load custom sound file if available
                                If reader.Table.Columns.Contains("alarm_sound") AndAlso Not IsDBNull(reader("alarm_sound")) Then
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

    Private Sub CreateTasksTableIfNeeded()
        Try
            Using connection As SQLiteConnection = GetSQLiteConnection()
                ' Check if Tasks table exists
                Dim checkTableCmd As New SQLiteCommand(
                    "SELECT name FROM sqlite_master WHERE type='table' AND name='Tasks'", connection)

                Dim tableExists As Object = checkTableCmd.ExecuteScalar()

                If tableExists Is Nothing Then
                    ' Create Tasks table with alarm support
                    Dim createTableCmd As New SQLiteCommand(
                        "CREATE TABLE Tasks (
                            id INTEGER PRIMARY KEY AUTOINCREMENT,
                            todoname TEXT NOT NULL,
                            comment TEXT,
                            date TEXT NOT NULL,
                            category TEXT NOT NULL,
                            has_alarm INTEGER DEFAULT 0,
                            alarm_time TEXT,
                            alarm_sound TEXT DEFAULT 'default.wav'
                        )", connection)

                    createTableCmd.ExecuteNonQuery()
                Else
                    ' Check if we need to add alarm columns to an existing table
                    Dim checkColumnsCmd As New SQLiteCommand(
                        "PRAGMA table_info(Tasks)", connection)

                    Dim hasAlarmColumn As Boolean = False

                    Using reader As SQLiteDataReader = checkColumnsCmd.ExecuteReader()
                        While reader.Read()
                            If reader("name").ToString().Equals("has_alarm") Then
                                hasAlarmColumn = True
                                Exit While
                            End If
                        End While
                    End Using

                    ' Add alarm columns if they don't exist
                    If Not hasAlarmColumn Then
                        Dim alterTableCmd As New SQLiteCommand(
                            "ALTER TABLE Tasks ADD COLUMN has_alarm INTEGER DEFAULT 0", connection)
                        alterTableCmd.ExecuteNonQuery()

                        alterTableCmd = New SQLiteCommand(
                            "ALTER TABLE Tasks ADD COLUMN alarm_time TEXT", connection)
                        alterTableCmd.ExecuteNonQuery()

                        alterTableCmd = New SQLiteCommand(
                            "ALTER TABLE Tasks ADD COLUMN alarm_sound TEXT DEFAULT 'default.wav'", connection)
                        alterTableCmd.ExecuteNonQuery()
                    End If
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error setting up database: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SaveTask()
        If String.IsNullOrWhiteSpace(todobox.Text) Then
            MessageBox.Show("Task name cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Using connection As SQLiteConnection = GetSQLiteConnection()
                Dim command As SQLiteCommand

                If IsEdit Then
                    command = New SQLiteCommand(
                        "UPDATE Tasks SET 
                        todoname = @todoname, 
                        comment = @comment, 
                        category = @category,
                        has_alarm = @hasAlarm,
                        alarm_time = @alarmTime,
                        alarm_sound = @alarmSound
                        WHERE todoname = @originalName AND date = @date", connection)

                    command.Parameters.AddWithValue("@originalName", OriginalNote)
                Else
                    command = New SQLiteCommand(
                        "INSERT INTO Tasks 
                        (todoname, comment, date, category, has_alarm, alarm_time, alarm_sound) 
                        VALUES 
                        (@todoname, @comment, @date, @category, @hasAlarm, @alarmTime, @alarmSound)", connection)
                End If

                command.Parameters.AddWithValue("@todoname", todobox.Text)
                command.Parameters.AddWithValue("@comment", comsecbox.Text)
                command.Parameters.AddWithValue("@date", SelectedDate.ToString("yyyy-MM-dd"))
                command.Parameters.AddWithValue("@category", If(e1.Checked, "Event", "School Works"))
                command.Parameters.AddWithValue("@hasAlarm", chkAlarm.Checked)

                If chkAlarm.Checked Then
                    ' Combine the selected date with the time from timePicker
                    Dim alarmTime As New DateTime(
                        SelectedDate.Year,
                        SelectedDate.Month,
                        SelectedDate.Day,
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

    Private Sub createbtn_Click(sender As Object, e As EventArgs) Handles createbtn.Click
        SaveTask()
        If DataSaved Then
            Me.Close()
        End If
    End Sub

    Private Sub Cancelbtn_Click(sender As Object, e As EventArgs) Handles Cancelbtn.Click
        DataSaved = False
        Me.Close()
    End Sub

    Private Sub chkAlarm_CheckedChanged(sender As Object, e As EventArgs) Handles chkAlarm.CheckedChanged
        ' Enable/disable alarm settings group based on checkbox
        grpAlarm.Enabled = chkAlarm.Checked
    End Sub

    Private Sub btnBrowseSound_Click(sender As Object, e As EventArgs) Handles btnBrowseSound.Click
        If openSoundDialog.ShowDialog() = DialogResult.OK Then
            txtSoundFile.Text = openSoundDialog.FileName
        End If
    End Sub
End Class