using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ej3_infracciones
{
    class Program
    {

        static void PantallaIngresoActa(SistemaActas sistema)
        {
            Console.Clear();

            Console.WriteLine("Ingrese dni y nombre");
            int dni = Convert.ToInt32(Console.ReadLine());
            string nombre = Console.ReadLine();
            sistema.IniciarActa(dni, nombre);

            Console.WriteLine("Ingrese codigo infraccion(1 a 5 , 0 terminar)");
            int codigo = Convert.ToInt32(Console.ReadLine());
            while (codigo > 0)
            {
                double monto = sistema.RegistrarInfraccion(codigo);
                Console.WriteLine($"Monto de la infracción({codigo}): $ {monto:f2}");

                Console.WriteLine("Ingrese codigo infraccion(1 a 5 , 0 terminar)");
                codigo = Convert.ToInt32(Console.ReadLine());
            }
            sistema.FinalizarActa(true);
            Console.WriteLine("Total a pagar: {0:f2}", sistema.totalAPagar);

            Console.WriteLine("Presione una tecla para volver al menu");
            Console.ReadKey();
        }

        static void PantallaImprimirDia(SistemaActas sistema)
        {
            Console.Clear();

            Console.WriteLine("Recaudación: {0:f2}", sistema.Recaudacion);

            Console.WriteLine("Presione una tecla para volver al menu");
            Console.ReadKey();
        }

        static ConsoleKeyInfo PantallaMenu()
        {
            Console.Clear();
            Console.WriteLine("1- Registrar acta");
            Console.WriteLine("2- Consulta recaudación");
            Console.WriteLine("otro- salida");
            return Console.ReadKey();
        }
        static void Main(string[] args)
        {
            SistemaActas sis = new SistemaActas();

            #region pantalla de configuracion
            Console.Clear();
            Console.WriteLine("Iniciando sistema");
            Console.WriteLine("Ingrese el valor Base (litros nafta/$)");
            double montoBase = Convert.ToDouble(Console.ReadLine());
            sis.IniciarSistema(montoBase);
            #endregion

            ConsoleKeyInfo key;
            do
            {
                key=PantallaMenu();

                switch (key.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        {
                            #region pantalla de carga de acta
                            PantallaIngresoActa(sis);
                            #endregion
                        }
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        {
                            #region pantalla de carga de acta
                            PantallaImprimirDia(sis);
                            #endregion
                        }
                        break;
                }
            } while (key.Key!= ConsoleKey.D0 && key.Key != ConsoleKey.NumPad0);


        }
    }
}
