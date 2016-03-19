using CreditCardsApplicationsApplication.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CreditCardsApplicationsApplication.Models;
using CreditCardsApplicationsApplication.Models.Enums;

namespace CreditCardsApplicationsApplication.DAL
{
    public class ApplicantsRepository : IApplicantsRepository
    {
        private Applicant[] allApplicants =
        {
            new Applicant()
            {
                Id = 1,
                Title = Title.Mr,
                FirstName = "Ollie",
                LastName = "Murphree",
                DateOfBirth = new DateTime(1970,7,1),
                AnnualIncome = 34000,
                EmploymentStatus = EmploymentStatus.FullTime,
                HouseNumber = "700",
                Postcode = "BS14 9PR",
                ImageUrl = @"http://media.salon.com/2015/07/donald_trump12.jpg"
            },
            new Applicant()
            {
                Id = 2,
                Title = Title.Ms,
                FirstName = "Elizabeth",
                LastName = "Edmundson",
                DateOfBirth = new DateTime(1984,6,29),
                AnnualIncome = 17000,
                EmploymentStatus = EmploymentStatus.Student,
                HouseNumber = "177",
                Postcode = "PH12 8UW",
                ImageUrl = @"http://fartashphoto.files.wordpress.com/2010/12/funny-hillary-clinton-picture.jpg#hillary%20looks%20crazy%20300x219"
            },
            new Applicant()
            {
                Id = 3,
                Title = Title.Mr,
                FirstName = "Trevor",
                LastName = "Rieck",
                DateOfBirth = new DateTime(1990,9,7),
                AnnualIncome = 15000,
                EmploymentStatus = EmploymentStatus.PartTime,
                HouseNumber = "343",
                Postcode = "TS25 2NF",
                ImageUrl = @"https://ronethebuzzcincy.files.wordpress.com/2013/01/funny-obama1.jpg"
            },
        };

        public Applicant Get(int applicantId)
        {
            return allApplicants.FirstOrDefault(app => app.Id == applicantId);
        }

        public IEnumerable<Applicant> GetAll()
        {
            return allApplicants;
        }
    }
}