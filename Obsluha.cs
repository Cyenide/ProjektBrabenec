using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EvidenceBasic;

internal static class Obsluha
{
    private static List<Pojistenec> evidence = new List<Pojistenec>();
    private static bool konec = false;

    public static void Evidence()
    {
        evidence.Add(new Pojistenec("Jan", "Novák", 27, 123456789));
        evidence.Add(new Pojistenec("David", "Kopecký", 45, 123456789));
        evidence.Add(new Pojistenec("Dalibor", "Nový", 27, 456654456));
        evidence.Add(new Pojistenec("Luboš", "Kovář", 25, 321123321));
        evidence.Add(new Pojistenec("Petr", "Pekař", 40, 987654321));
        evidence.Add(new Pojistenec("Patrik", "Pokorný", 34, 123456789));
        evidence.Add(new Pojistenec("Jan", "Novák", 35, 987456321));
        while (!konec) 
        {
            VypsatMenu();
            VyberVolby();
        }
    }
    /// <summary>
    /// Vykreslí do konzole Menu
    /// </summary>
    /// <param name="typMenu">Výchozí hodnota 0 vypíše výchozí menu, jakákoliv jiná hodnota vypíše menu k hledání pojištených</param>
    public static void VypsatMenu(int typMenu = 0)
    {
        Console.Clear();
        Console.WriteLine("------------------------");
        Console.WriteLine("Evidence pojištěných");
        Console.WriteLine("------------------------\n");
        if (typMenu == 0)
        {
            Console.WriteLine("Vyberte akci:");
            Console.WriteLine("1 - Přidat nového pojištěného");
            Console.WriteLine("2 - Vypsat všechny pojištěné");
            Console.WriteLine("3 - Vyhledat pojištěného");
            Console.WriteLine("4 - Konec");
        }
        else
        {
            Console.WriteLine("Dle čeho si přejete pojištené/ho vyhledat?:");
            Console.WriteLine("1 - Celého jména");
            Console.WriteLine("2 - Věku");
            Console.WriteLine("3 - Telefonního čísla");
        }


    }

    /// <summary>
    /// Zeptá se uživatele na hodnotu na základě které vyberé korespondující akci
    /// </summary>
    /// <param name="typVolby">Výchozí hodnota 0 zvolí výběr k obsluze aplikace, jakákoliv jiná zvolí výběr k hledání pojištěných</param>
    public static void VyberVolby(int typVolby = 0)
    {
        string volba = Console.ReadLine().Trim();
        Console.WriteLine();
        if (typVolby == 0)
        {
            switch (volba)
            {
                case "1":
                    Pridat();
                    break;

                case "2":
                    VypsatPojistene();
                    break;

                case "3":
                    VypsatMenu(1);
                    VyberVolby(1);
                    break;

                case "4":
                    konec = true;
                    break;

                default:
                    Console.WriteLine("Neplatná volba, zadejte prosím znovu:");
                    break;
            }
        }
        else
        {
            List<Pojistenec> listNalezenych = new List<Pojistenec>();
            string jmeno = "";
            string prijmeni = "";
            int vek = 0;
            switch (volba)
            {
                case "1":
                    jmeno = ZjistiJmeno().ToLower();
                    prijmeni = ZjistiPrijmeni().ToLower();
                    listNalezenych.AddRange(Vyhledat(jmeno, prijmeni));
                    break;

                case "2":
                    vek = ZjistiVek();
                    listNalezenych.AddRange(Vyhledat(vek));
                    break;

                case "3":
                    string cisloTextem = ZjistiTelefon().ToString();
                    listNalezenych.AddRange(Vyhledat(cisloTextem));
                    break;

                default:
                    Console.WriteLine("Neplatná volba, zadejte prosím znovu:");
                    break;
            }
            Console.WriteLine();
            if (listNalezenych.Count() > 0)
            {
                Console.WriteLine("{0,-15}{1,-15}{2,-5}{3,-15}", "Jméno", "Příjmení", "Věk", "Telefon");
                foreach (Pojistenec p in listNalezenych)
                {
                    Console.WriteLine(p);
                }
                Pokracovat();
            }
            else
            {
                Console.WriteLine("Nenalezen žádný pojištěnec odpovídající hledaným hodnotám.");
                Pokracovat();
            }
        }
    }

    /// <summary>
    /// Zjistí křestní jméno z uživatelského vstupu
    /// </summary>
    /// <returns>Zadané jméno jako string</returns>
    public static string ZjistiJmeno()
    {
        string jmeno = "";

        while (jmeno.Length == 0)
        {
            Console.WriteLine("Zadejte křestní jméno pojištěného:");
            jmeno = Console.ReadLine().Trim();
            if (jmeno.Length == 0)
            {
                Console.WriteLine("Jméno nezadáno, zadejte prosim znovu.");
            }
        }
        return jmeno;
    }

