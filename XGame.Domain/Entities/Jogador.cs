using prmToolkit.NotificationPattern;
using System;
using XGame.Domain.Enum;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Entities
{
    public class Jogador : Notifiable
    {
        #region Métodos Construtores

        public Jogador(Email email, string senha)
        {
            Email = email;
            Senha = senha;

            #region Notificações

            new AddNotifications<Jogador>(this)
                .IfNullOrInvalidLength(x => x.Senha, 6, 32, "Senha deve conter entre 6 e 32 carateres.");

            #endregion Notificações
        }

        public Jogador(Nome nome, Email email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        #endregion Métodos Construtores

        #region Propriedades

        public Guid Id { get; private set; }
        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public string Senha { get; private set; }
        public Status Status { get; private set; }

        #endregion Propriedades
    }
}
