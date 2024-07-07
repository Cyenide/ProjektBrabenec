using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

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
    public string ZvoleniVolby()
    {
        string volba = Console.ReadLine().Trim();
        Console.WriteLine();
        return volba;
    }

    /// <summary>
    /// Vypíše všechny pojištěné aktuálně v evidenci
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
    /// Vyžádá si křestní jméno z uživatelského vstupu
    /// </summary>
    /// <returns>Zadané jméno jako string</returns>
    public string ZjistiJmeno()
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
    /// Vyžádá si příjmení z uživatelského vstupu
    /// </summary>
    /// <returns>Zadané příjmení jako string</returns>
    public string ZjistiPrijmeni()
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
    /// Vyžádá si z věk uživatelského vstupu
    /// </summary>
    /// <returns>Zadaný věk jako int</returns>
    public int ZjistiVek()
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
