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
        
        public override void AfficherInfo()
        {
            Console.WriteLine("Profil d'observateur : ");
            Console.WriteLine();
            Console.WriteLine($"Id observateur : {IdObservateur}");
            base.AfficherInfo();
            
        }
        public string Choix()
        {
            Console.WriteLine("Recherche d'une mission (RM) : ");
            Console.WriteLine("Liste des missions (LM) : ");
            Console.WriteLine("Recherche un scientifique (RS) : ");
            Console.WriteLine("Liste des scientifiques (LS) : ");
            Console.WriteLine("Liste des instruments de mesure (LI) : ");
            string choix = "";
            bool recommencer = true;
            do
            {
                try
                {
                    choix = Console.ReadLine();
                    recommencer = true;
                }
                catch (FormatException)
                {
                    recommencer = false;
                    Console.WriteLine("Erreur, ce n'est pas une chaine de caractère");
                }
            } while (!recommencer);       
            return Choix();
           
        }

    }
}
