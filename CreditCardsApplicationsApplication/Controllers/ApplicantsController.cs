using CreditCardsApplicationsApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CreditCardsApplicationsApplication.Controllers
{
    public class ApplicantsController : ApiController
    {
        private IApplicantsRepository applicantsRepository;

        // TODO: use proper DI
        public ApplicantsController():base()
        {
            applicantsRepository = new DAL.ApplicantsRepository();
        }

        public IEnumerable<Applicant> GetAll()
        {
            return applicantsRepository.GetAll();
        }
    }
}
