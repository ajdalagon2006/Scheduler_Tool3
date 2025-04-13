Imports System.Runtime.InteropServices ' Add this import

Public Class AlarmNotification
    ' API for rounded corners (if needed)
    <DllImport("Gdi32.dll", EntryPoint:="CreateRoundRectRgn")>
    Private Shared Function CreateRoundRectRgn(ByVal x1 As Integer, ByVal y1 As Integer,
                                               ByVal x2 As Integer, ByVal y2 As Integer,
                                               ByVal cx As Integer, ByVal cy As Integer) As IntPtr
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

        ' Optional: Create rounded corners safely
        Try
            Me.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20))
        Catch ex As Exception
            ' Silently fail if rounded corners aren't supported
            Console.WriteLine("Couldn't create rounded corners: " & ex.Message)
        End Try

        ' Start fade-in
        timerFade.Start()
    End Sub

    Private Sub btnDismiss_Click(sender As Object, e As EventArgs) Handles btnDismiss.Click
        Me.Close()
    End Sub

    Private Sub btnSnooze_Click(sender As Object, e As EventArgs) Handles btnSnooze.Click
        ' Add 10 minutes snooze
        MessageBox.Show("Task snoozed for 10 minutes", "Snoozed", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

    Private Sub timerFade_Tick(sender As Object, e As EventArgs) Handles timerFade.Tick
        ' Fade-in effect
        If Me.Opacity < 1.0 Then
            Me.Opacity += 0.1
        Else
            timerFade.Stop()

            ' Auto-close after 20 seconds
            Dim autoCloseTimer As New Timer()
            autoCloseTimer.Interval = 20000
            AddHandler autoCloseTimer.Tick, Sub(s, args)
                                                Me.Close()
                                                autoCloseTimer.Stop()
                                            End Sub
            autoCloseTimer.Start()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ' Make the header panel draggable
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
        dragging = False
    End Sub
End Class