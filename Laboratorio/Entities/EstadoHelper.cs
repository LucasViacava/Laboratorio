namespace Laboratorio.Entities
{
    public class EstadoHelper
    {
        public enum EEstado
        {
            Pendiente,
            EnPreparacion,
            Cancelado, 
            Finalizado
        }

        private static readonly Dictionary<EEstado, String> EstadoToString = new Dictionary<EEstado, string>
        {
            { EEstado.Pendiente, "Pendiente" },
            { EEstado.EnPreparacion, "En Preparación" },
            { EEstado.Cancelado, "Cancelado" },
            { EEstado.Finalizado, "Finalizado" }
        };

        public static string GetEstadoAsString(EEstado estado)
        {
            return EstadoToString[estado];
        }
    }
}
