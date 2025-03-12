﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tablefy.Api.Data;

#nullable disable

namespace Tablefy.Api.Migrations
{
    [DbContext(typeof(TablefyContext))]
    partial class TablefyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Tablefy.Api.Entities.CategoryEntity", b =>
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

            modelBuilder.Entity("Tablefy.Api.Entities.CheckEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Checks");
                });

            modelBuilder.Entity("Tablefy.Api.Entities.CompaniesGroupEntity", b =>
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

            modelBuilder.Entity("Tablefy.Api.Entities.CompanyEntity", b =>
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

            modelBuilder.Entity("Tablefy.Api.Entities.CompanyProductEntity", b =>
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

                    b.ToTable("CompanyProducts");
                });

            modelBuilder.Entity("Tablefy.Api.Entities.CouponEntity", b =>
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

            modelBuilder.Entity("Tablefy.Api.Entities.EmployeeCompanyEntity", b =>
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

            modelBuilder.Entity("Tablefy.Api.Entities.EmployeeEntity", b =>
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

            modelBuilder.Entity("Tablefy.Api.Entities.IngredientEntity", b =>
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

            modelBuilder.Entity("Tablefy.Api.Entities.OrderEntity", b =>
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

            modelBuilder.Entity("Tablefy.Api.Entities.OrderProductEntity", b =>
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

            modelBuilder.Entity("Tablefy.Api.Entities.ProductCategoryEntity", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("Tablefy.Api.Entities.ProductEntity", b =>
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

            modelBuilder.Entity("Tablefy.Api.Entities.ProductIngredientsEntity", b =>
                {
                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("IngredientId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductIngredients");
                });

            modelBuilder.Entity("Tablefy.Api.Entities.ProductRecommendationsEntity", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductRecommendations");
                });

            modelBuilder.Entity("Tablefy.Api.Entities.ProductSidesEntity", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("SideId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "SideId");

                    b.HasIndex("SideId");

                    b.ToTable("ProductSides");
                });

            modelBuilder.Entity("Tablefy.Api.Entities.SelectionGroupEntity", b =>
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

            modelBuilder.Entity("Tablefy.Api.Entities.SelectionGroupProductEntity", b =>
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

            modelBuilder.Entity("Tablefy.Api.Entities.UserEntity", b =>
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

            modelBuilder.Entity("Tablefy.Api.Entities.CompaniesGroupEntity", b =>
                {
                    b.HasOne("Tablefy.Api.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tablefy.Api.Entities.CompanyEntity", b =>
                {
                    b.HasOne("Tablefy.Api.Entities.CompaniesGroupEntity", "CompaniesGroup")
                        .WithMany("Companies")
                        .HasForeignKey("CompaniesGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompaniesGroup");
                });

            modelBuilder.Entity("Tablefy.Api.Entities.CompanyProductEntity", b =>
                {
                    b.HasOne("Tablefy.Api.Entities.CompanyEntity", "Company")
                        .WithMany("CompanyProducts")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tablefy.Api.Entities.ProductEntity", "Product")
                        .WithMany("CompanyProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Tablefy.Api.Entities.EmployeeCompanyEntity", b =>
                {
                    b.HasOne("Tablefy.Api.Entities.CompanyEntity", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tablefy.Api.Entities.EmployeeEntity", null)
                        .WithMany("EmployeeCompanies")
                        .HasForeignKey("EmployeeEntityId");

                    b.HasOne("Tablefy.Api.Entities.EmployeeEntity", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Tablefy.Api.Entities.EmployeeEntity", b =>
                {
                    b.HasOne("Tablefy.Api.Entities.CompaniesGroupEntity", "CompaniesGroup")
                        .WithMany()
                        .HasForeignKey("CompaniesGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompaniesGroup");
                });

            modelBuilder.Entity("Tablefy.Api.Entities.OrderEntity", b =>
                {
                    b.HasOne("Tablefy.Api.Entities.CheckEntity", "Check")
                        .WithMany()
                        .HasForeignKey("CheckId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Check");
                });

            modelBuilder.Entity("Tablefy.Api.Entities.OrderProductEntity", b =>
                {
                    b.HasOne("Tablefy.Api.Entities.OrderEntity", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tablefy.Api.Entities.ProductEntity", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Tablefy.Api.Entities.ProductCategoryEntity", b =>
                {
                    b.HasOne("Tablefy.Api.Entities.CategoryEntity", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tablefy.Api.Entities.ProductEntity", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Tablefy.Api.Entities.ProductEntity", b =>
                {
                    b.HasOne("Tablefy.Api.Entities.CompaniesGroupEntity", "CompaniesGroup")
                        .WithMany()
                        .HasForeignKey("CompaniesGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompaniesGroup");
                });

            modelBuilder.Entity("Tablefy.Api.Entities.ProductIngredientsEntity", b =>
                {
                    b.HasOne("Tablefy.Api.Entities.IngredientEntity", "Ingredient")
                        .WithMany("ProductIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tablefy.Api.Entities.ProductEntity", "Product")
                        .WithMany("ProductIngredients")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingredient");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Tablefy.Api.Entities.ProductRecommendationsEntity", b =>
                {
                    b.HasOne("Tablefy.Api.Entities.CategoryEntity", "Category")
                        .WithMany("ProductRecommendations")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tablefy.Api.Entities.ProductEntity", "Product")
                        .WithMany("ProductRecommendations")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Tablefy.Api.Entities.ProductSidesEntity", b =>
                {
                    b.HasOne("Tablefy.Api.Entities.ProductEntity", "Product")
                        .WithMany("ProductsSides")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Tablefy.Api.Entities.ProductEntity", "Side")
                        .WithMany()
                        .HasForeignKey("SideId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Side");
                });

            modelBuilder.Entity("Tablefy.Api.Entities.SelectionGroupProductEntity", b =>
                {
                    b.HasOne("Tablefy.Api.Entities.ProductEntity", "Product")
                        .WithMany("SelectionGroupProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tablefy.Api.Entities.SelectionGroupEntity", "SelectionGroup")
                        .WithMany("SelectionGroupProducts")
                        .HasForeignKey("SelectionGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("SelectionGroup");
                });

            modelBuilder.Entity("Tablefy.Api.Entities.CategoryEntity", b =>
                {
                    b.Navigation("ProductCategories");

                    b.Navigation("ProductRecommendations");
                });

            modelBuilder.Entity("Tablefy.Api.Entities.CompaniesGroupEntity", b =>
                {
                    b.Navigation("Companies");
                });

            modelBuilder.Entity("Tablefy.Api.Entities.CompanyEntity", b =>
                {
                    b.Navigation("CompanyProducts");
                });

            modelBuilder.Entity("Tablefy.Api.Entities.EmployeeEntity", b =>
                {
                    b.Navigation("EmployeeCompanies");
                });

            modelBuilder.Entity("Tablefy.Api.Entities.IngredientEntity", b =>
                {
                    b.Navigation("ProductIngredients");
                });

            modelBuilder.Entity("Tablefy.Api.Entities.OrderEntity", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("Tablefy.Api.Entities.ProductEntity", b =>
                {
                    b.Navigation("CompanyProducts");

                    b.Navigation("OrderProducts");

                    b.Navigation("ProductCategories");

                    b.Navigation("ProductIngredients");

                    b.Navigation("ProductRecommendations");

                    b.Navigation("ProductsSides");

                    b.Navigation("SelectionGroupProducts");
                });

            modelBuilder.Entity("Tablefy.Api.Entities.SelectionGroupEntity", b =>
                {
                    b.Navigation("SelectionGroupProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
