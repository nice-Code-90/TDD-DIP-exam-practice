using System;
using System.Collections.Generic;

namespace Rendezes.Logika;

public class Rendez : ICserelheto
{
    private readonly IRendezesiStrategia _strategia;
    private const int MaxCacheSize = 100;
    private readonly Dictionary<string, int[]> _cache = new();

    // Konstruktor, ami fogadja a stratégiát.
    public Rendez(IRendezesiStrategia strategia)
    {
        _strategia = strategia;
    }

    //  A metódus, amit a tesztünk hív. Egyelőre üres.
    public void Rendezes(int[] t)
    {
        if (t is null)
        {
            throw new RendezesArgumentumKivetel("A rendezendő tömb nem lehet null.");
        }
        if (t.Length > 10_000)
        {
            throw new RendezesArgumentumKivetel("A rendezendő tömb mérete nem lehet nagyobb 10 000-nél.");
        }

        // 1. Kulcs generálása a bemeneti tömbből.
        var key = string.Join(",", t);

        // 2. Ellenőrizzük, hogy az eredmény már a cache-ben van-e.
        if (_cache.TryGetValue(key, out var cachedResult))
        {
            // Ha igen (cache hit), az eredményt bemásoljuk a bemeneti tömbbe,
            // és visszatérünk anélkül, hogy a stratégiát hívnánk.
            Array.Copy(cachedResult, t, t.Length);
            return;
        }

        // 3. Ha nincs a cache-ben (cache miss), futtatjuk a rendezést.
        _strategia.Rendezes(t, this);

        // 4. A frissen rendezett tömböt elmentjük a cache-be, ha van még hely.
        if (_cache.Count < MaxCacheSize)
        {
            _cache[key] = (int[])t.Clone();
        }
    }


    public void Csere(ref int a, ref int b)
    {
        (a, b) = (b, a);
    }
}