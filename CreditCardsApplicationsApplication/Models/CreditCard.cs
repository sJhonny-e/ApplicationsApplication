using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditCardsApplicationsApplication.Models
{
    public class CreditCard
    {
        // TODO: better encapsulation of these properties (i.e less public 'set's)
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Apr { get; set; }
        public int BalanceTransferOfferDurationMonths { get; set; }
        public int PurchaseOfferDurationMonths { get; set; }
        public double CreditAvailable { get; set; }

        [Newtonsoft.Json.JsonIgnore]    // Ewww!! This really shouldn't be here...
        public IEnumerable<IEligibilityChecker> EligibilityCheckers { get; set; }

        public CreditCard()
        {
            EligibilityCheckers = new List<IEligibilityChecker>();
        }

        // TODO: maybe think of a more sophisticated rule mechanism here. currently, just 'AND'-ing all checkers
        public virtual bool IsEligible(Applicant applicant)
        {
            foreach (var checker in EligibilityCheckers)
            {
                if (!checker.IsEligible(applicant))
                {
                    return false;
                }
            }

            return true;
        }
    }
}