using CosmosDbMongoApi.DomainLayer.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDbMongoApi.ApplicationLayer.Services.StudentService
{
    public interface IStudentService
    {
        void CreateStudent(Student student);
    }
}
