﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoftIran.DataLayer.Models.Context;

namespace SoftIran.DataLayer.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20210120085114_jhgfj")]
    partial class jhgfj
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ApplicationRoleApplicationUser", b =>
                {
                    b.Property<string>("RolesId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UsersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("ApplicationRoleApplicationUser");
                });

            modelBuilder.Entity("EquipmentOffishAction", b =>
                {
                    b.Property<string>("EquipmentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OffishActionsId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EquipmentId", "OffishActionsId");

                    b.HasIndex("OffishActionsId");

                    b.ToTable("EquipmentOffishAction");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

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
                        .UseIdentityColumn();

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

            modelBuilder.Entity("SoftIran.DataLayer.Models.Entities.ApplicationRole", b =>
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

            modelBuilder.Entity("SoftIran.DataLayer.Models.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartmentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

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

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SoftIran.DataLayer.Models.Entities.Department", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("SoftIran.DataLayer.Models.Entities.Equipment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Amval")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrandId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsInUse")
                        .HasColumnType("bit");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Serial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TechnicalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("PlaceId");

                    b.HasIndex("TypeId");

                    b.ToTable("Equipment");
                });

            modelBuilder.Entity("SoftIran.DataLayer.Models.Entities.EquipmentBrand", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EquipmentBrands");
                });

            modelBuilder.Entity("SoftIran.DataLayer.Models.Entities.EquipmentPlace", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EquipmentPlaces");
                });

            modelBuilder.Entity("SoftIran.DataLayer.Models.Entities.EquipmentType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EquipmentTypes");
                });

            modelBuilder.Entity("SoftIran.DataLayer.Models.Entities.Offish", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ActoinId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("BackDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BackTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DirectorId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExitDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExitTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDone")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFinal")
                        .HasColumnType("bit");

                    b.Property<string>("OffishTemplateId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PGMId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("TemplateId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OffishTemplateId");

                    b.HasIndex("PGMId");

                    b.ToTable("Offishes");
                });

            modelBuilder.Entity("SoftIran.DataLayer.Models.Entities.OffishAction", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ActionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ActionMakerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ActionType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("OffishId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SenderId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("OffishId");

                    b.HasIndex("SenderId");

                    b.ToTable("OffishActions");
                });

            modelBuilder.Entity("SoftIran.DataLayer.Models.Entities.OffishCategory", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OffishCategories");
                });

            modelBuilder.Entity("SoftIran.DataLayer.Models.Entities.OffishDescription", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ActionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ActionId");

                    b.ToTable("OffishDescriptions");
                });

            modelBuilder.Entity("SoftIran.DataLayer.Models.Entities.OffishTemplate", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("OffishTemplates");
                });

            modelBuilder.Entity("SoftIran.DataLayer.Models.Entities.OffishUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("OffishId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("OffishId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("OffishUser");
                });

            modelBuilder.Entity("SoftIran.DataLayer.Models.Entities.PGM", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartmentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("PGMs");
                });

            modelBuilder.Entity("ApplicationRoleApplicationUser", b =>
                {
                    b.HasOne("SoftIran.DataLayer.Models.Entities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftIran.DataLayer.Models.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EquipmentOffishAction", b =>
                {
                    b.HasOne("SoftIran.DataLayer.Models.Entities.Equipment", null)
                        .WithMany()
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftIran.DataLayer.Models.Entities.OffishAction", null)
                        .WithMany()
                        .HasForeignKey("OffishActionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("SoftIran.DataLayer.Models.Entities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SoftIran.DataLayer.Models.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SoftIran.DataLayer.Models.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("SoftIran.DataLayer.Models.Entities.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftIran.DataLayer.Models.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SoftIran.DataLayer.Models.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SoftIran.DataLayer.Models.Entities.ApplicationUser", b =>
                {
                    b.HasOne("SoftIran.DataLayer.Models.Entities.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("SoftIran.DataLayer.Models.Entities.Equipment", b =>
                {
                    b.HasOne("SoftIran.DataLayer.Models.Entities.EquipmentBrand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId");

                    b.HasOne("SoftIran.DataLayer.Models.Entities.EquipmentPlace", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceId");

                    b.HasOne("SoftIran.DataLayer.Models.Entities.EquipmentType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");

                    b.Navigation("Brand");

                    b.Navigation("Place");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("SoftIran.DataLayer.Models.Entities.Offish", b =>
                {
                    b.HasOne("SoftIran.DataLayer.Models.Entities.ApplicationUser", null)
                        .WithMany("Offishes")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("SoftIran.DataLayer.Models.Entities.OffishCategory", "Category")
                        .WithMany("Offishes")
                        .HasForeignKey("CategoryId");

                    b.HasOne("SoftIran.DataLayer.Models.Entities.OffishTemplate", "OffishTemplate")
                        .WithMany()
                        .HasForeignKey("OffishTemplateId");

                    b.HasOne("SoftIran.DataLayer.Models.Entities.PGM", "PGM")
                        .WithMany("Offishes")
                        .HasForeignKey("PGMId");

                    b.Navigation("Category");

                    b.Navigation("OffishTemplate");

                    b.Navigation("PGM");
                });

            modelBuilder.Entity("SoftIran.DataLayer.Models.Entities.OffishAction", b =>
                {
                    b.HasOne("SoftIran.DataLayer.Models.Entities.Offish", "Offish")
                        .WithMany("OffishActions")
                        .HasForeignKey("OffishId");

                    b.HasOne("SoftIran.DataLayer.Models.Entities.ApplicationUser", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");

                    b.Navigation("Offish");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("SoftIran.DataLayer.Models.Entities.OffishDescription", b =>
                {
                    b.HasOne("SoftIran.DataLayer.Models.Entities.OffishAction", "Action")
                        .WithMany()
                        .HasForeignKey("ActionId");

                    b.Navigation("Action");
                });

            modelBuilder.Entity("SoftIran.DataLayer.Models.Entities.OffishUser", b =>
                {
                    b.HasOne("SoftIran.DataLayer.Models.Entities.Offish", null)
                        .WithMany("OffishUsers")
                        .HasForeignKey("OffishId");

                    b.HasOne("SoftIran.DataLayer.Models.Entities.ApplicationRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("SoftIran.DataLayer.Models.Entities.ApplicationUser", "User")
                        .WithMany("OffishUsers")
                        .HasForeignKey("UserId");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SoftIran.DataLayer.Models.Entities.PGM", b =>
                {
                    b.HasOne("SoftIran.DataLayer.Models.Entities.Department", null)
                        .WithMany("PGMs")
                        .HasForeignKey("DepartmentId");
                });

            modelBuilder.Entity("SoftIran.DataLayer.Models.Entities.ApplicationUser", b =>
                {
                    b.Navigation("Offishes");

                    b.Navigation("OffishUsers");
                });

            modelBuilder.Entity("SoftIran.DataLayer.Models.Entities.Department", b =>
                {
                    b.Navigation("PGMs");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("SoftIran.DataLayer.Models.Entities.Offish", b =>
                {
                    b.Navigation("OffishActions");

                    b.Navigation("OffishUsers");
                });

            modelBuilder.Entity("SoftIran.DataLayer.Models.Entities.OffishCategory", b =>
                {
                    b.Navigation("Offishes");
                });

            modelBuilder.Entity("SoftIran.DataLayer.Models.Entities.PGM", b =>
                {
                    b.Navigation("Offishes");
                });
#pragma warning restore 612, 618
        }
    }
}