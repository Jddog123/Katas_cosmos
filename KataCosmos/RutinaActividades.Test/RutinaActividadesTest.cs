using FluentAssertions;

namespace RutinaActividades.Test
{
    public class RutinaActividadesTest
    {
        [Fact]
        public void Si_SolicitaActividadRealizarYLaHoraActualSonLasSeisAM_Debe_RetornarHacerEjecicio()
        {
            //Arrange
            RutinaPersonalizada rutina = new RutinaPersonalizada();
            //Act
            string Actividad = rutina.ActividadRealizar(new TimeSpan(6, 0, 0));
            //Assert
            Actividad.Should().BeEquivalentTo("Hacer ejercicio");
        }

        [Fact]
        public void Si_SolicitaActividadRealizarYLaHoraActualSonLasSieteAM_Debe_RetornarLeerYEstudiar()
        {
            //Arrange
            RutinaPersonalizada rutina = new RutinaPersonalizada();
            //Act
            string Actividad = rutina.ActividadRealizar(new TimeSpan(7, 0, 0));
            //Assert
            Actividad.Should().BeEquivalentTo("Leer y estudiar");
        }
    }

    internal class RutinaPersonalizada
    {
        public string ActividadRealizar(TimeSpan timeSpan)
        {
            return "Hacer Ejercicio";
        }
    }
}