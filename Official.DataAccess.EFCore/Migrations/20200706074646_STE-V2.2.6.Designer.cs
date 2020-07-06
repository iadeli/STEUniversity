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
    [Migration("20200706074646_STE-V2.2.6")]
    partial class STEV226
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Official.Domain.Model.Enum.Enumuration", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EnumFiled");

                    b.Property<string>("EnumName");

                    b.Property<string>("EnumTitle");

                    b.Property<string>("EnumValue");

                    b.HasKey("Id");

                    b.ToTable("Enumurations");
                });

            modelBuilder.Entity("Official.Domain.Model.Enum.Place", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<long>("PlaceId");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("Official.Domain.Model.Menu.Menu", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Icon");

                    b.Property<int?>("Level");

                    b.Property<long?>("MenuId");

                    b.Property<int?>("Order");

                    b.Property<string>("SystemId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("Official.Domain.Model.Person.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("BirthCertificateNumber");

                    b.Property<int?>("BirthCityId");

                    b.Property<int?>("BirthCountryId");

                    b.Property<string>("BirthDate");

                    b.Property<int?>("BirthProvinceId");

                    b.Property<string>("Description");

                    b.Property<string>("EFirstName");

                    b.Property<string>("ELastName");

                    b.Property<string>("Email");

                    b.Property<string>("EnlistCode");

                    b.Property<int?>("EnlistId");

                    b.Property<int?>("EthnicityId");

                    b.Property<string>("FatherName");

                    b.Property<string>("FirstName");

                    b.Property<int>("GenderId");

                    b.Property<int?>("IndigenousSituationId");

                    b.Property<int?>("IssueCityId");

                    b.Property<string>("LastName");

                    b.Property<int?>("MarriedId");

                    b.Property<string>("Mobile");

                    b.Property<string>("NationalCode");

                    b.Property<int?>("NationalityId");

                    b.Property<string>("NecessaryContactNumber");

                    b.Property<string>("PostBox");

                    b.Property<string>("PostalCode");

                    b.Property<int>("PrefixId");

                    b.Property<int?>("ReligionId");

                    b.Property<int?>("SubReligionId");

                    b.Property<string>("WorkAddress");

                    b.Property<string>("WorkplacePhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Official.Domain.Model.Menu.Menu", b =>
                {
                    b.HasOne("Official.Domain.Model.Menu.Menu")
                        .WithMany("SubMenus")
                        .HasForeignKey("MenuId");
                });
#pragma warning restore 612, 618
        }
    }
}
