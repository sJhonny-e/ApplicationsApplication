using System.Collections.Generic;
using CreditCardsApplicationsApplication.Models;

namespace CreditCardsApplicationsApplication.Controllers
{
    public interface ICreditCardsRepository
    {
        IEnumerable<CreditCard> GetAll();
    }
}