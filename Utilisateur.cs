using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Finale
{
    internal class Utilisateur
    {
        public string Nom {  get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public Systeme Systemes { get; set; }
        
        public Utilisateur(string nom,string prenom,DateTime dateNaissance)
        {
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
        }
        
        public virtual void AfficherInfo()
        {
            Console.WriteLine($"Prenom : {Prenom}");
            Console.WriteLine($"Nom : {Nom}");
            Console.WriteLine($"date de naissance : {DateNaissance}");
        }
    }
}
