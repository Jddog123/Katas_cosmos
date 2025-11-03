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

        [Fact]
        public void Si_SolicitaActividadRealizarYLaHoraActualSonLasOchoAM_Debe_RetornarDesayunar()
        {
            //Arrange
            RutinaPersonalizada rutina = new RutinaPersonalizada();
            //Act
            string Actividad = rutina.ActividadRealizar(new TimeSpan(8, 0, 0));
            //Assert
            Actividad.Should().BeEquivalentTo("Desayunar");
        }

        [Fact]
        public void Si_SolicitaActividadRealizarYLaHoraActualSonLasSeisYCincuentaYNueveMinutosConCincuentaYNueveSegundosAM_Debe_RetornarHacerEjecicio()
        {
            //Arrange
            RutinaPersonalizada rutina = new RutinaPersonalizada();
            //Act
            string Actividad = rutina.ActividadRealizar(new TimeSpan(6, 59, 59));
            //Assert
            Actividad.Should().BeEquivalentTo("Hacer ejercicio");
        }

        [Fact]
        public void Si_SolicitaActividadRealizarYLaHoraActualSonLasSieteYCincuentaYNueveMinutosConCincuentaYNueveSegundosAM_Debe_RetornarLeerYEstudiar()
        {
            //Arrange
            RutinaPersonalizada rutina = new RutinaPersonalizada();
            //Act
            string Actividad = rutina.ActividadRealizar(new TimeSpan(7, 59, 59));
            //Assert
            Actividad.Should().BeEquivalentTo("Leer y estudiar");
        }

        [Fact]
        public void Si_SolicitaActividadRealizarYLaHoraActualSonLasOchoYCincuentaYNueveMinutosConCincuentaYNueveSegundosAM_Debe_RetornarDesayunar()
        {
            //Arrange
            RutinaPersonalizada rutina = new RutinaPersonalizada();
            //Act
            string Actividad = rutina.ActividadRealizar(new TimeSpan(8, 59, 59));
            //Assert
            Actividad.Should().BeEquivalentTo("Desayunar");
        }
    }

    internal class RutinaPersonalizada
    {
        private readonly List<Actividad> _listaActividades;
        public RutinaPersonalizada()
        {
            _listaActividades = new List<Actividad> {
                new Actividad("Hacer Ejercicio", new TimeSpan(6, 0, 0), new TimeSpan(6, 59, 59)),
                new Actividad("Leer y estudiar", new TimeSpan(7, 0, 0), new TimeSpan(7, 59, 59)),
                new Actividad("Desayunar", new TimeSpan(8, 0, 0), new TimeSpan(8, 59, 59))
            };
        }
        public string ActividadRealizar(TimeSpan horaActual)
        {
            Actividad actividadRealizar = _listaActividades.FirstOrDefault(act => act.ActividadEnHorario(horaActual));

            return actividadRealizar.ObtenerNombreActividadEnHorario();
        }
    }

    internal class Actividad
    {
        private string _nombreActividad;
        private TimeSpan _horaInicial;
        private TimeSpan _horaFinal;
        public Actividad(string NombreActividad, TimeSpan HoraInicial, TimeSpan HoraFinal) 
        {
            _nombreActividad = NombreActividad;
            _horaInicial = HoraInicial;
            _horaFinal = HoraFinal;
        }

        public bool ActividadEnHorario(TimeSpan HoraActual)
        {
            return HoraActual >= _horaInicial && HoraActual <= _horaFinal;
        }

        public string ObtenerNombreActividadEnHorario()
        {
            return _nombreActividad;
        }
    }
}