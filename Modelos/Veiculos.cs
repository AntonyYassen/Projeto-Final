using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAluguelVeiculos.Modelos;

[Table("Veiculos")] // Todas as subclasses usarão a mesma tabela
public abstract class Veiculo
{
    [Key]
    [StringLength(7)]
    public string? Placa { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Modelo { get; set; }

    [Required]
    public int Ano { get; set; }

    public bool Disponivel { get; set; } = true;

    public Veiculo() { }

    public Veiculo(string placa, string modelo, int ano)
    {
        Placa = placa;
        Modelo = modelo;
        Ano = ano;
    }

    public virtual void ExibirInfo()
    {
        Console.WriteLine($"{Modelo} - {Placa} ({Ano}) - {(Disponivel ? "Disponível" : "Alugado")}");
    }
}