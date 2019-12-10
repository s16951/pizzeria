using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Promocja
    {
        public Promocja()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdPromocja { get; set; }
        public string Opis { get; set; }

        public ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
