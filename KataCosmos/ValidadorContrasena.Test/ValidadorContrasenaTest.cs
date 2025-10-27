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

        [Theory]
        [InlineData(TipoValidacion.Primera, "Dani123", 8)]
        [InlineData(TipoValidacion.Segunda, "Dan12", 6)]
        [InlineData(TipoValidacion.Tercera, "Daniel12345", 16)]
        public void Si_ContrasenaNoTieneMasDeNCaracteresSegunTipoValidacion_Debe_RetornarMensajeCausaSegunNCaracteres(TipoValidacion tipoValidacion, string Contrasena, int minimoCaracteres)
        {
            //Arrange
            ContrasenaValidador validator = ContrasenaValidadorFactory.CrearFactory(tipoValidacion);
            //Act
            ContrasenaValidadorResultado Resultado = validator.EsValida(Contrasena);
            //Assert
            Resultado.Errores.Should().NotBeNull();
            Resultado.Errores.Should().NotBeEmpty();
            Resultado.Errores.Should().Contain($"Debe tener mas de {minimoCaracteres} caracteres");
        }

        [Fact]
        public void Si_ContrasenaNoTieneAlmenosUnaLetraMayuscula_Debe_RetornarMensajeCausa()
        {
            //Arrange
            string Contrasena = "daniel123";
            ContrasenaValidador validator = ContrasenaValidadorFactory.CrearFactory(TipoValidacion.Primera);
            //Act
            ContrasenaValidadorResultado Resultado = validator.EsValida(Contrasena);
            //Assert
            Resultado.Errores.Should().NotBeNull();
            Resultado.Errores.Should().NotBeEmpty();
            Resultado.Errores.Should().Contain("Debe tener al menos una letra mayuscula");
        }

        [Fact]
        public void Si_ContrasenaNoTieneAlmenosUnaLetraMinuscula_Debe_RetornarMensajeCausa()
        {
            //Arrange
            string Contrasena = "DANIEL123";
            ContrasenaValidador validator = ContrasenaValidadorFactory.CrearFactory(TipoValidacion.Primera);
            //Act
            ContrasenaValidadorResultado Resultado = validator.EsValida(Contrasena);
            //Assert
            Resultado.Errores.Should().NotBeNull();
            Resultado.Errores.Should().NotBeEmpty();
            Resultado.Errores.Should().Contain("Debe tener al menos una letra minuscula");
        }

        [Fact]
        public void Si_ContrasenaNoTieneAlmenosUnNumero_Debe_RetornarMensajeCausa()
        {
            //Arrange
            string Contrasena = "Daniellll";
            ContrasenaValidador validator = ContrasenaValidadorFactory.CrearFactory(TipoValidacion.Primera);
            //Act
            ContrasenaValidadorResultado Resultado = validator.EsValida(Contrasena);
            //Assert
            Resultado.Errores.Should().NotBeNull();
            Resultado.Errores.Should().NotBeEmpty();
            Resultado.Errores.Should().Contain("Debe tener al menos una número");
        }

        [Fact]
        public void Si_ContrasenaNoTieneAlmenosUnGuionBajo_Debe_RetornarMensajeCausa()
        {
            //Arrange
            string Contrasena = "Daniel1234";
            ContrasenaValidador validator = ContrasenaValidadorFactory.CrearFactory(TipoValidacion.Primera);
            //Act
            ContrasenaValidadorResultado Resultado = validator.EsValida(Contrasena);
            //Assert
            Resultado.Errores.Should().NotBeNull();
            Resultado.Errores.Should().NotBeEmpty();
            Resultado.Errores.Should().Contain("Debe tener al menos un guion bajo");
        }

        [Theory]
        [InlineData("daniel123", "Debe tener al menos una letra mayuscula", "Debe tener al menos un guion bajo")]
        [InlineData("DANIELLL_", "Debe tener al menos una letra minuscula", "Debe tener al menos una número")]
        [InlineData("da", "Debe tener mas de 8 caracteres", "Debe tener al menos una letra mayuscula", "Debe tener al menos una número", "Debe tener al menos un guion bajo")]
        public void Si_ContrasenaEsInvalida_Debe_RetornarListaConMensajesDeCausa(string Contrasena, params string[] validacionesEsparadas)
        {
            //Arrange
            ContrasenaValidador validator = ContrasenaValidadorFactory.CrearFactory(TipoValidacion.Primera);
            //Act
            ContrasenaValidadorResultado Resultado = validator.EsValida(Contrasena);
            //Assert
            Resultado.Errores.Should().NotBeNull();
            Resultado.Errores.Should().NotBeEmpty();
            Resultado.Errores.Should().BeEquivalentTo(validacionesEsparadas);
        }
    }
}