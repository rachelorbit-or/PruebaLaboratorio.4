using System;
using System.Globalization;

namespace BibliotecaFacturacionTaller
{
    public static class ModuloTaller
    {
        public static decimal ObtenerTarifaBase(string tipoServicio)
        {
            switch (tipoServicio.Trim().ToUpper())
            {
                case "PREVENTIVO": return 180.00m;
                case "CORRECTIVO": return 320.00m;
                default: return 120.00m;
            }
        }

        public static decimal CalcularDescuentoCliente(decimal tarifaBase, string esFrecuente)
        {
            if (esFrecuente.Trim().ToUpper() == "SI")
                return tarifaBase * 0.15m;
            return 0m;
        }

        public static decimal CalcularImpuestoIGV(decimal tarifaBaseConDescuento)
        {
            return tarifaBaseConDescuento * 0.18m;
        }

        public static decimal CalcularTotalPagar(decimal tarifaBase, decimal descuento, decimal igv)
        {
            return tarifaBase - descuento + igv;
        }

        public static string ConstruirRegistroPipe(string placa, string propietario,
            string tipoServicio, decimal totalPagar, DateTime fecha)
        {
            string total = totalPagar.ToString("F2", CultureInfo.InvariantCulture);
            return placa + "|" + propietario + "|" + tipoServicio + "|" + total + "|" +
                   fecha.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}
