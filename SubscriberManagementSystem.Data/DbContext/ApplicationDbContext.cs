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
            builder.Entity<UserType>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<Page>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<Beneficiary>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<BeneficiaryInformation>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<Children>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<Beneficiary>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<Wive>().HasQueryFilter(x => !x.IsDeleted);
            // Restrict cascade delete for all Constants-based FKs on BeneficiaryInformation
            builder.Entity<User>()
               .HasOne(u => u.UserType)
               .WithMany()
               .HasForeignKey(u => u.UserTypeId)
               .IsRequired(false);
            builder.Entity<Children>()
    .HasOne(c => c.Gender)
    .WithMany()
    .HasForeignKey(c => c.GenderId)
    .OnDelete(DeleteBehavior.NoAction);
        }
        

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
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
       

    }
    
}
