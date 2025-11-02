
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
        private int _numeroRecibido;
        public void Convertir(int numero)
        {
            _numeroRecibido = numero;
        }

        public string ObtenerNumeroRomano()
        {
            if (_numeroRecibido == 2)
                return "II";
            return "I";
        }
    }
}