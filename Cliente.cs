namespace SistemaAluguelVeiculos.Modelos;

public class Cliente
{
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Telefone { get; set; }

    public Cliente(string nome, string cpf, string telefone)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("Nome é obrigatório");
        if (string.IsNullOrWhiteSpace(cpf))
            throw new ArgumentException("CPF é obrigatório");
        if (string.IsNullOrWhiteSpace(telefone))
            throw new ArgumentException("Telefone é obrigatório");

        Nome = nome;
        CPF = cpf;
        Telefone = telefone;
    }

    public override string ToString()
    {
        return $"{Nome} - CPF: {CPF} - Telefone: {Telefone}";
    }
}
