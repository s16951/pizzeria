using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Napoj
    {
        public Napoj()
        {
            NapojZamowienie = new HashSet<NapojZamowienie>();
        }

        public int IdNapoj { get; set; }
        public string IdNazwa { get; set; }
        public float Cena { get; set; }

        public ICollection<NapojZamowienie> NapojZamowienie { get; set; }
    }
}
