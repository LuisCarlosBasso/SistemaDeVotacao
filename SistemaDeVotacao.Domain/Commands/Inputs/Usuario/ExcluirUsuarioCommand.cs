using System.Text.Json.Serialization;
using Flunt.Notifications;
using SistemaDeVotacao.Infra.Interfaces.Commands;

namespace SistemaDeVotacao.Domain.Commands.Inputs.Usuario
{
    public class ExcluirUsuarioCommand : Notifiable, ICommandPadrao
    {
        [JsonIgnore]
        public long Id { get; set; }

        public bool ValidarCommand()
        {
            if (Id < 0)
                AddNotification("Id", "Id inválido.");

            return Valid;
        }
    }
}