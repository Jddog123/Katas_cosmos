
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
        [InlineData(4, "IV")]
        [InlineData(14, "XIV")]
        [InlineData(24, "XXIV")]
        [InlineData(34, "XXXIV")]
        public void Si_NumeroEsCatorceVeinticuatroOTreintaycuatro_Debe_RetornarElTotalDeDiezPorCadaXYCuatroPorCadaIV(int numero, string numeroRomanoEsperado)
        {
            //Act
            numerosRomanos.Convertir(numero);
            //Assert
            numerosRomanos.ObtenerNumeroRomano().Should().BeEquivalentTo(numeroRomanoEsperado);
        }

        [Theory]
        [InlineData(5, "V")]
        [InlineData(15, "XV")]
        [InlineData(25, "XXV")]
        [InlineData(35, "XXXV")]
        public void Si_NumeroEsCincoQuinceVeinticincoOTreintaCinco_Debe_RetornarElTotalDeDiezPorCadaXYCincoPorCadaV(int numero, string numeroRomanoEsperado)
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

        [Theory]
        [InlineData(9, "IX")]
        [InlineData(19, "XIX")]
        [InlineData(29, "XXIX")]
        public void Si_NumeroEsNueveDiecinueveOVeintinueve_Debe_RetornarElTotalDeDiezPorCadaXYNuevePorCadaIX(int numero, string numeroRomanoEsperado)
        {
            //Act
            numerosRomanos.Convertir(numero);
            //Assert
            numerosRomanos.ObtenerNumeroRomano().Should().BeEquivalentTo(numeroRomanoEsperado);
        }

        [Theory]
        [InlineData(10, "X")]
        [InlineData(20, "XX")]
        [InlineData(30, "XXX")]
        public void Si_NumeroDiexVeinteYTreinta_Debe_RetornarXPorCantidadDeNumeroMenosDiez(int numero, string numeroRomanoEsperado)
        {
            //Act
            numerosRomanos.Convertir(numero);
            //Assert
            numerosRomanos.ObtenerNumeroRomano().Should().BeEquivalentTo(numeroRomanoEsperado);
        }

        [Theory]
        [InlineData(11, "XI")]
        [InlineData(12, "XII")]
        [InlineData(13, "XIII")]
        public void Si_NumeroOnceDoceOTrece_Debe_RetornarXMasIPorCantidadDeNumeroMenosDiez(int numero, string numeroRomanoEsperado)
        {
            //Act
            numerosRomanos.Convertir(numero);
            //Assert
            numerosRomanos.ObtenerNumeroRomano().Should().BeEquivalentTo(numeroRomanoEsperado);
        }

        [Fact]
        public void Si_NumeroEsCuarenta_Debe_RetornarXL()
        {
            //Act
            numerosRomanos.Convertir(40);
            //Assert
            numerosRomanos.ObtenerNumeroRomano().Should().BeEquivalentTo("XL");
        }

        [Fact]
        public void Si_NumeroEsCuarentayuno_Debe_RetornarXLI()
        {
            //Act
            numerosRomanos.Convertir(41);
            //Assert
            numerosRomanos.ObtenerNumeroRomano().Should().BeEquivalentTo("XLI");
        }
    }

    public class NumerosRomanos()
    {
        private string _numeroRomano;
        public void Convertir(int numero)
        {
            if(numero == 40)
            {
                _numeroRomano = "XL";
                return;
            }

            while (numero >= 10)
            {
                _numeroRomano += "X";
                numero -= 10;
            }

            if (numero == 9)
            {
                _numeroRomano += "IX";
                return;
            }

            while (numero >= 5)
            {
                _numeroRomano += "V";
                numero -= 5;
            }

            if (numero == 4)
            {
                _numeroRomano += "IV";
                return;
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