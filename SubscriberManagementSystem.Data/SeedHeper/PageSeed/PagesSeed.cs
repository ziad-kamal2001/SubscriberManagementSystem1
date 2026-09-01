using SubscriberManagementSystem.Data.Enums;
using SubscriberManagementSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriberManagementSystem.Data.SeedHeper.PageSeed
{
    public static class PagesSeed
    {
        // seed Pages and Pass Pages To User To Seed User Permissions
        public static void Seed(this ModelBuilder builder)
        {
            var pages = new List<Page>()
            {
                                new Page()
                                {
                                    Id = 1,
                                    Name = "الاب",
                                    NameEn = "Parent Page",
                                    CategoryId = (int)GeneralEnums.Header
                                },
                                new Page()
                                {
                                    Id = 2,
                                    Name = "الرئيسية",
                                    NameEn = "Home",
                                    Icon = "bi bi-house-fill",
                                    Link ="Home/Index",
                                    InMenu = true,
                                    ParentId = (int)GeneralEnums.ParentPageId,
                                    IsActive = true,
                                    ModuleId = null,
                                    CategoryId = (int)GeneralEnums.Page
                                },
                                new Page()
                                {
                                    Id = 3,
                                    Name = "الإدارة",
                                    NameEn = "Management",
                                    Icon = "bi bi-list-ul",
                                    Link = null,
                                    InMenu = true,
                                    ParentId = (int)GeneralEnums.ParentPageId,
                                    IsActive = true,
                                    ModuleId = (int)GeneralEnums.Management,
                                    CategoryId = (int)GeneralEnums.Header
                                },
                                new Page()
                                {
                                    Id = 4,
                                    Name = "إدارة المستخدمين",
                                    NameEn = "Users Management",
                                    Icon = "bi bi-people",
                                    Link = null,
                                    InMenu = true,
                                    ParentId = 3, // Management
                                    IsActive = true,
                                    ModuleId = (int)GeneralEnums.Management,
                                    CategoryId = (int)GeneralEnums.Header
                                },
                                new Page()
                                {
                                    Id = 5,
                                    Name = "المستخدمين",
                                    NameEn = "Users",
                                    Icon = "bi bi-person-fill",
                                    Link = "User/Index",
                                    InMenu = true,
                                    ParentId = 4, //Users Management
                                    IsActive = true,
                                    ModuleId = (int)GeneralEnums.Management,
                                    CategoryId = (int)GeneralEnums.Page
                                },
                                new Page()
                                {
                                    Id = 6,
                                    Name = "أنواع المستخدمين",
                                    NameEn = "User Types",
                                    Icon = "bi bi-people",
                                    Link = "UserType/Index",
                                    InMenu = true,
                                    ParentId = 4, //Users Management
                                    IsActive = true,
                                    ModuleId = (int)GeneralEnums.Management,
                                    CategoryId = (int)GeneralEnums.Page
                                },
                                new Page()
                                {
                                    Id = 7,
                                    Name = "صلاحيات المستخدم",
                                    NameEn = "User Permissions",
                                    Icon = "bi bi-check-lg",
                                    Link = "UserPermission/Index",
                                    InMenu = true,
                                    ParentId = 4, //Users Management
                                    IsActive = true,
                                    ModuleId = (int)GeneralEnums.Management,
                                    CategoryId = (int)GeneralEnums.Page
                                },
               
                                new Page()
                                {
                                    Id = 9,
                                    Name = "وحدات النظام",
                                    NameEn = "Governorates and Cities",
                                    Icon = "bi bi-view-list",
                                    Link = "Management/Modules",
                                    InMenu = true,
                                    ParentId = 3, //Management
                                    IsActive = true,
                                    ModuleId = (int)GeneralEnums.Management,
                                    CategoryId = (int)GeneralEnums.Page
                                },
                                new Page()
                                {
                                    Id = 10,
                                    Name = "الصفحات",
                                    NameEn = "Pages",
                                    Icon = "bi bi-window-stack",
                                    Link = "Page/Index",
                                    InMenu = true,
                                    ParentId = 3, //Management
                                    IsActive = true,
                                    ModuleId = (int)GeneralEnums.Management,
                                    CategoryId = (int)GeneralEnums.Page
                                },
                                new Page()
                                {
                                    Id = 11,
                                    Name = "الثوابت",
                                    NameEn = "Constants",
                                    Icon = "fa fa-anchor",
                                    Link = "Constant/Index",
                                    InMenu = true,
                                    ParentId = 3, //Management
                                    IsActive = true,
                                    ModuleId = (int)GeneralEnums.Management,
                                    CategoryId = (int)GeneralEnums.Page
                                },
                new Page()
                {
                    Id = 12,
                    Name = "إدارة العملاء",
                    NameEn = "Beneficiaries Management",
                    Icon = "bi bi-people",
                    Link = null,
                    InMenu = true,
                    ParentId = (int)GeneralEnums.ParentPageId,
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.BeneficiariesManagement,
                    CategoryId = (int)GeneralEnums.Header
                },
                new Page()
                {
                    Id = 13,
                    Name = "المستفيدين",
                    NameEn = "Beneficiaries",
                    Icon = "bi bi-people-fill",
                    Link = "Beneficiary/Index",
                    InMenu = true,
                    ParentId = 12, // Beneficiaries Management
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.BeneficiariesManagement,
                    CategoryId = (int)GeneralEnums.Page
                },
                new Page()
                {
                    Id = 14,
                    Name = "أنواع المستفيدين",
                    NameEn = "Beneficiaries Types",
                    Icon = "bi bi-people-fill",
                    Link = "Beneficiary/BeneficiaryTypes",
                    InMenu = true,
                    ParentId = 12, // Beneficiaries Management
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.BeneficiariesManagement,
                    CategoryId = (int)GeneralEnums.Page
                },
                new Page()
                {
                    Id = 15,
                    Name = "أنواع المرفقات",
                    NameEn = "Attachments Types",
                    Icon = "bi bi-bookmarks",
                    Link = "AttachmentType/Index",
                    InMenu = true,
                    ParentId = 12, // Beneficiaries Management
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.BeneficiariesManagement,
                    CategoryId = (int)GeneralEnums.Page
                },
                new Page()
                {
                    Id = 16,
                    Name = "إدارة الخدمات",
                    NameEn = "Services Management",
                    Icon = "bi bi-stickies-fill",
                    Link = null,
                    InMenu = true,
                    ParentId = (int)GeneralEnums.ParentPageId,
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.ServicesManagement,
                    CategoryId = (int)GeneralEnums.Header
                },
                new Page()
                {
                    Id = 17,
                    Name = "الخدمات",
                    NameEn = "Services",
                    Icon = "bi bi-sticky-fill",
                    Link = "Service/Index",
                    InMenu = true,
                    ParentId = 16, // Services Management
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.ServicesManagement,
                    CategoryId = (int)GeneralEnums.Page
                },
                new Page()
                {
                    Id = 18,
                    Name = "مجموعات الخدمات",
                    NameEn = "Services Groups",
                    Icon = "bi bi-stickies-fill",
                    Link = "Service/ServiceGroups",
                    InMenu = true,
                    ParentId = 16, // Services Management
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.ServicesManagement,
                    CategoryId = (int)GeneralEnums.Page
                },
                new Page()
                {
                    Id = 19,
                    Name = "المندوبين",
                    NameEn = "Representatives",
                    Icon = "bi bi-person-check",
                    Link = "Representative/Index",
                    InMenu = true,
                    ParentId = 16, // Services Management
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.ServicesManagement,
                    CategoryId = (int)GeneralEnums.Page
                },
                new Page()
                {
                    Id = 20,
                    Name = "فئات المندوب",
                    NameEn = "Representative Categories",
                    Icon = "bi bi-person-check",
                    Link = "RepresentativeCategory/Index",
                    InMenu = true,
                    ParentId = 16, // Services Management
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.ServicesManagement,
                    CategoryId = (int)GeneralEnums.Page
                },
                new Page()
                {
                    Id = 21,
                    Name = " الجهات ",
                    NameEn = "Responsible Agencies",
                    Icon = "bi bi-person-check",
                    Link = "ResponsibleAgency/Index",
                    InMenu = true,
                    ParentId = 16, // Services Management
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.ServicesManagement,
                    CategoryId = (int)GeneralEnums.Page
                },
                 new Page()
                {
                    Id = 22,
                    Name = " أنواع الجهات  ",
                    NameEn = "Responsible Agencies Types",
                    Icon = "bi bi-person-check",
                    Link = "ResponsibleAgency/AgencyTypes",
                    InMenu = true,
                    ParentId = 16, // Services Management
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.ServicesManagement,
                    CategoryId = (int)GeneralEnums.Page
                },
                  new Page()
                {
                    Id = 23,
                    Name = " حالات الطلب ",
                    NameEn = "Request Cases",
                    Icon = "bi bi-person-check",
                    Link = "RequestCase/Index",
                    InMenu = true,
                    ParentId = 16, // Services Management
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.ServicesManagement,
                    CategoryId = (int)GeneralEnums.Page
                }

            };

            pages.AddRange(ToolPagesSeed.AddToollPages(pages.Last().Id)); // add Tool Pages  

            builder.Entity<Page>().HasData(pages);

            //Seed Admin User and all permissions

           builder.Seed(pages);
        }
            }
}
