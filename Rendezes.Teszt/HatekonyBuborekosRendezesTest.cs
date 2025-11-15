using Rendezes.Logika;

namespace Rendezes.Teszt;

[TestClass]
public class HatekonyBuborekosRendezesTest
{
    [TestMethod]
    public void Rendezes_EgyszeruTombbel_HelyesenRendezi()
    {
        // Arrange
        var strategia = new HatekonyBuborekosRendezes();
        var cserelo = new Rendez(strategia);
        int[] tomb = { 5, 1, 4, 2, 8 };
        int[] vartEredmeny = { 1, 2, 4, 5, 8 };

        // Act
        strategia.Rendezes(tomb, cserelo);

        // Assert
        CollectionAssert.AreEqual(vartEredmeny, tomb);
    }
}