    /// <summary>
    /// Zjistí příjmení z uživatelského vstupu
    /// </summary>
    /// <returns>Zadané příjmení jako string</returns>
    public static string ZjistiPrijmeni()
    {
        string prijmeni = "";

        while (prijmeni.Length == 0)
        {
            Console.WriteLine("Zadejte příjmení:");
            prijmeni = Console.ReadLine().Trim();
            if (prijmeni.Length == 0)
            {
                Console.WriteLine("Příjmení nezadáno, zadejte prosim znovu.");
            }
        }
        return prijmeni;
    }

    /// <summary>
    /// Zjistí věk z uživatelského vstupu
    /// </summary>
    /// <returns>Zadaný věk jako int</returns>
    public static int ZjistiVek()
    {
        int vek = 0;

        while (vek == 0)
        {
            Console.WriteLine("Zadejte věk:");
            int.TryParse(Console.ReadLine(), out vek);
            if (vek == 0)
            {
                Console.WriteLine("Zadejte prosím celé číslo větší než nula.");
            }
        }
        return vek;
    }

    /// <summary>
    /// Zjistí telefonní číslo z uživatelského vstupu
    /// </summary>
    /// <returns>9 místné telefonní číslo jako int</returns>
    public static int ZjistiTelefon()
    {
        int telefon = 0;

        while (telefon.ToString().Length != 9)
        {
            Console.WriteLine("Zadejte telefonní číslo:");
            int.TryParse(Console.ReadLine(), out telefon);
            if (telefon.ToString().Length != 9)
            {
                Console.WriteLine("Zadejte prosím devítimístné telefonní číslo.");
            }
        }
        return telefon;
    }

    /// <summary>
    /// Metoda k přidání pojištence do evidence
    /// </summary>
    /// <returns>Vytvořeného pojištěnce</returns>
    public static Pojistenec Pridat()
    {
        string jmeno = ZjistiJmeno();
        string prijmeni = ZjistiPrijmeni();
        int vek = ZjistiVek();
        int telefon = ZjistiTelefon();
        evidence.Add(new Pojistenec(jmeno, prijmeni, vek, telefon));
        Console.WriteLine("\nData byla uložena.");
        Pokracovat();
        return new Pojistenec(jmeno, prijmeni, vek, telefon);
    }

    /// <summary>
    /// Vypíše všechny pojištěné aktuálně v evidenci
    /// </summary>
    public static void VypsatPojistene()
    {
        Console.WriteLine("{0,-15}{1,-15}{2,-5}{3,-15}", "Jméno", "Příjmení", "Věk", "Telefon");
        foreach (Pojistenec p in evidence)
        {
            Console.WriteLine(p);
        }
        Pokracovat();
    }

    /// <summary>
    /// Vyhledá v evidenci pojištěnce odpovídajícího křestním jménem a příjmením
    /// </summary>
    /// <param name="jmeno">Křestní jméno hledaného pojištěnce</param>
    /// <param name="prijmeni">Příjmení hledaného pojištěnce</param>
    /// <returns>List nalezených pojištěnců</returns>
    public static List<Pojistenec> Vyhledat(string jmeno, string prijmeni)
    {
        List<Pojistenec> listNalezenych = new List<Pojistenec>();
        foreach (Pojistenec p in evidence)
        {
            if (p.Jmeno.ToLower() == jmeno && p.Prijmeni.ToLower() == prijmeni)
            {
                listNalezenych.Add(p);
            }
        }
        return listNalezenych;
    }

    /// <summary>
    /// Vyhledá pojištěnce v evidenci odpovídajícího věkem
    /// </summary>
    /// <param name="vek">Věk hledaných pojištěnců</param>
    /// <returns>List nalezených pojištěnců</returns>
    public static List<Pojistenec> Vyhledat(int vek)
    {
        List<Pojistenec> listNalezenych = new List<Pojistenec>();
        foreach (Pojistenec p in evidence)
        {
            if (p.Vek == vek)
            {
                listNalezenych.Add(p);
            }
        }
        return listNalezenych;
    }

    /// <summary>
    /// Vyhledá pojištěnce v evidenci odpovídajícího telefonním číslem
    /// </summary>
    /// <param name="cislo">Hledané telefonní číslo</param>
    /// <returns>List nalezených pojištěnců</returns>
    public static List<Pojistenec> Vyhledat(string cislo)
    {
        List<Pojistenec> listNalezenych = new List<Pojistenec>();
        int telefon = int.Parse(cislo);
        foreach (Pojistenec p in evidence)
        {
            if (p.Telefon == telefon)
            {
                listNalezenych.Add(p);
            }
        }
        return listNalezenych;
    }

    /// <summary>
    /// Vyzve ke stisknutí klávesy
    /// </summary>
    public static void Pokracovat()
    {
        Console.WriteLine("\nPokračujte libovolnou klávesou...");
        Console.ReadKey();
    }
}
