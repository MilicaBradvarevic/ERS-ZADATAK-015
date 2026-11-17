using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class KoncertniAlbum:Zapis
    {
        public string Izvodjac { get; set; } = string.Empty;
        public string MestoOdrzavanja { get; set; } = string.Empty;
        public int GodinaKoncerta { get; set; }
    }
}
