using BancoAtlantico.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BancoAtlantico.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<CaixaEletronico> CaixasEletronicos { get; set; }

        public DbSet<Cedula> Cedulas { get; set; }

        public DbSet<CedulaEstoque> CedulasEstoque { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaixaEletronico>().ToTable("TB_CAIXA_ELETRONICO");
            modelBuilder.Entity<CaixaEletronico>().HasKey(x => x.Id);
            modelBuilder.Entity<CaixaEletronico>().Property(x => x.Id).HasColumnName("ID");
            modelBuilder.Entity<CaixaEletronico>().Property(x => x.Status).HasColumnType("bit").HasColumnName("STATUS");;
            modelBuilder.Entity<CaixaEletronico>().HasMany(e => e.Cedulas).WithOne(x => x.CaixaEletronico);

            modelBuilder.Entity<Cedula>().ToTable("TB_CEDULA");
            modelBuilder.Entity<Cedula>().HasKey(x => x.Id);
            modelBuilder.Entity<Cedula>().Property(x => x.Id).HasColumnName("ID");
            modelBuilder.Entity<Cedula>().Property(x => x.Valor).HasColumnType("int").HasColumnName("VALOR");
            modelBuilder.Entity<Cedula>().HasMany(e => e.CedulasEstoque).WithOne(x => x.Cedula);

            modelBuilder.Entity<CedulaEstoque>().ToTable("TB_CEDULA_ESTOQUE");
            modelBuilder.Entity<CedulaEstoque>().HasKey(x => x.Id);
            modelBuilder.Entity<CedulaEstoque>().Property(x => x.Id).HasColumnName("ID");
            modelBuilder.Entity<CedulaEstoque>().Property(x => x.Quantidade).HasColumnType("int").HasColumnName("QUANTIDADE");
            modelBuilder.Entity<CedulaEstoque>().HasOne(x => x.Cedula).WithMany(x => x.CedulasEstoque).HasForeignKey("CEDULA_ID");
            modelBuilder.Entity<CedulaEstoque>().HasOne(x => x.CaixaEletronico).WithMany(x => x.Cedulas).HasForeignKey("CAIXA_ELETRONICO_ID");
        }
    }
}
