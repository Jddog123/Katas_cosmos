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
    }
}