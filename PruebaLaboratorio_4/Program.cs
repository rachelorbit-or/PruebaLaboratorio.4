using BibliotecaFacturacionTaller;

namespace PruebaLaboratorio_4
{
    internal class Program
    {
        static void RegistrarAtencion()
        {
            Console.WriteLine("PLACA:");
            string placa = Console.ReadLine();
            Console.WriteLine("PROPIETARIO:");
            string propietario = Console.ReadLine();
            Console.WriteLine("TIPO DE SERVICIO (PREVENTIVO/CORRECTIVO/OTRO):");
            string tipo = Console.ReadLine();
            Console.WriteLine("ES CLIENTE FRECUENTE? (SI/NO):");
            string frecuente = Console.ReadLine();

            DateTime fecha = DateTime.Now;

            decimal tarifa = ModuloTaller.ObtenerTarifaBase(tipo);
            decimal descuento = ModuloTaller.CalcularDescuentoCliente(tarifa, frecuente);
            decimal igv = ModuloTaller.CalcularImpuestoIGV(tarifa - descuento);
            decimal total = ModuloTaller.CalcularTotalPagar(tarifa, descuento, igv);

            Console.WriteLine("total: " + total);
            string nuevoregistro = ModuloTaller.ConstruirRegistroPipe(placa, propietario, tipo, total, fecha);
            ModuloArchivo.GuardarAtencion(nuevoregistro);
            Console.WriteLine("atencion registrada!");
        }

        static void Main(string[] args)
        {
            int opcion = 0;
            while (opcion != 4)
            {
                Console.WriteLine("//////////////////////////////////////");
                Console.WriteLine("    TALLER MECÁNICO - FACTURACIÓN");
                Console.WriteLine("======================================");
                Console.WriteLine("1. Registrar atencion");
                Console.WriteLine("2. Buscar atencion por placa");
                Console.WriteLine("3. Reporte general de atenciones");
                Console.WriteLine("4. Salir");
                try
                {
                    opcion = int.Parse(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            RegistrarAtencion();
                            break;
                        case 2:
                            Console.WriteLine("PLACA A BUSCAR:");
                            string placaBuscada = Console.ReadLine();
                            ModuloArchivo.BuscarAtencion(placaBuscada);
                            break;
                        case 3:
                            ModuloArchivo.ListarTodasLasAtenciones();
                            break;
                        case 4:
                            Console.WriteLine("hasta luego");
                            break;
                        default:
                            Console.WriteLine("opcion no valida");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: debes escribir un número del 1 al 4.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error: " + ex.Message);
                }
            }
        }
    }
}