using CreditCardsApplicationsApplication.Models;
using CreditCardsApplicationsApplication.Models.EligibilityCheckers;
using CreditCardsApplicationsApplication.Models.Enums;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCardsApplicationsApplication.Tests.Models.EligibilityCheckers
{
    [TestFixture]
    public class StudentEligibilityCheckerTests
    {
        private StudentEligibilityChecker studentEligibilityChecker = new StudentEligibilityChecker();

        [Test]
        public void IsEligible_ApplicantIsStudent_ReturnsTrue()
        {
            var applicant = new Applicant { EmploymentStatus = EmploymentStatus.Student };  // TODO: use a mock
            Assert.IsTrue(studentEligibilityChecker.IsEligible(applicant));
        }

        [Test]
        public void IsEligible_ApplicantIsntStudent_ReturnsFalse()
        {
            var applicant = new Applicant { EmploymentStatus = EmploymentStatus.Unemployed };
            Assert.IsFalse(studentEligibilityChecker.IsEligible(applicant));
        }
    }
}
