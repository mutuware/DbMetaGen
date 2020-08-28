using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DbMetaGen
{
    public class SqlDbMetadataProvider : IDbMetadataProvider
    {
        private readonly string _connectionString;

        public SqlDbMetadataProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbMetadata Get()
        {
            string sql = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES";
            var tables = new List<string>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(sql, connection);

                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        tables.Add(reader[0].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return new DbMetadata { Tables = tables };
        }
    }
}