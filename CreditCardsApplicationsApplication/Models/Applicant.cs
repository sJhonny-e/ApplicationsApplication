using CreditCardsApplicationsApplication.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditCardsApplicationsApplication.Models
{
    public class Applicant
    {
        // TODO: better encapsulation of these properties (i.e less public 'set's)
        public int Id { get; set; }
        public Title Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public uint AnnualIncome { get; set; }
        public EmploymentStatus EmploymentStatus { get; set; }
        public string HouseNumber { get; set; }
        public string Postcode { get; set; }
        public string ImageUrl { get; set; }

    }
}