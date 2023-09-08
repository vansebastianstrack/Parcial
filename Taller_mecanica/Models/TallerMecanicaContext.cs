using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Taller_mecanica.Models;

public partial class TallerMecanicaContext : DbContext
{
    public TallerMecanicaContext()
    {
    }

    public TallerMecanicaContext(DbContextOptions<TallerMecanicaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auto> Autos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Mecanico> Mecanicos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-HGR4UJM\\SQLEXPRESS; Database=Taller_Mecanica; Trusted_Connection=True; TrustServerCertificate=true ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auto>(entity =>
        {
            entity.HasKey(e => e.IdAuto);

            entity.ToTable("Auto");

            entity.Property(e => e.IdAuto).HasColumnName("Id_auto");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente);

            entity.ToTable("cliente");

            entity.Property(e => e.IdCliente).HasColumnName("Id_cliente");
            entity.Property(e => e.DocuCli)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Docu_cli");
            entity.Property(e => e.NomCli)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nom_cli");
        });

        modelBuilder.Entity<Mecanico>(entity =>
        {
            entity.HasKey(e => e.IdMecanico);

            entity.ToTable("Mecanico");

            entity.Property(e => e.IdMecanico).HasColumnName("Id_mecanico");
            entity.Property(e => e.DocuMeca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("docu_meca");
            entity.Property(e => e.NomMecanico)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nom_mecanico");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
