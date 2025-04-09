Public Class MonthlyCalendarInfo

    Private _Month As Integer
    Private _Year As Integer
    Private ReadOnly _Days(5, 6) As DateTime

    Public ReadOnly Property Month
        Get
            Return _Month
        End Get
    End Property

    Public ReadOnly Property Year
        Get
            Return _Year
        End Get
    End Property

    Public Sub New()

        _Month = Now.Month
        _Year = Now.Year
        SetDays()

    End Sub

    Public Sub New(year As Integer, month As Integer)

        If year < 1 Or year > 9999 Then
            Throw New ArgumentOutOfRangeException("year")
        End If

        If month < 1 Or month > 12 Then
            Throw New ArgumentOutOfRangeException("month")
        End If

        _Month = month
        _Year = year
        SetDays()

    End Sub

    Private Sub SetDays()

        Dim firstDateOfMonth As DateTime
        Dim firstDateOfMonthColumn As Integer
        Dim firstDateInGrid As DateTime
        Dim currentGridDate As DateTime

        firstDateOfMonth = New Date(_Year, _Month, 1)
        firstDateOfMonthColumn = CInt(firstDateOfMonth.DayOfWeek)
        firstDateInGrid = firstDateOfMonth.AddDays(firstDateOfMonthColumn * -1)
        currentGridDate = firstDateInGrid

        For rowIndex As Integer = 0 To 5

            For columnIndex As Integer = 0 To 6
                _Days(rowIndex, columnIndex) = currentGridDate
                currentGridDate = currentGridDate.AddDays(1)
            Next

        Next

        Return

    End Sub

    Public Sub GoToMonth(year As Integer, month As Integer)

        If year < 1 Or year > 9999 Then
            Throw New ArgumentOutOfRangeException("year")
        End If

        If month < 1 Or month > 12 Then
            Throw New ArgumentOutOfRangeException("month")
        End If

        _Year = year
        _Month = month
        SetDays()

    End Sub

    Public Function DayInMonth(row As Integer, column As Integer) As Integer

        If row < 0 Or row > 5 Then
            Throw New ArgumentOutOfRangeException("row")
        End If

        If column < 0 Or column > 6 Then
            Throw New ArgumentOutOfRangeException("column")
        End If

        Return _Days(row, column).Day

    End Function

    'Return full date for passed row/column
    Public Function DateInYear(row As Integer, column As Integer)

        If row < 0 Or row > 5 Then
            Throw New ArgumentOutOfRangeException("row")
        End If

        If column < 0 Or column > 6 Then
            Throw New ArgumentOutOfRangeException("column")
        End If

        Return _Days(row, column)

    End Function

    Public Function IsActiveMonth(row As Integer, column As Integer) As Boolean

        If row < 0 Or row > 5 Then
            Throw New ArgumentOutOfRangeException("row")
        End If

        If column < 0 Or column > 6 Then
            Throw New ArgumentOutOfRangeException("column")
        End If

        Return _Days(row, column).Month = Month

    End Function

    Public Function IsToday(row As Integer, column As Integer) As Boolean

        If row < 0 Or row > 5 Then
            Throw New ArgumentOutOfRangeException("row")
        End If

        If column < 0 Or column > 6 Then
            Throw New ArgumentOutOfRangeException("column")
        End If

        Return _Days(row, column).Date = Now.Date

    End Function

    Public Function DateRow(d As DateTime) As Integer

        For rowIndex As Integer = 0 To 5

            For columnIndex = 0 To 6
                If _Days(rowIndex, columnIndex) = d Then
                    Return rowIndex
                End If
            Next

        Next

        Return -1

    End Function

    Public Function DateColumn(d As DateTime) As Integer

        For rowIndex As Integer = 0 To 5

            For columnIndex = 0 To 6

                If _Days(rowIndex, columnIndex) = d Then
                    Return columnIndex
                End If

            Next
        Next

        Return -1

    End Function

    Public Function DateExists(d As DateTime) As Boolean

        If DateRow(d) > -1 Then
            Return True
        End If

        Return False

    End Function

End Class
