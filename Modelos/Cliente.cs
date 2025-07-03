using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaAluguelVeiculos.Modelos;

[Table("Clientes")]
public class Cliente
{
    [Key]
    [StringLength(11)]
    public string? CPF { get; set; }

    [Required]
    [MaxLength(100)]
    public string? Nome { get; set; }

    [Required]
    [MaxLength(20)]
    public string? Telefone { get; set; }

    public Cliente() { }

    public Cliente(string nome, string cpf, string telefone)
    {
        Nome = nome;
        CPF = cpf;
        Telefone = telefone;
    }

    public override string ToString() => $"{Nome} - CPF: {CPF} | Tel: {Telefone}";
}