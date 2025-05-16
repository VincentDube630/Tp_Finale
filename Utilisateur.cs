using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tp_Finale
{
    internal class Utilisateur
    {
        // Création des attributs 
        public string Nom {  get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public Systeme Systemes { get; set; }
        
        // Constructeur pour les classes fille
        public Utilisateur(string nom,string prenom,DateTime dateNaissance)
        {
            Nom = nom;
            Prenom = prenom;
            DateNaissance = dateNaissance;
        }
        
        // foncction virtual pour que les classes filles puissent changer la fonction
        public virtual void AfficherInfo()
        {
            Console.WriteLine($"Prenom : {Prenom}");
            Console.WriteLine($"Nom : {Nom}");
            Console.WriteLine($"date de naissance : {DateNaissance}");
        }
    }
}
