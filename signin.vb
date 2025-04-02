Imports System.Data.SQLite
Public Class signin

    Private Sub loginbtn_Click(sender As Object, e As EventArgs) Handles loginbtn.Click
        If userbox.Text = "" Then
            MessageBox.Show("Please enter a username")
            Return
        End If

        If passbox.Text = "" Then
            MessageBox.Show("Please enter a password")
            Return
        End If

        Dim conn As New SQLiteConnection("Data Source=D:\Scheduler_Tool\bin\Debug\Appdatabase.db;Version=3;")
        Try
            conn.Open()
            Dim cmd As New SQLiteCommand("SELECT ID, Username FROM Userdatabase WHERE Username = @Username And Password = @Password", conn)
            cmd.Parameters.AddWithValue("@Username", userbox.Text)
            cmd.Parameters.AddWithValue("@Password", passbox.Text)
            Dim reader As SQLiteDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                MessageBox.Show("Login successful")
                Dim userId As Integer = reader("ID")
                Dim homeForm As New Home()
                homeForm.SetUsername(userbox.Text)
                homeForm.Show()
                Me.Hide()
            Else
                MessageBox.Show("Invalid username or password")
            End If
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub


    Private Sub signin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        userbox.Text = "Username"
        userbox.ForeColor = Color.DarkGray

        passbox.Text = "Password"
        passbox.ForeColor = Color.DarkGray
    End Sub

    Private Sub uplink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles uplink.LinkClicked
        signup.Show()
        Me.Hide()
    End Sub

    Private Sub forgotlink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles forgotlink.LinkClicked
        forgot.Show()
        Me.Hide()
    End Sub

    Private Sub showbtn_CheckedChanged(sender As Object, e As EventArgs) Handles showbtn.CheckedChanged
        passbox.UseSystemPasswordChar = Not showbtn.Checked
    End Sub

    Private Sub userbox_GotFocus(sender As Object, e As EventArgs) Handles userbox.GotFocus
        If userbox.Text = "Username" Then
            userbox.Text = ""
            userbox.ForeColor = Color.Black
        End If
    End Sub

    Private Sub userbox_LostFocus(sender As Object, e As EventArgs) Handles userbox.LostFocus
        If userbox.Text = "" Then
            userbox.Text = "Username"
            userbox.ForeColor = Color.DarkGray
        End If
    End Sub

    Private Sub passbox_GotFocus(sender As Object, e As EventArgs) Handles passbox.GotFocus
        If passbox.Text = "Password" Then
            passbox.Text = ""
            passbox.ForeColor = Color.Black
        End If
    End Sub

    Private Sub passbox_LostFocus(sender As Object, e As EventArgs) Handles passbox.LostFocus
        If passbox.Text = "" Then
            passbox.Text = "Password"
            passbox.ForeColor = Color.DarkGray
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class