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
        [Display(Name = "OriginalCity", ResourceType = typeof(Messages))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        public string OriginalCity { get; set; }
        [Display(Name = "CurrentCity", ResourceType = typeof(Messages))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        public string CurrentCity { get; set; }
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

    }
}
