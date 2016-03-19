using CreditCardsApplicationsApplication.Controllers;
using CreditCardsApplicationsApplication.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardsApplicationsApplication.Tests.Controllers
{
    [TestFixture]
    public class CreditCardsControllerTests
    {

        private Mock<IApplicantsRepository> applicantsRepoMock = new Mock<IApplicantsRepository>();
        private Mock<ICreditCardsRepository> creditCardsRepoMock = new Mock<ICreditCardsRepository>();

        private CreditCardsController controller;

        private Applicant applicant = new Applicant();  // TODO use a mock instead

        [SetUp]
        public void Init()
        {
            applicantsRepoMock.Setup(repo => repo.Get(1))
                .Returns(applicant);
            applicantsRepoMock.Setup(repo => repo.Get(It.IsNotIn(new int[] { 1 })))
                .Returns((Applicant)null);

            controller = new CreditCardsController(applicantsRepoMock.Object, creditCardsRepoMock.Object);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(ArgumentException))]
        public void GetCreditCardsForApplicant_WhenApplicantDoesntExist_ThrowsError()
        {
            controller.GetCreditCardsForApplicant(55);
        }

        [Test]
        public void GetCreditCardsForApplicant_WhenNoCreditCardsExist_ReturnsEmptyList()
        {
            creditCardsRepoMock.Setup(repo => repo.GetAll())
                .Returns(new CreditCard[] { });
            Assert.IsEmpty(controller.GetCreditCardsForApplicant(1));
        }

        [Test]
        public void GetCreditCardsForApplicant_WhenCreditCardsWithoutConditionsExist_ReturnsCreditCards()
        {
            var firstCreditCard = Mock.Of<CreditCard>(cc => cc.IsEligible(applicant) == true);
            var secondCreditCard = Mock.Of<CreditCard>(cc => cc.IsEligible(applicant) == true);
            var allCreditCards = new CreditCard[] { firstCreditCard, secondCreditCard };
            creditCardsRepoMock.Setup(repo => repo.GetAll())
                .Returns(allCreditCards);

            Assert.AreEqual(allCreditCards, controller.GetCreditCardsForApplicant(1));
        }

        [Test]
        public void GetCreditCardsForApplicant_WhenCreditCardsWithConditionsExist_ReturnsOnlyEligibleCreditCards()
        {
            var firstCreditCard = Mock.Of<CreditCard>(cc => cc.IsEligible(applicant) == true);
            var secondCreditCard = Mock.Of<CreditCard>(cc => cc.IsEligible(applicant) == false );
            
            var allCreditCards = new CreditCard[] { firstCreditCard, secondCreditCard };
            creditCardsRepoMock.Setup(repo => repo.GetAll())
                .Returns(allCreditCards);

            Assert.AreEqual(new CreditCard[] { firstCreditCard }, controller.GetCreditCardsForApplicant(1));
        }
    }
}
