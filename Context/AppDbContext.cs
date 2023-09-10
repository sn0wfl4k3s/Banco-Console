using Banco.Domain;
using kDg.FileBaseContext.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Banco.Context;

internal class AppDbContext : DbContext
{
    public DbSet<Conta> Contas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var location = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "BancoApp");

        optionsBuilder.UseFileBaseContextDatabase(location: location);

        base.OnConfiguring(optionsBuilder);
    }
}
