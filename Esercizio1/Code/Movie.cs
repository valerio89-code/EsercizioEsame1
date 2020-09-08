using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio1.Code
{
    class Movie
    {
        public string Regista { get; set; }
        public string Titolo { get; set; }
        public int Anno { get; set; }
        public string Genere { get; set; }
        public double Prezzo { get; set; }

        /// <summary>
        /// Recupera in formato CSV l'istanza corrente
        /// </summary>
        /// <returns>Stringa contenente il formato CSV relativo all'istanza corrente</returns>
        public string GetCSVformat()
        {
            return $"{Regista};{Titolo};{Anno};{Genere};{Prezzo}";
        }
    }
}
