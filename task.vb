Imports System.Data.SQLite

Public Class Task

    Public DataSaved As Boolean
    Public NewNote As String
    Private IsEdit As Boolean
    Private SelectedDate As DateTime
    Private OriginalNote As String
    Private connection As SQLiteConnection

    Public Sub New(d As DateTime)
        InitializeComponent()

        IsEdit = False
        SelectedDate = d
        connection = New SQLiteConnection("Data Source=tasks.db;Version=3;")
    End Sub

    Public Sub New(d As DateTime, text As String)
        InitializeComponent()

        IsEdit = True
        SelectedDate = d
        OriginalNote = text
        connection = New SQLiteConnection("Data Source=tasks.db;Version=3;")
    End Sub

    Private Sub AddEditCalendarEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataSaved = False
        date1.Value = SelectedDate

        If IsEdit Then
            Me.Text = "Edit"
            todobox.Text = OriginalNote
        Else
            Me.Text = "Add"
            comsecbox.Clear()
        End If
    End Sub

    Private Sub SaveTask()
        If SelectedDate < Now Then
            MessageBox.Show("Cannot add task to a past date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        connection.Open()
        Dim command As SQLiteCommand
        If IsEdit Then
            command = New SQLiteCommand("UPDATE tasks SET todoname = @todoname, comment = @comment WHERE date = @date", connection)
            command.Parameters.AddWithValue("@todoname", todobox.Text)
            command.Parameters.AddWithValue("@comment", comsecbox.Text)
            command.Parameters.AddWithValue("@date", SelectedDate.ToString("yyyy-MM-dd"))
        Else
            command = New SQLiteCommand("INSERT INTO tasks (todoname, comment, date, category) VALUES (@todoname, @comment, @date, @category)", connection)
            command.Parameters.AddWithValue("@todoname", todobox.Text)
            command.Parameters.AddWithValue("@comment", comsecbox.Text)
            command.Parameters.AddWithValue("@date", SelectedDate.ToString("yyyy-MM-dd"))
            command.Parameters.AddWithValue("@category", If(e1.Checked, "Event", "School Works"))
        End If

        command.ExecuteNonQuery()
        connection.Close()
        DataSaved = True
        Me.Close()
    End Sub

    Private Sub Savebtn_Click(sender As Object, e As EventArgs) Handles createbtn.Click
        SaveTask()
    End Sub

    Private Sub Cancelbtn_Click(sender As Object, e As EventArgs) Handles Cancelbtn.Click
        Me.Hide()
    End Sub
End Class
