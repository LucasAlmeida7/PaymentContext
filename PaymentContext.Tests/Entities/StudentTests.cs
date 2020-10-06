using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void AddSubscription()
        {
            //var student = new Student("Jhon","Doo", "123.456.789.00", "example@email.com");
            
            var subscription = new Subscription(null);

            //student.AddSubscription(subscription);
        }
    }
}
