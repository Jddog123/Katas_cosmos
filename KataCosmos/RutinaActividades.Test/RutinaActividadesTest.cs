using FluentAssertions;
using RutinaActividades.Dominio;

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

        [Fact]
        public void Si_SolicitaActividadRealizarYLaHoraActualEstaAntesDeLasSeisAM_Debe_RetornarSinActividad()
        {
            //Arrange
            RutinaPersonalizada rutina = new RutinaPersonalizada();
            //Act
            string Actividad = rutina.ActividadRealizar(new TimeSpan(5, 59, 59));
            //Assert
            Actividad.Should().BeEquivalentTo(RutinaPersonalizada.SIN_ACTIVIDAD);
        }

        [Fact]
        public void Si_SolicitaActividadRealizarYLaHoraActualEstaDespuesDeLasOchoYcincuentanueveMinutosConCincuentayNueveSegundosAM_Debe_RetornarSinActividad()
        {
            //Arrange
            RutinaPersonalizada rutina = new RutinaPersonalizada();
            //Act
            string Actividad = rutina.ActividadRealizar(new TimeSpan(9, 0, 0));
            //Assert
            Actividad.Should().BeEquivalentTo(RutinaPersonalizada.SIN_ACTIVIDAD);
        }

        [Fact]
        public void Si_SolicitaEliminarActividadDucharse_Debe_RetornarExcepcion()
        {
            //Arrange
            RutinaPersonalizada rutina = new RutinaPersonalizada();
            //Act
            var resultado =  () => rutina.EliminarActividad("Ducharse");
            //Assert
            resultado.Should().ThrowExactly<ArgumentException>("Actividad Ducharse no programada");
        }
    }
}