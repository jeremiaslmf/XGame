using System;
using System.Linq;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Services;

namespace XGame.AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando......");

            Console.WriteLine("Criando instancia do servico......");
            var service = new ServiceJogador();

            Console.WriteLine("Criando instancia do objeto request......");
            AutenticarJogadorRquest request = new AutenticarJogadorRquest();
            request.Email = "jeremiaslmf@gmail.com";
            request.Senha = "123456789";

            var response = service.AutenticarJogador(request);

            service.Notifications.ToList().ForEach(x => Console.WriteLine(x.Message));

            if (service.IsValid())
                return;



            Console.ReadKey();
        }
    }
}
