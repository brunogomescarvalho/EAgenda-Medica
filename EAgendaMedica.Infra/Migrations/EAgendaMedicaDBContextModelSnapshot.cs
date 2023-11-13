﻿// <auto-generated />
using System;
using EAgendaMedica.Infra.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EAgendaMedica.Infra.Migrations
{
    [DbContext(typeof(EAgendaMedicaDBContext))]
    partial class EAgendaMedicaDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EAgendaMedica.Dominio.ModuloConsulta.Consulta", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<long>("HoraInicio")
                        .HasColumnType("bigint");

                    b.Property<long>("HoraTermino")
                        .HasColumnType("bigint");

                    b.Property<Guid>("MedicoId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MedicoId");

                    b.ToTable("TB_Consulta", (string)null);
                });

            modelBuilder.Entity("EAgendaMedica.Dominio.ModuloMedico.Medico", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CRM")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CRM")
                        .IsUnique();

                    b.ToTable("TB_Medico", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("1ccb16b9-b816-48ea-a94a-1f19e26a51dc"),
                            CRM = "12345-SC",
                            Nome = "Médico 1"
                        },
                        new
                        {
                            Id = new Guid("2365707a-de2a-409a-905e-9ffbc77116cc"),
                            CRM = "67890-SC",
                            Nome = "Médico 2"
                        });
                });

            modelBuilder.Entity("EAgendaMedica.Dominio.ModuloConsulta.Consulta", b =>
                {
                    b.HasOne("EAgendaMedica.Dominio.ModuloMedico.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Medico");
                });
#pragma warning restore 612, 618
        }
    }
}
