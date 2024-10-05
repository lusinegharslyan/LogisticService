using LogisticService.Classes;
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

        public void Add(CarModel carModel)
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

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Delete from CarModels where Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(CarModel carModel, int id)
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

                    command.ExecuteNonQuery();

                }

            }
        }

        public CarModel FindById(int id)
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
                    using (SqlDataReader reader = command.ExecuteReader())
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
        public List<CarModel> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                List<CarModel> carModels = new List<CarModel>();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from CarModels";
                    using (SqlDataReader reader = command.ExecuteReader())
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


        public CarModel Find(CarModel carModelName)
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

                    using (SqlDataReader reader = command.ExecuteReader())
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
