namespace EvidenceBasic;

internal class Evidence
{
    private List<Pojistenec> evidence = new List<Pojistenec>();
    UzivatelskeRozhrani rozhrani = new UzivatelskeRozhrani();

    /// <summary>
    /// Přidá nějaké pojištěnce do evidenčního listu
    /// </summary>
    public void PridatPojistence()
    {
        evidence.Add(new Pojistenec("Jan", "Novák", 27, "123456789"));
        evidence.Add(new Pojistenec("David", "Kopecký", 45, "123456789"));
        evidence.Add(new Pojistenec("Dalibor", "Nový", 27, "456654456"));
        evidence.Add(new Pojistenec("Luboš", "Kovář", 25, "321123321"));
        evidence.Add(new Pojistenec("Petr", "Pekař", 40, "987654321"));
        evidence.Add(new Pojistenec("Patrik", "Pokorný", 34, "123456789"));
        evidence.Add(new Pojistenec("Jan", "Novák", 35, "987456321"));
        evidence.Add(new Pojistenec("Karel", "Pokora", 55, "+421987456321"));
        evidence.Add(new Pojistenec("Martina", "Kovárová", 35, "+421987456321"));
    }

    /// <summary>
    /// Přidá pojištence do evidence
    /// </summary>
    /// <param name="jmeno">Jméno přidávaného pojištěnce</param>
    /// <param name="prijmeni">Příjmení přidávaného pojištěnce</param>
    /// <param name="vek">Věk přidávaného pojištěnce</param>
    /// <param name="telefon">Telefonní číslo přidávaného pojištěnce</param>
    /// <returns>Vytvořeného pojištěnce</returns>
    public Pojistenec PridatNovehoPojistence(string jmeno, string prijmeni, int vek, string telefon)
    {
        Pojistenec pojistenec = new Pojistenec(jmeno, prijmeni, vek, telefon);
        evidence.Add(pojistenec);
        return pojistenec;
    }

    /// <summary>
    /// Vyhledá v evidenci pojištěnce odpovídajícího křestním jménem a příjmením
    /// </summary>
    /// <param name="jmeno">Křestní jméno hledaného pojištěnce</param>
    /// <param name="prijmeni">Příjmení hledaného pojištěnce</param>
    /// <returns>List nalezených pojištěnců</returns>
    public List<Pojistenec> Vyhledat(string jmeno, string prijmeni)
    {
        List<Pojistenec> listNalezenych = new List<Pojistenec>();

        foreach (Pojistenec p in evidence)
        {
            if (p.Jmeno.ToLower() == jmeno.ToLower() && p.Prijmeni.ToLower() == prijmeni.ToLower())
            {
                listNalezenych.Add(p);
            }
        }
        return listNalezenych;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>Vrací list všech pojištěných v paměti</returns>
    public List<Pojistenec> VratListVsechPojistenych()
    {
        return evidence;
    }
}
