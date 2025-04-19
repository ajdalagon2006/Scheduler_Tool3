Imports System.Data.SQLite

Public Class forgot
    Private Sub cancelbtn_Click(sender As Object, e As EventArgs) Handles cancelbtn.Click
        signin.Show()
        Me.Hide()
    End Sub

    Private Sub resetbtn_Click(sender As Object, e As EventArgs) Handles resetbtn.Click
        ' First check if fields are filled
        If String.IsNullOrWhiteSpace(emailbox.Text) Then
            MessageBox.Show("Please enter your username in the email field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If String.IsNullOrWhiteSpace(codebox.Text) Then
            MessageBox.Show("Please enter your birthday in the code field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Try to verify user and reset password
        If VerifyUserDetails() Then
            ShowNewPasswordDialog()
        End If
    End Sub

    Private Function VerifyUserDetails() As Boolean
        Try
            ' Connect to the database
            Using connection As New SQLiteConnection("Data Source=D:\Scheduler_Tool\bin\Debug\Appdatabase.db;Version=3;")
                connection.Open()

                Dim enteredDate As DateTime
                Dim dateFormatted As String = ""

                ' Try to parse the date in multiple formats
                If DateTime.TryParseExact(codebox.Text.Trim(), "MM/dd/yyyy",
                                     System.Globalization.CultureInfo.InvariantCulture,
                                     System.Globalization.DateTimeStyles.None, enteredDate) Then
                    ' Format succeeded - MM/DD/YYYY
                    dateFormatted = enteredDate.ToString("yyyy-MM-dd")
                ElseIf DateTime.TryParseExact(codebox.Text.Trim(), "yyyy-MM-dd",
                                         System.Globalization.CultureInfo.InvariantCulture,
                                         System.Globalization.DateTimeStyles.None, enteredDate) Then
                    ' Format succeeded - YYYY-MM-DD
                    dateFormatted = enteredDate.ToString("yyyy-MM-dd")
                ElseIf DateTime.TryParse(codebox.Text.Trim(), enteredDate) Then
                    ' Generic parsing attempt
                    dateFormatted = enteredDate.ToString("yyyy-MM-dd")
                Else
                    MessageBox.Show("Please enter the birthday in MM/DD/YYYY format (e.g. 05/01/2007)",
                               "Invalid Format", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If

                ' Use SQL to compare only the date part (ignore time)
                Dim command As New SQLiteCommand(
                "SELECT ID FROM Userdatabase WHERE Username = @username AND date(Birthday) = @date",
                connection)

                command.Parameters.AddWithValue("@username", emailbox.Text.Trim())
                command.Parameters.AddWithValue("@date", dateFormatted)

                Dim result As Object = command.ExecuteScalar()

                If result IsNot Nothing Then
                    ' User found with matching username and birthday
                    Return True
                Else
                    MessageBox.Show("Invalid username or birthday. Please try again.",
                               "Verification Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub ShowNewPasswordDialog()
        ' Create a simple dialog to get new password
        Dim newPasswordForm As New Form()
        newPasswordForm.Text = "Reset Password"
        newPasswordForm.Size = New Size(400, 200)
        newPasswordForm.StartPosition = FormStartPosition.CenterScreen
        newPasswordForm.FormBorderStyle = FormBorderStyle.FixedDialog
        newPasswordForm.MaximizeBox = False
        newPasswordForm.MinimizeBox = False
        newPasswordForm.BackColor = Color.FromArgb(43, 46, 53)

        ' New password label
        Dim lblNewPassword As New Label()
        lblNewPassword.Text = "New Password:"
        lblNewPassword.AutoSize = True
        lblNewPassword.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        lblNewPassword.ForeColor = Color.FromArgb(219, 209, 236)
        lblNewPassword.Location = New Point(20, 30)
        newPasswordForm.Controls.Add(lblNewPassword)

        ' New password textbox
        Dim txtNewPassword As New TextBox()
        txtNewPassword.PasswordChar = "•"c
        txtNewPassword.Location = New Point(170, 30)
        txtNewPassword.Size = New Size(180, 25)
        newPasswordForm.Controls.Add(txtNewPassword)

        ' Confirm password label
        Dim lblConfirmPassword As New Label()
        lblConfirmPassword.Text = "Confirm Password:"
        lblConfirmPassword.AutoSize = True
        lblConfirmPassword.Font = New Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        lblConfirmPassword.ForeColor = Color.FromArgb(219, 209, 236)
        lblConfirmPassword.Location = New Point(20, 70)
        newPasswordForm.Controls.Add(lblConfirmPassword)

        ' Confirm password textbox
        Dim txtConfirmPassword As New TextBox()
        txtConfirmPassword.PasswordChar = "•"c
        txtConfirmPassword.Location = New Point(170, 70)
        txtConfirmPassword.Size = New Size(180, 25)
        newPasswordForm.Controls.Add(txtConfirmPassword)

        ' Save button
        Dim btnSave As New Button()
        btnSave.Text = "Save"
        btnSave.Location = New Point(100, 120)
        btnSave.Size = New Size(80, 30)
        AddHandler btnSave.Click, Sub(sender, e)
                                      ' Check if passwords match
                                      If txtNewPassword.Text = "" Then
                                          MessageBox.Show("Please enter a new password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                          Return
                                      End If

                                      If txtNewPassword.Text <> txtConfirmPassword.Text Then
                                          MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                          Return
                                      End If

                                      ' Update password in database
                                      If UpdatePassword(txtNewPassword.Text) Then
                                          MessageBox.Show("Password successfully reset! You can now log in with your new password.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                          newPasswordForm.Close()
                                          Me.Close()
                                          signin.Show()
                                      End If
                                  End Sub
        newPasswordForm.Controls.Add(btnSave)

        ' Cancel button
        Dim btnCancel As New Button()
        btnCancel.Text = "Cancel"
        btnCancel.Location = New Point(200, 120)
        btnCancel.Size = New Size(80, 30)
        AddHandler btnCancel.Click, Sub(sender, e) newPasswordForm.Close()
        newPasswordForm.Controls.Add(btnCancel)

        ' Show the dialog
        newPasswordForm.ShowDialog()
    End Sub

    Private Function UpdatePassword(newPassword As String) As Boolean
        Try
            ' Connect to the database
            Using connection As New SQLiteConnection("Data Source=D:\Scheduler_Tool\bin\Debug\Appdatabase.db;Version=3;")
                connection.Open()

                ' Update the password
                Dim command As New SQLiteCommand("UPDATE Userdatabase SET Password = @password WHERE Username = @username", connection)
                command.Parameters.AddWithValue("@password", newPassword)
                command.Parameters.AddWithValue("@username", emailbox.Text.Trim())

                Dim rowsAffected As Integer = command.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    ' Password updated successfully
                    Return True
                Else
                    MessageBox.Show("Failed to update password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub forgot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set tooltips to guide users
        Dim toolTip As New ToolTip()
        toolTip.SetToolTip(emailbox, "Enter your username here")
        toolTip.SetToolTip(codebox, "Enter your birthday in MM/DD/YYYY format")

        ' Optionally, you can change the label text to be more clear
        Label2.Text = "Enter Username"
        Label3.Text = "Enter Birthday"
    End Sub
End Class