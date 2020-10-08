using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Queries
{
    [TestClass]
    public class StudentQueriesTests
    {
        private IList<Student> _students;

        public StudentQueriesTests()
        {
            _students = new List<Student>();

            for (int i = 0; i < 10; i++)
            {
                var name = new Name("Estudante", i.ToString());
                var document = new Document($"1231231231{i.ToString()}", EDocumentType.CPF);
                var email = new Email($"estudante{i.ToString()}@email.com");

                _students.Add(new Student(name, document, email));
            }
        }

        [TestMethod]
        public void ShouldReturnNullWhenDocumentNotExists()
        {
            var exp = StudentQueries.GetStudentInfo("12312312399");
            var student = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreEqual(null, student);
        }

        [TestMethod]
        public void ShouldReturnStudentWhenDocumentNotExists()
        {
            var exp = StudentQueries.GetStudentInfo("12312312312");
            var student = _students.AsQueryable().Where(exp).FirstOrDefault();

            Assert.AreNotEqual(null, student);
        }
    }
}