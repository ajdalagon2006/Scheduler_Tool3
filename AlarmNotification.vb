Imports System.Data.SQLite

Public Class AlarmNotification
    Private fadeDirection As Integer = 1 ' 1 for fade in, -1 for fade out
    Private currentTask As String

    Public Sub New(taskName As String, taskDescription As String)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.lblTaskName.Text = taskName
        Me.lblTaskDescription.Text = taskDescription
        Me.currentTask = taskName

        ' Position in bottom right corner of screen
        Dim screenWidth As Integer = Screen.PrimaryScreen.WorkingArea.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.WorkingArea.Height
        Me.Location = New Point(screenWidth - Me.Width - 20, screenHeight - Me.Height - 20)

        ' Set rounded corners
        Me.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20))

        ' Create shadow effect
        Me.CreateDropShadow()

        ' Start fade-in animation
        Me.Opacity = 0
        timerFade.Start()
    End Sub

    Private Sub timerFade_Tick(sender As Object, e As EventArgs) Handles timerFade.Tick
        If fadeDirection > 0 Then ' Fade in
            Me.Opacity += 0.1
            If Me.Opacity >= 0.95 Then
                Me.Opacity = 0.95
                timerFade.Stop()

                ' Set auto-close timer after 30 seconds
                Dim autoCloseTimer As New Timer()
                autoCloseTimer.Interval = 30000 ' 30 seconds
                AddHandler autoCloseTimer.Tick, AddressOf AutoCloseTimer_Tick
                autoCloseTimer.Start()
            End If
        Else ' Fade out
            Me.Opacity -= 0.1
            If Me.Opacity <= 0 Then
                Me.Opacity = 0
                timerFade.Stop()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub AutoCloseTimer_Tick(sender As Object, e As EventArgs)
        ' Start fade-out effect after time expires
        fadeDirection = -1
        timerFade.Start()

        ' Stop the auto-close timer
        Dim timer As Timer = DirectCast(sender, Timer)
        timer.Stop()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        ' Start fade-out effect
        fadeDirection = -1
        timerFade.Start()
    End Sub

    Private Sub btnDismiss_Click(sender As Object, e As EventArgs) Handles btnDismiss.Click
        ' Start fade-out effect
        fadeDirection = -1
        timerFade.Start()
    End Sub

    Private Sub btnSnooze_Click(sender As Object, e As EventArgs) Handles btnSnooze.Click
        ' Snooze logic - Set a new alarm for 10 minutes later
        Try
            Dim connection = DbConnection.GetConnection()
            connection.Open()

            ' Create a new alarm time 10 minutes in the future
            Dim snoozeTime = DateTime.Now.AddMinutes(10)

            Dim command As New SQLiteCommand(
                "UPDATE Tasks SET alarm_time = @newAlarmTime WHERE todoname = @taskName AND has_alarm = 1",
                connection)

            command.Parameters.AddWithValue("@newAlarmTime", snoozeTime.ToString("yyyy-MM-dd HH:mm:ss"))
            command.Parameters.AddWithValue("@taskName", currentTask)
            command.ExecuteNonQuery()

            connection.Close()
            MessageBox.Show($"Alarm snoozed for 10 minutes. Will ring again at {snoozeTime.ToString("h:mm tt")}",
                           "Alarm Snoozed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error snoozing alarm: " & ex.Message)
        End Try

        ' Start fade-out effect
        fadeDirection = -1
        timerFade.Start()
    End Sub

    ' Helper method for rounded corners
    Private Declare Function CreateRoundRectRgn Lib "Gdi32.dll" (ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal cx As Integer, ByVal cy As Integer) As IntPtr

    ' For shadow effect (requires WindowsFormsAero library or similar implementation)
    Private Sub CreateDropShadow()
        ' For a simple drop shadow effect without external libraries:
        ' You can implement this with your preferred method or library
        ' Here's a simple implementation without dependencies:
        Me.FormBorderStyle = FormBorderStyle.None
        Me.BackColor = Color.White
    End Sub

    ' Make form draggable
    Private dragging As Boolean = False
    Private dragStartPoint As Point

    Private Sub panelHeader_MouseDown(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseDown
        If e.Button = MouseButtons.Left Then
            dragging = True
            dragStartPoint = New Point(e.X, e.Y)
        End If
    End Sub

    Private Sub panelHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseMove
        If dragging Then
            Dim p As Point = PointToScreen(New Point(e.X, e.Y))
            Location = New Point(p.X - dragStartPoint.X, p.Y - dragStartPoint.Y)
        End If
    End Sub

    Private Sub panelHeader_MouseUp(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseUp
        If e.Button = MouseButtons.Left Then
            dragging = False
        End If
    End Sub
End Class