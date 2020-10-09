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
        public Contribuyente Contribuyente { get; set; }
        public decimal Sancion { get; set; }
        public decimal ValorImpuesto { get; set; }
        public decimal ValorImpuestoTotal { get; set; }
        public String RespuestaEmplazamiento { get; set; }
        public decimal SMLDV = 980657 / 30;


        public LiquidarImpuesto(Contribuyente contribuyente, string respuestaEmplazamiento)
        {


            Contribuyente = contribuyente;
            RespuestaEmplazamiento = respuestaEmplazamiento;


        }

        public LiquidarImpuesto()
        {
        }

        public int CalculoDiasExtemporaneidad()
        {
            var fecha = Contribuyente.FechaDeclaracion.Subtract(Contribuyente.FechaPlazo);
            return fecha.Days;

        }

        public void CalculoImpuesto()
        {

            ValorImpuesto = Contribuyente.Ingreso * Convert.ToDecimal(0.15);
        }

        public void CalculoSancionSinEmplazamiento()
        {
            Sancion = ValorImpuesto * Convert.ToDecimal(CalculoDiasExtemporaneidad()) * Convert.ToDecimal(0.03);
        }

        public void CalculoSancionConEmplazamiento()
        {
            Sancion = ValorImpuesto * Convert.ToDecimal(CalculoDiasExtemporaneidad()) * Convert.ToDecimal(0.04) * SMLDV;
        }

        public void CalcularLiquidacion()
        {
            if (CalculoDiasExtemporaneidad() <= 0)
            {

                CalculoImpuesto();
                ValorImpuestoTotal = ValorImpuesto;
            }
            else
            {
                if (RespuestaEmplazamiento == "SI")
                {

                    CalculoImpuesto();
                    CalculoSancionConEmplazamiento();
                    ValorImpuestoTotal = ValorImpuesto + Sancion;
                }
                else
                {

                    CalculoImpuesto();
                    CalculoSancionSinEmplazamiento();
                    ValorImpuestoTotal = ValorImpuesto + Sancion;
                }

            }
        }

        public override string ToString()
        {
            return $"{Contribuyente.NumeroFormulario};{Contribuyente.Identificacion};{Contribuyente.FechaPlazo};{Contribuyente.FechaDeclaracion};{Contribuyente.Ingreso};" +
                $"{ValorImpuestoTotal};{RespuestaEmplazamiento};{Sancion}";
        }


    }

}

