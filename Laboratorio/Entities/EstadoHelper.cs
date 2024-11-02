namespace Laboratorio.Entities
{
    public class EstadoHelper
    {
        public enum EEstado
        {
            Pendiente,
            EnPreparacion,
            Entregado,
            Cancelado, 
            Finalizado
        }

        private static readonly Dictionary<EEstado, String> EstadoToString = new Dictionary<EEstado, string>
        {
            { EEstado.Pendiente, "Pendiente" },
            { EEstado.EnPreparacion, "En Preparación" },
            { EEstado.Entregado, "Entregado" },
            { EEstado.Cancelado, "Cancelado" },
            { EEstado.Finalizado, "Finalizado" }
        };

        private static readonly Dictionary<EEstado, EEstado?> EstadoTransiciones = new Dictionary<EEstado, EEstado?>
        {
            { EEstado.Pendiente, EEstado.EnPreparacion },
            { EEstado.EnPreparacion, EEstado.Entregado },
            { EEstado.Entregado, EEstado.Finalizado },
            { EEstado.Cancelado, null },
            { EEstado.Finalizado, null }
        };

        public static EEstado? GetEstadoFromString(string estado)
        {
            return EstadoToString.FirstOrDefault(e => e.Value.Equals(estado, StringComparison.OrdinalIgnoreCase)).Key;
        }

        public static EEstado? GetNextEstado(EEstado estado)
        {
            return EstadoTransiciones.ContainsKey(estado) ? EstadoTransiciones[estado] : null;
        }

        public static string GetEstadoAsString(EEstado estado)
        {
            return EstadoToString[estado];
        }
    }
}
