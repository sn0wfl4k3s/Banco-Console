using Banco;
using Banco.Commands;
using Banco.Context;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddDbContext<AppDbContext>();

var provider = services.BuildServiceProvider();

var optionsMenu = new Dictionary<int, IOptionCommand>
{
    { 0, ActivatorUtilities.CreateInstance<ExitCommand>(provider) },
    { 1, ActivatorUtilities.CreateInstance<ListAllCommand>(provider) },
    { 2, ActivatorUtilities.CreateInstance<CreateCommand>(provider) },
    { 3, ActivatorUtilities.CreateInstance<TransferCommand>(provider) }
};

UIManager.Run(optionsMenu, 0);