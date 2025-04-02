Imports System.Data.SQLite

Public Class task
    Private Sub upbtn_Click(sender As Object, e As EventArgs) Handles createbtn.Click
        Dim conn As New SQLiteConnection("Data Source=D:\Scheduler_Tool\bin\Debug\Appdatabase.db;Version=3;")
        If conn.State = ConnectionState.Closed Then
            conn.Open()
        End If
        Dim cmd As New SQLiteCommand("Select todoname from Task where todoname = @todoname", conn)
        cmd.Parameters.AddWithValue("@todoname", todobox.Text)
        Dim er As SQLiteDataReader = cmd.ExecuteReader()
        If (er.Read()) Then
            MessageBox.Show("This task is already exists")
            conn.Close()
        Else
            conn.Close()
            Dim cmd2 As New SQLiteCommand("INSERT INTO Task(todoname, Comment, category, Date) VALUES (@todoname, @Comment, @category, @Date)", conn)
            cmd2.Parameters.AddWithValue("@todoname", todobox.Text)
            cmd2.Parameters.AddWithValue("@Comment", comsecbox.Text)
            cmd2.Parameters.AddWithValue("@Date", date1.Value)

            Dim category_v As Boolean
            If e1.Checked = True Then
                category_v = 1 'Event
            End If
            If s1.Checked = True Then
                category_v = 0 'School
            End If
            cmd2.Parameters.AddWithValue("@category", category_v)

            If todobox.Text = "" Then
                MessageBox.Show("Please enter a task name")
            End If
            If e1.Checked = False And s1.Checked = False Then
                MessageBox.Show("Please select a category")
            End If
            If conn.State = ConnectionState.Closed Then
                conn.Open()
            End If
            cmd2.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("Task created successfully")
            Me.Hide()
        End If
    End Sub
End Class
