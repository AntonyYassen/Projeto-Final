using SistemaAluguelVeiculos.Modelos;

namespace SistemaAluguelVeiculos.Servicos;

public class Sistema
{
    private List<Cliente> clientes = new();
    private List<Veiculo> veiculos = new();
    private List<ContratoAluguel> contratos = new();

    public void CadastrarCliente(Cliente cliente)
    {
        if (cliente == null)
            throw new ArgumentNullException(nameof(cliente));

        clientes.Add(cliente);
    }

    public void CadastrarVeiculo(Veiculo veiculo)
    {
        if (veiculo == null)
            throw new ArgumentNullException(nameof(veiculo));

        veiculos.Add(veiculo);
    }

    public void RealizarAluguel(Cliente cliente, Veiculo veiculo, DateTime inicio, DateTime fim, decimal valor)
    {
        if (!veiculo.Disponivel)
        {
            Console.WriteLine("Veículo indisponível para aluguel.");
            return;
        }

        var contrato = new ContratoAluguel(cliente, veiculo, inicio, fim, valor);
        contratos.Add(contrato);
        Console.WriteLine("Aluguel realizado com sucesso!");
    }

    public void ListarVeiculosDisponiveis()
    {
        Console.WriteLine("\n--- Veículos Disponíveis ---");
        foreach (var v in veiculos.Where(v => v.Disponivel))
        {
            v.ExibirInfo();
        }
    }

    public void GerarRelatorioContratos()
    {
        Console.WriteLine("\n--- Relatório de Contratos ---");
        foreach (var contrato in contratos)
        {
            Console.WriteLine(contrato);
        }
    }

    public void ListarClientes()
    {
        Console.WriteLine("\n--- Lista de Clientes ---");
        foreach (var c in clientes)
        {
            Console.WriteLine(c);
        }
    }
}
