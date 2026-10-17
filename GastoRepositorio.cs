using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace RepositorioGastos
{
    public class GastoRepositorio
    {
        private const string CadenaConexion = @"Server=(localdb)\MSSQLLocalDB;database=GastosDB;trusted_connection=true;TrustServerCertificate=true";
        public void Insertar(Gasto g)
        {
            string sql = @"INSERT INTO Gastos (Descripcion, Monto, Categoria) VALUES (@Descripcion, @Monto, @Categoria)";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            using (SqlCommand comando= new SqlCommand(sql, conexion))
            {
                comando.Parameters.AddWithValue("@descripcion", g.Descripcion);
                comando.Parameters.AddWithValue("@monto", g.Monto);
                comando.Parameters.AddWithValue("@categoria", g.Categoria);
                conexion.Open();
                int filas = comando.ExecuteNonQuery();
                if (filas == 1)
                    Console.WriteLine("Gasto registrado exitosamente.");
                else
                    Console.WriteLine("No se puedo registra el gasto correctamente.");
            }
        }
        public List<Gasto> ListarTodos()
        {
            List<Gasto> lista = new List<Gasto>();
            string sql = @"SELECT Id, Descripcion, Monto, Categoria FROM Gastos ORDER BY Id";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                conexion.Open();
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        lista.Add(new Gasto
                        {
                            Id = lector.GetInt32(0),
                            Descripcion = lector.GetString(1),
                            Monto = lector.GetDecimal(2),
                            Categoria = lector.GetString(3)
                        });
                    }
                }
            }
            return lista;
        }
    }
}
