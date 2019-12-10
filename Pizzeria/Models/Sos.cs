using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Sos
    {
        public Sos()
        {
            SosZamowienie = new HashSet<SosZamowienie>();
        }

        public int IdSos { get; set; }
        public string Nazwa { get; set; }
        public float Cena { get; set; }

        public ICollection<SosZamowienie> SosZamowienie { get; set; }
    }
}
