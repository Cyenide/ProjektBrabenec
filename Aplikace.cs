namespace EvidenceBasic;

internal class Aplikace
{
    Evidence novaEvidence = new Evidence();
    UzivatelskeRozhrani rozhrani = new UzivatelskeRozhrani();

    /// <summary>
    /// Spustí hotovou aplikaci
    /// </summary>
    public void Spustit()
    {
        // jen aby v paměti byli nějací pojištěnci
        novaEvidence.PridatPojistence();
        bool konec = false;
        while (!konec)
        {
            rozhrani.VypsatMenu();
            char volba = rozhrani.ZvoleniVolby();
            Console.WriteLine("\n");
            switch (volba)
            {
                case '1':
                    novaEvidence.PridatNovehoPojistence(rozhrani.ZjistiJmeno(), rozhrani.ZjistiJmeno(1), rozhrani.ZjistiVek(), rozhrani.ZjistiTelefon());
                    Console.WriteLine("\nData byla uložena.");
                    rozhrani.Pokracovat();
                    break;

                case '2':
                    rozhrani.VypsatPojistene(novaEvidence.VratListVsechPojistenych());
                    break;

                case '3':
                    List<Pojistenec> listNalezenych = novaEvidence.Vyhledat(rozhrani.ZjistiJmeno(), rozhrani.ZjistiJmeno(1));
                    Console.WriteLine();
                    if (listNalezenych.Count != 0)
                    { rozhrani.VypsatPojistene(listNalezenych); }
                    else
                    {
                        Console.WriteLine("Nebyl nalezen žádný pojištěnec odpovídající hledanému jménu.");
                        rozhrani.Pokracovat();
                    }
                    break;

                case '4':
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

