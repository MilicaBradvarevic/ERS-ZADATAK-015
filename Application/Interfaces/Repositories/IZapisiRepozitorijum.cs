using Domain.Models;
using Shared;
using System.Collections.Generic;

namespace Application.Interfaces.Repositories;

// Polazni ugovor: student ga menja ili razdvaja prema operacijama svog zadatka.
public interface IZapisiRepozitorijum
{
    Result Sacuvaj(Zapis zapis);
    Result<Zapis> Pronadji(Guid id);
    Result<IReadOnlyList<Zapis>> Svi();
    Result Obrisi(Guid id);
}
