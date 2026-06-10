using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Stocks> Stocks { get; set; }
        public DbSet<Comments> Comments { get; set; }

        public DbSet<Portfolio> Portfolios{get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Portfolio>(x=>x.HasKey(p=>new{p.AppUserId,p.StocksId}));

            builder.Entity<Portfolio>()
               .HasOne(u=>u.AppUser)
               .WithMany(u=>u.Portfolios)
               .HasForeignKey(p=>p.AppUserId);

             builder.Entity<Portfolio>()
               .HasOne(u=>u.Stocks)
               .WithMany(u=>u.Portfolios)
               .HasForeignKey(p=>p.StocksId);



            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "dad088ce-ddcd-4117-bb11-0f174ebab3e9",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "a4991fb0-215e-4a48-be47-15e12daa036b"
                },
                new IdentityRole
                {
                    Id = "8604419d-b486-4004-8064-0b2702695a59",
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = "64feb54c-7d09-4303-91ae-9b2cf5df6921"
                });
        }
      
    }
}
