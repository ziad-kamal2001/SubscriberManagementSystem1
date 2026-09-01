using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SubscriberManagementSystem.Data.DbContext;
using SubscriberManagementSystem.Data.Enums;
using SubscriberManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriberManagementSystem.Data.SeedHeper
{
    public static class UserSeed
    {
        public static void Seed(this ModelBuilder builder, List<Page> Pages)
        {
            var seedDate = new DateTime(2026, 1, 1); // static, deterministic

            // seed User Type
            builder.Entity<UserType>().HasData(
                new UserType { Id = 1, Name = "مدير النظام", CreatedOn = seedDate },
                new UserType { Id = 2, Name = "مستخدم", CreatedOn = seedDate }
            );

            var adminUserId = "D3E20CBB-2AD1-4D55-9A1E-4CEEC5B4CDE3";

            var adminUser = new User
            {
                Id = adminUserId,
                Name = "Fast Admin",
                Email = "admin@fast.com",
                UserName = "admin@fast.com",
                PhoneNumber = "",
                NormalizedUserName = "ADMIN@FAST.COM",
                UserTypeId = 1,
                GenderId = (int)GeneralEnums.Male,
                IsActive = true,
                Avatar = "default_avatar.png",
                CreatedOn = seedDate,
                PasswordHash = "AQAAAAIAAYagAAAAEALPXo0djcdEdnFUCCnSoiw/YG1jql8WNeGoa6QmIaJ7PzjIHc8Pff2UGKH3PnPa/A==",
                ConcurrencyStamp = "00000000-0000-0000-0000-000000000001",
                SecurityStamp = "00000000-0000-0000-0000-000000000002"
            };

            builder.Entity<User>().HasData(adminUser);

            var userPermissions = new List<UserPermission>();
            int userPermissionId = 1;
            foreach (var page in Pages)
            {
                userPermissions.Add(new UserPermission
                {
                    Id = userPermissionId++,
                    UserTypeId = 1,
                    PageId = page.Id
                });
            }

            builder.Entity<UserPermission>().HasData(userPermissions);
        }
    }
}