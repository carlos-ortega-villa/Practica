using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class LiquidarImpuesto
    {
        public decimal Ingreso { get; set; }
        public decimal Sancion { get; set; }
        public decimal ValorImpuesto { get; set; }
        public decimal ValorImpuestoTotal { get; set; }
        public DateTime FechaDeclaracion { get; set; }
        public DateTime FechaPlazo { get; set; }
        public String RespuestaEmplazamiento { get; set; }
        public decimal SMLDV = 980657 / 30;


        public LiquidarImpuesto(decimal ingreso, DateTime fechaDeclaracion, DateTime fechaPlazo)
        {

            Ingreso = ingreso;
            FechaDeclaracion = fechaDeclaracion;
            FechaPlazo = fechaPlazo;


        }

        public LiquidarImpuesto()
        {
        }

        public int CalculoDiasExtemporaneidad()
        {
            var fecha = FechaDeclaracion.Subtract(FechaPlazo);
            return fecha.Days;

        }

        public void CalculoImpuesto()
        {

            ValorImpuesto = Ingreso * Convert.ToDecimal(0.15);
        }

        public decimal CalculoSancionSinEmplazamiento()
        {
            return ValorImpuesto * Convert.ToDecimal(CalculoDiasExtemporaneidad()) * Convert.ToDecimal(0.03);
        }

        public void CalculoSancionConEmplazamiento()
        {
            Sancion = ValorImpuesto * Convert.ToDecimal(CalculoDiasExtemporaneidad()) * Convert.ToDecimal(0.04) * SMLDV;
        }

        public void CalcularLiquidacion(string respuesta)
        {
            if (CalculoDiasExtemporaneidad() <= 0)
            {

                CalculoImpuesto();
                ValorImpuestoTotal = ValorImpuesto;
            }
            else
            {
                if (respuesta == "SI")
                {
                    CalculoImpuesto();
                    CalculoSancionConEmplazamiento();
                    ValorImpuestoTotal = ValorImpuesto + Sancion;
                }
                else
                {
                    CalculoImpuesto();
                    ValorImpuestoTotal = ValorImpuesto + CalculoSancionSinEmplazamiento();
                }

            }
        }


    }


}

