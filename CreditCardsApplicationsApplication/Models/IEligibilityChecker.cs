namespace CreditCardsApplicationsApplication.Models
{
    public interface IEligibilityChecker
    {
        bool IsEligible(Applicant applicant);
    }
}