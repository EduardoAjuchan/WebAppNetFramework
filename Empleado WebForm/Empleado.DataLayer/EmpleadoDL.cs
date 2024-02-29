using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Empleado.EntityLayer;
using System.Data;
using System.Data.SqlClient;
using EmpleadoEntity = Empleado.EntityLayer.Empleado;

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
                                    Nombre = dr["Nombre"].ToString()
                                },
                                Sueldo = (decimal)dr["Sueldo"],
                                FechaContrato = dr["FechaContrato"].ToString(),
                                FechaNacimiento = dr["fechaNacimiento"].ToString(),
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
                SqlCommand cmd = new SqlCommand("select * from fn_empleado(@idEmpleado)", oConexion);
                cmd.Parameters.AddWithValue("@idEmpleado", IdEmpleado);
                cmd.CommandType = CommandType.Text;
                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            entidad.IdEmpleado = Convert.ToInt32(dr["IdEmpleado"].ToString());
                            entidad.NombreCompleto = dr["NombreCompleto"].ToString();
                            entidad.Departamento = new Departamento
                            {
                                IdDepartamento = Convert.ToInt32(dr["IdDepartamento"].ToString()),
                                Nombre = dr["Nombre"].ToString()
                            };
                            entidad.Sueldo = (decimal)dr["Sueldo"];
                            entidad.FechaContrato = dr["FechaContrato"].ToString();
                            entidad.FechaNacimiento = dr["fechaNacimiento"].ToString();
                            entidad.Edad = Convert.ToInt32(dr["Edad"].ToString());
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
                SqlCommand cmd = new SqlCommand("sp_CrearEmpleado", oConexion);
                cmd.Parameters.AddWithValue("@NombreCompleto", entidad.NombreCompleto);
                cmd.Parameters.AddWithValue("@IdDepartamento", entidad.Departamento.IdDepartamento);
                cmd.Parameters.AddWithValue("@Sueldo", entidad.Sueldo);
                cmd.Parameters.AddWithValue("@FechaContrato", entidad.FechaContrato);
                cmd.CommandType = CommandType.StoredProcedure;

                // Calcula la edad a partir de la fecha de nacimiento
                DateTime fechaNacimiento = Convert.ToDateTime(entidad.FechaNacimiento);
                TimeSpan edadSpan = DateTime.Now - fechaNacimiento;

                int edad = (int)(edadSpan.TotalDays / 365.25); // Aproximación de años

                // Agrega el parámetro de la edad
                cmd.Parameters.AddWithValue("@Edad", edad);

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
                SqlCommand cmd = new SqlCommand("sp_EditarEmpleado", oConexion);
                cmd.Parameters.AddWithValue("@IdEmpleado", entidad.IdEmpleado);
                cmd.Parameters.AddWithValue("@NombreCompleto", entidad.NombreCompleto);
                cmd.Parameters.AddWithValue("@IdDepartamento", entidad.Departamento.IdDepartamento);
                cmd.Parameters.AddWithValue("@Sueldo", entidad.Sueldo);
                cmd.Parameters.AddWithValue("@FechaContrato", entidad.FechaContrato);
                cmd.Parameters.AddWithValue("@FechaNacimiento", entidad.FechaNacimiento); // Asegúrate de que el tipo de dato de la columna coincida con el tipo de dato de FechaNacimiento en la clase Empleado
                cmd.Parameters.AddWithValue("@Edad", entidad.Edad); // Asegúrate de que el tipo de dato de la columna coincida con el tipo de dato de Edad en la clase Empleado
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