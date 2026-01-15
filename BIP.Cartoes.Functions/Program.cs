using BIP.Cartoes.Application.Validator;
using BIP.Cartoes.Infrastructure.Persistence.CadastroPf;
using BIP.Cartoes.Infrastructure.Persistence.Dataprev;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<CadastroPfDbContext>(options =>
            options.UseSqlServer(context.Configuration.GetConnectionString("CadastroPfDb")));

        services.AddDbContext<DataprevSimDbContext>(options =>
            options.UseSqlServer(context.Configuration.GetConnectionString("DataprevSimDb")));

        services.AddValidatorsFromAssemblyContaining<CriarClientePfValidator>();
    })
    .Build();

host.Run();
