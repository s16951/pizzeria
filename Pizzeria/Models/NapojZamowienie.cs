﻿using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class NapojZamowienie
    {
        public int IdZamowienie { get; set; }
        public int IdNapoj { get; set; }

        public Napoj IdNapojNavigation { get; set; }
        public Zamowienie IdZamowienieNavigation { get; set; }
    }
}
