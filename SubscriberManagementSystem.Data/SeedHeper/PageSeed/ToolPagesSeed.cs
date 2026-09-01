using SubscriberManagementSystem.Data.Enums;
using SubscriberManagementSystem.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriberManagementSystem.Data.SeedHeper.PageSeed
{
    public static class ToolPagesSeed
    {
        public static List<Page> AddToollPages(int lastPageId)
        {
            var toolPages = new List<Page>()
            {
                new Page()
                {
                    Name = "عرض بيانات جدول المستخدمين",
                    NameEn = "Display User DataTable",
                    Icon = null,
                    Link ="User/GetAll",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.UserPageId, // User Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.Management,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "اظهار واجهة اضافة  تعديل مستخدم",
                    NameEn = "Display Create Edit User Page",
                    Icon = null,
                    Link ="User/CreateEditModal",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.UserPageId, // User Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.Management,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "اضافة تعديل مستخدم",
                    NameEn = "Create Edit User",
                    Icon = null,
                    Link ="User/CreateEdit",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.UserPageId, // User Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.Management,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "حذف مستخدم",
                    NameEn = "Delete User",
                    Icon = null,
                    Link ="User/Delete",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.UserPageId, // User Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.Management,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "عرض واجهة ملفي الشخصي",
                    NameEn = "Display My Profile Page",
                    Icon = null,
                    Link ="User/MyProfileModal",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.UserPageId, // User Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.Management,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "تعديل ملفي الشخصي",
                    NameEn = "Update My Profile",
                    Icon = null,
                    Link ="User/MyProfile",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.UserPageId, // User Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.Management,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "عرض واجهة تغير كلمة المرور",
                    NameEn = "Display Change Password Page",
                    Icon = null,
                    Link ="User/ChangePasswordModal",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.UserPageId, // User Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.Management,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "تغير كلمة المرور",
                    NameEn = "ChangePassword",
                    Icon = null,
                    Link ="User/ChangePassword",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.UserPageId, // User Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.Management,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "عرض بيانات جدول انواع المستخدين",
                    NameEn = "Display User Type DateTable",
                    Icon = null,
                    Link ="UserType/GetAll",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.UserTypePageId, // UserType Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.Management,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "عرض واجهة اضافة  تعديل نوع المستخدم",
                    NameEn = "Display Create Edit User Type page",
                    Icon = null,
                    Link ="UserType/CreateEditModal",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.UserTypePageId, // UserType Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.Management,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "اضافة تعديل نوع مستخدم",
                    NameEn = "Create Edit User Type ",
                    Icon = null,
                    Link ="UserType/CreateEdit",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.UserTypePageId, // UserType Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.Management,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "حذف نوع مستخدم",
                    NameEn =  "Delete User Type ",
                    Icon = null,
                    Link ="UserType/Delete",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.UserTypePageId, // UserType Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.Management,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "عرض صلاحيات نوع المستخدم",
                    NameEn =  "display User Type Permissions",
                    Icon = null,
                    Link ="UserPermission/GetUserTypePermissions",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.UserPermissionsId, // User Permissions Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.Management,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "حفظ صلاحيات نوع المستخدم",
                    NameEn =  "Save User Type Permissions",
                    Icon = null,
                    Link ="UserPermission/SavePermissions",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.UserPermissionsId, // User Permissions Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.Management,
                    CategoryId = (int)GeneralEnums.Tool
                },

                new Page()
                {
                    Name = "تبديل حالات وحدات النظام",
                    NameEn =  "Switching states of system Modules",
                    Icon = null,
                    Link ="Management/SwitchStatus",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.SystemModulesId, // System Modules Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.Management,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "عرض بيانات جدول الصفحات",
                    NameEn =  "Display Pages DataTable",
                    Icon = null,
                    Link ="Page/GetAll",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.PageId, // System Modules Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.Management,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "عرض واجهة إضافة  تعديل صفحة",
                    NameEn =  "Display Create Edit Page interface",
                    Icon = null,
                    Link ="Page/CreateEditModal",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.PageId, // System Modules Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.Management,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "إضافة تعديل صفحة",
                    NameEn =  "Create Edit Page",
                    Icon = null,
                    Link ="Page/CreateEdit",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.PageId, // System Modules Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.Management,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "حذف صفحة",
                    NameEn =  "Delete Page",
                    Icon = null,
                    Link ="Page/Delete",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.PageId, // System Modules Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.Management,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "عرض بيانات جدول الثوابت",
                    NameEn =  "Display Constant DataTable",
                    Icon = null,
                    Link ="Constant/GetAll",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.ConstantId, // Constant Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.Management,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "عرض واجهة إضافة تعديل ثوابت",
                    NameEn =  "Display Create Edit Constant Page",
                    Icon = null,
                    Link ="Constant/CreateEditModal",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.ConstantId, // Constant Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.Management,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "إضافة تعديل ثوابت",
                    NameEn =  "Create Edit Constant",
                    Icon = null,
                    Link ="Constant/CreateEdit",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.ConstantId, // Constant Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.Management,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "حذف ثابت",
                    NameEn =  "Delete Constant",
                    Icon = null,
                    Link ="Constant/Delete",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.ConstantId, // Constant Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.Management,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "عرض بيانات جدول المستفيدين",
                    NameEn =  "Display Beneficiaries DataTable",
                    Icon = null,
                    Link ="Beneficiary/GetAll",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.BeneficiaryId, // Beneficiaries Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.BeneficiariesManagement,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "عرض واجهة إضافة تعديل المستفيدين",
                    NameEn =  "Display Create Edit Beneficiaries Page",
                    Icon = null,
                    Link ="Beneficiary/CreateEdit",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.BeneficiaryId, // Beneficiaries Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.BeneficiariesManagement,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "ضافة تعديل المستفيدين",
                    NameEn =  "Create Edit Beneficiaries",
                    Icon = null,
                    Link ="Beneficiary/SubmitCreateEdit",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.BeneficiaryId, // Beneficiaries Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.BeneficiariesManagement,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "حذف مستفيد",
                    NameEn =  "Delete Beneficiary",
                    Icon = null,
                    Link ="Beneficiary/Delete",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.BeneficiaryId, // Beneficiaries Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.BeneficiariesManagement,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "عرض بيانات جدول عناوين المستفيد",
                    NameEn =  "Display beneficiary Addresses DataTable",
                    Icon = null,
                    Link ="Beneficiary/GetAddresses",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.BeneficiaryId, // Beneficiaries Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.BeneficiariesManagement,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "عرض واجهة إضافة تعديل عناوين المستفيد",
                    NameEn =  "Display Create Edit beneficiary Addresses Page",
                    Icon = null,
                    Link ="Beneficiary/CreateEditAddressModal",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.BeneficiaryId, // Beneficiaries Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.BeneficiariesManagement,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "إضافة تعديل عناوين المستفيد",
                    NameEn =  "Create Edit beneficiary Addresses",
                    Icon = null,
                    Link ="Beneficiary/CreateEditAddress",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.BeneficiaryId, // Beneficiaries Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.BeneficiariesManagement,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "حذف عناوين المستفيد",
                    NameEn =  "Delete beneficiary Addresses",
                    Icon = null,
                    Link ="Beneficiary/DeleteAddress",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.BeneficiaryId, // Beneficiaries Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.BeneficiariesManagement,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "عرض بيانات جدول جهات اتصال المستفيد",
                    NameEn =  "Display beneficiary Addresses DataTable",
                    Icon = null,
                    Link ="Beneficiary/GetContacts",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.BeneficiaryId, // Beneficiaries Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.BeneficiariesManagement,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "عرض واجهة إضافة تعديل جهات اتصال المستفيد",
                    NameEn =  "Display Create Edit beneficiary Addresses Page",
                    Icon = null,
                    Link ="Beneficiary/CreateEditContactModal",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.BeneficiaryId, // Beneficiaries Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.BeneficiariesManagement,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "إضافة تعديل جهات اتصال المستفيد",
                    NameEn =  "Create Edit beneficiary Addresses",
                    Icon = null,
                    Link ="Beneficiary/CreateEditContact",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.BeneficiaryId, // Beneficiaries Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.BeneficiariesManagement,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "حذف جهات اتصال المستفيد",
                    NameEn =  "Delete beneficiary Addresses",
                    Icon = null,
                    Link ="Beneficiary/DeleteContact",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.BeneficiariesManagement, // Beneficiaries Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.Management,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "عرض المرفقات",
                    NameEn =  "Display Attachments",
                    Icon = null,
                    Link ="Beneficiary/GetAttachments",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.BeneficiaryId, // Beneficiaries Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.BeneficiariesManagement,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "تحميل مرفق",
                    NameEn =  "Upload Attachment",
                    Icon = null,
                    Link ="Beneficiary/UploadAttachment",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.BeneficiaryId, // Beneficiaries Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.BeneficiariesManagement,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "حفظ المرفقات",
                    NameEn =  "Save Attachment",
                    Icon = null,
                    Link ="Beneficiary/SaveAttachment",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.BeneficiaryId, // Beneficiaries Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.BeneficiariesManagement,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "حذف المرفقات",
                    NameEn =  "Delete Attachment",
                    Icon = null,
                    Link ="Beneficiary/DeleteAttachment",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.BeneficiaryId, // Beneficiaries Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.BeneficiariesManagement,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "عرض بيانات جدول أنواع المستفيد ",
                    NameEn =  "Display Beneficiary Types DataTable",
                    Icon = null,
                    Link ="Beneficiary/GetBeneficiaryTypes",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.BeneficiaryTypesId, // Beneficiary Types Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.BeneficiariesManagement,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "عرض واجهة إضافة تعديل أنواع المستفيد",
                    NameEn =  "Display Create Edit Beneficiary Types page",
                    Icon = null,
                    Link ="Beneficiary/CreateEditBeneficiaryTypeModal",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.BeneficiaryTypesId, // Beneficiary Types Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.BeneficiariesManagement,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "إضافة تعديل أنواع المستفيد",
                    NameEn =  "Create Edit Beneficiary Types",
                    Icon = null,
                    Link ="Beneficiary/CreateEditBeneficiaryType",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.BeneficiaryTypesId, // Beneficiary Types Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.BeneficiariesManagement,
                    CategoryId = (int)GeneralEnums.Tool
                },
                new Page()
                {
                    Name = "حذف أنواع المستفيد",
                    NameEn =  "Delete Beneficiary Types",
                    Icon = null,
                    Link ="Beneficiary/DeleteBeneficiaryType",
                    InMenu = false,
                    IsAjax = true,
                    ParentId = (int)GeneralEnums.BeneficiaryTypesId, // Beneficiary Types Page
                    IsActive = true,
                    ModuleId = (int)GeneralEnums.BeneficiariesManagement,
                    CategoryId = (int)GeneralEnums.Tool
                },
            //    new Page()
            //    {
            //        Name = "عرض بيانات جدول جوازات السفر",
            //        NameEn =  "Display Passports DataTable",
            //        Icon = null,
            //        Link ="Passport/GetAll",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.PassportId, // Passport Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.BeneficiariesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "عرض واجهة إضافة تعديل جواز السفر",
            //        NameEn =  "Display Create Edit Passport page",
            //        Icon = null,
            //        Link ="Passport/CreateEditModal",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.PassportId, // Passport Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.BeneficiariesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "إضافة تعديل جواز السفر",
            //        NameEn =  "Create Edit Passport",
            //        Icon = null,
            //        Link ="Passport/CreateEdit",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.PassportId, // Passport Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.BeneficiariesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "حذف جواز السفر",
            //        NameEn =  "Delete Passport",
            //        Icon = null,
            //        Link ="Passport/Delete",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.PassportId, // Passport Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.BeneficiariesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "عرض بيانات جدول أنواع جوازات السفر",
            //        NameEn =  "Display Passports Types DataTable",
            //        Icon = null,
            //        Link ="Passport/GetPassportTypes",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.PassportTypesId, // Passport Types Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.BeneficiariesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "عرض واجهة إضافة تعديل أنواع جوازات السفر",
            //        NameEn =  "Display Create Edit Passport Types page",
            //        Icon = null,
            //        Link ="Passport/CreateEditPassportTypeModal",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.PassportTypesId, // Passport Types Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.BeneficiariesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "إضافة تعديل أنواع جوازات السفر",
            //        NameEn =  "Create Edit Passport Types",
            //        Icon = null,
            //        Link ="Passport/CreateEditPassportType",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.PassportTypesId, // Passport Types Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.BeneficiariesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "حذف نوع جواز السفر",
            //        NameEn =  "Delete Passport Type",
            //        Icon = null,
            //        Link ="Passport/DeletePassportType",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.PassportTypesId, // Passport Types Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.BeneficiariesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "عرض بيانات جدول الهويات",
            //        NameEn =  "Display Identities DataTable",
            //        Icon = null,
            //        Link ="Identity/GetAll",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.IdentityId, // Identities Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.BeneficiariesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "عرض واجهة إضافة تعديل هوية",
            //        NameEn =  "Display Create Edit Identity page",
            //        Icon = null,
            //        Link ="Identity/CreateEditModal",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.IdentityId, // Identities Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.BeneficiariesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "إضافة تعديل هوية",
            //        NameEn =  "Create Edit Identity",
            //        Icon = null,
            //        Link ="Identity/CreateEdit",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.IdentityId, // Identities Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.BeneficiariesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "حذف هوية",
            //        NameEn =  "Delete Identity",
            //        Icon = null,
            //        Link ="Identity/Delete",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.IdentityId, // Identities Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.BeneficiariesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "عرض بيانات جدول أنواع الهويات",
            //        NameEn =  "Display Identities Types DataTable",
            //        Icon = null,
            //        Link ="Identity/GetIdentityTypes",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.IdentityTypesId, // IdentityTypes Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.BeneficiariesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "عرض واجهة إضافة تعديل أنواع الهويات",
            //        NameEn =  "Display Create Edit Identity Types page",
            //        Icon = null,
            //        Link ="Identity/CreateEditIdentityTypeModal",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.IdentityTypesId, // IdentityTypes Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.BeneficiariesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "إضافة تعديل أنواع الهويات",
            //        NameEn =  "Create Edit Identity Types",
            //        Icon = null,
            //        Link ="Identity/CreateEditIdentityType",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.IdentityTypesId, // IdentityTypes Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.BeneficiariesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "حذف نوع الهوية",
            //        NameEn =  "Delete Identity Type",
            //        Icon = null,
            //        Link ="Identity/DeleteIdentityType",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.IdentityTypesId, // IdentityTypes Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.BeneficiariesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "عرض بيانات جدول أنواع المرفقات",
            //        NameEn =  "Display Attachment Types DataTable",
            //        Icon = null,
            //        Link ="AttachmentType/GetAll",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.AttachmentTypesId, // AttachmentTypes Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.BeneficiariesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "عرض واجهة إضافة تعديل نوع مرفق",
            //        NameEn =  "Display Create Edit Attachment Type page",
            //        Icon = null,
            //        Link ="AttachmentType/CreateEditModal",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.AttachmentTypesId, // AttachmentTypes Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.BeneficiariesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "إضافة تعديل نوع المرفق",
            //        NameEn =  "Create Edit Attachment Type",
            //        Icon = null,
            //        Link ="AttachmentType/CreateEdit",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.AttachmentTypesId, // AttachmentTypes Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.BeneficiariesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "حذف نوع المرفق",
            //        NameEn =  "Delete Attachment Type",
            //        Icon = null,
            //        Link ="AttachmentType/Delete",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.AttachmentTypesId, // AttachmentTypes Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.BeneficiariesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "عرض بيانات جدول الحسابات",
            //        NameEn =  "Display Accounts DataTable",
            //        Icon = null,
            //        Link ="Account/GetAll",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.AccountId, // Accounts Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.Finance,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "عرض واجهة إضافة تعديل الحساب",
            //        NameEn =  "Display Create Edit Account Page",
            //        Icon = null,
            //        Link ="Account/CreateEditModal",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.AccountId, // Accounts Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.Finance,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "إضافة تعديل الحساب",
            //        NameEn =  "Create Edit Account",
            //        Icon = null,
            //        Link ="Account/CreateEdit",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.AccountId, // Accounts Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.Finance,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "حذف الحساب",
            //        NameEn =  "Delete Account",
            //        Icon = null,
            //        Link ="Account/Delete",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.AccountId, // Accounts Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.Finance,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "عرض بيانات جدول الخدمات",
            //        NameEn =  "Display Services DataTable",
            //        Icon = null,
            //        Link ="Service/GetAll",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.ServiceId, // Services Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "عرض واجهة إضافة تعديل الخدمة",
            //        NameEn =  "Display Create Edit Service Page",
            //        Icon = null,
            //        Link ="Service/CreateEdit",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.ServiceId, // Services Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "إضافة تعديل خدمة",
            //        NameEn =  "Create Edit Service",
            //        Icon = null,
            //        Link ="Service/SubmitCreateEdit",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.ServiceId, // Services Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "حذف خدمة",
            //        NameEn =  "Delete Service",
            //        Icon = null,
            //        Link ="Service/Delete",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.ServiceId, // Services Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "عرض بيانات جدول متطلبات الخدمة",
            //        NameEn =  "Display Service Requirement DataTable",
            //        Icon = null,
            //        Link ="Service/GetServiceRequirements",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.ServiceId, // Services Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "عرض واجهة إضافة تعديل متطلب الخدمة",
            //        NameEn =  "Display Create Edit Service Requirement Page",
            //        Icon = null,
            //        Link ="Service/CreateEditServiceRequirementModal",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.ServiceId, // Services Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "إضافة تعديل متطلب الخدمة",
            //        NameEn =  "Create Edit Service Requirement",
            //        Icon = null,
            //        Link ="Service/CreateEditServiceRequirement",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.ServiceId, // Services Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "حذف متطلب خدمة",
            //        NameEn =  "Delete Service Requirement",
            //        Icon = null,
            //        Link ="Service/DeleteServiceRequirement",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.ServiceId, // Services Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "عرض بيانات جدول مرفقات الخدمة",
            //        NameEn =  "Display Service Attachment DataTable",
            //        Icon = null,
            //        Link ="Service/GetServiceAttachments",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.ServiceId, // Services Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "عرض واجهة إضافة تعديل مرفق الخدمة",
            //        NameEn =  "Display Create Edit Service Attachment Page",
            //        Icon = null,
            //        Link ="Service/CreateEditServiceAttachmentModal",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.ServiceId, // Services Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "إضافة تعديل مرفق الخدمة",
            //        NameEn =  "Create Edit Service Attachment",
            //        Icon = null,
            //        Link ="Service/CreateEditServiceAttachment",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.ServiceId, // Services Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "حذف مرفق خدمة",
            //        NameEn =  "Delete Service Attachment",
            //        Icon = null,
            //        Link ="Service/DeleteServiceAttachment",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.ServiceId, // Services Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "عرض بيانات جدول مجموعات الخدمات",
            //        NameEn =  "Display Services Groups DataTable",
            //        Icon = null,
            //        Link ="Service/GetServiceGroups",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.ServiceGroupsId, // Service Groups Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "عرض واجهة إضافة تعديلمجموعة الخدمة",
            //        NameEn =  "Display Create Edit Service Group Page",
            //        Icon = null,
            //        Link ="Service/CreateEditServiceGroupModal",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.ServiceGroupsId, // Service Groups Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "إضافة تعديل محموعة خدمة",
            //        NameEn =  "Create Edit Service Group",
            //        Icon = null,
            //        Link ="Service/CreateEditServiceGroup",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.ServiceGroupsId, // Service Groups Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "حذف مجموعة الخدمة",
            //        NameEn =  "Delete Service Group",
            //        Icon = null,
            //        Link ="Service/DeleteServiceGroup",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.ServiceGroupsId, // Service Groups Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },

            //    new Page()
            //    {
            //        Name = "عرض بيانات جدول المندوبين",
            //        NameEn =  "Display Representatives DataTable",
            //        Icon = null,
            //        Link ="Representative/GetAll",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.RepresentativeId, // Representative Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "عرض واجهة إضافة تعديل المندوب",
            //        NameEn =  "Display Create Edit Representative Page",
            //        Icon = null,
            //        Link ="Representative/CreateEditModal",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.RepresentativeId, // Representative Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "إضافة تعديل مندوب",
            //        NameEn =  "Create Edit Representative",
            //        Icon = null,
            //        Link ="Representative/CreateEdit",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.RepresentativeId, // Representative Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "حذف مندوب",
            //        NameEn =  "Delete Representative",
            //        Icon = null,
            //        Link ="Representative/Delete",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.RepresentativeId, // Representative Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "عرض بيانات جدول فئات المندوب",
            //        NameEn =  "Display Representative Categories DataTable",
            //        Icon = null,
            //        Link ="RepresentativeCategory/GetAll",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.RepresentativeCategoryId, // Representative Category Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "عرض واجهة إضافة تعديل فئة المندوب",
            //        NameEn =  "Display Create Edit Representative Category Page",
            //        Icon = null,
            //        Link ="RepresentativeCategory/CreateEditModal",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.RepresentativeCategoryId, // Representative Category Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "إضافة تعديل فئة المندوب",
            //        NameEn =  "Create Edit Representative Category",
            //        Icon = null,
            //        Link ="RepresentativeCategory/CreateEdit",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.RepresentativeCategoryId, // Representative Category Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "حذف فئة مندوب",
            //        NameEn =  "Delete Representative Category",
            //        Icon = null,
            //        Link ="RepresentativeCategory/Delete",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.RepresentativeCategoryId, // Representative Category Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    } ,
            //    new Page()
            //    {
            //        Name = "عرض بيانات جدول الجهات ",
            //        NameEn =  "Display Responsible Agencies DataTable",
            //        Icon = null,
            //        Link ="ResponsibleAgency/GetAll",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.ResponsibleAgencyId, // Responsible Agency Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "عرض واجهة إضافة تعديل جهة ",
            //        NameEn =  "Display Create Edit Responsible Agency Page",
            //        Icon = null,
            //        Link ="ResponsibleAgency/CreateEditModal",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.ResponsibleAgencyId, // Responsible Agency Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "إضافة تعديل جهة ",
            //        NameEn =  "Create Edit Responsible Agency",
            //        Icon = null,
            //        Link ="ResponsibleAgency/CreateEdit",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.ResponsibleAgencyId, // Responsible Agency Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "حذف جهة ",
            //        NameEn =  "Delete Responsible Agency",
            //        Icon = null,
            //        Link ="ResponsibleAgency/Delete",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.ResponsibleAgencyId, // Responsible Agency Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "عرض بيانات جدول أنواع الجهات ",
            //        NameEn =  "Display Responsible Agencies Types DataTable",
            //        Icon = null,
            //        Link ="ResponsibleAgency/GetAgencyTypes",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.ResponsibleAgencyTypeId, // Responsible Agency Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "عرض واجهة إضافة تعديل نوع جهة ",
            //        NameEn =  "Display Create Edit Responsible Agency Type Page",
            //        Icon = null,
            //        Link ="ResponsibleAgency/CreateEditAgencyTypeModal",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.ResponsibleAgencyTypeId, // Responsible Agency Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "إضافة تعديل نوع جهة ",
            //        NameEn =  "Create Edit Responsible Agency Type",
            //        Icon = null,
            //        Link ="ResponsibleAgency/CreateEditAgencyType",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.ResponsibleAgencyTypeId, // Responsible Agency Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "حذف نوع جهة ",
            //        NameEn =  "Delete Responsible Agency Type",
            //        Icon = null,
            //        Link ="ResponsibleAgency/DeleteAgencyType",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.ResponsibleAgencyTypeId, //Responsible Agency Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "عرض بيانات جدول أنواع الحسابات",
            //        NameEn =  "Display Accounts Types DataTable",
            //        Icon = null,
            //        Link ="Account/GetAccountsTypes",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.AccountTypeId, // Accounts Types Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.Finance,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "عرض واجهة إضافة تعديل نوع حساب",
            //        NameEn =  "Display Create Edit Account Type Page",
            //        Icon = null,
            //        Link ="Account/CreateEditAccountTypeModal",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.AccountTypeId, // Accounts Types Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.Finance,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "إضافة تعديل نوع حساب",
            //        NameEn =  "Create Edit Account Type",
            //        Icon = null,
            //        Link ="Account/CreateEditAccountType",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.AccountTypeId, // Accounts Types Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.Finance,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "حذف نوع حساب",
            //        NameEn =  "Delete Account Type",
            //        Icon = null,
            //        Link ="Account/DeleteAccountType",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.AccountTypeId, // Accounts Types Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.Finance,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "عرض بيانات جدول حالات الطلب",
            //        NameEn =  "Display Request Cases DataTable",
            //        Icon = null,
            //        Link ="RequestCase/GetAll",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.RequestCaseId, // Request Case Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "عرض واجهة إضافة تعديل حالة الطلب",
            //        NameEn =  "Display Create Edit RequestCase Page",
            //        Icon = null,
            //        Link ="RequestCase/CreateEditModal",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.RequestCaseId, // Request Case Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "إضافة تعديل حالة الطلب",
            //        NameEn =  "Create Edit Request Case ",
            //        Icon = null,
            //        Link ="RequestCase/CreateEdit",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.RequestCaseId, // Request Case Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },
            //    new Page()
            //    {
            //        Name = "حذف حالة الطلب",
            //        NameEn =  "Delete Request Case ",
            //        Icon = null,
            //        Link ="RequestCase/Delete",
            //        InMenu = false,
            //        IsAjax = true,
            //        ParentId = (int)GeneralEnums.RequestCaseId, // Request Case Page
            //        IsActive = true,
            //        ModuleId = (int)GeneralEnums.ServicesManagement,
            //        CategoryId = (int)GeneralEnums.Tool
            //    },


            };


            lastPageId++;
            foreach (var page in toolPages)
            {
                page.Id = lastPageId++;
            }

            return toolPages;
        }
    }
}
