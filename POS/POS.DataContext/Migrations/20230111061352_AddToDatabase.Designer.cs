﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POS.Repository;

#nullable disable

namespace POS.Repository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230111061352_AddToDatabase")]
    partial class AddToDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("POS.Repository.CategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("category_name");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("description");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("picture");

                    b.HasKey("Id");

                    b.ToTable("tbl_categories");
                });

            modelBuilder.Entity("POS.Repository.CustomerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("address");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("city");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("company_name");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("contact_name");

                    b.Property<string>("ContactTitle")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("contact_title");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("country");

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("fax");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("phone");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("postal_code");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("region");

                    b.HasKey("Id");

                    b.ToTable("tbl_customers");
                });

            modelBuilder.Entity("POS.Repository.EmployeeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("address");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("birth_date");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("country");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("extension");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("first_name");

                    b.Property<DateOnly>("HireDate")
                        .HasColumnType("date")
                        .HasColumnName("hire_date");

                    b.Property<string>("HomePhone")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("home_phone");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("last_name");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("notes");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("photo");

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("photo_path");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("postal_code");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("region");

                    b.Property<string>("ReportsTo")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("reports_to");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("title");

                    b.Property<string>("TitleOfCourtesy")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("title_of_courtesy");

                    b.HasKey("Id");

                    b.ToTable("tbl_employees");
                });

            modelBuilder.Entity("POS.Repository.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("Discount")
                        .HasColumnType("int")
                        .HasColumnName("discount");

                    b.Property<int>("OrdersId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("double")
                        .HasColumnName("unit_price");

                    b.HasKey("Id");

                    b.HasIndex("OrdersId");

                    b.HasIndex("ProductsId");

                    b.ToTable("tbl_order_details");
                });

            modelBuilder.Entity("POS.Repository.OrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("CustomersId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeesId")
                        .HasColumnType("int");

                    b.Property<string>("Freight")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("freight");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("order_date");

                    b.Property<DateTime>("RequiredDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("required_date");

                    b.Property<string>("ShipAddress")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("ship_address");

                    b.Property<string>("ShipCity")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("ship_city");

                    b.Property<string>("ShipCountry")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("ship_country");

                    b.Property<string>("ShipName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("ship_name");

                    b.Property<string>("ShipPostalCode")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("ship_postal_code");

                    b.Property<string>("ShipRegion")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("ship_region");

                    b.Property<int>("ShipVia")
                        .HasColumnType("int")
                        .HasColumnName("ship_via");

                    b.Property<DateTime>("ShippedDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("shipped_date");

                    b.Property<int?>("ShipperEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomersId");

                    b.HasIndex("EmployeesId");

                    b.HasIndex("ShipperEntityId");

                    b.ToTable("tbl_orders");
                });

            modelBuilder.Entity("POS.Repository.ProductEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("CategorysId")
                        .HasColumnType("int");

                    b.Property<bool>("Discontinued")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("discontinued");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("product_name");

                    b.Property<int>("QuantityPerUnit")
                        .HasColumnType("int")
                        .HasColumnName("quantity_per_unit");

                    b.Property<bool>("ReorderLevel")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("reorder_level");

                    b.Property<int>("SuppliersId")
                        .HasColumnType("int");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("double")
                        .HasColumnName("unit_price");

                    b.Property<int>("UnitsInStock")
                        .HasColumnType("int")
                        .HasColumnName("units_in_stock");

                    b.Property<int>("UnitsOnOrder")
                        .HasColumnType("int")
                        .HasColumnName("units_on_order");

                    b.HasKey("Id");

                    b.HasIndex("CategorysId");

                    b.HasIndex("SuppliersId");

                    b.ToTable("tbl_products");
                });

            modelBuilder.Entity("POS.Repository.ShipperEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("company_name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("phone");

                    b.HasKey("Id");

                    b.ToTable("tbl_shippers");
                });

            modelBuilder.Entity("POS.Repository.SupplierEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("address");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("city");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("company_name");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("contact_name");

                    b.Property<string>("ContactTitle")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("contact_title");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("country");

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("fax");

                    b.Property<string>("HomePage")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("home_page");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("phone");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("postal_code");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("region");

                    b.HasKey("Id");

                    b.ToTable("tbl_suppliers");
                });

            modelBuilder.Entity("POS.Repository.OrderDetail", b =>
                {
                    b.HasOne("POS.Repository.OrderEntity", "Orders")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POS.Repository.ProductEntity", "Products")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("POS.Repository.OrderEntity", b =>
                {
                    b.HasOne("POS.Repository.CustomerEntity", "Customers")
                        .WithMany("Orders")
                        .HasForeignKey("CustomersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POS.Repository.EmployeeEntity", "Employees")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POS.Repository.ShipperEntity", null)
                        .WithMany("Orders")
                        .HasForeignKey("ShipperEntityId");

                    b.Navigation("Customers");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("POS.Repository.ProductEntity", b =>
                {
                    b.HasOne("POS.Repository.CategoryEntity", "Categorys")
                        .WithMany("Products")
                        .HasForeignKey("CategorysId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("POS.Repository.SupplierEntity", "Suppliers")
                        .WithMany("Products")
                        .HasForeignKey("SuppliersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorys");

                    b.Navigation("Suppliers");
                });

            modelBuilder.Entity("POS.Repository.CategoryEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("POS.Repository.CustomerEntity", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("POS.Repository.EmployeeEntity", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("POS.Repository.OrderEntity", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("POS.Repository.ProductEntity", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("POS.Repository.ShipperEntity", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("POS.Repository.SupplierEntity", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
