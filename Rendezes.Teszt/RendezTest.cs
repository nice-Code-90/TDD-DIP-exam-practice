using Rendezes.Logika;

namespace Rendezes.Teszt;

[TestClass]
public sealed class RendezTest
{
    [TestMethod]
    public void Rendezes_NullBemenettel_RendezesArgumentumKiveteltDob()
    {
        // Arrange (Előkészítés)
        // A stratégia itt lényegtelen, lehet null is, vagy egy "ál" (mock) objektum.
        // A teszt fordításához létre kell hoznunk a Rendez osztályt.
        var rendez = new Rendez(null);

        // Act & Assert (Végrehajtás és Ellenőrzés)
        // Azt várjuk, hogy a Rendezes metódus hívása null-al
        // egy RendezesArgumentumKivetel típusú kivételt fog dobni.
        Assert.ThrowsException<RendezesArgumentumKivetel>(() => rendez.Rendezes(null));
    }

    [TestMethod]
    public void Rendezes_TulNagyMeretuTombbel_RendezesArgumentumKiveteltDob()
    {
        // Arrange
        var rendez = new Rendez(null);
        var tulNagyTomb = new int[10_001];

        // Act & Assert
        Assert.ThrowsException<RendezesArgumentumKivetel>(() => rendez.Rendezes(tulNagyTomb));
    }

    [TestMethod]
    public void Csere_KetErtekkel_HelyesenFelcsereliOketa()
    {
        // Arrange
        var rendez = new Rendez(null);
        int a = 10;
        int b = 20;
        const int originalA = 10;
        const int originalB = 20;

        // Act
        rendez.Csere(ref a, ref b);

        // Assert
        Assert.AreEqual(originalB, a);
        Assert.AreEqual(originalA, b);
    }
}
