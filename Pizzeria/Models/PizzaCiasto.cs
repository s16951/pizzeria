using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class PizzaCiasto
    {
        public int IdPizza { get; set; }
        public int IdCiasto { get; set; }

        public Ciasto IdCiastoNavigation { get; set; }
        public Pizza IdPizzaNavigation { get; set; }
    }
}
