namespace Tp_Finale
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Systeme systeme = new Systeme();
            systeme.ChargerDonnees();
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
            Console.WriteLine("                         Simulation des \n                         missions spatiales");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
            Console.WriteLine();
            Console.WriteLine("Choissisez une option : ");
            Console.WriteLine("Observateur (O)");
            Console.WriteLine("Scientifique (S)");
            Console.WriteLine("Quitter (Q)");
            Console.WriteLine();
            string choix = Console.ReadLine();
            switch (choix)
            {
                case "O":
                    Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
                    Console.WriteLine("                         Simulation des \n                         missions spatiales");
                    Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
                    Console.WriteLine();
                    Console.WriteLine("Option Observateur : ");
                    Console.Write("Veuillez fournir le numéro d'identification ----> ");
                    string id1 = Console.ReadLine();
                    systeme.ConnexionUtilisateur(id1);
                    break;
                case "S":
                    break;
                case "Q":
                    Environment.ExitCode = 0;
                    break;
                default:
                    Console.WriteLine("Choix invalide!");
                    break;
            }
        }
    }
}
