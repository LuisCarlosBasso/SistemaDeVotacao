using System.Collections.Generic;
using SistemaDeVotacao.Domain.Entidades;
using SistemaDeVotacao.Domain.Queries;

namespace SistemaDeVotacao.Domain.Interfaces.Repositories
{
    public interface IFilmeRepository
    {
        long Inserir(Filme usuario);
        void Atualizar(Filme usuario);
        void Excluir(long id);
        List<FilmeQueryResult> Listar();
        FilmeQueryResult Obter(long id);
        bool CheckId(long id);
    }
}