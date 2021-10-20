using System.Collections.Generic;
using SistemaDeVotacao.Domain.Entidades;
using SistemaDeVotacao.Domain.Queries;

namespace SistemaDeVotacao.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        long Inserir(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Excluir(long id);
        List<UsuarioQueryResult> Listar();
        UsuarioQueryResult Obter(long id);
        bool CheckId(long id);

    }
}