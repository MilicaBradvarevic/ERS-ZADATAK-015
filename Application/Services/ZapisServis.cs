using System;
using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Models;
using Shared;

namespace Application.Services
{

    // Polazna struktura servisa; poslovne operacije nisu implementirane.
    public sealed class ZapisServis : IZapisServis
    {
        private readonly ICitanjeZapisaRepozitorijum _citanjeRepozitroijum;

        private readonly IUpisZapisaRepozitorijum _upisRepozitorijum;

        private readonly ILoggerServis _logger;

        public ZapisServis(ICitanjeZapisaRepozitorijum citanjeRepozitorijum, IUpisZapisaRepozitorijum upisRepozitorijum, ILoggerServis logger)
        {
            _citanjeRepozitroijum = citanjeRepozitorijum ?? throw new ArgumentNullException(nameof(citanjeRepozitorijum));
            _upisRepozitorijum = upisRepozitorijum ?? throw new ArgumentNullException(nameof(upisRepozitorijum));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Result<Zapis> DodajStudijskiAlbum(StudijskiAlbum album)
        {
            // TODO: definisati poslovna pravila i pozvati repozitorijum.
            // Primer pokazuje gde pripada use case, ne daje rešenje zadatka.
            if (album == null)
            {
                return Result<Zapis>.Failure("album.null", "Studijski album ne može biti null.");
            }

            if (!album.IsValid(out string errorMassage))
            {
                _logger.Loguj($"Neuspesna validacija studijskog albuma:{errorMassage}");
                return Result<Zapis>.Failure("validation.error", errorMassage);
            }
            try
            {
                _upisRepozitorijum.Dodaj(album);
                _logger.Loguj($"Uspesno dodat studijski album sa ID-jem: {album.Id}");
                return Result<Zapis>.Success(album);
            }
            catch (Exception ex)
            {
                _logger.Loguj($"Greska pri upisu studijskog albuma: {ex.Message}");
                return Result<Zapis>.Failure("repository.error", ex.Message);
            }
        }

        public Result<Zapis> DodajKoncertniAlbum(KoncertniAlbum album)
        {
     
            if (album == null)
            {
                return Result<Zapis>.Failure("album.null", "Koncertni album ne može biti null.");
            }

            if (!album.IsValid(out string errorMassage))
            {
                _logger.Loguj($"Neuspesna validacija studijskog albuma:{errorMassage}");
                return Result<Zapis>.Failure("validation.error", errorMassage);
            }
            try
            {
                _upisRepozitorijum.Dodaj(album);
                _logger.Loguj($"Uspesno dodat studijski album sa ID-jem: {album.Id}");
                return Result<Zapis>.Success(album);
            }
            catch (Exception ex)
            {
                _logger.Loguj($"Greska pri upisu studijskog albuma: {ex.Message}");
                return Result<Zapis>.Failure("repository.error", ex.Message);
            }
        }

        public IEnumerable<Zapis> VratiSveZapise()
        {
            return _citanjeRepozitroijum.VratiSve() ?? new List<Zapis>();
        }

        public IEnumerable<Zapis> PronadjiPoIzvodjacu(string izvodjac)
        {
            if (string.IsNullOrWhiteSpace(izvodjac))
            {
                return Enumerable.Empty<Zapis>();
            }
            return _citanjeRepozitroijum.PronadjiPoIzvodjacu(izvodjac);
        }
        public Result DodajOmiljeno(Guid id)
        {
            var zapis = _citanjeRepozitroijum.VratiPoId(id);
            if (zapis == null)
            {
                _logger.Loguj($"Pokusaj dodavanja u omiljene neuspesan - Id {id} ne postoji.");
                return Result.Failure("zapis.notfound", "Zapis sa datim ID-jem ne postoji");
            }

            if (zapis.JeOmiljeno)
            {

                return Result.Failure("zapis.alreadyFavorite", "Zapis je vec u omiljenima.");
            }

            zapis.JeOmiljeno = true;
            _upisRepozitorijum.Azuriraj(zapis);

            _logger.Loguj($"Zapis sa ID-jem {id} dodat u omiljene.");
            return Result.Success();
        }

        public Result UkloniIzOmiljenih (Guid id)
        {
            var zapis = _citanjeRepozitroijum.VratiPoId(id);
            if (zapis == null)
            {
                _logger.Loguj($"Pokusaj dodavanja u omiljene neuspesan - Id {id} ne postoji.");
                return Result.Failure("zapis.notfound", "Zapis sa datim ID-jem ne postoji");
            }

            if (!zapis.JeOmiljeno)
            {

                return Result.Failure("zapis.notfavorite", "Zapis nije u omiljenima,  nedozvoljena operacija.");
            }

            zapis.JeOmiljeno = false;
            _upisRepozitorijum.Azuriraj(zapis);

            _logger.Loguj($"Zapis sa ID-jem {id} uklonjen iz omiljenih.");
            return Result.Success();
        }

        public Result DodajUOmiLjene(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
