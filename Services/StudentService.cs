using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ServerBlazorDemo.Models;
using System.Data;

namespace ServerBlazorDemo.Services
{
    public class StudentService : IStudentService
    {
        public static string connectionString = "AppDbContextConnection";

        private readonly BlazorDbContext _dbContext;

        public StudentService(BlazorDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }


        public async Task<List<Student>> GetAllStudentsAsync()
        {
            string sql = "EXEC PR_Student_SelectAll";
            var students = await _dbContext.Students.FromSqlRaw(sql).ToListAsync();
            return students;
        }

        public async Task AddStudent(Student student)
        {
            string sql = "EXEC PR_Student_Insert @FirstName, @LastName, @Std, @Address, @City";
            List<SqlParameter> parms = new List<SqlParameter>
    {
        new SqlParameter { ParameterName = "@FirstName", Value = @student.FirstName },
        new SqlParameter { ParameterName = "@LastName", Value = @student.LastName },
        new SqlParameter { ParameterName = "@Std", Value = @student.Std },
        new SqlParameter { ParameterName = "@Address", Value = @student.Address },
        new SqlParameter { ParameterName = "@City", Value = @student.City },
    };

            var stdData = _dbContext.Database.ExecuteSqlRaw(sql, parms.ToArray());
         
        }
        public async Task DeleteStudentAsync(int id)
        {
            string sql = "EXEC PR_Student_Delete @Id";
            var idParam = new SqlParameter("@Id", id);
            await _dbContext.Database.ExecuteSqlRawAsync(sql, idParam);
        }

        /*public async Task<List<Student>> GetAllStudentsAsync()
        {
            var students = new List<Student>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("PR_Student_SelectAll", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    await connection.OpenAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var student = new Student
                            {
                                Id = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2), 
                                Std = reader.GetInt32(3),
                                Address = reader.GetString(4), 
                                City = reader.GetString(5)
                            };

                            students.Add(student);
                        }
                    }
                }
            }
            return students;
        }*/

        /*public async Task AddStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("PR_Student_Insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", student.FirstName);
                    command.Parameters.AddWithValue("@LastName", student.LastName);
                    command.Parameters.AddWithValue("@Std", student.Std);
                    command.Parameters.AddWithValue("@Address", student.Address);
                    command.Parameters.AddWithValue("@City", student.City);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                    connection.Close();
                }
            }
        }*/

        public async Task UpdateStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("PR_Student_Update", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", student.Id);
                    command.Parameters.AddWithValue("@FirstName", student.FirstName);
                    command.Parameters.AddWithValue("@LastName", student.LastName);
                    command.Parameters.AddWithValue("@Std", student.Std);
                    command.Parameters.AddWithValue("@Address", student.Address);
                    command.Parameters.AddWithValue("@City", student.City);

                    connection.Open();
                    await command.ExecuteNonQueryAsync();
                    connection.Close();
                }
            }
        }

        //public async Task DeleteStudentAsync(int id)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand command = new SqlCommand("PR_Student_Delete", connection))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;
        //            command.Parameters.AddWithValue("@Id", id);

        //            connection.Open();
        //            await command.ExecuteNonQueryAsync();
        //            connection.Close();
        //        }
        //    }
        //}
    }
}
