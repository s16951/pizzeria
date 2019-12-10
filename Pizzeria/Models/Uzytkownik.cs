using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Uzytkownik
    {
        public Uzytkownik()
        {
            DaneWysylki = new HashSet<DaneWysylki>();
        }

        public string IdUzytkownik { get; set; }
        public string Haslo { get; set; }

        public ICollection<DaneWysylki> DaneWysylki { get; set; }
    }
}
