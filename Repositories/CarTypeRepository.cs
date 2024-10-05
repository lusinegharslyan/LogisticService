using LogisticService.Classes;
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

        public void Add(CarType carType)
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
                    command.CommandText = "Delete from CarTypes where Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(CarType carType, int id)
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

                    command.ExecuteNonQuery();

                }

            }
        }

        public CarType FindById(int id)
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
                    using (SqlDataReader reader = command.ExecuteReader())
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
        public List<CarType> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                List<CarType> carTypes = new List<CarType>();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from CarTypes";
                    using (SqlDataReader reader = command.ExecuteReader())
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


        public CarType Find(CarType carTypeName)
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

                    using (SqlDataReader reader = command.ExecuteReader())
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
