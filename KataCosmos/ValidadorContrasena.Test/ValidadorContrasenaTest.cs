using FluentAssertions;

namespace ValidadorContrasena
{
    public class ValidadorContrasenaTest
    {
        [Fact]
        public void Si_ContrasenaNoTieneOchoCaracteres_Debe_RetornarFalse()
        {
            //Arrange
            string Contrasena = "Daniel123";
            //Act
            bool Resultado = ValidadorContrasena(Contrasena);
            //Assert
            Resultado.Should().BeFalse();
        }

        [Fact]
        public void Si_ContrasenaTieneOchoCaracteres_Debe_RetornarTrue()
        {
            //Arrange
            string Contrasena = "Daniel12";
            //Act
            bool Resultado = ValidadorContrasena(Contrasena);
            //Assert
            Resultado.Should().BeTrue();
        }

        [Fact]
        public void Si_ContrasenaNoTieneAlmenosUnaLetraMayuscula_Debe_RetornarFalse()
        {
            //Arrange
            string Contrasena = "daniel12";
            //Act
            bool Resultado = ValidadorContrasena(Contrasena);
            //Assert
            Resultado.Should().BeFalse();
        }

        [Fact]
        public void Si_ContrasenaNoTieneAlmenosUnaLetraMinuscula_Debe_RetornarFalse()
        {
            //Arrange
            string Contrasena = "DANIEL12";
            //Act
            bool Resultado = ValidadorContrasena(Contrasena);
            //Assert
            Resultado.Should().BeFalse();
        }

        [Fact]
        public void Si_ContrasenaNoTieneAlmenosUnNumero_Debe_RetornarFalse()
        {
            //Arrange
            string Contrasena = "Danielll";
            //Act
            bool Resultado = ValidadorContrasena(Contrasena);
            //Assert
            Resultado.Should().BeFalse();
        }

        [Fact]
        public void Si_ContrasenaNoTieneAlmenosUnGuionBajo_Debe_RetornarFalse()
        {
            //Arrange
            string Contrasena = "Daniel1";
            //Act
            bool Resultado = ValidadorContrasena(Contrasena);
            //Assert
            Resultado.Should().BeFalse();
        }

        [Fact]
        public void Si_ContrasenaTieneOchoCaracteresYUnaLetraMayusculaYUnaLetraMinusculaYUnNumeroYUnGuionBajo_Debe_RetornarTrue()
        {
            //Arrange
            string Contrasena = "Daniel1_";
            //Act
            bool Resultado = ValidadorContrasena(Contrasena);
            //Assert
            Resultado.Should().BeTrue();
        }

        private bool ValidadorContrasena(string contrasena)
        {
            if (contrasena.Length != 8 && !contrasena.Contains('_'))
                return false;
            else if (contrasena.Any(char.IsUpper) == false)
                return false;
            else if (contrasena.Any(char.IsLower) == false)
                return false;
            if (!contrasena.Any(char.IsDigit))
                return false;

            return true;
        }
    }
}