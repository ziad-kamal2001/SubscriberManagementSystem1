using SubscriberManagementSystem.Data.Resources;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SubscriberManagementSystem.Data.Models
{
    public class BeneficiaryInformation : BaseModel
    {
        [Display(Name = "Id", ResourceType = typeof(Messages))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        public int Id { get; set; }

        [Display(Name = "Beneficiary", ResourceType = typeof(Messages))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        public int BeneficiaryId { get; set; }
        public Beneficiary? Beneficiary { get; set; }

        [Display(Name = "NumberofIndividuals", ResourceType = typeof(Messages))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        public int? NumberofIndividuals { get; set; }

        // NOTE: OriginalCity (free text) removed — original governorate now lives on
        // Beneficiary.OriginalGovernorateCityId (FK to City), per the extended survey form.

        [Display(Name = "Camp", ResourceType = typeof(Messages))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        public string Camp { get; set; }

        [Display(Name = "TotalAid", ResourceType = typeof(Messages))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        public int TotalAid { get; set; }

        [Display(Name = "HousingStatus", ResourceType = typeof(Messages))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        public int? HousingStatusId { get; set; }
        public HousingStatus? HousingStatus { get; set; }

        [Display(Name = "WorkStatus", ResourceType = typeof(Messages))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        public int? WorkStatusId { get; set; }
        public WorkStatus? WorkStatus { get; set; }


        [Display(Name = "TheHealthCondition", ResourceType = typeof(Messages))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        public int? TheHealthConditionId { get; set; }
        public TheHealthCondition? TheHealthCondition { get; set; }

        [Display(Name = "Accommodation", ResourceType = typeof(Messages))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        public int? AccommodationId { get; set; }
        public Accommodation? Accommodation { get; set; }
        public bool IsDefaultAddress { get; set; }

        // ---- New extended-form fields ----

        [Display(Name = "CurrentGovernorate", ResourceType = typeof(Messages))]
        public int? CurrentGovernorateCityId { get; set; }
        public City? CurrentGovernorateCity { get; set; }

        [Display(Name = "CurrentCity", ResourceType = typeof(Messages))]
        public int? CurrentCityId { get; set; }
        public City? CurrentCity { get; set; }

        [Display(Name = "Neighborhood", ResourceType = typeof(Messages))]
        public string? Neighborhood { get; set; }

        [Display(Name = "NearestLandmark", ResourceType = typeof(Messages))]
        public string? NearestLandmark { get; set; }

        [Display(Name = "ResidenceStatus", ResourceType = typeof(Messages))]
        public int? ResidenceStatusId { get; set; }
        public Constant? ResidenceStatus { get; set; }

    }
}