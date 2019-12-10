using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class PizzaSkladnik
    {
        public int IdPizza { get; set; }
        public int IdSkladnik { get; set; }

        public Pizza IdPizzaNavigation { get; set; }
        public Skladnik IdSkladnikNavigation { get; set; }
    }
}
