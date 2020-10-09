using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using System.IO;

namespace DAL
{
    public class LiquidarImpuestoRepositorio
    {

        string ruta = @"LiquidarImpuesto.txt";
        List<LiquidarImpuesto> LiquidarImpuestos;

        public LiquidarImpuestoRepositorio()
        {
            LiquidarImpuestos = new List<LiquidarImpuesto>();
        }

        public void Guardar(LiquidarImpuesto liquidarImpuesto)
        {
            FileStream fileStream = new FileStream(ruta, FileMode.Append);
            StreamWriter escritor = new StreamWriter(fileStream);
            escritor.WriteLine(liquidarImpuesto.ToString());
            escritor.Close();
            fileStream.Close();
        }
        public List<LiquidarImpuesto> Consultar()
        {
            LiquidarImpuestos.Clear();
            FileStream fileStream = new FileStream(ruta, FileMode.OpenOrCreate);
            StreamReader lector = new StreamReader(fileStream);

            string linea = string.Empty;

            while ((linea = lector.ReadLine()) != null)
            {
                LiquidarImpuesto liquidarImpuesto;
                String[] datos = linea.Split(';');


                /* return $"{Contribuyente.NumeroFormulario};{Contribuyente.Identificacion};{Contribuyente.FechaPlazo};{Contribuyente.FechaDeclaracion};{Contribuyente.Ingreso}" +
                 $"{ValorImpuestoTotal};{RespuestaEmplazamiento};{Sancion}";
                 */

                Contribuyente contribuyente = new Contribuyente(int.Parse(datos[0]), datos[1], Convert.ToDateTime(datos[3]), Convert.ToDateTime(datos[2]),
                    Convert.ToDecimal(datos[4]));
                liquidarImpuesto = new LiquidarImpuesto(contribuyente, datos[6]);

                liquidarImpuesto.CalcularLiquidacion();

                LiquidarImpuestos.Add(liquidarImpuesto);
            }
            fileStream.Close();
            lector.Close();
            return LiquidarImpuestos;
        }

        public LiquidarImpuesto Buscar(int numeroFormulario)
        {
            LiquidarImpuestos.Clear();
            LiquidarImpuestos = Consultar();
            foreach (var item in LiquidarImpuestos)
            {
                if (item.Contribuyente.NumeroFormulario == numeroFormulario)
                {
                    return item;
                }
            }
            return null;
        }

        public void Eliminar(int numeroFormulario)
        {
            LiquidarImpuestos.Clear();
            LiquidarImpuestos = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            foreach (var item in LiquidarImpuestos)
            {
                if (item.Contribuyente.NumeroFormulario != numeroFormulario)
                {
                    Guardar(item);
                }
            }

        }
        public void Modificar(LiquidarImpuesto liquidarImpuesto)
        {
            LiquidarImpuestos.Clear();
            LiquidarImpuestos = Consultar();
            FileStream fileStream = new FileStream(ruta, FileMode.Create);
            fileStream.Close();
            foreach (var item in LiquidarImpuestos)
            {
                if (item.Contribuyente.NumeroFormulario != liquidarImpuesto.Contribuyente.NumeroFormulario)
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(liquidarImpuesto);
                }
            }

        }
    }
}
