using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Empleado.EntityLayer;
using System.Data;
using System.Data.SqlClient;
using EmpleadoEntity = Empleado.EntityLayer.Empleado;
using System.Globalization;

namespace Empleado.DataLayer
       {
    public class EmpleadoDL
        {

        public List<EmpleadoEntity> Lista()
        {
            List<EmpleadoEntity> lista = new List<EmpleadoEntity>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("select * from fn_empleados()", oConexion);
                cmd.CommandType = CommandType.Text;
                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new EmpleadoEntity
                            {
                                IdEmpleado = Convert.ToInt32(dr["idEmpleado"].ToString()),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Departamento = new Departamento
                                {
                                    IdDepartamento = Convert.ToInt32(dr["IdDepartamento"].ToString()),
                                    Nombre = dr["NombreDepartamento"].ToString()  // Aquí se ajusta para usar "NombreDepartamento"
                                },

                                Sueldo = (decimal)dr["Sueldo"],
                                FechaContrato = DateTime.ParseExact(dr["FechaContrato"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                                FechaNacimiento = DateTime.ParseExact(dr["FechaNacimiento"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture),


                                Edad = Convert.ToInt32(dr["Edad"].ToString()),
                                Estatus = dr["Estatus"].ToString()
                            });
                        }
                    }
                    return lista;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        public EmpleadoEntity Obtener(int IdEmpleado)
        {
            EmpleadoEntity entidad = new EmpleadoEntity();

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("select * from fn_empleadoos(@idEmpleado)", oConexion);
                cmd.Parameters.AddWithValue("@idEmpleado", IdEmpleado);
                cmd.CommandType = CommandType.Text;
                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            entidad.IdEmpleado = Convert.ToInt32(dr["IdEmpleado"]);
                            entidad.NombreCompleto = dr["NombreCompleto"].ToString();
                            entidad.Departamento = new Departamento
                            {
                                IdDepartamento = Convert.ToInt32(dr["IdDepartamento"]),
                                Nombre = dr["NombreDepartamento"].ToString()
                            };
                            entidad.Sueldo = (decimal)dr["Sueldo"];

                            // Convertir la fecha de contrato y fecha de nacimiento al tipo DateTime
                            entidad.FechaContrato = (DateTime)dr["FechaContrato"];
                            entidad.FechaNacimiento = (DateTime)dr["FechaNacimiento"];

                            entidad.Edad = Convert.ToInt32(dr["Edad"]);
                            entidad.Estatus = dr["Estatus"].ToString();
                        }
                    }
                    return entidad;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }







        public bool Crear(EmpleadoEntity entidad)
        {
            bool respuesta = false;

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_CrearEmpleadoos", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;

                // Calcula la edad a partir de la fecha de nacimiento
                TimeSpan edadSpan = DateTime.Now - entidad.FechaNacimiento; // Utiliza la fecha de nacimiento proporcionada en la entidad
                int edad = (int)(edadSpan.TotalDays / 365.25); // Aproximación de años

                // Formatea las fechas de contratación y de nacimiento
                string fechaContratoFormateada = entidad.FechaContrato.ToString("yyyy-MM-dd");
                string fechaNacimientoFormateada = entidad.FechaNacimiento.ToString("yyyy-MM-dd");

                // Agregar parámetros
                cmd.Parameters.AddWithValue("@NombreCompleto", entidad.NombreCompleto);
                cmd.Parameters.AddWithValue("@IdDepartamento", entidad.Departamento.IdDepartamento);
                cmd.Parameters.AddWithValue("@Sueldo", entidad.Sueldo);
                cmd.Parameters.AddWithValue("@FechaContrato", fechaContratoFormateada);
                cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNacimientoFormateada);
                cmd.Parameters.AddWithValue("@Edad", edad);
                cmd.Parameters.AddWithValue("@Estatus", entidad.Estatus);

                try
                {
                    oConexion.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0) respuesta = true;

                    return respuesta;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }





        public bool Editar(EmpleadoEntity entidad)
        {
            bool respuesta = false;

            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))

            {
                SqlCommand cmd = new SqlCommand("sp_EditarEmpleadooss", oConexion);

                TimeSpan edadSpan = DateTime.Now - entidad.FechaNacimiento; // Utiliza la fecha de nacimiento proporcionada en la entidad
                int edad = (int)(edadSpan.TotalDays / 365.25); // Aproximación de años

                // Formatea las fechas de contratación y de nacimiento
                string fechaContratoFormateada = entidad.FechaContrato.ToString("yyyy-MM-dd");
                string fechaNacimientoFormateada = entidad.FechaNacimiento.ToString("yyyy-MM-dd");

                cmd.Parameters.AddWithValue("@IdEmpleado", entidad.IdEmpleado);
                cmd.Parameters.AddWithValue("@NombreCompleto", entidad.NombreCompleto);
                cmd.Parameters.AddWithValue("@IdDepartamento", entidad.Departamento.IdDepartamento);
                cmd.Parameters.AddWithValue("@Sueldo", entidad.Sueldo);
                cmd.Parameters.AddWithValue("@FechaContrato", entidad.FechaContrato);
                cmd.Parameters.AddWithValue("@FechaNacimiento", entidad.FechaNacimiento); // Asegúrate de que el tipo de dato de la columna coincida con el tipo de dato de FechaNacimiento en la clase Empleado
                cmd.Parameters.AddWithValue("@Edad", edad); // Asegúrate de que el tipo de dato de la columna coincida con el tipo de dato de Edad en la clase Empleado
                cmd.Parameters.AddWithValue("@Estatus", entidad.Estatus);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0) respuesta = true;

                    return respuesta;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        public bool Eliminar(int IdEmpleado)
            {
                bool respuesta = false;

                using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("sp_EliminarEmpleado", oConexion);
                    cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        oConexion.Open();
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        if (filasAfectadas > 0) respuesta = true;

                        return respuesta;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

            }

        }
    }