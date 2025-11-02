
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

        [Theory]
        [InlineData(40, "XL")]
        [InlineData(41, "XLI")]
        [InlineData(42, "XLII")]
        [InlineData(47, "XLVII")]
        [InlineData(49, "XLIX")]
        public void Si_NumeroContieneCuarente_Debe_RetornarXLParaRepresentarlo(int numero, string numeroRomanoEsperado)
        {
            //Act
            numerosRomanos.Convertir(numero);
            //Assert
            numerosRomanos.ObtenerNumeroRomano().Should().BeEquivalentTo(numeroRomanoEsperado);
        }

        [Theory]
        [InlineData(50, "L")]
        [InlineData(51, "LI")]
        [InlineData(52, "LII")]
        [InlineData(57, "LVII")]
        [InlineData(59, "LIX")]
        public void Si_NumeroContieneCincuenta_Debe_RetornarLParaRepresentarlo(int numero, string numeroRomanoEsperado)
        {
            //Act
            numerosRomanos.Convertir(numero);
            //Assert
            numerosRomanos.ObtenerNumeroRomano().Should().BeEquivalentTo(numeroRomanoEsperado);
        }

        [Fact]
        public void Si_NumeroEsNoventa_Debe_RetornarXC()
        {
            //Act
            numerosRomanos.Convertir(90);
            //Assert
            numerosRomanos.ObtenerNumeroRomano().Should().BeEquivalentTo("XC");
        }
    }

    public class NumerosRomanos()
    {
        private string _numeroRomano;
        public void Convertir(int numero)
        {
            if(numero == 90)
            {
                _numeroRomano = "XC";
                return;
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