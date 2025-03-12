using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text.RegularExpressions;
using Tablefy.Api.Entities;

namespace Tablefy.Api.Data
{
    public class TablefyContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CompaniesGroupEntity> CompaniesGroups { get; set; }
        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CompanyProductEntity> CompanyProducts { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<CheckEntity> Checks { get; set; }
        public DbSet<IngredientEntity> Ingredients { get; set; }
        public DbSet<CouponEntity> Coupons { get; set; }
        public DbSet<SelectionGroupEntity> SelectionGroups { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderProductEntity> OrderProducts { get; set; }
        public DbSet<ProductSidesEntity> ProductSides { get; set; }
        public DbSet<ProductRecommendationsEntity> ProductRecommendations { get; set; }
        public DbSet<ProductIngredientsEntity> ProductIngredients { get; set; }
        public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
        public DbSet<SelectionGroupProductEntity> SelectionGroupProducts { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=tablefy;user=hoske;password=123");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserEntity>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<UserEntity>()
                .Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<CompaniesGroupEntity>()
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<CompanyEntity>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<CompanyEntity>()
                .Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<CompanyEntity>()
                .HasOne(f => f.CompaniesGroup)
            .WithMany(g => g.Companies)
            .HasForeignKey(f => f.CompaniesGroupId);

            modelBuilder.Entity<CompanyProductEntity>()
            .HasKey(fp => new { fp.CompanyId, fp.ProductId });

            modelBuilder.Entity<CompanyProductEntity>()
            .HasOne(fp => fp.Company)
            .WithMany(f => f.CompanyProducts)
            .HasForeignKey(fp => fp.CompanyId);

            modelBuilder.Entity<CompanyProductEntity>()
            .HasOne(fp => fp.Product)
            .WithMany(p => p.CompanyProducts)
            .HasForeignKey(fp => fp.ProductId);

            modelBuilder.Entity<CategoryEntity>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<CategoryEntity>()
                .Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<EmployeeCompanyEntity>()
                .HasKey(pc => new { pc.EmployeeId, pc.CompanyId });

            modelBuilder.Entity<EmployeeCompanyEntity>()
                .HasOne(pc => pc.Employee)
                .WithMany()
                .HasForeignKey(pc => pc.EmployeeId);

            modelBuilder.Entity<EmployeeCompanyEntity>()
                .HasOne(pc => pc.Company)
                .WithMany()
                .HasForeignKey(pc => pc.CompanyId);


            modelBuilder.Entity<CheckEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<CheckEntity>().Property(x => x.Id).ValueGeneratedOnAdd();
            

            modelBuilder.Entity<CouponEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<CouponEntity>().Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<SelectionGroupEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<SelectionGroupEntity>().Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<IngredientEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<IngredientEntity>().Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<OrderEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<OrderEntity>().Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<OrderEntity>()
                .HasOne(o => o.Check)
                .WithMany()
                .HasForeignKey(o => o.CheckId);

            modelBuilder.Entity<OrderProductEntity>()
            .HasKey(op => new { op.OrderId, op.ProductId });

            modelBuilder.Entity<OrderProductEntity>()
            .HasOne(op => op.Order)  
            .WithMany(o => o.OrderProducts)  
            .HasForeignKey(op => op.OrderId); 

            modelBuilder.Entity<OrderProductEntity>()
                .HasOne(op => op.Product)  
                .WithMany(p => p.OrderProducts)  
                .HasForeignKey(op => op.ProductId); 

            #region Product
            modelBuilder.Entity<ProductEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<ProductEntity>().Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<ProductEntity>()
                .HasOne(o => o.CompaniesGroup)
                .WithMany()
                .HasForeignKey(o => o.CompaniesGroupId);

            #region Category Relation
            modelBuilder.Entity<ProductCategoryEntity>()
                .HasKey(pc => new { pc.CategoryId, pc.ProductId });

            modelBuilder.Entity<ProductCategoryEntity>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.ProductCategories)
                .HasForeignKey(pc => pc.CategoryId);

            modelBuilder.Entity<ProductCategoryEntity>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pc => pc.ProductId);
            #endregion

            #region Ingredients Relation
            modelBuilder.Entity<ProductIngredientsEntity>()
                .HasKey(pc => new { pc.IngredientId, pc.ProductId });

            modelBuilder.Entity<ProductIngredientsEntity>()
                .HasOne(pc => pc.Ingredient)
                .WithMany(c => c.ProductIngredients)
                .HasForeignKey(pc => pc.IngredientId);

            modelBuilder.Entity<ProductIngredientsEntity>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductIngredients)
                .HasForeignKey(pc => pc.ProductId);
            #endregion

            #region Sides Relation
            modelBuilder.Entity<ProductSidesEntity>()
            .HasKey(ps => new { ps.ProductId, ps.SideId }); // Composite Key

            modelBuilder.Entity<ProductSidesEntity>()
                .HasOne(ps => ps.Product)  
                .WithMany(p => p.ProductsSides)
                .HasForeignKey(ps => ps.ProductId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<ProductSidesEntity>()
                .HasOne(ps => ps.Side)
                .WithMany()  
                .HasForeignKey(ps => ps.SideId)
                .OnDelete(DeleteBehavior.Restrict); 
            #endregion

            #region Recommendations Relation
            modelBuilder.Entity<ProductRecommendationsEntity>()
                .HasKey(pc => new { pc.CategoryId, pc.ProductId });

            modelBuilder.Entity<ProductRecommendationsEntity>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.ProductRecommendations)
                .HasForeignKey(pc => pc.CategoryId);

            modelBuilder.Entity<ProductRecommendationsEntity>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductRecommendations)
                .HasForeignKey(pc => pc.ProductId);

            #endregion

            #region Selection Group Relation
            modelBuilder.Entity<SelectionGroupProductEntity>()
                .HasKey(sgp => new { sgp.SelectionGroupId, sgp.ProductId });

            modelBuilder.Entity<SelectionGroupProductEntity>()
                .HasOne(sgp => sgp.SelectionGroup)
                .WithMany(sg => sg.SelectionGroupProducts)
                .HasForeignKey(sgp => sgp.SelectionGroupId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SelectionGroupProductEntity>()
                .HasOne(sgp => sgp.Product)
                .WithMany(p => p.SelectionGroupProducts)
                .HasForeignKey(sgp => sgp.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #endregion

        }
    }
}
