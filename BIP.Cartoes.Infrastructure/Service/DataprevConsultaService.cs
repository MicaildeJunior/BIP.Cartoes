using BIP.Cartoes.Application.Abstractions;
using BIP.Cartoes.Infrastructure.Persistence.Dataprev;
using BIP.Cartoes.Shared.DataPrev;
using Microsoft.EntityFrameworkCore;

namespace BIP.Cartoes.Infrastructure.Service;

public class DataprevConsultaService : IDataprevConsultaService
{
    private readonly DataprevSimDbContext _db;

    public DataprevConsultaService(DataprevSimDbContext db)
    {
        _db = db;
    }

    public async Task<DataprevPessoaFisicaResponse?> ConsultarPorCpfAsync(string cpf, CancellationToken ct = default)
    {
        var entity = await _db.PessoaFisicaDataprevs
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Cpf == cpf, ct);

        if (entity is null) return null;

        return new DataprevPessoaFisicaResponse
        {
            Cpf = entity.Cpf,
            Nome = entity.Nome,
            StatusCpf = entity.StatusCpf
        };
    }
}
