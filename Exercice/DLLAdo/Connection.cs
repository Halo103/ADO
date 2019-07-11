using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace DLLAdo
{
    class Connection
    {
        private string _connectionString;
        //private SqlConnection _connection;
        private DbProviderFactory _factory;
        
        public string connectionString { get; set; }

        public Connection(string connectionString, string provider)
        {
            if (string.IsNullOrWhiteSpace(connectionString) || string.IsNullOrEmpty(provider))
            {
                throw new Exception("La connection string ou le provider est foirax");
            }

            _connectionString = connectionString;
            _factory = DbProviderFactories.GetFactory(provider);
            //_connection.ConnectionString = _connectionString;
        }

        private DbConnection setConnection()
        {
            DbConnection c = _factory.CreateConnection();
            c.ConnectionString = _connectionString;
            return c;
        }

        private DbCommand setCommand(Command command, DbConnection server)
        {
            DbCommand c = server.CreateCommand();
            c.CommandText = command.commandText;
            c.CommandType = (command.IsStoredProcedure) ? CommandType.StoredProcedure : CommandType.Text;
            foreach (KeyValuePair<string, object> kvp in command.parameters)
            {
                DbParameter dbp = _factory.CreateParameter();
                dbp.ParameterName = kvp.Key;
                dbp.Value = kvp.Value;
                c.Parameters.Add(dbp);
            }
            return c;
        }            

        public int ExecuteNonQuery(Command command)
        {
            int row;
            using (DbConnection connection = this.setConnection())
            {
                using (DbCommand c = this.setCommand(command,connection))
                {
                    connection.Open();
                    row = c.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return row;
        }

        public object ExectuteScalar(Command command)
        {
            object result;
            using (DbConnection connection = this.setConnection())
            {
                using (DbCommand c = this.setCommand(command,connection))
                {
                    connection.Open();
                    result = c.ExecuteScalar();
                    connection.Close();
                }
            }
            return result;                
        }

        public IEnumerable<T> ExecuteReader<T>(Command command, Func<IDataReader,T> convert) where T : new ()
        {
            List<T> result = new List<T>();
            using (DbConnection connection = this.setConnection())
            {
                using (DbCommand c = this.setCommand(command,connection))
                {
                    connection.Open();

                    using (DbDataReader reader = c.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(convert(reader));
                        }
                    }
                    connection.Close();
                }
            }
            return result;
        }

        public DataTable GetDataTable(Command command)
        {
            DataTable dt = new DataTable();
            using (DbConnection connection = this.setConnection())
            {
                using (DbCommand c = this.setCommand(command,connection))
                {
                    DbDataAdapter dataAdapt = _factory.CreateDataAdapter();
                    dataAdapt.Fill(dt);
                }
            }
            return dt;
        }
    }
}
