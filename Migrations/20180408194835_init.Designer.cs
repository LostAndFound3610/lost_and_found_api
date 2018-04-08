﻿// <auto-generated />
using lost_found_api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace lost_found_api.Migrations
{
    [DbContext(typeof(lostfoundcontext))]
    [Migration("20180408194835_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("lost_found_api.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Building");

                    b.Property<string>("Category");

                    b.Property<string>("School");

                    b.Property<string>("Type");

                    b.Property<int?>("userId");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("lost_found_api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email_Addr");

                    b.Property<string>("Phone_Num");

                    b.Property<string>("User_Name");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("lost_found_api.Models.Item", b =>
                {
                    b.HasOne("lost_found_api.Models.User", "user")
                        .WithMany("Items")
                        .HasForeignKey("userId");
                });
#pragma warning restore 612, 618
        }
    }
}
