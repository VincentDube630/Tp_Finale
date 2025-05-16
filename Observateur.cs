using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Finale
{
    internal class Observateur:Utilisateur// Classe fille de Utilisateur
    {
        // Attribut popre à la classe observateur
        public string IdObservateur {  get; set; }

        // Constructeur pour récuperer les attributs de la classe mère et le id
        public Observateur(string idObservateur,string nom,string prenom,DateTime dateNaissance ):base(nom,prenom,dateNaissance)
        {
            IdObservateur = idObservateur;
        }
        // Redéfénir la classe AfficherInfo() pour ajouter les différentes parties
        public override void AfficherInfo()
        {
            Console.WriteLine("Profil d'observateur : ");
            Console.WriteLine();
            Console.WriteLine($"Id observateur : {IdObservateur}");
            base.AfficherInfo();
            
        }
      

    }
}
