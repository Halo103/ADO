using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoExo
{
    class Program
    {
        static void Main(string[] args)
        {
            string SQLAuthConnectionString = @"Server=TECHNOBEL;" + "Database=Exercice;" + "User Id=sa;Password=test1234=;";

            try
            {
                using (SqlConnection connect = new SqlConnection())
                {
                    connect.ConnectionString = SQLAuthConnectionString;

                    using (SqlCommand command = connect.CreateCommand())
                    {                        
                        command.CommandText = "SELECT Id, LastName, FirstName, YearResult FROM V_Student";

                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = command;
                        DataTable ds = new DataTable();
                        da.Fill(ds);
                        
                        if(ds.Rows.Count > 0)
                        {
                            double moyenne = 0;
                            foreach(DataRow row in ds.Rows)
                            {
                                Console.WriteLine($"{row["Id"]} - {row["LastName"]} {row["FirstName"]}");
                                moyenne += (int)row["YearResult"];
                            }
                            moyenne /= ds.Rows.Count;
                            Console.WriteLine("----------");
                            Console.WriteLine("Moyenne annuelle : " + moyenne);
                        }
                        Console.WriteLine("----------");
                        connect.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                Console.WriteLine($"{reader["Id"]} - {reader["LastName"]} {reader["FirstName"]}");
                            }
                        }
                        connect.Close();
                       
                    }
                    using (SqlCommand moyenne = connect.CreateCommand())
                    {
                        connect.Open();
                        moyenne.CommandText = "SELECT AVG(CONVERT(FLOAT,YearResult)) FROM V_Student";
                        double moy = (double)moyenne.ExecuteScalar();
                        Console.WriteLine("----------");
                        Console.WriteLine("Moyenne annuelle : "+moy);
                        connect.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadKey();
            }
            
            
            
        }
    }
}
