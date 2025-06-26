namespace SistemaAluguelVeiculos.Modelos;

public class Carro : Veiculo
{
    public int QuantidadePortas { get; set; }

    public Carro(string placa, string modelo, int ano, int quantidadePortas)
        : base(placa, modelo, ano)
    {
        QuantidadePortas = quantidadePortas;
    }

    public override void ExibirInfo()
    {
        Console.WriteLine($"[Carro] {Modelo} - {Placa} ({Ano}) - {QuantidadePortas} portas - {(Disponivel ? "Disponível" : "Alugado")}");
    }
}
