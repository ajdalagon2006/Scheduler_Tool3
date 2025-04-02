Imports System.Data.SQLite


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
        Dim Enddate As DateTime = startDate.AddMonths(1).AddDays(-1)
        Dim connectionString As String = "Data Source=Appdata.db;Version=3;"
        Dim sql As String = $"select * From Database where date between '{startDate:yyyy-MM-dd}' and '{Enddate:yyyy-MM-dd}'"
        Dim dt As New DataTable

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
        f1Days.Controls.Clear()
        listf1day.Clear()
        For i As Integer = 1 To totalDays
            Dim f1 As New FlowLayoutPanel
            f1.Name = $"f1Day{i}"
            f1.Size = New Size(123, 95)
            f1.BackColor = Color.FromArgb(237, 233, 208)
            f1.BorderStyle = BorderStyle.FixedSingle
            f1.Cursor = Cursors.Hand
            f1.AutoScroll = True
            AddHandler f1.Click, AddressOf Addtasktof1day
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