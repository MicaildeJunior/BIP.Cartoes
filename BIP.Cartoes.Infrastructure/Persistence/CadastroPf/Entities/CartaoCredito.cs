using System;
using System.Collections.Generic;

namespace BIP.Cartoes.Infrastructure.Persistence.CadastroPf.Entities;

public partial class CartaoCredito
{
    public Guid Id { get; set; }

    public Guid ClientePfId { get; set; }

    public string NumeroMascarado { get; set; } = null!;

    public string Ultimos4 { get; set; } = null!;

    public string Bandeira { get; set; } = null!;

    public decimal Limite { get; set; }

    public string StatusCartao { get; set; } = null!;

    public byte ValidadeMes { get; set; }

    public short ValidadeAno { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ClientePf ClientePf { get; set; } = null!;
}
