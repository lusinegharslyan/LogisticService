using LogisticService.Models;
using LogisticService.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticService.Repositories
{
    class CrashedCarRepository : IRepository<CrashedCar>
    {
        public const string CONNECTCION_STRING = "Data Source=LUSINE1985\\MSSQLSERVER01;Initial Catalog=LogisticServiceDb;Integrated Security=True;Encrypt=False";

        public async Task AddAsync(CrashedCar crashedCar)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into CrashedCars values(@IsCrashed, @Coefficient)";
                    command.Parameters.Add(new SqlParameter("@IsCrashed", crashedCar.IsCrashed));
                    command.Parameters.Add(new SqlParameter("@Coefficient", crashedCar.Coefficient));

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
                    command.CommandText = "Delete from CrashedCars  where Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(CrashedCar crashedCar, int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "update CrashedCars  set IsCrashed = @IsCrashed,Coefficient= @Coefficient where Id= @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    command.Parameters.Add(new SqlParameter("@IsCrashed", crashedCar.IsCrashed));
                    command.Parameters.Add(new SqlParameter("@Coefficient", crashedCar.Coefficient));

                    await command.ExecuteNonQueryAsync();

                }

            }
        }

        public async Task<CrashedCar> FindByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                CrashedCar crashedCar = new CrashedCar();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from CrashedCars  where Id=@Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            crashedCar.Id = int.Parse(reader["Id"].ToString());
                            crashedCar.IsCrashed = bool.Parse(reader["IsCrashed"].ToString());
                            crashedCar.Coefficient = float.Parse(reader["Coefficient"].ToString());

                        }
                    }
                }
                return crashedCar;
            }
        }
        public async Task<List<CrashedCar>> GetAllAsync()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                List<CrashedCar> crashedCars = new List<CrashedCar>();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from CrashedCars ";
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            CrashedCar crashedCar = new CrashedCar();
                            crashedCar.Id = int.Parse(reader["Id"].ToString());
                            crashedCar.IsCrashed = bool.Parse(reader["IsCrashed"].ToString());
                            crashedCar.Coefficient = float.Parse(reader["Coefficient"].ToString());

                            crashedCars.Add(crashedCar);
                        }
                    }
                }
                return crashedCars;

            }
        }


        public async Task<CrashedCar> FindAsync(CrashedCar isCrashedCar)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                CrashedCar crashedCar = new CrashedCar();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from CrashedCars where IsCrashed=@IsCrashed";
                    command.Parameters.Add(new SqlParameter("@IsCrashed", isCrashedCar.IsCrashed));

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            crashedCar.Id = int.Parse(reader["Id"].ToString());
                            crashedCar.IsCrashed = bool.Parse(reader["IsCrashed"].ToString());
                            crashedCar.Coefficient = float.Parse(reader["Coefficient"].ToString());

                        }
                    }
                }
                return crashedCar;
            }
        }
    }
}
