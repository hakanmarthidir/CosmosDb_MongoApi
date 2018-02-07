using CosmosDbMongoApi.SharedKernel.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDbMongoApi.DomainLayer.Student
{
    public class Student : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
