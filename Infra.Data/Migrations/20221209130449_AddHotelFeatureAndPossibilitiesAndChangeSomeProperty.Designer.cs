﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using FinderProject.Infra.Data.Context;

namespace FinderProject.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20221209130449_AddHotelFeatureAndPossibilitiesAndChangeSomeProperty")]
    partial class AddHotelFeatureAndPossibilitiesAndChangeSomeProperty
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("FinderProject.Domian.Entities.AddressInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mantaghe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RemovedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("codeposti")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("countery")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("AddressInfos");
                });

            modelBuilder.Entity("FinderProject.Domian.Entities.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("ParentCategoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RemovedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("iconCate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isRemoved")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            InsertTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "اقامتگاه و بوم گردی",
                            RemovedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            iconCate = "fi-bed",
                            isRemoved = false
                        },
                        new
                        {
                            Id = 2L,
                            InsertTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "رستوران و کافی شاپ",
                            RemovedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            iconCate = "fi-cafe",
                            isRemoved = false
                        },
                        new
                        {
                            Id = 3L,
                            InsertTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "مراکز خرید",
                            RemovedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            iconCate = "fi-shopping-bag",
                            isRemoved = false
                        },
                        new
                        {
                            Id = 4L,
                            InsertTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "هنر و تئاتر",
                            RemovedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            iconCate = "fi-museum",
                            isRemoved = false
                        },
                        new
                        {
                            Id = 5L,
                            InsertTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "تفریحی و سرگرمی",
                            RemovedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            iconCate = "fi-entertainment",
                            isRemoved = false
                        },
                        new
                        {
                            Id = 6L,
                            InsertTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "باشگاه بدنسازی",
                            RemovedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            iconCate = "fi-dumbell",
                            isRemoved = false
                        },
                        new
                        {
                            Id = 7L,
                            InsertTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "تور و سفر",
                            RemovedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            iconCate = "fi-disco-ball",
                            isRemoved = false
                        },
                        new
                        {
                            Id = 8L,
                            InsertTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "سلامتی و پزشکی",
                            RemovedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            iconCate = "fi-meds",
                            isRemoved = false
                        },
                        new
                        {
                            Id = 9L,
                            InsertTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "آرایشی و زیبایی",
                            RemovedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            iconCate = "fi-makeup",
                            isRemoved = false
                        },
                        new
                        {
                            Id = 10L,
                            InsertTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "خدمات خودرو",
                            RemovedTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdateTime = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            iconCate = "fi-car",
                            isRemoved = false
                        });
                });

            modelBuilder.Entity("FinderProject.Domian.Entities.Features", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("DisPlayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RemovedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("FinderProject.Domian.Entities.HotelFeature", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("DisPlayNameF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RemovedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isRemoved")
                        .HasColumnType("bit");

                    b.Property<byte>("numberRoom")
                        .HasColumnType("tinyint");

                    b.Property<byte>("star")
                        .HasColumnType("tinyint");

                    b.Property<string>("valueF")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("HotelFeatures");
                });

            modelBuilder.Entity("FinderProject.Domian.Entities.Images", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RemovedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Src")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isRemoved")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("FinderProject.Domian.Entities.Possibilities", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("HotelFeatureId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("PossibilityValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RemovedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isRemoved")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("HotelFeatureId");

                    b.ToTable("Possibilities");
                });

            modelBuilder.Entity("FinderProject.Domian.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("LogoSrc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RemovedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("ViewCount")
                        .HasColumnType("bigint");

                    b.Property<bool>("isRemoved")
                        .HasColumnType("bit");

                    b.Property<float>("lowPrice")
                        .HasColumnType("real");

                    b.Property<float>("maxPrice")
                        .HasColumnType("real");

                    b.Property<string>("websiteUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FinderProject.Domian.Entities.SocialMedia", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("AddressSocialMedia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RemovedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isRemoved")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("SocialMedias");
                });

            modelBuilder.Entity("FinderProject.Domian.Entities.TypeRoom", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("HotelFeatureId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RemovedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Typevalue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isRemoved")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("HotelFeatureId");

                    b.ToTable("TypeRoom");
                });

            modelBuilder.Entity("FinderProject.Domian.Entities.awards", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("HotelFeatureId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RemovedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("src")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HotelFeatureId");

                    b.HasIndex("ProductId");

                    b.ToTable("Awards");
                });

            modelBuilder.Entity("FinderProject.Domian.Entities.AddressInfo", b =>
                {
                    b.HasOne("FinderProject.Domian.Entities.Product", "Product")
                        .WithOne("AddressInfo")
                        .HasForeignKey("FinderProject.Domian.Entities.AddressInfo", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FinderProject.Domian.Entities.Category", b =>
                {
                    b.HasOne("FinderProject.Domian.Entities.Category", "ParentCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("FinderProject.Domian.Entities.Features", b =>
                {
                    b.HasOne("FinderProject.Domian.Entities.Product", "Product")
                        .WithMany("Features")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FinderProject.Domian.Entities.HotelFeature", b =>
                {
                    b.HasOne("FinderProject.Domian.Entities.Product", "Product")
                        .WithMany("HotelFeatures")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FinderProject.Domian.Entities.Images", b =>
                {
                    b.HasOne("FinderProject.Domian.Entities.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FinderProject.Domian.Entities.Possibilities", b =>
                {
                    b.HasOne("FinderProject.Domian.Entities.HotelFeature", "HotelFeature")
                        .WithMany("Possibilities")
                        .HasForeignKey("HotelFeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HotelFeature");
                });

            modelBuilder.Entity("FinderProject.Domian.Entities.Product", b =>
                {
                    b.HasOne("FinderProject.Domian.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FinderProject.Domian.Entities.SocialMedia", b =>
                {
                    b.HasOne("FinderProject.Domian.Entities.Product", "Product")
                        .WithMany("SocialMedias")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FinderProject.Domian.Entities.TypeRoom", b =>
                {
                    b.HasOne("FinderProject.Domian.Entities.HotelFeature", "HotelFeature")
                        .WithMany("typeRoom")
                        .HasForeignKey("HotelFeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HotelFeature");
                });

            modelBuilder.Entity("FinderProject.Domian.Entities.awards", b =>
                {
                    b.HasOne("FinderProject.Domian.Entities.HotelFeature", "HotelFeature")
                        .WithMany("Awards")
                        .HasForeignKey("HotelFeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinderProject.Domian.Entities.Product", null)
                        .WithMany("Awards")
                        .HasForeignKey("ProductId");

                    b.Navigation("HotelFeature");
                });

            modelBuilder.Entity("FinderProject.Domian.Entities.Category", b =>
                {
                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("FinderProject.Domian.Entities.HotelFeature", b =>
                {
                    b.Navigation("Awards");

                    b.Navigation("Possibilities");

                    b.Navigation("typeRoom");
                });

            modelBuilder.Entity("FinderProject.Domian.Entities.Product", b =>
                {
                    b.Navigation("AddressInfo");

                    b.Navigation("Awards");

                    b.Navigation("Features");

                    b.Navigation("HotelFeatures");

                    b.Navigation("Images");

                    b.Navigation("SocialMedias");
                });
#pragma warning restore 612, 618
        }
    }
}
