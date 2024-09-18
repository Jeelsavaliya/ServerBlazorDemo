using ServerBlazorDemo.Models;

namespace ServerBlazorDemo.Services
{
    public interface IStudentService
    {
        public Task<List<Student>> GetAllStudentsAsync();
        public Task AddStudent(Student student);
        public Task UpdateStudent(Student student);
        public Task DeleteStudentAsync(int StudentId);
    }
}
