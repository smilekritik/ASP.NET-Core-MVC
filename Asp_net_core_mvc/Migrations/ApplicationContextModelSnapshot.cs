﻿// <auto-generated />
using System;
using Asp_net_core_mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Asp_net_core_mvc.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Asp_net_core_mvc.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("AviaryId")
                        .HasColumnType("int");

                    b.Property<int>("Aviary_ID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Type_Animal_ID")
                        .HasColumnType("int");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("AviaryId");

                    b.ToTable("Animal", t =>
                        {
                            t.HasCheckConstraint("Age", "[Age] > 0");

                            t.HasCheckConstraint("Weight", "[Weight] > 0");
                        });
                });

            modelBuilder.Entity("Asp_net_core_mvc.Models.Aviary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Animals_Ammount")
                        .HasColumnType("int");

                    b.Property<int?>("TicketId")
                        .HasColumnType("int");

                    b.Property<int?>("Ticket_ID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.ToTable("Aviary", t =>
                        {
                            t.HasCheckConstraint("Animals_ammount", "[Animals_ammount] > 0");
                        });
                });

            modelBuilder.Entity("Asp_net_core_mvc.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronimic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telephone_numer")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Telephone_numer")
                        .IsUnique();

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Asp_net_core_mvc.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ZooId")
                        .HasColumnType("int");

                    b.Property<int?>("Zoo_ID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ZooId");

                    b.ToTable("Ticket", t =>
                        {
                            t.HasCheckConstraint("Cost", "[Cost] > 0");
                        });
                });

            modelBuilder.Entity("Asp_net_core_mvc.Models.Type_Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AviaryId")
                        .HasColumnType("int");

                    b.Property<string>("SomeInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specifics")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AviaryId");

                    b.ToTable("Type_Animal");
                });

            modelBuilder.Entity("Asp_net_core_mvc.Models.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PassportID")
                        .HasColumnType("int");

                    b.Property<string>("Patronimic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Soname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Worker", t =>
                        {
                            t.HasCheckConstraint("Salary", "[Salary] > 4200");
                        });
                });

            modelBuilder.Entity("Asp_net_core_mvc.Models.Zoo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Aviary_Ammount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Workers_Ammount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Zoo", t =>
                        {
                            t.HasCheckConstraint("Aviary_Ammount", "[Aviary_Ammount] > 0");

                            t.HasCheckConstraint("Workers_Ammount", "[Workers_Ammount] > 0");
                        });

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Aviary_Ammount = 2,
                            Name = "12 month",
                            Workers_Ammount = 2
                        },
                        new
                        {
                            Id = 2,
                            Aviary_Ammount = 2,
                            Name = "Kyiv",
                            Workers_Ammount = 4
                        },
                        new
                        {
                            Id = 3,
                            Aviary_Ammount = 2,
                            Name = "International",
                            Workers_Ammount = 8
                        });
                });

            modelBuilder.Entity("AviaryWorker", b =>
                {
                    b.Property<int>("AviariesId")
                        .HasColumnType("int");

                    b.Property<int>("WorkersId")
                        .HasColumnType("int");

                    b.HasKey("AviariesId", "WorkersId");

                    b.HasIndex("WorkersId");

                    b.ToTable("AviaryWorker");
                });

            modelBuilder.Entity("CustomerTicket", b =>
                {
                    b.Property<int>("CustomersId")
                        .HasColumnType("int");

                    b.Property<int>("TicketsId")
                        .HasColumnType("int");

                    b.HasKey("CustomersId", "TicketsId");

                    b.HasIndex("TicketsId");

                    b.ToTable("CustomerTicket");
                });

            modelBuilder.Entity("Asp_net_core_mvc.Models.Animal", b =>
                {
                    b.HasOne("Asp_net_core_mvc.Models.Aviary", "Aviary")
                        .WithMany("Animals")
                        .HasForeignKey("AviaryId");

                    b.Navigation("Aviary");
                });

            modelBuilder.Entity("Asp_net_core_mvc.Models.Aviary", b =>
                {
                    b.HasOne("Asp_net_core_mvc.Models.Ticket", "Ticket")
                        .WithMany("Aviaries")
                        .HasForeignKey("TicketId");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("Asp_net_core_mvc.Models.Ticket", b =>
                {
                    b.HasOne("Asp_net_core_mvc.Models.Zoo", "Zoo")
                        .WithMany("Tickets")
                        .HasForeignKey("ZooId");

                    b.Navigation("Zoo");
                });

            modelBuilder.Entity("Asp_net_core_mvc.Models.Type_Animal", b =>
                {
                    b.HasOne("Asp_net_core_mvc.Models.Aviary", "Aviary")
                        .WithMany("Type_Animals")
                        .HasForeignKey("AviaryId");

                    b.Navigation("Aviary");
                });

            modelBuilder.Entity("AviaryWorker", b =>
                {
                    b.HasOne("Asp_net_core_mvc.Models.Aviary", null)
                        .WithMany()
                        .HasForeignKey("AviariesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asp_net_core_mvc.Models.Worker", null)
                        .WithMany()
                        .HasForeignKey("WorkersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CustomerTicket", b =>
                {
                    b.HasOne("Asp_net_core_mvc.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Asp_net_core_mvc.Models.Ticket", null)
                        .WithMany()
                        .HasForeignKey("TicketsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Asp_net_core_mvc.Models.Aviary", b =>
                {
                    b.Navigation("Animals");

                    b.Navigation("Type_Animals");
                });

            modelBuilder.Entity("Asp_net_core_mvc.Models.Ticket", b =>
                {
                    b.Navigation("Aviaries");
                });

            modelBuilder.Entity("Asp_net_core_mvc.Models.Zoo", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
