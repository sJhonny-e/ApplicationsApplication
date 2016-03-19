using System.Collections.Generic;
using CreditCardsApplicationsApplication.Models;

namespace CreditCardsApplicationsApplication.Controllers
{
    public interface IApplicantsRepository
    {
        Applicant Get(int applicantId);
        IEnumerable<Applicant> GetAll();
    }
}