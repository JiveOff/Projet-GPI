Imports System.Data.OleDb

Module BDModule

    Public Property connexionDB As New OleDbConnection

    Dim strConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" &
        Environment.CurrentDirectory & "\Resources\BD.accdb"

    Public Property currentUser As UserInfo

    Public Structure UserResult

        Public success As Boolean
        Public userObject As UserInfo

    End Structure

    Public Structure UserInfo

        Public id As Integer
        Public user As String
        Public password As String
        Public mail As String

        Public candidat As CandidatInfo
        Public agent As AgentInfo

    End Structure

    Public Structure CandidatInfo

        Public id As Integer
        Public nom As String
        Public prenom As String
        Public adresse As String
        Public cv As String
        Public naiss As Date

    End Structure

    Public Structure AgentInfo

        Public id As Integer
        Public nom As String
        Public prenom As String
        Public poste As String

    End Structure

    Public Sub LoadDatabase()
        connexionDB.ConnectionString = strConnectionString
        connexionDB.Open()
    End Sub

    Public Sub SaveDatabase()
        connexionDB.Close()
        connexionDB.ConnectionString = strConnectionString
        connexionDB.Open()
    End Sub

    Public Function GetUser(ByVal username As String, ByVal password As String) As UserResult

        Dim commandeDB As OleDbCommand = connexionDB.CreateCommand()

        commandeDB.Parameters.Add(New OleDbParameter("@username", username))
        commandeDB.Parameters.Add(New OleDbParameter("@password", password))
        commandeDB.CommandText = "SELECT * FROM UTILISATEUR WHERE NOM_UTILISATEUR = @username AND MDP_UTILISATEUR = @password;"

        Dim reader As OleDbDataReader = commandeDB.ExecuteReader()

        Dim resObj As New UserResult With {.success = False}

        If reader.Read = True Then
            resObj.success = True
            resObj.userObject = New UserInfo With {
                .id = Integer.Parse(reader.Item(0).ToString()),
                .user = reader.Item(1).ToString(),
                .password = reader.Item(2).ToString(),
                .mail = reader.Item(3).ToString()
            }
        End If

        reader.Close()
        Return resObj

    End Function

    Public Function GetCandidat() As UserResult

        Dim commandeDB As OleDbCommand = connexionDB.CreateCommand()

        commandeDB.Parameters.Add(New OleDbParameter("@userId", currentUser.id))
        commandeDB.CommandText = "SELECT * FROM CANDIDAT WHERE ID_UTILISATEUR = @userId;"

        Dim reader As OleDbDataReader = commandeDB.ExecuteReader()

        Dim resObj As New UserResult With {.success = False}

        If reader.Read = True Then
            resObj.success = True
            Dim usr As UserInfo = New UserInfo With {
                .id = currentUser.id,
                .user = currentUser.user,
                .password = currentUser.password,
                .mail = currentUser.mail,
                .candidat = New CandidatInfo With {
                    .id = Integer.Parse(reader.Item(0).ToString()),
                    .nom = reader.Item(1).ToString(),
                    .prenom = reader.Item(2).ToString(),
                    .adresse = reader.Item(3).ToString(),
                    .cv = reader.Item(4).ToString(),
                    .naiss = reader.Item(5).ToString()
                }
            }
            currentUser = usr
            resObj.userObject = currentUser
        End If

        reader.Close()
        Return resObj

    End Function

    Public Function GetAgentRH() As UserResult

        Dim commandeDB As OleDbCommand = connexionDB.CreateCommand()

        commandeDB.Parameters.Add(New OleDbParameter("@userId", currentUser.id))
        commandeDB.CommandText = "SELECT * FROM AGENT_RH WHERE ID_UTILISATEUR = @userId;"

        Dim reader As OleDbDataReader = commandeDB.ExecuteReader()

        Dim resObj As New UserResult With {.success = False}

        If reader.Read = True Then
            resObj.success = True
            Dim usr As UserInfo = New UserInfo With {
                .id = currentUser.id,
                .user = currentUser.user,
                .password = currentUser.password,
                .mail = currentUser.mail,
                .agent = New AgentInfo With {
                    .id = Integer.Parse(reader.Item(0).ToString()),
                    .nom = reader.Item(1).ToString(),
                    .prenom = reader.Item(2).ToString(),
                    .poste = reader.Item(3).ToString()
                }
            }
            currentUser = usr
            resObj.userObject = currentUser
        End If

        reader.Close()
        Return resObj

    End Function

End Module
