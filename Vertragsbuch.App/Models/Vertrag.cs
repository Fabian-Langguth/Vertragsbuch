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
        public DateTime Vertragsbeginn { get; set; }
        public int MindestlaufzeitMonate { get; set; }
        public int KuendigungsfristMonate { get; set; }

        public DateTime Vertragsende
        {
            get
            {
                return Vertragsbeginn.AddMonths(MindestlaufzeitMonate);
            }
        }

        public DateTime KuendigenBis
        {
            get
            {
                return Vertragsende.AddMonths(-KuendigungsfristMonate);
            }
        }
    }
}
