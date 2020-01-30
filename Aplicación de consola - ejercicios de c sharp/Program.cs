using System;
using System.Data.SqlClient;
using System.Text;

namespace Aplicación_de_consola___ejercicios_de_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string connectString =
                 "Data Source=(local);User ID=ab;Password=MyPassword;" +
                 "Initial Catalog=pricing_test";

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectString);

                //elimino el user y la pw porque se inicia con la autenticación de windows
                builder.Remove("User ID");
                builder.Remove("Password");
                builder.IntegratedSecurity = true;

                // Connect to SQL
                Console.Write("Conectando a SQL Server ... ");
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    Console.WriteLine("conectado");
                    Console.WriteLine("Ejercicio 1-A.");
                    //Ejercicio 1-A
                    StringBuilder sb = new StringBuilder();
                    sb.Append("USE pricing_test;");
                    sb.Append("select count(*) from proveedor;");
                    //sb.Append("INSERT INTO proveedor (rut,nombre,telefono,pagina_web,direccion,id_comuna,id_ciudad) values (195845921,'Barbara', 930799532, 'www.pricinprueba.cl','Cuatro poniente 322',1,1);");

                    string query = sb.ToString();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        var countRows = command.ExecuteScalar();
                        Console.WriteLine("La cantidad de proveedores es: " + countRows);
                    }
                    //Ejercicio 1-B
                    Console.WriteLine("Ejercicio 1-B.");
                    sb.Clear();
                    sb.Append("USE pricing_test;");
                    sb.Append("select TOP 1 id_producto from venta_detalle GROUP BY id_producto ORDER BY sum(monto_total_producto) desc");
                    string id_product = sb.ToString();

                    using (SqlCommand command = new SqlCommand(id_product, connection))
                    {
                        var id_pro = command.ExecuteScalar();
                        sb.Clear();
                        sb.Append("USE pricing_test;");
                        sb.Append("select rut_proveedor from producto where id = " + id_pro);
                        string query_to_rut = sb.ToString();

                        using (SqlCommand command2 = new SqlCommand(query_to_rut, connection))
                        {
                            var rut_proveedor = command2.ExecuteScalar();
                            sb.Clear();
                            sb.Append("USE pricing_test;");
                            sb.Append("select nombre from proveedor where rut = " + rut_proveedor);
                            string query_to_name = sb.ToString();

                            using (SqlCommand command3 = new SqlCommand(query_to_name, connection))
                            {
                                var name = command3.ExecuteScalar();

                                Console.WriteLine("El mejor proveedor de acuerdo a las ventas de sus productos es: " + name);
                            }
                        }
                    }
                    //Ejercicio 1-C
                    Console.WriteLine("Ejercicio 1-C.");
                    sb.Clear();
                    sb.Append("USE pricing_test;");
                    sb.Append("select TOP 1 id_producto from venta_detalle GROUP BY id_producto ORDER BY sum(cantidad_vendida_producto) desc");
                    id_product = sb.ToString();

                    using (SqlCommand command = new SqlCommand(id_product, connection))
                    {
                        var id_pro = command.ExecuteScalar();
                        sb.Clear();
                        sb.Append("USE pricing_test;");
                        sb.Append("select rut_proveedor from producto where id = " + id_pro);
                        string query_to_rut = sb.ToString();

                        using (SqlCommand command2 = new SqlCommand(query_to_rut, connection))
                        {
                            var rut_proveedor = command2.ExecuteScalar();
                            sb.Clear();
                            sb.Append("USE pricing_test;");
                            sb.Append("select nombre from proveedor where rut = " + rut_proveedor);
                            string query_to_name = sb.ToString();

                            using (SqlCommand command3 = new SqlCommand(query_to_name, connection))
                            {
                                var name = command3.ExecuteScalar();

                                Console.WriteLine("El producto mejor vendido: " + name);
                            }
                        }
                    }

                }

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("Presione una tecla para salir");
            Console.ReadKey(true);
        }
    }
}
