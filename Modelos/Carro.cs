amespace SistemaAluguelVeiculos.Modelos;

public class Carro : Veiculo
{
    public int QuantidadePortas { get; set; }

    public Carro() { }

    public Carro(string placa, string modelo, int ano, int quantidadePortas)
        : base(placa, modelo, ano)
    {
        QuantidadePortas = quantidadePortas;
    }

    public override void ExibirInfo()
    {
        Console.WriteLine($"[CARRO] {Modelo} | Portas: {QuantidadePortas} | Placa: {Placa} | Status: {(Disponivel ? "Disponível" : "Alugado")}");
    }
}