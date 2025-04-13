Imports System.Data.SQLite
Imports System.IO

Public Module DbConnection
    ' Central connection method for all classes to use
    Public Function GetSQLiteConnection() As SQLiteConnection
        Dim connectionString As String = "Data Source=Appdatabase.db;Version=3;"
        Dim connection As New SQLiteConnection(connectionString)
        connection.Open()
        Return connection
    End Function

    ' Update database schema to include alarm fields without losing data
    Public Sub UpdateDatabaseSchema()
        Try
            Using connection As SQLiteConnection = GetSQLiteConnection()
                ' Check if we need to add columns to the Task table
                Dim checkColumnsCmd As New SQLiteCommand(
                    "PRAGMA table_info(Task)", connection)

                Dim hasAlarmColumn As Boolean = False
                Dim hasAlarmTimeColumn As Boolean = False
                Dim hasAlarmSoundColumn As Boolean = False

                Using reader As SQLiteDataReader = checkColumnsCmd.ExecuteReader()
                    While reader.Read()
                        Dim columnName As String = reader("name").ToString()
                        If columnName = "has_alarm" Then hasAlarmColumn = True
                        If columnName = "alarm_time" Then hasAlarmTimeColumn = True
                        If columnName = "alarm_sound" Then hasAlarmSoundColumn = True
                    End While
                End Using

                ' Add columns if they don't exist
                If Not hasAlarmColumn Then
                    Dim alterTableCmd As New SQLiteCommand(
                        "ALTER TABLE Task ADD COLUMN has_alarm INTEGER DEFAULT 0", connection)
                    alterTableCmd.ExecuteNonQuery()
                End If

                If Not hasAlarmTimeColumn Then
                    Dim alterTableCmd As New SQLiteCommand(
                        "ALTER TABLE Task ADD COLUMN alarm_time TEXT", connection)
                    alterTableCmd.ExecuteNonQuery()
                End If

                If Not hasAlarmSoundColumn Then
                    Dim alterTableCmd As New SQLiteCommand(
                        "ALTER TABLE Task ADD COLUMN alarm_sound TEXT DEFAULT 'default.wav'", connection)
                    alterTableCmd.ExecuteNonQuery()
                End If
            End Using

            Console.WriteLine("Database schema update completed successfully.")
        Catch ex As Exception
            MessageBox.Show("Error updating database schema: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Module