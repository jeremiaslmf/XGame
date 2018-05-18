using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Services;
using XGame.Domain.Resources;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Services
{
    public class ServiceJogador : Notifiable, IServiceJogador
    {
        private readonly IRepositoryJogador _repositoryJogador;

        public ServiceJogador()
        {

        }

        public ServiceJogador(IRepositoryJogador repositoryJogador)
        {
            _repositoryJogador = repositoryJogador;
        }

        public AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorRequest request)
        {

            Guid id = _repositoryJogador.AdicionarJogador(request);
            return new AdicionarJogadorResponse()
            {
                Id = id,
                Message = "Operação realizada com sucesso!"
            };
        }

        public AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRquest request)
        {
            if (request == null)
                AddNotification("AutenticarJogadorRquest", Message.X0_E_OBRIGATORIO.ToFormat("AutenticarJogadorRquest"));

            var email = new Email(request.Email);
            var jogador = new Jogador(email, request.Senha);

            AddNotifications(jogador, email);

            if (jogador.IsInvalid())
                return null;

            var response = _repositoryJogador.AutenticarJogador(jogador.Email.Endereco, jogador.Senha);

            return response;
        }

        private bool IsEmail(string email)
        {
            return string.IsNullOrEmpty(email);
        }
    }
}
