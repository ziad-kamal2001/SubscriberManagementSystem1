using SubscriberManagementSystem.Data.Models;

namespace SubscriberManagementSystem.Web.ViewModel.Beneficiaries
{
    public class CreateEditBeneficiaryVM
    {
        public Beneficiary Beneficiary { get; set; }
        public List<Constant> BeneficiaryTypes { get; set; }

        public List<Constant> Genders { get; set; }

        public List<Wive> Wives { get; set; }


    }
}
