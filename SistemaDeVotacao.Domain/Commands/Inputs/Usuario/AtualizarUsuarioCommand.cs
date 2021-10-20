using System.Text.Json.Serialization;
using Flunt.Notifications;
using SistemaDeVotacao.Infra.Interfaces.Commands;

namespace SistemaDeVotacao.Domain.Commands.Inputs.Usuario
{
    public class AtualizarUsuarioCommand : Notifiable, ICommandPadrao
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public bool ValidarCommand()
        {
            if (Id < 0)
                AddNotification("Id", "Id inválido.");
            
            int tamanhoLogin = 15;
            if (string.IsNullOrEmpty(Login))
                AddNotification("Login", "Login é um campo obrigatório.");
            if (Login.Length > tamanhoLogin) 
                AddNotification("Login", $"Login deve ser menor do que {tamanhoLogin} caracteres.");
                
            if (string.IsNullOrEmpty(Senha))
                AddNotification("Senha", "Senha é um campo obrigatório.");
            
            if (string.IsNullOrEmpty(Nome))
                AddNotification("Nome", "Nome é um campo obrigatório.");

            return Valid;
        }
    }
}