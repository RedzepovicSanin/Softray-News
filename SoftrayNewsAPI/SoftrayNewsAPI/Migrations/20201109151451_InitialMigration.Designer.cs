﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoftrayNewsAPI.DL.DBContext;

namespace SoftrayNewsAPI.Migrations
{
    [DbContext(typeof(dbContext))]
    [Migration("20201109151451_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SoftrayNewsAPI.DL.Models.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateInserted")
                        .HasColumnType("datetime");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("varchar(max)")
                        .IsUnicode(false);

                    b.Property<string>("Title")
                        .HasColumnType("varchar(max)")
                        .IsUnicode(false);

                    b.Property<int?>("UserCreatedId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserCreatedId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("SoftrayNewsAPI.DL.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateInserted")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(max)")
                        .IsUnicode(false);

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("SoftrayNewsAPI.DL.Models.News", b =>
                {
                    b.HasOne("SoftrayNewsAPI.DL.Models.User", "UserCreated")
                        .WithMany()
                        .HasForeignKey("UserCreatedId");
                });
#pragma warning restore 612, 618
        }
    }
}
