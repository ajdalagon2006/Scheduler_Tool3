Imports System.Data.SQLite
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class View
    Private listf1day As New List(Of FlowLayoutPanel)
    Private currentDate As DateTime = DateTime.Today
    Private notifyIcon As New NotifyIcon()

    Private Sub ConfigureNotifyIcon()
        notifyIcon.Icon = SystemIcons.Information
        notifyIcon.Visible = True
    End Sub

    Private Sub View_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GenerateDayPanel(42)
        DisplayCurrentDate()
        Me.AutoScroll = True
    End Sub

    Private Sub Addtasktof1day()
        Dim startDate As DateTime = New Date(currentDate.Year, currentDate.Month, 1)
        Dim endDate As DateTime = startDate.AddMonths(1).AddDays(-1)
        Dim conn As New SQLiteConnection("Data Source=|DataDirectory|\Appdatabase.db;Version=3;")
        Try
            conn.Open()
            Dim cmd As New SQLiteCommand("SELECT * FROM Task WHERE Date BETWEEN @startDate AND @endDate", conn)
            cmd.Parameters.AddWithValue("@startDate", startDate.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@endDate", endDate.ToString("yyyy-MM-dd"))
            Dim reader As SQLiteDataReader = cmd.ExecuteReader()
            While reader.Read()
                Dim taskDate As DateTime
                If DateTime.TryParse(reader("Date").ToString(), taskDate) Then
                    Dim link As New LinkLabel()
                    link.Tag = reader("ID")
                    link.Name = $"link{reader("ID")}"
                    link.Text = reader("todoname").ToString()
                    listf1day(taskDate.Day + (GetFirstDayOfWeekOfCurrentdate() - 1)).Controls.Add(link)
                    If taskDate.Date = DateTime.Today Then
                        notifyIcon.BalloonTipTitle = "Task Due Today"
                        notifyIcon.BalloonTipText = $"Task: {reader("todoname")}"
                        notifyIcon.ShowBalloonTip(3000)
                    End If
                Else
                    MessageBox.Show("Error parsing task date: " & reader("Date").ToString())
                End If
            End While
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error retrieving tasks: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub DisplayCurrentDate()
        lblmonth.Text = currentDate.ToString("MMMM, yyyy")
        Dim firstdayatf1number As Integer = GetFirstDayOfWeekOfCurrentdate()
        Dim totalDay As Integer = GetTotalDayOfCurrentDate()
        AddlabelDaytof1day(firstdayatf1number, totalDay)
        Addtasktof1day()
    End Sub

    Private Sub Nextmonth()
        currentDate = currentDate.AddMonths(1)
        DisplayCurrentDate()
    End Sub

    Private Sub Today()
        currentDate = DateTime.Today
        DisplayCurrentDate()
    End Sub

    Private Function GetFirstDayOfWeekOfCurrentdate() As Integer
        Dim firstdayofmonth As DateTime = New Date(currentDate.Year, currentDate.Month, 1)
        Return firstdayofmonth.DayOfWeek + 1
    End Function

    Private Function GetTotalDayOfCurrentDate() As Integer
        Dim firstdayofcurrentday As DateTime = New Date(currentDate.Year, currentDate.Month, 1)
        Return firstdayofcurrentday.AddMonths(1).AddDays(-1).Day
    End Function

    Private Sub GenerateDayPanel(ByVal totalDays As Integer)
        f1days.Controls.Clear()
        listf1day.Clear()
        For i As Integer = 1 To totalDays
            Dim f1 As New FlowLayoutPanel
            f1.Name = $"f1Day{i}"
            f1.Size = New Size(123, 95)
            f1.BackColor = Color.FromArgb(237, 233, 208)
            f1.BorderStyle = BorderStyle.FixedSingle
            f1.Cursor = Cursors.Hand
            f1.AutoScroll = True
            f1days.Controls.Add(f1)
            listf1day.Add(f1)
        Next
    End Sub

    Private Sub AddlabelDaytof1day(ByVal startDayAtf1Number As Integer, ByVal totalDaysInMonth As Integer)
        For Each f1 As FlowLayoutPanel In listf1day
            f1.Controls.Clear()
            f1.Tag = 0
        Next

        For i As Integer = 1 To totalDaysInMonth
            Dim lbl As New Label
            lbl.Name = $"lblday{i}"
            lbl.AutoSize = False
            lbl.TextAlign = ContentAlignment.TopRight
            lbl.Size = New Size(96, 23)
            lbl.Text = i
            lbl.Font = New Font("Microsoft Sans Serif", 11.25)
            listf1day(i - 1 + startDayAtf1Number - 1).Tag = i
            listf1day(i - 1 + startDayAtf1Number - 1).Controls.Clear()
            listf1day(i - 1 + startDayAtf1Number - 1).Controls.Add(lbl)
        Next
    End Sub

    Private Sub nextbtn_Click(sender As Object, e As EventArgs) Handles nextbtn.Click
        Nextmonth()
    End Sub

    Private Sub btntoday_Click(sender As Object, e As EventArgs) Handles btntoday.Click
        Today()
    End Sub
End Class
