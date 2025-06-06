﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Infrastructure.Context;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.5");

            modelBuilder.Entity("TaskApp.Domain.Entities.SharedTaskList", b =>
                {
                    b.Property<Guid>("TaskListId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SharedWithUserId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.HasKey("TaskListId", "SharedWithUserId");

                    b.ToTable("SharedTaskLists");
                });

            modelBuilder.Entity("TaskApp.Domain.Entities.TaskItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("TaskListId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("TaskListId");

                    b.ToTable("TaskItems");
                });

            modelBuilder.Entity("TaskApp.Domain.Entities.TaskList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TaskLists");
                });

            modelBuilder.Entity("TaskApp.Domain.Entities.SharedTaskList", b =>
                {
                    b.HasOne("TaskApp.Domain.Entities.TaskList", "TaskList")
                        .WithMany("SharedWithUsers")
                        .HasForeignKey("TaskListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaskList");
                });

            modelBuilder.Entity("TaskApp.Domain.Entities.TaskItem", b =>
                {
                    b.HasOne("TaskApp.Domain.Entities.TaskList", "TaskList")
                        .WithMany("Tasks")
                        .HasForeignKey("TaskListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaskList");
                });

            modelBuilder.Entity("TaskApp.Domain.Entities.TaskList", b =>
                {
                    b.Navigation("SharedWithUsers");

                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
