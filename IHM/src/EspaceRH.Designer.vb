<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EspaceRH
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Espace = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Candidatures = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RDV = New System.Windows.Forms.DataGridView()
        Me.Recherche = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Candidatures, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RDV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Gray
        Me.Label1.Font = New System.Drawing.Font("Lato Black", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(29, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(240, 48)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Quick Recruit"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Gray
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1245, 38)
        Me.PictureBox1.TabIndex = 12
        Me.PictureBox1.TabStop = False
        '
        'Espace
        '
        Me.Espace.BackColor = System.Drawing.Color.White
        Me.Espace.Font = New System.Drawing.Font("Lato", 10.0!)
        Me.Espace.ForeColor = System.Drawing.Color.DimGray
        Me.Espace.Location = New System.Drawing.Point(748, 43)
        Me.Espace.Name = "Espace"
        Me.Espace.Size = New System.Drawing.Size(466, 47)
        Me.Espace.TabIndex = 14
        Me.Espace.Text = "Vous êtes connecté en tant que:"
        Me.Espace.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Lato", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(22, 159)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(456, 33)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Candidatures en attente pour vous"
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
        Me.Candidatures.Location = New System.Drawing.Point(28, 205)
        Me.Candidatures.Name = "Candidatures"
        Me.Candidatures.ReadOnly = True
        Me.Candidatures.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.Candidatures.Size = New System.Drawing.Size(735, 272)
        Me.Candidatures.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Lato", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(784, 163)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(231, 33)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Mes rendez-vous"
        '
        'RDV
        '
        Me.RDV.AllowUserToAddRows = False
        Me.RDV.AllowUserToDeleteRows = False
        Me.RDV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.RDV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.RDV.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.RDV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.RDV.Location = New System.Drawing.Point(790, 205)
        Me.RDV.Name = "RDV"
        Me.RDV.ReadOnly = True
        Me.RDV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.RDV.Size = New System.Drawing.Size(424, 272)
        Me.RDV.TabIndex = 19
        '
        'Recherche
        '
        Me.Recherche.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.Recherche.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Recherche.BackColor = System.Drawing.Color.Gainsboro
        Me.Recherche.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Recherche.FormattingEnabled = True
        Me.Recherche.Location = New System.Drawing.Point(28, 124)
        Me.Recherche.Name = "Recherche"
        Me.Recherche.Size = New System.Drawing.Size(1186, 21)
        Me.Recherche.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Lato", 16.25!)
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(23, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(456, 33)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Recherche de candidature"
        '
        'EspaceRH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1245, 503)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Recherche)
        Me.Controls.Add(Me.RDV)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Candidatures)
        Me.Controls.Add(Me.Espace)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EspaceRH"
        Me.ShowIcon = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Espace RH"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Candidatures, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RDV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents Espace As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Candidatures As Windows.Forms.DataGridView
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents RDV As Windows.Forms.DataGridView
    Friend WithEvents Recherche As Windows.Forms.ComboBox
    Friend WithEvents Label4 As Windows.Forms.Label
End Class
