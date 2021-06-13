﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Web;

namespace Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("newkilibraries.Agent", b =>
                {
                    b.Property<int>("AgentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Vergi")
                        .HasColumnType("text");

                    b.Property<string>("Website")
                        .HasColumnType("text");

                    b.Property<string>("ZipCode")
                        .HasColumnType("text");

                    b.HasKey("AgentId");

                    b.ToTable("Agent");
                });

            modelBuilder.Entity("newkilibraries.AgentCustomer", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<int>("AgentId")
                        .HasColumnType("integer");

                    b.Property<double>("Rate")
                        .HasColumnType("double precision");

                    b.HasKey("CustomerId", "AgentId");

                    b.HasIndex("AgentId");

                    b.ToTable("AgentCustomer");
                });

            modelBuilder.Entity("newkilibraries.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("newkilibraries.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Gmail")
                        .HasColumnType("text");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<int>("Rate")
                        .HasColumnType("integer");

                    b.Property<string>("Vergi")
                        .HasColumnType("text");

                    b.Property<string>("Website")
                        .HasColumnType("text");

                    b.Property<string>("ZipCode")
                        .HasColumnType("text");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("newkilibraries.DocumentFile", b =>
                {
                    b.Property<int>("DocumentFileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FileName")
                        .HasColumnType("text");

                    b.HasKey("DocumentFileId");

                    b.ToTable("DocumentFile");
                });

            modelBuilder.Entity("newkilibraries.Proforma", b =>
                {
                    b.Property<int>("ProformaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("BankAccounts")
                        .HasColumnType("text");

                    b.Property<string>("Buyer")
                        .HasColumnType("text");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<string>("Consignee")
                        .HasColumnType("text");

                    b.Property<string>("CountryOfBeneficiary")
                        .HasColumnType("text");

                    b.Property<string>("CountryOfDestination")
                        .HasColumnType("text");

                    b.Property<string>("CountryOfOrigin")
                        .HasColumnType("text");

                    b.Property<string>("Currency")
                        .HasColumnType("text");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<double>("Discount")
                        .HasColumnType("double precision");

                    b.Property<double>("ExchangeRate")
                        .HasColumnType("double precision");

                    b.Property<string>("FreightForwarder")
                        .HasColumnType("text");

                    b.Property<string>("HsCode")
                        .HasColumnType("text");

                    b.Property<double>("Kdv")
                        .HasColumnType("double precision");

                    b.Property<string>("PackageDescription")
                        .HasColumnType("text");

                    b.Property<double>("Paid")
                        .HasColumnType("double precision");

                    b.Property<string>("PartialShipment")
                        .HasColumnType("text");

                    b.Property<string>("Port")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("ProformaDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("ProformaDueDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ProformaNumber")
                        .HasColumnType("text");

                    b.Property<string>("RelevantLocation")
                        .HasColumnType("text");

                    b.Property<string>("Seller")
                        .HasColumnType("text");

                    b.Property<string>("Size")
                        .HasColumnType("text");

                    b.Property<double>("Tax")
                        .HasColumnType("double precision");

                    b.Property<string>("TermsOfDelivery")
                        .HasColumnType("text");

                    b.Property<string>("TermsOfPayment")
                        .HasColumnType("text");

                    b.Property<string>("TotalGross")
                        .HasColumnType("text");

                    b.Property<double>("TotalUsd")
                        .HasColumnType("double precision");

                    b.Property<string>("TransportBy")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("ValidUntil")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ProformaId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Proforma");
                });

            modelBuilder.Entity("newkilibraries.ProformaDataView", b =>
                {
                    b.Property<int>("ProformaId")
                        .HasColumnType("integer");

                    b.Property<string>("Data")
                        .HasColumnType("text");

                    b.HasKey("ProformaId");

                    b.ToTable("ProformaDataView");
                });

            modelBuilder.Entity("newkilibraries.ProformaDocumentFile", b =>
                {
                    b.Property<int>("ProformaId")
                        .HasColumnType("integer");

                    b.Property<int>("DocumentFileId")
                        .HasColumnType("integer");

                    b.HasKey("ProformaId", "DocumentFileId");

                    b.HasIndex("DocumentFileId");

                    b.ToTable("ProformaDocumentFile");
                });

            modelBuilder.Entity("newkilibraries.ProformaItem", b =>
                {
                    b.Property<int>("ProformaItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("ProformaItemId");

                    b.ToTable("ProformaItem");
                });

            modelBuilder.Entity("newkilibraries.ProformaProformaItem", b =>
                {
                    b.Property<int>("ProformaId")
                        .HasColumnType("integer");

                    b.Property<int>("ProformaItemId")
                        .HasColumnType("integer");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("ProformaId", "ProformaItemId");

                    b.HasIndex("ProformaItemId");

                    b.ToTable("ProformaProformaItem");
                });

            modelBuilder.Entity("newkilibraries.RequestStatus", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RequestStatus");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("newkilibraries.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("newkilibraries.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("newkilibraries.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("newkilibraries.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("newkilibraries.AgentCustomer", b =>
                {
                    b.HasOne("newkilibraries.Agent", "Agent")
                        .WithMany("Customers")
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("newkilibraries.Customer", "Customer")
                        .WithMany("Agents")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("newkilibraries.Proforma", b =>
                {
                    b.HasOne("newkilibraries.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("newkilibraries.ProformaDocumentFile", b =>
                {
                    b.HasOne("newkilibraries.DocumentFile", "File")
                        .WithMany()
                        .HasForeignKey("DocumentFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("newkilibraries.Proforma", "Proforma")
                        .WithMany("Files")
                        .HasForeignKey("ProformaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("File");

                    b.Navigation("Proforma");
                });

            modelBuilder.Entity("newkilibraries.ProformaProformaItem", b =>
                {
                    b.HasOne("newkilibraries.Proforma", "Proforma")
                        .WithMany("ProformaProformaItems")
                        .HasForeignKey("ProformaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("newkilibraries.ProformaItem", "ProformaItem")
                        .WithMany("Proformas")
                        .HasForeignKey("ProformaItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proforma");

                    b.Navigation("ProformaItem");
                });

            modelBuilder.Entity("newkilibraries.Agent", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("newkilibraries.Customer", b =>
                {
                    b.Navigation("Agents");
                });

            modelBuilder.Entity("newkilibraries.Proforma", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("ProformaProformaItems");
                });

            modelBuilder.Entity("newkilibraries.ProformaItem", b =>
                {
                    b.Navigation("Proformas");
                });
#pragma warning restore 612, 618
        }
    }
}
