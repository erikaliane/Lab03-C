//Librerias del ADO .NET
using System.Data.SqlClient;
using System.Data;
using Lab03_Consola;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    // Cadena de conexión a la base de datos
    public static string connectionString = "Data Source=LAB1504-06\\SQLEXPRESS;Initial Catalog=Tecsup2023DB;User ID=userTec;Password=123456";


    static void Main()
    {
         DataTable table = ListarProductosDataTable();
        foreach ( DataRow ite in table.Rows)
        {

           
            Console.WriteLine(ite["Nombre"]);
            Console.WriteLine(ite["Categoria"]);
            Console.WriteLine(ite["Precio"]);
            Console.WriteLine("-------------------");

        }




        var obj =  ListarProductosListaObjetos();

        foreach (var item in obj)
        {


            Console.WriteLine("============LISTA OBJETOS ==================");
            Console.WriteLine(item.IdProducto);

            Console.WriteLine(item.Nombre);
            Console.WriteLine(item.Categoria);
            Console.WriteLine(item.Precio);
            
        }

    }

    //De forma desconectada
    public static DataTable ListarProductosDataTable()
    {
        // Crear un DataTable para almacenar los resultados
        DataTable dataTable = new DataTable();
        // Crear una conexión a la base de datos
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Abrir la conexión
            connection.Open();

            // Consulta SQL para seleccionar datos
            string query = "SELECT * FROM productos";

            // Crear un adaptador de datos
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);


            // Llenar el DataTable con los datos de la consulta
            adapter.Fill(dataTable);

            // Cerrar la conexión
            connection.Close();

        }
        return dataTable;
    }

    //De forma conectada
    public static List<Producto> ListarProductosListaObjetos()
    {
        List<Producto> productos = new List<Producto>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Abrir la conexión
            connection.Open();

            // Consulta SQL para seleccionar datos
            string query = "SELECT IdProducto,Nombre,Categoria ,Precio, FechaVencimiento FROM productos";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Verificar si hay filas
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Leer los datos de cada fila

                            productos.Add(new Producto
                            {
                                IdProducto = (int)reader["IdProducto"],
                                Nombre = reader["Nombre"].ToString(),
                                Categoria = reader["Categoria"].ToString(),
                                 Precio = (decimal)reader["Precio"],
                                FechaVencimiento = (DateTime)reader["FechaVencimiento"]
                            });

                        }
                    }
                }
            }

            // Cerrar la conexión
            connection.Close();


        }
        return productos;

    }

   
}