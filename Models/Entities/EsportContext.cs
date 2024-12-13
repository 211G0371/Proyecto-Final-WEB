using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace ProyectoFinal.Models.Entities;

public partial class EsportContext : DbContext
{
    public EsportContext()
    {
    }

    public EsportContext(DbContextOptions<EsportContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Equipo> Equipo { get; set; }

    public virtual DbSet<Estadisticas> Estadisticas { get; set; }

    public virtual DbSet<Jugadores> Jugadores { get; set; }

    public virtual DbSet<Sliders> Sliders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=root;database=esport", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.40-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Equipo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("equipo");

            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Pais).HasMaxLength(45);
        });

        modelBuilder.Entity<Estadisticas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("estadisticas");

            entity.HasIndex(e => e.IdJugador, "JugadorEstaditicas_idx");

            entity.Property(e => e.Earnings).HasMaxLength(45);
            entity.Property(e => e.Headshot).HasMaxLength(45);
            entity.Property(e => e.KDRatio)
                .HasMaxLength(45)
                .HasColumnName("K/D Ratio");
            entity.Property(e => e.Lose).HasMaxLength(45);
            entity.Property(e => e.Winrate).HasMaxLength(45);
            entity.Property(e => e.Wins).HasMaxLength(45);

            entity.HasOne(d => d.IdJugadorNavigation).WithMany(p => p.Estadisticas)
                .HasForeignKey(d => d.IdJugador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("JugadorEstaditicas");
        });

        modelBuilder.Entity<Jugadores>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("jugadores");

            entity.Property(e => e.Gamertag).HasMaxLength(45);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Pais).HasMaxLength(45);
            entity.Property(e => e.Rol).HasMaxLength(45);
        });

        modelBuilder.Entity<Sliders>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sliders");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NombreDelSlider).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
