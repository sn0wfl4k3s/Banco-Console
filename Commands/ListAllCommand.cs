using Banco.Context;
using Microsoft.EntityFrameworkCore;

namespace Banco.Commands;

internal class ListAllCommand : IOptionCommand
{
    private readonly AppDbContext _context;

    public ListAllCommand(AppDbContext context)
    {
        _context = context;
    }

    public string Display => "Listar Contas";

    public void Execute()
    {
        var contas = string.Join(
            "\n-----------------------------------\n",
            _context
                .Contas
                .AsQueryable()
                .AsNoTracking()
                .ToList()
                .Select(c => c.ToString()));

        Console.WriteLine(contas);

        UIManager.PressKeyToContinue();
    }
}
