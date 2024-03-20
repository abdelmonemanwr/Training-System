﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trainning_System.Models;

#nullable disable

namespace Trainning_System.Migrations
{
    [DbContext(typeof(TrainningSystemContext))]
    partial class TrainningSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.1.24081.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Trainning_System.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Degree")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("Min_Degree")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Course");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Degree = 100,
                            DepartmentId = 1,
                            Min_Degree = 60,
                            Name = "MVC"
                        },
                        new
                        {
                            Id = 2,
                            Degree = 100,
                            DepartmentId = 1,
                            Min_Degree = 60,
                            Name = "Entity Framework"
                        },
                        new
                        {
                            Id = 3,
                            Degree = 100,
                            DepartmentId = 1,
                            Min_Degree = 60,
                            Name = "LinQ"
                        },
                        new
                        {
                            Id = 4,
                            Degree = 100,
                            DepartmentId = 2,
                            Min_Degree = 60,
                            Name = "Angular"
                        },
                        new
                        {
                            Id = 5,
                            Degree = 100,
                            DepartmentId = 2,
                            Min_Degree = 60,
                            Name = "NodeJS"
                        });
                });

            modelBuilder.Entity("Trainning_System.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Manager")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Department");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Manager = "Mohamed ElShafei",
                            Name = "SD"
                        },
                        new
                        {
                            Id = 2,
                            Manager = "Omnia",
                            Name = "OS"
                        });
                });

            modelBuilder.Entity("Trainning_System.Models.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("salary")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Instructor");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Address = "Hunter X Hunter",
                            CourseId = 2,
                            DepartmentId = 1,
                            Image = "man1.jpg",
                            Name = "Killua",
                            salary = 30000
                        },
                        new
                        {
                            Id = 1,
                            Address = "Hunter X Hunter",
                            CourseId = 3,
                            DepartmentId = 1,
                            Image = "man2.jpeg",
                            Name = "Gon Freecs",
                            salary = 50000
                        },
                        new
                        {
                            Id = 3,
                            Address = "Hunter X Hunter",
                            CourseId = 1,
                            DepartmentId = 2,
                            Image = "girl.jpeg",
                            Name = "Pitou",
                            salary = 20000
                        });
                });

            modelBuilder.Entity("Trainning_System.Models.Trainee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Grade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Trainee");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Paris",
                            DepartmentId = 1,
                            Grade = "3",
                            Image = "men3m.png",
                            Name = "Men3m"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Chanzelizah",
                            DepartmentId = 1,
                            Grade = "3",
                            Image = "man1.png",
                            Name = "Ahmed"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Tokyo",
                            DepartmentId = 1,
                            Grade = "2",
                            Image = "man3.png",
                            Name = "John Doe"
                        },
                        new
                        {
                            Id = 3,
                            Address = "London",
                            DepartmentId = 2,
                            Grade = "1",
                            Image = "man4.png",
                            Name = "Mark"
                        });
                });

            modelBuilder.Entity("Trainning_System.Models.crsResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<int?>("Degree")
                        .HasColumnType("int");

                    b.Property<int>("TraineeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TraineeId");

                    b.ToTable("CrsResult");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 4,
                            Degree = 20,
                            TraineeId = 3
                        },
                        new
                        {
                            Id = 2,
                            CourseId = 1,
                            Degree = 80,
                            TraineeId = 1
                        },
                        new
                        {
                            Id = 3,
                            CourseId = 5,
                            Degree = 60,
                            TraineeId = 2
                        },
                        new
                        {
                            Id = 4,
                            CourseId = 1,
                            Degree = 55,
                            TraineeId = 4
                        },
                        new
                        {
                            Id = 5,
                            CourseId = 4,
                            Degree = 37,
                            TraineeId = 1
                        },
                        new
                        {
                            Id = 6,
                            CourseId = 5,
                            Degree = 95,
                            TraineeId = 1
                        });
                });

            modelBuilder.Entity("Trainning_System.Models.Course", b =>
                {
                    b.HasOne("Trainning_System.Models.Department", "Department")
                        .WithMany("Course")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Trainning_System.Models.Instructor", b =>
                {
                    b.HasOne("Trainning_System.Models.Course", "Course")
                        .WithMany("Instructor")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Trainning_System.Models.Department", "Department")
                        .WithMany("Instructor")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Trainning_System.Models.Trainee", b =>
                {
                    b.HasOne("Trainning_System.Models.Department", "Department")
                        .WithMany("Trainee")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Trainning_System.Models.crsResult", b =>
                {
                    b.HasOne("Trainning_System.Models.Course", "Course")
                        .WithMany("crsResult")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Trainning_System.Models.Trainee", "Trainee")
                        .WithMany("CrsResult")
                        .HasForeignKey("TraineeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("Trainning_System.Models.Course", b =>
                {
                    b.Navigation("Instructor");

                    b.Navigation("crsResult");
                });

            modelBuilder.Entity("Trainning_System.Models.Department", b =>
                {
                    b.Navigation("Course");

                    b.Navigation("Instructor");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("Trainning_System.Models.Trainee", b =>
                {
                    b.Navigation("CrsResult");
                });
#pragma warning restore 612, 618
        }
    }
}
