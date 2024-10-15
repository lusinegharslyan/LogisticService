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
    class ContainerRepository : IRepository<Container>
    {
        public const string CONNECTCION_STRING = "Data Source=LUSINE1985\\MSSQLSERVER01;Initial Catalog=LogisticServiceDb;Integrated Security=True;Encrypt=False";

        public async Task AddAsync(Container container)
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
                    command.CommandText = "Delete from Containers  where Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                   await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Container container, int id)
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

                   await command.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task<Container> FindByIdAsync(int id)
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
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
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
        public async Task<List<Container>> GetAllAsync()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                List<Container> containers = new List<Container>();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from Containers ";
                    using (SqlDataReader reader =await command.ExecuteReaderAsync())
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


        public async Task <Container> FindAsync(Container isOpenContainer)
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

                    using (SqlDataReader reader =await command.ExecuteReaderAsync())
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
