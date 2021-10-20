using System;
using Flunt.Notifications;
using SistemaDeVotacao.Infra.Interfaces.Commands;

namespace SistemaDeVotacao.Domain.Commands.Inputs.Voto
{
    public class AdicionarVotoCommand : Notifiable, ICommandPadrao
    {
        public long IdUsuario { get; set; }
        public long IdFilme { get; set; }
        public bool ValidarCommand()
        {
            try
            {
                if (IdUsuario < 0)
                    AddNotification("IdUsuario", "Id do usuário inválido.");
            
                if (IdFilme < 0)
                    AddNotification("IdFilme", "Id do filme inválido.");

                return Valid;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}