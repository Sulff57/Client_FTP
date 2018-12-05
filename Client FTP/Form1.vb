Imports System.net





Public Class Form1

    Dim x As Integer 'variable de boucle
    Dim dossierCourant As String = My.Computer.FileSystem.CurrentDirectory
    Dim fichierCfg As String = dossierCourant + "/clientFTP.cfg"
    'définit le nom du fichier de configuration et l'endroit où il se trouvera
    'currentdirectory = dossier de l'application

    Dim repertoireDeTravail As String

    'PROCEDURES

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        charger_cfg()
        definir_listview(liste_dossierLocal)
        definir_listview(liste_dossierDistant)

        CheminAccesTxt.Text = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
        'on ne peut pas obtenir directement le répertoire désiré,
        'on obtient son ID puis à partir de celui-ci le chemin d'accès correspondant

        afficher_contenu_local()
        ' on définit Mes Documents comme le répertoire par défaut à afficher



    End Sub

    Private Sub OuvrirFichier_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OuvrirFichier.Click


        SelectionDossier.ShowDialog()
        CheminAccesTxt.Text = SelectionDossier.SelectedPath


        afficher_contenu_local()

    End Sub



    Private Sub afficher_contenu_local()
        Dim colonnes As System.Windows.Forms.ListViewItem

        Dim ObjetRepertoire, repertoires, fichiers, SousRepertoire, fichier As Object


        'on vide la liste en cas de changement de répertoire
        ViderListe(liste_dossierLocal)


        ObjetRepertoire = CreateObject("Scripting.FileSystemObject")
        'Objet système de fichiers
        'va servir à créer les objets répertoire et fichiers
        'liste méthodes FileSystemObject : 
        'http://www.commentcamarche.net/contents/vbscript/vbs-fso.php3

        ObjetRepertoire = ObjetRepertoire.GetFolder(CheminAccesTxt.Text)
        'on crée un objet répertoire à partir du chemin d'accès

        repertoires = ObjetRepertoire.SubFolders
        'on crée un objet servant à obtenir les sous dossiers du dossiers en cours

        fichiers = ObjetRepertoire.Files
        'idem pour les fichiers

        ImageList1.Images.Add("icone_dossier", Image.FromFile(dossierCourant + "\icone_dossier.bmp"))

        liste_dossierLocal.SmallImageList = ImageList1

        'ajout du lien vers le repertoire racine

        colonnes = liste_dossierLocal.Items.Add("...")

        'ajout des répertoires
        For Each SousRepertoire In repertoires


            colonnes = liste_dossierLocal.Items.Add(SousRepertoire.Name)
            colonnes.SubItems.Add("")
            'taille nulle car c'est un répertoire
            colonnes.SubItems.Add(SousRepertoire.Type)
            colonnes.SubItems.Add(SousRepertoire.DateCreated)

        Next

        'ajout des fichiers
        For Each fichier In fichiers

            colonnes = liste_dossierLocal.Items.Add(fichier.Name)

            colonnes.SubItems.Add(fichier.size)
            'taille nulle car c'est un répertoire
            colonnes.SubItems.Add(fichier.Type)
            colonnes.SubItems.Add(fichier.DateCreated)
        Next
        'ajout des dossiers


    End Sub

    Private Sub DoubleClic_listeLocale(ByVal sender As Object, ByVal e As System.EventArgs) Handles liste_dossierLocal.DoubleClick

        Dim pos_slash, rep_clic_pos As Integer
        Dim rep_clic_nom, chemin_acces_clic As String
        Dim ObjetRepertoire As Object
        Dim est_Repertoire As Boolean

        If (liste_dossierLocal.SelectedItems(0).Index = 0) Then
            'clic sur les ...
            pos_slash = CheminAccesTxt.Text.LastIndexOf("\")

            If (pos_slash > 0) Then
                CheminAccesTxt.Text = CheminAccesTxt.Text.Substring(0, pos_slash)
                'cette fonction se sert de CheminAccesTxt.text
                'pour remplir la listview
                'donc on aura la nouvelle liste du repertoire parent
            End If
        Else
            rep_clic_pos = liste_dossierLocal.SelectedItems(0).Index
            rep_clic_nom = liste_dossierLocal.Items(rep_clic_pos).Text
            chemin_acces_clic = CheminAccesTxt.Text + "\" + rep_clic_nom

            ObjetRepertoire = CreateObject("Scripting.FileSystemObject")
            est_Repertoire = ObjetRepertoire.FolderExists(chemin_acces_clic)

            If (est_Repertoire) Then
                CheminAccesTxt.Text = chemin_acces_clic
            End If
        End If

        ViderListe(liste_dossierLocal)
        afficher_contenu_local()




    End Sub

    Private Sub ViderListe(ByRef liste As Object)

        'vide une liste.
        'on vide dans le sens inverse pour éviter que les items
        'ne changent d'index

        For x = liste.items.count - 1 To 0 Step -1
            liste.Items.removeat(x)
        Next
    End Sub

    Private Sub bouton_envoyer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles boutton_envoyer.Click

        Dim nomFichier As String
        nomFichier = liste_dossierLocal.SelectedItems.Item(0).Text

        Dim location_fichier As String = CheminAccesTxt.Text + "\" + nomFichier 'Chemin d'accès du fichier à envoyer
        Dim destination_fichier As String




        destination_fichier = ftpisation(ServAdr.Text + "/" + repertoireDeTravail + "/" + nomFichier) 'Location du fichier sur le serveur

        My.Computer.Network.UploadFile(location_fichier, destination_fichier, IdentifiantTxt.Text, MdpTxt.Text, True, 100000)

    End Sub

    Private Sub bouton_recevoir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bouton_recevoir.Click
        Dim nomFichier As String
        nomFichier = liste_dossierDistant.SelectedItems.Item(0).Text

        Dim location_fichier As New Uri(ftpisation(ServAdr.Text + "/" + repertoireDeTravail + "/" + nomFichier)) 'Chemin d'accès du fichier à envoyer
        Dim destination_fichier As String




        destination_fichier = CheminAccesTxt.Text + "\" + nomFichier 'Location du fichier sur le serveur

        'My.Computer.Network.DownloadFile(location_fichier, destination_fichier, IdentifiantTxt.Text, MdpTxt.Text, True, 100000)
        My.Computer.Network.DownloadFile(location_fichier, destination_fichier, IdentifiantTxt.Text, MdpTxt.Text, True, 100000)
    End Sub



    Private Sub Connexion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Connexion.Click

        connect_ftp()

        
    End Sub

    Private Sub connect_ftp(Optional ByVal repertoire As String = "")

        Dim uri As String


        enregistrer_cfg()
        ViderListe(liste_dossierDistant)


        uri = ftpisation(ServAdr.Text + "/" + repertoire)
        Dim fwr As FtpWebRequest
        fwr = FtpWebRequest.Create(uri)

        Dim colonnes As System.Windows.Forms.ListViewItem
        fwr.Credentials = New NetworkCredential(IdentifiantTxt.Text, MdpTxt.Text)
        fwr.Method = WebRequestMethods.Ftp.ListDirectoryDetails

        Dim sr As New System.IO.StreamReader(fwr.GetResponse().GetResponseStream())

        Dim str As String = sr.ReadLine()

        'on parse les informations de Ftp.ListDirectoryDetails

        colonnes = liste_dossierDistant.Items.Add("..")

        While Not str Is Nothing
            Dim tab_ensemble As New ArrayList
            Dim tab_element, element_date As String
            Dim element_nom As String = ""
            Dim taille As Integer
            Dim x As Integer = 0

            'la structure après le parsing est différente entre les fichiers et dossiers
            'donc on crée 2 tableaux distincts

            'tableau des fichiers et dossiers
            For Each tab_element In str.Split(" ")
                If tab_element <> "" Then
                    tab_ensemble.Add(tab_element)
                End If
            Next

            'récupération de la taille
            taille = tab_ensemble(4)
            'récupération de la date
            element_date = tab_ensemble(5) + " " + tab_ensemble(6) + " " + tab_ensemble(7)

            'récupération du nom

            Dim indexDernierElement As Integer = tailleArrayList(tab_ensemble) - 1

            For Each tab_element In tab_ensemble

                If x >= 8 Then
                    If x = indexDernierElement Then
                        element_nom += tab_ensemble(x)
                    Else
                        element_nom += tab_ensemble(x) + " "
                    End If
                End If
                x += 1
            Next

 


            colonnes = liste_dossierDistant.Items.Add(element_nom)

            If taille Then
                colonnes.SubItems.Add(taille)
                colonnes.SubItems.Add("Fichier")

            Else
                colonnes.SubItems.Add("")
                colonnes.SubItems.Add("Dossier de fichiers")

            End If
            colonnes.SubItems.Add(element_date)
            str = sr.ReadLine()
        End While

        sr.Close()

        sr = Nothing

        fwr = Nothing

    End Sub



    Private Sub definir_listview(ByVal liste As ListView)
        liste.View = View.Details
        'ajoute une barre grise avec description des colonnes en haut

        liste.MultiSelect = False
        liste.Alignment = ListViewAlignment.Left
        liste.GridLines = True
        liste.AllowColumnReorder = True
        liste.Clear()


        liste.Columns.Add("nom", 140, HorizontalAlignment.Right)
        liste.Columns.Add("taille", 70, HorizontalAlignment.Right)
        liste.Columns.Add("type", 100, HorizontalAlignment.Right)
        liste.Columns.Add("modifié le", 100, HorizontalAlignment.Right)


    End Sub


    '    Private Sub liste_dossierLocal_ColumnClick(ByVal sender As System.Object, _
    'ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles liste_dossierLocal.ColumnClick



    '    End Sub


    Private Sub enregistrer_cfg()
        Dim fileW As System.IO.StreamWriter 'creation d'un objet d'écriture

        fileW = My.Computer.FileSystem.OpenTextFileWriter(fichierCfg, False)

        fileW.WriteLine(ServAdr.Text)
        fileW.WriteLine(IdentifiantTxt.Text)
        fileW.WriteLine(MdpTxt.Text)

        fileW.Close()




    End Sub
    Private Sub charger_cfg()
        Dim fileR As System.IO.StreamReader 'creation d'un objet de lecture


        If System.IO.File.Exists(fichierCfg) Then

            fileR = My.Computer.FileSystem.OpenTextFileReader(fichierCfg)

            ServAdr.Text = fileR.ReadLine
            IdentifiantTxt.Text = fileR.ReadLine
            MdpTxt.Text = fileR.ReadLine


            fileR.Close()

        End If
    End Sub

    Private Sub liste_dossierDistant_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles liste_dossierDistant.DoubleClick

        'la procédure est appelée deux fois pour un seul clic car la sélection de la liste semble se faire
        'en même temps que celle de l'item donc on ajoute une condition (sinon bug)

        If (liste_dossierDistant.SelectedItems.Count > 0) Then
            Dim item As Integer
            Dim item_text As String
            item = liste_dossierDistant.SelectedIndices.Item(0)
            item_text = liste_dossierDistant.Items(item).Text
            repertoireDeTravail = item_text
            connect_ftp(item_text)
        End If





    End Sub





    'FONCTIONS

    Private Function recupNom(ByVal cheminComplet As String)

        'fonction qui va récupérer le nom des fichiers ou dossiers
        'au lieu d'afficher le chemin complet
        ' ex : "c:\repertoire\fichier.txt" retourne "fichier.txt"

        Dim positionSlash As Integer
        Dim nomFin As String

        positionSlash = cheminComplet.LastIndexOf("\")
        nomFin = cheminComplet.Substring(positionSlash + 1)

        Return nomFin

    End Function

    Private Function ftpisation(ByVal adresseFtp As String) As String

        If adresseFtp.Substring(0, 6) = "ftp://" Then
            Return adresseFtp
        Else
            Return "ftp://" + adresseFtp
        End If

    End Function

    Private Function tailleArrayList(ByVal tableau As ArrayList) As Integer

        Dim x As Integer = 0
        Dim tab_element As String

        For Each tab_element In tableau
            x += 1
        Next

        Return x
    End Function


End Class

