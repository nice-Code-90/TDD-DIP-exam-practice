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

    [TestMethod]
    public void Rendezes_BuborekosStrategiaval_HelyesenRendeziATombot()
    {
        var strategia = new BuborekRendezes();
        var rendez = new Rendez(strategia);

        int[] tomb = { 5, 1, 4, 2, 8 };
        int[] vartEredmeny = { 1, 2, 4, 5, 8 };

        rendez.Rendezes(tomb);

        CollectionAssert.AreEqual(vartEredmeny, tomb);
    }

    [TestMethod]
    public void Rendezes_UgyanazzalATombbelKetszer_StrategiaCsakEgyszerFutLe()
    {
        // Arrange
        var mockStrategia = new MockRendezesiStrategia();
        var rendez = new Rendez(mockStrategia);
        int[] tomb1 = { 3, 1, 2 };
        int[] tomb2 = { 3, 1, 2 }; // Fontos, hogy a tartalom azonos legyen

        // Act
        rendez.Rendezes(tomb1);
        rendez.Rendezes(tomb2);

        // Assert
        // A stratégiát csak az első hívásnál kellett volna meghívni,
        // a másodiknál a cache-ből kellett volna dolgozni.
        Assert.AreEqual(1, mockStrategia.HivasokSzama);
    }
}
