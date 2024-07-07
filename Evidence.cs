using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
    }

    /// <summary>
    /// Přidá pojištence do evidence
    /// </summary>
    /// <param name="jmeno">Jméno přidávaného pojištěnce</param>
    /// <param name="prijmeni">Příjmení přidávaného pojištěnce</param>
    /// <param name="vek">Věk přidávaného pojištěnce</param>
    /// <param name="telefon">Telefon přidávaného pojištěnce</param>
    /// <returns>Vytvořeného pojištěnce</returns>
    public Pojistenec PridatPojistence(string jmeno, string prijmeni, int vek, string telefon)
    {
        evidence.Add(new Pojistenec(jmeno, prijmeni, vek, telefon));
        return new Pojistenec(jmeno, prijmeni, vek, telefon);
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
            if (p.Jmeno.ToLower() == jmeno && p.Prijmeni.ToLower() == prijmeni)
            {
                listNalezenych.Add(p);
            }
        }
        return listNalezenych;
    }

    public List<Pojistenec> VratListVsechPojistenych()
    {
        return evidence;
    }
}
