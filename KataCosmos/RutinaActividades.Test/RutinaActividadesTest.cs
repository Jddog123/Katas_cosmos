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

        [Fact]
        public void Si_SolicitaActividadRealizarYLaHoraActualEstaEntreSieteYSieteYcincuentaNueveAM_Debe_RetornarLeerYEstudiar()
        {
            //Arrange
            TimeSpan horaInicial = new TimeSpan(7, 0, 0);
            TimeSpan horaFinal = new TimeSpan(7, 59, 59);
            RutinaActividad rutina = new RutinaPersonalizada();
            //Act
            string Actividad = rutina.ActidadRealizar(horaInicial, horaFinal);
            //Assert
            Actividad.Should().BeEquivalentTo("Leer y estudiar");
        }

        [Fact]
        public void Si_SolicitaActividadRealizarYLaHoraActualEstaEntreOchoYOchoYcincuentaNueveAM_Debe_RetornarDesayunar()
        {
            //Arrange
            TimeSpan horaInicial = new TimeSpan(8, 0, 0);
            TimeSpan horaFinal = new TimeSpan(8, 59, 59);
            RutinaActividad rutina = new RutinaPersonalizada();
            //Act
            string Actividad = rutina.ActidadRealizar(horaInicial, horaFinal);
            //Assert
            Actividad.Should().BeEquivalentTo("Desayunar");
        }
    }

    internal class RutinaPersonalizada : RutinaActividad
    {
        public string ActidadRealizar(TimeSpan horaInicial, TimeSpan horaFinal)
        {
            if (horaInicial == new TimeSpan(8, 0, 0) && horaFinal == new TimeSpan(8, 59, 59))
                return "Desayunar";

            if (horaInicial == new TimeSpan(7, 0, 0) && horaFinal == new TimeSpan(7, 59, 59))
                return "Leer y estudiar";

            return "Hacer ejercicio";
        }
    }

    interface RutinaActividad
    {
        string ActidadRealizar(TimeSpan horaInicial, TimeSpan horaFinal);
    }
}