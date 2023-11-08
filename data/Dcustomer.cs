using entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data
{
    public class Dcustomer
    {
        public static string connectionString = "Data Source=LAPTOP-54SNKJH2\\SQLEXPRESS;Initial Catalog=FacturaDB;Integrated Security=true";

        public static List<Cliente> ListarClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                connection.Open();
                string query = "ListarClientes";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Verificar si hay filas
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // Leer los datos de cada fila
                                clientes.Add(new Cliente
                                {
                                    CustomerID = (int)reader["Customer_id"],
                                    Name = reader["name"].ToString(),
                                    Address = reader["address"].ToString(),
                                    Phone = reader["phone"].ToString(),
                                    Active = (bool)reader["active"],
                                });

                            }
                        }
                    }
                }

                // Cerrar la conexión
                connection.Close();


            }
            return clientes;

        }

        public static void InsertarCliente(Cliente cliente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "InsertarCliente";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Asignar los parámetros para el procedimiento almacenado
                    command.Parameters.AddWithValue("@name", cliente.Name);
                    command.Parameters.AddWithValue("@address", cliente.Address);
                    command.Parameters.AddWithValue("@phone", cliente.Phone);
                    command.Parameters.AddWithValue("@active", cliente.Active);

                    // Ejecuta el comando
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public static void ModificarCliente(Cliente cliente)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "ModificarCliente";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Asignar los parámetros para el procedimiento almacenado
                    command.Parameters.AddWithValue("@customer_id", cliente.CustomerID);

                    // Solo agregar los parámetros si tienen valores para evitar sobrescribir con NULL
                    if (!string.IsNullOrEmpty(cliente.Name))
                        command.Parameters.AddWithValue("@name", cliente.Name);
                    if (!string.IsNullOrEmpty(cliente.Address))
                        command.Parameters.AddWithValue("@address", cliente.Address);
                    if (!string.IsNullOrEmpty(cliente.Phone))
                        command.Parameters.AddWithValue("@phone", cliente.Phone);
                    // Para el campo 'Active', que es booleano, lo manejamos diferente
                    command.Parameters.AddWithValue("@active", cliente.Active);

                    // Ejecuta el comando
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public static void EliminarClienteLogicamente(int customerId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "EliminarClienteLogicamente";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@customer_id", customerId);

                    // Ejecuta el comando
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

    }
}
