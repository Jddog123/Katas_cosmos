using FluentAssertions;

namespace RutinaActividades.Test
{
    public class RutinaActividadesTest
    {
        [Fact]
        public void Si_SolicitaActividadRealizarYLaHoraActualEstaEntreSeisYSeisYcincuentaNueveAM_Debe_RetornarHacerEjecicio()
        {
            //Arrange
            TimeSpan horaInicial = new TimeSpan(6, 0, 0);
            TimeSpan horaFinal = new TimeSpan(6, 59, 59);
            RutinaActividad rutina = new RutinaPersonalizada();
            //Act
            string Actividad = rutina.ActidadRealizar(horaInicial, horaFinal);
            //Assert
            Actividad.Should().BeEquivalentTo("Hacer ejercicio");
        }
    }

    internal class RutinaPersonalizada : RutinaActividad
    {
        public string ActidadRealizar(TimeSpan horaInicial, TimeSpan horaFinal)
        {
            throw new NotImplementedException();
        }
    }

    interface RutinaActividad
    {
        string ActidadRealizar(TimeSpan horaInicial, TimeSpan horaFinal);
    }
}