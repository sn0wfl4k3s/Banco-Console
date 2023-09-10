using Banco.Context;
using Banco.Domain;

namespace Banco.Commands;

internal class CreateCommand : IOptionCommand
{
    private readonly AppDbContext _context;

    public CreateCommand(AppDbContext context)
    {
        _context = context;
    }

    public string Display => "Criar Nova Conta";

    public void Execute()
    {
        Console.Write("Titular...: ");

        var titular = Console.ReadLine() ?? string.Empty;

        Console.Write("Saldo (R$): ");

        if (!double.TryParse(Console.ReadLine(), out var saldo))
            throw new ArgumentException(nameof(saldo));

        Console.Write("Número....: ");

        if (!int.TryParse(Console.ReadLine(), out var numero))
            throw new ArgumentException(nameof(numero));

        var conta = new Conta { Titular = titular, Saldo = saldo, Numero = numero };

        _context.Contas.Add(conta);

        _context.SaveChanges();

        Console.WriteLine("Conta criada com sucesso!");

        Thread.Sleep(2_000);
    }
}
