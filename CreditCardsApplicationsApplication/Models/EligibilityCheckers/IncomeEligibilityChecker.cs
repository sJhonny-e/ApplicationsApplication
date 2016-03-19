using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditCardsApplicationsApplication.Models.EligibilityCheckers
{
    public class IncomeEligibilityChecker : IEligibilityChecker
    {
        private uint threshold;

        public IncomeEligibilityChecker(uint threshold)
        {
            this.threshold = threshold;
        }


        public bool IsEligible(Applicant applicant)
        {
            return applicant.AnnualIncome > threshold;
        }
    }
}