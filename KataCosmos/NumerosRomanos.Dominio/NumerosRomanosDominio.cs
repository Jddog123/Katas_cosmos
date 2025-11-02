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
        public void Convertir(int numero)
        {
            if(numero == 500)
            {
                _numeroRomano = "D";
                return;
            }

            while (numero >= 100)
            {
                _numeroRomano += "C";
                numero -= 100;
            }

            while (numero >= 90)
            {
                _numeroRomano += "XC";
                numero -= 90;
            }

            while (numero >= 50)
            {
                _numeroRomano += "L";
                numero -= 50;
            }

            while (numero >= 40)
            {
                _numeroRomano += "XL";
                numero -= 40;
            }

            while (numero >= 10)
            {
                _numeroRomano += "X";
                numero -= 10;
            }

            while (numero >= 9)
            {
                _numeroRomano += "IX";
                numero -= 9;
            }

            while (numero >= 5)
            {
                _numeroRomano += "V";
                numero -= 5;
            }

            while (numero >= 4)
            {
                _numeroRomano += "IV";
                numero -= 4;
            }

            while (numero >= 1)
            {
                _numeroRomano += "I";
                numero -= 1;
            }
        }

        public string ObtenerNumeroRomano()
        {
            return _numeroRomano;
        }
    }
}
