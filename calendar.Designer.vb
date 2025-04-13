<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class calendar
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.DaysRow5Container = New System.Windows.Forms.Panel()
        Me.DaysRow4Container = New System.Windows.Forms.Panel()
        Me.DaysRow3Container = New System.Windows.Forms.Panel()
        Me.DaysRow2Container = New System.Windows.Forms.Panel()
        Me.DaysRow1Container = New System.Windows.Forms.Panel()
        Me.DaysRow0Container = New System.Windows.Forms.Panel()
        Me.DaysOfWeekContainer = New System.Windows.Forms.Panel()
        Me.MonthYearContainer = New System.Windows.Forms.Panel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TasksPanel = New System.Windows.Forms.Panel()
        Me.AlarmTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DaysRow5Container
        '
        Me.DaysRow5Container.BackColor = System.Drawing.Color.FromArgb(CType(CType(53, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.DaysRow5Container.Location = New System.Drawing.Point(22, 391)
        Me.DaysRow5Container.Name = "DaysRow5Container"
        Me.DaysRow5Container.Size = New System.Drawing.Size(757, 50)
        Me.DaysRow5Container.TabIndex = 14
        '
        'DaysRow4Container
        '
        Me.DaysRow4Container.BackColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(201, Byte), Integer))
        Me.DaysRow4Container.Location = New System.Drawing.Point(22, 334)
        Me.DaysRow4Container.Name = "DaysRow4Container"
        Me.DaysRow4Container.Size = New System.Drawing.Size(757, 50)
        Me.DaysRow4Container.TabIndex = 13
        '
        'DaysRow3Container
        '
        Me.DaysRow3Container.BackColor = System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(181, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.DaysRow3Container.Location = New System.Drawing.Point(21, 277)
        Me.DaysRow3Container.Name = "DaysRow3Container"
        Me.DaysRow3Container.Size = New System.Drawing.Size(757, 50)
        Me.DaysRow3Container.TabIndex = 12
        '
        'DaysRow2Container
        '
        Me.DaysRow2Container.BackColor = System.Drawing.Color.FromArgb(CType(CType(119, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(1, Byte), Integer))
        Me.DaysRow2Container.Location = New System.Drawing.Point(21, 220)
        Me.DaysRow2Container.Name = "DaysRow2Container"
        Me.DaysRow2Container.Size = New System.Drawing.Size(757, 50)
        Me.DaysRow2Container.TabIndex = 10
        '
        'DaysRow1Container
        '
        Me.DaysRow1Container.BackColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.DaysRow1Container.Location = New System.Drawing.Point(21, 163)
        Me.DaysRow1Container.Name = "DaysRow1Container"
        Me.DaysRow1Container.Size = New System.Drawing.Size(757, 50)
        Me.DaysRow1Container.TabIndex = 11
        '
        'DaysRow0Container
        '
        Me.DaysRow0Container.BackColor = System.Drawing.Color.FromArgb(CType(CType(104, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.DaysRow0Container.Location = New System.Drawing.Point(22, 106)
        Me.DaysRow0Container.Name = "DaysRow0Container"
        Me.DaysRow0Container.Size = New System.Drawing.Size(757, 50)
        Me.DaysRow0Container.TabIndex = 9
        '
        'DaysOfWeekContainer
        '
        Me.DaysOfWeekContainer.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.DaysOfWeekContainer.Location = New System.Drawing.Point(22, 66)
        Me.DaysOfWeekContainer.Name = "DaysOfWeekContainer"
        Me.DaysOfWeekContainer.Size = New System.Drawing.Size(757, 30)
        Me.DaysOfWeekContainer.TabIndex = 8
        '
        'MonthYearContainer
        '
        Me.MonthYearContainer.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(223, Byte), Integer))
        Me.MonthYearContainer.Location = New System.Drawing.Point(21, 9)
        Me.MonthYearContainer.Name = "MonthYearContainer"
        Me.MonthYearContainer.Size = New System.Drawing.Size(757, 50)
        Me.MonthYearContainer.TabIndex = 7
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(181, 48)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'TasksPanel
        '
        Me.TasksPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(243, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.TasksPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TasksPanel.Location = New System.Drawing.Point(250, 75)
        Me.TasksPanel.Name = "TasksPanel"
        Me.TasksPanel.Size = New System.Drawing.Size(300, 300)
        Me.TasksPanel.TabIndex = 15
        Me.TasksPanel.Visible = False
        '
        'AlarmTimer
        '
        Me.AlarmTimer.Interval = 60000
        '
        'calendar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TasksPanel)
        Me.Controls.Add(Me.DaysRow5Container)
        Me.Controls.Add(Me.DaysRow4Container)
        Me.Controls.Add(Me.DaysRow3Container)
        Me.Controls.Add(Me.DaysRow2Container)
        Me.Controls.Add(Me.DaysRow1Container)
        Me.Controls.Add(Me.DaysRow0Container)
        Me.Controls.Add(Me.DaysOfWeekContainer)
        Me.Controls.Add(Me.MonthYearContainer)
        Me.Name = "calendar"
        Me.Text = "calendar"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DaysRow5Container As Panel
    Friend WithEvents DaysRow4Container As Panel
    Friend WithEvents DaysRow3Container As Panel
    Friend WithEvents DaysRow2Container As Panel
    Friend WithEvents DaysRow1Container As Panel
    Friend WithEvents DaysRow0Container As Panel
    Friend WithEvents DaysOfWeekContainer As Panel
    Friend WithEvents MonthYearContainer As Panel
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TasksPanel As Panel
    Friend WithEvents AlarmTimer As Timer
End Class