Imports FontAwesome.Sharp
Imports Microsoft.VisualBasic.ApplicationServices
Imports System.Data.SQLite

Public Class Home
    Private userId As Integer

    ' Constructor accepting user ID
    Public Sub New(userId As Integer)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.userId = userId
        topBorderBtn = New Panel()
        topBorderBtn.Size = New Size(7, 60)
        Panelmenu.Controls.Add(topBorderBtn)
    End Sub

    Private Sub Home0_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        topBorderBtn = New Panel()
        topBorderBtn.Size = New Size(7, 60)
        Panelmenu.Controls.Add(topBorderBtn)

        Dim username As String = GetUsername()
        SetUsername(username)
        Me.AutoScroll = True
    End Sub


    Public Sub SetUsername(user As String)
        username = user
        If String.IsNullOrEmpty(username) Then
            lbluser.Text = "Welcome User!"
        Else
            lbluser.Text = $"Welcome Back {username}!"
        End If
    End Sub

    Private Function GetUsername() As String
        Dim username As String = String.Empty
        Dim conn As New SQLiteConnection("Data Source=E:\Scheduler_Tool\bin\Debug\Appdatabase.db;Version=3;")
        Try
            conn.Open()
            Dim cmd As New SQLiteCommand("SELECT Username FROM Userdatabase WHERE ID = @id", conn)
            cmd.Parameters.AddWithValue("@id", userId)
            Dim reader As SQLiteDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                username = reader("Username").ToString()
            End If
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error retrieving username: " & ex.Message)
        Finally
            conn.Close()
        End Try
        Return username
    End Function

    'Fields
    Private currentBtn As IconButton
    Private topBorderBtn As Panel
    Private currentChildForm As Form

    'Methods
    Private Sub ActivateButton(senderBtn As Object, customcolor As Color)
        DisableButton()
        If senderBtn IsNot Nothing Then
            'Button
            currentBtn = CType(senderBtn, IconButton)
            currentBtn.BackColor = Color.FromArgb(54, 57, 66)
            currentBtn.ForeColor = customcolor
            currentBtn.TextAlign = ContentAlignment.MiddleRight
            currentBtn.IconColor = customcolor
            currentBtn.ImageAlign = ContentAlignment.MiddleCenter
            currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage
            'top border button
            topBorderBtn.BackColor = customcolor
            topBorderBtn.BackColor = Color.FromArgb(54, 57, 66)
            topBorderBtn.Location = New Point(0, currentBtn.Location.Y)
            topBorderBtn.Visible = True
            topBorderBtn.BringToFront()
            'current form icon
            homecurrenticon.IconChar = currentBtn.IconChar
            homecurrenticon.IconColor = customcolor
        End If
    End Sub

    Private Sub OpenChildForm(childForm As Form)
        'Open Only Form 
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
        End If
        currentChildForm = childForm
        'end
        childForm.TopLevel = False
        childForm.FormBorderStyle = FormBorderStyle.None
        childForm.Dock = DockStyle.Fill
        Paneldesktop.Controls.Add(childForm)
        Paneldesktop.Tag = childForm
        childForm.BringToFront()
        childForm.Show()
        lblFormTitle.Text = childForm.Text
    End Sub

    Private Sub DisableButton()
        If currentBtn IsNot Nothing Then
            currentBtn.BackColor = Color.FromArgb(43, 46, 53)
            currentBtn.ForeColor = Color.FromArgb(226, 234, 247)
            currentBtn.IconColor = Color.FromArgb(226, 234, 247)
            currentBtn.TextAlign = ContentAlignment.MiddleCenter
            currentBtn.ImageAlign = ContentAlignment.MiddleRight
            currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText
        End If
    End Sub
    Private username As String

    Private Sub Home_Click(sender As Object, e As EventArgs) Handles homebtn.Click
        If currentChildForm IsNot Nothing Then
            currentChildForm.Close()
        End If
        Reset()
    End Sub

    Private Sub Reset()
        DisableButton()
        topBorderBtn.Visible = False
        homecurrenticon.IconChar = IconChar.HomeUser
        lblFormTitle.Text = "Home"
    End Sub

    Private Sub viewbtn_Click(sender As Object, e As EventArgs) Handles viewbtn.Click
        ActivateButton(sender, btncolor.color1)
        OpenChildForm(New calendar)
        lblFormTitle.Text = "Calendar View"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim addEditForm As New Task(DateTime.Now) ' Pass the current date or any specific date
        addEditForm.Show()
    End Sub


End Class