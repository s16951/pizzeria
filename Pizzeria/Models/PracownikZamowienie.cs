using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class PracownikZamowienie
    {
        public int IdPracownik { get; set; }
        public int IdZamowienie { get; set; }

        public Pracownik IdPracownikNavigation { get; set; }
        public Zamowienie IdZamowienieNavigation { get; set; }
    }
}
