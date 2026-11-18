using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class StudijskiAlbum:Zapis
    {
        public int IzdanjeGodina { get; set; }
        public string IzdavackaKuca { get; set; } = string.Empty;
    }
}
