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
    [Migration("20220702143220_SearchProduct")]
    partial class SearchProduct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IQ.Accountant.System.Entities.ImageVideo", b =>
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

                    b.Property<string>("Url")
                        .HasColumnName("URL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IMAGE_VIDEO");
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductIqCode")
                        .HasColumnName("PRODUCT_IQ_CODE")
                        .HasColumnType("nvarchar(max)");

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

                    b.ToTable("PRODUCT");
                });

            modelBuilder.Entity("IQ.Accountant.System.Entities.ProductImageVideo", b =>
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

                    b.Property<int>("ImageVideoId")
                        .HasColumnName("IMAGE_ID")
                        .HasColumnType("int");

                    b.Property<bool>("IsImage")
                        .HasColumnName("IS_IMAGE")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnName("MODEFIED_DATA")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnName("PRODUCT_ID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImageVideoId");

                    b.HasIndex("ProductId");

                    b.ToTable("PRODUCT_IMAGE_VIDEO");
                });

            modelBuilder.Entity("IQ.Accountant.System.Entities.Sale", b =>
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

                    b.Property<int>("ProductId")
                        .HasColumnName("PRODUCT_ID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnName("QYANTITY")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("SALE");
                });

            modelBuilder.Entity("IQ.Accountant.System.Entities.ProductImageVideo", b =>
                {
                    b.HasOne("IQ.Accountant.System.Entities.ImageVideo", "imageVideo")
                        .WithMany("productImageVideos")
                        .HasForeignKey("ImageVideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IQ.Accountant.System.Entities.Product", "product")
                        .WithMany("productImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IQ.Accountant.System.Entities.Sale", b =>
                {
                    b.HasOne("IQ.Accountant.System.Entities.Product", "Product")
                        .WithMany("Sales")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
