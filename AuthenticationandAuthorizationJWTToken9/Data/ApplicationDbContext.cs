using AuthenticationandAuthorizationJWTToken9.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationandAuthorizationJWTToken9.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }



        public DbSet<Employee> Employees { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //not showing the relation bwtween the tables
            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.UserName).HasMaxLength(30);
                entity.Property(e => e.Email).HasMaxLength(50);
                entity.Property(e => e.Password).HasMaxLength(20);
                entity.Property(e => e.DisplayName).HasMaxLength(60);
                //entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.CreatedDate).HasPrecision(0);
            });




            modelBuilder.Entity<Employee>(entity =>
            {
                // Configure Primary Key
                entity.HasKey(e => e.EmployeeID);

                // Configure Property Lengths
                entity.Property(e => e.NationalIDNumber)
                      .HasMaxLength(15);

                entity.Property(e => e.EmployeeName)
                      .HasMaxLength(100);

                entity.Property(e => e.LoginID)
                      .HasMaxLength(256);

                entity.Property(e => e.JobTitle)
                      .HasMaxLength(50);

                entity.Property(e => e.MaritalStatus)
                      .HasMaxLength(1);

                entity.Property(e => e.Gender)
                      .HasMaxLength(1);

                // Configure Column Type for Date Properties
                entity.Property(e => e.BirthDate)
                      .HasPrecision(0);

                entity.Property(e => e.HireDate)
                      .HasPrecision(0);

                // Configure Required Fields
                entity.Property(e => e.RowGuid)
                      .IsRequired();

                // Configure Other Properties
                entity.Property(e => e.VacationHours)
                      .IsRequired();

                entity.Property(e => e.SickLeaveHours)
                      .IsRequired();

                entity.Property(e => e.ModifiedDate)
                      .IsRequired();
            });




        }





    }
}
