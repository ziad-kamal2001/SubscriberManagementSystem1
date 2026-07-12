using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriberManagementSystem.Data.Enums
{
    public enum GeneralEnums
    {
        // Main Constant
        Gender = 1,
        HousingStatus = 4,
        WorkStatus = 8,
        TheHealthCondition = 11,
        Accommodation = 14,

        // Gender
        Male = 2,   
        Female = 3,

        // HousingStatus
        TotalDestruction = 5,
        PartialDestruction = 6,
        Intact = 7,
        
        // WorkStatus
        Unemployed = 9,
        Working = 10,

        // TheHealthCondition
        Healthy = 12,
        Negative = 13,

        //Accommodation
        Indoor = 15,
        Outdoor = 16,

        ParentPageId = 1,   // Parent Page Id

        Header = 1, // Page Category
        Page = 2,
        Tool = 3,

        Management = 1, //Modules
        BeneficiariesManagement = 2,

    }
}
