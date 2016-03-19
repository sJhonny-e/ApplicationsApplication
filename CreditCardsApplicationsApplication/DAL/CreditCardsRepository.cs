using CreditCardsApplicationsApplication.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CreditCardsApplicationsApplication.Models;
using CreditCardsApplicationsApplication.Models.EligibilityCheckers;

namespace CreditCardsApplicationsApplication.DAL
{
    public class CreditCardsRepository : ICreditCardsRepository
    {
        private CreditCard[] allCreditCards =
        {
            new CreditCard
            {
                Id = 1,
                Name = "Student Life Card",
                Description = "5% cashback on beer!",
                Apr = 18.9,
                BalanceTransferOfferDurationMonths = 0,
                PurchaseOfferDurationMonths = 6,
                CreditAvailable = 1200,
                EligibilityCheckers = new IEligibilityChecker [] { new StudentEligibilityChecker() }
            },
            new CreditCard
            {
                Id = 2,
                Name = "Anywhere Card",
                Description = "Accepted almost nowhere!",
                Apr = 33.9,
                BalanceTransferOfferDurationMonths = 0,
                PurchaseOfferDurationMonths = 0,
                CreditAvailable = 300
            },
            new CreditCard
            {
                Id = 3,
                Name = "Liquid Card",
                Description = "Quick, before we freeze all your assets",
                Apr = 33.9,
                BalanceTransferOfferDurationMonths = 12,
                PurchaseOfferDurationMonths = 6,
                CreditAvailable = 3000,
                EligibilityCheckers = new IEligibilityChecker[] { new IncomeEligibilityChecker(1600 * 12)}  // Available only if you make > 1600 a month
            }
        };

        public IEnumerable<CreditCard> GetAll()
        {
            return allCreditCards;
        }
    }
}