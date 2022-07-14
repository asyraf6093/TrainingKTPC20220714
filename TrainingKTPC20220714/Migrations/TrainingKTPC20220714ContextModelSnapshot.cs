﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrainingKTPC20220714.Data;

#nullable disable

namespace TrainingKTPC20220714.Migrations
{
    [DbContext(typeof(TrainingKTPC20220714Context))]
    partial class TrainingKTPC20220714ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TrainingKTPC20220714.Models.Bangunan", b =>
                {
                    b.Property<int>("IdKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdKey"), 1L, 1);

                    b.Property<string>("Alamat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BilTingkat")
                        .HasColumnType("int");

                    b.Property<string>("Kategori")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LokasiID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdKey");

                    b.HasIndex("LokasiID");

                    b.ToTable("Bangunan");
                });

            modelBuilder.Entity("TrainingKTPC20220714.Models.Lokasi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lokasi");
                });

            modelBuilder.Entity("TrainingKTPC20220714.Models.Bangunan", b =>
                {
                    b.HasOne("TrainingKTPC20220714.Models.Lokasi", null)
                        .WithMany("bangunanList")
                        .HasForeignKey("LokasiID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TrainingKTPC20220714.Models.Lokasi", b =>
                {
                    b.Navigation("bangunanList");
                });
#pragma warning restore 612, 618
        }
    }
}
