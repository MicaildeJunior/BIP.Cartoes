using System;
using System.Collections.Generic;

namespace BIP.Cartoes.Infrastructure.Persistence.CadastroPf.Entities;

public partial class ClientePf
{
    public Guid Id { get; set; }

    public string Cpf { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public DateTime? DataNascimento { get; set; }

    public string? Email { get; set; }

    public string? Celular { get; set; }

    public decimal? RendaMensal { get; set; }

    public string? Profissao { get; set; }

    public string StatusCadastro { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<CartaoCredito> CartaoCreditos { get; set; } = new List<CartaoCredito>();
}
