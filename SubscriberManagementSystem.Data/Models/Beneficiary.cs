using SubscriberManagementSystem.Data.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text;

namespace SubscriberManagementSystem.Data.Models
{
    public class Beneficiary : BaseModel
    {
        [Display(Name = "Id", ResourceType = typeof(Messages))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        public int Id { get; set; }

        [Display(Name = "IDNumber", ResourceType = typeof(Messages))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        [RegularExpression(@"^\d+$", ErrorMessageResourceName = "InvalidNumber", ErrorMessageResourceType = typeof(Messages))]
        public string IDNumber { get; set; }

        [Display(Name = "FName", ResourceType = typeof(Messages))]
        [StringLength(ApplicationConstant.MaxStringName, MinimumLength = ApplicationConstant.MinStringName, ErrorMessageResourceName = "StringLengthValidation", ErrorMessageResourceType = typeof(Messages))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        public string FName { get; set; }

        [Display(Name = "SName", ResourceType = typeof(Messages))]
        [StringLength(ApplicationConstant.MaxStringName, MinimumLength = ApplicationConstant.MinStringName, ErrorMessageResourceName = "StringLengthValidation", ErrorMessageResourceType = typeof(Messages))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        public string SName { get; set; }

        [Display(Name = "TName", ResourceType = typeof(Messages))]
        [StringLength(ApplicationConstant.MaxStringName, MinimumLength = ApplicationConstant.MinStringName, ErrorMessageResourceName = "StringLengthValidation", ErrorMessageResourceType = typeof(Messages))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        public string TName { get; set; }

        [Display(Name = "LName", ResourceType = typeof(Messages))]
        [StringLength(ApplicationConstant.MaxStringName, MinimumLength = ApplicationConstant.MinStringName, ErrorMessageResourceName = "StringLengthValidation", ErrorMessageResourceType = typeof(Messages))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        public string LName { get; set; }



        public string FullName
        {
            get
            {
                return $"{FName} {SName} {TName} {LName}";
            }
        }
    

        [Display(Name = "DOB", ResourceType = typeof(Messages))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }

        [Display(Name = "Gender", ResourceType = typeof(Messages))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        public int? GenderId { get; set; }
        public Constant? Gender { get; set; }

        [Display(Name = "PhoneNumber", ResourceType = typeof(Messages))]
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(Messages))]
        [Phone(ErrorMessageResourceName = "InvalidNumber", ErrorMessageResourceType = typeof(Messages))]
        public string PhoneNumber { get; set; }
        public int? BeneficiaryTypeId { get; set; }
        public Constant? BeneficiaryType { get; set; }
        public bool IsReceivingMessages { get; set; }
        public int? ParentId { get; set; }
        public Beneficiary? Parent { get; set; }

        [NotMapped]
        public string? CampName { get; set; }
        public bool IsActive { get; set; }


    }
}
