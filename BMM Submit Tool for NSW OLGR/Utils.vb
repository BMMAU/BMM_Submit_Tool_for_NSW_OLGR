Imports Ionic.Zip
Imports System.IO

Public Class Utils
    Private Const DEFAULT_PASSWORD = "3FE72B42.579E9471*;~;#&#7n6H156J_Q_K%35CE85D1!!112B70D6..3EDD1B4L5"
    Private Const NOT_ALLOWED_FILE_TYPES = ".ade, .adp, .bat, .chm, .cmd, .com, .cpl, .exe, .hta, .ins, .isp, .jse, .lib, .mde, .msc, .msp, .mst, .pif, .scr, .sct, .shb, .sys, .vb, .vbe, .vbs, .vxd, .wsc, .wsf, .wsh, .zip, .tar, .tgz, .taz, .z, .gz, .rar, .7z"

    ' Zip folders into a zip file
    Public Shared Function ZipFolders(ByRef folderList As ArrayList, ByRef zipFileName As String) As Boolean
        Dim zipFile As New ZipFile
        Try
            ' Set zip file properties
            zipFile.Password = DEFAULT_PASSWORD
            zipFile.Encryption = EncryptionAlgorithm.WinZipAes256

            ' Add all the folders into zip file
            For Each folder In folderList
                zipFile.AddDirectory(folder, folder.ToString.Substring(folder.ToString.LastIndexOf("\")))
            Next

            ' Save zip file as specified file name
            zipFile.Save(zipFileName)

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ' Check whether folder has forbidden file types
    Public Shared Function ContainNotAllowedFileTypes(ByRef folderName As String) As Boolean
        Dim types = Split(NOT_ALLOWED_FILE_TYPES, ", ")

        For Each type In types
            If fileExists(folderName, "*" + type) Then
                Return True
            End If
        Next

        Return False
    End Function

    Public Shared Function SendEmail(ByRef item As ProjectItem) As Boolean
        Try
            Dim application As Outlook.Application
            application = CreateObject("Outlook.Application")

            Dim ns As Outlook.NameSpace
            ns = application.GetNamespace("MAPI")
            ns.Logon()

            Dim emailItem As Outlook.MailItem
            emailItem = application.CreateItem(Outlook.OlItemType.olMailItem)

            Dim body As String = New String("")
            body = "Hi Cherrie/Cathy," + vbCrLf + vbCrLf
            body = body + "The following submission is ready for transfer; please send the conformation email to NSW once the transfer is completed. Thank you." + vbCrLf + vbCrLf
            body = body + "______________________________________________________" + vbCrLf + vbCrLf
            body = body + "Project Code: " + item.ProjectCode + vbCrLf + vbCrLf
            body = body + "Project Name: " + item.ProjectName + vbCrLf + vbCrLf
            body = body + "ARN: " + item.ARN + vbCrLf + vbCrLf
            body = body + "Type: " + item.Type + vbCrLf + vbCrLf
            body = body + "User Name: " + item.Username + vbCrLf + vbCrLf
            body = body + "Date: " + item.CreateDate + vbCrLf + vbCrLf
            body = body + "______________________________________________________" + vbCrLf + vbCrLf + vbCrLf + vbCrLf
            body = body + "Regards," + vbCrLf + vbCrLf
            body = body + ns.CurrentUser.Name
            With emailItem
                .Subject = "ARN " + item.ARN + " - " + item.ProjectName + " - " + item.Type
                .To = "ProjectAdmin@bmm.com"
                .CC = "tnadesapillai@bmm.com"
                .BodyFormat = Outlook.OlBodyFormat.olFormatHTML
                .Body = body
                .Attachments.Add(item.ZipFileName)
                .Display()
            End With

            ns.Logoff()
            ns = Nothing
            emailItem = Nothing
            application = Nothing

            Return True
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ' Make Utils as a static class
    Private Sub New()
    End Sub

    ' Check whether specified file type exists
    Private Shared Function fileExists(ByRef folderName As String, ByRef type As String) As Boolean
        Dim file As String

        ' Check files first
        For Each file In Directory.GetFiles(folderName, type)
            ' Find a matching file, then return with True
            Return True
        Next

        ' Check sub-folders recursively
        For Each d In Directory.GetDirectories(folderName)
            ' Find a matching file in sub-folders, then return with True
            If fileExists(d, type) Then
                Return True
            End If
        Next

        ' Not found, return with False
        Return False
    End Function

End Class
