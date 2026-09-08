using SubscriberManagementSystem.Data.Resources;
using System.ComponentModel.DataAnnotations;

namespace SubscriberManagementSystem.Data.Models
{
    // Simple lookup table for cities/governorates. Used both as the
    // "governorate" level (Beneficiary.OriginalGovernorateCityId,
    // BeneficiaryInformation.CurrentGovernorateCityId) and the
    // "city" level (BeneficiaryInformation.CurrentCityId) of the extended
    // Beneficiary CreateEdit form, per your instruction to reuse one City table
    // for both instead of introducing a separate Governorate table.
    public class City
    {
        public int Id { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Messages))]
        [StringLength(ApplicationConstant.MaxStringName, MinimumLength = ApplicationConstant.MinStringName, ErrorMessageResourceName = "StringLengthValidation", ErrorMessageResourceType = typeof(Messages))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        public string Name { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
