using BIP.Cartoes.Application.Validator;
using BIP.Cartoes.Infrastructure.Persistence.CadastroPf;
using BIP.Cartoes.Infrastructure.Persistence.CadastroPf.Entities;
using BIP.Cartoes.Shared.Contracts.Clientes;
using FluentValidation;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BIP.Cartoes.Functions;

public class ClientesFunctions
{
    private readonly ILogger _logger;
    private readonly IValidator<CriarClientePfRequest> _validator;

    public ClientesFunctions(ILoggerFactory loggerFactory, IValidator<CriarClientePfRequest> validator)
    {
        _logger = loggerFactory.CreateLogger<ClientesFunctions>();
        _validator = validator;
    }

    [Function("ClientesFunctions")]
    public async Task<HttpResponseData> CriarClientePfAsync([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "clientes")] HttpRequestData req)
    {
        try
        {
            _logger.LogInformation("POST recebido.");
            var request = await req.ReadFromJsonAsync<CriarClientePfRequest>();
            var validation = await _validator.ValidateAsync(request);

            if (!validation.IsValid)
                throw new ValidationException(validation.Errors);

            var ok = req.CreateResponse(HttpStatusCode.OK);
            await ok.WriteStringAsync("Cliente validado com sucesso!");
            return ok;
        }
        catch (ValidationException ex)
        {
            var bad = req.CreateResponse(HttpStatusCode.BadRequest);
            await bad.WriteAsJsonAsync(new
            {
                errors = ex.Errors.Select(e => new { field = e.PropertyName, error = e.ErrorMessage })
            });
            return bad;
        }

    }
}
