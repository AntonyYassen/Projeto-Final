using Microsoft.EntityFrameworkCore;
using SistemaAluguelVeiculos.Modelos;

namespace SistemaAluguelVeiculos.Data;

public class AppDbContext : DbContext
{
    public DbSet<Veiculo> Veiculos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<ContratoAluguel> Contratos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=aluguel_veiculos.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuração da herança (TPH - Tabela única para Veiculo/Carro/Moto)
        modelBuilder.Entity<Veiculo>()
            .HasDiscriminator<string>("TipoVeiculo")
            .HasValue<Carro>("Carro")
            .HasValue<Moto>("Moto");

        // Configuração do Cliente
        modelBuilder.Entity<Cliente>(e => 
        {
            e.HasKey(c => c.CPF);
            e.Property(c => c.Nome).IsRequired().HasMaxLength(100);
            e.Property(c => c.Telefone).IsRequired().HasMaxLength(20);
        });

        // Configuração do Contrato
        modelBuilder.Entity<ContratoAluguel>(e => 
        {
            e.HasKey(c => c.Id);
            e.HasOne(c => c.Cliente).WithMany().HasForeignKey(c => c.ClienteCPF);
            e.HasOne(c => c.Veiculo).WithMany().HasForeignKey(c => c.VeiculoPlaca);
        });
    }
}