using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class SosZamowienie
    {
        public int IdZamowienie { get; set; }
        public int IdSos { get; set; }

        public Sos IdSosNavigation { get; set; }
        public Zamowienie IdZamowienieNavigation { get; set; }
    }
}
