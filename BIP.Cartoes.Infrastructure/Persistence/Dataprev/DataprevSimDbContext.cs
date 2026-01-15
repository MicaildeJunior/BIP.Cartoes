using BIP.Cartoes.Infrastructure.Persistence.Dataprev.Entities;
using Microsoft.EntityFrameworkCore;

namespace BIP.Cartoes.Infrastructure.Persistence.Dataprev;

public partial class DataprevSimDbContext : DbContext
{
    public DataprevSimDbContext(DbContextOptions<DataprevSimDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PessoaFisicaDataprev> PessoaFisicaDataprevs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PessoaFisicaDataprev>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PessoaFi__3214EC078F50106F");

            entity.ToTable("PessoaFisicaDataprev");

            entity.HasIndex(e => e.Cpf, "UQ__PessoaFi__C1FF9309B228353B").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Nome).HasMaxLength(200);
            entity.Property(e => e.StatusCpf)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasDefaultValueSql("(sysutcdatetime())");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
