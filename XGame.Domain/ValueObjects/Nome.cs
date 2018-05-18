using prmToolkit.NotificationPattern;

namespace XGame.Domain.ValueObjects
{
    public class Nome : Notifiable
    {
        public Nome(string primeiroNome, string ultimoNome)
        {
            PrimeiroNome = primeiroNome;
            UltimoNome = ultimoNome;

            new AddNotifications<Nome>(this)
                .IfNullOrInvalidLength(x => x.PrimeiroNome, 3, 20, );
        }

        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
    }
}