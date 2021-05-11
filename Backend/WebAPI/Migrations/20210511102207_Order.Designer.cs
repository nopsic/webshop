﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Data;

namespace WebAPI.Migrations
{
    [DbContext(typeof(InstrumentContext))]
    [Migration("20210511102207_Order")]
    partial class Order
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebAPI.Data.Entities.Instrument", b =>
                {
                    b.Property<int>("InstrumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstrumentId");

                    b.ToTable("Instruments");

                    b.HasData(
                        new
                        {
                            InstrumentId = 1,
                            Code = "FH0049",
                            Description = "One of the best musical instruments ever.",
                            Name = "French horn",
                            PictureName = "assets/images/french_horn.png",
                            Price = 150000,
                            Quantity = 3,
                            Rating = 5.0,
                            Type = "brass"
                        },
                        new
                        {
                            InstrumentId = 2,
                            Code = "TR0050",
                            Description = "Everybody knows what trumpet looks like.",
                            Name = "Trumpet",
                            PictureName = "assets/images/trumpet.jpg",
                            Price = 120000,
                            Quantity = 6,
                            Rating = 4.2000000000000002,
                            Type = "brass"
                        },
                        new
                        {
                            InstrumentId = 3,
                            Code = "TU0051",
                            Description = "Tuba is Tuba.",
                            Name = "Tuba",
                            PictureName = "assets/images/tuba.jpg",
                            Price = 200000,
                            Quantity = 2,
                            Rating = 4.0999999999999996,
                            Type = "brass"
                        },
                        new
                        {
                            InstrumentId = 4,
                            Code = "TB0052",
                            Description = "When mom isn't home meme.",
                            Name = "Trombone",
                            PictureName = "assets/images/trombone.jpg",
                            Price = 170000,
                            Quantity = 5,
                            Rating = 4.5999999999999996,
                            Type = "brass"
                        },
                        new
                        {
                            InstrumentId = 5,
                            Code = "FH0053",
                            Description = "A valved brass musical instrument like a cornet but with a mellower tone.",
                            Name = "Flugelhorn",
                            PictureName = "assets/images/flugelhorn.jpg",
                            Price = 134000,
                            Quantity = 5,
                            Rating = 3.7000000000000002,
                            Type = "brass"
                        },
                        new
                        {
                            InstrumentId = 6,
                            Code = "FL0054",
                            Description = "Every girl want to play this instrument.",
                            Name = "Flute",
                            PictureName = "assets/images/flute.jpg",
                            Price = 80000,
                            Quantity = 12,
                            Rating = 3.8999999999999999,
                            Type = "woodwind"
                        },
                        new
                        {
                            InstrumentId = 7,
                            Code = "AS0055",
                            Description = "Epic sax guy.",
                            Name = "Alto saxophone",
                            PictureName = "assets/images/alto_saxophone.jpg",
                            Price = 125000,
                            Quantity = 9,
                            Rating = 4.4000000000000004,
                            Type = "woodwind"
                        },
                        new
                        {
                            InstrumentId = 8,
                            Code = "CL0056",
                            Description = "Squid had this instrument in SpongeBob.",
                            Name = "Clarinet",
                            PictureName = "assets/images/clarinet.png",
                            Price = 93590,
                            Quantity = 17,
                            Rating = 4.2999999999999998,
                            Type = "woodwind"
                        },
                        new
                        {
                            InstrumentId = 9,
                            Code = "FA0056",
                            Description = "A big windwood musical instrument.",
                            Name = "Bassoon",
                            PictureName = "assets/images/bassoon.jpg",
                            Price = 134790,
                            Quantity = 1,
                            Rating = 2.5,
                            Type = "woodwind"
                        },
                        new
                        {
                            InstrumentId = 10,
                            Code = "SD0057",
                            Description = "Side drum.",
                            Name = "Snare drum",
                            PictureName = "assets/images/leaf_rake.png",
                            Price = 42370,
                            Quantity = 4,
                            Rating = 4.0,
                            Type = "percussion"
                        },
                        new
                        {
                            InstrumentId = 11,
                            Code = "BD0058",
                            Description = "Bass drum.",
                            Name = "Bass drum",
                            PictureName = "assets/images/leaf_rake.png",
                            Price = 78640,
                            Quantity = 2,
                            Rating = 3.7000000000000002,
                            Type = "percussion"
                        },
                        new
                        {
                            InstrumentId = 12,
                            Code = "PI0059",
                            Description = "Classical piano.",
                            Name = "Piano",
                            PictureName = "assets/images/leaf_rake.png",
                            Price = 540990,
                            Quantity = 1,
                            Rating = 4.5999999999999996,
                            Type = "percussion"
                        },
                        new
                        {
                            InstrumentId = 13,
                            Code = "XY0060",
                            Description = "Xylophone.",
                            Name = "Xylophone",
                            PictureName = "assets/images/leaf_rake.png",
                            Price = 99990,
                            Quantity = 1,
                            Rating = 3.2999999999999998,
                            Type = "percussion"
                        },
                        new
                        {
                            InstrumentId = 14,
                            Code = "VI0061",
                            Description = "Violin.",
                            Name = "Violin",
                            PictureName = "assets/images/leaf_rake.png",
                            Price = 135760,
                            Quantity = 11,
                            Rating = 4.2999999999999998,
                            Type = "string"
                        },
                        new
                        {
                            InstrumentId = 15,
                            Code = "CG0062",
                            Description = "Classical guitar, ideal for learning how to play the guitar.",
                            Name = "Classical guitar",
                            PictureName = "assets/images/leaf_rake.png",
                            Price = 49990,
                            Quantity = 4,
                            Rating = 4.5999999999999996,
                            Type = "string"
                        },
                        new
                        {
                            InstrumentId = 16,
                            Code = "EG0063",
                            Description = "Electric guitar is a best choice to play hard rock.",
                            Name = "Electric guitar",
                            PictureName = "assets/images/leaf_rake.png",
                            Price = 156490,
                            Quantity = 3,
                            Rating = 4.7000000000000002,
                            Type = "string"
                        });
                });

            modelBuilder.Entity("WebAPI.Data.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("WebAPI.Data.Entities.UserData", b =>
                {
                    b.Property<int>("UserDataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserDataId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
