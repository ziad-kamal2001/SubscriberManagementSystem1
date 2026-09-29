using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SubscriberManagementSystem.Data.Models;
using SubscriberManagementSystem.Data.SeedHeper;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Security.Principal;

namespace SubscriberManagementSystem.Data.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            SeedHelper.Seed(builder);
            base.OnModelCreating(builder);

            // ---- Query Filters (Soft Delete) ----
            builder.Entity<UserType>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<Page>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<Beneficiary>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<BeneficiaryInformation>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<Children>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<Wive>().HasQueryFilter(x => !x.IsDeleted);

            // ---- User / UserType ----
            builder.Entity<User>()
               .HasOne(u => u.UserType)
               .WithMany()
               .HasForeignKey(u => u.UserTypeId)
               .IsRequired(false);

            // ---- Children.GenderId ----
            builder.Entity<Children>()
               .HasOne(c => c.Gender)
               .WithMany()
               .HasForeignKey(c => c.GenderId)
               .OnDelete(DeleteBehavior.NoAction);

            // ---- تحديد صريح وكامل لكل علاقات Children/Wives مع Beneficiary ----
            // Children له علاقتان مع Beneficiary (BeneficiaryId و ParentId)، لذلك
            // يجب تحديد كلتيهما صراحة لإزالة الغموض عند EF Core.

            // العلاقة الأساسية: المستفيد المالك للابن (Beneficiary -> ChildrenList)
            builder.Entity<Beneficiary>()
                .HasMany(b => b.ChildrenList)
                .WithOne(c => c.Beneficiary)
                .HasForeignKey(c => c.BeneficiaryId)
                .OnDelete(DeleteBehavior.Restrict);

            // العلاقة الثانوية: Parent (بدون Collection مقابلة في Beneficiary)
            builder.Entity<Children>()
                .HasOne(c => c.Parent)
                .WithMany()
                .HasForeignKey(c => c.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            // علاقة الزوجات: Beneficiary -> Wives
            builder.Entity<Beneficiary>()
                .HasMany(b => b.Wives)
                .WithOne(w => w.Beneficiary)
                .HasForeignKey(w => w.BeneficiaryId)
                .OnDelete(DeleteBehavior.Restrict);

            // ---- New relations for the extended Beneficiary CreateEdit form ----
            // Use Restrict/NoAction on every new City/Constant FK below to avoid
            // "multiple cascade paths" errors, since Beneficiary/BeneficiaryInformation
            // already cascade-delete through other relations.

            builder.Entity<Beneficiary>()
               .HasOne(b => b.MaritalStatus)
               .WithMany()
               .HasForeignKey(b => b.MaritalStatusId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Beneficiary>()
               .HasOne(b => b.BreadwinnerStatus)
               .WithMany()
               .HasForeignKey(b => b.BreadwinnerStatusId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Beneficiary>()
               .HasOne(b => b.WifeStatus)
               .WithMany()
               .HasForeignKey(b => b.WifeStatusId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Beneficiary>()
               .HasOne(b => b.OriginalGovernorateCity)
               .WithMany()
               .HasForeignKey(b => b.OriginalGovernorateCityId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<BeneficiaryInformation>()
               .HasOne(bi => bi.CurrentGovernorateCity)
               .WithMany()
               .HasForeignKey(bi => bi.CurrentGovernorateCityId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<BeneficiaryInformation>()
               .HasOne(bi => bi.CurrentCity)
               .WithMany()
               .HasForeignKey(bi => bi.CurrentCityId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<BeneficiaryInformation>()
               .HasOne(bi => bi.ResidenceStatus)
               .WithMany()
               .HasForeignKey(bi => bi.ResidenceStatusId)
               .OnDelete(DeleteBehavior.Restrict);
        }


        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<Constant> Constants { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Children> Childrens { get; set; }
        public DbSet<Wive> Wives { get; set; }
        public DbSet<TheHealthCondition> TheHealthConditions { get; set; }
        public DbSet<WorkStatus> WorkStatus { get; set; }
        public DbSet<TypesSubscription> TypesSubscriptions { get; set; }
        public DbSet<HousingStatus> HousingStatus { get; set; }
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageCategory> PageCategories { get; set; }
        public DbSet<Beneficiary> Beneficiaries { get; set; }
        public DbSet<BeneficiaryInformation> BeneficiaryInformations { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}