using SistemaAluguelVeiculos.Modelos;

namespace SistemaAluguelVeiculos.Servicos;

public class Sistema
{
    private List<Cliente> clientes = new();
    private List<Veiculo> veiculos = new();
    private List<ContratoAluguel> contratos = new();

    public void CadastrarCliente(Cliente cliente) => clientes.Add(cliente);
    public void CadastrarVeiculo(Veiculo veiculo) => veiculos.Add(veiculo);

    public void RealizarAluguel(Cliente cliente, Veiculo veiculo, DateTime inicio, DateTime fim, decimal valor)
    {
        if (!veiculo.Disponivel)
        {
            Console.WriteLine("Veículo indisponível.");
            return;
        }

        var contrato = new ContratoAluguel(cliente, veiculo, inicio, fim, valor);
        contratos.Add(contrato);
        Console.WriteLine("Aluguel realizado.");
    }

    public void ListarVeiculosDisponiveis()
    {
        Console.WriteLine("\n--- Veículos Disponíveis ---");
        foreach (var v in veiculos.Where(v => v.Disponivel))
            v.ExibirInfo();
    }

    public void GerarRelatorioContratos()
    {
        Console.WriteLine("\n--- Relatório de Contratos ---");
        foreach (var c in contratos)
            Console.WriteLine(c);
    }

    public void ListarClientes()
    {
        Console.WriteLine("\n--- Lista de Clientes ---");
        foreach (var c in clientes)
            Console.WriteLine(c);
    }

    public Cliente BuscarClientePorCPF(string cpf) =>
        clientes.FirstOrDefault(c => c.CPF == cpf);

    public Veiculo BuscarVeiculoPorPlaca(string placa) =>
        veiculos.FirstOrDefault(v => v.Placa == placa);
}
