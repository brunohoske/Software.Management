using Microsoft.EntityFrameworkCore;
using Tablefy.Order.Api.Table;
using Tablefy.Order.Api.Coupon;
using Tablefy.Order.Api.Order.Entities;
using Tablefy.Order.Api.Order.Entities.Relations;

namespace Tablefy.Order.Api.Data
{
    public class TablefyOrderContext : DbContext
    {
        public DbSet<TableEntity> Tables { get; set; }
        public DbSet<CouponEntity> Coupons { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderItemEntity> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=tablefy_order;user=hoske;password=123", b => b.MigrationsAssembly("Tablefy.Api"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TableEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<TableEntity>().Property(x => x.Id).ValueGeneratedOnAdd();
            

            modelBuilder.Entity<CouponEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<CouponEntity>().Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<OrderEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<OrderEntity>().Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<OrderEntity>()
                .HasOne(o => o.Table)
                .WithMany()
                .HasForeignKey(o => o.TableId);

            modelBuilder.Entity<OrderItemEntity>()
            .HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<OrderItemEntity>()
            .HasOne(op => op.Order)  
            .WithMany(o => o.OrderItems)  
            .HasForeignKey(op => op.OrderId);

        }
    }
}
