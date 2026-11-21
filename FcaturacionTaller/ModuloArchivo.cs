using System;
using System.Globalization;
using System.IO;

namespace BibliotecaFacturacionTaller
{
    public static class ModuloArchivo
    {
        private const string Ruta = "atenciones.txt";

        public static void GuardarAtencion(string linea)
        {
            File.AppendAllText(Ruta, linea + Environment.NewLine);
        }

        public static void BuscarAtencion(string placaBuscada)
        {
            if (!File.Exists(Ruta))
            {
                Console.WriteLine("Aun no hay atenciones registradas.");
                return;
            }

            bool encontrada = false;
            string[] lineas = File.ReadAllLines(Ruta);
            foreach (string linea in lineas)
            {
                string[] partes = linea.Split('|');
                if (partes[0].ToUpper() == placaBuscada.Trim().ToUpper())
                {
                    Console.WriteLine("Placa: " + partes[0] + " | Propietario: " + partes[1] +
                        " | Servicio: " + partes[2] + " | Total: S/ " + partes[3] +
                        " | Fecha: " + partes[4]);
                    encontrada = true;
                }
            }

            if (!encontrada)
                Console.WriteLine("No se encontro esa placa.");
        }

        public static void ListarTodasLasAtenciones()
        {
            if (!File.Exists(Ruta))
            {
                Console.WriteLine("Aun no hay atenciones registradas.");
                return;
            }

            decimal sumaTotal = 0;
            string[] lineas = File.ReadAllLines(Ruta);
            foreach (string linea in lineas)
            {
                string[] partes = linea.Split('|');
                Console.WriteLine("Placa: " + partes[0] + " | Propietario: " + partes[1] +
                    " | Servicio: " + partes[2] + " | Total: S/ " + partes[3] +
                    " | Fecha: " + partes[4]);
                sumaTotal += decimal.Parse(partes[3], CultureInfo.InvariantCulture);
            }

            Console.WriteLine("Total recaudado: S/ " + sumaTotal.ToString("F2"));
        }
    }
}