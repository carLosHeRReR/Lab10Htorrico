using entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data
{
    public class Dproduct
    {
        public static string connectionString = "Data Source=LAPTOP-54SNKJH2\\SQLEXPRESS;Initial Catalog=FacturaDB;Integrated Security=true";
        public static List<Producto> ListarProductos()
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "ListarProductos";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productos.Add(new Producto
                            {
                                ProductID = (int)reader["product_id"],
                                Name = reader["name"].ToString(),
                                Stock = (int)reader["stock"],
                                Price = (decimal)reader["price"],
                                Active = (bool)reader["active"]
                            });
                        }
                    }
                }
            }
            return productos;
        }

        public static void InsertarProducto(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "InsertarProducto";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@name", producto.Name);
                    command.Parameters.AddWithValue("@stock", producto.Stock);
                    command.Parameters.AddWithValue("@price", producto.Price);
                    command.Parameters.AddWithValue("@active", producto.Active);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void ModificarProducto(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "ModificarProducto";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@product_id", producto.ProductID);
                    command.Parameters.AddWithValue("@name", producto.Name);
                    command.Parameters.AddWithValue("@stock", producto.Stock);
                    command.Parameters.AddWithValue("@price", producto.Price);
                    command.Parameters.AddWithValue("@active", producto.Active);

                    command.ExecuteNonQuery();
                }
            }
        }

        public static void EliminarProductoLogicamente(int productId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "EliminarProductoLogicamente";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@product_id", productId);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
