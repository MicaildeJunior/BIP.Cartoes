using BIP.Cartoes.Shared.DataPrev;

namespace BIP.Cartoes.Application.Abstractions;

public interface IDataprevConsultaService
{
    Task<DataprevPessoaFisicaResponse?> ConsultarPorCpfAsync(string cpf, CancellationToken ct = default);
}
