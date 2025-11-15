using Rendezes.Logika;

namespace Rendezes.Teszt;

public class MockRendezesiStrategia : IRendezesiStrategia
{
    public int HivasokSzama { get; private set; } = 0;

    public void Rendezes(int[] t, ICserelheto cserelo)
    {
        HivasokSzama++;
    }
}