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
    class CarModelRepository : IRepository<CarModel>
    {
        public const string CONNECTCION_STRING = "Data Source=LUSINE1985\\MSSQLSERVER01;Initial Catalog=LogisticServiceDb;Integrated Security=True;Encrypt=False";

        public async Task AddAsync(CarModel carModel)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into CarModels values(@Model, @Coefficient)";
                    command.Parameters.Add(new SqlParameter("@Model", carModel.Model));
                    command.Parameters.Add(new SqlParameter("@Coefficient", carModel.Coefficient));

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
                    command.CommandText = "Delete from CarModels where Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(CarModel carModel, int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "update CarModels set Model = @Model,Coefficient= @Coefficient where Id= @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    command.Parameters.Add(new SqlParameter("@Model", carModel.Model));
                    command.Parameters.Add(new SqlParameter("@Coefficient", carModel.Coefficient));

                    await command.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task<CarModel> FindByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                CarModel carModel = new CarModel();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from CarModels where Id=@Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            carModel.Id = int.Parse(reader["Id"].ToString());
                            carModel.Model = reader["Model"].ToString();
                            carModel.Coefficient = float.Parse(reader["Coefficient"].ToString());

                        }
                    }
                }
                return carModel;
            }
        }
        public async Task<List<CarModel>> GetAllAsync()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                List<CarModel> carModels = new List<CarModel>();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from CarModels";
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            CarModel carModel = new CarModel();
                            carModel.Id = int.Parse(reader["Id"].ToString());
                            carModel.Model = reader["Model"].ToString();
                            carModel.Coefficient = float.Parse(reader["Coefficient"].ToString());
                            carModels.Add(carModel);
                        }
                    }
                }
                return carModels;

            }
        }


        public async Task<CarModel> FindAsync(CarModel carModelName)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                CarModel carModel = new CarModel();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from CarModels where Model=@Model";
                    command.Parameters.Add(new SqlParameter("@Model", carModelName.Model));

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            carModel.Id = int.Parse(reader["Id"].ToString());
                            carModel.Model = reader["Model"].ToString();
                            carModel.Coefficient = float.Parse(reader["Coefficient"].ToString());

                        }
                    }
                }
                return carModel;
            }

        }

    }
}
