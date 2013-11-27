Public NotInheritable Class FormHelp

    Private Sub FormHelp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim text As String = New String("")

        text = "1. Select ""Add Project..."" " + vbCrLf + vbCrLf
        text += "2. Input project information, and select submission folder." + vbCrLf + vbCrLf
        text += "3. Click ""Add"" to add project." + vbCrLf + vbCrLf

        TextBox1.Text = text
    End Sub
   
    Private Sub OKButton_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Close()
    End Sub
End Class
