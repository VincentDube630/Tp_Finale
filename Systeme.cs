using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tp_Finale
{
    internal class Systeme
    {
        public static Dictionary<string, List<string>> dictionnaire { get; set; } = new Dictionary<string, List<string>>();
        public static Dictionary<string, List<string>> dictionnaireInstruments { get; set; } = new Dictionary<string, List<string>>();
        public static Dictionary<string, Mission> dictionnaireMission { get; set; } = new Dictionary<string, Mission>();

        public static void ChargerDonnees()
        {
            string cheminFichier = "Donnees.csv";

            if (File.Exists(cheminFichier))
            {
                foreach (var ligne in File.ReadLines(cheminFichier))
                {
                    string[] donnees = ligne.Split(';');

                    if (donnees.Length >= 1)
                    {
                        var valeurs = new List<string>();
                        var listeObservateur = new List<string>(); // Liste qui va avec la clée du dictionnaire pour les observateurs
                        var listeScientifique = new List<string>(); // Liste pour les scientifiques
                        var listMission = new List<string>();
                        string cleValeur;

                        // Ajout des valeurs dans une liste générale
                        for (int i = 0; i < donnees.Length; i++)
                        {
                            valeurs.Add(donnees[i]);
                        }
                        // Si observateur
                        if (valeurs[3] == "")
                        {
                            cleValeur = donnees[0];
                            listeObservateur.Add(valeurs[1]); // Deviens le nom en 0
                            listeObservateur.Add(valeurs[2]); // Deviens date naissance en 1

                            // Ajouter au dictionnaire
                            Systeme.dictionnaire.Add(cleValeur, listeObservateur);

                        }
                        if (valeurs[5]!="")
                        {
                            cleValeur=valeurs[1];
                            Mission mission = new Mission(valeurs[1], valeurs[0], DateTime.Parse(valeurs[6]), int.Parse(valeurs[5]), valeurs[4], valeurs[3], valeurs[2]); 
                            //valeurs[0]); // Le nom de la mission devient 0
                            //listMission.Add(valeurs[2]);//Le matricule du scientifique devient le numero 1
                            //listMission.Add(valeurs[3]);//la catégorie devient le numero 2
                            //listMission.Add(valeurs[4]);// le vaisseau devient le 3
                            //listMission.Add(valeurs[5]);// la duree devient le 4
                            //listMission.Add(valeurs[6]);// La date de lancement devient le 5
                            if (!Systeme.dictionnaireMission.ContainsKey(cleValeur))
                            {
                                Systeme.dictionnaireMission.Add(cleValeur, mission);

                            }

                        }
                        // Si scientifique
                        if (valeurs[5] == "" && valeurs[3]!="") 
                        {
                            cleValeur = valeurs[3];
                            listeScientifique.Add(valeurs[1]); // Deviens le nom en 0
                            listeScientifique.Add(valeurs[2]); // Deviens date naissance en 1
                            listeScientifique.Add(valeurs[4]); // Deviens la fonction (ingénieur...) en 2

                            // Ajouter au dictionnaire

                            if (!Systeme.dictionnaire.ContainsKey(cleValeur))
                            {
                                Systeme.dictionnaire.Add(cleValeur, listeScientifique);
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Fichier introuvable");
            }
            string cheminFichier1="InstrumentMesures";

            if (File.Exists(cheminFichier1))
            {
                foreach (var ligne in File.ReadLines(cheminFichier1))
                {
                    string[] donnees = ligne.Split(';');

                    if (donnees.Length >= 1)
                    {
                        var valeurs = new List<string>();
                        var listeInstrumentsAnalyse = new List<string>(); // Liste qui va avec la clée du dictionnaire pour tous les instruments analyse
                        var listeInstrumentsObservation = new List<string>();// Liste qui va avec la cle du dictionnaire pour tous les instruments observation
                        string cleValeur;

                        // Ajout des valeurs dans une liste générale
                        for (int i = 0; i < donnees.Length; i++)
                        {
                            valeurs.Add(donnees[i]);
                        }
                        if (valeurs[3]!="")
                        {
                            cleValeur = valeurs[0];
                            listeInstrumentsObservation.Add(valeurs[1]);
                            listeInstrumentsObservation.Add(valeurs[2]);
                            listeInstrumentsObservation.Add(valeurs[3]);
                            if (!Systeme.dictionnaireInstruments.ContainsKey(cleValeur))
                            {
                                Systeme.dictionnaireInstruments.Add(cleValeur, listeInstrumentsObservation);

                            }
                        }
                        else
                        {
                            cleValeur=valeurs[0];
                            listeInstrumentsAnalyse.Add(valeurs[1]);
                            listeInstrumentsAnalyse.Add(valeurs[2]);
                            if (!Systeme.dictionnaireInstruments.ContainsKey(cleValeur))
                            {
                                Systeme.dictionnaireInstruments.Add(cleValeur, listeInstrumentsAnalyse);

                            }
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("Fichier introuvable");
            }
            string cheminFichier2 = "ObjetMission";
            if (File.Exists(cheminFichier2))
            {
                foreach (var ligne in File.ReadLines(cheminFichier2))
                {
                    string[] donnees = ligne.Split(';');

                    //if (donnees.Length >= 1)
                    //{
                    //    var valeurs = new List<string>();
                    //    var listePlante = new List<string>(); // Liste qui va avec la clée du dictionnaire pour tous les objets planete
                    //    var listeSatelitte = new List<string>(); // Liste qui va avec la clée du dictionnaire pour tous les objets satelitte
                    //    var listeEtoile = new List<string>(); // Liste qui va avec la clée du dictionnaire pour tous les objets etoile
                    //    string cleValeur;

                    //    // Ajout des valeurs dans une liste générale
                    //    for (int i = 0; i < donnees.Length; i++)
                    //    {
                    //        valeurs.Add(donnees[i]);
                    //    }
                    //    if (valeurs[6] != "")
                    //    {
                    //        cleValeur = valeurs[1];
                    //        listePlante.Add(valeurs[1]);
                    //        listeInstrumentsObservation.Add(valeurs[2]);
                    //        listeInstrumentsObservation.Add(valeurs[3]);
                    //        if (!Systeme.dictionnaireInstruments.ContainsKey(cleValeur))
                    //        {
                    //            Systeme.dictionnaireInstruments.Add(cleValeur, listeInstrumentsObservation);

                    //        }
                    //    }
                    //    else
                    //    {
                    //        cleValeur = valeurs[0];
                    //        listeInstrumentsAnalyse.Add(valeurs[1]);
                    //        listeInstrumentsAnalyse.Add(valeurs[2]);
                    //        if (!Systeme.dictionnaireInstruments.ContainsKey(cleValeur))
                    //        {
                    //            Systeme.dictionnaireInstruments.Add(cleValeur, listeInstrumentsAnalyse);

                    //        }
                    //    }

                    //}
                }
            }
            else
            {
                Console.WriteLine("Fichier introuvable");
            }
            // Objets célestes
            foreach (var ligne in File.ReadLines("ObjetMission.csv"))
            {
                string[] valeurs = ligne.Split(';');
                ObjetCeleste objet;

                if (valeurs[6] == "" && valeurs[7] == "")
                {
                    double resultat1 = ConvertirNotationScientifiqueDouble(valeurs[4]);
                    ObjetCeleste planete = new Planete(valeurs[0], valeurs[1], valeurs[2], valeurs[3],resultat1, double.Parse(valeurs[5]));
                    objet = planete;
                }
                else if (valeurs[7] == "")
                {
                    double resultat1 = ConvertirNotationScientifiqueDouble(valeurs[4]);
                    double resultat2 = ConvertirNotationScientifiqueDouble(valeurs[6]);
                    ObjetCeleste etoile = new Etoile(valeurs[0], valeurs[1], valeurs[2], valeurs[3], resultat1, double.Parse(valeurs[5], CultureInfo.InvariantCulture),resultat2);
                    objet = etoile;
                }
                else
                {
                    double resultat1 = ConvertirNotationScientifiqueDouble(valeurs[4]);
                    ObjetCeleste satellite = new Satellite(valeurs[0], valeurs[1], valeurs[2], valeurs[3],resultat1, double.Parse(valeurs[5], CultureInfo.InvariantCulture), double.Parse(valeurs[6], CultureInfo.InvariantCulture), double.Parse(valeurs[7]));
                    objet = satellite;
                }

                // Missions
                if (dictionnaireMission.ContainsKey(objet.Scientifique))
                {
                    dictionnaireMission[objet.Scientifique].Destination = objet;
                }
            }
        }
        static double ConvertirNotationScientifiqueDouble(string input)
        {
            // Nettoyer les espaces et normaliser le format
            input = input.Replace(" ", "").ToLower();

            // Remplacer "x10^" par "e" pour passer à une notation scientifique standard
            input = Regex.Replace(input, @"x10\^", "e");

            return double.Parse(input, NumberStyles.Float, CultureInfo.InvariantCulture);
        }

        public void SauvegarderDonnees()
        {

        }
        public void SauvegarderDonneesScientifique(Utilisateur utilisateur )
        {

        }
        public void ConnexionUtilisateur(string id)
        {
            if (dictionnaire.ContainsKey(id) == false)
            {
                Console.WriteLine("Aucune correspondance trouvé");
                Console.WriteLine("Re rentrer le numéro (R)");
                Console.WriteLine("Menu principale (MP)");
                string choix1 = Console.ReadLine();
                switch (choix1)
                {
                    case "R":
                        Console.Write("Numéro : ");
                        id = Console.ReadLine();
                        ConnexionUtilisateur(id);
                        break;
                    case "MP":
                        break;
                    default:
                        break;
                }
            }
            else
            {
                string observateur1 = "";
                List<string> valeurs = dictionnaire[id];
                string nomComplet = valeurs[0];
                string[] nomGauche = nomComplet.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string prenom = "";
                string nom = "";
                if (valeurs.Count < 2 && !string.IsNullOrWhiteSpace(valeurs[ 2]))
                {
                    observateur1 = "A";
                }
                if (nomGauche.Length >= 2)
                {
                    prenom = nomGauche[0];
                    nom = string.Join(" ", nomGauche.Skip(1)); // Si Nom de famille avec espace
                }
                if (valeurs.Count > 2 && !string.IsNullOrWhiteSpace(valeurs[2])&& observateur1=="A") // Si il y a des données a la valeur 3 du la liste a l'id donnée alors ce n'est pas un observateur mais un scientifique
                {
                    Console.WriteLine("Ce numéro n'est pas un observateur");
                    Console.Write("Re rentrer votre numéro d'identification : ");
                    id = Console.ReadLine();
                    ConnexionUtilisateur(id);
                }
                else if (valeurs.Count > 2 && !string.IsNullOrWhiteSpace(valeurs[2]) && observateur1 == "")
                {
                    Scientifique scientifique = new Scientifique(id, nom, prenom, DateTime.Parse(valeurs[1]));
                    scientifique.AfficherInfo();
                    Console.WriteLine();
                    Console.WriteLine("Gestion des profils (GP)");
                    Console.WriteLine("Gestion des objets (GO)");
                    Console.WriteLine("Gestion des missions (GM)");
                    Console.WriteLine("Gestion des instruments de mesures (GI)");
                    Console.WriteLine("Simulation des mesures (SI)");
                    Console.Write("Choix : ");
                    string mo = "";
                    bool recommencer = true;
                    do
                    {
                        try
                        {
                            mo = Console.ReadLine();
                            recommencer = true;
                        }
                        catch (FormatException)
                        {
                            recommencer = false;
                            Console.WriteLine("Erreur, ce n'est pas une chaine de caractère");
                        }
                    } while (!recommencer);
                    switch (mo)
                    {
                        case "GP":
                            Console.WriteLine("Ajout d'un observateur (O)");
                            Console.WriteLine("Ajouit d'un scientifique (S)");
                            string choix = "";
                            try
                            {
                               choix = Console.ReadLine();
                            }
                            catch(FormatException)
                            {
                                Console.WriteLine("Erreur, ce n'est pas une chaine de caractère");
                            }
                            if(choix == "O")
                            {
                                Console.Write("Numéro de l'identification : ");
                                string matricule = Console.ReadLine();
                                Console.Write("Nom : ");
                                string noom = Console.ReadLine();
                                Console.Write("Prenom : ");
                                string prenoom = Console.ReadLine();
                                Console.Write("Date naissance : ");
                                string dateNaissance = Console.ReadLine();
                                scientifique.AjouterObservateur(new Observateur(matricule, noom, prenoom, DateTime.Parse(dateNaissance)));
                                List<string> liste = new List<string>();
                                liste.Add(noom);
                                liste.Add(prenom);
                                liste.Add(dateNaissance);
                                Systeme.dictionnaire.Add(matricule, liste);
                            }
                            else if (choix == "S")
                            {
                                Console.Write("Numéro de matricule : ");
                                string matricule = Console.ReadLine();
                                Console.Write("Nom : ");
                                string noom = Console.ReadLine();
                                Console.Write("Prenom : ");
                                string prenoom = Console.ReadLine();
                                Console.Write("Date naissance : ");
                                string dateNaissance = Console.ReadLine();
                                scientifique.AjouterScientifique(new Scientifique(matricule,noom,prenoom,DateTime.Parse(dateNaissance)));
                                List<string>liste=new List<string>();
                                liste.Add(noom);
                                liste.Add(prenom);
                                liste.Add(dateNaissance);
                                Systeme.dictionnaire.Add(matricule, liste);
                            }
                            else if(choix == "Q")
                            {
                                ConnexionUtilisateur(id);
                            }

                            break;
                        case "GO":
                            Console.WriteLine("Gestion des objets : ");
                            Console.WriteLine();
                            Console.WriteLine("Planètes (PL)");
                            Console.WriteLine("Étoiles (ET)");
                            Console.WriteLine("Satelittes (SA)");
                            Console.WriteLine("Quitter (Q)");
                            Console.WriteLine();
                            Console.Write("Votre choix ----> ");
                            choix = Console.ReadLine();
                            switch (choix)
                            {
                                case "PL":
                                    Console.WriteLine("Numéro de matricule du scientifique : ");
                                    string matricule = Console.ReadLine();
                                    if (dictionnaire.ContainsKey(matricule)==true)
                                    {
                                        Console.Write("Numéro d'identification de la mission : ");
                                        string numero = Console .ReadLine();
                                        
                                    }
                                    else
                                    {
                                        Console.WriteLine("Il n'y a pas de scientifique qui correspond à ce matricule ");
                                    }
                                    break;
                                case "ET":

                                    break;
                                case "SA":

                                    break;
                                case "Q":
                                    ConnexionUtilisateur(id);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "GM":
                            Console.WriteLine("Gestion des missions : ");
                            Console.WriteLine();
                            Console.WriteLine("Ajouter une mission (AM)");
                            Console.WriteLine("Suprimmer une mission (SU)");
                            Console.WriteLine("Quitter (Q)");
                            Console.WriteLine();
                            Console.Write("Votre choix ----> ");
                            choix = Console.ReadLine();
                            switch (choix)
                            {
                                case "AM":
                                    Console.Write("Numéro du scientifique pour l'ajout de la mission : ");
                                    string matricule = Console.ReadLine();
                                    if (dictionnaire.ContainsKey(matricule) == true)
                                    {
                                        Console.Write("Nom de la mission : ");
                                        nom = Console .ReadLine();
                                        Console.Write("Numéro de référence de la mission");
                                        string numeroMission1 = Console .ReadLine();
                                        Console.Write("Catégorie de la mission : ");
                                        string categorie = Console .ReadLine();
                                        Console.Write("Vaisseau spatial  : ");
                                        string vaisseau = Console .ReadLine();
                                        Console.Write("Durée estimée : ");
                                        string duree = Console .ReadLine();
                                        Console.Write("Date de lancement : ");
                                        string date = Console .ReadLine();
                                        dictionnaireMission.Add(matricule, new Mission(numeroMission1, nom, DateTime.Parse(date), int.Parse(duree), vaisseau, categorie, matricule));
                                        
                                    }
                                    else
                                    {
                                        Console.WriteLine("Il n'y a pas de scientifique qui ont ce matricule");
                                    }
                                    break;
                                case "SU":
                                    Console.WriteLine("Numero de la mission a suprimmer : ");
                                    string numeroMission = Console.ReadLine();
                                    foreach (var mission in dictionnaireMission.Values)
                                    {
                                        if (mission.NomMission== numeroMission)
                                        {
                                            string lalal = dictionnaireMission[mission.NomMission].Matricule;
                                            dictionnaireMission.Remove(lalal);
                                            Console.WriteLine("Mission suprimmé de la base de donnés");
                                        }
                                    }
                                    break;
                                case "Q":
                                    ConnexionUtilisateur(id);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "GI":
                            Console.WriteLine("Gestion des instruments de mesures : ");
                            Console.WriteLine();
                            Console.WriteLine("Instrument d'observation (IO)");
                            Console.WriteLine("Instrument d'analyse (IA)");
                            Console.WriteLine("Quitter (Q)");
                            Console.WriteLine();
                            Console.Write("Votre choix ---> ");
                            choix = Console.ReadLine();
                            switch (choix)
                            {
                                case "IO":
                                    break;
                                case "IA":
                                    break;
                                case "Q":
                                    ConnexionUtilisateur(id);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "SI":
                            Console.WriteLine("Catégorie pour faire la simulation : ");
                            Console.Write("Catégorie 1 : ");
                            string categorie1=Console.ReadLine();
                            Console.Write("Catégorie 2 : ");
                            string categorie2=Console.ReadLine();

                            break;
                        default:
                            break;
                    }

                }
                else
                {
                    Observateur observateur = new Observateur(id,nom, prenom, DateTime.Parse(valeurs[1]));
                    observateur.AfficherInfo();
                    Console.WriteLine();
                    Console.WriteLine("Recherche d'une mission (RM) : ");
                    Console.WriteLine("Liste des missions (LM) : ");
                    Console.WriteLine("Recherche un scientifique (RS) : ");
                    Console.WriteLine("Liste des scientifiques (LS) : ");
                    Console.WriteLine("Liste des instruments de mesure (LI) : ");
                    Console.Write("Votre choix ----> ");
                    string mo = "";
                    bool recommencer = true;
                    do
                    {
                        try
                        {
                            mo = Console.ReadLine();
                            recommencer = true;
                        }
                        catch (FormatException)
                        {
                            recommencer = false;
                            Console.WriteLine("Erreur, ce n'est pas une chaine de caractère");
                        }
                    } while (!recommencer);
                    switch (mo)
                    {
                        case "RM":
                            Console.WriteLine("Numéro de référence : ");
                            string numeroReference = "";
                            try
                            {
                                numeroReference=Console.ReadLine();
                            }
                            catch(FormatException)
                            {
                                Console.WriteLine("Ce n'est pas le bon format!");
                            }
                            if (dictionnaireMission.ContainsKey(numeroReference) == false)
                            {
                                Console.WriteLine("Il n'y a pas de numéro de mission correspodant");
                            }
                            else
                            {
                                Mission valeurs1 = dictionnaireMission[numeroReference];
                                //Mission mission = new Mission(numeroReference, valeurs1[0], DateTime.Parse(valeurs1[5]), int.Parse(valeurs1[4]), valeurs1[3], valeurs1[2]);
                                valeurs1.AfficherInfo();
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.Write("Revenir au menu princiaple : ");
                                string revenir = Console.ReadLine();
                                ConnexionUtilisateur(id);
                                
                            }
                            break;
                        case "LM":
                            List<int> list = new List<int>();
                            foreach (var valeur in dictionnaireMission.Values)
                            {
                                //string dureeString = valeur[4];
                                //int duree = int.Parse(dureeString);
                                int duree = valeur.DureeEstimee;
                                list.Add(duree);

                            }
                            list.Sort();
                            List<List<string>> missionsTri = new List<List<string>>();
                            for (int i = 0; i < dictionnaireMission.Count; i++)
                            {
                                foreach (var item in dictionnaireMission.Keys)
                                {
                                    //List<string> a = new List<string>();
                                    //a = dictionnaireMission[item];
                                    Mission mission = dictionnaireMission[item];
                                    int duree = mission.DureeEstimee;
                                    if (list[i] == duree)
                                    {
                                        //missionsTri.Add(a);
                                        //Mission mission = new Mission(item, a[0], DateTime.Parse(a[5]), duree, a[3], a[2]);
                                        //mission.AfficherInfo();
                                        mission.AfficherInfo();
                                    }
                                }
                            }

                            break;
                        case "RS":
                            Console.WriteLine("Numéro matricule du scientifique : ");
                            string matricule = Console.ReadLine();

                            if (dictionnaire.ContainsKey(matricule))
                            {
                                Console.WriteLine($"\nNom et prénom : {dictionnaire[matricule][0]}");
                                Console.WriteLine($"Date de naissance : {dictionnaire[matricule][1]}");
                                Console.WriteLine("Adresse : Adresse pas fournie dans les fichiers");
                                Console.Write("Missions affectées : ");

                                int j = 0;
                                foreach (var mission in dictionnaireMission.Values)
                                {
                                    if (mission.Matricule == matricule)
                                    {
                                        Console.Write($"{mission.NomMission} ; ");
                                        j++;
                                    }
                                }
                                if (j == 0)
                                {
                                    Console.Write("Aucune mission affectée.");
                                }

                            }
                            else
                            {
                                Console.WriteLine("Le scientifique n'existe pas.");
                            }
                            Console.WriteLine();
                            break;
                        case "LS":
                            List<string> utilisateur;
                            foreach (var item in dictionnaire.Keys)
                            {
                                utilisateur = dictionnaire[item];
                                utilisateur.Add("");
                                if (utilisateur[2] != "")
                                {
                                    Console.WriteLine($"Nom : {dictionnaire[item][0]}");
                                    Console.WriteLine($"Matricule : {item}");
                                    Console.WriteLine($"Nom : {dictionnaire[item][1]}");
                                    Console.WriteLine($"Fonction : {dictionnaire[item][2]}");
                                    Console.WriteLine();
                                }
                            }

                                break;
                        case "LI":
                            Console.WriteLine("Numéro de référence : ");
                            numeroReference = "";
                            try
                            {
                                numeroReference = Console.ReadLine();
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Ce n'est pas le bon format!");
                            }
                            if (dictionnaireInstruments.ContainsKey(numeroReference) == false)
                            {
                                Console.WriteLine("Il n'y a pas de numéro de mission correspodant");
                            }
                            else
                            {
                                List<string> valeurs1 = dictionnaireInstruments[numeroReference];
                                if (valeurs1[3] != "")
                                {
                                    InstrumentObservation instrumentObservation2 = new InstrumentObservation(numeroReference, valeurs1[1], valeurs1[2], int.Parse(valeurs1[3]));
                                }
                                else
                                {
                                    InstrumentAnalyse instrumentAnalyse2 = new InstrumentAnalyse(numeroReference, valeurs1[1], valeurs1[2]);
                                }
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.Write("Revenir au menu princiaple : ");
                                string revenir = Console.ReadLine();
                                ConnexionUtilisateur(id);

                            }
                            break;
                        default:

                            break;
                    }
                }
            }
        }
    }
}

       

