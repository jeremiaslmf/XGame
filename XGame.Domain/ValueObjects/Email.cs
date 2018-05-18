using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using XGame.Domain.Resources;

namespace XGame.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        #region Método Construtor

        public Email(string endereco)
        {
            Endereco = endereco;

            #region Notificações

            new AddNotifications<Email>(this)
                .IfNotEmail(x => x.Endereco, Message.X0_INVALIDO.ToFormat("E-mail"));

            #endregion Notificações
        }

        #endregion Método Construtor

        public string Endereco { get; set; }
    }
}
