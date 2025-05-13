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
        public Observateur(string idObservateur,string nom,string prenom,DateTime dateNaissance,string adresse,Systeme systeme):base(nom,prenom,dateNaissance,adresse,systeme)
        {
            IdObservateur = idObservateur;
        }
        public override void AfficherInfo()
        {
            base.AfficherInfo();
            Console.WriteLine($"Id observateur : {IdObservateur}");
        }
    }
}
