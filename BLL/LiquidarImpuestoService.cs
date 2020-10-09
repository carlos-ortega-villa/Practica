using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using DAL;

namespace BLL
{
    public class LiquidarImpuestoService
    {
        LiquidarImpuestoRepositorio LiquidarImpuestoRepositorio;

        public LiquidarImpuestoService()
        {
            LiquidarImpuestoRepositorio = new LiquidarImpuestoRepositorio();
        }

        public string Guardar(LiquidarImpuesto liquidarImpuesto)
        {
            try
            {
                if (LiquidarImpuestoRepositorio.Buscar(liquidarImpuesto.Contribuyente.NumeroFormulario) == null)
                {
                    LiquidarImpuestoRepositorio.Guardar(liquidarImpuesto);
                    return "Ha sido guardada con exito";
                }
                return $"Ya existe {liquidarImpuesto.Contribuyente.NumeroFormulario} registrado";
            }
            catch (Exception e)
            {

                return $"Error en los datos {e.Message}";
            }


        }

        public RespuestaConsulta Consultar()
        {
            RespuestaConsulta respuestaConsulta = new RespuestaConsulta();
            try
            {
                respuestaConsulta.LiquidarImpuestos = LiquidarImpuestoRepositorio.Consultar();
                if (respuestaConsulta.LiquidarImpuestos != null)
                {
                    respuestaConsulta.Mensaje = "La operacion ha sido ejecutada con exito";
                }
                else
                {
                    respuestaConsulta.Mensaje = "No se encontraron registros";
                }
            }
            catch (Exception e)
            {

                respuestaConsulta.Mensaje = $"Error en los datos {e.Message}";
            }
            return respuestaConsulta;
        }
        public string Eliminar(int numeroFormulario)
        {
            try
            {
                if (LiquidarImpuestoRepositorio.Buscar(numeroFormulario) != null)
                    LiquidarImpuestoRepositorio.Eliminar(numeroFormulario);

                return $"El registro con el numero {numeroFormulario} ha sido eliminado";
            }
            catch (Exception e)
            {

                return $"Error el eliminar {e.Message}";
            }
        }
        public string Modificar(LiquidarImpuesto liquidarImpuesto)
        {
            try
            {
                if (LiquidarImpuestoRepositorio.Buscar(liquidarImpuesto.Contribuyente.NumeroFormulario) != null)
                {
                    LiquidarImpuestoRepositorio.Modificar(liquidarImpuesto);
                    return "Modificacion realizada con exito";
                }
                return "No se ha podido realizar la modificacion";
            }
            catch (Exception e)
            {

                return "Error de datos" + e.Message;
            }
        }

    }


    public class RespuestaConsulta
    {
        public string Mensaje { get; set; }
        public List<LiquidarImpuesto> LiquidarImpuestos { get; set; }

    }
}
