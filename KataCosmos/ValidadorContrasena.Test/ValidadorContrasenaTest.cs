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
            //Arrange
            IContrasenaValidador validator = ContrasenaValidadorFactory.CrearFactory(TipoValidacion.Primera);
            bool Resultado = validator.EsValida(Contrasena);
            //Assert
            Resultado.Should().BeTrue();
        }

        [Theory]
        [InlineData("Dani123")]
        [InlineData("daNi123")]
        [InlineData("123Dani")]
        public void Si_ContrasenaTieneMasDeSeisCaracteresYUnaLetraMayusculaYUnaLetraMinusculaYUnNumero_Debe_RetornarTrue(string Contrasena)
        {
            //Arrange
            IContrasenaValidador validator = ContrasenaValidadorFactory.CrearFactory(TipoValidacion.Segunda);
            //Act
            bool Resultado = validator.EsValida(Contrasena);
            //Assert
            Resultado.Should().BeTrue();
        }

        [Theory]
        [InlineData("Danielabcdefghijklmn_")]
        [InlineData("danielAbcd_fghijklmn")]
        [InlineData("_Danielabcdefghijklmn")]
        public void Si_ContrasenaTieneMasDeDieciseisCaracteresYUnaLetraMayusculaYUnaLetraMinusculaYUnGuionBajo_Debe_RetornarTrue(string Contrasena)
        {
            //Arrange
            IContrasenaValidador validator = ContrasenaValidadorFactory.CrearFactory(TipoValidacion.Tercera);
            //Act
            bool Resultado = validator.EsValida(Contrasena);
            //Assert
            Resultado.Should().BeTrue();
        }

        [Fact]
        public void Si_ContrasenaTieneSegundoGrupoReglas_Debe_ValidarSegunSegundoGrupoDeReglas()
        {
            //Arrange
            string Contrasena = "Daniel1";
            IContrasenaValidador validator = ContrasenaValidadorFactory.CrearFactory(TipoValidacion.Segunda);
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
            IContrasenaValidador validator = ContrasenaValidadorFactory.CrearFactory(TipoValidacion.Tercera);
            //Act
            bool Resultado = validator.EsValida(Contrasena);
            //Assert
            Resultado.Should().BeTrue();
        }
    }
}