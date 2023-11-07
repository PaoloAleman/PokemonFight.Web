using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PokemonFight.Web.EF;

public partial class PokemonFightContext : DbContext
{
    public PokemonFightContext()
    {
    }

    public PokemonFightContext(DbContextOptions<PokemonFightContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ataque> Ataques { get; set; }

    public virtual DbSet<AtaquePokemon> AtaquePokemons { get; set; }

    public virtual DbSet<Pokemon> Pokemons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=PokemonFight;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ataque>(entity =>
        {
            entity.ToTable("Ataque");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Daño).HasColumnName("daño");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<AtaquePokemon>(entity =>
        {
            entity.ToTable("AtaquePokemon");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdAtaque).HasColumnName("idAtaque");
            entity.Property(e => e.IdPokemon).HasColumnName("idPokemon");

            entity.HasOne(d => d.IdAtaqueNavigation).WithMany(p => p.AtaquePokemons)
                .HasForeignKey(d => d.IdAtaque)
                .HasConstraintName("FK_AtaquePokemon_Ataque");

            entity.HasOne(d => d.IdPokemonNavigation).WithMany(p => p.AtaquePokemons)
                .HasForeignKey(d => d.IdPokemon)
                .HasConstraintName("FK_AtaquePokemon_Pokemon");
        });

        modelBuilder.Entity<Pokemon>(entity =>
        {
            entity.ToTable("Pokemon");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Imagen)
                .HasMaxLength(50)
                .HasColumnName("imagen");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .HasColumnName("tipo");
            entity.Property(e => e.Vida).HasColumnName("vida");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
