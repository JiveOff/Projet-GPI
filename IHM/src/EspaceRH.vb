Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Forms

Public Class EspaceRH

    Public Function CheckPermission() As Boolean
        Dim success As Boolean = GetAgentRH().success
        If success Then
            MsgBox("Bienvenue sur votre espace RH, " & currentUser.agent.prenom & "!", MsgBoxStyle.OkOnly & MsgBoxStyle.Information, "Connecté")
        End If
        Return success
    End Function

    Private Sub EspaceRH_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Espace.Text = "Bienvenue, " & currentUser.agent.nom.ToUpper() & " " & currentUser.agent.prenom & Environment.NewLine & "Poste: " & currentUser.agent.poste

        ' Candidatures en attente

        Dim commandeDB As OleDbCommand = connexionDB.CreateCommand()

        commandeDB.Parameters.Add(New OleDbParameter("@idAgent", currentUser.agent.id))
        commandeDB.CommandText =
            "SELECT CANDIDATURE.ID_CANDIDATURE AS [N° Candidature], EMPLOI.LIB_EMPLOI AS [Libellé Emploi], CANDIDATURE.ETAT_CANDIDATURE AS [Etat Candidature], PUBLICATION.REF_PUBLICATION AS [Ref Publication], DEMANDE.SERVICE_DEMANDE AS [Service], DEMANDE.NATURE_DEMANDE AS [Nature], CANDIDATURE.DATE_CANDIDATURE AS [Date] " &
            "FROM CANDIDAT INNER JOIN ((EMPLOI INNER JOIN DEMANDE ON EMPLOI.ID_EMPLOI = DEMANDE.ID_EMPLOI) INNER JOIN (PUBLICATION INNER JOIN CANDIDATURE ON PUBLICATION.ID_PUBLICATION = CANDIDATURE.ID_PUBLICATION) ON DEMANDE.ID_DEMANDE = PUBLICATION.ID_DEMANDE) ON CANDIDAT.ID_CANDIDAT = CANDIDATURE.ID_CANDIDAT " &
            "WHERE (((PUBLICATION.ID_AGENT)=@idAgent)) AND CANDIDATURE.ETAT_CANDIDATURE = 'En attente' " &
            "ORDER BY CANDIDATURE.DATE_CANDIDATURE DESC;"

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

        ' Recherche Candidat

        Me.Recherche.Items.Clear()

        commandeDB = connexionDB.CreateCommand()

        commandeDB.Parameters.Add(New OleDbParameter("@idAgent", currentUser.agent.id))
        commandeDB.CommandText =
            "SELECT CANDIDATURE.ID_CANDIDATURE AS [N° Candidature], EMPLOI.LIB_EMPLOI AS [Libellé Emploi], CANDIDATURE.ETAT_CANDIDATURE AS [Etat Candidature], DEMANDE.SERVICE_DEMANDE AS [Service], DEMANDE.NATURE_DEMANDE AS [Nature], CANDIDATURE.DATE_CANDIDATURE AS [Date], CANDIDAT.PRENOM_CANDIDAT & ' ' & CANDIDAT.NOM_CANDIDAT " &
            "FROM CANDIDAT INNER JOIN ((EMPLOI INNER JOIN DEMANDE ON EMPLOI.ID_EMPLOI = DEMANDE.ID_EMPLOI) INNER JOIN (PUBLICATION INNER JOIN CANDIDATURE ON PUBLICATION.ID_PUBLICATION = CANDIDATURE.ID_PUBLICATION) ON DEMANDE.ID_DEMANDE = PUBLICATION.ID_DEMANDE) ON CANDIDAT.ID_CANDIDAT = CANDIDATURE.ID_CANDIDAT " &
            "WHERE (((PUBLICATION.ID_AGENT)=@idAgent)) " &
            "ORDER BY CANDIDATURE.DATE_CANDIDATURE DESC;"

        Dim SelectReader = commandeDB.ExecuteReader()

        While SelectReader.Read()
            Me.Recherche.Items.Add(SelectReader(0) & " (le " & SelectReader(5) & " par " & SelectReader(6) & ") " & " - " & SelectReader(1) & " (" & SelectReader(3) & ", " & SelectReader(4) & ") " & " - " & SelectReader(2))
        End While

        ' Rendez-vous

        commandeDB = connexionDB.CreateCommand()

        commandeDB.Parameters.Add(New OleDbParameter("@idAgent", currentUser.agent.id))
        commandeDB.CommandText = "SELECT r.ID_RENDEZ_VOUS AS [N° RDV], r.DATE_RENDEZ_VOUS AS [Date], e.LIB_EMPLOI AS [Emploi] " &
            "FROM (((RENDEZ_VOUS AS r INNER JOIN CANDIDATURE c ON c.ID_CANDIDATURE = r.ID_CANDIDATURE) INNER JOIN PUBLICATION p ON p.ID_PUBLICATION = c.ID_PUBLICATION) INNER JOIN DEMANDE d ON d.ID_DEMANDE = p.ID_DEMANDE) INNER JOIN EMPLOI e ON d.ID_EMPLOI = e.ID_EMPLOI " &
            "WHERE r.ID_AGENT = @idAgent AND DATEDIFF('D', r.DATE_RENDEZ_VOUS, NOW) < 7;"

        CommandRes = New OleDbDataAdapter(commandeDB)
        DataTable = New DataTable("Table")
        CommandRes.Fill(DataTable)

        Me.RDV.Columns.Clear()
        Me.RDV.DataSource = DataTable

        btn = New DataGridViewButtonColumn()
        btn.Text = "Voir"
        btn.UseColumnTextForButtonValue = True
        btn.Name = "Candidature"

        Me.RDV.Columns.Add(btn)

        btn = New DataGridViewButtonColumn()
        btn.Text = "Saisir"
        btn.UseColumnTextForButtonValue = True
        btn.Name = "Compte-rendu"

        Me.RDV.Columns.Add(btn)

        btn = New DataGridViewButtonColumn()
        btn.Text = "Voir"
        btn.UseColumnTextForButtonValue = True
        btn.Name = "Compte-rendu"

        Me.RDV.Columns.Add(btn)

    End Sub

    Public Sub CandidatureShow(IdCandidature As Integer)

        Dim commandeDB As OleDbCommand = connexionDB.CreateCommand()
        commandeDB.Parameters.Add(New OleDbParameter("@idCandidature", IdCandidature))
        commandeDB.CommandText = "SELECT c.ID_CANDIDATURE, c.DATE_CANDIDATURE, c.ETAT_CANDIDATURE, e.LIB_EMPLOI, d.SERVICE_DEMANDE, d.NATURE_DEMANDE, d.VACANCE_DEMANDE, d.DATE_LIMITE_DEMANDE, r.PRENOM_AGENT & ' ' & r.NOM_AGENT AS NOMPRENOM_AGENT, ca.PRENOM_CANDIDAT & ' ' & ca.NOM_CANDIDAT, ca.DATENAISS_CANDIDAT, ca.ADRESSE_CANDIDAT FROM ((((CANDIDATURE AS c INNER JOIN PUBLICATION AS p ON c.ID_PUBLICATION = p.ID_PUBLICATION) INNER JOIN DEMANDE AS d ON d.ID_DEMANDE = p.ID_DEMANDE) INNER JOIN EMPLOI AS e ON e.ID_EMPLOI = d.ID_EMPLOI) INNER JOIN AGENT_RH AS r ON p.ID_AGENT = r.ID_AGENT) INNER JOIN CANDIDAT AS ca ON c.ID_CANDIDAT = ca.ID_CANDIDAT WHERE c.ID_CANDIDATURE = @idCandidature;"

        Dim commandeRes = New OleDbDataAdapter(commandeDB)

        Dim newData As New DataTable("Table")
        commandeRes.Fill(newData)

        Dim dataRow As DataRow = newData.Rows(0)

        MsgBox("N° de la candidature: " & dataRow.Item(0) & vbCrLf &
               "Date de la candidature: " & dataRow.Item(1) & vbCrLf &
               "Etat de la candidature: " & dataRow.Item(2) & vbCrLf & vbCrLf &
               "Nom & prénom du candidat: " & dataRow.Item(9) & vbCrLf &
               "Date de naissance du candidat: " & dataRow.Item(10) & vbCrLf &
               "Adresse du candidat: " & dataRow.Item(11) & vbCrLf & vbCrLf &
               "Libellé du poste: " & dataRow.Item(3) & vbCrLf &
               "Service concerné: " & dataRow.Item(4) & vbCrLf &
               "Nature du poste: " & dataRow.Item(5) & vbCrLf & vbCrLf &
               "Vacance du poste: " & dataRow.Item(6) & vbCrLf &
               "Date limite de candidature: " & dataRow.Item(7) & vbCrLf & vbCrLf &
               "Agent RH en charge du recrutement: " & dataRow.Item(8), MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Affichage de la candidature")

    End Sub

    Public Sub CandidatureClic(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles Candidatures.CellClick

        If (e.RowIndex < 0) Then Return
        If (e.ColumnIndex <> 7) Then Return

        Dim dataTable As DataTable = TryCast(Me.Candidatures.DataSource, DataTable)

        CandidatureShow(dataTable.Rows(e.RowIndex).Item(0))

    End Sub

    Public Sub RDVClic(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles RDV.CellClick

        If (e.RowIndex < 0) Then Return
        If (e.ColumnIndex <> 3) Then Return

        Dim dataTable As DataTable = TryCast(Me.RDV.DataSource, DataTable)

        Dim selectDB = connexionDB.CreateCommand()
        selectDB.Parameters.Add(New OleDbParameter("@idRDV", dataTable.Rows(e.RowIndex).Item(0)))
        selectDB.CommandText = "SELECT ID_CANDIDATURE FROM RENDEZ_VOUS WHERE ID_RENDEZ_VOUS = @idRDV;"

        Dim readSelect = selectDB.ExecuteReader()
        readSelect.Read()

        CandidatureShow(readSelect(0))

    End Sub

    Public Sub CompteRenduClic(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles RDV.CellClick

        If (e.RowIndex < 0) Then Return
        If (e.ColumnIndex <> 4) Then Return

        Dim dataTable As DataTable = TryCast(Me.RDV.DataSource, DataTable)
        Dim compteRendu As String = InputBox("Saisissez le compte rendu pour ce rendez-vous (N°" & dataTable.Rows(e.RowIndex).Item(0) & " le " & dataTable.Rows(e.RowIndex).Item(1) & ") ci-dessous.")

        If (compteRendu.Length > 0) Then

            Dim updateDB = connexionDB.CreateCommand()
            updateDB.Parameters.Add(New OleDbParameter("@compteRendu", compteRendu))
            updateDB.Parameters.Add(New OleDbParameter("@idRDV", dataTable.Rows(e.RowIndex).Item(0)))
            updateDB.CommandText = "UPDATE RENDEZ_VOUS SET CONTENU_COMPTE_RENDU = @compteRendu WHERE ID_RENDEZ_VOUS = @idRDV;"

            'Console.WriteLine(dataTable.Rows(e.RowIndex).Item(0) & " " & compteRendu)
            'Console.WriteLine(updateDB.ExecuteNonQuery())

            If (updateDB.ExecuteNonQuery() > 0) Then

                MsgBox("Compte-rendu saisi avec succès.", MsgBoxStyle.OkOnly & MsgBoxStyle.Information)

            Else

                MsgBox("Erreur de saisie du compte rendu.", MsgBoxStyle.OkOnly & MsgBoxStyle.Information)

            End If

        End If

    End Sub

    Public Sub CompteRenduVoirClic(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles RDV.CellClick

        If (e.RowIndex < 0) Then Return
        If (e.ColumnIndex <> 5) Then Return

        Dim dataTable As DataTable = TryCast(Me.RDV.DataSource, DataTable)

        Dim selectDB = connexionDB.CreateCommand()
        selectDB.Parameters.Add(New OleDbParameter("@idRDV", dataTable.Rows(e.RowIndex).Item(0)))
        selectDB.CommandText = "SELECT CONTENU_COMPTE_RENDU FROM RENDEZ_VOUS WHERE ID_RENDEZ_VOUS = @idRDV;"

        Dim readSelect As OleDbDataReader

        Try
            readSelect = selectDB.ExecuteReader()
            readSelect.Read()

            'MsgBox(readSelect.GetString(0))

            If readSelect.GetString(0).Length > 0 Then
                MsgBox("Compte rendu saisi: " & vbCrLf & vbCrLf & readSelect.GetString(0), MsgBoxStyle.OkOnly & MsgBoxStyle.Information, "Compte rendu")
            Else
                MsgBox("Aucun compte rendu n'a été saisi pour cette candidature.", MsgBoxStyle.OkOnly & MsgBoxStyle.Exclamation, "Compte rendu")
            End If
        Catch
            MsgBox("Aucun compte rendu n'a été saisi pour cette candidature.", MsgBoxStyle.OkOnly & MsgBoxStyle.Exclamation, "Compte rendu")
        End Try

    End Sub

    Private Sub Exit_Candidat() Handles Me.Closed
        Application.Exit()
    End Sub

    Private Sub Recherche_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Recherche.SelectedIndexChanged

        CandidatureShow(Recherche.SelectedItem.ToString().Split(" ")(0))

    End Sub
End Class