using SistemaAluguelVeiculos.Modelos;
using SistemaAluguelVeiculos.Servicos;

namespace SistemaAluguelVeiculos
{
    class Program
    {
        static void Main()
        {
            var sistema = new Sistema();
            bool sair = false;

            while (!sair)
            {
                Console.WriteLine("\n1. Cadastrar Cliente\n2. Cadastrar Veículo\n3. Listar Veículos\n4. Listar Clientes\n5. Realizar Aluguel\n6. Relatório\n7. Sair");
                Console.Write("Opção: ");
                switch (Console.ReadLine())
                {
                    case "1": CadastrarCliente(sistema); break;
                    case "2": CadastrarVeiculo(sistema); break;
                    case "3": sistema.ListarVeiculosDisponiveis(); break;
                    case "4": sistema.ListarClientes(); break;
                    case "5": RealizarAluguel(sistema); break;
                    case "6": sistema.GerarRelatorioContratos(); break;
                    case "7": sair = true; break;
                    default: Console.WriteLine("Opção inválida."); break;
                }
            }
        }

        static void CadastrarCliente(Sistema s)
        {
            var nome = Ler("Nome");
            var cpf = Ler("CPF");
            var tel = Ler("Telefone");
            s.CadastrarCliente(new Cliente(nome, cpf, tel));
            Console.WriteLine("Cliente cadastrado.");
        }

        static void CadastrarVeiculo(Sistema s)
        {
            var tipo = Ler("Tipo (1-Carro, 2-Moto)");
            var placa = Ler("Placa");
            var modelo = Ler("Modelo");
            int.TryParse(Ler("Ano"), out int ano);

            if (tipo == "1")
            {
                int.TryParse(Ler("Qtd portas"), out int portas);
                s.CadastrarVeiculo(new Carro(placa, modelo, ano, portas));
            }
            else if (tipo == "2")
            {
                int.TryParse(Ler("Cilindradas"), out int cil);
                s.CadastrarVeiculo(new Moto(placa, modelo, ano, cil));
            }
            Console.WriteLine("Veículo cadastrado.");
        }

        static void RealizarAluguel(Sistema s)
        {
            var cpf = Ler("CPF do cliente");
            var cliente = s.BuscarClientePorCPF(cpf);
            if (cliente == null) { Console.WriteLine("Cliente não encontrado."); return; }

            s.ListarVeiculosDisponiveis();
            var placa = Ler("Placa do veículo");
            var veiculo = s.BuscarVeiculoPorPlaca(placa);
            if (veiculo == null || !veiculo.Disponivel) { Console.WriteLine("Veículo indisponível."); return; }

            DateTime.TryParse(Ler("Data início (dd/MM/yyyy)"), out DateTime inicio);
            DateTime.TryParse(Ler("Data fim (dd/MM/yyyy)"), out DateTime fim);
            decimal.TryParse(Ler("Valor total"), out decimal valor);

            s.RealizarAluguel(cliente, veiculo, inicio, fim, valor);
        }

        static string Ler(string msg)
        {
            Console.Write($"{msg}: ");
            return Console.ReadLine() ?? "";
        }
    }
}