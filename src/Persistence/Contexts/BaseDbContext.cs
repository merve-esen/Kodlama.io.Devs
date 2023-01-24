using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    public DbSet<Technology> Technologies { get; set; }
    public DbSet<GithubAddress> GithubAddresses { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //if (!optionsBuilder.IsConfigured)
        //    base.OnConfiguring(
        //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProgrammingLanguage>(m =>
        {
            m.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
            m.Property(p => p.Id).HasColumnName("Id");
            m.Property(p => p.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
        });

        modelBuilder.Entity<Technology>(m =>
        {
            m.ToTable("Technologies").HasKey(k => k.Id);
            m.Property(p => p.Id).HasColumnName("Id");
            m.Property(p => p.Name).HasColumnName("Name").HasMaxLength(50).IsRequired();
            m.Property(p => p.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
            m.HasOne(p => p.ProgrammingLanguage);
        });

        modelBuilder.Entity<GithubAddress>(m =>
        {
            m.ToTable("GithubAddresses").HasKey(p => p.Id);
            m.Property(p => p.Id).HasColumnName("Id");
            m.Property(p => p.UserId).HasColumnName("UserId");
            m.Property(p => p.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
            m.HasOne(p => p.User);
        });

        modelBuilder.Entity<User>(m =>
        {
            m.ToTable("Users").HasKey(p => p.Id);
            m.Property(p => p.Id).HasColumnName("Id");
            m.Property(p => p.FirstName).HasColumnName("FirstName").HasMaxLength(50).IsRequired();
            m.Property(p => p.LastName).HasColumnName("LastName").HasMaxLength(50).IsRequired();
            m.Property(p => p.Email).HasColumnName("Email").HasMaxLength(50).IsRequired();
            m.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt").HasMaxLength(500).IsRequired();
            m.Property(p => p.PasswordHash).HasColumnName("PasswordHash").HasMaxLength(500).IsRequired();
            m.Property(p => p.Status).HasColumnName("Status").IsRequired();
            m.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");
        });

        modelBuilder.Entity<OperationClaim>(m =>
        {
            m.ToTable("OperationClaims").HasKey(p => p.Id);
            m.Property(p => p.Id).HasColumnName("Id");
            m.Property(p => p.Name).HasColumnName("Name").HasMaxLength(500).IsRequired();
        });

        modelBuilder.Entity<UserOperationClaim>(m =>
        {
            m.ToTable("UserOperationClaims").HasKey(p => p.Id);
            m.Property(p => p.Id).HasColumnName("Id");
            m.Property(p => p.UserId).HasColumnName("UserId");
            m.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
            m.HasOne(p => p.User);
            m.HasOne(p => p.OperationClaim);
        });

        modelBuilder.Entity<RefreshToken>(m =>
        {
            m.ToTable("RefreshTokens").HasKey(p => p.Id);
            m.Property(p => p.UserId).HasColumnName("UserId");
            m.Property(p => p.Token).HasColumnName("Token");
            m.Property(p => p.Expires).HasColumnName("Expires");
            m.Property(p => p.Created).HasColumnName("Created");
            m.Property(p => p.CreatedByIp).HasColumnName("CreatedByIp");
            m.Property(p => p.Revoked).HasColumnName("Revoked");
            m.Property(p => p.RevokedByIp).HasColumnName("RevokedByIp");
            m.Property(p => p.ReplacedByToken).HasColumnName("ReplacedByToken");
            m.Property(p => p.ReasonRevoked).HasColumnName("ReasonRevoked");
            m.HasOne(p => p.User);
        });

        ProgrammingLanguage[] programmingLanguageSeeds = { new(1, "C#"), new(2, "Java"), new(3, "Python") };
        modelBuilder.Entity<ProgrammingLanguage>().HasData(programmingLanguageSeeds);
    }
}
