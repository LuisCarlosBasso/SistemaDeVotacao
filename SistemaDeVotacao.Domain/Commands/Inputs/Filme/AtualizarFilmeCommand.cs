using System;
using System.Text.Json.Serialization;
using Flunt.Notifications;
using SistemaDeVotacao.Infra.Interfaces.Commands;

namespace SistemaDeVotacao.Domain.Commands.Inputs.Filme
{
    public class AtualizarFilmeCommand : Notifiable, ICommandPadrao
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Diretor { get; set; }
        public bool ValidarCommand()
        {
            try
            {
                if (Id < 0)
                    AddNotification("Id", "Id é inválido.");
            
                if (string.IsNullOrEmpty(Titulo))
                    AddNotification("Titulo", "Título é um campo obrigatório.");
            
                if (string.IsNullOrEmpty(Diretor))
                    AddNotification("Diretor", "Diretor é um campo obrigatório.");

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