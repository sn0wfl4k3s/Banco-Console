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
        var contas = _context.Contas.AsQueryable().AsNoTracking().ToList();

        foreach (var conta in contas)
        {
            Console.WriteLine(conta);
        }

        UIManager.PressKeyToContinue();
    }
}
