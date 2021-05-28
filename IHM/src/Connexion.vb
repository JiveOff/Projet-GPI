Public Class Connexion

    Dim formToOpen As Windows.Forms.Form
    Dim homepage As Windows.Forms.Form

    Public Sub New(ByVal espace As String, ByVal rt As Windows.Forms.Form, ByVal frm As Windows.Forms.Form)
        InitializeComponent()
        Me.Espace.Text = "Connexion à: " & espace
        formToOpen = frm
        homepage = rt
    End Sub

    Private Sub Login(sender As Object, e As EventArgs) Handles Button1.Click
        Dim LoginRes As UserResult = GetUser(Me.User.Text, Me.Password.Text)
        If LoginRes.success = True Then
            currentUser = LoginRes.userObject
            Dim hasPerm As Boolean = False
            If formToOpen.Name = "EspaceCandidat" Then
                hasPerm = CType(formToOpen, EspaceCandidat).CheckPermission()
            ElseIf formToOpen.Name = "EspaceRH" Then
                hasPerm = CType(formToOpen, EspaceRH).CheckPermission()
            End If
            If Not hasPerm Then
                MsgBox("Vous n'avez pas la permission d'accéder à cette section.", MsgBoxStyle.OkOnly & MsgBoxStyle.Critical, "Erreur")
                Return
            End If
            Me.Hide()
            formToOpen.Show()
        Else
            MsgBox("Identifiants incorrects.", MsgBoxStyle.OkOnly & MsgBoxStyle.Critical, "Erreur")
        End If
    End Sub

    Private Sub CloseEvent(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Hide()
        homepage.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class