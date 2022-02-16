﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkillMatrix.Database;

#nullable disable

namespace SkillMatrix.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SkillMatrix.Models.Department", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("SkillMatrix.Models.Language", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("SkillMatrix.Models.Skill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SkillCategoryId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SkillCategoryId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("SkillMatrix.Models.SkillCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SkillCategories");
                });

            modelBuilder.Entity("SkillMatrix.Models.Team", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long?>("DepartmentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("SkillMatrix.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long?>("DepartmentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SkillMatrix.Models.UserLanguage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long?>("LanguageId")
                        .HasColumnType("bigint");

                    b.Property<int?>("Level")
                        .HasColumnType("int");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("UserId");

                    b.ToTable("UserLanguages");
                });

            modelBuilder.Entity("SkillMatrix.Models.UserSkill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int?>("Level")
                        .HasColumnType("int");

                    b.Property<long?>("SkillId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SkillId");

                    b.HasIndex("UserId");

                    b.ToTable("UserSkills");
                });

            modelBuilder.Entity("TeamUser", b =>
                {
                    b.Property<long>("MembersId")
                        .HasColumnType("bigint");

                    b.Property<long>("TeamsId")
                        .HasColumnType("bigint");

                    b.HasKey("MembersId", "TeamsId");

                    b.HasIndex("TeamsId");

                    b.ToTable("TeamUser");
                });

            modelBuilder.Entity("SkillMatrix.Models.Skill", b =>
                {
                    b.HasOne("SkillMatrix.Models.SkillCategory", "SkillCategory")
                        .WithMany("Skills")
                        .HasForeignKey("SkillCategoryId");

                    b.Navigation("SkillCategory");
                });

            modelBuilder.Entity("SkillMatrix.Models.Team", b =>
                {
                    b.HasOne("SkillMatrix.Models.Department", null)
                        .WithMany("Teams")
                        .HasForeignKey("DepartmentId");
                });

            modelBuilder.Entity("SkillMatrix.Models.User", b =>
                {
                    b.HasOne("SkillMatrix.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("SkillMatrix.Models.UserLanguage", b =>
                {
                    b.HasOne("SkillMatrix.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId");

                    b.HasOne("SkillMatrix.Models.User", null)
                        .WithMany("Languages")
                        .HasForeignKey("UserId");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("SkillMatrix.Models.UserSkill", b =>
                {
                    b.HasOne("SkillMatrix.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId");

                    b.HasOne("SkillMatrix.Models.User", null)
                        .WithMany("Skills")
                        .HasForeignKey("UserId");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("TeamUser", b =>
                {
                    b.HasOne("SkillMatrix.Models.User", null)
                        .WithMany()
                        .HasForeignKey("MembersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkillMatrix.Models.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SkillMatrix.Models.Department", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("SkillMatrix.Models.SkillCategory", b =>
                {
                    b.Navigation("Skills");
                });

            modelBuilder.Entity("SkillMatrix.Models.User", b =>
                {
                    b.Navigation("Languages");

                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}