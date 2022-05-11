﻿// <auto-generated />
using System;
using Ecommerce.RepositoryLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ecommerce.RepositoryLayer.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220509063235_AddCartItems")]
    partial class AddCartItems
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ecommerce.DomainLayer.models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int?>("cartid")
                        .HasColumnType("int");

                    b.Property<byte[]>("profilepic")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("cartid")
                        .IsUnique()
                        .HasFilter("[cartid] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Ecommerce.DomainLayer.models.Cart", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Productid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Productid");

                    b.ToTable("cart");
                });

            modelBuilder.Entity("Ecommerce.DomainLayer.models.CartItems", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("cartId")
                        .HasColumnType("int");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("cartId");

                    b.HasIndex("productId");

                    b.ToTable("cartitems");
                });

            modelBuilder.Entity("Ecommerce.DomainLayer.models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("brandname")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("maincategoryid")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("picturesid")
                        .HasColumnType("int");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<string>("sellername")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("supcategoryid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("maincategoryid");

                    b.HasIndex("picturesid")
                        .IsUnique()
                        .HasFilter("[picturesid] IS NOT NULL");

                    b.HasIndex("supcategoryid");

                    b.ToTable("products");
                });

            modelBuilder.Entity("Ecommerce.DomainLayer.models.maincat", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("picture")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("id");

                    b.ToTable("maincats");
                });

            modelBuilder.Entity("Ecommerce.DomainLayer.models.picture", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("picture1")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("picture2")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("picture3")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("picture4")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("id");

                    b.ToTable("pictures");
                });

            modelBuilder.Entity("Ecommerce.DomainLayer.models.supcat", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("supcats");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Ecommerce.DomainLayer.models.ApplicationUser", b =>
                {
                    b.HasOne("Ecommerce.DomainLayer.models.Cart", "cart")
                        .WithOne("user")
                        .HasForeignKey("Ecommerce.DomainLayer.models.ApplicationUser", "cartid");

                    b.Navigation("cart");
                });

            modelBuilder.Entity("Ecommerce.DomainLayer.models.Cart", b =>
                {
                    b.HasOne("Ecommerce.DomainLayer.models.Product", null)
                        .WithMany("cart")
                        .HasForeignKey("Productid");
                });

            modelBuilder.Entity("Ecommerce.DomainLayer.models.CartItems", b =>
                {
                    b.HasOne("Ecommerce.DomainLayer.models.Cart", "Cart")
                        .WithMany("cartItems")
                        .HasForeignKey("cartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecommerce.DomainLayer.models.Product", "product")
                        .WithMany()
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("product");
                });

            modelBuilder.Entity("Ecommerce.DomainLayer.models.Product", b =>
                {
                    b.HasOne("Ecommerce.DomainLayer.models.maincat", "maincat")
                        .WithMany("products")
                        .HasForeignKey("maincategoryid");

                    b.HasOne("Ecommerce.DomainLayer.models.picture", "pictures")
                        .WithOne("product")
                        .HasForeignKey("Ecommerce.DomainLayer.models.Product", "picturesid");

                    b.HasOne("Ecommerce.DomainLayer.models.supcat", "supcat")
                        .WithMany("products")
                        .HasForeignKey("supcategoryid");

                    b.Navigation("maincat");

                    b.Navigation("pictures");

                    b.Navigation("supcat");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Ecommerce.DomainLayer.models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Ecommerce.DomainLayer.models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecommerce.DomainLayer.models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Ecommerce.DomainLayer.models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ecommerce.DomainLayer.models.Cart", b =>
                {
                    b.Navigation("cartItems");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Ecommerce.DomainLayer.models.Product", b =>
                {
                    b.Navigation("cart");
                });

            modelBuilder.Entity("Ecommerce.DomainLayer.models.maincat", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("Ecommerce.DomainLayer.models.picture", b =>
                {
                    b.Navigation("product");
                });

            modelBuilder.Entity("Ecommerce.DomainLayer.models.supcat", b =>
                {
                    b.Navigation("products");
                });
#pragma warning restore 612, 618
        }
    }
}