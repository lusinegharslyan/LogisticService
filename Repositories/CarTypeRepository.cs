using LogisticService.Models;
using LogisticService.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Repositories
{
    class CarTypeRepository : IRepository<CarType>
    {
        public const string CONNECTCION_STRING = "Data Source=LUSINE1985\\MSSQLSERVER01;Initial Catalog=LogisticServiceDb;Integrated Security=True;Encrypt=False";

        public async Task AddAsync(CarType carType)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into CarTypes values(@Type, @Coefficient)";
                    command.Parameters.Add(new SqlParameter("@Type", carType.Type));
                    command.Parameters.Add(new SqlParameter("@Coefficient", carType.Coefficient));

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Delete from CarTypes where Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(CarType carType, int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "update CarTypes set Type = @Type,Coefficient= @Coefficient where Id= @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    command.Parameters.Add(new SqlParameter("@Type", carType.Type));
                    command.Parameters.Add(new SqlParameter("@Coefficient", carType.Coefficient));

                    await command.ExecuteNonQueryAsync();

                }

            }
        }

        public async Task<CarType> FindByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                CarType carType = new CarType();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from CarTypes where Id=@Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            carType.Id = int.Parse(reader["Id"].ToString());
                            carType.Type = reader["Type"].ToString();
                            carType.Coefficient = float.Parse(reader["Coefficient"].ToString());

                        }
                    }
                }
                return carType;
            }
        }
        public async Task<List<CarType>> GetAllAsync()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                List<CarType> carTypes = new List<CarType>();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from CarTypes";
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            CarType carType = new CarType();
                            carType.Id = int.Parse(reader["Id"].ToString());
                            carType.Type = reader["Type"].ToString();
                            carType.Coefficient = float.Parse(reader["Coefficient"].ToString());

                            carTypes.Add(carType);
                        }
                    }
                }
                return carTypes;

            }
        }


        public async Task<CarType> FindAsync(CarType carTypeName)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                CarType carType = new CarType();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from CarTypes where Type=@Type";
                    command.Parameters.Add(new SqlParameter("@Type", carTypeName.Type));

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            carType.Id = int.Parse(reader["Id"].ToString());
                            carType.Type = reader["Type"].ToString();
                            carType.Coefficient = float.Parse(reader["Coefficient"].ToString());

                        }
                    }
                }
                return carType;
            }

        }
    }
}
