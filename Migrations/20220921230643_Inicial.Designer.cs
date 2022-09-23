﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace PeluqueriaStar.Migrations
{
    [DbContext(typeof(PeluqueriaPagesPersonaContext))]
    [Migration("20220921230643_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PeluqueriaStar.Models.HorarioEstelista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Disponibilidad")
                        .HasColumnType("bit");

                    b.Property<int?>("EstelistaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Horario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EstelistaId");

                    b.ToTable("HorarioEstelista");
                });

            modelBuilder.Entity("PeluqueriaStar.Models.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Celular")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EstadoSalud")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persona");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("PeluqueriaStar.Models.ServiciosOfrecer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EstelistaId")
                        .HasColumnType("int");

                    b.Property<int>("ValorAplicarDescuento")
                        .HasColumnType("int");

                    b.Property<int>("ValorServicio")
                        .HasColumnType("int");

                    b.Property<int>("ValorTotalServicio")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstelistaId");

                    b.ToTable("ServiciosOfrecer");
                });

            modelBuilder.Entity("PeluqueriaStar.Models.Administrador", b =>
                {
                    b.HasBaseType("PeluqueriaStar.Models.Persona");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int?>("EstelistaId")
                        .HasColumnType("int")
                        .HasColumnName("Administrador_EstelistaId");

                    b.Property<int?>("HorarioEstelistaId")
                        .HasColumnType("int")
                        .HasColumnName("Administrador_HorarioEstelistaId");

                    b.Property<int?>("ServiciosOfrecerId")
                        .HasColumnType("int")
                        .HasColumnName("Administrador_ServiciosOfrecerId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EstelistaId");

                    b.HasIndex("HorarioEstelistaId");

                    b.HasIndex("ServiciosOfrecerId");

                    b.HasDiscriminator().HasValue("Administrador");
                });

            modelBuilder.Entity("PeluqueriaStar.Models.Cliente", b =>
                {
                    b.HasBaseType("PeluqueriaStar.Models.Persona");

                    b.Property<int>("CantidadCitas")
                        .HasColumnType("int");

                    b.Property<string>("Dirrecion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<int?>("EstelistaId")
                        .HasColumnType("int");

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<int?>("HorarioEstelistaId")
                        .HasColumnType("int");

                    b.Property<bool>("Membresia")
                        .HasColumnType("bit");

                    b.Property<int?>("ServiciosOfrecerId")
                        .HasColumnType("int");

                    b.HasIndex("EstelistaId");

                    b.HasIndex("HorarioEstelistaId");

                    b.HasIndex("ServiciosOfrecerId");

                    b.HasDiscriminator().HasValue("Cliente");
                });

            modelBuilder.Entity("PeluqueriaStar.Models.Estelista", b =>
                {
                    b.HasBaseType("PeluqueriaStar.Models.Persona");

                    b.Property<string>("TarjetaProfesional")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Estelista");
                });

            modelBuilder.Entity("PeluqueriaStar.Models.HorarioEstelista", b =>
                {
                    b.HasOne("PeluqueriaStar.Models.Estelista", null)
                        .WithMany("HorarioEstelista")
                        .HasForeignKey("EstelistaId");
                });

            modelBuilder.Entity("PeluqueriaStar.Models.ServiciosOfrecer", b =>
                {
                    b.HasOne("PeluqueriaStar.Models.Estelista", null)
                        .WithMany("ServiciosOfrecer")
                        .HasForeignKey("EstelistaId");
                });

            modelBuilder.Entity("PeluqueriaStar.Models.Administrador", b =>
                {
                    b.HasOne("PeluqueriaStar.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("PeluqueriaStar.Models.Estelista", "Estelista")
                        .WithMany()
                        .HasForeignKey("EstelistaId");

                    b.HasOne("PeluqueriaStar.Models.HorarioEstelista", "HorarioEstelista")
                        .WithMany()
                        .HasForeignKey("HorarioEstelistaId");

                    b.HasOne("PeluqueriaStar.Models.ServiciosOfrecer", "ServiciosOfrecer")
                        .WithMany()
                        .HasForeignKey("ServiciosOfrecerId");

                    b.Navigation("Cliente");

                    b.Navigation("Estelista");

                    b.Navigation("HorarioEstelista");

                    b.Navigation("ServiciosOfrecer");
                });

            modelBuilder.Entity("PeluqueriaStar.Models.Cliente", b =>
                {
                    b.HasOne("PeluqueriaStar.Models.Estelista", "Estelista")
                        .WithMany()
                        .HasForeignKey("EstelistaId");

                    b.HasOne("PeluqueriaStar.Models.HorarioEstelista", "HorarioEstelista")
                        .WithMany()
                        .HasForeignKey("HorarioEstelistaId");

                    b.HasOne("PeluqueriaStar.Models.ServiciosOfrecer", "ServiciosOfrecer")
                        .WithMany()
                        .HasForeignKey("ServiciosOfrecerId");

                    b.Navigation("Estelista");

                    b.Navigation("HorarioEstelista");

                    b.Navigation("ServiciosOfrecer");
                });

            modelBuilder.Entity("PeluqueriaStar.Models.Estelista", b =>
                {
                    b.Navigation("HorarioEstelista");

                    b.Navigation("ServiciosOfrecer");
                });
#pragma warning restore 612, 618
        }
    }
}