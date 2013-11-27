Imports System.Data.OleDb

Public Class DataManager
    Private Const DB_PROVIDER As String = "Provider=Microsoft.ACE.OLEDB.12.0;"
#If DEBUG Then
    Private Const DB_FILE As String = "\\meldc2\X-Drive\Luxi\NSW_OLGR.accdb"
#Else
    Private Const DB_FILE As String = "\\meldc2\Teams\IGT\TOOLS\BMM Submit Tool for NSW OLGR\NSW_OLGR.accdb"
#End If

    Private Const DB_LOCK_FILE As String = DB_FILE + ".lock"
    Private Const DB_SOURCE As String = "Data Source=" + DB_FILE + ";"
    Private Const DB_MODE As String = "Mode=Share Exclusive;"
    Private Const DB_CONNECTION_STRING As String = DB_PROVIDER + DB_SOURCE + DB_MODE + "Jet OLEDB:Database Password=pontiff"
    Private Const DB_TABLE As String = "PROJECTS"
    Private Const DB_FIELD_ID As String = "ID"
    Private Const DB_FIELD_PROJECT_CODE As String = "PROJECT_CODE"
    Private Const DB_FIELD_PROJECT_NAME As String = "PROJECT_NAME"
    Private Const DB_FIELD_ARN As String = "ARN"
    Private Const DB_FIELD_TYPE As String = "TYPE"
    Private Const DB_FIELD_USERNAME As String = "USERNAME"
    Private Const DB_FIELD_CREATE_DATE As String = "CREATE_DATE"
    Private Const DB_FIELD_FILE As String = "FILE"
    Private mConnection As OleDbConnection = Nothing
    Private mLockFlag As Boolean = False

    Public Shared ReadOnly Property GetInstance() As DataManager
        Get
            Static instance As DataManager = New DataManager
            Return instance
        End Get
    End Property

    ' Initialise data source
    Public Function InitDataSource() As Boolean
        Try
            If openDB() Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' Release data source
    Public Sub ReleaseDataSource()
        Try
            closeDB()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetAllItems() As ArrayList
        Dim itemList As ArrayList = New ArrayList
        Dim command As OleDbCommand
        Dim reader As OleDbDataReader

        Try
            ' SELECT SQL command
            command = mConnection.CreateCommand
            command.CommandText = "SELECT " + _
                DB_FIELD_ID + ", " + _
                DB_FIELD_PROJECT_CODE + ", " + _
                DB_FIELD_PROJECT_NAME + ", " + _
                DB_FIELD_ARN + ", " + _
                DB_FIELD_TYPE + ", " + _
                DB_FIELD_USERNAME + ", " + _
                DB_FIELD_CREATE_DATE + ", " + _
                DB_FIELD_FILE + _
                " FROM " + DB_TABLE
            reader = command.ExecuteReader

            ' Add item into itemList
            While reader.Read()
                Dim pi As ProjectItem = New ProjectItem
                pi.Id = reader.Item(DB_FIELD_ID)
                pi.ProjectCode = reader.Item(DB_FIELD_PROJECT_CODE)
                pi.ProjectName = reader.Item(DB_FIELD_PROJECT_NAME)
                pi.ARN = reader.Item(DB_FIELD_ARN)
                pi.Type = reader.Item(DB_FIELD_TYPE)
                pi.Username = reader.Item(DB_FIELD_USERNAME)
                pi.CreateDate = reader.Item(DB_FIELD_CREATE_DATE)
                pi.ZipFileName = reader.Item(DB_FIELD_FILE)

                itemList.Add(pi)
            End While
        Catch ex As Exception
            Throw ex
        End Try

        Return itemList
    End Function

    Public Function GetItem(ByVal index As Integer) As ProjectItem
        Return GetAllItems()(index)
    End Function

    Public Function AddItem(ByVal item As ProjectItem) As Boolean
        Dim command As OleDbCommand

        Try
            ' INSERT SQL command to update an item
            command = mConnection.CreateCommand
            command.CommandText = "INSERT INTO " + _
                DB_TABLE + " (" + _
                DB_FIELD_PROJECT_CODE + ", " + _
                DB_FIELD_PROJECT_NAME + ", " + _
                DB_FIELD_ARN + ", " + _
                DB_FIELD_TYPE + ", " + _
                DB_FIELD_USERNAME + ", " + _
                DB_FIELD_CREATE_DATE + ", " + _
                DB_FIELD_FILE + ") " + _
                "VALUES (" + _
                """" + item.ProjectCode + """" + ", " + _
                """" + item.ProjectName + """" + ", " + _
                """" + item.ARN + """" + ", " + _
                """" + item.Type + """" + ", " + _
                """" + item.Username + """" + ", " + _
                """" + item.CreateDate + """" + ", " + _
                """" + item.ZipFileName + """" + ")"

            command.ExecuteNonQuery()

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function UpdateItem(ByVal item As ProjectItem) As Boolean
        Dim command As OleDbCommand

        Try
            ' UPDATE SQL command to update an item
            command = mConnection.CreateCommand
            command.CommandText = "UPDATE " + _
                DB_TABLE + " SET " + _
                DB_FIELD_PROJECT_CODE + "=" + """" + item.ProjectCode + """, " + _
                DB_FIELD_PROJECT_NAME + "=" + """" + item.ProjectName + """, " + _
                DB_FIELD_ARN + "=" + """" + item.ARN + """, " + _
                DB_FIELD_TYPE + "=" + """" + item.Type + """, " + _
                DB_FIELD_USERNAME + "=" + """" + item.Username + """, " + _
                DB_FIELD_CREATE_DATE + "=" + """" + item.CreateDate + """, " + _
                DB_FIELD_FILE + "=" + """" + item.ZipFileName + """" + " WHERE " + _
                DB_FIELD_ID + "=" + item.Id.ToString
            command.ExecuteNonQuery()

            Return True
        Catch ex As Exception
            Throw ex
        End Try
       
    End Function

    Public Function IndexOf(ByRef item As ProjectItem) As Integer
        Dim items As ArrayList = GetAllItems()

        For index As Integer = 0 To items.Count - 1
            If items(index).Id = item.Id Then
                Return index
            End If
        Next

        Return -1
    End Function

    Public Function GetLocker() As String
        Dim locker As String = Nothing
        Dim fileStream As FileStream
        Dim streamReader As StreamReader

        Try
            fileStream = New FileStream(DB_LOCK_FILE, FileMode.Open, FileAccess.Read, FileShare.Read)
            streamReader = New StreamReader(fileStream)
            streamReader.BaseStream.Seek(0, SeekOrigin.Begin)
            locker = streamReader.ReadLine()

            ' Get the locker
            Return locker
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ' Make DataManage as singleton
    Private Sub New()
    End Sub

    ' Open DB
    Private Function openDB() As Boolean
        If My.Computer.FileSystem.FileExists(DB_FILE) Then
            Try
                If lockDB() Then
                    ' Lock succeed, ready to open

                    mConnection = New OleDbConnection
                    mConnection.ConnectionString = DB_CONNECTION_STRING

                    mConnection.Open()

                    ' Open succeed
                    Return True
                Else
                    ' Cannot lock database, open fail
                    Return False
                End If
            Catch ex As Exception
                Throw ex
            End Try
        Else
            ' Database not exist
            Return False
        End If

    End Function

    ' Close DB
    Private Sub closeDB()
        Try
            If mConnection IsNot Nothing Then
                ' Close connection opened previously
                mConnection.Close()
            End If

            ' Unlock database file
            unLockDB()
        Catch ex As Exception
            ' Exception occurs
            Throw ex
        End Try
    End Sub

    Private Function lockDB() As Boolean
        If Not My.Computer.FileSystem.FileExists(DB_LOCK_FILE) Then
            Try
                Dim fileStream As System.IO.FileStream
                Dim streamWriter As System.IO.StreamWriter
                fileStream = System.IO.File.Create(DB_FILE + ".lock")
                File.SetAttributes(DB_FILE + ".lock", File.GetAttributes(DB_FILE + ".lock") Or FileAttributes.Hidden)

                fileStream.SetLength(0)

                streamWriter = New StreamWriter(fileStream)
                streamWriter.BaseStream.Seek(0, SeekOrigin.End)
                streamWriter.WriteLine(UserPrincipal.Current.DisplayName)
                streamWriter.Flush()
                streamWriter.Close()

                fileStream.Close()

                ' Lock succeed
                mLockFlag = True
                Return True
            Catch ex As Exception
                ' Exception occurs
                Throw ex
            End Try
        Else
            ' Lock file already exists, lock fail
            Return False
        End If
    End Function

    Private Sub unLockDB()
        If mLockFlag Then
            ' Lock file is locked by me, which I could unlock
            Try
                System.IO.File.Delete(DB_LOCK_FILE)
            Catch ex As Exception
                ' Exception occurs
                Throw ex
            End Try
        End If
    End Sub
End Class
