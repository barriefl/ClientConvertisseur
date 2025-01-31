using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace WSConvertisseur.Models
{
    public class Devise
    {
        private int id;
        private string? nomDevise;
        private double taux;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string? NomDevise
        {
            get
            {
                return nomDevise;
            }

            set
            {
                nomDevise = value;
            }
        }

        public double Taux
        {
            get
            {
                return this.taux;
            }

            set
            {
                this.taux = value;
            }
        }

        public Devise()
        {
        }

        /// <summary>
        /// Create a single currency.
        /// </summary>
        /// <returns>Devise object</returns>
        /// <param name="id">The id of the currency</param>
        /// <param name="nomDevise">The name of the currency</param>
        /// <param name="taux">The rate of the currency</param>
        public Devise(int id, string? nomDevise, double taux)
        {
            this.Id = id;
            this.NomDevise = nomDevise;
            this.Taux = taux;
        }

        public override bool Equals(object? obj)
        {
            return obj is Devise devise &&
                this.Id == devise.Id &&
                this.NomDevise == devise.NomDevise &&
                this.Taux == devise.Taux;
        }
    }
}
