﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Official.Persistence.EFCore.Context;

namespace Official.Persistence.EFCore.Migrations
{
    [DbContext(typeof(STEDbContext))]
    [Migration("20200721070116_STE_V.0.1.7")]
    partial class STE_V017
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Official.Domain.Model.Authorization.ControllerInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action");

                    b.Property<string>("Controller");

                    b.Property<string>("Policy");

                    b.HasKey("Id");

                    b.ToTable("ControllerInfos");
                });

            modelBuilder.Entity("Official.Domain.Model.CommonEntity.Enum.Enumuration", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EnumFiled");

                    b.Property<string>("EnumName")
                        .IsRequired();

                    b.Property<string>("EnumTitle")
                        .IsRequired();

                    b.Property<string>("EnumValue")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Enumurations");
                });

            modelBuilder.Entity("Official.Domain.Model.CommonEntity.Enum.Place", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<long>("PlaceId");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("Official.Domain.Model.CommonEntity.Menu.Menu", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Icon")
                        .HasMaxLength(500);

                    b.Property<int?>("Level");

                    b.Property<long>("MenuId");

                    b.Property<int?>("Order");

                    b.Property<string>("Path")
                        .HasMaxLength(500);

                    b.Property<string>("SystemId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("Official.Domain.Model.CommonEntity.Term.Term", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FromYear")
                        .HasMaxLength(10);

                    b.Property<int>("No");

                    b.Property<string>("Title");

                    b.Property<string>("ToYear")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Terms");
                });

            modelBuilder.Entity("Official.Domain.Model.Log.ApiLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Method");

                    b.Property<string>("Path");

                    b.Property<string>("QueryString");

                    b.Property<string>("RequestBody");

                    b.Property<DateTime>("RequestTime");

                    b.Property<string>("ResponseBody");

                    b.Property<long>("ResponseMillis");

                    b.Property<int>("StatusCode");

                    b.HasKey("Id");

                    b.ToTable("ApiLogs");
                });

            modelBuilder.Entity("Official.Domain.Model.Person.BirthCertificate", b =>
                {
                    b.Property<long>("PersonId");

                    b.Property<int?>("BirthCityId");

                    b.Property<int?>("BirthCountryId");

                    b.Property<string>("BirthDate")
                        .HasMaxLength(10);

                    b.Property<int?>("BirthProvinceId");

                    b.Property<string>("EFirstName");

                    b.Property<string>("ELastName");

                    b.Property<string>("FatherName");

                    b.Property<int?>("GenderId");

                    b.Property<int?>("IssueCityId");

                    b.Property<int?>("MarriedId");

                    b.Property<string>("No");

                    b.Property<int?>("PrefixId");

                    b.HasKey("PersonId");

                    b.ToTable("BirthCertificates");
                });

            modelBuilder.Entity("Official.Domain.Model.Person.Contact", b =>
                {
                    b.Property<long>("PersonId");

                    b.Property<string>("Address");

                    b.Property<string>("Description");

                    b.Property<string>("Email");

                    b.Property<string>("Mobile")
                        .HasMaxLength(11);

                    b.Property<string>("NecessaryContactNumber")
                        .HasMaxLength(11);

                    b.Property<string>("PostBox");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(10);

                    b.Property<string>("WorkAddress");

                    b.Property<string>("WorkplacePhoneNumber")
                        .HasMaxLength(11);

                    b.HasKey("PersonId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Official.Domain.Model.Person.DegreeAttach", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("AttachFile")
                        .IsRequired();

                    b.Property<string>("Extention")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<long>("HistoryEducationalId");

                    b.HasKey("Id");

                    b.HasIndex("HistoryEducationalId");

                    b.ToTable("DegreeAttaches");
                });

            modelBuilder.Entity("Official.Domain.Model.Person.EducationalInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("HolyDefenseTeacher");

                    b.Property<int>("MaxUnit");

                    b.Property<long>("PersonId");

                    b.Property<bool?>("ReligiousTeacher");

                    b.Property<bool?>("Status");

                    b.Property<int>("TeacherTypeId");

                    b.Property<long>("TermId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("TermId");

                    b.ToTable("EducationalInfos");
                });

            modelBuilder.Entity("Official.Domain.Model.Person.HireStage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<bool>("IsFacultymember");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<long>("PersonId");

                    b.Property<long>("TermId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("TermId");

                    b.ToTable("HireStages");
                });

            modelBuilder.Entity("Official.Domain.Model.Person.HistoryEducational", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AverageScore");

                    b.Property<string>("DegreeDate")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<long>("DegreeId");

                    b.Property<int?>("DegreeStatus");

                    b.Property<string>("EndDate")
                        .HasMaxLength(10);

                    b.Property<long>("GradeId");

                    b.Property<long>("MajorSubjectId");

                    b.Property<long>("PersonId");

                    b.Property<long>("UniversityId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("HistoryEducationals");
                });

            modelBuilder.Entity("Official.Domain.Model.Person.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("PersonnelCode")
                        .IsRequired();

                    b.Property<int>("PositionId");

                    b.Property<string>("TeacherCode")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Official.Domain.Model.Person.PersonDetail", b =>
                {
                    b.Property<long>("PersonId");

                    b.Property<string>("EnlistCode");

                    b.Property<int?>("EnlistId");

                    b.Property<int?>("EthnicityId");

                    b.Property<int?>("IndigenousSituationId");

                    b.Property<int?>("NationalityId");

                    b.Property<int?>("ReligionId");

                    b.Property<int?>("SubReligionId");

                    b.HasKey("PersonId");

                    b.ToTable("PersonDetails");
                });

            modelBuilder.Entity("Official.Persistence.EFCore.Identity.AppRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Official.Persistence.EFCore.Identity.AppRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<long>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Official.Persistence.EFCore.Identity.AppUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<long>("PersonId");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Official.Persistence.EFCore.Identity.AppUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Official.Persistence.EFCore.Identity.AppUserLogin", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<long>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Official.Persistence.EFCore.Identity.AppUserRole", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<long>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Official.Persistence.EFCore.Identity.AppUserToken", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Z.EntityFramework.Plus.AuditEntry", b =>
                {
                    b.Property<int>("AuditEntryID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(255);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("EntitySetName")
                        .HasMaxLength(255);

                    b.Property<string>("EntityTypeName")
                        .HasMaxLength(255);

                    b.Property<int>("State");

                    b.Property<string>("StateName")
                        .HasMaxLength(255);

                    b.HasKey("AuditEntryID");

                    b.ToTable("AuditEntries");
                });

            modelBuilder.Entity("Z.EntityFramework.Plus.AuditEntryProperty", b =>
                {
                    b.Property<int>("AuditEntryPropertyID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuditEntryID");

                    b.Property<string>("NewValueFormatted")
                        .HasColumnName("NewValue");

                    b.Property<string>("OldValueFormatted")
                        .HasColumnName("OldValue");

                    b.Property<string>("PropertyName")
                        .HasMaxLength(255);

                    b.Property<string>("RelationName")
                        .HasMaxLength(255);

                    b.HasKey("AuditEntryPropertyID");

                    b.HasIndex("AuditEntryID");

                    b.ToTable("AuditEntryProperties");
                });

            modelBuilder.Entity("Official.Domain.Model.CommonEntity.Menu.Menu", b =>
                {
                    b.HasOne("Official.Domain.Model.CommonEntity.Menu.Menu")
                        .WithMany("SubMenus")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Official.Domain.Model.Person.BirthCertificate", b =>
                {
                    b.HasOne("Official.Domain.Model.Person.Person", "Person")
                        .WithOne("BirthCertificate")
                        .HasForeignKey("Official.Domain.Model.Person.BirthCertificate", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Official.Domain.Model.Person.Contact", b =>
                {
                    b.HasOne("Official.Domain.Model.Person.Person", "Person")
                        .WithOne("Contact")
                        .HasForeignKey("Official.Domain.Model.Person.Contact", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Official.Domain.Model.Person.DegreeAttach", b =>
                {
                    b.HasOne("Official.Domain.Model.Person.HistoryEducational", "HistoryEducational")
                        .WithMany("DegreeAttaches")
                        .HasForeignKey("HistoryEducationalId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Official.Domain.Model.Person.EducationalInfo", b =>
                {
                    b.HasOne("Official.Domain.Model.Person.Person", "Person")
                        .WithMany("EducationalInfos")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Official.Domain.Model.CommonEntity.Term.Term", "Term")
                        .WithMany("EducationalInfos")
                        .HasForeignKey("TermId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Official.Domain.Model.Person.HireStage", b =>
                {
                    b.HasOne("Official.Domain.Model.Person.Person", "Person")
                        .WithMany("HireStages")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Official.Domain.Model.CommonEntity.Term.Term", "Term")
                        .WithMany("HireStages")
                        .HasForeignKey("TermId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Official.Domain.Model.Person.HistoryEducational", b =>
                {
                    b.HasOne("Official.Domain.Model.Person.Person", "Person")
                        .WithMany("HistoryEducationals")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Official.Domain.Model.Person.PersonDetail", b =>
                {
                    b.HasOne("Official.Domain.Model.Person.Person", "Person")
                        .WithOne("PersonDetail")
                        .HasForeignKey("Official.Domain.Model.Person.PersonDetail", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Official.Persistence.EFCore.Identity.AppRoleClaim", b =>
                {
                    b.HasOne("Official.Persistence.EFCore.Identity.AppRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Official.Persistence.EFCore.Identity.AppUserClaim", b =>
                {
                    b.HasOne("Official.Persistence.EFCore.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Official.Persistence.EFCore.Identity.AppUserLogin", b =>
                {
                    b.HasOne("Official.Persistence.EFCore.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Official.Persistence.EFCore.Identity.AppUserRole", b =>
                {
                    b.HasOne("Official.Persistence.EFCore.Identity.AppRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Official.Persistence.EFCore.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Official.Persistence.EFCore.Identity.AppUserToken", b =>
                {
                    b.HasOne("Official.Persistence.EFCore.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Z.EntityFramework.Plus.AuditEntryProperty", b =>
                {
                    b.HasOne("Z.EntityFramework.Plus.AuditEntry", "Parent")
                        .WithMany("Properties")
                        .HasForeignKey("AuditEntryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
