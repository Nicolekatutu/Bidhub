using Microsoft.EntityFrameworkCore;

namespace Bidhub.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOtp> UserOtps { get; set; }
        public DbSet<Auctioneer> Auctioneers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Bidders> Bidders { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ProductDocument> ProductDocuments { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<BidDates> BidDetails { get; set; }
        public DbSet<BViewing> BViewings { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  relationships
            modelBuilder.Entity<Product>().HasOne(p => p.Auctioneer) .WithMany(a => a.Products).HasForeignKey(p => p.AuctioneerId);

            modelBuilder.Entity<Bidders>().HasOne(b => b.User) .WithMany(u => u.Bidders) .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<Auctioneer>().HasOne(a => a.User) .WithMany(u => u.Auctioneers).HasForeignKey(a => a.UserId);

            modelBuilder.Entity<ProductDocument>() .HasOne(pd => pd.Product) .WithMany(p => p.ProductDocuments) .HasForeignKey(pd => pd.ProductId);

            modelBuilder.Entity<ProductPhoto>() .HasOne(pp => pp.Product) .WithMany(p => p.ProductPhotos) .HasForeignKey(pp => pp.ProductId);

            //modelBuilder.Entity<BidDates>() .HasOne(bd => bd.Product) .WithMany(p => p.BidDetails) .HasForeignKey(bd => bd.ProductId);

            modelBuilder.Entity<BViewing>() .HasOne(v => v.User) .WithMany(u => u.BViewings) .HasForeignKey(v => v.UserId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BViewing>() .HasOne(v => v.Product) .WithMany(p => p.BViewings).HasForeignKey(v => v.ProductId);

            modelBuilder.Entity<Auctioneer>() .HasOne(a => a.Company) .WithMany(c => c.Auctioneers) .HasForeignKey(a => a.CompanyId) .OnDelete(DeleteBehavior.Cascade);

           modelBuilder.Entity<UserRoles>() .HasOne(ur => ur.User).WithMany(u => u.UserRoles) .HasForeignKey(ur => ur.UserId);

            
        }
    }
}
