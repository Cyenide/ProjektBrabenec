using System.Security.Policy;

namespace EvidenceBasic;

internal class Program
{
    static void Main(string[] args)
    {
        Evidence novaEvidence = new Evidence();
        UzivatelskeRozhrani rozhrani = new UzivatelskeRozhrani();
        novaEvidence.PridatPojistence();
        bool konec = false;
        while (!konec)
        {
            rozhrani.VypsatMenu();
            string volba = rozhrani.ZvoleniVolby();
            switch (volba)
            {
                case "1":
                    novaEvidence.PridatPojistence(rozhrani.ZjistiJmeno(), rozhrani.ZjistiPrijmeni(), rozhrani.ZjistiVek(), rozhrani.ZjistiTelefon());
                    Console.WriteLine("\nData byla uložena.");
                    rozhrani.Pokracovat();
                    break;

                case "2":
                    rozhrani.VypsatPojistene(novaEvidence.VratListVsechPojistenych());
                    break;

                case "3":
                    List<Pojistenec> listNalezenych = novaEvidence.Vyhledat(rozhrani.ZjistiJmeno(), rozhrani.ZjistiPrijmeni());
                    Console.WriteLine();
                    rozhrani.VypsatPojistene(listNalezenych);
                    break;

                case "4":
                    konec = true;
                    break;

                default:
                    Console.WriteLine("Neplatná volba, zadejte prosím znovu.");
                    rozhrani.Pokracovat();
                    break;
            }
        }
    }
}
