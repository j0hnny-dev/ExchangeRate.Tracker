# ExchangeRate.Tracker

A feladat, hogy készíts egy mini site-ot, backendként .NET Core WebAPI-t, adatbázisként MSSQL/PostGreSQL-t használva. Frontendnek egy Angular app-ot kérnénk.

Az alábbi funkciókat kérjük megvalósítani:

- Bejelentkezés
- User regisztráció
- Bejelentkezett oldal funkciói:
-- Jelenítse meg az MNB interfészéről (https://www.mnb.hu/arfolyamok.asmx) lekérdezhető árfolyamokat egy táblázatban. Az oldalon lehessen az egyes árfolyamok aktuális állapotát elmenteni adatbázisba egy opcionális megjegyzéssel.
-- Mini form, ahol megadott input adatra (forint összeg) kiírja a program az annak megfelelő EUR összeget.
-- Egy oldal, ami megjelenít egy listát elmentett árfolyamokról, és szerkeszteni lehet a megjegyzést, és törölni a rekordokat. Az alábbi adatokat kérjük elmenteni:
--- Mentés időpontja
--- Valuta
--- Érték
--- Megjegyzés (szöveges, nem kötelező, max. 100 karakter) 


## Migráció hozzáadása a projekthez

Add-Migration init -Project ExchangeRate.Tracker.Infrastructure -v

