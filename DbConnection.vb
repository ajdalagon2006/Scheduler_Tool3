Imports System.Data.SQLite

Public Class DbConnection
    ' Make all methods Shared 
    Public Shared Function GetSQLiteConnection() As SQLiteConnection
        Dim connectionString As String = "Data Source=Appdatabase.db;Version=3;"
        Dim connection As New SQLiteConnection(connectionString)
        connection.Open()
        Return connection
    End Function

    Public Shared Function GetConnection() As SQLiteConnection
        ' This is for GetSQLiteConnection for backward compatibility
        Return GetSQLiteConnection()
    End Function

    Public Shared Sub UpdateDatabaseSchema()
        Try
            Using connection As SQLiteConnection = GetSQLiteConnection()
                Dim checkAlarmCmd As New SQLiteCommand(
                    "PRAGMA table_info(Task)", connection)

                Dim hasAlarmCol As Boolean = False
                Dim hasAlarmTimeCol As Boolean = False
                Dim hasCategoryCol As Boolean = False

                Using reader As SQLiteDataReader = checkAlarmCmd.ExecuteReader()
                    While reader.Read()
                        Dim colName As String = reader("name").ToString().ToLower()
                        If colName = "has_alarm" Then hasAlarmCol = True
                        If colName = "alarm_time" Then hasAlarmTimeCol = True
                        If colName = "category" Then hasCategoryCol = True
                    End While
                End Using

                ' columns
                If Not hasAlarmCol Then
                    Dim addAlarmCmd As New SQLiteCommand(
                        "ALTER TABLE Task ADD COLUMN has_alarm INTEGER DEFAULT 0", connection)
                    addAlarmCmd.ExecuteNonQuery()
                End If

                If Not hasAlarmTimeCol Then
                    Dim addTimeCmd As New SQLiteCommand(
                        "ALTER TABLE Task ADD COLUMN alarm_time TEXT", connection)
                    addTimeCmd.ExecuteNonQuery()
                End If

                If Not hasCategoryCol Then
                    Dim addCategoryCmd As New SQLiteCommand(
                        "ALTER TABLE Task ADD COLUMN category TEXT DEFAULT 'Other'", connection)
                    addCategoryCmd.ExecuteNonQuery()

                    ' category
                    Dim updateCmd As New SQLiteCommand(
                        "UPDATE Task SET category = 'Other' WHERE category IS NULL", connection)
                    updateCmd.ExecuteNonQuery()
                End If
            End Using
        Catch ex As Exception
            Console.WriteLine("Error updating database schema: " & ex.Message)
        End Try
    End Sub

    Public Shared Sub UpdateDatabaseSchemaForTags()
        Try
            Using connection As SQLiteConnection = GetSQLiteConnection()
                ' Check if Tags table exists
                Dim checkTagsTableCmd = New SQLiteCommand(
                    "SELECT name FROM sqlite_master WHERE type='table' AND name='Tags'", connection)

                If checkTagsTableCmd.ExecuteScalar() Is Nothing Then
                    Dim insertTagsCmd = New SQLiteCommand(
                        "INSERT INTO Tags (name) VALUES ('Personal'), ('Work'), ('Deadline'), ('Meeting'), ('Important')",
                        connection)
                    insertTagsCmd.ExecuteNonQuery()
                End If
                Dim checkTaskTagsTableCmd = New SQLiteCommand(
                    "SELECT name FROM sqlite_master WHERE type='table' AND name='TaskTags'", connection)

            End Using
        Catch ex As Exception
            Console.WriteLine("Error updating database schema for tags: " & ex.Message)
        End Try
    End Sub
End Class