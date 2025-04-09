Imports System.Data.SQLite

Public Class signin
    Private Sub signin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conn As New SQLiteConnection("Data Source=|DataDirectory|\Appdatabase.db;Version=3;")
        conn.Open()

        Dim checkCmd As New SQLiteCommand("SELECT COUNT(*) FROM Userdatabase", conn)
        Dim userCount As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

        If userCount > 0 Then
            uplink.Enabled = False
            uplink.Visible = False
        End If

        conn.Close()

        userbox.Text = "Username"
        userbox.ForeColor = Color.DarkGray

        passbox.Text = "Password"
        passbox.ForeColor = Color.DarkGray
    End Sub

    Private Sub loginbtn_Click(sender As Object, e As EventArgs) Handles Loginbtn.Click
        If userbox.Text = "" Then
            MessageBox.Show("Please enter a username")
            Return
        End If
        If passbox.Text = "" Then
            MessageBox.Show("Please enter a password")
            Return
        End If

        Dim conn As New SQLiteConnection("Data Source=|DataDirectory|\Appdatabase.db;Version=3;")
        Try
            conn.Open()
            Dim cmd As New SQLiteCommand("SELECT ID, Username FROM Userdatabase WHERE Username = @username AND Password = @password", conn)
            cmd.Parameters.AddWithValue("@username", userbox.Text)
            cmd.Parameters.AddWithValue("@password", passbox.Text)
            Dim reader As SQLiteDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                MessageBox.Show("Login successful")

                ' Ensure ID is not Nothing
                Dim userId As Integer = If(reader("ID") IsNot DBNull.Value, Convert.ToInt32(reader("ID")), 0)

                ' Only update LoggedIn if we got a valid ID
                If userId > 0 Then
                    Dim updateCmd As New SQLiteCommand("UPDATE Userdatabase SET LoggedIn = 1 WHERE ID = @id", conn)
                    updateCmd.Parameters.AddWithValue("@id", userId)
                    updateCmd.ExecuteNonQuery()
                End If

                reader.Close()  ' Close the reader before using data

                ' Ensure the Home form constructor expects an ID and username
                Dim homeForm As New Home(userId)
                homeForm.SetUsername(userbox.Text)
                homeForm.Show()
                Me.Hide()
            Else
                MessageBox.Show("Invalid username or password")
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub uplink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles uplink.LinkClicked
        Dim conn As New SQLiteConnection("Data Source=|DataDirectory|\Appdatabase.db;Version=3;")
        conn.Open()
        Dim cmd As New SQLiteCommand("SELECT COUNT(*) FROM Userdatabase", conn)
        Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
        conn.Close()

        If count >= 1 Then
            MessageBox.Show("Sign-up is disabled. An account already exists.")
        Else
            signup.Show()
            Me.Hide()
        End If
    End Sub

    ' UI helpers remain the same
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

    Private Sub forgotlink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles forgotlink.LinkClicked
        forgot.Show()
        Me.Hide()
    End Sub
End Class
