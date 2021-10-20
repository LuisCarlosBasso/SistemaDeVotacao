using Microsoft.AspNetCore.Mvc;
using SistemaDeVotacao.Domain.Commands.Inputs.Autenticacao;
using SistemaDeVotacao.Domain.Handlers;
using SistemaDeVotacao.Infra.Interfaces.Commands;

namespace SistemaDeVotacao.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [ApiController]
    [Route("autenticar")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly AutenticacaoHandler _handler;

        public AutenticacaoController(AutenticacaoHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        [Route("signin")]
        public ICommandResult Autenticar([FromBody] AutenticarCommand command)
        {
            return _handler.Handle(command);
        }
        
    }
}