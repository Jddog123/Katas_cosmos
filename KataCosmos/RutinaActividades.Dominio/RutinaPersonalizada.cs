namespace RutinaActividades.Dominio
{
    public class RutinaPersonalizada
    {
        public const string SIN_ACTIVIDAD = "Sin actividad";
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

            return actividadRealizar != null ? actividadRealizar.ObtenerNombreActividadEnHorario() : SIN_ACTIVIDAD;
        }

        public void AgregarActividad(Actividad actividad)
        {
            bool existeActividad = ExisteActividadEnHorario(actividad);

            if (existeActividad)
                throw new ArgumentException("Ya existe una actividad programada en ese horario");

            if(actividad.ObtenerHoraInicialActividad() == new TimeSpan(10, 0, 0))
                _listaActividades.Add(new Actividad("Ducharse", new TimeSpan(10, 0, 0), new TimeSpan(10, 30, 0)));

            _listaActividades.Add(new Actividad("Ducharse", new TimeSpan(9, 0, 0), new TimeSpan(9, 30, 0)));
        }

        public void EliminarActividad(string Actividad)
        {
            int actividadEliminada = _listaActividades.RemoveAll(act => act.ObtenerNombreActividadEnHorario().Equals(Actividad));

            if(actividadEliminada == 0)
                throw new ArgumentException($"Actividad {Actividad} no programada");
        }

        private bool ExisteActividadEnHorario(Actividad actividad)
        {
            return _listaActividades.Any(act => act.ActividadEnHorario(actividad.ObtenerHoraInicialActividad()) || act.ActividadEnHorario(actividad.ObtenerHoraFinalActividad()));
        }
    }
}