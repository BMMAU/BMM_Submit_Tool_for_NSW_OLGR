Imports Ionic.Zip

Public Class FormMain
    Private mDM As DataManager = DataManager.GetInstance

    Private Sub FormMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ' Initialize database
            If mDM.InitDataSource() Then
                ' Load all items into ListView
                Dim items = mDM.GetAllItems()
                For Each item As ProjectItem In items
                    Dim listViewItem As ListViewItem = New ListViewItem()
                    listViewItem.Text = item.ProjectCode
                    listViewItem.SubItems.Add(item.ProjectName)
                    listViewItem.SubItems.Add(item.ARN)
                    listViewItem.SubItems.Add(item.Type)
                    listViewItem.SubItems.Add(item.Username)
                    listViewItem.SubItems.Add(item.CreateDate)
                    ListView_Project.Items.Add(listViewItem)
                Next

                ' Set focus
                ListView_Project.Select()
                If Not ListView_Project.Items.Count.Equals(0) Then
                    ListView_Project.Items(ListView_Project.Items.Count - 1).Selected = True
                    ListView_Project.Items(ListView_Project.Items.Count - 1).EnsureVisible()
                End If
            Else
                MsgBox("Database is currently locked for editing by " + mDM.GetLocker + ".")
                Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Close()
        End Try
    End Sub

    Private Sub FormMain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        ' Release database
        mDM.ReleaseDataSource()
    End Sub

    Private Sub HelpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpToolStripMenuItem.Click
        ' Show help screen
        FormHelp.ShowDialog()
    End Sub

    Private Sub Button_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_Add.Click
        ' Show 'Add Project' screen
        FormNew.Show()
    End Sub

    Private Sub ListView_Project_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView_Project.MouseClick
        ' Show context menu strip
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ContextMenuStrip.Show(Me.ListView_Project, ListView_Project.PointToClient(Windows.Forms.Cursor.Position))
        End If
    End Sub

    Private Sub ToolStripMenuItemEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemEdit.Click
        Dim item As ProjectItem = mDM.GetItem(ListView_Project.SelectedIndices(0))

        FormEdit.requestEditItem(item)
        FormEdit.Show()
    End Sub

    Private Sub SendEmailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendEmailToolStripMenuItem.Click
        Dim item = mDM.GetItem(ListView_Project.SelectedIndices(0))

        If My.Computer.FileSystem.FileExists(item.ZipFileName) Then
            Try
                ' Send email
                Utils.SendEmail(item)
            Catch ex As Exception
                MsgBox("Cannot send email.")
            End Try
        Else
            MsgBox("Cannot find attachment.")
        End If
    End Sub

    Private Sub OpenZIPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenZIPToolStripMenuItem.Click
        Dim item As ProjectItem = mDM.GetItem(ListView_Project.SelectedIndices(0))

        If Not My.Computer.FileSystem.FileExists(item.ZipFileName) Then
            MsgBox("Cannot find submission ZIP file.")
        End If

        ' Open using explorer
        Process.Start("explorer.exe", Directory.GetParent(item.ZipFileName).ToString)
    End Sub

    Public Sub ItemEdited(ByRef item As ProjectItem)
        ' Update edited item 
        Dim listViewItem = ListView_Project.Items(mDM.IndexOf(item))

        listViewItem.Text = item.ProjectCode
        listViewItem.SubItems(1).Text = item.ProjectName
        listViewItem.SubItems(2).Text = item.ARN
        listViewItem.SubItems(3).Text = item.Type
        listViewItem.SubItems(4).Text = item.Username
        listViewItem.SubItems(5).Text = item.CreateDate
    End Sub

    Public Sub ItemAdded(ByRef item As ProjectItem)
        ' Add a new item into ListView
        Dim listViewItem As ListViewItem = New ListViewItem()

        listViewItem.Text = item.ProjectCode
        listViewItem.SubItems.Add(item.ProjectName)
        listViewItem.SubItems.Add(item.ARN)
        listViewItem.SubItems.Add(item.Type)
        listViewItem.SubItems.Add(item.Username)
        listViewItem.SubItems.Add(item.CreateDate)
        ListView_Project.Items.Add(listViewItem)

        ListView_Project.Items(ListView_Project.Items.Count - 1).Selected = True
        ListView_Project.Items(ListView_Project.Items.Count - 1).EnsureVisible()
    End Sub
End Class
