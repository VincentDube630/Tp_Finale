namespace Tp_Finale
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Systeme systeme = new Systeme();
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
            if (choix == "Q")
            {
                return;
            }
            if(choix == "O")
            {
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
                Console.WriteLine("                         Simulation des \n                         missions spatiales");
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
                Console.WriteLine();
                Console.WriteLine("Option Observateur : ");
                Console.Write("Veuillez fournir le numéro d'identification ----> ");
                string id1 = Console.ReadLine();
                int id = Convert.ToInt32(id1);
                Observateur observateur = new Observateur();
            }
            if(choix == "S")
            {

            }
        }
    }
}
