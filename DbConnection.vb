Imports System.Data.SQLite
Imports System.IO

''' <summary>
''' Database connection and schema management module
''' </summary>
Public Module DbConnection
    ''' <summary>
    ''' Gets an open connection to the SQLite database (primary method)
    ''' </summary>
    Public Function GetConnection() As SQLiteConnection
        Dim connectionString As String = "Data Source=Appdatabase.db;Version=3;"
        Dim connection As New SQLiteConnection(connectionString)
        connection.Open()
        Return connection
    End Function

    ''' <summary>
    ''' Gets an open connection to the SQLite database (alias for compatibility)
    ''' </summary>
    Public Function GetSQLiteConnection() As SQLiteConnection
        Return GetConnection()
    End Function

    ''' <summary>
    ''' Updates the database schema to include alarm-related columns
    ''' </summary>
    Public Sub UpdateDatabaseSchema()
        Try
            Using connection As SQLiteConnection = GetConnection()
                ' Check if alarm columns exist in Task table
                Dim cmd As New SQLiteCommand("PRAGMA table_info(Task)", connection)
                Dim reader As SQLiteDataReader = cmd.ExecuteReader()

                Dim hasAlarmCol As Boolean = False
                Dim hasAlarmTimeCol As Boolean = False
                Dim hasAlarmSoundCol As Boolean = False

                While reader.Read()
                    Dim colName As String = reader("name").ToString().ToLower()
                    If colName = "has_alarm" Then hasAlarmCol = True
                    If colName = "alarm_time" Then hasAlarmTimeCol = True
                    If colName = "alarm_sound" Then hasAlarmSoundCol = True
                End While
                reader.Close()

                ' Add missing columns
                If Not hasAlarmCol Then
                    Dim alterCmd As New SQLiteCommand("ALTER TABLE Task ADD COLUMN has_alarm INTEGER DEFAULT 0", connection)
                    alterCmd.ExecuteNonQuery()
                    Console.WriteLine("Added has_alarm column to Task table")
                End If

                If Not hasAlarmTimeCol Then
                    Dim alterCmd As New SQLiteCommand("ALTER TABLE Task ADD COLUMN alarm_time TEXT", connection)
                    alterCmd.ExecuteNonQuery()
                    Console.WriteLine("Added alarm_time column to Task table")
                End If

                If Not hasAlarmSoundCol Then
                    Dim alterCmd As New SQLiteCommand("ALTER TABLE Task ADD COLUMN alarm_sound TEXT DEFAULT 'default.wav'", connection)
                    alterCmd.ExecuteNonQuery()
                    Console.WriteLine("Added alarm_sound column to Task table")
                End If

                ' Create Holidays table if it doesn't exist
                Dim createHolidaysCmd As New SQLiteCommand(
                    "CREATE TABLE IF NOT EXISTS Holidays (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        date TEXT NOT NULL,
                        name TEXT NOT NULL,
                        is_recurring INTEGER DEFAULT 0,
                        color TEXT DEFAULT 'Red'
                    )", connection)
                createHolidaysCmd.ExecuteNonQuery()
                Console.WriteLine("Created or verified Holidays table")
            End Using

            Console.WriteLine("Database schema update completed successfully")
        Catch ex As Exception
            MessageBox.Show("Error updating database schema: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Module