using CreditCardsApplicationsApplication.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardsApplicationsApplication.Tests.Models
{
    [TestFixture]
    public class CreditCardTests
    {
        private CreditCard creditCard;
        private Applicant applicant = new Applicant();  // TODO: this should probably be a mock as well

        [TestFixtureSetUp]
        public void Init()
        {
            creditCard = new CreditCard();
        }

        [Test]
        public void IsEligible_WithNoCheckers_ReturnsTrue()
        {
            Assert.IsTrue(creditCard.IsEligible(applicant));
        }

        [Test]
        public void IsEligible_WithAllCheckersReturningTrue_ReturnsTrue()
        {
            var firstChecker = new Mock<IEligibilityChecker>();
            firstChecker.Setup(checker => checker.IsEligible(applicant))
                .Returns(true);

            var secondChecker = new Mock<IEligibilityChecker>();
            secondChecker.Setup(checker => checker.IsEligible(applicant))
                .Returns(true);

            creditCard.EligibilityCheckers = new IEligibilityChecker[] { firstChecker.Object, secondChecker.Object };

            Assert.IsTrue(creditCard.IsEligible(applicant));
        }

        [Test]
        public void IsEligible_WithOneCheckerReturningFalse_ReturnsFalse()
        {
            var firstChecker = new Mock<IEligibilityChecker>();
            firstChecker.Setup(checker => checker.IsEligible(applicant))
                .Returns(true);

            var secondChecker = new Mock<IEligibilityChecker>();
            secondChecker.Setup(checker => checker.IsEligible(applicant))
                .Returns(false);

            creditCard.EligibilityCheckers = new IEligibilityChecker[] { firstChecker.Object, secondChecker.Object };

            Assert.IsFalse(creditCard.IsEligible(applicant));
        }
    }
}
