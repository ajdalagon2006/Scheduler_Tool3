Imports System.Data.SQLite
Imports System.Diagnostics.Eventing.Reader
Public Class signup

    Private Sub showbtn_CheckedChanged(sender As Object, e As EventArgs) Handles showbtn.CheckedChanged
        passbox.UseSystemPasswordChar = Not showbtn.Checked
    End Sub

    Private Sub cancelbtn_Click(sender As Object, e As EventArgs) Handles cancelbtn.Click
        signin.Show()
        Me.Hide()
    End Sub

    Private Sub upbtn_Click(sender As Object, e As EventArgs) Handles upbtn.Click
        Dim conn As New SQLiteConnection("Data Source=D:\Scheduler_Tool\bin\Debug\Appdatabase.db;Version=3;")
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If

        Dim cmd As New SQLiteCommand("Select username from Userdatabase where username = @username", conn)
        cmd.Parameters.AddWithValue("@username", userbox.Text)
        Dim er As SQLiteDataReader = cmd.ExecuteReader()
        If (er.Read()) Then
            MessageBox.Show("Username already exists")
            conn.Close()
        Else
            conn.Close()
            Dim cmd2 As New SQLiteCommand("INSERT INTO Userdatabase(Username, Password, Birthday, Gender)Values(@Username, @Password, @Birthday, @Gender)", conn)
            cmd2.Parameters.AddWithValue("@Username", userbox.Text)
            cmd2.Parameters.AddWithValue("@Password", passbox.Text)
            cmd2.Parameters.AddWithValue("@Birthday", bday.Value)

            Dim gender_v As Boolean
            If m1.Checked = True Then
                gender_v = 1 'Male
            End If

            If f1.Checked = True Then
                gender_v = 0 'Female
            End If
            cmd2.Parameters.AddWithValue("Gender", gender_v)

            If userbox.Text = "" Then
                MessageBox.Show("Please enter a username")
            End If

            If passbox.Text = "" Then
                MessageBox.Show("Please enter a password")
            End If

            If m1.Checked = False And f1.Checked = False Then
                MessageBox.Show("Please select gender")
            End If

            If userbox.Text.Length < 5 OrElse userbox.Text.Length > 20 Then
                MessageBox.Show("Username must be between 5 and 20 characters.", "Error")
                Exit Sub
            End If

            If passbox.Text.Length < 9 OrElse passbox.Text.Length > 20 Then
                MessageBox.Show("Password must be between 9 and 20 characters.", "Error")
                Exit Sub
            End If

            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If

            cmd2.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("Account created successfully")
            MessageBox.Show("Please login to continue")
            signin.Show()
            Me.Hide()
        End If


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
End Class