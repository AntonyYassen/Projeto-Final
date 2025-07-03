namespace SistemaAluguelVeiculos.Modelos;

public class Moto : Veiculo
{
    public int Cilindradas { get; set; }

    public Moto() { }

    public Moto(string placa, string modelo, int ano, int cilindradas)
        : base(placa, modelo, ano)
    {
        Cilindradas = cilindradas;
    }

    public override void ExibirInfo()
    {
        Console.WriteLine($"[MOTO] {Modelo} | {Cilindradas}cc | Placa: {Placa} | Status: {(Disponivel ? "Disponível" : "Alugada")}");
    }
}