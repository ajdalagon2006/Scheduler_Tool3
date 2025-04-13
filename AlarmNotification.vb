Public Class AlarmNotification
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
End Class