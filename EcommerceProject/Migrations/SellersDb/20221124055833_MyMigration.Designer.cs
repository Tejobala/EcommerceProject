// <auto-generated />
using System;
using Ecommerce.DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EcommerceProject.Migrations.SellersDb
{
    [DbContext(typeof(SellersDbContext))]
    [Migration("20221124055833_MyMigration")]
    partial class MyMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EcommerceProject.DataContext.Seller", b =>
                {
                    b.Property<string>("SellerId")
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Products")
                        .HasColumnType("int");

                    b.Property<float>("Rating")
                        .HasColumnType("real");

                    b.Property<float>("Revenue")
                        .HasColumnType("real");

                    b.Property<string>("SellerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("WalletBalance")
                        .HasColumnType("bigint");

                    b.HasKey("SellerId");

                    b.ToTable("Sellers");
                });
#pragma warning restore 612, 618
        }
    }
}
