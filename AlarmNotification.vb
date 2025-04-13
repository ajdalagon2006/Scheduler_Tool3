Imports System.Runtime.InteropServices
Imports System.Data.SQLite

Public Class AlarmNotification
    ' Optional: API for rounded corners
    <DllImport("Gdi32.dll", EntryPoint:="CreateRoundRectRgn")>
    Private Shared Function CreateRoundRectRgn(
                                ByVal x1 As Integer,
                                ByVal y1 As Integer,
                                ByVal x2 As Integer,
                                ByVal y2 As Integer,
                                ByVal cx As Integer,
                                ByVal cy As Integer) As IntPtr
    End Function

    Public Sub New(taskName As String, description As String)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        lblTaskName.Text = taskName
        lblTaskDescription.Text = description

        ' Position in bottom-right corner
        Dim screenWidth As Integer = Screen.PrimaryScreen.WorkingArea.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.WorkingArea.Height
        Me.Location = New Point(screenWidth - Me.Width - 20, screenHeight - Me.Height - 20)

        ' Optional: Make form have rounded corners
        Try
            Me.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20))
        Catch ex As Exception
            ' Silently fail if rounded corners aren't supported
        End Try

        ' Start fade-in
        Me.Opacity = 0
        timerFade.Start()
    End Sub

    Private Sub timerFade_Tick(sender As Object, e As EventArgs) Handles timerFade.Tick
        ' Fade-in effect
        If Me.Opacity < 0.95 Then
            Me.Opacity += 0.05
        Else
            Me.Opacity = 0.95
            timerFade.Stop()

            ' Auto-close after 30 seconds
            Dim autoCloseTimer As New Timer()
            autoCloseTimer.Interval = 30000
            AddHandler autoCloseTimer.Tick, Sub(s, args)
                                                Me.Close()
                                                autoCloseTimer.Stop()
                                            End Sub
            autoCloseTimer.Start()
        End If
    End Sub

    Private Sub btnDismiss_Click(sender As Object, e As EventArgs) Handles btnDismiss.Click
        Me.Close()
    End Sub

    Private Sub btnSnooze_Click(sender As Object, e As EventArgs) Handles btnSnooze.Click
        ' Snooze for 10 minutes
        Using connection As SQLiteConnection = DbConnection.GetSQLiteConnection()
            ' Update the alarm time to 10 minutes in the future
            Dim cmd As New SQLiteCommand(
                "UPDATE Task SET alarm_time = @newTime WHERE todoname = @taskName AND has_alarm = 1",
                connection)

            cmd.Parameters.AddWithValue("@newTime", DateTime.Now.AddMinutes(10).ToString("yyyy-MM-dd HH:mm:ss"))
            cmd.Parameters.AddWithValue("@taskName", lblTaskName.Text)
            cmd.ExecuteNonQuery()
        End Using

        MessageBox.Show("Task snoozed for 10 minutes", "Snoozed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ' Make form draggable
    Private dragging As Boolean = False
    Private offset As Point

    Private Sub panelHeader_MouseDown(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseDown
        If e.Button = MouseButtons.Left Then
            dragging = True
            offset = New Point(e.X, e.Y)
        End If
    End Sub

    Private Sub panelHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseMove
        If dragging Then
            Dim newPoint As Point = Me.PointToScreen(New Point(e.X, e.Y))
            newPoint.X -= offset.X
            newPoint.Y -= offset.Y
            Me.Location = newPoint
        End If
    End Sub

    Private Sub panelHeader_MouseUp(sender As Object, e As MouseEventArgs) Handles panelHeader.MouseUp
        dragging = False
    End Sub
End Class