using System;

namespace Rendezes.Logika;

public class BuborekRendezes : IRendezesiStrategia
{
    public void Rendezes(int[] t, ICserelheto cserelo)
    {
        if (t is null)
        {
            return;
        }

        for (int i = 0; i < t.Length - 1; i++)
        {
            for (int j = 0; j < t.Length - 1 - i; j++)
            {
                if (t[j] > t[j + 1]) cserelo.Csere(ref t[j], ref t[j + 1]);
            }
        }
    }
}
