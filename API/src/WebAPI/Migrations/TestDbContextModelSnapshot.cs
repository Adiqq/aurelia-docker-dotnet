using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Infrastructure.Data;

namespace WebAPI.Migrations
{
    [DbContext(typeof(TestDbContext))]
    partial class TestDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("Infrastructure.Data.Model.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<int?>("CommentId");

                    b.Property<string>("Content");

                    b.Property<int?>("PageId");

                    b.HasKey("Id");

                    b.HasIndex("CommentId");

                    b.HasIndex("PageId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Infrastructure.Data.Model.Page", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("Infrastructure.Data.Model.Comment", b =>
                {
                    b.HasOne("Infrastructure.Data.Model.Comment")
                        .WithMany("Children")
                        .HasForeignKey("CommentId");

                    b.HasOne("Infrastructure.Data.Model.Page", "Page")
                        .WithMany("Comments")
                        .HasForeignKey("PageId");
                });
        }
    }
}
