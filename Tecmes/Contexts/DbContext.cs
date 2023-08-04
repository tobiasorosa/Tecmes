using Microsoft.EntityFrameworkCore;
using Tecmes.Entities;
using Tecmes.Extensions;
using Tecmes.Models.Auth;

namespace Tecmes.Contexts
{
    public class TecmesDbContext : DbContext
    {
        public TecmesDbContext(DbContextOptions<TecmesDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Replace "YourConnectionString" with your actual PostgreSQL connection string
                optionsBuilder.UseNpgsql("YourConnectionString");
            }
        }

        public DbSet<User> UserTb { get; set; }
        public DbSet<Product> ProductTb { get; set; }
        public DbSet<SaleOrder> SaleOrderTb { get; set; }
        public DbSet<ProductionOrder> ProductionOrderTb { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.ToTable($"{nameof(User)}Tb".ToSnakeCase());

                builder.Property(p => p.Id)
                    .UseIdentityAlwaysColumn();

                builder.HasKey(t => t.Id)
                    .HasName("PkUser");

                builder.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(300);

                builder.Property(p => p.Password)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(builder =>
            {
                builder.ToTable($"{nameof(Product)}Tb".ToSnakeCase());

                builder.Property(p => p.Id)
                    .UseIdentityAlwaysColumn();

                builder.HasKey(t => t.Id)
                    .HasName("PkProduct");

                builder.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(300);
            });

            modelBuilder.Entity<SaleOrder>(builder =>
            {
                builder.ToTable($"{nameof(SaleOrder)}Tb".ToSnakeCase());

                builder.Property(p => p.Id)
                    .UseIdentityAlwaysColumn();

                builder.HasKey(t => t.Id)
                    .HasName("PkSaleOrder");

                builder.Property(p => p.Quantity)
                    .IsRequired();

                builder.Property(p => p.ProductId)
                    .IsRequired();

                builder.Property(p => p.IsCompleted)
                    .HasDefaultValue(false);

                builder.Property(p => p.ProductionOrderId)
                    .IsRequired();

                builder.HasOne<Product>()
                    .WithMany()
                    .HasForeignKey(p => p.ProductId)
                    .HasConstraintName("FkSaleOrderTbXProductTb");

                builder.HasOne<ProductionOrder>()
                    .WithMany()
                    .HasForeignKey(p => p.ProductionOrderId)
                    .HasConstraintName("FkSaleOrderTbXProductionOrderTb");
            });

            modelBuilder.Entity<ProductionOrder>(builder =>
            {
                builder.ToTable($"{nameof(ProductionOrder)}Tb".ToSnakeCase());

                builder.Property(p => p.Id)
                    .UseIdentityAlwaysColumn();

                builder.HasKey(t => t.Id)
                    .HasName("PkProductionOrder");

                builder.Property(p => p.Quantity)
                    .IsRequired();

                builder.Property(p => p.ProductId)
                    .IsRequired();

                builder.Property(p => p.IsCompleted)
                    .HasDefaultValue(false);

                builder.Property(p => p.QuantitySold)
                    .HasDefaultValue(0);

                builder.HasOne<ProductionOrder>()
                    .WithMany()
                    .HasForeignKey(p => p.ProductId)
                    .HasConstraintName("FkSaleOrderTbXProductTb");
            });
        }
    }
}