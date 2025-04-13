Imports System.Data.SQLite
Imports System.IO

Public Class Task

    Public DataSaved As Boolean
    Public NewNote As String
    Private IsEdit As Boolean
    Private SelectedDate As DateTime
    Private OriginalNote As String
    Private Connection As SQLiteConnection
    Private OpenSoundFileDialog As New OpenFileDialog()

    Public Sub New(d As DateTime)
        InitializeComponent()

        IsEdit = False
        SelectedDate = d
        Connection = GetConnection()
        SetupSoundDialog()
    End Sub

    Public Sub New(d As DateTime, text As String)
        InitializeComponent()

        IsEdit = True
        SelectedDate = d
        OriginalNote = text
        Connection = GetConnection()
        SetupSoundDialog()
    End Sub

    Private Sub SetupSoundDialog()
        OpenSoundFileDialog.Filter = "Sound files (*.wav;*.mp3)|*.wav;*.mp3|All files (*.*)|*.*"
        OpenSoundFileDialog.Title = "Select Alarm Sound"
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

            ' Load saved task data including alarm settings
            LoadTaskData()
        Else
            Me.Text = "Add"
            todobox.Clear()
            comsecbox.Clear()
            e1.Checked = True
        End If
    End Sub

    Private Sub LoadTaskData()
        Try
            Connection.Open()
            Dim command As New SQLiteCommand("SELECT * FROM Tasks WHERE date = @date AND todoname = @todoname", Connection)
            command.Parameters.AddWithValue("@date", SelectedDate.ToString("yyyy-MM-dd"))
            command.Parameters.AddWithValue("@todoname", OriginalNote)

            Dim reader As SQLiteDataReader = command.ExecuteReader()
            If reader.Read() Then
                todobox.Text = reader("todoname").ToString()
                comsecbox.Text = If(reader("comment") IsNot DBNull.Value, reader("comment").ToString(), "")

                Dim category As String = reader("category").ToString()
                If category = "Event" Then
                    e1.Checked = True
                Else
                    s1.Checked = True
                End If

                ' Load alarm settings
                Dim hasAlarm As Boolean = Convert.ToBoolean(reader("has_alarm"))
                chkAlarm.Checked = hasAlarm
                grpAlarm.Enabled = hasAlarm

                If hasAlarm Then
                    Dim alarmTimeStr As String = reader("alarm_time").ToString()
                    If Not String.IsNullOrEmpty(alarmTimeStr) Then
                        Dim alarmTime As DateTime = DateTime.Parse(alarmTimeStr)
                        timePicker.Value = alarmTime
                    End If

                    txtSoundFile.Text = If(reader("alarm_sound") IsNot DBNull.Value, reader("alarm_sound").ToString(), "default.wav")
                End If
            End If
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading task data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If
        End Try
    End Sub

    Private Sub SaveTask()
        If SelectedDate < Now.Date AndAlso Not IsEdit Then
            MessageBox.Show("Cannot add task to a past date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If String.IsNullOrWhiteSpace(todobox.Text) Then
            MessageBox.Show("Task name cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            Connection.Open()
            Dim command As SQLiteCommand
            If IsEdit Then
                command = New SQLiteCommand("UPDATE Tasks SET todoname = @todoname, comment = @comment, category = @category, has_alarm = @hasAlarm, alarm_time = @alarmTime, alarm_sound = @alarmSound WHERE date = @date AND todoname = @originalNote", Connection)
                command.Parameters.AddWithValue("@originalNote", OriginalNote)
            Else
                command = New SQLiteCommand("INSERT INTO Tasks (todoname, comment, date, category, has_alarm, alarm_time, alarm_sound) VALUES (@todoname, @comment, @date, @category, @hasAlarm, @alarmTime, @alarmSound)", Connection)
            End If

            command.Parameters.AddWithValue("@todoname", todobox.Text)
            command.Parameters.AddWithValue("@comment", comsecbox.Text)
            command.Parameters.AddWithValue("@date", SelectedDate.ToString("yyyy-MM-dd"))
            command.Parameters.AddWithValue("@category", If(e1.Checked, "Event", "School Works"))
            command.Parameters.AddWithValue("@hasAlarm", chkAlarm.Checked)

            If chkAlarm.Checked Then
                command.Parameters.AddWithValue("@alarmTime", timePicker.Value.ToString("yyyy-MM-dd HH:mm:ss"))
                command.Parameters.AddWithValue("@alarmSound", txtSoundFile.Text)
            Else
                command.Parameters.AddWithValue("@alarmTime", DBNull.Value)
                command.Parameters.AddWithValue("@alarmSound", "default.wav")
            End If

            command.ExecuteNonQuery()

            DataSaved = True
            NewNote = todobox.Text
        Catch ex As Exception
            MessageBox.Show("Error saving task: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            DataSaved = False
        Finally
            If Connection.State = ConnectionState.Open Then
                Connection.Close()
            End If

            If DataSaved Then
                Me.Close()
            End If
        End Try
    End Sub

    Private Sub createbtn_Click(sender As Object, e As EventArgs) Handles createbtn.Click
        SaveTask()
    End Sub

    Private Sub Cancelbtn_Click(sender As Object, e As EventArgs) Handles Cancelbtn.Click
        DataSaved = False
        Me.Close()
    End Sub

    Private Sub chkAlarm_CheckedChanged(sender As Object, e As EventArgs) Handles chkAlarm.CheckedChanged
        grpAlarm.Enabled = chkAlarm.Checked
    End Sub

    Private Sub btnBrowseSound_Click(sender As Object, e As EventArgs) Handles btnBrowseSound.Click
        If OpenSoundFileDialog.ShowDialog() = DialogResult.OK Then
            txtSoundFile.Text = OpenSoundFileDialog.FileName
        End If
    End Sub
End Class