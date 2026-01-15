using BIP.Cartoes.Shared.Contracts.Clientes;

namespace BIP.Cartoes.Application.Clientes.Interfaces;

public interface ICriarClientePfUseCase
{
    Task<CriarClientePfResponse> ExecutarAsync(CriarClientePfRequest request, CancellationToken ct = default);
}
