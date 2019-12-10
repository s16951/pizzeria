using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class RodzajPlatnosci
    {
        public RodzajPlatnosci()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdRodzajPlatnosci { get; set; }
        public string Nazwa { get; set; }

        public ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
