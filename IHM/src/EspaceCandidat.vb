Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class EspaceCandidat

    Public Function CheckPermission() As Boolean
        Dim success As Boolean = GetCandidat().success
        If success Then
            MsgBox("Bienvenue sur votre espace candidat, " & currentUser.candidat.prenom & "!", MsgBoxStyle.OkOnly & MsgBoxStyle.Information, "Connecté")
        End If
        Return success
    End Function

    Private Sub EspaceCandidat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Espace.Text = "Bienvenue, " & currentUser.candidat.nom.ToUpper() & " " & currentUser.candidat.prenom & Environment.NewLine & "Candidat N°" & currentUser.candidat.id

        ' Candidatures

        Dim commandeDB As OleDbCommand = connexionDB.CreateCommand()

        commandeDB.Parameters.Add(New OleDbParameter("@idCandidat", currentUser.candidat.id))
        commandeDB.CommandText = "SELECT c.ID_CANDIDATURE AS [N° Candidature], c.DATE_CANDIDATURE AS [Date], c.ETAT_CANDIDATURE AS [Etat], e.LIB_EMPLOI AS [Emploi] FROM ((CANDIDATURE AS c INNER JOIN PUBLICATION AS p ON c.ID_PUBLICATION = p.ID_PUBLICATION) INNER JOIN DEMANDE AS d ON d.ID_DEMANDE = p.ID_DEMANDE) INNER JOIN EMPLOI AS e ON e.ID_EMPLOI = d.ID_EMPLOI WHERE c.ID_CANDIDAT = @idCandidat;"

        Dim CommandRes = New OleDbDataAdapter(commandeDB)

        Dim DataTable As New DataTable("Table")
        CommandRes.Fill(DataTable)
        Me.Candidatures.Columns.Clear()
        Me.Candidatures.DataSource = DataTable

        Dim btn As DataGridViewButtonColumn = New DataGridViewButtonColumn()
        btn.Text = "Détails"
        btn.UseColumnTextForButtonValue = True
        btn.Name = "Détails"

        Me.Candidatures.Columns.Add(btn)

        ' Publications

        commandeDB = connexionDB.CreateCommand()

        commandeDB.Parameters.Add(New OleDbParameter("@idCandidat", currentUser.candidat.id))
        commandeDB.CommandText = "SELECT " &
            "p.ID_PUBLICATION AS [N° Publication], " &
            "e.LIB_EMPLOI AS [Libellé de l'emploi], " &
            "d.DATE_LIMITE_DEMANDE AS [Date limite de candidature], " &
            "d.SERVICE_DEMANDE AS [Service], " &
            "d.NATURE_DEMANDE AS [Nature de l'emploi] " &
            "FROM (PUBLICATION AS p INNER JOIN DEMANDE d ON d.ID_DEMANDE = p.ID_DEMANDE) INNER JOIN EMPLOI AS e ON d.ID_EMPLOI = e.ID_EMPLOI " &
            "WHERE d.VALIDATION_DEMANDE = True AND DATEDIFF('D', d.DATE_LIMITE_DEMANDE, NOW) < 0 AND DATEDIFF('D', p.DATE_FIN_PUBLICATION, NOW) < 0"

        CommandRes = New OleDbDataAdapter(commandeDB)

        DataTable = New DataTable("Table")
        CommandRes.Fill(DataTable)

        Me.Publications.Columns.Clear()
        Me.Publications.DataSource = DataTable

        btn = New DataGridViewButtonColumn()
        btn.Text = "Postuler"
        btn.UseColumnTextForButtonValue = True
        btn.Name = "Postuler"

        Me.Publications.Columns.Add(btn)

    End Sub

    Public Sub PosteClic(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Publications.CellClick

        If (e.RowIndex < 0) Then Return
        If (e.ColumnIndex <> 5) Then Return

        Dim dataTable As DataTable = TryCast(Me.Publications.DataSource, DataTable)

        Dim inputRes = InputBox("Vous vous apprêtez à postuler pour le poste '" & dataTable.Rows(e.RowIndex).Item(1) & "', veuillez saisir le lien de la lettre de motivation ci-dessous. Votre CV par défaut sera joint à la candidature.", "Postuler")

        If (inputRes.Length > 0) Then

            Dim selectDB = connexionDB.CreateCommand()
            selectDB.CommandText = "SELECT MAX(ID_CANDIDATURE) FROM CANDIDATURE;"

            Dim readSelect = selectDB.ExecuteReader()
            readSelect.Read()

            Dim commandeDB = connexionDB.CreateCommand()

            commandeDB.Parameters.Add(New OleDbParameter("@id", readSelect(0) + 1))
            readSelect.Close()
            commandeDB.Parameters.Add(New OleDbParameter("@lettre", inputRes))
            commandeDB.Parameters.Add(New OleDbParameter("@idp", dataTable.Rows(e.RowIndex).Item(0)))
            commandeDB.Parameters.Add(New OleDbParameter("@idc", currentUser.candidat.id))
            commandeDB.CommandText = "INSERT INTO CANDIDATURE (ID_CANDIDATURE, DATE_CANDIDATURE, LETTRE_MOTIVATION, ETAT_CANDIDATURE, ID_PUBLICATION, ID_CANDIDAT) VALUES (@id, NOW, @lettre, 'En attente', @idp, @idc)"

            If commandeDB.ExecuteNonQuery() = 1 Then
                SaveDatabase()

                MsgBox("Votre candidature a bien été soumise au service RH.", MsgBoxStyle.Information & MsgBoxStyle.OkOnly, "Succès")
                EspaceCandidat_Load(sender, e)
            End If

        End If

    End Sub

    Private Sub CandidatureClic(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Candidatures.CellClick

        If (e.RowIndex < 0) Then Return
        If (e.ColumnIndex <> 4) Then Return

        Dim dataTable As DataTable = TryCast(Me.Candidatures.DataSource, DataTable)

        Dim commandeDB As OleDbCommand = connexionDB.CreateCommand()
        commandeDB.Parameters.Add(New OleDbParameter("@idCandidature", dataTable.Rows(e.RowIndex).Item(0)))
        commandeDB.CommandText = "SELECT c.ID_CANDIDATURE, c.DATE_CANDIDATURE, c.ETAT_CANDIDATURE, e.LIB_EMPLOI, d.SERVICE_DEMANDE, d.NATURE_DEMANDE, d.VACANCE_DEMANDE, d.DATE_LIMITE_DEMANDE, r.PRENOM_AGENT & ' ' & r.NOM_AGENT AS NOMPRENOM_AGENT FROM (((CANDIDATURE AS c INNER JOIN PUBLICATION AS p ON c.ID_PUBLICATION = p.ID_PUBLICATION) INNER JOIN DEMANDE AS d ON d.ID_DEMANDE = p.ID_DEMANDE) INNER JOIN EMPLOI AS e ON e.ID_EMPLOI = d.ID_EMPLOI) INNER JOIN AGENT_RH AS r ON p.ID_AGENT = r.ID_AGENT WHERE c.ID_CANDIDATURE = @idCandidature;"

        Dim commandeRes = New OleDbDataAdapter(commandeDB)

        Dim newData As New DataTable("Table")
        commandeRes.Fill(newData)

        Dim dataRow As DataRow = newData.Rows(0)

        MsgBox("N° de la candidature: " & dataRow.Item(0) & vbCrLf &
               "Date de la candidature: " & dataRow.Item(1) & vbCrLf &
               "Etat de la candidature: " & dataRow.Item(2) & vbCrLf & vbCrLf &
               "Libellé du poste: " & dataRow.Item(3) & vbCrLf &
               "Service concerné: " & dataRow.Item(4) & vbCrLf &
               "Nature du poste: " & dataRow.Item(5) & vbCrLf & vbCrLf &
               "Vacance du poste: " & dataRow.Item(6) & vbCrLf &
               "Date limite de candidature: " & dataRow.Item(7) & vbCrLf & vbCrLf &
               "Agent RH en charge du recrutement: " & dataRow.Item(8), MsgBoxStyle.OkOnly & MsgBoxStyle.Information, "Affichage de la candidature")
    End Sub

    Private Sub Exit_Candidat() Handles Me.Closed
        Application.Exit()
    End Sub

End Class