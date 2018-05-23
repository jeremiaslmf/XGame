using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using XGame.Domain.Entities.Base;
using XGame.Domain.Enum;
using XGame.Domain.Extensions;
using XGame.Domain.Resources;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Entities
{
    public class Jogador : EntityBase
    {

        #region Métodos Construtores

        public Jogador(Email email, string senha)
        {
            Email = email;
            Senha = senha;
            Status = Status.EmAnalise;

            #region Notificações

            new AddNotifications<Jogador>(this)
                .IfNullOrInvalidLength(x => x.Senha, 6, 32, Message.X0_E_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Senha", "6", "32"));

            if (IsValid())
                Senha = Senha.ConverToMD5();

            #endregion Notificações
        }

        public Jogador(Nome nome, Email email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Status = Status.EmAnalise;

            new AddNotifications<Jogador>(this)
               .IfNullOrInvalidLength(x => x.Senha, 6, 32, Message.X0_E_OBRIGATORIA_E_DEVE_CONTER_ENTRE_X1_E_X2_CARACTERES.ToFormat("Senha", "6", "32"));

            if (IsValid())
                Senha = Senha.ConverToMD5();

            AddNotifications(nome, email);
        }

        #endregion Métodos Construtores

        #region Propriedades

        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public string Senha { get; private set; }
        public Status Status { get; private set; }

        #endregion Propriedades

        public override string ToString()
        {
            return $"{Nome.PrimeiroNome} {Nome.UltimoNome}";
        }

        public void AlterarJogador(Nome nome, Email email, Status status)
        {
            Nome = nome;
            Email = email;

            new AddNotifications<Jogador>(this).IfFalse(status == Status.Ativo, Message.NAO_E_POSSIVEL_ALTERAR_X0.ToFormat("Jogador"));

            AddNotifications(nome, email);
        }
    }
}
