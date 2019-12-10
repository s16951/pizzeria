using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Pracownik
    {
        public Pracownik()
        {
            PracownikZamowienie = new HashSet<PracownikZamowienie>();
        }

        public int IdPracownik { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int IdStanowisko { get; set; }

        public Stanowisko IdStanowiskoNavigation { get; set; }
        public ICollection<PracownikZamowienie> PracownikZamowienie { get; set; }
    }
}
