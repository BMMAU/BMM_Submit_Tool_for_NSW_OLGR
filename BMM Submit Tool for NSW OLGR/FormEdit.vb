Imports VBScript_RegExp_55

Public Class FormEdit
    Private mItem As ProjectItem

    Public Sub requestEditItem(ByRef item As ProjectItem)
        mItem = item
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim reg As New RegExp
        reg.Pattern = "[0-9][0-9]-A[0-9][0-9][0-9][0-9]-S[0-9[0-9]"
        If reg.Test(ARN_TextBox.Text) Then
            ' Set new properties
            ' DO NOT UPDATE Username & CreateDate
            mItem.ProjectCode = ProjectCode_TextBox.Text
            mItem.ProjectName = ProjectName_TextBox.Text
            mItem.ARN = ARN_TextBox.Text
            mItem.Type = Type_ComboBox.Text
            mItem.ZipFileName = ZipFileLabel.Text

            ' Update item in database
            DataManager.GetInstance.UpdateItem(mItem)

            ' Close me
            Close()

            ' FIX ME - NOT A GOOD DESIGN
            FormMain.ItemEdited(mItem)

            MsgBox("Project Saved Successfully.")
        Else
            MsgBox("ARN is not valid.")
        End If


    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Close()
    End Sub

    Private Sub FormEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ProjectCode_TextBox.Select()
        Type_ComboBox.Items.AddRange(ProjectItem.PROJECT_TYPES)

        ' Set initial project information
        If Not IsNothing(mItem) Then
            ProjectCode_TextBox.Text = mItem.ProjectCode
            ProjectName_TextBox.Text = mItem.ProjectName
            ARN_TextBox.Text = mItem.ARN

            For Each item In Type_ComboBox.Items
                If item.Equals(mItem.Type) Then
                    Type_ComboBox.SelectedItem = item
                    Exit For
                End If
            Next
            ZipFileLabel.Text = mItem.ZipFileName

            ' Set initial directory
            OpenFileDialog.InitialDirectory = Directory.GetParent(mItem.ZipFileName).ToString
        End If
    End Sub

    Private Sub SelectFolder_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectFolder_Button.Click
        If OpenFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ZipFileLabel.Text = OpenFileDialog.FileName
        End If
    End Sub

    Private Sub updateUI()
        If String.IsNullOrEmpty(ProjectCode_TextBox.Text) Or _
            String.IsNullOrEmpty(ProjectName_TextBox.Text) Or _
            String.IsNullOrEmpty(ARN_TextBox.Text) Or _
            String.IsNullOrEmpty(Type_ComboBox.Text) Then

            OK_Button.Enabled = False
        Else
            OK_Button.Enabled = True
        End If
    End Sub

    Private Sub ProjectCode_TextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjectCode_TextBox.TextChanged
        updateUI()
    End Sub

    Private Sub ProjectName_TextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjectName_TextBox.TextChanged
        updateUI()
    End Sub

    Private Sub Type_ComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Type_ComboBox.SelectedIndexChanged
        updateUI()
    End Sub
End Class