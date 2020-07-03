using Microsoft.AspNetCore.Http.Features.Authentication;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Models
{
    public class CodenationContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Acceleration> Accelerations { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<User> Users { get; set; }
        public  DbSet<Challenge> Challenges { get; set; }
                
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Codenation;Trusted_Connection=True");            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Candidate>().HasKey(c => new {c.AccelerationId, c.CompanyId, c.UserId});
            modelBuilder.Entity<Submission>().HasKey(s => new {s.ChallengeId, s.UserID });

            modelBuilder.Entity<Candidate>().HasOne(c => c.Acceleration)
                .WithMany(a => a.Candidates)
                .HasForeignKey(c => c.AccelerationId)
                .HasPrincipalKey(a => a.Id);
        }
    }
}