using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class StudijskiAlbum:Zapis
    {
        public string Izvodjac { get; set; } = string.Empty;
        public int IzdanjeGodina { get; set; }
        public string IzdavackaKuca { get; set; } = string.Empty;
    }
}
