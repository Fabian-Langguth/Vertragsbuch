using System;
using System.Collections.Generic;
using System.Text;

namespace Vertragsbuch.App.Models
{
    public class Vertrag
    {
        public string Name { get; set; } = string.Empty;
        public string Anbieter { get; set; } = string.Empty;
        public decimal MonatlicheKosten { get; set; }

    }
}
