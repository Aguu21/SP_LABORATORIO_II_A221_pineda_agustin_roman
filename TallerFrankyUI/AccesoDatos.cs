using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Parcial.WindowsForm
{
    public static class AccesoDatos
    {
        private static MySqlCommand command;
        private static MySqlConnection connection;
        private static MySqlDataReader reader;
        private static string connectionString =
            $"server=localhost;user id=root;password=;database=parcial2;";
        static AccesoDatos()
        {
            connection = new MySqlConnection(connectionString);
            command = new MySqlCommand(); 
            command.Connection = connection;
        }

        public static bool Guardar(string msj)
        {
            try
            {
                connection.Open();
                command.CommandText = $"INSERT INTO registros " +
                    $"(mensaje, alumno) VALUES (@mensaje, @alumno)";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@mensaje", msj);
                command.Parameters.AddWithValue("@alumno",
                    "Agustín Román Pineda");
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
                return false;
            }
        }

        public static bool IntentarConexion()
        {
            try
            {
                connection.Open();
                connection.Close();
                return true;
            }
            catch { return false; }
        }

        public static List<Barco> LeerBarcos()
        {
            try
            {
                List<Barco> barcos = new List<Barco>();
                connection.Open();
                command.CommandText = $"SELECT * FROM barcos";
                command.Parameters.Clear();
                reader = command.ExecuteReader();

                while (reader.Read())
                {

                    Enum.TryParse(reader.GetString("operacion"),
                            out EOperacion operacion);

                    if (reader.GetString("tipo") ==
                        ETipoBarco.Marina.ToString())
                    {
                        var Marina = new Marina
                        {
                            Costo = reader.GetFloat("costo"),
                            EstadoReparado = reader.GetBoolean(
                                "estadoReparado"),
                            Nombre = reader.GetString("nombre"),
                            Operacion = operacion,
                            Tripulacion = reader.GetInt32("tripulacion")
                        };
                        barcos.Add(Marina);
                    }

                    else if (reader.GetString("tipo") ==
                        ETipoBarco.Pirata.ToString())
                    {
                        var Pirata = new Pirata
                        {
                            Costo = reader.GetFloat("costo"),
                            EstadoReparado = reader.GetBoolean(
                                "estadoReparado"),
                            Nombre = reader.GetString("nombre"),
                            Operacion = operacion,
                            Tripulacion = reader.GetInt32("tripulacion")
                        };
                        barcos.Add(Pirata);
                    }
                }
                connection.Close();
                return barcos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
                return null;
            }
        }

        public static bool GuardarBarco(Barco barco)
        {
            try
            {
                connection.Open();
                command.CommandText = $"INSERT INTO barcos " +
                    $"(costo, estadoReparado, nombre, operacion," +
                    $" tripulacion, tipo) VALUES " +
                    $"(@costo, @estadoReparado, @nombre, @operacion," +
                    $"@tripulacion, @tipo)";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@costo", barco.Costo);
                command.Parameters.AddWithValue("@estadoReparado", 
                    barco.EstadoReparado);
                command.Parameters.AddWithValue("@nombre", barco.Nombre);
                command.Parameters.AddWithValue("@operacion", 
                    barco.Operacion.ToString());

                if (barco is Pirata p)
                {
                    command.Parameters.AddWithValue("@tripulacion", 
                        p.Tripulacion);
                    command.Parameters.AddWithValue("@tipo", 
                        ETipoBarco.Pirata.ToString());
                }
                else if (barco is Marina m)
                {
                    command.Parameters.AddWithValue("@tripulacion", 
                        m.Tripulacion);
                    command.Parameters.AddWithValue("@tipo", 
                        ETipoBarco.Marina.ToString());
                }

                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
                return false;
            }
        }

        public static bool ActualizarEstadoCosto(Barco barco)
        {
            try
            {
                connection.Open();
                
                command.CommandText = $"UPDATE barcos SET " +
                    $"costo = @costo, estadoReparado = @estadoReparado " +
                    $"WHERE nombre = @nombre";
                
                command.Parameters.Clear();
                
                command.Parameters.AddWithValue("@costo", barco.Costo);
                command.Parameters.AddWithValue("@estadoReparado",
                    barco.EstadoReparado);
                command.Parameters.AddWithValue("@nombre", barco.Nombre);
                
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
                return false;
            }
        }

        public static bool ActualizarBarco(Barco barco, string nombreViejo)
        {
            try
            {
                connection.Open();

                command.CommandText = $"UPDATE barcos SET " +
                    $"nombre = @nombre, operacion = @operacion, " +
                    $"tipo = @tipo WHERE nombre = @nombreViejo";

                command.Parameters.Clear();

                command.Parameters.AddWithValue("@nombre", barco.Nombre);
                command.Parameters.AddWithValue("@operacion",
                    barco.Operacion.ToString());
                if (barco is Pirata p)
                {
                    command.Parameters.AddWithValue("@tipo",
                        ETipoBarco.Pirata.ToString());
                }
                else if (barco is Marina m)
                {
                    command.Parameters.AddWithValue("@tipo",
                        ETipoBarco.Marina.ToString());
                }

                command.Parameters.AddWithValue("@nombreViejo",
                    nombreViejo);

                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
                return false;
            }
        }

        public static bool BorrarBarco(string nombre)
        {
            try
            {
                connection.Open();

                command.CommandText = $"DELETE FROM barcos " +
                    $"WHERE nombre = @nombre";

                command.Parameters.AddWithValue("@nombre",
                    nombre);

                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
                return false;
            }
        }
    }
}
