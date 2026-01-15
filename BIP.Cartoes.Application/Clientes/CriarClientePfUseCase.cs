using BIP.Cartoes.Application.Clientes.Interfaces;
using BIP.Cartoes.Shared.Contracts.Clientes;

namespace BIP.Cartoes.Application.Clientes;

public class CriarClientePfUseCase : ICriarClientePfUseCase
{
    public Task<CriarClientePfResponse> ExecutarAsync(CriarClientePfRequest request, CancellationToken ct = default)
    {
        throw new NotImplementedException();
    }
}
