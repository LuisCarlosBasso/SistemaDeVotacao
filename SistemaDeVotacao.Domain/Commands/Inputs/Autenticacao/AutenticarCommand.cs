using System;
using Flunt.Notifications;
using SistemaDeVotacao.Infra.Interfaces.Commands;

namespace SistemaDeVotacao.Domain.Commands.Inputs.Autenticacao
{
    public class AutenticarCommand : Notifiable, ICommandPadrao
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        
        public bool ValidarCommand()
        {
            try
            {
                if (string.IsNullOrEmpty(Login))
                    AddNotification("Login", "Login é um campo obrigatório.");
                
                if (string.IsNullOrEmpty(Senha))
                    AddNotification("Senha", "Senha é um campo obrigatório.");
                
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