using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using DLLAdo;



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
                    #region Exo1
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
                    #endregion
                    #region Exo2 Ajout Student
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
                    //using (SqlCommand command = connect.CreateCommand())
                    //{
                    //    connect.Open();
                    //    command.CommandText = $"INSERT INTO Student(FirstName, LastName, BirthDate, YearResult, SectionId) OUTPUT inserted.Id" +
                    //        $" values(@FirstName,@LastName, @BirthDate, @YearResult, @SectionId);";
                    //    SqlParameter PFirstName = new SqlParameter("FirstName",marceau.FirstName);
                    //    SqlParameter PLastName = new SqlParameter("LastName",marceau.LastName);
                    //    SqlParameter PBirthDate = new SqlParameter("BirthDate", marceau.BirthDate);
                    //    SqlParameter PYearResult = new SqlParameter("YearResult", marceau.YearResult);
                    //    SqlParameter PSectionId = new SqlParameter("SectionId", marceau.SectionId );                        
                    //    command.Parameters.AddRange(new SqlParameter[] { PLastName, PFirstName, PBirthDate, PYearResult, PSectionId });                        

                    //    marceau.Id = (int)command.ExecuteScalar();
                    //    Console.WriteLine(command.CommandText);
                    //}
                    #endregion
                    #region Exo3 Update Section
                    //////////////////// MODIF SECTION ////////////////////////
                    //using (SqlCommand command = connect.CreateCommand())
                    //{
                    //    command.CommandText = "UpdateStudent";
                    //    command.CommandType = CommandType.StoredProcedure;

                    //    SqlParameter PId = new SqlParameter("Id", 26);
                    //    SqlParameter PYearResult = new SqlParameter("YearResult", 20);
                    //    SqlParameter PSectionId = new SqlParameter("SectionId", 1010 );                        
                    //    command.Parameters.AddRange(new SqlParameter[] { PId, PYearResult, PSectionId });

                    //    connect.Open();
                    //    command.ExecuteNonQuery();

                    //    Console.WriteLine(command.CommandText);
                    //}
                    #endregion
                    #region Exo3 Delete Student
                    //////////////////// DELETE STUDENT ////////////////////////
                    using (SqlCommand command = connect.CreateCommand())
                    {
                        command.CommandText = "DeleteStudent";
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter PId = new SqlParameter("Id", 27);                        
                        command.Parameters.Add( PId );

                        connect.Open();
                        command.ExecuteNonQuery();

                        Console.WriteLine(command.CommandText);
                    }
                    #endregion

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
