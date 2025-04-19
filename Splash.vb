Public Class Splash
    Private Sub Time_Tick(sender As Object, e As EventArgs) Handles Time.Tick
        Panel2.Width += 9
        If Panel2.Width >= 524 Then
            Dim Login As New signin
            Time.Stop()
            Login.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub Splash_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


End Class
