
using FluentAssertions;

namespace NumerosRomanos.Test
{
    public class NumerosRomanosTest
    {
        [Fact]
        public void Si_NumeroEsUno_Debe_RetornarI()
        {
            //Arrange
            int numero = 1;
            var numerosRomanos = new NumerosRomanos();
            //Act
            numerosRomanos.Convertir(numero);
            //Assert
            numerosRomanos.ObtenerNumeroRomano().Should().BeEquivalentTo("I");
        }

        [Fact]
        public void Si_NumeroEsDos_Debe_RetornarII()
        {
            //Arrange
            int numero = 2;
            var numerosRomanos = new NumerosRomanos();
            //Act
            numerosRomanos.Convertir(numero);
            //Assert
            numerosRomanos.ObtenerNumeroRomano().Should().BeEquivalentTo("II");
        }
    }

    public class NumerosRomanos()
    {
        public void Convertir(int numero)
        {
        }

        public string ObtenerNumeroRomano()
        {
            return "I";
        }
    }
}