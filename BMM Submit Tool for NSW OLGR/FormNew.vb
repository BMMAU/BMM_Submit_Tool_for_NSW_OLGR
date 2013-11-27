Imports VBScript_RegExp_55

Public Class FormNew
    Private mItem As ProjectItem
    Private mType As String

    Private Sub FormNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set initial focus
        ProjectCode_TextBox.Select()
        Finish_Button.Enabled = False
        Type_ComboBox.Items.AddRange(ProjectItem.PROJECT_TYPES)
    End Sub

    Private Sub SelectFolder_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectFolder_Button.Click
        If FolderBrowserDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim folder = FolderBrowserDialog.SelectedPath
            ' Check whether the folder contains a forbidden file types
            If Utils.ContainNotAllowedFileTypes(folder) Then
                MsgBox("The folder contains blocked file types.")
            ElseIf Not isDuplicate(folder) Then
                ' Only one item in list box
                Directory_ListBox.Items.Add(folder)
            End If
        End If

        updateUI()
    End Sub

    Private Sub Finish_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Finish_Button.Click
        Dim reg As New RegExp
        reg.Pattern = "[0-9][0-9]-A[0-9][0-9][0-9][0-9]-S[0-9[0-9]"
        If reg.Test(ARN_TextBox.Text) Then
            ' Add new item in background
            BackgroundWorker.RunWorkerAsync()

            ' Show a waiting dialog
            Me.Enabled = False
            FormProgress.Show()
        Else
            MsgBox("ARN is not valid.")
        End If
        Return
    End Sub

    Private Sub ProjectCode_TextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjectCode_TextBox.TextChanged
        updateUI()
    End Sub

    Private Sub ProjectName_TextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjectName_TextBox.TextChanged
        updateUI()
    End Sub

    Private Sub ARN_TextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        updateUI()
    End Sub

    Private Sub Type_ComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Type_ComboBox.SelectedIndexChanged
        ' The Text of the ComboBox cannot be read from outside the thread, which creates this ComboBox
        mType = Type_ComboBox.Text
        updateUI()
    End Sub

    Private Sub updateUI()
        If String.IsNullOrEmpty(ProjectCode_TextBox.Text) Or _
            String.IsNullOrEmpty(ProjectName_TextBox.Text) Or _
            String.IsNullOrEmpty(ARN_TextBox.Text) Or _
            String.IsNullOrEmpty(Type_ComboBox.Text) Or _
            Directory_ListBox.Items.Count = 0 Then

            Finish_Button.Enabled = False
        Else
            Finish_Button.Enabled = True
        End If
    End Sub

    Private Sub BackgroundWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker.DoWork
        addItem()
    End Sub

    Private Sub BackgroundWorker_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker.RunWorkerCompleted
        FormProgress.Close()

        Close()

        ' FIX ME - NOT A GOOD DESIGN
        FormMain.ItemAdded(mItem)

        MsgBox("Project Added Successfully.")
    End Sub

    Private Sub Files_ListBox_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Directory_ListBox.KeyDown
        If e.KeyCode = Keys.Delete Then
            Directory_ListBox.Items.Remove(Directory_ListBox.SelectedItem)
            updateUI()
        End If
    End Sub

    Private Function isDuplicate(ByVal folder As String) As Boolean
        For Each item In Directory_ListBox.Items
            If item.Equals(folder) Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Sub addItem()
        ' Create a ProjectItem object and set its properties
        mItem = New ProjectItem
        mItem.ProjectCode = ProjectCode_TextBox.Text
        mItem.ProjectName = ProjectName_TextBox.Text
        mItem.ARN = ARN_TextBox.Text
        mItem.Type = mType
        Try
            mItem.Username = UserPrincipal.Current.DisplayName
        Catch ex As System.Exception
            mItem.Username = ""
        End Try
        mItem.CreateDate = Now()
        For Each folder As String In Directory_ListBox.Items()
            mItem.addFolderName(folder)
        Next
        mItem.ZipFileName = Directory.GetParent(Directory_ListBox.Items(0)).FullName + "\" + "ARN " + mItem.ARN + " - " + mItem.ProjectName + " - " + mItem.Type + ".zip"

        ' Make ZIP for this project
        Utils.ZipFolders(mItem.FolderNameList, mItem.ZipFileName)

        ' Add into database
        DataManager.GetInstance.AddItem(mItem)
    End Sub

    Private Sub Directory_ListBox_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Directory_ListBox.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim directoris() As String

            ' Assign the files and folders to an array.
            directoris = e.Data.GetData(DataFormats.FileDrop)
            ' Loop through the array and add directory to the list.
            For index = 0 To directoris.Length - 1
                If (Directory.Exists(directoris(index))) Then
                    Directory_ListBox.Items.Add(directoris(index))
                Else
                    If File.Exists(directoris(index)) Then
                        MsgBox("Cannot add a single file.")
                    End If
                End If
            Next
        End If

        updateUI()
    End Sub

    Private Sub Directory_ListBox_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Directory_ListBox.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub
End Class