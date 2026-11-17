# Корисничке приче

<!-- Самостално написати шест прича према додељеној спецификацији. -->

<!-- За сваку причу навести улогу, могућност, корист, F-ознаку и >= 2 критеријума прихватања. -->

## US-01 (F1)

US-01: Dodavanje studijskog albuma

Kao administrator sistema, želim da dodam zapis tipa „Studijski album” unosom naziva, opisa i godine izdanja, kako bih evidentirao novo izdanje u sistemu uz poštovanje poslovnih pravila.

Kriterijumi prihvatanja:

&#x20; 1. Uspešan unos vraća generisani jedinstveni identifikator i čuva zapis.

&#x20; 2. Unos sa godinom izdanja u budućnosti ili praznim nazivom se odbija uz odgovarajući rezultat neuspeha.



## US-02 (F2)

US-02: Dodavanje koncertnog albuma

Kao administrator sistema,želim da dodam zapis tipa „Koncertni album” unosom naziva, opisa i mesta koncerta,kako bih evidentirao živo izvođenje u sistemu.

Kriterijumi prihvatanja:

&#x20; 1. Uspešan unos kreira zapis sa unetim mestom koncerta i vraća njegov ID.

&#x20; 2. Pokušaj unosa sa praznim obaveznim poljima (naziv, opis, mesto) odbija se bez upisa u bazu.



## US-03 (F3)

US-03: Pregled i prikaz svih zapisa

Kao korisnik sistema,želim da prikažem sve evidentirane zapise sa tipom, identifikatorom, statusom i godinom izdanja,kako bih imao jasan pregled muzičke kolekcije.

Kriterijumi prihvatanja:

&#x20; 1. Prikaz uspešno izlistava sve zapise bez obzira na njihov tip (studijski ili koncertni).

&#x20; 2. Ukoliko je kolekcija prazna, sistem vraća jasnu poruku da nema evidentiranih zapisa.



## US-04 (F4)

US-04: Pretraga zapisa po imenu izvođača

Kao korisnik sistema,želim da pretražim zapise prema imenu izvođača bez razlikovanja velikih i malih slova,kako bih brzo pronašao albume određenog izvođača.

Kriterijumi prihvatanja:

&#x20; 1. Pretraga vraća sve zapise čije ime izvođača delimično ili potpuno odgovara unetom tekstu.

&#x20; 2. Ako nijedan zapis ne odgovara kriterijumima pretrage, sistem prikazuje odgovarajuću poruku o neuspehu.



## US-05 (F5)

US-05: Dodavanje albuma u omiljene

Kao korisnik sistema,želim da dodam postojeći album u listu omiljenih preko njegovog identifikatora,

kako bih istakao značajna izdanja.

Kriterijumi prihvatanja:

&#x20; 1. Album koji nije u omiljenima uspešno prelazi u status omiljenog.

&#x20; 2. Pokušaj dodavanja albuma koji je već u omiljenima ili prosleđivanje nepostojećeg ID-ja vraća rezultat neuspeha.



## US-06 (F6)

US-06: Uklanjanje albuma iz omiljenih

Kao korisnik sistema,želim da uklonim album iz liste omiljenih,kako bih korigovao listu favorizovanih izdanja.

Kriterijumi prihvatanja:

&#x20; 1. Album koji je bio označen kao omiljeni uspešno gubi taj status.

&#x20; 2. Pokušaj uklanjanja albuma koji nije u omiljenima odbija se bez promene stanja sistema.

