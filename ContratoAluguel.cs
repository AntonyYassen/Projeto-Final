namespace SistemaAluguelVeiculos.Modelos;

public class ContratoAluguel
{
    public Cliente Cliente { get; }
    public Veiculo Veiculo { get; }
    public DateTime DataInicio { get; }
    public DateTime DataFim { get; }
    public decimal ValorTotal { get; }

    public ContratoAluguel(Cliente cliente, Veiculo veiculo, DateTime dataInicio, DateTime dataFim, decimal valorTotal)
    {
        if (dataFim <= dataInicio)
            throw new ArgumentException("A data de fim deve ser posterior à data de início.");

        Cliente = cliente ?? throw new ArgumentNullException(nameof(cliente));
        Veiculo = veiculo ?? throw new ArgumentNullException(nameof(veiculo));
        DataInicio = dataInicio;
        DataFim = dataFim;
        ValorTotal = valorTotal;

        // Marca veículo como indisponível
        Veiculo.Disponivel = false;
    }

    public override string ToString()
    {
        return $"Contrato: {Cliente.Nome} alugou {Veiculo.Modelo} de {DataInicio:dd/MM/yyyy} até {DataFim:dd/MM/yyyy} - Valor: R${ValorTotal:F2}";
    }
}
