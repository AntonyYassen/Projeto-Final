namespace SistemaAluguelVeiculos.Modelos;

public class Veiculo
{
    public string Placa { get; set; }
    public string Modelo { get; set; }
    public int Ano { get; set; }
    public bool Disponivel { get; set; } = true;

    public Veiculo(string placa, string modelo, int ano)
    {
        Placa = placa;
        Modelo = modelo;
        Ano = ano;
    }

    public virtual void ExibirInfo()
    {
        Console.WriteLine($"{Modelo} - {Placa} ({Ano}) - {(Disponivel ? "Disponível" : "Alugado")}");
    }
}
