using BIP.Cartoes.Application.Abstractions;
using BIP.Cartoes.Infrastructure.Persistence.CadastroPf;
using BIP.Cartoes.Infrastructure.Persistence.CadastroPf.Entities;
using Microsoft.EntityFrameworkCore;

namespace BIP.Cartoes.Infrastructure.Repository;

public class ClientePfRepository : IClientePfRepository
{
    private readonly CadastroPfDbContext _db;

    public ClientePfRepository(CadastroPfDbContext db)
    {
        _db = db;
    }

    public Task<bool> ExisteCpfAsync(string cpf, CancellationToken ct = default)
        => _db.ClientePfs.AnyAsync(x => x.Cpf == cpf, ct);

    public async Task<Guid> InserirAsync(ClientePfModel model, CancellationToken ct = default)
    {
        var entity = new ClientePf
        {
            Id = model.Id,
            Cpf = model.Cpf,
            Nome = model.Nome,
            DataNascimento = model.DataNascimento,
            Email = model.Email,
            Celular = model.Celular,
            RendaMensal = model.RendaMensal,
            Profissao = model.Profissao,
            StatusCadastro = "ATIVO",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _db.ClientePfs.Add(entity);
        await _db.SaveChangesAsync(ct);

        return entity.Id;
    }
}
