﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using gevs_api.Data;

#nullable disable

namespace gevs_api.Core.Migrations
{
    [DbContext(typeof(GevsDbContext))]
    partial class GevsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("gevs_api.Domain.Candidate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ConstituencyId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PartyId")
                        .HasColumnType("uuid");

                    b.Property<int>("VoteCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Candidates");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b34bfb32-6e73-4feb-a3d1-049f3bc87063"),
                            ConstituencyId = new Guid("54a13cc1-0c60-436c-8b06-4ef8b0789ba7"),
                            Name = "candidate 1",
                            PartyId = new Guid("8722b842-c9aa-4bf5-99c4-402a8ecac82c"),
                            VoteCount = 4
                        },
                        new
                        {
                            Id = new Guid("0087a1df-8fe1-4254-b9c3-83811934e677"),
                            ConstituencyId = new Guid("54a13cc1-0c60-436c-8b06-4ef8b0789ba7"),
                            Name = "candidate 2",
                            PartyId = new Guid("5ade3b46-ca2c-4309-858d-e916e65ed03a"),
                            VoteCount = 2
                        },
                        new
                        {
                            Id = new Guid("2fd811f6-490e-4319-b1f0-d949570d6b92"),
                            ConstituencyId = new Guid("54a13cc1-0c60-436c-8b06-4ef8b0789ba7"),
                            Name = "candidate 3",
                            PartyId = new Guid("eedbc3b1-a9c7-495c-a113-68d35a2d112c"),
                            VoteCount = 1
                        },
                        new
                        {
                            Id = new Guid("a93008cc-f290-4484-8605-dcb168297bba"),
                            ConstituencyId = new Guid("3ae69fd3-a026-4603-b5a5-0aafdc0e87d0"),
                            Name = "candidate 1",
                            PartyId = new Guid("8722b842-c9aa-4bf5-99c4-402a8ecac82c"),
                            VoteCount = 4
                        },
                        new
                        {
                            Id = new Guid("8f8fd368-c33e-449c-8af4-ffb8626880a0"),
                            ConstituencyId = new Guid("3ae69fd3-a026-4603-b5a5-0aafdc0e87d0"),
                            Name = "candidate 2",
                            PartyId = new Guid("5ade3b46-ca2c-4309-858d-e916e65ed03a"),
                            VoteCount = 3
                        },
                        new
                        {
                            Id = new Guid("a1cc8cce-59f3-4a53-bb01-37845da7b05f"),
                            ConstituencyId = new Guid("3ae69fd3-a026-4603-b5a5-0aafdc0e87d0"),
                            Name = "candidate 3",
                            PartyId = new Guid("eedbc3b1-a9c7-495c-a113-68d35a2d112c"),
                            VoteCount = 1
                        },
                        new
                        {
                            Id = new Guid("4db6523f-6d27-4ec9-9699-8b577c547fc8"),
                            ConstituencyId = new Guid("ffcef07a-4f74-451a-8d00-b371faa51b3d"),
                            Name = "candidate 1",
                            PartyId = new Guid("8722b842-c9aa-4bf5-99c4-402a8ecac82c"),
                            VoteCount = 5
                        },
                        new
                        {
                            Id = new Guid("b44b2013-ca8e-4dab-8ea8-0fb14253bac0"),
                            ConstituencyId = new Guid("ffcef07a-4f74-451a-8d00-b371faa51b3d"),
                            Name = "candidate 2",
                            PartyId = new Guid("5ade3b46-ca2c-4309-858d-e916e65ed03a"),
                            VoteCount = 2
                        },
                        new
                        {
                            Id = new Guid("08c611d7-d6b4-4f29-b64e-6308737e9396"),
                            ConstituencyId = new Guid("ffcef07a-4f74-451a-8d00-b371faa51b3d"),
                            Name = "candidate 3",
                            PartyId = new Guid("eedbc3b1-a9c7-495c-a113-68d35a2d112c"),
                            VoteCount = 1
                        },
                        new
                        {
                            Id = new Guid("e8708f5c-f719-43eb-95af-1537285ad80d"),
                            ConstituencyId = new Guid("b071e105-fb89-4940-9856-ac725c469118"),
                            Name = "candidate 1",
                            PartyId = new Guid("8722b842-c9aa-4bf5-99c4-402a8ecac82c"),
                            VoteCount = 2
                        },
                        new
                        {
                            Id = new Guid("fcb28380-7745-4333-bd36-995aecc2c02a"),
                            ConstituencyId = new Guid("b071e105-fb89-4940-9856-ac725c469118"),
                            Name = "candidate 2",
                            PartyId = new Guid("5ade3b46-ca2c-4309-858d-e916e65ed03a"),
                            VoteCount = 5
                        },
                        new
                        {
                            Id = new Guid("2474fb28-ace2-4f7d-a460-b5f9f804165b"),
                            ConstituencyId = new Guid("b071e105-fb89-4940-9856-ac725c469118"),
                            Name = "candidate 3",
                            PartyId = new Guid("eedbc3b1-a9c7-495c-a113-68d35a2d112c"),
                            VoteCount = 1
                        },
                        new
                        {
                            Id = new Guid("77487e75-9a02-4295-a379-9800a3680fd8"),
                            ConstituencyId = new Guid("12ab861c-80fb-4ed5-ba91-2fd8c5b21e7b"),
                            Name = "candidate 1",
                            PartyId = new Guid("8722b842-c9aa-4bf5-99c4-402a8ecac82c"),
                            VoteCount = 2
                        },
                        new
                        {
                            Id = new Guid("148fe514-ffe8-4865-80e3-c05535f72319"),
                            ConstituencyId = new Guid("12ab861c-80fb-4ed5-ba91-2fd8c5b21e7b"),
                            Name = "candidate 2",
                            PartyId = new Guid("5ade3b46-ca2c-4309-858d-e916e65ed03a"),
                            VoteCount = 2
                        },
                        new
                        {
                            Id = new Guid("0bb617a3-5ddd-4298-9368-4235e8e52611"),
                            ConstituencyId = new Guid("12ab861c-80fb-4ed5-ba91-2fd8c5b21e7b"),
                            Name = "candidate 3",
                            PartyId = new Guid("eedbc3b1-a9c7-495c-a113-68d35a2d112c"),
                            VoteCount = 6
                        });
                });

            modelBuilder.Entity("gevs_api.Domain.CandidateResult", b =>
                {
                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Party")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Vote")
                        .HasColumnType("integer");

                    b.ToTable("CandidateResults");
                });

            modelBuilder.Entity("gevs_api.Domain.Constituency", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Constituencies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3ae69fd3-a026-4603-b5a5-0aafdc0e87d0"),
                            Name = "Shangri-la-Town"
                        },
                        new
                        {
                            Id = new Guid("54a13cc1-0c60-436c-8b06-4ef8b0789ba7"),
                            Name = "Northern-Kunlun-Mountain"
                        },
                        new
                        {
                            Id = new Guid("ffcef07a-4f74-451a-8d00-b371faa51b3d"),
                            Name = "Western-Shangri-la"
                        },
                        new
                        {
                            Id = new Guid("b071e105-fb89-4940-9856-ac725c469118"),
                            Name = "Naboo-Vallery"
                        },
                        new
                        {
                            Id = new Guid("12ab861c-80fb-4ed5-ba91-2fd8c5b21e7b"),
                            Name = "New-Felucia"
                        });
                });

            modelBuilder.Entity("gevs_api.Domain.Election", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Ongoing")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Elections");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6288bcce-4f67-4971-92ed-4defb45d4117"),
                            Ongoing = false
                        });
                });

            modelBuilder.Entity("gevs_api.Domain.Party", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Parties");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8722b842-c9aa-4bf5-99c4-402a8ecac82c"),
                            Name = "Red Party"
                        },
                        new
                        {
                            Id = new Guid("5ade3b46-ca2c-4309-858d-e916e65ed03a"),
                            Name = "Blue Party"
                        },
                        new
                        {
                            Id = new Guid("eedbc3b1-a9c7-495c-a113-68d35a2d112c"),
                            Name = "Yellow Party"
                        },
                        new
                        {
                            Id = new Guid("e8e6b790-754a-43e6-a376-e2af64f3610d"),
                            Name = "Independent"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
