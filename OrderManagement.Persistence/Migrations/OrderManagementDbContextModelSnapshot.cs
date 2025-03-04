﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderManagement.Persistence;

#nullable disable

namespace OrderManagement.Persistence.Migrations
{
    [DbContext(typeof(OrderManagementDbContext))]
    partial class OrderManagementDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OrderManagement.Domain.Order.OrderAggregate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderNumber")
                        .HasColumnType("int");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("OrderAggregate");
                });

            modelBuilder.Entity("OrderManagement.Domain.Order.OrderAggregate", b =>
                {
                    b.OwnsMany("OrderManagement.Domain.Order.OrderItem", "OrderItems", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("OrderAggregateId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Id");

                            b1.HasIndex("OrderAggregateId");

                            b1.ToTable("OrderItem");

                            b1.WithOwner()
                                .HasForeignKey("OrderAggregateId");

                            b1.OwnsOne("OrderManagement.Domain.Order.Money", "UnitPrice", b2 =>
                                {
                                    b2.Property<Guid>("OrderItemId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<decimal>("Value")
                                        .HasColumnType("decimal(18,2)");

                                    b2.HasKey("OrderItemId");

                                    b2.ToTable("OrderItem");

                                    b2.WithOwner()
                                        .HasForeignKey("OrderItemId");
                                });

                            b1.OwnsOne("OrderManagement.Domain.Order.Quantity", "Quantity", b2 =>
                                {
                                    b2.Property<Guid>("OrderItemId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<long>("Value")
                                        .HasColumnType("bigint");

                                    b2.HasKey("OrderItemId");

                                    b2.ToTable("OrderItem");

                                    b2.WithOwner()
                                        .HasForeignKey("OrderItemId");
                                });

                            b1.Navigation("Quantity")
                                .IsRequired();

                            b1.Navigation("UnitPrice")
                                .IsRequired();
                        });

                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
