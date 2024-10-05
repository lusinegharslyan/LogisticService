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
    class CrashedCarRepository : IRepository<CrashedCar>
    {
        public const string CONNECTCION_STRING = "Data Source=LUSINE1985\\MSSQLSERVER01;Initial Catalog=LogisticServiceDb;Integrated Security=True;Encrypt=False";

        public void Add(CrashedCar crashedCar)
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
                    command.CommandText = "Delete from CrashedCars  where Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(CrashedCar crashedCar, int id)
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

                    command.ExecuteNonQuery();

                }

            }
        }

        public CrashedCar FindById(int id)
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
                    using (SqlDataReader reader = command.ExecuteReader())
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
        public List<CrashedCar> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                List<CrashedCar> crashedCars = new List<CrashedCar>();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from CrashedCars ";
                    using (SqlDataReader reader = command.ExecuteReader())
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


        public CrashedCar Find(CrashedCar isCrashedCar)
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

                    using (SqlDataReader reader = command.ExecuteReader())
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
