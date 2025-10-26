using FluentAssertions;
using ValidadorContrasena.Dominio;
using ValidadorContrasena.Dominio.Enum;

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
        public void Si_ContrasenaNoTieneMasDeOchoCaracteres_Debe_RetornarFalse()
        {
            //Arrange
            string Contrasena = "Daniel1";
            //Act
            bool Resultado = validadorContrasena.EsValida(Contrasena);
            //Assert
            Resultado.Should().BeFalse();
        }

        [Fact]
        public void Si_ContrasenaNoTieneAlmenosUnaLetraMayuscula_Debe_RetornarFalse()
        {
            //Arrange
            string Contrasena = "Daniel123";
            //Act
            bool Resultado = validadorContrasena.EsValida(Contrasena);
            //Assert
            Resultado.Should().BeFalse();
        }

        [Fact]
        public void Si_ContrasenaNoTieneAlmenosUnaLetraMinuscula_Debe_RetornarFalse()
        {
            //Arrange
            string Contrasena = "DANIEL123";
            //Act
            bool Resultado = validadorContrasena.EsValida(Contrasena);
            //Assert
            Resultado.Should().BeFalse();
        }

        [Fact]
        public void Si_ContrasenaNoTieneAlmenosUnNumero_Debe_RetornarFalse()
        {
            //Arrange
            string Contrasena = "Daniellll";
            //Act
            bool Resultado = validadorContrasena.EsValida(Contrasena);
            //Assert
            Resultado.Should().BeFalse();
        }

        [Fact]
        public void Si_ContrasenaNoTieneAlmenosUnGuionBajo_Debe_RetornarFalse()
        {
            //Arrange
            string Contrasena = "Daniel1234";
            //Act
            bool Resultado = validadorContrasena.EsValida(Contrasena);
            //Assert
            Resultado.Should().BeFalse();
        }

        [Theory]
        [InlineData("Daniel123_")]
        [InlineData("daNiel123_")]
        [InlineData("Dan_iel123")]
        [InlineData("123Da_niel")]
        public void Si_ContrasenaTieneMasDeOchoCaracteresYUnaLetraMayusculaYUnaLetraMinusculaYUnNumeroYUnGuionBajo_Debe_RetornarTrue(string Contrasena)
        {
            //Act
            bool Resultado = validadorContrasena.EsValida(Contrasena);
            //Assert
            Resultado.Should().BeTrue();
        }

        [Fact]
        public void Si_ContrasenaTieneMasDeSeisCaracteresYUnaLetraMayusculaYUnaLetraMinusculaYUnNumero_Debe_RetornarTrue()
        {
            //Arrange
            string Contrasena = "Dani123";
            //Act
            bool Resultado = validadorContrasena.EsValida(Contrasena, TipoValidacion.Segunda);
            //Assert
            Resultado.Should().BeTrue();
        }

        [Fact]
        public void Si_ContrasenaTieneMasDeDieciseisCaracteresYUnaLetraMayusculaYUnaLetraMinusculaYUnGuionBajo_Debe_RetornarTrue()
        {
            //Arrange
            string Contrasena = "Danielabcdefghijklmn_";
            //Act
            bool Resultado = validadorContrasena.EsValida(Contrasena, TipoValidacion.Tercera);
            //Assert
            Resultado.Should().BeTrue();
        }

        [Fact]
        public void Si_ContrasenaTieneSegundoGrupoReglas_Debe_ValidarSegunSegundoGrupoDeReglas()
        {
            //Arrange
            string Contrasena = "Daniel1";
            IContrasenaValidador validator = new SegundoGrupoReglas();
            //Act
            bool Resultado = validator.EsValida(Contrasena);
            //Assert
            Resultado.Should().BeTrue();
        }

        [Fact]
        public void Si_ContrasenaTieneTercerGrupoReglas_Debe_ValidarSegunTercerGrupoDeReglas()
        {
            //Arrange
            string Contrasena = "Danielabcdefghijeeeeee_";
            IContrasenaValidador validator = new TercerGrupoReglas();
            //Act
            bool Resultado = validator.EsValida(Contrasena);
            //Assert
            Resultado.Should().BeTrue();
        }
    }

    internal class TercerGrupoReglas : IContrasenaValidador
    {
        public bool EsValida(string contrasena)
        {
            return new Validador().EsValida(contrasena, TipoValidacion.Tercera);
        }
    }
}