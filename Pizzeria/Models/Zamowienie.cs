using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Zamowienie
    {
        public Zamowienie()
        {
            NapojZamowienie = new HashSet<NapojZamowienie>();
            PracownikZamowienie = new HashSet<PracownikZamowienie>();
            SosZamowienie = new HashSet<SosZamowienie>();
            ZamowieniePizza = new HashSet<ZamowieniePizza>();
        }

        public int IdZamowienie { get; set; }
        public int RodzajPlatnosci { get; set; }
        public float Cena { get; set; }
        public DateTime Data { get; set; }
        public int DaneWysylkiIdDane { get; set; }
        public int IdPromocja { get; set; }

        public DaneWysylki DaneWysylkiIdDaneNavigation { get; set; }
        public Promocja IdPromocjaNavigation { get; set; }
        public RodzajPlatnosci RodzajPlatnosciNavigation { get; set; }
        public ICollection<NapojZamowienie> NapojZamowienie { get; set; }
        public ICollection<PracownikZamowienie> PracownikZamowienie { get; set; }
        public ICollection<SosZamowienie> SosZamowienie { get; set; }
        public ICollection<ZamowieniePizza> ZamowieniePizza { get; set; }
    }
}
