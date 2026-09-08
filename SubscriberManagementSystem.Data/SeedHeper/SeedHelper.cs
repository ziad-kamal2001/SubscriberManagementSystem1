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
            SeedCities(builder);
            PagesSeed.Seed(builder);

        }

        private static void SeedCities(ModelBuilder builder)
        {
            // Same City table is reused for both "governorate" and "city" dropdowns
            // in the extended Beneficiary CreateEdit form.
            builder.Entity<City>().HasData(
                new City { Id = 1, Name = "شمال غزة" },
                new City { Id = 2, Name = "محافظة غزة" },
                new City { Id = 3, Name = "المحافظة الوسطى" },
                new City { Id = 4, Name = "محافظة خانيونس" },
                new City { Id = 5, Name = "محافظة رفح" },
                new City { Id = 6, Name = "غ ش" } // TODO: confirm full label — text appears truncated in the UI
            );
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
                new Constant { Id = 20, Name = "مزود خدمة", ParentId = 17 },

                // ---- New Constant groups for the extended Beneficiary CreateEdit form ----

                new Constant { Id = 21, Name = "الحالة الإجتماعية" }, // MaritalStatus
                new Constant { Id = 22, Name = "متزوج", ParentId = 21 }, // Married
                new Constant { Id = 23, Name = "أرمل", ParentId = 21 }, // Widowed
                new Constant { Id = 24, Name = "مطلق", ParentId = 21 }, // Divorced
                new Constant { Id = 25, Name = "منفصل", ParentId = 21 }, // Separated
                new Constant { Id = 26, Name = "متعدد الزوجات", ParentId = 21 }, // Polygamous

                new Constant { Id = 27, Name = "معيل الأسرة" }, // BreadwinnerStatus
                new Constant { Id = 28, Name = "الأب", ParentId = 27 }, // Father
                new Constant { Id = 29, Name = "الأم", ParentId = 27 }, // Mother
                new Constant { Id = 30, Name = "غير ذلك", ParentId = 27 }, // Other

                new Constant { Id = 31, Name = "حالة الزوجة" }, // WifeStatus
                new Constant { Id = 32, Name = "لا يوجد", ParentId = 31 }, // NoWife
                new Constant { Id = 33, Name = "على قيد الحياة", ParentId = 31 }, // WifeAlive
                new Constant { Id = 34, Name = "متوفاة", ParentId = 31 }, // WifeDeceased

                new Constant { Id = 35, Name = "حالة المسكن" }, // ResidenceStatus (ownership) — distinct from HousingStatus (destruction level)
                new Constant { Id = 36, Name = "ملك", ParentId = 35 }, // Owned
                new Constant { Id = 37, Name = "إيجار", ParentId = 35 }, // Rented
                new Constant { Id = 38, Name = "بدون سكن", ParentId = 35 } // WithoutResidence

            );
        }


    }
}