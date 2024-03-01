using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EmpleadosBuinessLayer;
using Empleado.EntityLayer;
using EmpleadoEntity = Empleado.EntityLayer.Empleado;
using System.Runtime.InteropServices.ComTypes;

namespace Empleado_WebForm
{
    public partial class _Default : Page
    {
        EmpleadoBL empleadoBL = new EmpleadoBL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarEmpleados();
            }
        }

        private void MostrarEmpleados()
        {
            List<EmpleadoEntity> lista = empleadoBL.Lista();
            GVEmpleado.DataSource = lista;
            GVEmpleado.DataBind();
        }

        protected void Nuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Contact.aspx?idEmpleado=0");
        }

        protected void Editar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string idEmpleado = btn.CommandArgument;
            Response.Redirect($"~/Contact.aspx?idEmpleado={idEmpleado}");
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string idEmpleado = btn.CommandArgument;
            bool respuesta = empleadoBL.Eliminar(Convert.ToInt32(idEmpleado));
            if (respuesta)
                MostrarEmpleados();
        }

        protected void GenerarReporte_Click(object sender, EventArgs e)
        {
            // Obtenemos las fechas seleccionadas por el usario
            DateTime fechaInicio;
            DateTime fechaFin;

            if (DateTime.TryParse(startDate.Text, out fechaInicio) && DateTime.TryParse(endDate.Text, out fechaFin))
            {
                // Obtenemos los empleados por rango de fecha de contratación
                List<EmpleadoEntity> lista = empleadoBL.ObtenerEmpleadosPorRangoFechaContratacion(fechaInicio, fechaFin);

                // Mostramos los empleados encontrados en nuestra tabla o gridview
                GVEmpleado.DataSource = lista;
                GVEmpleado.DataBind();
            }
            else
            {
                
                lblMessage.Text = "Por favor ingrese fechas válidas.";
                lblMessage.Visible = true;
            }
        }

    }
    }
