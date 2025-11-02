
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
            numerosRomanos.ObtenerNumeroRomano().Should().Equals("I");
        }
    }

    public class NumerosRomanos()
    {
        public void Convertir(int numero)
        {
            throw new NotImplementedException();
        }

        public string ObtenerNumeroRomano()
        {
            throw new NotImplementedException();
        }
    }
}