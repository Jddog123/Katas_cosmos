
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
            if(_numeroRecibido == 2)
                return "II";
            return "I";
        }
    }
}