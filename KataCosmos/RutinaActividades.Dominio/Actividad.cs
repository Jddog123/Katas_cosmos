namespace RutinaActividades.Dominio
{
    public class Actividad
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

        public TimeSpan ObtenerHoraInicialActividad()
        {
            return _horaInicial;
        }

        public TimeSpan ObtenerHoraFinalActividad()
        {
            return _horaFinal;
        }
    }
}