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

    class DirectionRepository : IRepository<Direction>
    {
        public const string CONNECTCION_STRING = "Data Source=LUSINE1985\\MSSQLSERVER01;Initial Catalog=LogisticServiceDb;Integrated Security=True;Encrypt=False";

        public async Task AddAsync(Direction direction)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into Directions values(@FromDir, @ToDir, @Distance,@Price)";
                    command.Parameters.Add(new SqlParameter("@FromDir", direction.From));
                    command.Parameters.Add(new SqlParameter("@ToDir", direction.To));
                    command.Parameters.Add(new SqlParameter("@Distance", direction.Distance));
                    command.Parameters.Add(new SqlParameter("@Price", direction.Price));
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
                    command.CommandText = "Delete from Directions where Id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Direction direction, int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "update Directions set FromDir = @From,ToDir= @To, Distance = @Distance,Price = @Price where Id= @Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    command.Parameters.Add(new SqlParameter("@From", direction.From));
                    command.Parameters.Add(new SqlParameter("@To", direction.To));
                    command.Parameters.Add(new SqlParameter("@Distance", direction.Distance));
                    command.Parameters.Add(new SqlParameter("@Price", direction.Price));
                    await command.ExecuteNonQueryAsync();

                }
            }
        }

        public async Task<Direction> FindByIdAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                Direction direction = new Direction();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from Directions where Id=@Id";
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            direction.Id = int.Parse(reader["Id"].ToString());
                            direction.From = reader["FromDir"].ToString();
                            direction.To = reader["ToDir"].ToString();
                            direction.Distance = float.Parse(reader["Distance"].ToString());
                            direction.Price = float.Parse(reader["Price"].ToString());

                        }
                    }
                }
                return direction;
            }
        }
        public async Task<List<Direction>> GetAllAsync()
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                List<Direction> directions = new List<Direction>();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from Directions";
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            Direction direction = new Direction();
                            direction.Id = int.Parse(reader["Id"].ToString());
                            direction.From = reader["FromDir"].ToString();
                            direction.To = reader["ToDir"].ToString();
                            direction.Distance = float.Parse(reader["Distance"].ToString());
                            direction.Price = float.Parse(reader["Price"].ToString());

                            directions.Add(direction);
                        }
                    }
                }
                return directions;

            }
        }


        public async Task<Direction> FindAsync(Direction directionPoints)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTCION_STRING))
            {
                connection.Open();
                Direction direction = new Direction();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select * from Directions where FromDir=@From and ToDir = @To";
                    command.Parameters.Add(new SqlParameter("@From", directionPoints.From));
                    command.Parameters.Add(new SqlParameter("@To", directionPoints.To));
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            direction.Id = int.Parse(reader["Id"].ToString());
                            direction.From = reader["FromDir"].ToString();
                            direction.To = reader["ToDir"].ToString();
                            direction.Distance = float.Parse(reader["Distance"].ToString());
                            direction.Price = float.Parse(reader["Price"].ToString());

                        }
                    }
                }
                return direction;
            }
        }
    }
}
