
using FluentAssertions;
using NumerosRomanos.Dominio;

namespace NumerosRomanos.Test
{
    public class NumerosRomanosTest
    {
        NumerosRomanosDominio numerosRomanos;
        public NumerosRomanosTest()
        {
            numerosRomanos = new NumerosRomanosDominio();
        }

        [Theory]
        [InlineData(1,"I")]
        [InlineData(2, "II")]
        [InlineData(3, "III")]
        [InlineData(6, "VI")]
        [InlineData(7, "VII")]
        [InlineData(8, "VIII")]
        [InlineData(11, "XI")]
        [InlineData(12, "XII")]
        [InlineData(13, "XIII")]
        public void Si_NumeroContieneUnoDosOTres_Debe_RetornarIParaRepresentarCadaUnidad(int numero, string numeroRomanoEsperado)
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
        public void Si_NumeroContieneCuatro_Debe_RetornarIVParaRepresentarlo(int numero, string numeroRomanoEsperado)
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
        public void Si_NumeroContieneCinco_Debe_RetornarVParaRepresentarlo(int numero, string numeroRomanoEsperado)
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
        public void Si_NumeroContieneNueve_Debe_RetornarIXParaRepresentarlo(int numero, string numeroRomanoEsperado)
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
        public void Si_NumeroDiexVeinteYTreinta_Debe_RetornarXParaRepresentarlo(int numero, string numeroRomanoEsperado)
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

        [Theory]
        [InlineData(90, "XC")]
        [InlineData(91, "XCI")]
        [InlineData(92, "XCII")]
        [InlineData(97, "XCVII")]
        [InlineData(99, "XCIX")]
        public void Si_NumeroContieneNoventa_Debe_RetornarXCParaRepresentarlo(int numero, string numeroRomanoEsperado)
        {
            //Act
            numerosRomanos.Convertir(numero);
            //Assert
            numerosRomanos.ObtenerNumeroRomano().Should().BeEquivalentTo(numeroRomanoEsperado);
        }

        [Theory]
        [InlineData(100, "C")]
        [InlineData(101, "CI")]
        [InlineData(102, "CII")]
        [InlineData(107, "CVII")]
        [InlineData(109, "CIX")]
        public void Si_NumeroContieneCien_Debe_RetornarCParaRepresentarlo(int numero, string numeroRomanoEsperado)
        {
            //Act
            numerosRomanos.Convertir(numero);
            //Assert
            numerosRomanos.ObtenerNumeroRomano().Should().BeEquivalentTo(numeroRomanoEsperado);
        }

        [Theory]
        [InlineData(500, "D")]
        [InlineData(501, "DI")]
        [InlineData(502, "DII")]
        [InlineData(507, "DVII")]
        [InlineData(509, "DIX")]
        public void Si_NumeroContieneQuinientos_Debe_RetornarDParaRepresentarlo(int numero, string numeroRomanoEsperado)
        {
            //Act
            numerosRomanos.Convertir(numero);
            //Assert
            numerosRomanos.ObtenerNumeroRomano().Should().BeEquivalentTo(numeroRomanoEsperado);
        }

        [Theory]
        [InlineData(900, "CM")]
        [InlineData(901, "CMI")]
        [InlineData(902, "CMII")]
        [InlineData(907, "CMVII")]
        [InlineData(909, "CMIX")]
        public void Si_NumeroContieneNovecientos_Debe_RetornarCMParaRepresentarlo(int numero, string numeroRomanoEsperado)
        {
            //Act
            numerosRomanos.Convertir(numero);
            //Assert
            numerosRomanos.ObtenerNumeroRomano().Should().BeEquivalentTo(numeroRomanoEsperado);
        }
    }
}