using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Entity;
using BusinessEntity.ClassModels;

namespace DataLayer
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DataBaseLabb2")
        {
        }

        public DbSet<Activity> Activities { get; set; }
        public DbSet<Alumnus> Alumnuses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SendList> SendLists { get; set; }

        public void Reset()
        {
            string connectionString = Database.Connection.ConnectionString;
            string commandText = "DECLARE @sql NVARCHAR(MAX) = N''; SELECT @sql += 'DROP TABLE ' + QUOTENAME(s.name) + '.' + QUOTENAME(t.name) + ';'FROM sys.tables AS t INNER JOIN sys.schemas AS s ON t.[schema_id] = s.[schema_id] WHERE t.name LIKE '%_" + "' OR t.name like '__MigrationHistory'; PRINT @sql; EXEC sp_executesql @sql; ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(commandText, conn))
            {
                conn.Open();
                for (int i = 0; i < 5; i++)
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (System.Exception)
                    {
                    }
                }

                conn.Close();
            }
            Database.Initialize(true);
        }
    }
}
