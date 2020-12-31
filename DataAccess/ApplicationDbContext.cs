using fleepage.oatleaf.com.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fleepage.oatleaf.com.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Freelance> Freelance { get; set; }
        public DbSet<Setup> Setup { get; set; }
        public DbSet<Session> Session { get; set; }
        public DbSet<Term> Term { get; set; }
        public DbSet<SmsAccount> SmsAccount { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<ContactList> ContactList { get; set; }
        public DbSet<Staffs> Staffs { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<SchoolAdmin> SchoolAdmin { get; set; }
        public DbSet<OrgAdmin> OrgAdmin { get; set; }
        public DbSet<Beneficiary> Beneficiary { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Organisation> Organisation { get; set; }
        public DbSet<Subscriptions> Subscriptions { get; set; }
        public DbSet<Subscription> Subscription { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<SubjectCA> SubjectCA { get; set; }
        public DbSet<TermCA> TermCA { get; set; }
        public DbSet<GradePoint> GradePoint { get; set; }
        public DbSet<Assessment> Assessment { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subscription>().HasData(
                new Subscription
                {
                   Id=1,
                   InActivePrice=0,
                   ActivePrice=0,
                   Code="TRIAL",
                   Duration = 90,
                   IsAvailable = true,
                   Name = "Trial Subscription",
                   Description="trial period subscription",
                   Type=1
                },
                new Subscription
                {
                    Id = 2,
                    InActivePrice = 0,
                    ActivePrice = 200,
                    Code = "BRONZE",
                    Duration = 120,
                    IsAvailable = true,
                    Name = "Bronze Subscription",
                    Description = "Bronze subscription",
                    Type = 1
                },
                new Subscription
                {
                    Id = 3,
                    InActivePrice = 0,
                    ActivePrice = 300,
                    Code = "SILVER",
                    Duration = 120,
                    IsAvailable = true,
                    Name = "Silver Subscription",
                    Description = "Silver subscription",
                    Type = 1
                },
                 new Subscription
                {
                    Id = 4,
                    InActivePrice = 0,
                    ActivePrice = 500,
                    Code = "GOLD",
                    Duration = 120,
                    IsAvailable = true,
                    Name = "Gold Subscription",
                    Description = "Gold subscription",
                     Type = 1
                 }
            );
        }
    }
}
