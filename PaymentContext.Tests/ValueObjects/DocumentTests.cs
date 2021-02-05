using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        public void ShouldReturnErrorWhenCNPJIsInvalid(){
            var document = new Document("123", EDocumentType.CNPJ);
            Assert.IsTrue(document.Invalid);
        }

        public void ShouldReturnSuccessWhenCNPJIsValid(){
            var document = new Document("40013544000102", EDocumentType.CNPJ);
            Assert.IsTrue(document.Valid);
        }

        public void ShouldReturnErrorWhenCPFIsInvalid(){
            var document = new Document("1234", EDocumentType.CPF);
            Assert.IsTrue(document.Valid);
        }

        public void ShouldReturnSuccessWhenCPFIsValid(){
             var document = new Document("96132564071", EDocumentType.CPF);
            Assert.IsTrue(document.Valid);
        }
    }
}