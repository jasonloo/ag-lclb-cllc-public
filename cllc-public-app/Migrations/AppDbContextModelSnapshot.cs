﻿// <auto-generated />
using Gov.Lclb.Cllb.Public.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Gov.Lclb.Cllb.Public.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Gov.Lclb.Cllb.Public.Models.Jurisdiction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<string>("SelectMessage")
                        .HasMaxLength(2048);

                    b.HasKey("Id");

                    b.ToTable("Jurisdictions");
                });

            modelBuilder.Entity("Gov.Lclb.Cllb.Public.Models.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .HasMaxLength(50);

                    b.Property<string>("Description")
                        .HasMaxLength(2048);

                    b.Property<string>("Name")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Gov.Lclb.Cllb.Public.Models.PostSurveyResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("postId");

                    b.Property<string>("surveyResult");

                    b.HasKey("Id");

                    b.ToTable("PostSurveyResults");
                });

            modelBuilder.Entity("Gov.Lclb.Cllb.Public.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasMaxLength(2048);

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Gov.Lclb.Cllb.Public.Models.RolePermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("PermissionId");

                    b.Property<Guid?>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("Gov.Lclb.Cllb.Public.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Email")
                        .HasMaxLength(255);

                    b.Property<string>("GivenName")
                        .HasMaxLength(50);

                    b.Property<string>("Guid")
                        .HasMaxLength(255);

                    b.Property<string>("Initials")
                        .HasMaxLength(10);

                    b.Property<string>("SmAuthorizationDirectory")
                        .HasMaxLength(255);

                    b.Property<string>("SmUserId")
                        .HasMaxLength(255);

                    b.Property<string>("Surname")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Gov.Lclb.Cllb.Public.Models.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EffectiveDate");

                    b.Property<DateTime?>("ExpiryDate");

                    b.Property<Guid?>("RoleId");

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Gov.Lclb.Cllb.Public.Models.RolePermission", b =>
                {
                    b.HasOne("Gov.Lclb.Cllb.Public.Models.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId");

                    b.HasOne("Gov.Lclb.Cllb.Public.Models.Role", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Gov.Lclb.Cllb.Public.Models.UserRole", b =>
                {
                    b.HasOne("Gov.Lclb.Cllb.Public.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId");

                    b.HasOne("Gov.Lclb.Cllb.Public.Models.User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
