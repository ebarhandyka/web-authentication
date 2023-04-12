﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp.Contexts;

#nullable disable

namespace WebApp.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20230411164729_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApp.Models.Account", b =>
                {
                    b.Property<string>("EmployeeNIK")
                        .HasColumnType("CHAR (5)")
                        .HasColumnName("employee_nik");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)")
                        .HasColumnName("password");

                    b.HasKey("EmployeeNIK");

                    b.ToTable("TB_M_Account");
                });

            modelBuilder.Entity("WebApp.Models.AccountRole", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("AccountNIK")
                        .IsRequired()
                        .HasColumnType("CHAR(5)")
                        .HasColumnName("account_nik");

                    b.Property<int>("RoleID")
                        .HasColumnType("INT")
                        .HasColumnName("role_id");

                    b.HasKey("ID");

                    b.HasIndex("AccountNIK");

                    b.HasIndex("RoleID");

                    b.ToTable("TB_TR_Account_Roles");
                });

            modelBuilder.Entity("WebApp.Models.Education", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("VARCHAR(10)")
                        .HasColumnName("degree");

                    b.Property<decimal>("GPA")
                        .HasColumnType("DECIMAL(3,2)")
                        .HasColumnName("gpa");

                    b.Property<string>("Major")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("major");

                    b.Property<int>("UniversityID")
                        .HasColumnType("INT")
                        .HasColumnName("university_id");

                    b.HasKey("ID");

                    b.HasIndex("UniversityID");

                    b.ToTable("TB_M_Educations");
                });

            modelBuilder.Entity("WebApp.Models.Employee", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("CHAR(5)")
                        .HasColumnName("nik");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("DATETIME")
                        .HasColumnName("birth_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("first_name");

                    b.Property<int>("Gender")
                        .HasColumnType("int")
                        .HasColumnName("gender");

                    b.Property<DateTime>("HiringDate")
                        .HasColumnType("DATETIME")
                        .HasColumnName("hiring_date");

                    b.Property<string>("LastName")
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("VARCHAR(20)")
                        .HasColumnName("phone_number");

                    b.HasKey("NIK");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("TB_M_Employees");
                });

            modelBuilder.Entity("WebApp.Models.Profiling", b =>
                {
                    b.Property<string>("EmployeeNIK")
                        .HasColumnType("CHAR (5)")
                        .HasColumnName("employee_nik");

                    b.Property<int>("EducationID")
                        .HasColumnType("INT")
                        .HasColumnName("education_id");

                    b.HasKey("EmployeeNIK");

                    b.HasIndex("EducationID")
                        .IsUnique();

                    b.ToTable("TB_TR_Profilings");
                });

            modelBuilder.Entity("WebApp.Models.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("name");

                    b.HasKey("ID");

                    b.ToTable("TB_M_Roles");
                });

            modelBuilder.Entity("WebApp.Models.University", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("name");

                    b.HasKey("ID");

                    b.ToTable("TB_M_Universities");
                });

            modelBuilder.Entity("WebApp.Models.Account", b =>
                {
                    b.HasOne("WebApp.Models.Employee", "Employees")
                        .WithOne("Accounts")
                        .HasForeignKey("WebApp.Models.Account", "EmployeeNIK")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("WebApp.Models.AccountRole", b =>
                {
                    b.HasOne("WebApp.Models.Account", "Accounts")
                        .WithMany("AccountRoles")
                        .HasForeignKey("AccountNIK")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebApp.Models.Role", "Roles")
                        .WithMany("AccountRoles")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Accounts");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("WebApp.Models.Education", b =>
                {
                    b.HasOne("WebApp.Models.University", "Universities")
                        .WithMany("Educations")
                        .HasForeignKey("UniversityID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Universities");
                });

            modelBuilder.Entity("WebApp.Models.Profiling", b =>
                {
                    b.HasOne("WebApp.Models.Education", "Educations")
                        .WithOne("Profilings")
                        .HasForeignKey("WebApp.Models.Profiling", "EducationID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WebApp.Models.Employee", "Employees")
                        .WithOne("Profilings")
                        .HasForeignKey("WebApp.Models.Profiling", "EmployeeNIK")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Educations");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("WebApp.Models.Account", b =>
                {
                    b.Navigation("AccountRoles");
                });

            modelBuilder.Entity("WebApp.Models.Education", b =>
                {
                    b.Navigation("Profilings");
                });

            modelBuilder.Entity("WebApp.Models.Employee", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Profilings");
                });

            modelBuilder.Entity("WebApp.Models.Role", b =>
                {
                    b.Navigation("AccountRoles");
                });

            modelBuilder.Entity("WebApp.Models.University", b =>
                {
                    b.Navigation("Educations");
                });
#pragma warning restore 612, 618
        }
    }
}
