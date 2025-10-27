using FluentAssertions;
using FluentAssertions.Equivalency.Tracing;
using ValidadorContrasena.Dominio;
using ValidadorContrasena.Dominio.Enum;
using ValidadorContrasena.Dominio.Reglas;

namespace ValidadorContrasenaTest
{
    public class ValidadorContrasenaTest
    {
        [Theory]
        [InlineData(6, "Dan12")]
        [InlineData(8, "Dani123")]
        [InlineData(16, "Daniel12345")]
        public void Si_ContrasenaTieneMasNCaracteres_Debe_RetornarFalse(int LongitudValidar, string Contrasena)
        {
            //Act
            bool Resultado = new LongitudRegla(LongitudValidar).EsValida(Contrasena);
            //Assert
            Resultado.Should().BeFalse();
        }

        [Fact]
        public void Si_ContrasenaNoTieneAlmenosUnaLetraMayuscula_Debe_RetornarFalse()
        {
            //Arrange
            string Contrasena = "daniel123";
            //Act
            bool Resultado = new ContieneMayusculaRegla().EsValida(Contrasena);
            //Assert
            Resultado.Should().BeFalse();
        }

        [Fact]
        public void Si_ContrasenaNoTieneAlmenosUnaLetraMinuscula_Debe_RetornarFalse()
        {
            //Arrange
            string Contrasena = "DANIEL123";
            //Act
            bool Resultado = new ContieneMinusculaRegla().EsValida(Contrasena);
            //Assert
            Resultado.Should().BeFalse();
        }

        [Fact]
        public void Si_ContrasenaNoTieneAlmenosUnNumero_Debe_RetornarFalse()
        {
            //Arrange
            string Contrasena = "Daniellll";
            //Act
            bool Resultado = new ContieneNumeroRegla().EsValida(Contrasena);
            //Assert
            Resultado.Should().BeFalse();
        }

        [Fact]
        public void Si_ContrasenaNoTieneAlmenosUnGuionBajo_Debe_RetornarFalse()
        {
            //Arrange
            string Contrasena = "Daniel1234";
            //Act
            bool Resultado = new ContieneGuionBajoRegla().EsValida(Contrasena);
            //Assert
            Resultado.Should().BeFalse();
        }

        [Theory]
        [InlineData("Daniel123_")]
        [InlineData("daNiel123_")]
        [InlineData("Dan_iel123")]
        [InlineData("123Da_niel")]
        public void Si_ContrasenaEsValidaDeGrupoPrimero_Debe_RetornarTrue(string Contrasena)
        {
            //Arrange
            ContrasenaValidador validator = ContrasenaValidadorFactory.CrearFactory(TipoValidacion.Primera);
            ContrasenaValidadorResultado Resultado = validator.EsValida(Contrasena);
            //Assert
            Resultado.EsValida.Should().BeTrue();
        }

        [Theory]
        [InlineData("Dani123")]
        [InlineData("daNi123")]
        [InlineData("123Dani")]
        [InlineData("Daniel1")]
        public void Si_ContrasenaEsValidaDeGrupoSegundo_Debe_RetornarTrue(string Contrasena)
        {
            //Arrange
            ContrasenaValidador validator = ContrasenaValidadorFactory.CrearFactory(TipoValidacion.Segunda);
            //Act
            ContrasenaValidadorResultado Resultado = validator.EsValida(Contrasena);
            //Assert
            Resultado.EsValida.Should().BeTrue();
        }

        [Theory]
        [InlineData("Danielabcdefghijklmn_")]
        [InlineData("danielAbcd_fghijklmn")]
        [InlineData("_Danielabcdefghijklmn")]
        [InlineData("Danielabcdefghijeeeeee_")]
        public void Si_ContrasenaEsValidaDeGrupoTercero_Debe_RetornarTrue(string Contrasena)
        {
            //Arrange
            ContrasenaValidador validator = ContrasenaValidadorFactory.CrearFactory(TipoValidacion.Tercera);
            //Act
            ContrasenaValidadorResultado Resultado = validator.EsValida(Contrasena);
            //Assert
            Resultado.EsValida.Should().BeTrue();
        }

        [Fact]
        public void Si_NoSeEncuentraGrupoDeReglas_Debe_RetornarExcepcion()
        {
            //Act
            var resultado = () => ContrasenaValidadorFactory.CrearFactory();
            //Assert
            resultado.Should().ThrowExactly<Exception>("No se encontro el grupo de reglas");
        }

        [Fact]
        public void Si_ContrasenaNoTieneMasDeOchoCaracteres_Debe_RetornarMensajeCausa()
        {
            //Arrange
            string Contrasena = "Dani123";
            ContrasenaValidador validator = ContrasenaValidadorFactory.CrearFactory(TipoValidacion.Primera);
            //Act
            ContrasenaValidadorResultado Resultado = validator.EsValida(Contrasena);
            //Assert
            Resultado.Errores.Should().NotBeNull();
            Resultado.Errores.Should().NotBeEmpty();
            Resultado.Errores.Should().Contain("Debe tener mas de 8 caracteres");
        }

        [Fact]
        public void Si_ContrasenaNoTieneMasDeSeisCaracteres_Debe_RetornarMensajeCausa()
        {
            //Arrange
            string Contrasena = "Dan12";
            ContrasenaValidador validator = ContrasenaValidadorFactory.CrearFactory(TipoValidacion.Segunda);
            //Act
            ContrasenaValidadorResultado Resultado = validator.EsValida(Contrasena);
            //Assert
            Resultado.Errores.Should().NotBeNull();
            Resultado.Errores.Should().NotBeEmpty();
            Resultado.Errores.Should().Contain("Debe tener mas de 6 caracteres");
        }
    }
}