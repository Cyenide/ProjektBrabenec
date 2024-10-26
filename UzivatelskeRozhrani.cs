namespace EvidenceBasic;

internal class UzivatelskeRozhrani
{
    /// <summary>
    /// Vykreslí do konzole menu
    /// </summary>
    public void VypsatMenu()
    {
        Console.Clear();
        Console.WriteLine("------------------------");
        Console.WriteLine("Evidence pojištěných");
        Console.WriteLine("------------------------\n");
        Console.WriteLine("Vyberte akci:");
        Console.WriteLine("1 - Přidat nového pojištěného");
        Console.WriteLine("2 - Vypsat všechny pojištěné");
        Console.WriteLine("3 - Vyhledat pojištěného");
        Console.WriteLine("4 - Konec");
    }

    /// <summary>
    /// Získá od uživatele hodnotu pro ovládání menu
    /// </summary>
    /// <returns>Zadanou hodnotu</returns>
    public char ZvoleniVolby()
    {
        return Console.ReadKey().KeyChar;
    }

    /// <summary>
    /// Vypíše pojištěné aktuálně v listu
    /// </summary>
    /// <param name="list">List, který se má vypsat</param>
    public void VypsatPojistene(List<Pojistenec> list)
    {
        Console.WriteLine("{0,-15}{1,-15}{2,-5}{3,-15}", "Jméno", "Příjmení", "Věk", "Telefon");
        foreach (Pojistenec p in list)
        {
            Console.WriteLine(p);
        }
        Pokracovat();
    }

    /// <summary>
    /// Vyžádá si jméno z uživatelského vstupu
    /// </summary>
    /// <param name="typMetody">Výchozí hodnota 0 pro získání křestního jména nebo jakákoliv jiná pro získání příjmení</param>
    /// <returns>Zadané jméno jako string</returns>
    public string ZjistiJmeno(int typMetody = 0)
    {
        string jmeno = "";

        if (typMetody == 0)

        {
            while (jmeno.Length == 0)
            {
                Console.WriteLine("Zadejte křestní jméno pojištěného:");
                jmeno = Console.ReadLine().Trim();
                if (jmeno.Length == 0)
                {
                    Console.WriteLine("Jméno nezadáno, zadejte prosím znovu.");
                }
            }
            return jmeno;
        }
        else
        {
            while (jmeno.Length == 0)
            {
                Console.WriteLine("Zadejte příjmení:");
                jmeno = Console.ReadLine().Trim();
                if (jmeno.Length == 0)
                {
                    Console.WriteLine("Příjmení nezadáno, zadejte prosím znovu.");
                }
            }
            return jmeno;
        }
    }

    /// <summary>
    /// Vyžádá si z věk uživatelského vstupu
    /// </summary>
    /// <returns>Zadaný věk jako int</returns>
    public int ZjistiVek()
    {
        int vek = 0;

        while (vek <= 0)
        {
            Console.WriteLine("Zadejte věk:");
            int.TryParse(Console.ReadLine(), out vek);
            if (vek <= 0)
            {
                Console.WriteLine("Zadejte prosím celé číslo větší než nula.");
            }
        }
        return vek;
    }

    /// <summary>
    /// Vyžádá si telefonní číslo z uživatelského vstupu
    /// </summary>
    /// <returns>Zadané telefonní číslo jako string</returns>
    public string ZjistiTelefon()
    {
        string telefon = "";

        while (telefon.Length < 9 || telefon.Length > 13)
        {
            Console.WriteLine("Zadejte telefonní číslo:");
            telefon = Console.ReadLine();
            if (telefon.Length < 9 || telefon.Length > 13)
            {
                Console.WriteLine("Zadejte prosím devítimístné telefonní číslo nebo telefonní číslo s předvolbou.");
            }
        }
        return telefon;
    }

    /// <summary>
    /// Vyzve ke stisknutí klávesy
    /// </summary>
    public void Pokracovat()
    {
        Console.WriteLine("\nPokračujte libovolnou klávesou...");
        Console.ReadKey();
    }
}
