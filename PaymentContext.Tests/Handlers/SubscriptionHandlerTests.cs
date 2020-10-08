using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        // Red, Green, Refactor

        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());

            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "Bruce";
            command.LastName = "Wayne";
            command.Document = "12345678901";
            command.Email = "test@email.com";

            command.BarCode = "123456789";
            command.BoletoNumber = "123456789";
            command.PaymentNumber = "123123";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 100;
            command.TotalPaid = 100;
            command.Payer = "Wayne Industries";
            command.PayerDocument = "12345678900";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "batman@dc.com";

            command.Street = "Batcave";
            command.Number = "666";
            command.Neighborhood = "Unknow";
            command.City = "Gotham";
            command.State = "MG";
            command.Country = "EUA";
            command.ZipCode = "36000333";

            var commandResult = handler.Handle(command);
            Assert.AreEqual(false, commandResult.Success);
        }
    }
}
