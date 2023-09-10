using Banco.Context;

namespace Banco.Commands;

internal class TransferCommand : IOptionCommand
{
    private readonly AppDbContext _context;

    public TransferCommand(AppDbContext context)
    {
        _context = context;
    }

    public string Display => "Transferência de Saldo";

    public void Execute()
    {
        Console.Write("Numero da Conta de Origem.: ");

        if (!int.TryParse(Console.ReadLine(), out var numeroContaOrigem))
            throw new ArgumentException(nameof(numeroContaOrigem));

        var contaOrigem = _context.Contas.FirstOrDefault(c => c.Numero == numeroContaOrigem)
            ?? throw new ArgumentNullException("Conta origem não encontrada");

        Console.Write("Numero da Conta de Destino: ");

        if (!int.TryParse(Console.ReadLine(), out var numeroContaDestino))
            throw new ArgumentException(nameof(numeroContaDestino));

        var contaDestino = _context.Contas.FirstOrDefault(c => c.Numero == numeroContaDestino)
            ?? throw new ArgumentNullException("Conta destino não encontrada");

        Console.Write("Valor: ");

        if (!double.TryParse(Console.ReadLine(), out var valor))
            throw new ArgumentException(nameof(valor));

        contaOrigem.Transfer(contaDestino, valor);

        _context.SaveChanges();
    }
}
