using Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IZapisServis
    {
        Result<Zapis> DodajStudijskiAlbum(StudijskiAlbum album);
        Result<Zapis> DodajKoncertniAlbum(KoncertniAlbum album);

        IEnumerable<Zapis> VratiSveZapise();
        IEnumerable<Zapis> PronadjiPoIzvodjacu(string izvodjac);

        Result DodajUOmiLjene(Guid id);

        Result UkloniIzOmiljenih(Guid id);

    }
}
