using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Stanowisko
    {
        public Stanowisko()
        {
            Pracownik = new HashSet<Pracownik>();
        }

        public int IdStanowisko { get; set; }
        public string Nazwa { get; set; }

        public ICollection<Pracownik> Pracownik { get; set; }
    }
}
