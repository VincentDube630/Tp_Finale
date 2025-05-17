using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tp_Finale
{
    internal class Systeme
    {
        // Déclarer l'ensemble des dictionnaires en static pour qu'ils soient accesible dans tous les classes
        public static Dictionary<string, List<string>> dictionnaire { get; set; } = new Dictionary<string, List<string>>();
        public static Dictionary<string, List<string>> dictionnaireInstruments { get; set; } = new Dictionary<string, List<string>>();
        public static Dictionary<string, Mission> dictionnaireMission { get; set; } = new Dictionary<string, Mission>();
        public static Dictionary<string, Mission> dictionnaireNouveauMission { get; set; } = new Dictionary<string, Mission>();
        public static Dictionary<string, List<string>> dictionnaireNouveauUtilisateur { get; set; } = new Dictionary<string, List<string>>();
        public static Dictionary<string, List<string>> dictionnaireNouveauxInstruments{ get; set; } = new Dictionary<string, List<string>>();
        public static ObjetCeleste objet { get; set; }

        // Fonction pour charger les données du fichier excel
        public static void ChargerDonnees()
        {
            string cheminFichier = "Donnees.csv";

            // Si le dossier "Donnees.csv" fonctionne alors commencer à noter les attributs
            if (File.Exists(cheminFichier))
            {
                // Utiliser foreach afin que chaque ligne du fichier sois pris en compte
                foreach (var ligne in File.ReadLines(cheminFichier))
                {
                    // Les données du fichier sont enregistrées dans un tableau string et séparé quand il y a un point-virgule (;)
                    string[] donnees = ligne.Split(';');

                    if (donnees.Length >= 1)
                    {
                        // Création de la clé ainsi que les différentes listes 
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
                            if (!dictionnaire.ContainsKey(cleValeur))
                            {
                                Systeme.dictionnaire.Add(cleValeur, listeObservateur);

                            }

                        }
                        if (valeurs[5]!="")
                        {
                            // Le dictionnaire dictionnaireMission est composé de la clé ainsi que de l'objet Mission qui contient touus les attributs d'une mission
                            cleValeur=valeurs[1];
                            Mission mission = new Mission(valeurs[1], valeurs[0], DateTime.Parse(valeurs[6]), int.Parse(valeurs[5]), valeurs[4], valeurs[3], valeurs[2]); 
                          
                            // Autre manière de le faire (décidé de changer )
                            
                            //valeurs[0]); // Le nom de la mission devient 0
                            //listMission.Add(valeurs[2]);//Le matricule du scientifique devient le numero 1
                            //listMission.Add(valeurs[3]);//la catégorie devient le numero 2
                            //listMission.Add(valeurs[4]);// le vaisseau devient le 3
                            //listMission.Add(valeurs[5]);// la duree devient le 4
                            //listMission.Add(valeurs[6]);// La date de lancement devient le 5


                            // Ajout au dictionnaireMission
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
            string cheminFichier1="IntrusmentMesures.csv";
            // Si le fichier "InstrumentMesures" existe alors commencer la lecture
            if (File.Exists(cheminFichier1))
            {
                // lire chaque ligne du fichier avec un foreach
                foreach (var ligne in File.ReadLines(cheminFichier1))
                {
                    string[] donnees = ligne.Split(';');
                    // Si il y a plus d'une ligne alors crééer les listes et la clé
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
                        // SI c'est un instrument d'observation
                        if (valeurs[3]!="")
                        {
                            cleValeur = valeurs[0];
                            listeInstrumentsObservation.Add(valeurs[1]);
                            listeInstrumentsObservation.Add(valeurs[2]);
                            listeInstrumentsObservation.Add(valeurs[3]);
                            // Ajout au dictionnaire
                            if (!Systeme.dictionnaireInstruments.ContainsKey(cleValeur))
                            {
                                Systeme.dictionnaireInstruments.Add(cleValeur, listeInstrumentsObservation);

                            }
                        }
                        else
                        {
                            // Si c'est un instrument d'analyse
                            cleValeur=valeurs[0];
                            listeInstrumentsAnalyse.Add(valeurs[1]);
                            listeInstrumentsAnalyse.Add(valeurs[2]);
                            // ajout au dictionnaire
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
            string cheminFichier2 = "ObjetMission.csv";
            if (File.Exists(cheminFichier2))
            {
                foreach (var ligne in File.ReadLines(cheminFichier2))
                {
                    string[] donnees = ligne.Split(';');

                    // Autre méthode ( j'ai décidé de changer en cours de route car plus facile)


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

                // Si l'objet celeste est une planète
                if (valeurs[6] == "" && valeurs[7] == "")
                {
                    double resultat1 = ConvertirNotationScientifiqueDouble(valeurs[4]);
                    ObjetCeleste planete = new Planete(valeurs[0], valeurs[1], valeurs[2], valeurs[3],resultat1, double.Parse(valeurs[5]));
                    objet = planete;
                }
                // Si l'objet célèste est un étoile
                else if (valeurs[7] == "")
                {
                    double resultat1 = ConvertirNotationScientifiqueDouble(valeurs[4]);
                    double resultat2 = ConvertirNotationScientifiqueDouble(valeurs[6]);
                    ObjetCeleste etoile = new Etoile(valeurs[0], valeurs[1], valeurs[2], valeurs[3], resultat1, double.Parse(valeurs[5], CultureInfo.InvariantCulture),resultat2);
                    objet = etoile;
                }
                // Si l'objet célèste est un satelitte
                else
                {
                    double resultat1 = ConvertirNotationScientifiqueDouble(valeurs[4]);
                    ObjetCeleste satellite = new Satellite(valeurs[0], valeurs[1], valeurs[2], valeurs[3],resultat1, double.Parse(valeurs[5], CultureInfo.InvariantCulture), double.Parse(valeurs[6], CultureInfo.InvariantCulture), double.Parse(valeurs[7]));
                    objet = satellite;
                }

                // La destination des objets équivaut à planète ou étoile et satelitte.
                if (dictionnaireMission.ContainsKey(objet.Scientifique))
                {
                    dictionnaireMission[objet.Scientifique].Destination = objet;
                }
            }
        }
        
        // Fonction pour convertir les données car celle du professeur ne fonctionne pas
        static double ConvertirNotationScientifiqueDouble(string input)
        {
            // Nettoyer les espaces et normaliser le format
            input = input.Replace(" ", "").ToLower();

            // Remplacer "x10^" par "e" pour passer à une notation scientifique standard
            input = Regex.Replace(input, @"x10\^", "e");

            return double.Parse(input, NumberStyles.Float, CultureInfo.InvariantCulture);
        }

       
        // Sauvergarder les missions en mémoire
        public static void SauvegarderMission(Mission mission)
        {
            string cheminFichier = "Donnees.csv";

           
                using (StreamWriter fichier= new StreamWriter(cheminFichier, append: true))
                {
                    fichier.WriteLine($"{mission.NomMission};{mission.referenceMission};{mission.Matricule};{mission.Destination};{mission.VaisseauSpatial};{mission.DureeEstimee};{mission.DateLancement:yyyy-MM-dd}");
                }
            
        }

        // Sauvegarder les instruments en mémoire 
        static void SauvegarderListe()
        {
            string cheminFichier = "IntrusmentMesures.csv";
            using (StreamWriter writer = new StreamWriter(cheminFichier, true))
            {
                foreach(var nouveau in Systeme.dictionnaireNouveauxInstruments)
                {
                    string id = nouveau.Key;
                    List<string> list = nouveau.Value;

                    string ligne = "";
                    if (list.Count == 2)
                    {
                        //Ajout instrument d'analyse
                        ligne = $"{id};{list[0]};{list[1]}";
                    }
                    else
                    {
                        ligne = $"{id};{list[0]};{list[1]}{list[2]}";

                    }
                }
            }
        }

        // Sauvergarder les nouveaux scientifiques et observateurs en mémoire
        public void SauvegarderDonneesScientifique()
        {
            string cheminFichier = "Donnees.csv";

            using (StreamWriter writer = new StreamWriter(cheminFichier, true))
            {
                foreach (var nouveau in Systeme.dictionnaireNouveauUtilisateur)
                {
                    string id = nouveau.Key;
                    List<string> valeurs = nouveau.Value;
                    string ligne = "";

                    if (valeurs.Count == 2)
                    {
                        // Ajouter observateur
                        ligne = $"{id};{valeurs[0]} {valeurs[1]};;;;";
                    }
                    else if (valeurs.Count == 3)
                    {
                        // Ajouter scientifique
                        ligne = $"{id};{valeurs[0]} {valeurs[1]};{valeurs[2]};;;";
                    }

                    writer.WriteLine(ligne);
                }
            }

            Console.WriteLine("Nouveaux utilisateurs sauvegardés dans Donnees.csv.");
        }
    //Fonction qui te permet de te connecter ainsi que de faire l'ensemble du programme
        public void ConnexionUtilisateur(string id)
        {
            // Si le id que l'utilisateur a rentré n,est pas dans le dictionnaire alors un message d'erreur est affiché et l'utilisateur peut revenir au menu ou re rentrer la clé
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
            // Si elle correspond alors rentré dans le else
            else
            {
                // Séparé le nom et nom de famille ainsi que déclaré une liste qui prend en données les valeurs du dictionnaire que l'id est identique à la clé
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
                // Si c'est un scientifique crééer le scientifique et afficher les infos de celui-ci
                else if (valeurs.Count > 2 && !string.IsNullOrWhiteSpace(valeurs[2]) && observateur1 == "")
                {
                    Scientifique scientifique = new Scientifique(id, nom, prenom, DateTime.Parse(valeurs[1]));
                    scientifique.AfficherInfo();
                    Console.WriteLine();
                    // afficher le menu scientifique 
                    Console.WriteLine("Gestion des profils (GP)");
                    Console.WriteLine("Gestion des objets (GO)");
                    Console.WriteLine("Gestion des missions (GM)");
                    Console.WriteLine("Gestion des instruments de mesures (GI)");
                    Console.WriteLine("Simulation des mesures (SI)");
                    Console.WriteLine();
                    Console.WriteLine("Quitter : ");
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

                    // Switch pour prendre le choix de l'utilisateur 
                    switch (mo)
                    {
                        // Si l'utilisateur choisit "GP" comme option
                        case "GP":
                            // Demander si il veut ajouter un observsteur ou un scientifique
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
                            // Si observateur alors demandé tous les informations en lien avec l'observateur
                            if (choix == "O")
                            {
                                recommencer = true;
                                do
                                {
                                    Console.Write("Numéro de l'identification : ");
                                    string matricule = Console.ReadLine();
                                    Console.Write("Nom : ");
                                    string noom = Console.ReadLine();
                                    Console.Write("Prenom : ");
                                    string prenoom = Console.ReadLine();
                                    Console.Write("Date naissance : ");
                                    string dateNaissance = Console.ReadLine();

                                    // Créer l'observateur et l'enregistrer à l'aide de la fonction SauvergarderDonneesScientifique
                                    scientifique.AjouterObservateur(new Observateur(matricule, noom, prenoom, DateTime.Parse(dateNaissance)));
                                    List<string> liste = new List<string>();
                                    liste.Add(noom);
                                    liste.Add(prenoom);
                                    liste.Add(dateNaissance);
                                    if (!dictionnaire.ContainsKey(matricule))
                                    {
                                        Systeme.dictionnaire.Add(matricule, liste);
                                        Console.WriteLine("Observateur Créé");
                                        dictionnaireNouveauUtilisateur.Add(matricule, liste);
                                        SauvegarderDonneesScientifique();
                                    }
                                    else
                                    // Si il y a déja un observateur avec cette id aloirs l'afficher, proposer a nouveau d'entrer l'id ou revenir au menu principale 

                                    {
                                        Console.WriteLine("Il y a déja un observateur avec ce numéro");
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine("Re crééer un observateur (O)");
                                    Console.WriteLine("Menu principale (M)");
                                    Console.WriteLine("Votre choix ---->");
                                    choix = Console.ReadLine();
                                    if (choix == "S")
                                    {
                                        recommencer = true;
                                    }
                                    else
                                    {
                                        ConnexionUtilisateur(id);
                                    }
                                } while (recommencer == true);
                            }
                            else if (choix == "S")
                            {
                                // Si le choix est un scientifique alors rentré dans le if et demander les informations en lien avec le scientifique
                                recommencer = true;
                                do {
                                    Console.Write("Numéro de matricule : ");
                                    string matricule = Console.ReadLine();
                                    Console.Write("Nom : ");
                                    string noom = Console.ReadLine();
                                    Console.Write("Prenom : ");
                                    string prenoom = Console.ReadLine();
                                    Console.Write("Date naissance : ");
                                    string dateNaissance = Console.ReadLine();

                                    // Créer le scientifique et l'enregistrer à l'aide de la fonction SauvergarderDonneesScientifique
                                    scientifique.AjouterScientifique(new Scientifique(matricule, noom, prenoom, DateTime.Parse(dateNaissance)));
                                    List<string> liste = new List<string>();
                                    liste.Add(noom);
                                    liste.Add(prenoom);
                                    liste.Add(dateNaissance);
                                    if (!dictionnaire.ContainsKey(matricule))
                                    {
                                        Systeme.dictionnaire.Add(matricule, liste);
                                        Console.WriteLine("Scientifique créé avec succès !");
                                        dictionnaireNouveauUtilisateur.Add(matricule, liste);
                                        SauvegarderDonneesScientifique();
                                    }
                                    // Si il y a déja un scientifique avec ce matricule aloirs l'afficher, proposer a nouveau d'entrer le matricule ou revenir au menu principale 
                                    else
                                    {
                                        Console.WriteLine("Il y a déja un scientifique avec ce matricule ");
                                    }
                                    Console.WriteLine("Re crééer un scientifique (S)");
                                    Console.WriteLine("Menu principale (M)");
                                    Console.WriteLine("Votre choix ---->");
                                    choix = Console.ReadLine();
                                    if (choix == "S")
                                    {
                                        recommencer = true;
                                    }
                                    else
                                    {
                                        ConnexionUtilisateur(id);
                                    }
                                } while (recommencer == true);

                            }
                            else if (choix == "Q")
                                {
                                    ConnexionUtilisateur(id);
                                }
                            break;

                            // Si le choix est "GO"
                        case "GO":
                            // Demander quel objet à modifier
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
                                // Je n'ai pas réussi à faire cette étape
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
                            // Si l'utilisateur choisit "GM"
                        case "GM":
                            bool grosseBoucle = true;
                            do
                            {
                                //Demander quelles missions modifier
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
                                    // Si l'utilisateur veut ajouter une mission demander le matricule du scientifique auquel la mission appartient
                                    case "AM":
                                        bool boucle = true;
                                        do
                                        {
                                            Console.Write("Numéro du scientifique pour l'ajout de la mission : ");
                                            string matricule = Console.ReadLine();
                                            if (dictionnaire.ContainsKey(matricule) == true)
                                            {
                                                // demander tous les informations de la mission
                                                Console.Write("Nom de la mission : ");
                                                nom = Console.ReadLine();
                                                Console.Write("Numéro de référence de la mission");
                                                string numeroMission1 = Console.ReadLine();
                                                Console.Write("Catégorie de la mission : ");
                                                string categorie = Console.ReadLine();
                                                Console.Write("Vaisseau spatial  : ");
                                                string vaisseau = Console.ReadLine();
                                                Console.Write("Durée estimée : ");
                                                string duree = Console.ReadLine();
                                                Console.Write("Date de lancement : ");
                                                string date = Console.ReadLine();
                                                // Crééer la mission et l'ajout au fichier 
                                                Mission mission = new Mission(numeroMission1, nom, DateTime.Parse(date), int.Parse(duree), vaisseau, categorie, matricule);
                                                dictionnaireNouveauMission.Add(matricule,mission);
                                                SauvegarderMission(mission);
                                                boucle = false;
                                            }
                                            // Si le matricule n'est pas bon alors l'indiquer et propser de le rentrer a nouveau ou de revenir au menu
                                            else
                                            {
                                                Console.WriteLine("Il n'y a pas de scientifique qui a ce matricule");
                                                Console.WriteLine("Entrer de nouveau une mission (E) ");
                                                Console.WriteLine("Revenir au menu (M)");
                                                Console.Write("Votre choix ----> ");
                                                choix = Console.ReadLine();
                                                if (choix == "E")
                                                {

                                                }
                                                else
                                                {
                                                    boucle = false;
                                                }

                                            }
                                        } while (boucle == true);
                                        break;
                                    case "SU":
                                        // Si il faut suppirmer la fonction alors demandé le numéro de la fonction a suprimmer
                                        Console.WriteLine("Numero de la mission a suprimmer : ");
                                        string numeroMission = Console.ReadLine();
                                        foreach (var mission in dictionnaireMission.Values)
                                        {
                                            if (mission.NomMission == numeroMission)
                                            {
                                                // Suprimmer la fonction
                                                string lalal = dictionnaireMission[mission.NomMission].Matricule;
                                                dictionnaireMission.Remove(lalal);
                                                Console.WriteLine("Mission suprimmé de la base de donnés");
                                            }
                                        }
                                        break;
                                    case "Q":
                                        // revevenir au menu
                                        ConnexionUtilisateur(id);
                                        break;
                                    default:
                                        break;
                                }
                            } while (grosseBoucle == true);
                            break;
                            // Si le choix est "GI"
                        case "GI":
                            do
                            {
                                // menu pour gérer les instruments
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
                                    // Si le choix est un instrument d'observation
                                    case "IO":
                                        bool refaire = true;
                                        do
                                        {
                                            // demander le numéro de référence de la mission 
                                            Console.Write("Numéro de référence de la mission : ");
                                            string numeroReference = Console.ReadLine();
                                            if (dictionnaireInstruments.ContainsKey(numeroReference) == true)
                                            {
                                                // Toutes les informations pour un instrument
                                                Console.Write("Id instrument : ");
                                                string idInstrument = Console.ReadLine();
                                                Console.Write("Nom instrument : ");
                                                string nomInstrument = Console.ReadLine();
                                                Console.Write("Champs de vision : ");
                                                string champsVision = Console.ReadLine();
                                                Console.Write("Longueur de l'onde : ");
                                                string longueurOnde = Console.ReadLine();
                                                List<string> list = new List<string>();
                                                list.Add(nomInstrument);
                                                list.Add(champsVision);
                                                list.Add(longueurOnde);
                                                // Ajouter l'instrument au dictionnaire
                                                dictionnaireInstruments.Add(numeroReference, list);
                                                dictionnaireNouveauxInstruments.Add(numeroReference, list);
                                                // Demander de rentrer un autre instrument ou de revenir au menu
                                                Console.WriteLine();
                                                Console.WriteLine("Entrer un autre instrument (E)");
                                                Console.WriteLine("Revenir au menu (M)");
                                                Console.Write("Votre choix ----> ");
                                                choix = Console.ReadLine();
                                                if (choix == "E")
                                                {
                                                    refaire = true;
                                                }
                                                else
                                                {
                                                    refaire = false;
                                                }
                                            }
                                            // Si aucune mission à le numéro de référence alors l'indiquer et proposer de re rentrer le numéro ou revenir au menu
                                            else
                                            {
                                                Console.WriteLine("Aucune mission a ce numéro de référence");
                                                Console.WriteLine("Entrer de nouveau le numéro (E)");
                                                Console.WriteLine("Revenir au menu (M)");
                                                choix = Console.ReadLine();
                                                if (choix == "E")
                                                {

                                                }
                                                else
                                                {
                                                    refaire = false;
                                                }
                                            }
                                        } while (refaire == true);
                                        break;
                                        // Si le choix est insturment d'analyse
                                    case "IA":
                                        bool boucle = true;
                                        do
                                        {
                                            // Demander le numéro de référence de la mission
                                            Console.Write("Numéro de référence de la mission : ");
                                            string numeroReference = Console.ReadLine();
                                            if (dictionnaireInstruments.ContainsKey(numeroReference) == true)
                                            {
                                                // demander les information pour l'instrument
                                                Console.Write("Id instrument : ");
                                                string idInstrument = Console.ReadLine();
                                                Console.Write("Nom instrument : ");
                                                string nomInstrument = Console.ReadLine();
                                                Console.Write("Type de signale : ");
                                                string typeSignal = Console.ReadLine();

                                                List<string> list = new List<string>();
                                                list.Add(nomInstrument);
                                                list.Add(typeSignal);
                                                // Ajouter l'instrument au dictionnaire
                                                dictionnaireInstruments.Add(numeroReference, list);
                                                dictionnaireNouveauxInstruments.Add(numeroReference, list);

                                                // Demander de re créer un instrument ou revenir au menu principslr
                                                Console.WriteLine();
                                                Console.WriteLine("Entrer un autre instrument (E)");
                                                Console.WriteLine("Revenir au menu (M)");
                                                Console.Write("Votre choix ----> ");
                                                choix = Console.ReadLine();
                                                if (choix == "E")
                                                {
                                                    boucle = true;
                                                }
                                                else
                                                {
                                                    boucle = false;
                                                }
                                            }
                                            // Si le numréro de référence n'est pas une mission alors l'indiqué et proposer de rentrer a nouveau le numéro ou même revenir au menu
                                            else
                                            {
                                                Console.WriteLine("Aucune mission a ce numéro de référence");
                                                Console.WriteLine("Entrer de nouveau le numéro (E)");
                                                Console.WriteLine("Revenir au menu (M)");
                                                choix = Console.ReadLine();
                                                if (choix == "E")
                                                {

                                                }
                                                else
                                                {
                                                    boucle = false;
                                                }
                                            }
                                        } while (boucle == true);
                                        break;
                                    case "Q":
                                        // Revenir au menu principale
                                        ConnexionUtilisateur(id);
                                        break;
                                    default:
                                        break;
                                }
                            } while (true);
                            break;
                            // Si le choix est "SI"
                        case "SI":
                            // Je ne suis pas capable de le faire encore
                            string categorie1 = "";
                            string categorie2 = "";
                            Console.WriteLine("Catégorie pour faire la simulation : ");
                            recommencer = true;
                            do {
                                Console.Write("Catégorie 1 (Étoile,Satelitte,Planète) : ");
                                categorie1 = Console.ReadLine();
                                if (categorie1 == "Planète" || categorie1 == "Satelitte" || categorie1 == "Étoile")
                                {
                                    recommencer = false;
                                }
                                else
                                {
                                    Console.WriteLine("Catégorie invalide !");
                                    Console.WriteLine("Entrer de nouveau la catégorie ou revenez au menu (M)");
                                    Console.Write("Votre choix --->");
                                    categorie1 = Console.ReadLine();
                                    if (categorie1 == "M")
                                    {
                                        ConnexionUtilisateur(id);
                                    }
                                    else
                                    {
                                        recommencer = true;
                                    }
                                }
                            }while(recommencer==true);
                            recommencer = true;
                            do
                            {
                                Console.Write("Catégorie 2 (Étoile,Satelitte,Planète) : ");
                                categorie2 = Console.ReadLine();
                                if (categorie2 == "Planète" || categorie2 == "Satelitte" || categorie2 == "Étoile")
                                {
                                    recommencer = false;
                                }
                                else
                                {
                                    Console.WriteLine("Catégorie invalide !");
                                    Console.WriteLine("Entrer de nouveau la catégorie ou revenez au menu (M)");
                                    Console.Write("Votre choix --->");
                                    categorie2 = Console.ReadLine();
                                    if (categorie2 == "M")
                                    {
                                        ConnexionUtilisateur(id);
                                    }
                                    else
                                    {
                                        recommencer = true;
                                    }
                                }
                            } while (recommencer == true);
                            double compteur1 = 0;
                            double compteur2 = 0;
                            foreach (var item in Systeme.dictionnaireMission.Values)
                            {
                                if (item.Destination != null)
                                {
                                    if (categorie1 == "Planète" && item.Destination is Planete)
                                    {
                                        compteur1++;
                                    }
                                    else if (categorie1 == "Satellite" && item.Destination is Satellite)
                                    {
                                        compteur1++;
                                    }
                                    else if (categorie1 == "Étoile" && item.Destination is Etoile)
                                    {
                                        compteur1++;
                                    }

                                    if (categorie2 == "Planète" && item.Destination is Planete)
                                    {
                                        compteur2++;
                                    }
                                    else if (categorie2 == "Satellite" && item.Destination is Satellite)
                                    {
                                        compteur2++;
                                    }
                                    else if (categorie2 == "Étoile" && item.Destination is Etoile)
                                    {
                                        compteur2++;
                                    }
                                }
                            }
                            // Ne fonctionne pas 
                            Console.WriteLine($"Il y a {compteur1} missions pour la catégorie {categorie1}");
                            Console.WriteLine($"Il y a {compteur2} missions pour la catégorie {categorie2}");
                            Console.WriteLine();
                            Console.WriteLine("Nom de l'objet 1 : ");
                            string objet1 = Console.ReadLine();
                            Console.WriteLine("Nom de l'objet 2 : ");
                            string objet2 = Console.ReadLine();
                            Console.WriteLine("masse de l'objet centrale : ");
                            string masseObjetCentrale = Console.ReadLine();
                            Console.WriteLine("Distance entre les deux distances : ");
                            string distance = Console.ReadLine();
                            break;
                        case "Q":
                            Console.WriteLine("Toutes les données ont bien été enregistrées dans les fichiers");
                            break;
                        default:
                            break;
                    }

                }
                // Si l'id est un id validé pour un observateur 
                else
                {
                    // crééer l'observateur, afficher les infos ainsi que afficher le menu observateur
                    Observateur observateur = new Observateur(id,nom, prenom, DateTime.Parse(valeurs[1]));
                    observateur.AfficherInfo();
                    Console.WriteLine();
                    Console.WriteLine("Recherche d'une mission (RM) : ");
                    Console.WriteLine("Liste des missions (LM) : ");
                    Console.WriteLine("Recherche un scientifique (RS) : ");
                    Console.WriteLine("Liste des scientifiques (LS) : ");
                    Console.WriteLine("Liste des instruments de mesure (LI) : ");
                    Console.WriteLine();
                    Console.WriteLine("Quitter (Q)");
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
                    // Switch pour les différents choix qui s'offrent à l'utilisateur
                    switch (mo)
                    {
                        // Si le choix est "RM"
                        case "RM":
                            // Demander le numéro de référence 
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
                            do
                            {
                                // SI il n'est pas une mission alors l'indiquer et proposer de entrer à nouveau le numéro ou plutot de quitter
                                if (dictionnaireMission.ContainsKey(numeroReference) == false)
                                {
                                    Console.WriteLine("Il n'y a pas de numéro de mission correspodant");
                                    Console.Write("Rentrer à nouveau le numéro de référence ou (Q) pour quitter : ");
                                    numeroReference = Console.ReadLine();
                                    // revenir au menu
                                    if (numeroReference == "Q")
                                    {
                                        ConnexionUtilisateur(id);
                                    }
                                }
                                else
                                {
                                    // Si le numéro est validé alors afficher les informations de la mission
                                    Mission valeurs1 = dictionnaireMission[numeroReference];
                                    //Mission mission = new Mission(numeroReference, valeurs1[0], DateTime.Parse(valeurs1[5]), int.Parse(valeurs1[4]), valeurs1[3], valeurs1[2]);
                                    valeurs1.AfficherInfo();
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.Write("Revenir au menu princiaple : ");
                                    string revenir = Console.ReadLine();
                                    ConnexionUtilisateur(id);

                                }
                            }while(true);
                            // Si le choix est "LM"
                        case "LM":
                            // créer une liste
                            List<int> list = new List<int>();
                            // Foreach pour passer parmi toutes les valeurs du dictionnaire
                            foreach (var valeur in dictionnaireMission.Values)
                            {
                                //string dureeString = valeur[4];
                                //int duree = int.Parse(dureeString);



                                // Mettre la durée dans une liste
                                int duree = valeur.DureeEstimee;
                                list.Add(duree);

                            }
                            //Trier la liste
                            list.Sort();
                            List<List<string>> missionsTri = new List<List<string>>();
                            // For affin d'afficher toutes les missions
                            for (int i = 0; i < dictionnaireMission.Count; i++)
                            {
                                // foreach pour l'entièreté des clés
                                foreach (var item in dictionnaireMission.Keys)
                                {
                                    //List<string> a = new List<string>();
                                    //a = dictionnaireMission[item];

                                    // mission de la clé
                                    Mission mission = dictionnaireMission[item];
                                    int duree = mission.DureeEstimee;
                                    if (list[i] == duree)
                                    {
                                        //missionsTri.Add(a);
                                        //Mission mission = new Mission(item, a[0], DateTime.Parse(a[5]), duree, a[3], a[2]);
                                        //mission.AfficherInfo();


                                        // Afficher les missions en orde croissant de la duré
                                        mission.AfficherInfo();
                                    }
                                }
                            }

                            break;
                            // SI le choix est "RS"
                        case "RS":
                            // Demander le matricule 
                            Console.WriteLine("Numéro matricule du scientifique : ");
                            string matricule = Console.ReadLine();
                            // Si le matricule est valide alors affiché les informations
                            if (dictionnaire.ContainsKey(matricule))
                            {
                                Console.WriteLine($"\nNom et prénom : {dictionnaire[matricule][0]}");
                                Console.WriteLine($"Date de naissance : {dictionnaire[matricule][1]}");
                                Console.WriteLine("Adresse : Adresse pas fournie dans les fichiers");
                                Console.Write("Missions affectées : ");

                                int j = 0;
                                // Toutes les missions qui sont affecté à ce scientifique
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
                                    Console.Write("Aucune mission affectée");
                                }

                            }
                            // Si le scientifique n'exite pas alors l'indiquer et revenir au menu
                            else
                            {
                                Console.WriteLine("Le scientifique n'existe pas");
                                Console.Write("Entrer n'importe quelle touche pour revenir au menu et appuyer sur entrer");
                                Console.ReadLine();
                                ConnexionUtilisateur(id);
                            }
                            Console.WriteLine();
                            break;
                            // Si le choix est "LS"
                        case "LS":
                            // Afficher la liste des scientifiques avec leurs attributs 
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
                            // Si le choix est "LI"
                            recommencer = true;
                            
                            // Demander le numéro de référence 
                            Console.WriteLine("Numéro de référence : ");
                            numeroReference = Console.ReadLine();
                            
                            do
                            {
                                // Si il est false l'indiquer et appuyer sur une touche pour revenir au menu principale
                                if (dictionnaireInstruments.ContainsKey(numeroReference) == false)
                                {
                                    Console.WriteLine("Il n'y a pas de numéro de mission correspodant");
                                    Console.WriteLine();
                                    Console.Write("Rentrer de nouveau le numéro de référence ou (Q) pour quitter: ");
                                    numeroReference = Console.ReadLine();
                                    if (numeroReference == "Q")
                                    {
                                        ConnexionUtilisateur(id);
                                    }

                                }
                                // Si il est valide alors afficher l'instrument
                                else
                                {
                                    List<string> valeurs1 = dictionnaireInstruments[numeroReference];
                                    // try pour obtenir l'erreur ArgumentOutOfRangeException si la valeur1[2] n'est pas dans la liste
                                    try
                                    {
                                        if (valeurs1[2] != "")
                                        {
                                            InstrumentObservation instrumentObservation2 = new InstrumentObservation(numeroReference, valeurs1[0], valeurs1[1], int.Parse(valeurs1[2]));

                                            Console.WriteLine();
                                            Console.WriteLine("Info : ");
                                            instrumentObservation2.AfficherInfo();
                                        }
                                    }
                                    // prendre l'exception et afficher l'instrument d'analyse
                                    catch(ArgumentOutOfRangeException)
                                    {
                                        InstrumentAnalyse instrumentAnalyse2 = new InstrumentAnalyse(numeroReference, valeurs1[0], valeurs1[1]);
                                        instrumentAnalyse2.AfficherInfo();
                                    }
                                    
                                    // Revenir au menu pricipale en appuyant sur une touche
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.Write("Revenir au menu princiaple : ( appuyer sur une touche et faite enter )");
                                    string revenir = Console.ReadLine();
                                    ConnexionUtilisateur(id);
                                }
                            }while (recommencer == true) ;
                            break;
                        case "Q":
                            break;
                        default:

                            break;
                    }
                }
            }
        }
        public double GetDonneesCalcul()
        {
            return 3.0;
        }
    }
}

       

