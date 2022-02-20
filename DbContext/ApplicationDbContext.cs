using DentalDDS_Api.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace DentalDDS_Api.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
           
            //AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = false;
            //DbMigrationsConfiguration.AutomaticMigrationsEnabled;
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

        }
        //Add model entities to database.
        #region DB_Set
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<ErrorLog> ErrorLog { get; set; }
        public DbSet<EventLog> EventLog { get; set; }       
       
        #endregion

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Format Datetime to datetime2
            modelBuilder.Properties<DateTime>()
                .Configure(c => c.HasColumnType("datetime2"));

            //Fluent API, Primary Keys
            #region PrimaryKey
            modelBuilder.Entity<UserProfile>()
                        .HasKey(cus => cus.UserProfileID);

            modelBuilder.Entity<Tasks>()
            .HasKey(pro => pro.TasksID);

            modelBuilder.Entity<ErrorLog>()
             .HasKey(erl => erl.ErrorID);

            modelBuilder.Entity<EventLog>()
             .HasKey(el => el.EventID);

            modelBuilder.Entity<ApplicationUser>()
                    .HasKey(apu => apu.Id);

            modelBuilder.Entity<IdentityUserRole>()
               .HasKey(iur => iur.UserId);

            modelBuilder.Entity<IdentityUserLogin>()
                .HasKey(iul => iul.UserId);

            #endregion


            ///Relationships
            #region Relationship
            // Configure UserAccount as FK for ApplicationUser ASPNET
            modelBuilder.Entity<ApplicationUser>()
                 .HasRequired(s => s.UserProfile)
                 .WithRequiredPrincipal(s => s.ApplicationUser);


            #endregion

            base.OnModelCreating(modelBuilder);



        }
    }
}
