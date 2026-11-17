using Application.Interfaces.Repositories;
using Domain.Models;
using Shared;

namespace Database.Repositories;

// TODO: implementirati skladištenje u memoriji.
public sealed class InMemoryZapisiRepozitorijum : IZapisiRepozitorijum
{
    private readonly List<Zapis> _zapisi = new();
    public Result Sacuvaj(Zapis zapis) {
       if(zapis is null)
        {
            return Result.Failure("zapis_null", "Zapis ne sme biti null.");
        }
        var postojeci = _zapisi.FirstOrDefault(z => z.Id == zapis.Id);
        if (postojeci != null)
        {
           _zapisi.Remove(postojeci);
        }
        _zapisi.Add(zapis);
        return Result.Success();
    }

    public Result<Zapis> Pronadji(Guid id)
    {
        var zapis = _zapisi.FirstOrDefault(z => z.Id == id);
        if (zapis is null)
        {
            return Result<Zapis>.Failure("zapis.nije.pronadjen", "Zapis sa datim ID-jem ne postoji.");
        }
        return Result<Zapis>.Success(zapis);
    }

    public Result<IReadOnlyList<Zapis>> Svi()
    {
        return Result<IReadOnlyList<Zapis>>.Success(_zapisi.AsReadOnly());
    }

    public Result Obrisi(Guid id)
    {
        var zapis = _zapisi.FirstOrDefault(z => z.Id == id);
        if (zapis is null)
        {
            return Result.Failure("zapis.nije.pronadjen", "Zapis sa datim ID-jem ne postoji.");
        }
        _zapisi.Remove(zapis);
        return Result.Success();
    }
}
