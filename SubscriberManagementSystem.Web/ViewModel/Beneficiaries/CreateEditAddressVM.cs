using SubscriberManagementSystem.Data.Models;

namespace SubscriberManagementSystem.Web.ViewModel.Beneficiaries
{
    public class CreateEditAddressVM
    {
        public BeneficiaryInformation BeneficiaryInformation { get; set; }
  
        public List<Constant> AddressTypes { get; set; }

        public Wive Wives { get; set; }
        public List<Constant> BeneficiaryTypes { get; internal set; }
    }
}
