using System.Collections.Generic;
using SistemaDeVotacao.Domain.Entidades;
using SistemaDeVotacao.Domain.Queries;

namespace SistemaDeVotacao.Domain.Interfaces.Repositories
{
    public interface IVotoRepository
    {
        long Inserir(Voto voto);
        void Excluir(long id);
        List<VotoQueryResult> Listar();
        VotoQueryResult Obter(long id);
        bool CheckId(long id);
    }
}