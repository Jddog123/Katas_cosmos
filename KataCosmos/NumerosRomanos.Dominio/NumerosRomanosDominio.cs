using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumerosRomanos.Dominio
{
    public class NumerosRomanosDominio
    {
        private string _numeroRomano;
        public static readonly IDictionary<int, string> LetrasRomanas = new Dictionary<int, string>
        {
             {1000, "M"},
             {900, "CM"},
             {500, "D"},
             {400, "CD"},
             {100, "C"},
             {90, "XC"},
             {50, "L"},
             {40, "XL"},
             {10, "X"},
             {9, "IX"},
             {5, "V"},
             {4, "IV"},
             {1, "I"},
        };
        public void Convertir(int numero)
        {
            foreach (var letraRomana in LetrasRomanas)
            {
                while (numero >= letraRomana.Key)
                {
                    _numeroRomano += letraRomana.Value;
                    numero -= letraRomana.Key;
                }
            }
        }

        public string ObtenerNumeroRomano()
        {
            return _numeroRomano;
        }
    }
}
