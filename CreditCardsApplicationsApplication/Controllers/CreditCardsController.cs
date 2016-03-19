using CreditCardsApplicationsApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CreditCardsApplicationsApplication.Controllers
{
    public class CreditCardsController : ApiController
    {
        private IApplicantsRepository applicantsRepository;
        private ICreditCardsRepository creditCardsRepository;


        public CreditCardsController(IApplicantsRepository applicantsRepository, ICreditCardsRepository creditCardsRepository)
            :base()
        {
            this.applicantsRepository = applicantsRepository;
            this.creditCardsRepository = creditCardsRepository;
        }

        // TODO: remove this and replace with proper DI
        public CreditCardsController():this(new DAL.ApplicantsRepository(), new DAL.CreditCardsRepository())
        {
        
        }
        
        // TODO: Use DTO instead of returning an actual model class
        public IEnumerable<CreditCard> GetCreditCardsForApplicant(int applicantId)
        {
            var applicant = applicantsRepository.Get(applicantId);
            if (applicant == null)
            {
                throw new ArgumentException("No applicant found with id: " + applicantId);
            }

            var allCreditCards = creditCardsRepository.GetAll();
            return allCreditCards.Where(cc => cc.IsEligible(applicant));
        }
    }
}
