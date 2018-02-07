using CosmosDbMongoApi.ApplicationLayer.Services.StudentService;
using CosmosDbMongoApi.DomainLayer.Student;
using CosmosDbMongoApi.InfrastructureLayer.Context;
using CosmosDbMongoApi.InfrastructureLayer.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace CosmosDbMongoApi
{
    [TestClass]
    public class MongoReopsitoryTests
    {
        MongoGenericRepository<Student> _repository = new MongoGenericRepository<Student>(new MongoContext());

        [TestMethod]
        public void Cosmosdb_MongoRepository_Insert_ShouldBeTrue()
        {            
            _repository.Insert(new Student() {FirstName = "xyz", ModifiedDate = DateTime.UtcNow, LastName = "def", CreatedDate = DateTime.UtcNow });
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Cosmosdb_MongoServiceLayer_Insert_ShouldBeTrue()
        {                    
            var _service = new StudentService(_repository);
            _service.CreateStudent(new Student() { FirstName = "cdf", ModifiedDate = DateTime.UtcNow, LastName = "ghf", CreatedDate = DateTime.UtcNow });
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Cosmosdb_MongoRepository_Delete_ShouldBeTrue()
        {            
            _repository.Delete("5a7ab4caad2fdc1bd838d646");
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Cosmosdb_MongoRepository_GetById_ShouldNotBeNull()
        {            
            var student= _repository.GetById("5a7ab7fbad2fdc1f54ef6d90");
            Debug.WriteLine(student.FirstName);
            Assert.IsNotNull(student.FirstName);
        }

        [TestMethod]
        public void Cosmosdb_MongoRepository_GetAll_ShouldBeTrue()
        {            
            var studentList = _repository.GetAll();
            foreach (var item in studentList)
            {
                Debug.WriteLine(item.FirstName);
            }
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Cosmosdb_MongoRepository_GetAllWithCriteria_ShouldBeTrue()
        {            
            var studentList = _repository.GetAll(x=>x.FirstName=="xyz");
            foreach (var item in studentList)
            {
                Debug.WriteLine(item._Id);
            }
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Cosmosdb_MongoRepository_Update_ShouldBeTrue()
        {            
            _repository.Update(new Student() { _Id= "5a7ab4caad2fdc1bd838d646", FirstName = "denver", ModifiedDate = DateTime.UtcNow, LastName = "thelastdinasour", CreatedDate = DateTime.UtcNow });            
            Assert.IsTrue(true);
        }

    }
}
