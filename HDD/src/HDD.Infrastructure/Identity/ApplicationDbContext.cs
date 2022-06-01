using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HDD.Infrastructure.Identity;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    protected ApplicationDbContext(DbContextOptions options)
    : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        //builder.HasDefaultSchema("dbo");

        //builder.Entity<ApplicationUser>()
        //    .Property(e => e.FirstName)
        //    .HasMaxLength(250);

        //builder.Entity<ApplicationUser>()
        //    .Property(e => e.LastName)
        //    .HasMaxLength(250);

        //builder.Entity<ApplicationUser>()
        //    .Property(e => e.Title)
        //    .HasMaxLength(100);

        //builder.Entity<ApplicationUser>()
        //    .Property(e => e.Company)
        //    .HasMaxLength(100);

        //builder.Entity<ApplicationUser>()
        //    .Property(e => e.VIN)
        //    .HasMaxLength(20);

        //builder.Entity<ApplicationUser>()
        //    .Property(e => e.Plate)
        //    .HasMaxLength(100);

        //builder.Entity<ApplicationUser>()
        //    .Property(e => e.RegisteredZip)
        //    .HasMaxLength(10);
    }
}
