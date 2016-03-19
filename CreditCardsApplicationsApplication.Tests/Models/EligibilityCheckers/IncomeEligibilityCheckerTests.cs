using CreditCardsApplicationsApplication.Models;
using CreditCardsApplicationsApplication.Models.EligibilityCheckers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardsApplicationsApplication.Tests.Models.EligibilityCheckers
{
    [TestFixture]
    public class IncomeEligibilityCheckerTests
    {
        // TODO: use a mock here
        private Applicant averageDotNetProgrammer = new Applicant { AnnualIncome = 42539 }; // http://stackoverflow.com/research/developer-survey-2015#work-complang

        [Test]
        public void IsEligible_AnnualIncomeBelowThreshold_ReturnsFalse()
        {
            var incomeChecker = new IncomeEligibilityChecker(threshold: 50000);
            Assert.IsFalse(incomeChecker.IsEligible(averageDotNetProgrammer));
        }

        [Test]
        public void IsEligible_AnnualIncomeEqualsThreshold_ReturnsFalse()
        {
            var incomeChecker = new IncomeEligibilityChecker(threshold: 42539);
            Assert.IsFalse(incomeChecker.IsEligible(averageDotNetProgrammer));
        }

        [Test]
        public void IsEligible_AnnualIncomeAboveThreshold_ReturnsTrue()
        {
            var incomeChecker = new IncomeEligibilityChecker(threshold: 42538);
            Assert.IsTrue(incomeChecker.IsEligible(averageDotNetProgrammer));
        }
    }
}
