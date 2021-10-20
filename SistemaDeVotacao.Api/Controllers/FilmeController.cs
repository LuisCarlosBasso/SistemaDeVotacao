using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SistemaDeVotacao.Domain.Commands.Inputs.Filme;
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
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeRepository _repository;
        private readonly FilmeHandler _handler;

        public FilmeController(IFilmeRepository repository, FilmeHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpPost]
        [Route("filme")]
        public ICommandResult InserirFilme([FromBody] AdicionarFilmeCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut]
        [Route("filme/{id}")]
        public ICommandResult AtualizarFilme(long id, [FromBody] AtualizarFilmeCommand command)
        {
            command.Id = id;
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("filme/{id}")]
        public ICommandResult ExcluirFilme(long id)
        {
            var command = new ExcluirFilmeCommand() {Id = id};
            return _handler.Handle(command);
        }
        
        [HttpGet]
        [Route("filmes")]
        public List<FilmeQueryResult> ListarFilmes()
        {
            return _repository.Listar();
        }

        [HttpGet]
        [Route("filme/{id}")]
        public FilmeQueryResult ObterFilme(long id)
        {
            return _repository.Obter(id);
        }
    }
}