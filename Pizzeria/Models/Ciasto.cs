using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Ciasto
    {
        public Ciasto()
        {
            PizzaCiasto = new HashSet<PizzaCiasto>();
        }

        public int IdCiasto { get; set; }
        public string Nazwa { get; set; }
        public float Cena { get; set; }

        public ICollection<PizzaCiasto> PizzaCiasto { get; set; }
    }
}
