using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            PizzaCiasto = new HashSet<PizzaCiasto>();
            PizzaSkladnik = new HashSet<PizzaSkladnik>();
            ZamowieniePizza = new HashSet<ZamowieniePizza>();
        }

        public int IdPizza { get; set; }
        public string Nazwa { get; set; }

        public ICollection<PizzaCiasto> PizzaCiasto { get; set; }
        public ICollection<PizzaSkladnik> PizzaSkladnik { get; set; }
        public ICollection<ZamowieniePizza> ZamowieniePizza { get; set; }
    }
}
