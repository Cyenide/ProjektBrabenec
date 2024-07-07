using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidenceBasic;

internal class Pojistenec
{
    public string Jmeno { get; private set; }
    public string Prijmeni { get; private set; }
    public int Vek { get; private set; }
    public string Telefon { get; private set; }

    public Pojistenec(string jmeno, string prijmeni, int vek, string telefon)
    {
        Jmeno = jmeno;
        Prijmeni = prijmeni;
        Vek = vek;
        Telefon = telefon;
    }

    public override string ToString()
    {
        return String.Format("{0,-15}{1,-15}{2,-5}{3,-15}", Jmeno, Prijmeni, Vek, Telefon);
    }
}
