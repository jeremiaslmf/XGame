using System;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Services;

namespace XGame.AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando......");

            var service = new ServiceJogador();
            Console.WriteLine("Criei instancia do servico......");

            AutenticarJogadorRquest request = new AutenticarJogadorRquest();
            Console.WriteLine("Criei instancia do objeto request......");

            var response = service.AutenticarJogador(request);

            Console.ReadKey();
        }
    }
}
