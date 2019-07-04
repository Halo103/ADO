using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace AdoExo
{
    class Program
    {
        static void Main(string[] args)
        {
            string SQLAuthConnectionString = @"Server=TECHNOBEL;" + "Database=Exercice;" + "User Id=sa;Password=test1234=;";
            Student aude = new Student("Beurive", "Aude", new DateTime(1989, 10, 16), 19.5, 1120);
            Student marceau = new Student("Depasse", "Marceau", new DateTime(1990, 05, 03), 20, 1010);
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";

            try
            {
                using (SqlConnection connect = new SqlConnection())
                {
                    connect.ConnectionString = SQLAuthConnectionString;

                    //using (SqlCommand command = connect.CreateCommand())
                    //{                        
                    //    command.CommandText = "SELECT Id, LastName, FirstName, YearResult FROM V_Student";

                    //    SqlDataAdapter da = new SqlDataAdapter();
                    //    da.SelectCommand = command;
                    //    DataTable ds = new DataTable();
                    //    da.Fill(ds);

                    //    if(ds.Rows.Count > 0)
                    //    {
                    //        double moyenne = 0;
                    //        foreach(DataRow row in ds.Rows)
                    //        {
                    //            Console.WriteLine($"{row["Id"]} - {row["LastName"]} {row["FirstName"]}");
                    //            moyenne += (int)row["YearResult"];
                    //        }
                    //        moyenne /= ds.Rows.Count;
                    //        Console.WriteLine("----------");
                    //        Console.WriteLine("Moyenne annuelle : " + moyenne);
                    //    }
                    //    Console.WriteLine("----------");
                    //    connect.Open();
                    //    using (SqlDataReader reader = command.ExecuteReader())
                    //    {
                    //        while(reader.Read())
                    //        {
                    //            Console.WriteLine($"{reader["Id"]} - {reader["LastName"]} {reader["FirstName"]}");
                    //        }
                    //    }

                    //using (SqlCommand moyenne = connect.CreateCommand())
                    //{
                    //    connect.Open();
                    //    moyenne.CommandText = "SELECT AVG(CONVERT(FLOAT,YearResult)) FROM V_Student";
                    //    double moy = (double)moyenne.ExecuteScalar();
                    //    Console.WriteLine("----------");
                    //    Console.WriteLine("Moyenne annuelle : "+moy);
                    //    connect.Close();
                    //}
                //}
                    //////////////////// Ajout Student Aude /////////////////////
                    //using (SqlCommand command = connect.CreateCommand())
                    //{
                    //    connect.Open();                        
                    //    command.CommandText = $"INSERT INTO Student(FirstName, LastName, BirthDate, YearResult, SectionId) OUTPUT inserted.Id" +
                    //        $" values('{aude.FirstName}','{aude.LastName}','{aude.BirthDate.ToString("yyy-MM-dd")}',{aude.YearResult.ToString(nfi)},{aude.SectionId});";
                    //    aude.Id = (int)command.ExecuteScalar();
                    //    Console.WriteLine(command.CommandText);
                    //}

                    /////////////////// Ajout Student Marceau //////////////////
                    using (SqlCommand command = connect.CreateCommand())
                    {
                        connect.Open();
                        command.CommandText = $"INSERT INTO Student(FirstName, LastName, BirthDate, YearResult, SectionId) OUTPUT inserted.Id" +
                            $" values(@FirstName,@LastName, @BirthDate, @YearResult, @SectionId);";
                        SqlParameter PFirstName = new SqlParameter() { ParameterName = "FirstName", Value = marceau.FirstName };
                        SqlParameter PLastName = new SqlParameter() { ParameterName = "LastName", Value = marceau.LastName };
                        SqlParameter PBirthDate = new SqlParameter() { ParameterName = "BirthDate", Value = marceau.BirthDate.ToString("yyyy-MM-dd")};
                        SqlParameter PYearResult = new SqlParameter() { ParameterName = "YearResult", Value = marceau.YearResult };
                        SqlParameter PSectionId = new SqlParameter() { ParameterName = "SectionId", Value = marceau.SectionId };
                        List<SqlParameter> Listparam = new List<SqlParameter>() { PLastName, PFirstName, PBirthDate, PYearResult, PSectionId };                        
                        command.Parameters.Add(PFirstName);
                        command.Parameters.Add(PLastName);
                        command.Parameters.Add(PBirthDate);
                        command.Parameters.Add(PYearResult);
                        command.Parameters.Add(PSectionId);

                        marceau.Id = (int)command.ExecuteScalar();
                        Console.WriteLine(command.CommandText);
                    }


                    connect.Close();
                       
                    
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
