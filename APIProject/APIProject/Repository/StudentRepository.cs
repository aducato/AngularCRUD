using APIProject.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext dbContext;

        public StudentRepository(StudentDbContext studentDbContext)
        {
            this.dbContext = studentDbContext;
        }

        public async Task<int> AddStudentAsync(Student StudentModel)
        {
            dbContext.Students.Add(StudentModel);
            await dbContext.SaveChangesAsync();

            return StudentModel.Id;
        }

        public async Task DeleteStudentAsync(int StudentId)
        {
            Student student = new Student() { Id = StudentId };

            dbContext.Students.Remove(student);

            await dbContext.SaveChangesAsync();

        }

        public List<Student> GetAllStudentAsync()
        {

            var AllStudents = dbContext.Students.ToList();

            return AllStudents;
        }

        public async Task<Student> GetStudentByIdAsync(int StudentID)
        {
            var Student = await dbContext.Students.FindAsync(StudentID);

            return Student;


        }

        public async Task UpdateStudentAsync(int StudentId, Student StudentModel)
        {
            StudentModel.Id = StudentId;

            dbContext.Students.Update(StudentModel);
            await dbContext.SaveChangesAsync();

        }



    }
}
