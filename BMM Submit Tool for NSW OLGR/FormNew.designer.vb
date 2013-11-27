<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormNew
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Finish_Button = New System.Windows.Forms.Button
        Me.Project_GroupBox = New System.Windows.Forms.GroupBox
        Me.ARN_TextBox = New System.Windows.Forms.MaskedTextBox
        Me.Type_ComboBox = New System.Windows.Forms.ComboBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Type_Label = New System.Windows.Forms.Label
        Me.ARN_Label = New System.Windows.Forms.Label
        Me.ProjectName_TextBox = New System.Windows.Forms.TextBox
        Me.GameName_Label = New System.Windows.Forms.Label
        Me.ProjectCode_TextBox = New System.Windows.Forms.TextBox
        Me.ProjectCode_Label = New System.Windows.Forms.Label
        Me.File_GroupBox = New System.Windows.Forms.GroupBox
        Me.SelectFolder_Button = New System.Windows.Forms.Button
        Me.Directory_ListBox = New System.Windows.Forms.ListBox
        Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog
        Me.BackgroundWorker = New System.ComponentModel.BackgroundWorker
        Me.Project_GroupBox.SuspendLayout()
        Me.File_GroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'Finish_Button
        '
        Me.Finish_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Finish_Button.Location = New System.Drawing.Point(428, 409)
        Me.Finish_Button.Name = "Finish_Button"
        Me.Finish_Button.Size = New System.Drawing.Size(100, 35)
        Me.Finish_Button.TabIndex = 6
        Me.Finish_Button.Text = "Add"
        Me.Finish_Button.UseVisualStyleBackColor = True
        '
        'Project_GroupBox
        '
        Me.Project_GroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Project_GroupBox.Controls.Add(Me.ARN_TextBox)
        Me.Project_GroupBox.Controls.Add(Me.Type_ComboBox)
        Me.Project_GroupBox.Controls.Add(Me.TableLayoutPanel1)
        Me.Project_GroupBox.Controls.Add(Me.Type_Label)
        Me.Project_GroupBox.Controls.Add(Me.ARN_Label)
        Me.Project_GroupBox.Controls.Add(Me.ProjectName_TextBox)
        Me.Project_GroupBox.Controls.Add(Me.GameName_Label)
        Me.Project_GroupBox.Controls.Add(Me.ProjectCode_TextBox)
        Me.Project_GroupBox.Controls.Add(Me.ProjectCode_Label)
        Me.Project_GroupBox.Location = New System.Drawing.Point(12, 12)
        Me.Project_GroupBox.Name = "Project_GroupBox"
        Me.Project_GroupBox.Size = New System.Drawing.Size(516, 181)
        Me.Project_GroupBox.TabIndex = 23
        Me.Project_GroupBox.TabStop = False
        Me.Project_GroupBox.Text = "Project Information"
        '
        'ARN_TextBox
        '
        Me.ARN_TextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ARN_TextBox.Location = New System.Drawing.Point(109, 106)
        Me.ARN_TextBox.Mask = "00-\A0000-S00"
        Me.ARN_TextBox.Name = "ARN_TextBox"
        Me.ARN_TextBox.Size = New System.Drawing.Size(401, 22)
        Me.ARN_TextBox.TabIndex = 2
        '
        'Type_ComboBox
        '
        Me.Type_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Type_ComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Type_ComboBox.FormattingEnabled = True
        Me.Type_ComboBox.Location = New System.Drawing.Point(109, 149)
        Me.Type_ComboBox.Name = "Type_ComboBox"
        Me.Type_ComboBox.Size = New System.Drawing.Size(144, 24)
        Me.Type_ComboBox.TabIndex = 3
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(109, 193)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(200, 100)
        Me.TableLayoutPanel1.TabIndex = 31
        '
        'Type_Label
        '
        Me.Type_Label.AutoSize = True
        Me.Type_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Type_Label.Location = New System.Drawing.Point(6, 149)
        Me.Type_Label.Name = "Type_Label"
        Me.Type_Label.Size = New System.Drawing.Size(44, 17)
        Me.Type_Label.TabIndex = 33
        Me.Type_Label.Text = "Type:"
        '
        'ARN_Label
        '
        Me.ARN_Label.AutoSize = True
        Me.ARN_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ARN_Label.Location = New System.Drawing.Point(6, 109)
        Me.ARN_Label.Name = "ARN_Label"
        Me.ARN_Label.Size = New System.Drawing.Size(41, 17)
        Me.ARN_Label.TabIndex = 32
        Me.ARN_Label.Text = "ARN:"
        '
        'ProjectName_TextBox
        '
        Me.ProjectName_TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ProjectName_TextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ProjectName_TextBox.Location = New System.Drawing.Point(109, 63)
        Me.ProjectName_TextBox.Name = "ProjectName_TextBox"
        Me.ProjectName_TextBox.Size = New System.Drawing.Size(401, 23)
        Me.ProjectName_TextBox.TabIndex = 1
        '
        'GameName_Label
        '
        Me.GameName_Label.AutoSize = True
        Me.GameName_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GameName_Label.Location = New System.Drawing.Point(6, 66)
        Me.GameName_Label.Name = "GameName_Label"
        Me.GameName_Label.Size = New System.Drawing.Size(97, 17)
        Me.GameName_Label.TabIndex = 29
        Me.GameName_Label.Text = "Project Name:"
        '
        'ProjectCode_TextBox
        '
        Me.ProjectCode_TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ProjectCode_TextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ProjectCode_TextBox.Location = New System.Drawing.Point(109, 19)
        Me.ProjectCode_TextBox.Name = "ProjectCode_TextBox"
        Me.ProjectCode_TextBox.Size = New System.Drawing.Size(401, 23)
        Me.ProjectCode_TextBox.TabIndex = 0
        '
        'ProjectCode_Label
        '
        Me.ProjectCode_Label.AutoSize = True
        Me.ProjectCode_Label.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ProjectCode_Label.Location = New System.Drawing.Point(6, 22)
        Me.ProjectCode_Label.Name = "ProjectCode_Label"
        Me.ProjectCode_Label.Size = New System.Drawing.Size(93, 17)
        Me.ProjectCode_Label.TabIndex = 28
        Me.ProjectCode_Label.Text = "Project Code:"
        '
        'File_GroupBox
        '
        Me.File_GroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.File_GroupBox.Controls.Add(Me.SelectFolder_Button)
        Me.File_GroupBox.Controls.Add(Me.Directory_ListBox)
        Me.File_GroupBox.Location = New System.Drawing.Point(12, 199)
        Me.File_GroupBox.Name = "File_GroupBox"
        Me.File_GroupBox.Size = New System.Drawing.Size(516, 199)
        Me.File_GroupBox.TabIndex = 24
        Me.File_GroupBox.TabStop = False
        Me.File_GroupBox.Text = "Submission Directory"
        '
        'SelectFolder_Button
        '
        Me.SelectFolder_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.SelectFolder_Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SelectFolder_Button.Location = New System.Drawing.Point(278, 153)
        Me.SelectFolder_Button.Name = "SelectFolder_Button"
        Me.SelectFolder_Button.Size = New System.Drawing.Size(232, 35)
        Me.SelectFolder_Button.TabIndex = 5
        Me.SelectFolder_Button.Text = "Add Submission Directories..."
        Me.SelectFolder_Button.UseVisualStyleBackColor = True
        '
        'Directory_ListBox
        '
        Me.Directory_ListBox.AllowDrop = True
        Me.Directory_ListBox.FormattingEnabled = True
        Me.Directory_ListBox.HorizontalScrollbar = True
        Me.Directory_ListBox.Location = New System.Drawing.Point(6, 19)
        Me.Directory_ListBox.Name = "Directory_ListBox"
        Me.Directory_ListBox.Size = New System.Drawing.Size(504, 121)
        Me.Directory_ListBox.TabIndex = 4
        '
        'FolderBrowserDialog
        '
        Me.FolderBrowserDialog.ShowNewFolderButton = False
        '
        'BackgroundWorker
        '
        '
        'FormNew
        '
        Me.AcceptButton = Me.Finish_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.ClientSize = New System.Drawing.Size(540, 453)
        Me.Controls.Add(Me.File_GroupBox)
        Me.Controls.Add(Me.Project_GroupBox)
        Me.Controls.Add(Me.Finish_Button)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormNew"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Project"
        Me.Project_GroupBox.ResumeLayout(False)
        Me.Project_GroupBox.PerformLayout()
        Me.File_GroupBox.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Finish_Button As System.Windows.Forms.Button
    Friend WithEvents Project_GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents ProjectName_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents GameName_Label As System.Windows.Forms.Label
    Friend WithEvents ProjectCode_TextBox As System.Windows.Forms.TextBox
    Friend WithEvents ProjectCode_Label As System.Windows.Forms.Label
    Friend WithEvents File_GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents SelectFolder_Button As System.Windows.Forms.Button
    Friend WithEvents Directory_ListBox As System.Windows.Forms.ListBox
    Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Type_ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Type_Label As System.Windows.Forms.Label
    Friend WithEvents ARN_Label As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents BackgroundWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents ARN_TextBox As System.Windows.Forms.MaskedTextBox
End Class
