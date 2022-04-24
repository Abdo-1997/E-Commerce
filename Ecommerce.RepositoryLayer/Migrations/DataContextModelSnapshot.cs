﻿// <auto-generated />
using System;
using Ecommerce.RepositoryLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ecommerce.RepositoryLayer.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Ecommerce.DomainLayer.models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

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

                    b.Property<int?>("maincatid")
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

                    b.Property<int?>("supcatid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("maincatid");

                    b.HasIndex("picturesid")
                        .IsUnique()
                        .HasFilter("[picturesid] IS NOT NULL");

                    b.HasIndex("supcatid");

                    b.ToTable("products");
                });

            modelBuilder.Entity("Ecommerce.DomainLayer.models.maincat", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("maincats");
                });

            modelBuilder.Entity("Ecommerce.DomainLayer.models.picture", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

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
                        .UseIdentityColumn();

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("supcats");
                });

            modelBuilder.Entity("Ecommerce.DomainLayer.models.Product", b =>
                {
                    b.HasOne("Ecommerce.DomainLayer.models.maincat", "maincat")
                        .WithMany("products")
                        .HasForeignKey("maincatid");

                    b.HasOne("Ecommerce.DomainLayer.models.picture", "pictures")
                        .WithOne("product")
                        .HasForeignKey("Ecommerce.DomainLayer.models.Product", "picturesid");

                    b.HasOne("Ecommerce.DomainLayer.models.supcat", "supcat")
                        .WithMany("products")
                        .HasForeignKey("supcatid");

                    b.Navigation("maincat");

                    b.Navigation("pictures");

                    b.Navigation("supcat");
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
