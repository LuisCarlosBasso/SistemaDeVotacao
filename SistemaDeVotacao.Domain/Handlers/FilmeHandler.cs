using System;
using SistemaDeVotacao.Domain.Commands.Inputs.Filme;
using SistemaDeVotacao.Domain.Commands.Inputs.Usuario;
using SistemaDeVotacao.Domain.Commands.Outputs;
using SistemaDeVotacao.Domain.Entidades;
using SistemaDeVotacao.Domain.Interfaces.Repositories;
using SistemaDeVotacao.Infra.Interfaces.Commands;

namespace SistemaDeVotacao.Domain.Handlers
{
    public class FilmeHandler : ICommandHandler<AdicionarFilmeCommand>, ICommandHandler<AtualizarFilmeCommand>,
        ICommandHandler<ExcluirFilmeCommand>
    {
        private readonly IFilmeRepository _repository;

        public FilmeHandler(IFilmeRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(AdicionarFilmeCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new FilmeCommandResult(false, "Por favor corrija as inconsistências.",
                        command.Notifications);
                long id = 0;
                Filme filme = new Filme(id, command.Titulo, command.Diretor);
                id = _repository.Inserir(filme);
                filme.SetId(id);
                return new FilmeCommandResult(true, "Filme cadastrado com sucesso!", filme);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public ICommandResult Handle(AtualizarFilmeCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new FilmeCommandResult(false, "Por favor corrija as inconsistências.",
                        command.Notifications);
                if (!_repository.CheckId(command.Id))
                    return new FilmeCommandResult(false, "Este filme não existe.", new { });

                Filme filme = new Filme(command.Id, command.Titulo, command.Diretor);
                _repository.Atualizar(filme);
                return new FilmeCommandResult(true, "Filme atualizado com sucesso!", new { });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public ICommandResult Handle(ExcluirFilmeCommand command)
        {
            if (!command.ValidarCommand())
                return new FilmeCommandResult(false, "Por favor corrija as inconsistências.",
                    command.Notifications);
            
            if (!_repository.CheckId(command.Id))
                return new FilmeCommandResult(false, "Este filme não existe.", new { });
            
            _repository.Excluir(command.Id);
            return new FilmeCommandResult(true, "Filme excluído com sucesso!", new { });
        }
    }
}