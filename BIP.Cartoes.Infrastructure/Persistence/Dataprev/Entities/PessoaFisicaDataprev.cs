using System;
using System.Collections.Generic;

namespace BIP.Cartoes.Infrastructure.Persistence.Dataprev.Entities;

public partial class PessoaFisicaDataprev
{
    public Guid Id { get; set; }

    public string Cpf { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public DateOnly? DataNascimento { get; set; }

    public string StatusCpf { get; set; } = null!;

    public bool Obito { get; set; }

    public DateTime UpdatedAt { get; set; }
}
