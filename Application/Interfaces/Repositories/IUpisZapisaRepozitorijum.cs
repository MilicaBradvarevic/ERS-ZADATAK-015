using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Interfaces.Repositories
{
    public interface IUpisZapisaRepozitorijum
    {
        void Dodaj(Zapis zapis);
        void Azuriraj(Zapis zapis);
    }
}
