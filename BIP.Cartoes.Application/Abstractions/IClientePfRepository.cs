namespace BIP.Cartoes.Application.Abstractions;

public interface IClientePfRepository
{
    Task<bool> ExisteCpfAsync(string cpf, CancellationToken ct = default);
    Task<Guid> InserirAsync(ClientePfModel model, CancellationToken ct = default);
}

public sealed class ClientePfModel
{
    public Guid Id { get; init; }
    public string Cpf { get; init; } = default!;
    public string Nome { get; init; } = default!;
    public DateTime? DataNascimento { get; init; }
    public string? Email { get; init; }
    public string? Celular { get; init; }
    public decimal? RendaMensal { get; init; }
    public string? Profissao { get; init; }
}