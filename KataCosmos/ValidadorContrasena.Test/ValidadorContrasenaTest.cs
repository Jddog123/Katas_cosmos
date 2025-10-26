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
            Resultado.Should().BeTrue();
        }

        private bool ValidadorContrasena(string contrasena)
        {
            throw new NotImplementedException();
        }
    }
}