namespace Rendezes.Logika;

public class Rendez : ICserelheto
{
    private readonly IRendezesiStrategia _strategia;

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
        _strategia.Rendezes(t, this);

    }

    // Az interfész implementálása. Egyelőre üres.
    public void Csere(ref int a, ref int b)
    {
        (a, b) = (b, a);
    }
}