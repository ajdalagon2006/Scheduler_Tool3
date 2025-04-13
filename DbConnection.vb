Imports System.Data.SQLite

Module DbConnection
    Public Function GetConnection() As SQLiteConnection
        Return New SQLiteConnection("Data Source=D:\Scheduler_Tool\bin\Debug\Appdatabase.db;Version=3;")
    End Function
End Module
