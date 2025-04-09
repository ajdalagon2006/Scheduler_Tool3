Imports System.Data.SQLite

Public Class signup
    Private Sub signup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conn As New SQLiteConnection("Data Source=|DataDirectory|\Appdatabase.db;Version=3;")
        conn.Open()

        Dim checkCmd As New SQLiteCommand("SELECT COUNT(*) FROM Userdatabase", conn)
        Dim userCount As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

        If userCount > 0 Then
            MessageBox.Show("An account already exists. Sign-up is disabled.")
            signin.Show()
            Me.Hide()
        End If

        conn.Close()
    End Sub

    Private Sub upbtn_Click(sender As Object, e As EventArgs) Handles upbtn.Click
        Dim conn As New SQLiteConnection("Data Source=|DataDirectory|\Appdatabase.db;Version=3;")
        conn.Open()
        If userbox.Text = "" Or passbox.Text = "" Or (m1.Checked = False And f1.Checked = False) Then
            MessageBox.Show("Please fill all fields.")
            Return
        End If

        If userbox.Text.Length < 5 Or userbox.Text.Length > 20 Then
            MessageBox.Show("Username must be 5-20 characters.")
            Return
        End If
        If passbox.Text.Length < 9 Or passbox.Text.Length > 20 Then
            MessageBox.Show("Password must be 9-20 characters.")
            Return
        End If
        Dim genderVal As String = If(m1.Checked, "Male", "Female")
        Dim cmd As New SQLiteCommand("INSERT INTO Userdatabase (Username, Password, Birthday, Gender, LoggedIn) VALUES (@Username, @Password, @Birthday, @Gender, 0)", conn)
        cmd.Parameters.AddWithValue("@Username", userbox.Text)
        cmd.Parameters.AddWithValue("@Password", passbox.Text)
        cmd.Parameters.AddWithValue("@Birthday", bday.Value)
        cmd.Parameters.AddWithValue("@Gender", genderVal)
        cmd.ExecuteNonQuery()
        conn.Close()

        MessageBox.Show("Account created. Please log in.")
        signin.Show()
        Me.Hide()
    End Sub

    Private Sub showbtn_CheckedChanged(sender As Object, e As EventArgs) Handles showbtn.CheckedChanged
        passbox.UseSystemPasswordChar = Not showbtn.Checked
    End Sub

    Private Sub cancelbtn_Click(sender As Object, e As EventArgs) Handles cancelbtn.Click
        signin.Show()
        Me.Hide()
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
