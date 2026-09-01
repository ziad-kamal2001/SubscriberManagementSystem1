using SubscriberManagementSystem.Data.Enums;
using SubscriberManagementSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SubscriberManagementSystem.Data.SeedHeper.PageSeed;

namespace SubscriberManagementSystem.Data.SeedHeper
{
    public static class SeedHelper
    {
        public static void Seed(this ModelBuilder builder)
        {
            SeedPageCategories(builder);
            SeedModules(builder);
            SeedConstants(builder);
            PagesSeed.Seed(builder);
            
        }

        private static void SeedPageCategories(ModelBuilder builder)
        {
            builder.Entity<PageCategory>().HasData(
                new PageCategory { Id = 1, Name = "Header" },
                new PageCategory { Id = 2, Name = "Page" },
                new PageCategory { Id = 3, Name = "Tool" }
            );
        }

        private static void SeedModules(ModelBuilder builder)
        {
            builder.Entity<Module>().HasData(
                    new Module { Id = 1, Name = "الادارة", Status = true },
                new Module { Id = 2, Name = "إدارة العملاء", Status = true },
                new Module { Id = 3, Name = "إدارة الخدمات", Status = true },
                new Module { Id = 4, Name = "المالية", Status = true }
            );
        }

        private static void SeedConstants(ModelBuilder builder)
        {
            builder.Entity<Constant>().HasData(
 

                new Constant { Id = 1, Name = "الجنس" }, // Gender
                new Constant { Id = 2, Name = "ذكر", ParentId = 1 },
                new Constant { Id = 3, Name = "أنثى", ParentId = 1 },

                new Constant { Id = 4, Name = "حالة السكن" }, // HousingStatus
                new Constant { Id = 5, Name = "تدمير كلي", ParentId = 4 }, // TotalDestruction
                new Constant { Id = 6, Name = "تدمير جزئي", ParentId = 4 }, // PartialDestruction
                new Constant { Id = 7, Name = "سليم", ParentId = 4 }, // Intact

                new Constant { Id = 8, Name = "حالة العمل" }, // WorkStatus
                new Constant { Id = 9, Name = "لا يعمل", ParentId = 8 }, // Unemployed
                new Constant { Id = 10, Name = "يعمل", ParentId = 8 }, // Working
                

                new Constant { Id = 11, Name = "الحالة الصحية" }, // TheHealthCondition
                new Constant { Id = 12, Name = "سليم", ParentId = 11 }, // Healthy
                new Constant { Id = 13, Name = "مصاب", ParentId = 11 },// Negative


                new Constant { Id = 14, Name = " الاقامة مكان" }, // Accommodation
                new Constant { Id = 15, Name = "داخلي", ParentId = 14 },//Indoor
                new Constant { Id = 16, Name = "خارجي", ParentId = 14 },//Outdoor

                new Constant { Id = 17, Name = "نوع المستفيد" }, // BeneficiaryType
                new Constant { Id = 18, Name = "زبون", ParentId = 17 },
                new Constant { Id = 19, Name = "مورد", ParentId = 17 },
                new Constant { Id = 20, Name = "مزود خدمة", ParentId = 17 }

            );
        }

       
    }
}
