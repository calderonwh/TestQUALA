using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackendSucursales.Entities;

public partial class DbaQualaContext : DbContext
{
    public DbaQualaContext()
    {
    }

    public DbaQualaContext(DbContextOptions<DbaQualaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Moneda> Monedas { get; set; }

    public virtual DbSet<Sucursale> Sucursales { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Moneda>(entity =>
        {
            entity.HasKey(e => e.IdMoneda).HasName("PK__Monedas__AA690671848E3E3F");

            entity.ToTable("MonedasTest");

            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Simbolo).HasMaxLength(10);
        });

        modelBuilder.Entity<Sucursale>(entity =>
        {
            entity.HasKey(e => e.IdSucursal).HasName("PK__Sucursal__BFB6CD997B44E189");

            entity.ToTable("SucursalesTest");

            entity.Property(e => e.Descripcion).HasMaxLength(250);
            entity.Property(e => e.Direccion).HasMaxLength(250);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Identificacion).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
