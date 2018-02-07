using CosmosDbMongoApi.DomainLayer.Student;
using CosmosDbMongoApi.InfrastructureLayer.Repositories;

namespace CosmosDbMongoApi.ApplicationLayer.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly IGenericRepository<Student> _studentRepository;
        public StudentService(IGenericRepository<Student> studentRepository)
        {
            this._studentRepository = studentRepository;
        }

        public void CreateStudent(Student student)
        {
            this._studentRepository.Insert(student);
        }
    }
}
