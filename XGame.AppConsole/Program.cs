using System;
using System.Linq;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Services;
using XGame.Domain.ValueObjects;

namespace XGame.AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando......");

            Console.WriteLine("Criando instancia do servico......");
            var service = new ServiceJogador();

            Console.WriteLine("Criando instancia do objeto request - Autenticação Jogador");            
            var autenticarRequest = new AutenticarJogadorRquest()
            {
                Email = "jeremiaslmf@gmail.com",
                Senha = "123456789"
            };
            var responseAut = service.AutenticarJogador(autenticarRequest);

            Console.WriteLine("Criando instancia do objeto request - Inserção Jogador");
            var adicionarResponse = new AdicionarJogadorRequest()
            {
                Email = new Email("jeremiaslmf@gmail.com"),
                Nome = new Nome("Jeremias", "Lima dos Santos Filho"),
                Senha = "123456789"
            };

            var responseAdd = service.AdicionarJogador(adicionarResponse);

            service.Notifications.ToList().ForEach(x => Console.WriteLine(x.Message));

            if (service.IsValid())
                return;



            Console.ReadKey();
        }
    }
}
