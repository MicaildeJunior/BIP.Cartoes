namespace BIP.Cartoes.Shared.Contracts.Clientes;

public class CriarClientePfRequest
{
    public string Cpf { get; set; } = default!;
    public string Nome { get; set; } = default!;
    public DateTime? DataNascimento { get; set; }
    public string? Email { get; set; }
    public decimal? RendaMensal { get; set; }
}
