﻿// <auto-generated />
using System;
using IQ.Accountant.System.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IQ.Accountant.System.Model.Migrations
{
    [DbContext(typeof(IQAccountantSystemContext))]
    [Migration("20220622143702_editProduct")]
    partial class editProduct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IQ.Accountant.System.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnName("ADDED_DATA")
                        .HasColumnType("datetime2");

                    b.Property<string>("IPAddress")
                        .HasColumnName("IP_ADDRESS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnName("MODEFIED_DATA")
                        .HasColumnType("datetime2");

                    b.Property<string>("imageUrl")
                        .HasColumnName("IMAGE_URL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IMAGE");
                });

            modelBuilder.Entity("IQ.Accountant.System.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnName("ADDED_DATA")
                        .HasColumnType("datetime2");

                    b.Property<string>("IPAddress")
                        .HasColumnName("IP_ADDRESS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnName("MODEFIED_DATA")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasColumnName("PRODUCT_CODE")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnName("PRODUCT_NAME")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductNote")
                        .HasColumnName("PRODUCT_NOTE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("ProductPrice")
                        .HasColumnName("PRODUCT_PRICE")
                        .HasColumnType("real");

                    b.Property<float?>("ProductTax")
                        .HasColumnName("PRODUCT_TAX")
                        .HasColumnType("real");

                    b.Property<string>("ProductUnit")
                        .IsRequired()
                        .HasColumnName("PRODUCT_UNIT")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductCode")
                        .IsUnique();

                    b.ToTable("PRODUCT");
                });

            modelBuilder.Entity("IQ.Accountant.System.Entities.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnName("ADDED_DATA")
                        .HasColumnType("datetime2");

                    b.Property<string>("IPAddress")
                        .HasColumnName("IP_ADDRESS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnName("MODEFIED_DATA")
                        .HasColumnType("datetime2");

                    b.Property<int>("imageId")
                        .HasColumnName("IMAGE_ID")
                        .HasColumnType("int");

                    b.Property<int>("productId")
                        .HasColumnName("PRODUCT_ID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("imageId");

                    b.HasIndex("productId");

                    b.ToTable("PRODUCT_IMAGE");
                });

            modelBuilder.Entity("IQ.Accountant.System.Entities.ProductVideo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnName("ADDED_DATA")
                        .HasColumnType("datetime2");

                    b.Property<string>("IPAddress")
                        .HasColumnName("IP_ADDRESS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnName("MODEFIED_DATA")
                        .HasColumnType("datetime2");

                    b.Property<int>("productId")
                        .HasColumnName("PRODUCT_ID")
                        .HasColumnType("int");

                    b.Property<int>("videoId")
                        .HasColumnName("VIDEO_ID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("productId");

                    b.HasIndex("videoId");

                    b.ToTable("PRODUCT_VIDEO");
                });

            modelBuilder.Entity("IQ.Accountant.System.Entities.Sales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnName("ADDED_DATA")
                        .HasColumnType("datetime2");

                    b.Property<string>("IPAddress")
                        .HasColumnName("IP_ADDRESS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnName("MODEFIED_DATA")
                        .HasColumnType("datetime2");

                    b.Property<int>("productId")
                        .HasColumnName("PRODUCT_ID")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnName("QYANTITY")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("productId");

                    b.ToTable("SALE");
                });

            modelBuilder.Entity("IQ.Accountant.System.Entities.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate")
                        .HasColumnName("ADDED_DATA")
                        .HasColumnType("datetime2");

                    b.Property<string>("IPAddress")
                        .HasColumnName("IP_ADDRESS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnName("MODEFIED_DATA")
                        .HasColumnType("datetime2");

                    b.Property<string>("videoUrl")
                        .HasColumnName("VIDEO_URL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VIDEO");
                });

            modelBuilder.Entity("IQ.Accountant.System.Entities.ProductImage", b =>
                {
                    b.HasOne("IQ.Accountant.System.Entities.Image", "image")
                        .WithMany("productImages")
                        .HasForeignKey("imageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IQ.Accountant.System.Entities.Product", "product")
                        .WithMany("productImages")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IQ.Accountant.System.Entities.ProductVideo", b =>
                {
                    b.HasOne("IQ.Accountant.System.Entities.Product", "product")
                        .WithMany("productVideos")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IQ.Accountant.System.Entities.Video", "video")
                        .WithMany("productVideos")
                        .HasForeignKey("videoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IQ.Accountant.System.Entities.Sales", b =>
                {
                    b.HasOne("IQ.Accountant.System.Entities.Product", "Product")
                        .WithMany("Sales")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}