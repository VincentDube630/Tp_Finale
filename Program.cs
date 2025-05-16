namespace Tp_Finale
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Charger les données 
            Systeme systeme = new Systeme();
            Systeme.ChargerDonnees();
            // Boucle pour refaire le menu
            do
            {
                // Afficher le menu
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
                Console.WriteLine("                         Simulation des \n                         missions spatiales");
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
                Console.WriteLine();
                Console.WriteLine("Choissisez une option : ");
                Console.WriteLine("Observateur (O)");
                Console.WriteLine("Scientifique (S)");
                Console.WriteLine("Quitter (Q)");
                Console.WriteLine();
                // Prendre dans le string choix la réponse
                string choix = Console.ReadLine();

                // Switch pour la réponse
                switch (choix)
                {
                    // Si la réponse est O alors demandé l'Id de l'observateur et l'envoyé à la fonction ConnexionUtilisateur();
                    case "O":
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
                        Console.WriteLine("                         Simulation des \n                         missions spatiales");
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
                        Console.WriteLine();
                        Console.WriteLine("Option observateur : ");
                        Console.Write("Veuillez fournir le numéro d'identification ----> ");
                        string id1 = Console.ReadLine();
                        systeme.ConnexionUtilisateur(id1);
                        break;
                    case "S":
                        // Si la réponse est S alors demandé le matricule du scientifique et l'envoyé à la fonction ConnexionUtilisateur();

                        Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
                        Console.WriteLine("                         Simulation des \n                         missions spatiales");
                        Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
                        Console.WriteLine();
                        Console.WriteLine("Option scientifique : ");
                        Console.Write("Veuillez fournir le numéro matricule ----> ");
                        string id2 = Console.ReadLine();
                        systeme.ConnexionUtilisateur(id2);
                        break;
                    case "Q":
                        // Si le choix est Q alors quitté le programme
                        Environment.ExitCode = 0;
                        break;
                    default:
                        // Si le choix est invalide alors le dire et recommencer la boucle
                        Console.WriteLine("Choix invalide!");
                        break;

                }
            } while (true);
        }
    }
}
