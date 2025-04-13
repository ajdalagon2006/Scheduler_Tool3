Imports System.Data.SQLite

Public Class HolidayManager

    Public Shared Sub SetupHolidaysTable()
        Try
            Using connection As SQLiteConnection = DbConnection.GetConnection()
                connection.Open()

                ' Create Holidays table if it doesn't exist
                Dim createTableCmd As New SQLiteCommand(
                    "CREATE TABLE IF NOT EXISTS Holidays (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        date TEXT NOT NULL,
                        name TEXT NOT NULL,
                        is_recurring INTEGER DEFAULT 0,
                        color TEXT DEFAULT 'Red'
                    )", connection)

                createTableCmd.ExecuteNonQuery()
                connection.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error setting up holidays table: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Shared Sub AddDefaultHolidays(year As Integer)
        Try
            Using connection As SQLiteConnection = DbConnection.GetConnection()
                connection.Open()

                ' Add common Philippine holidays (adjust for your country)
                Dim holidays As New List(Of KeyValuePair(Of DateTime, String))()

                ' Fixed date holidays
                holidays.Add(New KeyValuePair(Of DateTime, String)(New DateTime(year, 1, 1), "New Year's Day"))
                holidays.Add(New KeyValuePair(Of DateTime, String)(New DateTime(year, 4, 9), "Araw ng Kagitingan"))
                holidays.Add(New KeyValuePair(Of DateTime, String)(New DateTime(year, 5, 1), "Labor Day"))
                holidays.Add(New KeyValuePair(Of DateTime, String)(New DateTime(year, 6, 12), "Independence Day"))
                holidays.Add(New KeyValuePair(Of DateTime, String)(New DateTime(year, 8, 21), "Ninoy Aquino Day"))
                holidays.Add(New KeyValuePair(Of DateTime, String)(New DateTime(year, 8, 30), "National Heroes Day"))
                holidays.Add(New KeyValuePair(Of DateTime, String)(New DateTime(year, 11, 1), "All Saints' Day"))
                holidays.Add(New KeyValuePair(Of DateTime, String)(New DateTime(year, 11, 30), "Bonifacio Day"))
                holidays.Add(New KeyValuePair(Of DateTime, String)(New DateTime(year, 12, 25), "Christmas Day"))
                holidays.Add(New KeyValuePair(Of DateTime, String)(New DateTime(year, 12, 30), "Rizal Day"))

                ' Insert each holiday, ignoring duplicates
                For Each holiday In holidays
                    Dim command As New SQLiteCommand(
                        "INSERT OR IGNORE INTO Holidays (date, name, is_recurring, color) VALUES (@date, @name, 1, 'Red')",
                        connection)

                    command.Parameters.AddWithValue("@date", holiday.Key.ToString("yyyy-MM-dd"))
                    command.Parameters.AddWithValue("@name", holiday.Value)
                    command.ExecuteNonQuery()
                Next

                connection.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error adding default holidays: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Shared Function GetHolidaysForDateRange(startDate As DateTime, endDate As DateTime) As List(Of KeyValuePair(Of DateTime, String))
        Dim holidays As New List(Of KeyValuePair(Of DateTime, String))()

        Try
            Using connection As SQLiteConnection = DbConnection.GetConnection()
                connection.Open()

                Dim command As New SQLiteCommand(
                    "SELECT date, name FROM Holidays WHERE date BETWEEN @startDate AND @endDate",
                    connection)

                command.Parameters.AddWithValue("@startDate", startDate.ToString("yyyy-MM-dd"))
                command.Parameters.AddWithValue("@endDate", endDate.ToString("yyyy-MM-dd"))

                Using reader As SQLiteDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim holidayDate As DateTime = DateTime.Parse(reader("date").ToString())
                        Dim holidayName As String = reader("name").ToString()

                        holidays.Add(New KeyValuePair(Of DateTime, String)(holidayDate, holidayName))
                    End While
                End Using

                connection.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error retrieving holidays: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return holidays
    End Function

    Public Shared Sub AddCustomHoliday(holidayDate As DateTime, holidayName As String, isRecurring As Boolean, color As String)
        Try
            Using connection As SQLiteConnection = DbConnection.GetConnection()
                connection.Open()

                Dim command As New SQLiteCommand(
                    "INSERT INTO Holidays (date, name, is_recurring, color) VALUES (@date, @name, @isRecurring, @color)",
                    connection)

                command.Parameters.AddWithValue("@date", holidayDate.ToString("yyyy-MM-dd"))
                command.Parameters.AddWithValue("@name", holidayName)
                command.Parameters.AddWithValue("@isRecurring", If(isRecurring, 1, 0))
                command.Parameters.AddWithValue("@color", color)

                command.ExecuteNonQuery()
                connection.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error adding custom holiday: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class