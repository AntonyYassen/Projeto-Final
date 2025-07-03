using Microsoft.EntityFrameworkCore;
using SistemaAluguelVeiculos.Data;
using SistemaAluguelVeiculos.Modelos;
using System;
using System.Linq;

namespace SistemaAluguelVeiculos.Servicos;

public class Sistema
{
    private readonly AppDbContext _db;

    public Sistema(AppDbContext db) => _db = db;

    public void CadastrarCliente(Cliente cliente)
    {
        _db.Clientes.Add(cliente);
        _db.SaveChanges();
    }

    public void CadastrarVeiculo(Veiculo veiculo)
    {
        _db.Veiculos.Add(veiculo);
        _db.SaveChanges();
    }

    public void RealizarAluguel(Cliente cliente, Veiculo veiculo, DateTime inicio, DateTime fim, decimal valor)
    {
        if (!veiculo.Disponivel)
            throw new InvalidOperationException("Veículo já está alugado");

        var contrato = new ContratoAluguel
        {
            ClienteCPF = cliente.CPF,
            VeiculoPlaca = veiculo.Placa,
            DataInicio = inicio,
            DataFim = fim,
            ValorTotal = valor,
            Cliente = cliente,
            Veiculo = veiculo
        };

        veiculo.Disponivel = false;
        _db.Contratos.Add(contrato);
        _db.SaveChanges();
    }

    public Cliente? BuscarClientePorCpf(string cpf) => 
        _db.Clientes.FirstOrDefault(c => c.CPF == cpf);

    public Veiculo? BuscarVeiculoPorPlaca(string placa) => 
        _db.Veiculos.FirstOrDefault(v => v.Placa == placa);

    public void ListarVeiculosDisponiveis()
    {
        var veiculos = _db.Veiculos.Where(v => v.Disponivel).ToList();
        if (!veiculos.Any())
        {
            Console.WriteLine("Nenhum veículo disponível no momento.");
            return;
        }
        veiculos.ForEach(v => v.ExibirInfo());
    }

    public void ListarClientes()
    {
        var clientes = _db.Clientes.ToList();
        if (!clientes.Any())
        {
            Console.WriteLine("Nenhum cliente cadastrado.");
            return;
        }
        clientes.ForEach(c => Console.WriteLine(c));
    }

    public void GerarRelatorioContratos()
    {
        var contratos = _db.Contratos
            .Include(c => c.Cliente)
            .Include(c => c.Veiculo)
            .ToList();

        if (!contratos.Any())
        {
            Console.WriteLine("Nenhum contrato registrado.");
            return;
        }

        contratos.ForEach(c => Console.WriteLine(c));
        Console.WriteLine($"\nTotal de contratos: {contratos.Count}");
        Console.WriteLine($"Faturamento total: R${contratos.Sum(c => c.ValorTotal):F2}");
    }
}