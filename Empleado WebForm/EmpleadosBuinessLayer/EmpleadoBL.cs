using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Empleado.DataLayer;
using Empleado.EntityLayer;
using EmpleadoEntity = Empleado.EntityLayer.Empleado;


namespace EmpleadosBuinessLayer
{
    public class EmpleadoBL
    {
        EmpleadoDL empleadoDL = new EmpleadoDL();

        public List<EmpleadoEntity> Lista()
        {
            try
            {
                return empleadoDL.Lista();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EmpleadoEntity Obtener(int idEmpleado)
        {
            try
            {
                return empleadoDL.Obtener(idEmpleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Crear(EmpleadoEntity entidad)
        {
            try
            {
                if (entidad.NombreCompleto == "")
                    throw new OperationCanceledException("El nombre no puede ser vacio");

                return empleadoDL.Crear(entidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Editar(EmpleadoEntity entidad)
        {
            try
            {

                var encontrado = empleadoDL.Obtener(entidad.IdEmpleado);


                if (encontrado.IdEmpleado == 0)
                    throw new OperationCanceledException("No existe el empleado");

                return empleadoDL.Editar(entidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //agregar aqui el metodo para el reporte
        public bool Eliminar(int idEmpleado)
        {
            try
            {
                var encontrado = empleadoDL.Obtener(idEmpleado);
                if (encontrado.IdEmpleado == 0)
                    throw new OperationCanceledException("No existe el empleado");

                return empleadoDL.Eliminar(idEmpleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}