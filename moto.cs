namespace SistemaAluguelVeiculos.Modelos;

public class Moto : Veiculo
{
    public int Cilindradas { get; set; }

    public Moto(string placa, string modelo, int ano, int cilindradas)
        : base(placa, modelo, ano)
    {
        Cilindradas = cilindradas;
    }

    public override void ExibirInfo()
    {
        Console.WriteLine($"[Moto] {Modelo} - {Placa} ({Ano}) - {Cilindradas}cc - {(Disponivel ? "Disponível" : "Alugada")}");
    }
}
