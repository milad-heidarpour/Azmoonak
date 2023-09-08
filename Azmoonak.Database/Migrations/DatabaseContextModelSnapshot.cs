﻿// <auto-generated />
using System;
using Azmoonak.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Azmoonak.Database.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Azmoonak.Database.Models.Certificate", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CorrectAnswer")
                        .HasColumnType("int");

                    b.Property<int>("FalseAnswer")
                        .HasColumnType("int");

                    b.Property<double>("FinalScore")
                        .HasColumnType("float");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("NoAnswer")
                        .HasColumnType("int");

                    b.Property<string>("OpenDateTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("UserId");

                    b.ToTable("Certificates");
                });

            modelBuilder.Entity("Azmoonak.Database.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("GroupDes")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("NotShow")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Azmoonak.Database.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AnFour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnOne")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnThree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnTwo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorrectAn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("QText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserAn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Azmoonak.Database.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("32f2d53f-1ab2-4fc4-bdeb-ef6718204148"),
                            RoleName = "admin",
                            RoleTitle = "مدیر"
                        },
                        new
                        {
                            Id = new Guid("2ad90754-f396-4949-a9a1-907c523ed7b1"),
                            RoleName = "user",
                            RoleTitle = "کاربر"
                        });
                });

            modelBuilder.Entity("Azmoonak.Database.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8c79591c-cc73-4e99-a94c-24bd42e5deeb"),
                            FName = "میلاد",
                            IsActive = true,
                            LName = "حیدرپور",
                            Mobile = "09030826556",
                            Password = "C4-65-39-0D-14-88-0E-D0-87-DC-E9-8C-CC-E7-D8-93",
                            RoleId = new Guid("32f2d53f-1ab2-4fc4-bdeb-ef6718204148")
                        });
                });

            modelBuilder.Entity("Azmoonak.Database.Models.Certificate", b =>
                {
                    b.HasOne("Azmoonak.Database.Models.Group", "Group")
                        .WithMany("Certificates")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Azmoonak.Database.Models.User", "User")
                        .WithMany("Certificates")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Azmoonak.Database.Models.Question", b =>
                {
                    b.HasOne("Azmoonak.Database.Models.Group", "Group")
                        .WithMany("Questions")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Azmoonak.Database.Models.User", b =>
                {
                    b.HasOne("Azmoonak.Database.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Azmoonak.Database.Models.Group", b =>
                {
                    b.Navigation("Certificates");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Azmoonak.Database.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Azmoonak.Database.Models.User", b =>
                {
                    b.Navigation("Certificates");
                });
#pragma warning restore 612, 618
        }
    }
}
