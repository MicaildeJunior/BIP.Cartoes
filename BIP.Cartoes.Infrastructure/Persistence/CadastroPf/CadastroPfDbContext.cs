using BIP.Cartoes.Infrastructure.Persistence.CadastroPf.Entities;
using Microsoft.EntityFrameworkCore;

namespace BIP.Cartoes.Infrastructure.Persistence.CadastroPf;

public partial class CadastroPfDbContext : DbContext
{
    public CadastroPfDbContext(DbContextOptions<CadastroPfDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CartaoCredito> CartaoCreditos { get; set; }

    public virtual DbSet<ClientePf> ClientePfs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CartaoCredito>(entity =>
        {
            entity.ToTable("CartaoCredito");

            entity.HasIndex(e => e.ClientePfId, "IX_CartaoCredito_ClientePfId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Bandeira)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Limite).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.NumeroMascarado)
                .HasMaxLength(19)
                .IsUnicode(false);
            entity.Property(e => e.StatusCartao)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("ATIVO");
            entity.Property(e => e.Ultimos4)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.ClientePf).WithMany(p => p.CartaoCreditos)
                .HasForeignKey(d => d.ClientePfId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CartaoCredito_ClientePf");
        });

        modelBuilder.Entity<ClientePf>(entity =>
        {
            entity.ToTable("ClientePf");

            entity.HasIndex(e => e.Cpf, "UQ_ClientePf_Cpf").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Celular).HasMaxLength(20);
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.Nome).HasMaxLength(200);
            entity.Property(e => e.Profissao).HasMaxLength(120);
            entity.Property(e => e.RendaMensal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.StatusCadastro)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("ATIVO");
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysutcdatetime())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
