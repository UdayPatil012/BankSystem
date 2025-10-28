using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using BankSystem.Model;
namespace BankSystem.Data
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> options) : base(options) { }

        public DbSet<Bank> Banks { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Beneficiary> Beneficiaries { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<SalaryDisbursement> SalaryDisbursements { get; set; }
        public DbSet<Report> Reports { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .Property(u => u.UserType)
            .HasConversion<string>();

            modelBuilder.Entity<User>()
            .Property(u => u.ClientStatus)
            .HasConversion<string>();

            modelBuilder.Entity<Document>()
            .Property(d => d.DocumentType)
            .HasConversion<string>();

            modelBuilder.Entity<Document>()
            .Property(d => d.DocumentVerifiedStatus)
            .HasConversion<string>();

            modelBuilder.Entity<Payment>()
            .Property(p => p.paymentStatus)
            .HasConversion<string>();

            modelBuilder.Entity<SalaryDisbursement>()
            .Property(s => s.PaymentStatus)
            .HasConversion<string>();

            // Seed data
            modelBuilder.Entity<Bank>().HasData(
                new Bank { BankId = 1, BankName = "HDFC BANK", BankAddress = "MUMBAI" ,IFSCCode="HDFC123"}
            );

            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, UserName = "Rohit", Password = "Rohit@123", UserType = Enum.UserType.SuperAdmin, Email = "Rohit12@Gmail.com", BankId = 1 },
                new User { UserId = 2, UserName = "Uday", Password = "Uday@123", UserType = Enum.UserType.BankUser, Email = "Uday123@G", BankId = 1 }
            );
        }


    }
}
