using FranciscoHernandez._2024.PruebaTecnica.Models;
using Microsoft.Data.SqlClient;

namespace FranciscoHernandez._2024.PruebaTecnica.DAL
{
    public class ProductoDAL { 
        private string connectionString = "your_connection_string_here";
        public List<Producto> ObtenerProductos() 
        {
            List<Producto> productos = new List<Producto>();
            using (SqlConnection connection = new SqlConnection(connectionString)) 
            { 
                connection.Open(); SqlCommand command = new SqlCommand("SELECT * FROM Productos", connection); 
                SqlDataReader reader = command.ExecuteReader(); while (reader.Read()) 
                { 
                    Producto producto = new Producto 
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nombre = reader["Nombre"].ToString(),
                        Precio = Convert.ToDecimal(reader["Precio"]) }; 
                    productos.Add(producto); 
                }
            } 
            return productos; 
        } 
        public void InsertarProducto(Producto producto) 
        { 
            using (SqlConnection connection = new SqlConnection(connectionString)) 
            { 
                connection.Open(); SqlCommand command = new SqlCommand("INSERT INTO Productos (Nombre, Precio) VALUES (@Nombre, @Precio)", connection); 
                command.Parameters.AddWithValue("@Nombre", producto.Nombre); 
                command.Parameters.AddWithValue("@Precio", producto.Precio);
                command.ExecuteNonQuery(); 
            }
        } 
    }
}
