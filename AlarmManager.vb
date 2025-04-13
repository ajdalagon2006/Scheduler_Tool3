Imports System.Data.SQLite

Public Class AlarmManager
    Private Shared _instance As AlarmManager
    Private WithEvents checkTimer As New Timer()
    Private soundPlayer As System.Media.SoundPlayer

    ' Singleton pattern
    Public Shared Function GetInstance() As AlarmManager
        If _instance Is Nothing Then
            _instance = New AlarmManager()
        End If
        Return _instance
    End Function

    Private Sub New()
        ' Set up timer to check for alarms every minute
        checkTimer.Interval = 60000 ' 1 minute
        checkTimer.Start()

        ' Initialize sound player
        soundPlayer = New System.Media.SoundPlayer()
    End Sub

    Private Sub CheckTimer_Tick(sender As Object, e As EventArgs) Handles checkTimer.Tick
        CheckForDueAlarms()
    End Sub

    Public Sub CheckForDueAlarms()
        Dim currentDateTime = DateTime.Now
        Dim currentDateTimeStr = currentDateTime.ToString("yyyy-MM-dd HH:mm")

        Try
            Using connection As SQLiteConnection = DbConnection.GetConnection()
                connection.Open()

                ' Find alarms that should trigger at the current time (within the minute)
                Dim command As New SQLiteCommand(
                    "SELECT * FROM Tasks WHERE has_alarm = 1 AND " &
                    "strftime('%Y-%m-%d %H:%M', alarm_time) = @currentTime",
                    connection)

                command.Parameters.AddWithValue("@currentTime", currentDateTime.ToString("yyyy-MM-dd HH:mm"))

                Using reader As SQLiteDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim taskName As String = reader("todoname").ToString()
                        Dim taskComment As String = If(reader("comment") IsNot DBNull.Value, reader("comment").ToString(), "")
                        Dim soundFile As String = If(reader("alarm_sound") IsNot DBNull.Value, reader("alarm_sound").ToString(), "default.wav")

                        ' Play sound and show notification
                        TriggerAlarm(taskName, taskComment, soundFile)
                    End While
                End Using

                connection.Close()
            End Using
        Catch ex As Exception
            ' Log error but don't show message box as this runs in background
            Console.WriteLine("Error checking alarms: " & ex.Message)
        End Try
    End Sub

    Public Sub TriggerAlarm(taskName As String, taskComment As String, soundFile As String)
        ' Play the alarm sound in a separate thread
        System.Threading.ThreadPool.QueueUserWorkItem(
            Sub()
                PlayAlarmSound(soundFile)
            End Sub)

        ' Show notification form
        ShowNotification(taskName, taskComment)
    End Sub

    Private Sub PlayAlarmSound(soundFile As String)
        Try
            If soundFile = "default.wav" OrElse Not System.IO.File.Exists(soundFile) Then
                ' Use system sound if default or file doesn't exist
                My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
            Else
                ' Play custom sound file
                soundPlayer.SoundLocation = soundFile
                soundPlayer.PlayLooping()

                ' Stop after 10 seconds to avoid annoying the user
                System.Threading.Thread.Sleep(10000)
                soundPlayer.Stop()
            End If
        Catch ex As Exception
            ' Fall back to system sound if there's an error
            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
        End Try
    End Sub

    Private Sub ShowNotification(taskName As String, taskComment As String)
        ' Use Invoke if needed to run on UI thread
        If Application.OpenForms.Count > 0 Then
            Dim mainForm As Form = Application.OpenForms(0)
            mainForm.Invoke(
                Sub()
                    Dim notification As New AlarmNotification(taskName, taskComment)
                    notification.Show()
                End Sub)
        Else
            ' Direct approach if no UI thread issues
            Dim notification As New AlarmNotification(taskName, taskComment)
            notification.Show()
        End If
    End Sub

    ' Call this method to stop checking for alarms (e.g., when application closes)
    Public Sub StopAlarmChecking()
        checkTimer.Stop()
        If soundPlayer IsNot Nothing Then
            soundPlayer.Stop()
        End If
    End Sub

    ' Create this method to test alarms without waiting
    Public Sub TestAlarm(taskName As String, taskComment As String, soundFile As String)
        TriggerAlarm(taskName, taskComment, soundFile)
    End Sub
End Class