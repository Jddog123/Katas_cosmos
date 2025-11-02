
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

        [Theory]
        [InlineData(6, "VI")]
        [InlineData(7, "VII")]
        [InlineData(8, "VIII")]
        public void Si_NumeroSeisSienteUOcho_Debe_RetornarVMasIPorCantidadDeNumeroMenosCinco(int numero, string numeroRomanoEsperado)
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
        public void Si_NumeroEsNueve_Debe_RetornarIX()
        {
            //Act
            numerosRomanos.Convertir(9);
            //Assert
            numerosRomanos.ObtenerNumeroRomano().Should().BeEquivalentTo("IX");
        }

        [Fact]
        public void Si_NumeroEsDiez_Debe_RetornarX()
        {
            //Act
            numerosRomanos.Convertir(10);
            //Assert
            numerosRomanos.ObtenerNumeroRomano().Should().BeEquivalentTo("X");
        }
    }

    public class NumerosRomanos()
    {
        private string _numeroRomano;
        public void Convertir(int numero)
        {
            if (numero == 10)
            {
                _numeroRomano = "X";
                return;
            }

            if (numero == 9)
            {
                _numeroRomano = "IX";
                return;
            }

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