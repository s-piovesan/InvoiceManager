﻿// <auto-generated />
using FacturationWebSite.Models.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace InvoiceManager.WebSite.Migrations
{
    [DbContext(typeof(MvcAppContext))]
    partial class MvcAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("FacturationWebSite.Models.Barcode", b =>
                {
                    b.Property<int>("BarcodeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.Property<int>("ProductId");

                    b.HasKey("BarcodeId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Barcode");
                });

            modelBuilder.Entity("FacturationWebSite.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("address");

                    b.Property<string>("address2");

                    b.Property<string>("address3");

                    b.Property<string>("city");

                    b.Property<string>("zipcode");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("FacturationWebSite.Models.CustomerPrice", b =>
                {
                    b.Property<int>("CustomerPriceId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.Property<double>("Price");

                    b.Property<int>("ProductId");

                    b.HasKey("CustomerPriceId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("CustomerPrice");
                });

            modelBuilder.Entity("FacturationWebSite.Models.Delivery", b =>
                {
                    b.Property<int>("DeliveryId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int>("Status");

                    b.HasKey("DeliveryId");

                    b.ToTable("Delivery");
                });

            modelBuilder.Entity("FacturationWebSite.Models.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<int>("CustomerId");

                    b.Property<string>("EndPeriod");

                    b.Property<string>("Ref");

                    b.Property<string>("StartPeriod");

                    b.Property<int>("Status");

                    b.HasKey("InvoiceId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("FacturationWebSite.Models.InvoiceLine", b =>
                {
                    b.Property<int>("InvoiceLineId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<int>("DeliveryId");

                    b.Property<string>("Description");

                    b.Property<int>("InvoiceId");

                    b.Property<double>("Price");

                    b.Property<int?>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("InvoiceLineId");

                    b.HasIndex("DeliveryId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ProductId");

                    b.ToTable("InvoiceLine");
                });

            modelBuilder.Entity("FacturationWebSite.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<double>("Price");

                    b.HasKey("ProductId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("FacturationWebSite.Models.Barcode", b =>
                {
                    b.HasOne("FacturationWebSite.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FacturationWebSite.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FacturationWebSite.Models.CustomerPrice", b =>
                {
                    b.HasOne("FacturationWebSite.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FacturationWebSite.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FacturationWebSite.Models.Invoice", b =>
                {
                    b.HasOne("FacturationWebSite.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FacturationWebSite.Models.InvoiceLine", b =>
                {
                    b.HasOne("FacturationWebSite.Models.Delivery", "Delivery")
                        .WithMany()
                        .HasForeignKey("DeliveryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FacturationWebSite.Models.Invoice", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FacturationWebSite.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
