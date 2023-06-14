﻿// <auto-generated />
using System;
using AgendaOn.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AgendaOn.Infra.Data.Migrations
{
    [DbContext(typeof(AgendaOnContext))]
    partial class AgendaOnContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.13");

            modelBuilder.Entity("AgendaOn.Domain.Entities.Administrador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_ADMINISTRADOR");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_USUARIO");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("TB_ADMINISTRADOR", (string)null);
                });

            modelBuilder.Entity("AgendaOn.Domain.Entities.Agendamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_AGENDAMENTO");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_CLIENTE");

                    b.Property<DateTime>("DataAgendamento")
                        .HasColumnType("TEXT")
                        .HasColumnName("DT_AGENDAMENTO");

                    b.Property<DateTime?>("DataCancelamento")
                        .HasColumnType("TEXT")
                        .HasColumnName("DT_CANCELAMENTO");

                    b.Property<int>("HorarioId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_HORARIO");

                    b.Property<int>("PrestadorId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_PRESTADOR");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("HorarioId");

                    b.HasIndex("PrestadorId");

                    b.ToTable("TB_AGENDAMENTO", (string)null);
                });

            modelBuilder.Entity("AgendaOn.Domain.Entities.Avaliacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_AVALIACAO");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_CLIENTE");

                    b.Property<string>("DescAvaliacao")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("DESC_AVALIACAO");

                    b.Property<int>("Nota")
                        .HasColumnType("INTEGER")
                        .HasColumnName("NOTA");

                    b.Property<int>("PerfilId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_PERFIL");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("PerfilId");

                    b.ToTable("TB_AVALIACAO", (string)null);
                });

            modelBuilder.Entity("AgendaOn.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_CLIENTE");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_USUARIO");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("TB_CLIENTE", (string)null);
                });

            modelBuilder.Entity("AgendaOn.Domain.Entities.Foto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_FOTO");

                    b.Property<string>("Path")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("PATH");

                    b.Property<int>("PerfilId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_PERFIL");

                    b.HasKey("Id");

                    b.HasIndex("PerfilId");

                    b.ToTable("TB_FOTO", (string)null);
                });

            modelBuilder.Entity("AgendaOn.Domain.Entities.Horario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_HORARIO");

                    b.Property<TimeOnly>("HoraFim")
                        .HasColumnType("TEXT")
                        .HasColumnName("HORA_FIM");

                    b.Property<TimeOnly>("HoraInicio")
                        .HasColumnType("TEXT")
                        .HasColumnName("HORA_INICIO");

                    b.Property<int>("PrestadorId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_PRESTADOR");

                    b.HasKey("Id");

                    b.HasIndex("PrestadorId");

                    b.ToTable("TB_HORARIO", (string)null);
                });

            modelBuilder.Entity("AgendaOn.Domain.Entities.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_PERFIL");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("DESCRICAO");

                    b.Property<int>("PrestadorId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_PRESTADOR");

                    b.HasKey("Id");

                    b.HasIndex("PrestadorId")
                        .IsUnique();

                    b.ToTable("TB_PERFIL", (string)null);
                });

            modelBuilder.Entity("AgendaOn.Domain.Entities.Prestador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_PRESTADOR");

                    b.Property<decimal>("Preco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValue(100m)
                        .HasColumnName("PRECO");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_USUARIO");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("TB_PRESTADOR", (string)null);
                });

            modelBuilder.Entity("AgendaOn.Domain.Entities.RedeSocial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_REDE_SOCIAL");

                    b.Property<string>("Link")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("LINK");

                    b.Property<int>("PerfilId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_PERFIL");

                    b.Property<string>("Rede")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("NOME_REDE");

                    b.HasKey("Id");

                    b.HasIndex("PerfilId");

                    b.ToTable("TB_REDE_SOCIAL", (string)null);
                });

            modelBuilder.Entity("AgendaOn.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("ID_USUARIO");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("TEXT")
                        .HasColumnName("EMAIL");

                    b.Property<string>("IdIdentity")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("ID_IDENTITY");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("TEXT")
                        .HasColumnName("NOME");

                    b.HasKey("Id");

                    b.HasIndex("IdIdentity")
                        .IsUnique();

                    b.ToTable("TB_USUARIO", (string)null);
                });

            modelBuilder.Entity("AgendaOn.Domain.Entities.Administrador", b =>
                {
                    b.HasOne("AgendaOn.Domain.Entities.Usuario", "Usuario")
                        .WithOne("Administrador")
                        .HasForeignKey("AgendaOn.Domain.Entities.Administrador", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("AgendaOn.Domain.Entities.Agendamento", b =>
                {
                    b.HasOne("AgendaOn.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Agendamentos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AgendaOn.Domain.Entities.Horario", "Horario")
                        .WithMany("Agendamentos")
                        .HasForeignKey("HorarioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AgendaOn.Domain.Entities.Prestador", "Prestador")
                        .WithMany("Agendamentos")
                        .HasForeignKey("PrestadorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Horario");

                    b.Navigation("Prestador");
                });

            modelBuilder.Entity("AgendaOn.Domain.Entities.Avaliacao", b =>
                {
                    b.HasOne("AgendaOn.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("AgendaOn.Domain.Entities.Perfil", "Perfil")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("AgendaOn.Domain.Entities.Cliente", b =>
                {
                    b.HasOne("AgendaOn.Domain.Entities.Usuario", "Usuario")
                        .WithOne("Cliente")
                        .HasForeignKey("AgendaOn.Domain.Entities.Cliente", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("AgendaOn.Domain.Entities.Foto", b =>
                {
                    b.HasOne("AgendaOn.Domain.Entities.Perfil", "Perfil")
                        .WithMany("Fotos")
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("AgendaOn.Domain.Entities.Horario", b =>
                {
                    b.HasOne("AgendaOn.Domain.Entities.Prestador", "Prestador")
                        .WithMany("Horarios")
                        .HasForeignKey("PrestadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prestador");
                });

            modelBuilder.Entity("AgendaOn.Domain.Entities.Perfil", b =>
                {
                    b.HasOne("AgendaOn.Domain.Entities.Prestador", "Prestador")
                        .WithOne("Perfil")
                        .HasForeignKey("AgendaOn.Domain.Entities.Perfil", "PrestadorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Prestador");
                });

            modelBuilder.Entity("AgendaOn.Domain.Entities.Prestador", b =>
                {
                    b.HasOne("AgendaOn.Domain.Entities.Usuario", "Usuario")
                        .WithOne("Prestador")
                        .HasForeignKey("AgendaOn.Domain.Entities.Prestador", "UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("AgendaOn.Domain.Entities.RedeSocial", b =>
                {
                    b.HasOne("AgendaOn.Domain.Entities.Perfil", "Perfil")
                        .WithMany("RedeSociais")
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Perfil");
                });

            modelBuilder.Entity("AgendaOn.Domain.Entities.Cliente", b =>
                {
                    b.Navigation("Agendamentos");

                    b.Navigation("Avaliacoes");
                });

            modelBuilder.Entity("AgendaOn.Domain.Entities.Horario", b =>
                {
                    b.Navigation("Agendamentos");
                });

            modelBuilder.Entity("AgendaOn.Domain.Entities.Perfil", b =>
                {
                    b.Navigation("Avaliacoes");

                    b.Navigation("Fotos");

                    b.Navigation("RedeSociais");
                });

            modelBuilder.Entity("AgendaOn.Domain.Entities.Prestador", b =>
                {
                    b.Navigation("Agendamentos");

                    b.Navigation("Horarios");

                    b.Navigation("Perfil")
                        .IsRequired();
                });

            modelBuilder.Entity("AgendaOn.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Administrador");

                    b.Navigation("Cliente");

                    b.Navigation("Prestador");
                });
#pragma warning restore 612, 618
        }
    }
}
