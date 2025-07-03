using SistemaAluguelVeiculos.Modelos;
using SistemaAluguelVeiculos.Servicos;
using System;
using System.Globalization;

namespace SistemaAluguelVeiculos.Servicos;

public class MenuPrincipal
{
    private readonly Sistema _sistema;

    public MenuPrincipal(Sistema sistema) => _sistema = sistema;

    public void ExibirMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== SISTEMA DE ALUGUEL DE VEÍCULOS ===");
            Console.WriteLine("\n1. Cadastrar Veículo");
            Console.WriteLine("2. Cadastrar Cliente");
            Console.WriteLine("3. Realizar Aluguel");
            Console.WriteLine("4. Listar Veículos Disponíveis");
            Console.WriteLine("5. Listar Clientes");
            Console.WriteLine("6. Relatório de Contratos");
            Console.WriteLine("0. Sair");
            Console.Write("\nOpção: ");

            try
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        CadastrarVeiculo();
                        break;
                    case "2":
                        CadastrarCliente();
                        break;
                    case "3":
                        RealizarAluguel();
                        break;
                    case "4":
                        ListarVeiculosDisponiveis();
                        break;
                    case "5":
                        ListarClientes();
                        break;
                    case "6":
                        GerarRelatorioContratos();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    private void CadastrarVeiculo()
    {
        Console.Clear();
        Console.WriteLine("=== CADASTRAR VEÍCULO ===\n");
        
        Console.Write("Tipo (1-Carro / 2-Moto): ");
        var tipo = Console.ReadLine();

        Console.Write("Placa: ");
        var placa = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(placa))
            throw new ArgumentException("Placa não pode ser vazia!");

        Console.Write("Modelo: ");
        var modelo = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(modelo))
            throw new ArgumentException("Modelo não pode ser vazio!");

        Console.Write("Ano: ");
        var anoInput = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(anoInput))
            throw new ArgumentException("Ano não pode ser vazio!");
        var ano = int.Parse(anoInput);

        Veiculo veiculo = tipo switch
        {
            "1" => new Carro(placa, modelo, ano, LerInt("Quantidade de portas: ")),
            "2" => new Moto(placa, modelo, ano, LerInt("Cilindradas: ")),
            _ => throw new ArgumentException("Tipo inválido!")
        };

        _sistema.CadastrarVeiculo(veiculo);
        Console.WriteLine("\nVeículo cadastrado com sucesso!");
    }

    private void CadastrarCliente()
    {
        Console.Clear();
        Console.WriteLine("=== CADASTRAR CLIENTE ===\n");
        
        Console.Write("Nome: ");
        var nome = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome não pode ser vazio!");

        Console.Write("CPF: ");
        var cpf = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(cpf))
            throw new ArgumentException("CPF não pode ser vazio!");

        Console.Write("Telefone: ");
        var telefone = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(telefone))
            throw new ArgumentException("Telefone não pode ser vazio!");

        _sistema.CadastrarCliente(new Cliente(nome, cpf, telefone));
        Console.WriteLine("\nCliente cadastrado com sucesso!");
    }

    private void RealizarAluguel()
    {
        Console.Clear();
        Console.WriteLine("=== REALIZAR ALUGUEL ===\n");
        
        _sistema.ListarClientes();
        Console.Write("\nCPF do cliente: ");
        var cpfInput = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(cpfInput))
            throw new ArgumentException("CPF não pode ser vazio!");
        var cliente = _sistema.BuscarClientePorCpf(cpfInput);
        if (cliente == null)
            throw new Exception("Cliente não encontrado!");

        _sistema.ListarVeiculosDisponiveis();
        Console.Write("\nPlaca do veículo: ");
        var placaInput = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(placaInput))
            throw new ArgumentException("Placa não pode ser vazia!");
        var veiculo = _sistema.BuscarVeiculoPorPlaca(placaInput);
        if (veiculo == null)
            throw new Exception("Veículo não encontrado ou indisponível!");

        Console.Write("Data de início (dd/mm/aaaa): ");
        var inicioInput = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(inicioInput))
            throw new ArgumentException("Data de início não pode ser vazia!");
        var inicio = DateTime.ParseExact(inicioInput, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        Console.Write("Data de fim (dd/mm/aaaa): ");
        var fimInput = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(fimInput))
            throw new ArgumentException("Data de fim não pode ser vazia!");
        var fim = DateTime.ParseExact(fimInput, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        Console.Write("Valor total: R$");
        var valorInput = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(valorInput))
            throw new ArgumentException("Valor total não pode ser vazio!");
        var valor = decimal.Parse(valorInput);

        _sistema.RealizarAluguel(cliente, veiculo, inicio, fim, valor);
        Console.WriteLine("\nAluguel registrado com sucesso!");
    }

    private void ListarVeiculosDisponiveis()
    {
        Console.Clear();
        Console.WriteLine("=== VEÍCULOS DISPONÍVEIS ===\n");
        _sistema.ListarVeiculosDisponiveis();
    }

    private void ListarClientes()
    {
        Console.Clear();
        Console.WriteLine("=== CLIENTES CADASTRADOS ===\n");
        _sistema.ListarClientes();
    }

    private void GerarRelatorioContratos()
    {
        Console.Clear();
        Console.WriteLine("=== RELATÓRIO DE CONTRATOS ===\n");
        _sistema.GerarRelatorioContratos();
    }

    private static int LerInt(string prompt)
    {
        Console.Write(prompt);
        var input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException("Entrada não pode ser vazia!");
        return int.Parse(input);
    }
}