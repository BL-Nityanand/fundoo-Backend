﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using repolayer.Context;

namespace repolayer.Migrations
{
    [DbContext(typeof(FundooContext))]
    partial class FundooContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("repolayer.Entity.CollaboratorEntity", b =>
                {
                    b.Property<long>("collabId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("noteid")
                        .HasColumnType("bigint");

                    b.Property<long>("userid")
                        .HasColumnType("bigint");

                    b.HasKey("collabId");

                    b.HasIndex("noteid");

                    b.HasIndex("userid");

                    b.ToTable("CollaboratorsTable");
                });

            modelBuilder.Entity("repolayer.Entity.LabelEntity", b =>
                {
                    b.Property<long>("labelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("label")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("noteid")
                        .HasColumnType("bigint");

                    b.Property<long>("userid")
                        .HasColumnType("bigint");

                    b.HasKey("labelID");

                    b.HasIndex("noteid");

                    b.HasIndex("userid");

                    b.ToTable("Labels");
                });

            modelBuilder.Entity("repolayer.Entity.NoteEntity", b =>
                {
                    b.Property<long>("noteid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("createdAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("editedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isArchived")
                        .HasColumnType("bit");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("isPinned")
                        .HasColumnType("bit");

                    b.Property<DateTime>("reminder")
                        .HasColumnType("datetime2");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("userid")
                        .HasColumnType("bigint");

                    b.HasKey("noteid");

                    b.HasIndex("userid");

                    b.ToTable("NotesTable");
                });

            modelBuilder.Entity("repolayer.Entity.UserEntity", b =>
                {
                    b.Property<long>("userid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("repolayer.Entity.CollaboratorEntity", b =>
                {
                    b.HasOne("repolayer.Entity.NoteEntity", "note")
                        .WithMany()
                        .HasForeignKey("noteid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("repolayer.Entity.UserEntity", "users")
                        .WithMany()
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("repolayer.Entity.LabelEntity", b =>
                {
                    b.HasOne("repolayer.Entity.NoteEntity", "note")
                        .WithMany()
                        .HasForeignKey("noteid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("repolayer.Entity.UserEntity", "user")
                        .WithMany()
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("repolayer.Entity.NoteEntity", b =>
                {
                    b.HasOne("repolayer.Entity.UserEntity", "user")
                        .WithMany()
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
