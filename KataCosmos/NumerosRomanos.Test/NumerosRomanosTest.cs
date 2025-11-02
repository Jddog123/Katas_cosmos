
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
        [Theory]
        [InlineData(1,"I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        public void Si_NumeroEsUnoDosOTres_Debe_RetornarIPorCantidadDeNumero(int numero, string numeroRomanoEsperado)
        {
            //Act
            numerosRomanos.Convertir(numero);
            //Assert
            numerosRomanos.ObtenerNumeroRomano().Should().BeEquivalentTo(numeroRomanoEsperado);
        }

        [Fact]
        public void Si_NumeroEsCuatro_Debe_RetornarIV()
        {
            //Act
            numerosRomanos.Convertir(4);
            //Assert
            numerosRomanos.ObtenerNumeroRomano().Should().BeEquivalentTo("IV");
        }

        [Fact]
        public void Si_NumeroEsCinco_Debe_RetornarV()
        {
            //Act
            numerosRomanos.Convertir(5);
            //Assert
            numerosRomanos.ObtenerNumeroRomano().Should().BeEquivalentTo("V");
        }

        [Fact]
        public void Si_NumeroEsSeis_Debe_RetornarVI()
        {
            //Act
            numerosRomanos.Convertir(6);
            //Assert
            numerosRomanos.ObtenerNumeroRomano().Should().BeEquivalentTo("VI");
        }

        [Fact]
        public void Si_NumeroEsSiete_Debe_RetornarVII()
        {
            //Act
            numerosRomanos.Convertir(7);
            //Assert
            numerosRomanos.ObtenerNumeroRomano().Should().BeEquivalentTo("VII");
        }

        [Fact]
        public void Si_NumeroEsOcho_Debe_RetornarVIII()
        {
            //Act
            numerosRomanos.Convertir(8);
            //Assert
            numerosRomanos.ObtenerNumeroRomano().Should().BeEquivalentTo("VIII");
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

            if (numero == 5)
            {
                _numeroRomano = "V";
                return;

            }

            if (numero > 5)
            {
                _numeroRomano = "V";
                numero -= 5;
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