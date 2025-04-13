Imports System.Data.SQLite

Public Module DbHelper
    ' Central connection method for all classes to use
    Public Function GetConnection() As SQLiteConnection
        Dim connectionString As String = "Data Source=Appdatabase.db;Version=3;"
        Dim connection As New SQLiteConnection(connectionString)
        connection.Open()
        Return connection
    End Function

    Private Sub ExecuteNonQuery(connection As SQLiteConnection, commandText As String)
        Using command As New SQLiteCommand(commandText, connection)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Module