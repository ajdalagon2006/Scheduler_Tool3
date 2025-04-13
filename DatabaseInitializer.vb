Imports System.Data.SQLite
Imports System.IO

Public Class DatabaseInitializer
    Public Shared Sub InitializeDatabase()
        ' Ensure database directory exists
        Dim dbPath As String = "Appdatabase.db"

        ' Create database file if it doesn't exist
        If Not File.Exists(dbPath) Then
            SQLiteConnection.CreateFile(dbPath)
        End If

        ' Open connection
        Using connection As New SQLiteConnection("Data Source=" & dbPath & ";Version=3;")
            connection.Open()

            ' Create Holidays table
            ExecuteNonQuery(connection,
                "CREATE TABLE IF NOT EXISTS Holidays (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    date TEXT NOT NULL,
                    name TEXT NOT NULL,
                    is_recurring INTEGER DEFAULT 0,
                    color TEXT DEFAULT 'Red'
                )")

            connection.Close()
        End Using
    End Sub

    Private Shared Sub ExecuteNonQuery(connection As SQLiteConnection, commandText As String)
        Using command As New SQLiteCommand(commandText, connection)
            command.ExecuteNonQuery()
        End Using
    End Sub
End Class