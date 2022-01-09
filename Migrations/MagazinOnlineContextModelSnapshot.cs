﻿// <auto-generated />
using MagazinOnline.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MagazinOnline.Migrations
{
    [DbContext(typeof(MagazinOnlineContext))]
    partial class MagazinOnlineContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MagazinOnline.Models.CryptoMarketCap", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CryptocurrencyID")
                        .HasColumnType("int");

                    b.Property<int>("MarketCapID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CryptocurrencyID");

                    b.HasIndex("MarketCapID");

                    b.ToTable("CryptoMarketCap");
                });

            modelBuilder.Entity("MagazinOnline.Models.Cryptocurrency", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SellerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SellerID");

                    b.ToTable("Cryptocurrency");
                });

            modelBuilder.Entity("MagazinOnline.Models.MarketCap", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MarketCapValue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("MarketCap");
                });

            modelBuilder.Entity("MagazinOnline.Models.Seller", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SellerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Seller");
                });

            modelBuilder.Entity("MagazinOnline.Models.CryptoMarketCap", b =>
                {
                    b.HasOne("MagazinOnline.Models.Cryptocurrency", "Cryptocurrency")
                        .WithMany("CryptoMarketCaps")
                        .HasForeignKey("CryptocurrencyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MagazinOnline.Models.MarketCap", "MarketCap")
                        .WithMany("CryptoMarketCaps")
                        .HasForeignKey("MarketCapID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cryptocurrency");

                    b.Navigation("MarketCap");
                });

            modelBuilder.Entity("MagazinOnline.Models.Cryptocurrency", b =>
                {
                    b.HasOne("MagazinOnline.Models.Seller", "Seller")
                        .WithMany("Cryptocurrencies")
                        .HasForeignKey("SellerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("MagazinOnline.Models.Cryptocurrency", b =>
                {
                    b.Navigation("CryptoMarketCaps");
                });

            modelBuilder.Entity("MagazinOnline.Models.MarketCap", b =>
                {
                    b.Navigation("CryptoMarketCaps");
                });

            modelBuilder.Entity("MagazinOnline.Models.Seller", b =>
                {
                    b.Navigation("Cryptocurrencies");
                });
#pragma warning restore 612, 618
        }
    }
}
