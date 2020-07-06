﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Official.Persistence.EFCore.Context;

namespace Official.Persistence.EFCore.Migrations
{
    [DbContext(typeof(STEDbContext))]
    [Migration("20200705213358_STE-V1.2")]
    partial class STEV12
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

                    b.Property<long>("ParentId");

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

                    b.Property<int>("Level");

                    b.Property<int>("Order");

                    b.Property<long>("ParentId");

                    b.Property<string>("SystemId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("Official.Domain.Model.Person.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("BirthCertificateNumber");

                    b.Property<int>("BirthCountry");

                    b.Property<int>("CityOfBirth");

                    b.Property<string>("DateOfBirth");

                    b.Property<string>("Description");

                    b.Property<string>("DutySystemCode");

                    b.Property<string>("Email");

                    b.Property<int>("Ethnicity");

                    b.Property<int>("Faith");

                    b.Property<string>("FatherName");

                    b.Property<int>("Gender");

                    b.Property<int>("IndigenousSituation");

                    b.Property<string>("LastName");

                    b.Property<string>("LatinName");

                    b.Property<string>("LatinSurname");

                    b.Property<int>("MaritalStatus");

                    b.Property<int>("MilitaryServiceStatus");

                    b.Property<string>("Mobile");

                    b.Property<string>("Name");

                    b.Property<string>("NationalCode");

                    b.Property<int>("Nationality");

                    b.Property<string>("NecessaryContactNumber");

                    b.Property<string>("PlaceOfIssue");

                    b.Property<int>("PostBox");

                    b.Property<string>("PostalCode");

                    b.Property<string>("PrefixName");

                    b.Property<int>("ProvinceOfBirth");

                    b.Property<int>("Religion");

                    b.Property<string>("WorkAddress");

                    b.Property<int>("WorkplacePhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });
#pragma warning restore 612, 618
        }
    }
}
