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

        private bool ValidadorContrasena(string contrasena)
        {
            if(contrasena.Any(char.IsUpper) == false)
                return false;
            else if (contrasena.Length == 8)
                return true;
            return false;
        }
    }
}