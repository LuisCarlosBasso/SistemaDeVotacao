using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SistemaDeVotacao.Domain.Commands.Inputs.Usuario;
using SistemaDeVotacao.Domain.Handlers;
using SistemaDeVotacao.Domain.Interfaces.Repositories;
using SistemaDeVotacao.Domain.Queries;
using SistemaDeVotacao.Infra.Interfaces.Commands;

namespace SistemaDeVotacao.Controllers
{
    
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    [Route("api/v1")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;
        private readonly UsuarioHandler _handler;

        public UsuarioController(IUsuarioRepository repository, UsuarioHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpPost]
        [Route("usuario")]
        public ICommandResult InserirUsuario([FromBody] AdicionarUsuarioCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut]
        [Route("usuario/{id}")]
        public ICommandResult AtualizarUsuario(long id, [FromBody] AtualizarUsuarioCommand command)
        {
            command.Id = id;
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("usuario/{id}")]
        public ICommandResult ExcluirUsuario(long id)
        {
            var command = new ExcluirUsuarioCommand() {Id = id};
            return _handler.Handle(command);
        }
        
        [HttpGet]
        [Route("usuarios")]
        public List<UsuarioQueryResult> ListarUsuarios()
        {
            return _repository.Listar();
        }

        [HttpGet]
        [Route("usuario/{id}")]
        public UsuarioQueryResult ObterUsuario(long id)
        {
            return _repository.Obter(id);
        }
    }
}