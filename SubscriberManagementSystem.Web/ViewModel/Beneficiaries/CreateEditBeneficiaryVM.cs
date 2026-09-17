using SubscriberManagementSystem.Data.Models;
using SubscriberManagementSystem.Infrastructure.Services.Beneficiaries;
namespace SubscriberManagementSystem.Web.ViewModel.Beneficiaries
{ 
public class CreateEditBeneficiaryVM
{
    public Beneficiary Beneficiary { get; set; }
    public List<Constant> BeneficiaryTypes { get; set; }
    public List<Constant> Genders { get; set; }
    public List<Wive> Wives { get; set; }

    public List<Constant> MaritalStatuses { get; set; }
    public List<Constant> BreadwinnerStatuses { get; set; }
    public List<Constant> WifeStatuses { get; set; }
    public List<Constant> ResidenceStatuses { get; set; }
    public List<City> Cities { get; set; }

    public List<TheHealthCondition> HealthConditions { get; set; } // جديد

    public FamilyMembersCountDto FamilyMembersCount { get; set; }
}
}