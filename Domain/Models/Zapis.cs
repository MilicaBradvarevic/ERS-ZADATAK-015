namespace Domain.Models;

// Zajednički osnovni tip iz koga se mogu izvesti modeli konkretnog zadatka.
// Polja, nazive i nasledjivanje prilagoditi dodeljenoj specifikaciji.
public abstract class Zapis
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Naziv { get; init; } = string.Empty;
    public string Opis { get; init; } = string.Empty;

    public string Izvodjac { get; init; } = string.Empty;

    public bool JeOmiljeno { get; set; } = false;
    public DateTimeOffset KreiranoUtc { get; init; } = DateTimeOffset.UtcNow;

    public virtual bool IsValid(out string errorMassage)
    {
        errorMassage = string.Empty;
        if (string.IsNullOrWhiteSpace(Naziv))
        {
            errorMassage = "Naziv zapisa ne sme biti prazan.";
            return false;

        }
        if (string.IsNullOrWhiteSpace(Opis))
        {
            errorMassage = "Opis zapisa ne sme biti prazan.";
            return false;
        }
        if (string.IsNullOrWhiteSpace(Izvodjac))
        {
            errorMassage = "Izvodjac je obavezan.";
            return false;
        }
        return true;
    }
}
