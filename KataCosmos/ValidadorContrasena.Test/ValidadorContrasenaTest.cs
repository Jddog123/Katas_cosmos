using FluentAssertions;
using ValidadorContrasena.Test.Dominio;

namespace ValidadorContrasenaTest
{
    public class ValidadorContrasenaTest
    {
        Validador validadorContrasena;
        public ValidadorContrasenaTest()
        {
            validadorContrasena = new Validador();
        }

        [Fact]
        public void Si_ContrasenaNoTieneOchoCaracteres_Debe_RetornarFalse()
        {
            //Arrange
            string Contrasena = "Daniel123";
            //Act
            bool Resultado = validadorContrasena.EsValida(Contrasena);
            //Assert
            Resultado.Should().BeFalse();
        }

        [Fact]
        public void Si_ContrasenaNoTieneAlmenosUnaLetraMayuscula_Debe_RetornarFalse()
        {
            //Arrange
            string Contrasena = "daniel12";
            //Act
            bool Resultado = validadorContrasena.EsValida(Contrasena);
            //Assert
            Resultado.Should().BeFalse();
        }

        [Fact]
        public void Si_ContrasenaNoTieneAlmenosUnaLetraMinuscula_Debe_RetornarFalse()
        {
            //Arrange
            string Contrasena = "DANIEL12";
            //Act
            bool Resultado = validadorContrasena.EsValida(Contrasena);
            //Assert
            Resultado.Should().BeFalse();
        }

        [Fact]
        public void Si_ContrasenaNoTieneAlmenosUnNumero_Debe_RetornarFalse()
        {
            //Arrange
            string Contrasena = "Danielll";
            //Act
            bool Resultado = validadorContrasena.EsValida(Contrasena);
            //Assert
            Resultado.Should().BeFalse();
        }

        [Fact]
        public void Si_ContrasenaNoTieneAlmenosUnGuionBajo_Debe_RetornarFalse()
        {
            //Arrange
            string Contrasena = "Daniel1";
            //Act
            bool Resultado = validadorContrasena.EsValida(Contrasena);
            //Assert
            Resultado.Should().BeFalse();
        }

        [Theory]
        [InlineData("Daniel1_")]
        [InlineData("daNiel1_")]
        [InlineData("Dan_iel1")]
        [InlineData("1Da_niel")]
        public void Si_ContrasenaTieneOchoCaracteresYUnaLetraMayusculaYUnaLetraMinusculaYUnNumeroYUnGuionBajo_Debe_RetornarTrue(string Contrasena)
        {
            //Act
            bool Resultado = validadorContrasena.EsValida(Contrasena);
            //Assert
            Resultado.Should().BeTrue();
        }
    }
}