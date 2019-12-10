using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class ZamowieniePizza
    {
        public int IdZamowienie { get; set; }
        public int IdPizza { get; set; }

        public Pizza IdPizzaNavigation { get; set; }
        public Zamowienie IdZamowienieNavigation { get; set; }
    }
}
