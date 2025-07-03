using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAluguelVeiculos.Modelos;

[Table("Contratos")]
public class ContratoAluguel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [ForeignKey("Cliente")]
    public string? ClienteCPF { get; set; }

    [Required]
    [ForeignKey("Veiculo")]
    public string? VeiculoPlaca { get; set; }

    [Required]
    public DateTime DataInicio { get; set; }

    [Required]
    public DateTime DataFim { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal ValorTotal { get; set; }
    public Cliente? Cliente { get; set; }
    public Veiculo? Veiculo { get; set; }

    public ContratoAluguel() { }
        public override string ToString() =>
    $"Contrato #{Id}: {Cliente?.Nome} alugou {Veiculo?.Modelo} " +
    $"({DataInicio:dd/MM/yyyy} a {DataFim:dd/MM/yyyy}) " +
    $"| Valor: R${ValorTotal:F2}";
}