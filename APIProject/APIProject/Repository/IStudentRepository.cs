using APIProject.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.Repository
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudentAsync();
        Task<Student> GetStudentByIdAsync(int StudentID);
        Task<int> AddStudentAsync(Student StudentModel);
        Task UpdateStudentAsync(int StudentId, Student StudentModel);
        Task DeleteStudentAsync(int StudentId);

    }
}
