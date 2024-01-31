﻿// <auto-generated />
using System;
using Gym_Manegement_API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GymManegementSystem.Migrations
{
    [DbContext(typeof(Gym_ManagementDbContext))]
    partial class Gym_ManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Gym_Manegement_API.Models.Entity.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ArabicName")
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("EnglishName")
                        .HasColumnType("int");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.HasKey("DepartmentId");

                    b.ToTable("Department", (string)null);
                });

            modelBuilder.Entity("Gym_Manegement_API.Models.Entity.GymClasses", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClassName")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("SubscriptionId")
                        .HasColumnType("int");

                    b.HasKey("ClassId");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("GymClasses", (string)null);
                });

            modelBuilder.Entity("Gym_Manegement_API.Models.Entity.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ClassesClassId")
                        .HasColumnType("int");

                    b.Property<string>("CoachDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EmergencyContactName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("EmergencyContactPhone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PersonTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("SubscriptionsSubscriptionId")
                        .HasColumnType("int");

                    b.HasKey("PersonId");

                    b.HasIndex("ClassesClassId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("PersonTypeId");

                    b.HasIndex("SubscriptionsSubscriptionId");

                    b.ToTable("Person", (string)null);
                });

            modelBuilder.Entity("Gym_Manegement_API.Models.Entity.PersonType", b =>
                {
                    b.Property<int>("PersonTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PersonTypeId");

                    b.ToTable("PersonType", (string)null);
                });

            modelBuilder.Entity("Gym_Manegement_API.Models.Entity.Subscriptions", b =>
                {
                    b.Property<int>("SubscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClassSubscriptionPlan")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("DurationInDays")
                        .HasColumnType("int");

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.Property<int>("MembershipPlan")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("Price")
                        .HasColumnType("float");

                    b.Property<int>("TrainingHoursPerDay")
                        .HasColumnType("int");

                    b.HasKey("SubscriptionId");

                    b.ToTable("Subscriptions", (string)null);
                });

            modelBuilder.Entity("Gym_Manegement_API.Models.Entity.GymClasses", b =>
                {
                    b.HasOne("Gym_Manegement_API.Models.Entity.Subscriptions", "Subscription")
                        .WithMany("Classes")
                        .HasForeignKey("SubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("Gym_Manegement_API.Models.Entity.Person", b =>
                {
                    b.HasOne("Gym_Manegement_API.Models.Entity.GymClasses", "Classes")
                        .WithMany("RegisteredClients")
                        .HasForeignKey("ClassesClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gym_Manegement_API.Models.Entity.Department", "Department")
                        .WithMany("People")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gym_Manegement_API.Models.Entity.PersonType", "PersonType")
                        .WithMany("People")
                        .HasForeignKey("PersonTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Gym_Manegement_API.Models.Entity.Subscriptions", "Subscriptions")
                        .WithMany("SubscribedClients")
                        .HasForeignKey("SubscriptionsSubscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classes");

                    b.Navigation("Department");

                    b.Navigation("PersonType");

                    b.Navigation("Subscriptions");
                });

            modelBuilder.Entity("Gym_Manegement_API.Models.Entity.Department", b =>
                {
                    b.Navigation("People");
                });

            modelBuilder.Entity("Gym_Manegement_API.Models.Entity.GymClasses", b =>
                {
                    b.Navigation("RegisteredClients");
                });

            modelBuilder.Entity("Gym_Manegement_API.Models.Entity.PersonType", b =>
                {
                    b.Navigation("People");
                });

            modelBuilder.Entity("Gym_Manegement_API.Models.Entity.Subscriptions", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("SubscribedClients");
                });
#pragma warning restore 612, 618
        }
    }
}
