
using FluentAssertions;

namespace NumerosRomanos.Test
{
    public class NumerosRomanosTest
    {
        NumerosRomanos numerosRomanos;
        public NumerosRomanosTest()
        {
            numerosRomanos = new NumerosRomanos();
        }
        [Fact]
        public void Si_NumeroEsUno_Debe_RetornarI()
        {
            //Act
            numerosRomanos.Convertir(1);
            //Assert
            numerosRomanos.ObtenerNumeroRomano().Should().BeEquivalentTo("I");
        }

        [Fact]
        public void Si_NumeroEsDos_Debe_RetornarII()
        {
            //Act
            numerosRomanos.Convertir(2);
            //Assert
            numerosRomanos.ObtenerNumeroRomano().Should().BeEquivalentTo("II");
        }

        [Fact]
        public void Si_NumeroEsTres_Debe_RetornarIII()
        {
            //Act
            numerosRomanos.Convertir(3);
            //Assert
            numerosRomanos.ObtenerNumeroRomano().Should().BeEquivalentTo("III");
        }

        [Fact]
        public void Si_NumeroEsCuatro_Debe_RetornarIV()
        {
            //Act
            numerosRomanos.Convertir(4);
            //Assert
            numerosRomanos.ObtenerNumeroRomano().Should().BeEquivalentTo("IV");
        }
    }

    public class NumerosRomanos()
    {
        private string _numeroRomano;
        public void Convertir(int numero)
        {
            if (numero == 4)
            {
                _numeroRomano = "IV";
                return;
            }
                
            for (int i = 1; i <= numero; i++)
            {
                _numeroRomano += "I";
            }
        }

        public string ObtenerNumeroRomano()
        {
            return _numeroRomano;
        }
    }
}