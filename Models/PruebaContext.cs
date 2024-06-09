using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SistemaAviacionCivil.Models;

public partial class PruebaContext : DbContext
{
    public PruebaContext()
    {
    }

    public PruebaContext(DbContextOptions<PruebaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aeronave> Aeronaves { get; set; }

    public virtual DbSet<Aeropuerto> Aeropuertos { get; set; }

    public virtual DbSet<Hangar> Hangars { get; set; }

    public virtual DbSet<Piloto> Pilotos { get; set; }

    public virtual DbSet<ProgramaVuelo> ProgramaVuelos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local);Database=AviacionCivil;User Id=sa;Password=As86314575;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aeronave>(entity =>
        {
            entity.HasKey(e => e.IdAvion).HasName("PK__aeronave__66D8A4F38D3C383C");

            entity.ToTable("aeronave");

            entity.Property(e => e.IdAvion)
                .ValueGeneratedNever()
                .HasColumnName("id_avion");
            entity.Property(e => e.CapacidadPasajeros)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("capacidad_pasajeros");
            entity.Property(e => e.HorasVuelos)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("horas_vuelos");
            entity.Property(e => e.IdPiloto).HasColumnName("id_piloto");
            entity.Property(e => e.Modelo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("modelo");

            entity.HasOne(d => d.IdPilotoNavigation).WithMany(p => p.Aeronaves)
                .HasForeignKey(d => d.IdPiloto)
                .HasConstraintName("FK__aeronave__id_pil__619B8048");
        });

        modelBuilder.Entity<Aeropuerto>(entity =>
        {
            entity.HasKey(e => e.IdAeropuerto).HasName("PK__aeropuer__207E2F0373D695A9");

            entity.ToTable("aeropuerto");

            entity.Property(e => e.IdAeropuerto)
                .ValueGeneratedNever()
                .HasColumnName("id_aeropuerto");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ciudad");
            entity.Property(e => e.IdAvion).HasColumnName("id_avion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.NumHangares)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("num_Hangares");
            entity.Property(e => e.Pais)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pais");

            entity.HasOne(d => d.IdAvionNavigation).WithMany(p => p.Aeropuertos)
                .HasForeignKey(d => d.IdAvion)
                .HasConstraintName("FK__aeropuert__id_av__66603565");
        });

        modelBuilder.Entity<Hangar>(entity =>
        {
            entity.HasKey(e => e.IdHangar).HasName("PK__hangar__243A14E2B9B3ED03");

            entity.ToTable("hangar");

            entity.Property(e => e.IdHangar)
                .ValueGeneratedNever()
                .HasColumnName("id_hangar");
            entity.Property(e => e.CapacidadAeronaves)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("capacidad_Aeronaves");
            entity.Property(e => e.IdAeropuerto).HasColumnName("id_aeropuerto");
            entity.Property(e => e.TipoAeronaves)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_Aeronaves");

            entity.HasOne(d => d.IdAeropuertoNavigation).WithMany(p => p.Hangars)
                .HasForeignKey(d => d.IdAeropuerto)
                .HasConstraintName("FK__hangar__id_aerop__49C3F6B7");
        });

        modelBuilder.Entity<Piloto>(entity =>
        {
            entity.HasKey(e => e.IdPiloto).HasName("PK__pilotos__93ED523537962A85");

            entity.ToTable("pilotos");

            entity.Property(e => e.IdPiloto)
                .ValueGeneratedNever()
                .HasColumnName("id_piloto");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.FechaEmisLicen)
                .HasColumnType("datetime")
                .HasColumnName("fecha_emis_licen");
            entity.Property(e => e.FechaNac)
                .HasColumnType("datetime")
                .HasColumnName("fecha_nac");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.TipoLicencia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_licencia");
        });

        modelBuilder.Entity<ProgramaVuelo>(entity =>
        {
            entity.HasKey(e => e.IdVuelo).HasName("PK__programa__CA179BA225D44E4C");

            entity.ToTable("programa_vuelos");

            entity.Property(e => e.IdVuelo)
                .ValueGeneratedNever()
                .HasColumnName("id_vuelo");
            entity.Property(e => e.FechaSalida)
                .HasColumnType("datetime")
                .HasColumnName("fecha_Salida");
            entity.Property(e => e.HoraSalida)
                .HasColumnType("datetime")
                .HasColumnName("hora_Salida");
            entity.Property(e => e.IdAvion).HasColumnName("id_avion");
            entity.Property(e => e.IdPiloto).HasColumnName("id_piloto");
            entity.Property(e => e.LugarDestino)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lugar_Destino");
            entity.Property(e => e.LugarPartida)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lugar_Partida");
            entity.Property(e => e.TipoVuelo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_Vuelo");

            entity.HasOne(d => d.IdAvionNavigation).WithMany(p => p.ProgramaVuelos)
                .HasForeignKey(d => d.IdAvion)
                .HasConstraintName("FK__programa___id_av__656C112C");

            entity.HasOne(d => d.IdPilotoNavigation).WithMany(p => p.ProgramaVuelos)
                .HasForeignKey(d => d.IdPiloto)
                .HasConstraintName("FK__programa___id_pi__6477ECF3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
