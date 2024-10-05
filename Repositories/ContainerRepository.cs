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
    class ContainerRepository : IRepository<Container>
    {
        public const string CONNECTCION_STRING = "Data Source=LUSINE1985\\MSSQLSERVER01;Initial Catalog=LogisticServiceDb;Integrated Security=True;Encrypt=False";

        public void Add(Container container)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into Containers values(@IsOpen, @Coefficient)";
                    command.Parameters.Add(new SqlParameter("@IsOpen", container.IsOpen));
                    command.Parameters.Add(new SqlParameter("@Coefficient", container.Coefficient));

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
                    command.CommandText = "Delete from Containers  where Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Container container, int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "update Containers  set IsOpen = @IsOpen,Coefficient= @Coefficient where Id= @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    command.Parameters.Add(new SqlParameter("@IsOpen", container.IsOpen));
                    command.Parameters.Add(new SqlParameter("@Coefficient", container.Coefficient));

                    command.ExecuteNonQuery();

                }

            }
        }

        public Container FindById(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                Container container = new Container();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from Containers  where Id=@Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            container.Id = int.Parse(reader["Id"].ToString());
                            container.IsOpen = bool.Parse(reader["IsOpen"].ToString());
                            container.Coefficient = float.Parse(reader["Coefficient"].ToString());

                        }
                    }
                }
                return container;
            }
        }
        public List<Container> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                List<Container> containers = new List<Container>();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from Containers ";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Container container = new Container();
                            container.Id = int.Parse(reader["Id"].ToString());
                            container.IsOpen = bool.Parse(reader["IsOpen"].ToString());
                            container.Coefficient = float.Parse(reader["Coefficient"].ToString());

                            containers.Add(container);
                        }
                    }
                }
                return containers;

            }
        }


        public Container Find(Container isOpenContainer)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                Container container = new Container();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from Containers where IsOpen=@IsOpen";
                    command.Parameters.Add(new SqlParameter("@IsOpen", isOpenContainer.IsOpen));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            container.Id = int.Parse(reader["Id"].ToString());
                            container.IsOpen = bool.Parse(reader["IsOpen"].ToString());
                            container.Coefficient = float.Parse(reader["Coefficient"].ToString());

                        }
                    }
                }
                return container;
            }


        }

    }
}
