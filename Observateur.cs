using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Finale
{
    internal class Observateur:Utilisateur
    {
        public string IdObservateur {  get; set; }
        public Observateur(string idObservateur,string nom,string prenom,DateTime dateNaissance,string adresse):base(nom,prenom,dateNaissance,adresse)
        {
            IdObservateur = idObservateur;
        }
        public int DemanderId()
        {
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
            Console.WriteLine("                         Simulation des \n                         missions spatiales");
            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
            Console.WriteLine();
            Console.WriteLine("Option Observateur : ");
            Console.Write("Veuillez fournir le numéro d'identification ----> ");
            try
            {
                string id1 = Console.ReadLine();
                int id = Convert.ToInt32(id1);
            }
            catch
            {
                int id = Convert.ToInt32(id1);
            }

            return id;
        }
        public override void AfficherInfo()
        {
            Console.WriteLine("Profil d'observateur : ");
            Console.WriteLine();
            Console.WriteLine($"Id observateur : {IdObservateur}");
            base.AfficherInfo();
            
        }

    }
}
