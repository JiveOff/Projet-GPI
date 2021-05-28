<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EspaceCandidat
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Espace = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Candidatures = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Publications = New System.Windows.Forms.DataGridView()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Candidatures, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Publications, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Espace
        '
        Me.Espace.BackColor = System.Drawing.Color.White
        Me.Espace.Font = New System.Drawing.Font("Lato", 10.0!)
        Me.Espace.ForeColor = System.Drawing.Color.DimGray
        Me.Espace.Location = New System.Drawing.Point(275, 44)
        Me.Espace.Name = "Espace"
        Me.Espace.Size = New System.Drawing.Size(423, 47)
        Me.Espace.TabIndex = 11
        Me.Espace.Text = "Vous êtes connecté en tant que:"
        Me.Espace.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gray
        Me.Label1.Font = New System.Drawing.Font("Lato Black", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(29, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(240, 48)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Quick Recruit"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Gray
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(726, 38)
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'Candidatures
        '
        Me.Candidatures.AllowUserToAddRows = False
        Me.Candidatures.AllowUserToDeleteRows = False
        Me.Candidatures.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Candidatures.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.Candidatures.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.Candidatures.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Candidatures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Candidatures.Location = New System.Drawing.Point(29, 315)
        Me.Candidatures.Name = "Candidatures"
        Me.Candidatures.ReadOnly = True
        Me.Candidatures.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.Candidatures.Size = New System.Drawing.Size(669, 121)
        Me.Candidatures.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Lato", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(23, 272)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(239, 33)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Mes candidatures"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Lato", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(23, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(239, 33)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Postes à pourvoir"
        '
        'Publications
        '
        Me.Publications.AllowUserToAddRows = False
        Me.Publications.AllowUserToDeleteRows = False
        Me.Publications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Publications.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.Publications.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.Publications.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Publications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Publications.Location = New System.Drawing.Point(29, 128)
        Me.Publications.Name = "Publications"
        Me.Publications.ReadOnly = True
        Me.Publications.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.Publications.Size = New System.Drawing.Size(669, 127)
        Me.Publications.TabIndex = 14
        '
        'EspaceCandidat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(726, 460)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Publications)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Candidatures)
        Me.Controls.Add(Me.Espace)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EspaceCandidat"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Espace Candidat"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Candidatures, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Publications, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Espace As Windows.Forms.Label
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents Candidatures As Windows.Forms.DataGridView
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Publications As Windows.Forms.DataGridView
End Class
