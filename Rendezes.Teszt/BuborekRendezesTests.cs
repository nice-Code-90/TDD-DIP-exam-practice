using Rendezes.Logika;

namespace Rendezes.Teszt;

[TestClass]
public class BuborekRendezesTests
{
    [TestMethod]
    public void Rendezes_EgyszeruTombbel_HelyesenRendezi()
    {
        var strategia = new BuborekRendezes();
        var cserelo = new Rendez(strategia);

        int[] tomb = { 5, 1, 4, 2, 8 };
        int[] vartEredmeny = { 1, 2, 4, 5, 8 };

        strategia.Rendezes(tomb, cserelo);

        CollectionAssert.AreEqual(vartEredmeny, tomb);
    }
    
}
