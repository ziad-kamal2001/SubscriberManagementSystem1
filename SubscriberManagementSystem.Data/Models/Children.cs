using SubscriberManagementSystem.Data.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SubscriberManagementSystem.Data.Models
{
    public class Children : BaseModel
    {
        [Display(Name = "Id", ResourceType = typeof(Messages))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        public int Id { get; set; }

        [Display(Name = "IDNumber", ResourceType = typeof(Messages))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        [RegularExpression(@"^\d+$", ErrorMessageResourceName = "InvalidNumber", ErrorMessageResourceType = typeof(Messages))]
        public string IDNumber { get; set; }

        [Display(Name = "Name", ResourceType = typeof(Messages))]
        [StringLength(ApplicationConstant.MaxStringName, MinimumLength = ApplicationConstant.MinStringName, ErrorMessageResourceName = "StringLengthValidation", ErrorMessageResourceType = typeof(Messages))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        public string Name { get; set; }

        [Display(Name = "DOB", ResourceType = typeof(Messages))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }

        [Display(Name = "Gender", ResourceType = typeof(Messages))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        public int? GenderId { get; set; }
        public Constant? Gender { get; set; }

        [Display(Name = "Wive", ResourceType = typeof(Messages))]
        [StringLength(ApplicationConstant.MaxStringName, MinimumLength = ApplicationConstant.MinStringName, ErrorMessageResourceName = "StringLengthValidation", ErrorMessageResourceType = typeof(Messages))]
        public int? WiveId { get; set; }
        public Wive? Wive { get; set; }

        [Display(Name = "TheHealthCondition", ResourceType = typeof(Messages))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        public int? TheHealthConditionId { get; set; }
        public TheHealthCondition? TheHealthCondition { get; set; }

        [Display(Name = "Beneficiary", ResourceType = typeof(Messages))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        public int BeneficiaryId { get; set; }
        public Beneficiary? Beneficiary { get; set; }

        public int? ParentId { get; set; }
        public Beneficiary? Parent { get; set; }

    }
}
