﻿using System;
using SistemaDeVotacao.Domain.Commands.Inputs.Usuario;
using SistemaDeVotacao.Domain.Commands.Outputs;
using SistemaDeVotacao.Domain.Entidades;
using SistemaDeVotacao.Domain.Interfaces.Repositories;
using SistemaDeVotacao.Infra.Interfaces.Commands;

namespace SistemaDeVotacao.Domain.Handlers
{
    public class UsuarioHandler : ICommandHandler<AdicionarUsuarioCommand>, ICommandHandler<AtualizarUsuarioCommand>,
        ICommandHandler<ExcluirUsuarioCommand>
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(AdicionarUsuarioCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new UsuarioCommandResult(false, "Por favor corrija as inconsistências",
                        command.Notifications);
                long id = 0;
                Usuario usuario = new Usuario(id, command.Nome, command.Login, command.Senha);
                id = _repository.Inserir(usuario);
                usuario.SetId(id);
                return new UsuarioCommandResult(true, "Usuário cadastrado com sucesso!", usuario);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public ICommandResult Handle(AtualizarUsuarioCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new UsuarioCommandResult(false, "Por favor corrija as inconsistências.",
                        command.Notifications);
                if (!_repository.CheckId(command.Id))
                    return new UsuarioCommandResult(false, "Este usuário não existe.", new { });

                Usuario usuario = new Usuario(command.Id, command.Nome, command.Login, command.Senha);
                _repository.Atualizar(usuario);
                return new UsuarioCommandResult(true, "Usuário atualizado com sucesso.", usuario);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public ICommandResult Handle(ExcluirUsuarioCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new UsuarioCommandResult(false, "Por favor corrija as inconsistencias.",
                        command.Notifications);

                if (!_repository.CheckId(command.Id))
                    return new UsuarioCommandResult(false, "Este usuário não existe.", new { });
                
                _repository.Excluir(command.Id);
                return new UsuarioCommandResult(true, "Usuário excluído com sucesso", new { });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}