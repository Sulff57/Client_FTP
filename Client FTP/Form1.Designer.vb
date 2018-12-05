<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label
        Me.ServAdr = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.boutton_envoyer = New System.Windows.Forms.Button
        Me.labelident = New System.Windows.Forms.Label
        Me.labelmdp = New System.Windows.Forms.Label
        Me.IdentifiantTxt = New System.Windows.Forms.TextBox
        Me.MdpTxt = New System.Windows.Forms.TextBox
        Me.SelectionDossier = New System.Windows.Forms.FolderBrowserDialog
        Me.OuvrirFichier = New System.Windows.Forms.Button
        Me.CheminAccesTxt = New System.Windows.Forms.TextBox
        Me.Connexion = New System.Windows.Forms.Button
        Me.liste_dossierLocal = New System.Windows.Forms.ListView
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.liste_dossierDistant = New System.Windows.Forms.ListView
        Me.bouton_recevoir = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 115)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Répertoire"
        '
        'ServAdr
        '
        Me.ServAdr.BackColor = System.Drawing.Color.White
        Me.ServAdr.Location = New System.Drawing.Point(138, 9)
        Me.ServAdr.Name = "ServAdr"
        Me.ServAdr.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ServAdr.Size = New System.Drawing.Size(154, 20)
        Me.ServAdr.TabIndex = 2
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(12, 9)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(54, 16)
        Me.label2.TabIndex = 4
        Me.label2.Text = "Adresse"
        '
        'boutton_envoyer
        '
        Me.boutton_envoyer.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.boutton_envoyer.Location = New System.Drawing.Point(428, 339)
        Me.boutton_envoyer.Name = "boutton_envoyer"
        Me.boutton_envoyer.Size = New System.Drawing.Size(57, 23)
        Me.boutton_envoyer.TabIndex = 6
        Me.boutton_envoyer.Text = ">"
        Me.boutton_envoyer.UseVisualStyleBackColor = True
        '
        'labelident
        '
        Me.labelident.AutoSize = True
        Me.labelident.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelident.Location = New System.Drawing.Point(12, 62)
        Me.labelident.Name = "labelident"
        Me.labelident.Size = New System.Drawing.Size(65, 16)
        Me.labelident.TabIndex = 8
        Me.labelident.Text = "Identifiant"
        '
        'labelmdp
        '
        Me.labelmdp.AutoSize = True
        Me.labelmdp.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelmdp.Location = New System.Drawing.Point(12, 88)
        Me.labelmdp.Name = "labelmdp"
        Me.labelmdp.Size = New System.Drawing.Size(84, 16)
        Me.labelmdp.TabIndex = 9
        Me.labelmdp.Text = "Mot de passe"
        '
        'IdentifiantTxt
        '
        Me.IdentifiantTxt.BackColor = System.Drawing.Color.White
        Me.IdentifiantTxt.Location = New System.Drawing.Point(138, 61)
        Me.IdentifiantTxt.Name = "IdentifiantTxt"
        Me.IdentifiantTxt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.IdentifiantTxt.Size = New System.Drawing.Size(154, 20)
        Me.IdentifiantTxt.TabIndex = 10
        '
        'MdpTxt
        '
        Me.MdpTxt.BackColor = System.Drawing.Color.White
        Me.MdpTxt.Location = New System.Drawing.Point(138, 87)
        Me.MdpTxt.Name = "MdpTxt"
        Me.MdpTxt.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.MdpTxt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MdpTxt.Size = New System.Drawing.Size(154, 20)
        Me.MdpTxt.TabIndex = 11
        '
        'OuvrirFichier
        '
        Me.OuvrirFichier.Location = New System.Drawing.Point(264, 113)
        Me.OuvrirFichier.Name = "OuvrirFichier"
        Me.OuvrirFichier.Size = New System.Drawing.Size(28, 21)
        Me.OuvrirFichier.TabIndex = 15
        Me.OuvrirFichier.Text = "..."
        Me.OuvrirFichier.UseVisualStyleBackColor = True
        '
        'CheminAccesTxt
        '
        Me.CheminAccesTxt.Location = New System.Drawing.Point(138, 114)
        Me.CheminAccesTxt.Name = "CheminAccesTxt"
        Me.CheminAccesTxt.Size = New System.Drawing.Size(120, 20)
        Me.CheminAccesTxt.TabIndex = 16
        '
        'Connexion
        '
        Me.Connexion.Location = New System.Drawing.Point(138, 149)
        Me.Connexion.Name = "Connexion"
        Me.Connexion.Size = New System.Drawing.Size(154, 23)
        Me.Connexion.TabIndex = 18
        Me.Connexion.Text = "Connexion"
        Me.Connexion.UseVisualStyleBackColor = True
        '
        'liste_dossierLocal
        '
        Me.liste_dossierLocal.LargeImageList = Me.ImageList1
        Me.liste_dossierLocal.Location = New System.Drawing.Point(7, 198)
        Me.liste_dossierLocal.Name = "liste_dossierLocal"
        Me.liste_dossierLocal.Size = New System.Drawing.Size(415, 320)
        Me.liste_dossierLocal.TabIndex = 21
        Me.liste_dossierLocal.UseCompatibleStateImageBehavior = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "icone_dossier.JPG")
        '
        'liste_dossierDistant
        '
        Me.liste_dossierDistant.Location = New System.Drawing.Point(491, 198)
        Me.liste_dossierDistant.Name = "liste_dossierDistant"
        Me.liste_dossierDistant.Size = New System.Drawing.Size(415, 320)
        Me.liste_dossierDistant.TabIndex = 22
        Me.liste_dossierDistant.UseCompatibleStateImageBehavior = False
        '
        'bouton_recevoir
        '
        Me.bouton_recevoir.Location = New System.Drawing.Point(428, 368)
        Me.bouton_recevoir.Name = "bouton_recevoir"
        Me.bouton_recevoir.Size = New System.Drawing.Size(57, 23)
        Me.bouton_recevoir.TabIndex = 23
        Me.bouton_recevoir.Text = "<"
        Me.bouton_recevoir.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Lavender
        Me.ClientSize = New System.Drawing.Size(918, 530)
        Me.Controls.Add(Me.bouton_recevoir)
        Me.Controls.Add(Me.liste_dossierDistant)
        Me.Controls.Add(Me.liste_dossierLocal)
        Me.Controls.Add(Me.Connexion)
        Me.Controls.Add(Me.CheminAccesTxt)
        Me.Controls.Add(Me.OuvrirFichier)
        Me.Controls.Add(Me.MdpTxt)
        Me.Controls.Add(Me.IdentifiantTxt)
        Me.Controls.Add(Me.labelmdp)
        Me.Controls.Add(Me.labelident)
        Me.Controls.Add(Me.boutton_envoyer)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.ServAdr)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "SendFile"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ServAdr As System.Windows.Forms.TextBox
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents boutton_envoyer As System.Windows.Forms.Button
    Friend WithEvents labelident As System.Windows.Forms.Label
    Friend WithEvents labelmdp As System.Windows.Forms.Label
    Friend WithEvents IdentifiantTxt As System.Windows.Forms.TextBox
    Friend WithEvents MdpTxt As System.Windows.Forms.TextBox
    Friend WithEvents SelectionDossier As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents OuvrirFichier As System.Windows.Forms.Button
    Friend WithEvents CheminAccesTxt As System.Windows.Forms.TextBox
    Friend WithEvents Connexion As System.Windows.Forms.Button
    Friend WithEvents liste_dossierLocal As System.Windows.Forms.ListView
    Friend WithEvents liste_dossierDistant As System.Windows.Forms.ListView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents bouton_recevoir As System.Windows.Forms.Button

End Class
