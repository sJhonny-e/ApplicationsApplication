using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditCardsApplicationsApplication.Models.EligibilityCheckers
{
    public class StudentEligibilityChecker : IEligibilityChecker
    {
        public bool IsEligible(Applicant applicant)
        {
            return applicant.EmploymentStatus == Enums.EmploymentStatus.Student;
        }
    }
}