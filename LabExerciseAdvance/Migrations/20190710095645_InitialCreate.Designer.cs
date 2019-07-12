﻿// <auto-generated />
using System;
using LabExerciseAdvance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LabExerciseAdvance.Migrations
{
    [DbContext(typeof(LabExerciseDBContext))]
    [Migration("20190710095645_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LabExerciseAdvance.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<string>("Province");

                    b.Property<string>("Region");

                    b.HasKey("ID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("LabExerciseAdvance.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("FirstName");

                    b.Property<int>("Gender");

                    b.Property<string>("LastName");

                    b.Property<int>("Status");

                    b.HasKey("ID");

                    b.ToTable("Persons");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("LabExerciseAdvance.Adult", b =>
                {
                    b.HasBaseType("LabExerciseAdvance.Person");

                    b.Property<bool>("Employed");

                    b.Property<string>("JobTitle");

                    b.ToTable("Adults");

                    b.HasDiscriminator().HasValue("Adult");
                });

            modelBuilder.Entity("LabExerciseAdvance.Child", b =>
                {
                    b.HasBaseType("LabExerciseAdvance.Person");

                    b.Property<string>("Level");

                    b.Property<string>("School");

                    b.ToTable("Childs");

                    b.HasDiscriminator().HasValue("Child");
                });

            modelBuilder.Entity("LabExerciseAdvance.Infant", b =>
                {
                    b.HasBaseType("LabExerciseAdvance.Person");

                    b.Property<string>("FavoriteFood");

                    b.Property<string>("FavoriteMilk");

                    b.ToTable("Infants");

                    b.HasDiscriminator().HasValue("Infant");
                });
#pragma warning restore 612, 618
        }
    }
}
