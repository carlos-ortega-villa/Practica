using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Contribuyente
    {
        public int NumeroFormulario { get; set; }
        public string Identificacion { get; set; }
        public DateTime FechaDeclaracion { get; set; }
        public DateTime FechaPlazo { get; set; }
        public decimal Ingreso { get; set; }
        public string Respuesta { get; set; }

        public Contribuyente(int numeroFormulario, string identificacion, DateTime fechaDeclaracion, DateTime fechaPlazo, decimal ingreso)
        {
            NumeroFormulario = numeroFormulario;
            Identificacion = identificacion;
            FechaDeclaracion = fechaDeclaracion;
            FechaPlazo = fechaPlazo;
            Ingreso = ingreso;
        }


    }
}
