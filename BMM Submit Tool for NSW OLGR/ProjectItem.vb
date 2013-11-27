Public Class ProjectItem
    Private mId As Integer
    Private mProjectCode As String
    Private mProjectName As String
    Private mARN As String
    Private mType As String
    Private mUsername As String
    Private mDate As Date
    Private mFolderNameList As ArrayList = New ArrayList
    Private mZipFileName As String

    Public Shared ReadOnly PROJECT_TYPES() As Object = New Object() {"NEW GAME", "GAME UPDATE", "HARDWARE", "HARDWARE UPDATE"}

    Property Id() As Integer
        Get
            Return mId
        End Get
        Set(ByVal id As Integer)
            mId = id
        End Set
    End Property

    Property ProjectCode() As String
        Get
            Return mProjectCode
        End Get
        Set(ByVal projectCode As String)
            mProjectCode = projectCode
        End Set
    End Property

    Property ProjectName() As String
        Get
            Return mProjectName
        End Get
        Set(ByVal projectName As String)
            mProjectName = projectName
        End Set
    End Property

    Property ARN() As String
        Get
            Return mARN
        End Get
        Set(ByVal arn As String)
            mARN = arn
        End Set
    End Property

    Property Type() As String
        Get
            Return mType
        End Get
        Set(ByVal type As String)
            mType = type
        End Set
    End Property

    Property Username() As String
        Get
            Return mUsername
        End Get
        Set(ByVal username As String)
            mUsername = username
        End Set
    End Property

    Property CreateDate() As Date
        Get
            Return mDate
        End Get
        Set(ByVal createDate As Date)
            mDate = createDate
        End Set
    End Property

    Public Sub addFolderName(ByVal folder As String)
        mFolderNameList.Add(folder)
    End Sub

    ReadOnly Property FolderNameList()
        Get
            Return mFolderNameList
        End Get
    End Property

    Property ZipFileName() As String
        Get
            Return mZipFileName
        End Get
        Set(ByVal zipFileName As String)
            mZipFileName = zipFileName
        End Set
    End Property

End Class
