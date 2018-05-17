using System;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Interfaces.Repositories;
using XGame.Domain.Interfaces.Services;

namespace XGame.Domain.Services
{
    public class ServiceJogador : IServiceJogador
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
            // Isso será melhorado futuramente, pois as Exceptions exigem muito processamento
            if (request == null)
                throw new Exception("AutenticarJogadorRequest é obrigatório.");

            if (IsEmail(request.Email))
                throw new Exception("Informe um e-mail.");

            if (request.Senha.Length < 6)
                throw new Exception("Digite uma senha de no mínimo 6 caracteres.");

            var response = _repositoryJogador.AutenticarJogador(request);

            return response;
        }

        private bool IsEmail(string email)
        {
            return string.IsNullOrEmpty(email);
        }
    }
}
