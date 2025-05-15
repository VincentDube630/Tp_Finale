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
        public Observateur(string idObservateur,string nom,string prenom,DateTime dateNaissance ):base(nom,prenom,dateNaissance)
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
      

    }
}
