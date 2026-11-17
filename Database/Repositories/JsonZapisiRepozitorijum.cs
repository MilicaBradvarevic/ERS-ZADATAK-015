using Application.Interfaces.Repositories;
using Domain.Models;
using Shared;
using System.Text.Json;

namespace Database.Repositories 
{ 

// TODO: implementirati trajno cuvanje u JSON datoteci.
// Nacrtati/odabrati nacin serijalizacije polimorfnih modela konkretnog zadatka.
public sealed class JsonZapisiRepozitorijum : IZapisiRepozitorijum
{
    private readonly string _putanja;
    private readonly JsonSerializerOptions _jsonOptions;

    public JsonZapisiRepozitorijum(string putanja = "zapisi.json")
    {
        _putanja = putanja;
        _jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
            IncludeFields = true,
        };
    }

    private List<Zapis> UcitajIzFajla()
    {
        if (!File.Exists(_putanja))
        {
            return new List<Zapis>();
        }
        try
        {
            string json = File.ReadAllText(_putanja);
            var zapisi = JsonSerializer.Deserialize<List<Zapis>>(json, _jsonOptions);
            return zapisi ?? new List<Zapis>();

        }
        catch
        {

            return new List<Zapis>();
        }
    }

    private void SacuvajUFajl(List<Zapis> zapisi)
    {
        string json = JsonSerializer.Serialize(zapisi, _jsonOptions);
        File.WriteAllText(_putanja, json);
    }
    public Result Sacuvaj(Zapis zapis)
    {
        var zapisi = UcitajIzFajla();
        if (zapisi.Any(z => z.Id == zapis.Id))
        {
            return Result.Failure("zapisi.postoji", "Zapis sa ID-jem već postoji.");
        }
        zapisi.Add(zapis);
        SacuvajUFajl(zapisi);
        return Result.Success();
    }

    public Result<Zapis> Pronadji(Guid id)
    {
        var zapisi = UcitajIzFajla();
        var zapis = zapisi.FirstOrDefault(z => z.Id == id);
        if (zapis == null)
        {
            return Result<Zapis>.Failure("zapisi.nije.pronadjen", "Zapis sa datim ID-jem ne postoji.");
        }
        return Result<Zapis>.Success(zapis);
    }

    public Result<IReadOnlyList<Zapis>> Svi()
    {
        var zapisi = UcitajIzFajla();
        return Result<IReadOnlyList<Zapis>>.Success(zapisi.AsReadOnly());
    }

    public Result Obrisi(Guid id)
    {
        var zapisi = UcitajIzFajla();
        var zapis = zapisi.FirstOrDefault(z => z.Id == id);
        if (zapis == null)
        {
            return Result.Failure("zapisi.nije.pronadjen", "Zapis sa datim ID-jem ne postoji.");
        }
        zapisi.Remove(zapis);
        SacuvajUFajl(zapisi);
        return Result.Success();
    }
   }
}
