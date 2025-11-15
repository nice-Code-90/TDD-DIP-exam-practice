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
        // var rendez = new Rendez(null);

        // Act & Assert (Végrehajtás és Ellenőrzés)
        // Azt várjuk, hogy a Rendezes metódus hívása null-al
        // egy RendezesArgumentumKivetel típusú kivételt fog dobni.
        // Assert.ThrowsException<RendezesArgumentumKivetel>(() => rendez.Rendezes(null));
    }
}
