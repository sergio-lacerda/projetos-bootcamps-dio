// <auto-generated />
using Estoque.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Estoque.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20201212110600_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Estoque.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("codProd")
                        .HasColumnType("int");

                    b.Property<string>("nomeProd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("precoProd")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("qtdEstProd")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
