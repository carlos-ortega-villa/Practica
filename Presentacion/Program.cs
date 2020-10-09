using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;

namespace Presentacion
{
    class Program
    {
        static void Main(string[] args)
        {

            {
                LiquidarImpuesto liquidarImpuesto = new LiquidarImpuesto()
                {
                    Ingreso = 600000,
                    FechaPlazo = Convert.ToDateTime("8/10/2020"),
                    FechaDeclaracion = Convert.ToDateTime("8/10/2020")

                };

                Console.WriteLine(liquidarImpuesto.CalculoDiasExtemporaneidad());

                liquidarImpuesto.CalcularLiquidacion("NO");

                Console.WriteLine(liquidarImpuesto.ValorImpuestoTotal);


                Console.ReadKey();
            }

        }
    }
}
