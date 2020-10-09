using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using BLL;

namespace Presentacion
{
     class Program
    {
        static void Main(string[] args)
        {

            LiquidarImpuestoService liquidarImpuestoService = new LiquidarImpuestoService();
            RespuestaConsulta respuestaConsulta = new RespuestaConsulta();
            Contribuyente contribuyente = new Contribuyente(1, "2",
            Convert.ToDateTime("10/10/2020"), Convert.ToDateTime("8/10/2020"), 60000);
            Contribuyente contribuyente2 = new Contribuyente(2, "4",
            Convert.ToDateTime("15/10/2020"), Convert.ToDateTime("6/10/2020"), 80000);

            LiquidarImpuesto liquidarImpuesto = new LiquidarImpuesto(contribuyente, "NO");
            LiquidarImpuesto liquidarImpuesto2 = new LiquidarImpuesto(contribuyente2, "NO");

            Console.WriteLine(liquidarImpuesto.CalculoDiasExtemporaneidad());



            liquidarImpuesto.CalcularLiquidacion();
            liquidarImpuesto2.CalcularLiquidacion();

            Console.WriteLine(liquidarImpuesto.ValorImpuestoTotal);

            Console.WriteLine(liquidarImpuestoService.Guardar(liquidarImpuesto));
            Console.WriteLine(liquidarImpuestoService.Guardar(liquidarImpuesto2));
            respuestaConsulta = liquidarImpuestoService.Consultar();

            foreach (var item in respuestaConsulta.LiquidarImpuestos)
            {
                Console.WriteLine(item.ToString());
            }
            /*
            Console.WriteLine(liquidarImpuestoService.Eliminar(2));
            
            respuestaConsulta = liquidarImpuestoService.Consultar();
            foreach (var item in respuestaConsulta.LiquidarImpuestos)
            {
                Console.WriteLine(item.ToString());
            }
            */
            Console.WriteLine("Modificar");
            Contribuyente contribuyente3 = new Contribuyente(2, "5",
            Convert.ToDateTime("15/10/2020"), Convert.ToDateTime("6/10/2020"), 90000);
            LiquidarImpuesto liquidarImpuesto3 = new LiquidarImpuesto(contribuyente3, "NO");
            Console.WriteLine(liquidarImpuestoService.Modificar(liquidarImpuesto3));


            respuestaConsulta = liquidarImpuestoService.Consultar();
            foreach (var item in respuestaConsulta.LiquidarImpuestos)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();
        }
    }
}
