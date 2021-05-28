Public Class Home
    Private Sub Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BDModule.LoadDatabase()
    End Sub

    Private Sub AfficherConnexion(ByVal espace As String, form As Windows.Forms.Form)
        Me.Hide()
        Dim Connexion = New Connexion(espace, Me, form)
        Connexion.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AfficherConnexion("Espace Candidat", New EspaceCandidat)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AfficherConnexion("Espace RH", New EspaceRH)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class