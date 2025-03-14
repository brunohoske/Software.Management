﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tablefy.Api.Data;

#nullable disable

namespace Tablefy.Api.Migrations
{
    [DbContext(typeof(TablefyContext))]
    [Migration("20250313043631_Initial7")]
    partial class Initial7
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Tablefy.Api.Auth.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Tablefy.Api.Category.CategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("DisplayMainPage")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Tablefy.Api.Check.CheckEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Checks");
                });

            modelBuilder.Entity("Tablefy.Api.Company.CompaniesGroupEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("CompaniesGroups");
                });

            modelBuilder.Entity("Tablefy.Api.Company.CompanyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Banner")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CompaniesGroupId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesGroupId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Tablefy.Api.Coupon.CouponEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Coupons");
                });

            modelBuilder.Entity("Tablefy.Api.Employee.EmployeeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CompaniesGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesGroupId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Tablefy.Api.Employee.Relations.EmployeeCompanyEntity", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeEntityId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "CompanyId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("EmployeeEntityId");

                    b.ToTable("EmployeeCompanyEntity");
                });

            modelBuilder.Entity("Tablefy.Api.Ingredient.IngredientEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Tablefy.Api.Order.OrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("CheckId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CheckId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Tablefy.Api.Order.Relations.OrderProductEntity", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("Tablefy.Api.Product.Entities.ProductEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CompaniesGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsCombo")
                        .HasColumnType("tinyint(1)");

                    b.Property<float>("Kcal")
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CompaniesGroupId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Tablefy.Api.Product.Entities.Relations.ComboProductsEntity", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ComboId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "ComboId");

                    b.HasIndex("ComboId");

                    b.ToTable("ComboProducts");
                });

            modelBuilder.Entity("Tablefy.Api.Product.Entities.Relations.ProductCategoryEntity", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("Tablefy.Api.Product.Entities.Relations.ProductCompanyEntity", b =>
                {
                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("PercentageDiscount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("SaleProduct")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal>("ValueDiscount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CompanyId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductsCompany");
                });

            modelBuilder.Entity("Tablefy.Api.Product.Entities.Relations.ProductIngredientsEntity", b =>
                {
                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("IngredientId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductIngredients");
                });

            modelBuilder.Entity("Tablefy.Api.Product.Entities.Relations.ProductRecommendationsEntity", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductRecommendations");
                });

            modelBuilder.Entity("Tablefy.Api.Product.Entities.Relations.ProductSidesEntity", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("SideId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "SideId");

                    b.HasIndex("SideId");

                    b.ToTable("ProductSides");
                });

            modelBuilder.Entity("Tablefy.Api.Product.Entities.Relations.SelectionGroupProductEntity", b =>
                {
                    b.Property<int>("SelectionGroupId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SelectionGroupId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("SelectionGroupProducts");
                });

            modelBuilder.Entity("Tablefy.Api.Product.Entities.SelectionGroupEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("GroupDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ViewName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("SelectionGroups");
                });

            modelBuilder.Entity("Tablefy.Api.Company.CompaniesGroupEntity", b =>
                {
                    b.HasOne("Tablefy.Api.Auth.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tablefy.Api.Company.CompanyEntity", b =>
                {
                    b.HasOne("Tablefy.Api.Company.CompaniesGroupEntity", "CompaniesGroup")
                        .WithMany("Companies")
                        .HasForeignKey("CompaniesGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompaniesGroup");
                });

            modelBuilder.Entity("Tablefy.Api.Employee.EmployeeEntity", b =>
                {
                    b.HasOne("Tablefy.Api.Company.CompaniesGroupEntity", "CompaniesGroup")
                        .WithMany()
                        .HasForeignKey("CompaniesGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompaniesGroup");
                });

            modelBuilder.Entity("Tablefy.Api.Employee.Relations.EmployeeCompanyEntity", b =>
                {
                    b.HasOne("Tablefy.Api.Company.CompanyEntity", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tablefy.Api.Employee.EmployeeEntity", null)
                        .WithMany("EmployeeCompanies")
                        .HasForeignKey("EmployeeEntityId");

                    b.HasOne("Tablefy.Api.Employee.EmployeeEntity", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Tablefy.Api.Order.OrderEntity", b =>
                {
                    b.HasOne("Tablefy.Api.Check.CheckEntity", "Check")
                        .WithMany()
                        .HasForeignKey("CheckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Check");
                });

            modelBuilder.Entity("Tablefy.Api.Order.Relations.OrderProductEntity", b =>
                {
                    b.HasOne("Tablefy.Api.Order.OrderEntity", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tablefy.Api.Product.Entities.ProductEntity", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Tablefy.Api.Product.Entities.ProductEntity", b =>
                {
                    b.HasOne("Tablefy.Api.Company.CompaniesGroupEntity", "CompaniesGroup")
                        .WithMany()
                        .HasForeignKey("CompaniesGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompaniesGroup");
                });

            modelBuilder.Entity("Tablefy.Api.Product.Entities.Relations.ComboProductsEntity", b =>
                {
                    b.HasOne("Tablefy.Api.Product.Entities.ProductEntity", "Combo")
                        .WithMany("ComboProducts")
                        .HasForeignKey("ComboId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Tablefy.Api.Product.Entities.ProductEntity", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Combo");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Tablefy.Api.Product.Entities.Relations.ProductCategoryEntity", b =>
                {
                    b.HasOne("Tablefy.Api.Category.CategoryEntity", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tablefy.Api.Product.Entities.ProductEntity", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Tablefy.Api.Product.Entities.Relations.ProductCompanyEntity", b =>
                {
                    b.HasOne("Tablefy.Api.Company.CompanyEntity", "Company")
                        .WithMany("CompanyProducts")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tablefy.Api.Product.Entities.ProductEntity", "Product")
                        .WithMany("CompanyProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Tablefy.Api.Product.Entities.Relations.ProductIngredientsEntity", b =>
                {
                    b.HasOne("Tablefy.Api.Ingredient.IngredientEntity", "Ingredient")
                        .WithMany("ProductIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tablefy.Api.Product.Entities.ProductEntity", "Product")
                        .WithMany("ProductIngredients")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Tablefy.Api.Product.Entities.Relations.ProductRecommendationsEntity", b =>
                {
                    b.HasOne("Tablefy.Api.Category.CategoryEntity", "Category")
                        .WithMany("ProductRecommendations")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tablefy.Api.Product.Entities.ProductEntity", "Product")
                        .WithMany("ProductRecommendations")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Tablefy.Api.Product.Entities.Relations.ProductSidesEntity", b =>
                {
                    b.HasOne("Tablefy.Api.Product.Entities.ProductEntity", "Product")
                        .WithMany("ProductsSides")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Tablefy.Api.Product.Entities.ProductEntity", "Side")
                        .WithMany()
                        .HasForeignKey("SideId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Side");
                });

            modelBuilder.Entity("Tablefy.Api.Product.Entities.Relations.SelectionGroupProductEntity", b =>
                {
                    b.HasOne("Tablefy.Api.Product.Entities.ProductEntity", "Product")
                        .WithMany("SelectionGroupProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tablefy.Api.Product.Entities.SelectionGroupEntity", "SelectionGroup")
                        .WithMany("SelectionGroupProducts")
                        .HasForeignKey("SelectionGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("SelectionGroup");
                });

            modelBuilder.Entity("Tablefy.Api.Category.CategoryEntity", b =>
                {
                    b.Navigation("ProductCategories");

                    b.Navigation("ProductRecommendations");
                });

            modelBuilder.Entity("Tablefy.Api.Company.CompaniesGroupEntity", b =>
                {
                    b.Navigation("Companies");
                });

            modelBuilder.Entity("Tablefy.Api.Company.CompanyEntity", b =>
                {
                    b.Navigation("CompanyProducts");
                });

            modelBuilder.Entity("Tablefy.Api.Employee.EmployeeEntity", b =>
                {
                    b.Navigation("EmployeeCompanies");
                });

            modelBuilder.Entity("Tablefy.Api.Ingredient.IngredientEntity", b =>
                {
                    b.Navigation("ProductIngredients");
                });

            modelBuilder.Entity("Tablefy.Api.Order.OrderEntity", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("Tablefy.Api.Product.Entities.ProductEntity", b =>
                {
                    b.Navigation("ComboProducts");

                    b.Navigation("CompanyProducts");

                    b.Navigation("OrderProducts");

                    b.Navigation("ProductCategories");

                    b.Navigation("ProductIngredients");

                    b.Navigation("ProductRecommendations");

                    b.Navigation("ProductsSides");

                    b.Navigation("SelectionGroupProducts");
                });

            modelBuilder.Entity("Tablefy.Api.Product.Entities.SelectionGroupEntity", b =>
                {
                    b.Navigation("SelectionGroupProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
