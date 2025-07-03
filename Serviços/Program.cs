using Microsoft.EntityFrameworkCore;
using SistemaAluguelVeiculos.Data;
using SistemaAluguelVeiculos.Modelos;
using SistemaAluguelVeiculos.Servicos;

// Inicializa o banco de dados
var db = new AppDbContext();
db.Database.EnsureCreated();
if (!db.Veiculos.Any())
{
    // Carros
    db.Veiculos.AddRange(
        new Carro("ABC1D23", "Fiat Argo", 2023, 4),
        new Carro("DEF4G56", "VW Gol", 2022, 4),
        new Carro("GHI7J89", "Hyundai HB20", 2023, 4),
        new Carro("JKL0M12", "Chevrolet Onix", 2024, 4),
        new Carro("MNO3P45", "Renault Kwid", 2022, 4),

        // Motos
        new Moto("MOT0R01", "Honda CB500", 2023, 500),
        new Moto("MOT0R02", "Yamaha Factor", 2024, 150),
        new Moto("MOT0R03", "Honda Biz", 2023, 125),
        new Moto("MOT0R04", "Yamaha Fazer", 2022, 250),
        new Moto("MOT0R05", "Honda CG", 2023, 160)
    );

    // Clientes
    db.Clientes.AddRange(
        new Cliente("João Silva", "11122233344", "11999991111"),
        new Cliente("Maria Souza", "55566677788", "21988882222"),
        new Cliente("Carlos Oliveira", "99900011122", "31977773333")
    );

    db.SaveChanges();
}

// Cadastra dados iniciais se o banco estiver vazio
if (!db.Veiculos.Any())
{
    db.Veiculos.AddRange(
        new Carro("ABC1D23", "Fiat Argo", 2023, 4),
        new Carro("XYZ9A87", "Hyundai HB20", 2022, 4),
        new Moto("MOT0R12", "Honda CB 500", 2023, 500),
        new Moto("BIKE001", "Yamaha Factor 150", 2022, 150)
    );

    db.Clientes.AddRange(
        new Cliente("João Silva", "12345678901", "11999998888"),
        new Cliente("Maria Souza", "98765432109", "21988887777")
    );

    db.SaveChanges();
}

// Inicia o sistema
var sistema = new Sistema(db);
var menu = new MenuPrincipal(sistema);
menu.ExibirMenu();