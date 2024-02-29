using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Empleado.DataLayer;
using Empleado.EntityLayer;

namespace EmpleadosBuinessLayer
{
    public class DepartamentoBL
    {
        DepartamentoDL departamentoDL = new DepartamentoDL();

        public List<Departamento> Lista()
        {
            try
            {

                return departamentoDL.Lista();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}