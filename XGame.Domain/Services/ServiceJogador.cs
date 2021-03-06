﻿using prmToolkit.NotificationPattern;
using prmToolkit.NotificationPattern.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using XGame.Domain.Arguments.Base;
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
            var nome = new Nome(request.Nome.PrimeiroNome, request.Nome.UltimoNome);
            var email = new Email(request.Email.Endereco);
            var jogador = new Jogador(nome, email, request.Senha);

            AddNotifications(jogador);

            //if (_repositoryJogador.Existe(x => x.Email.Endereco == request.Email.Endereco))
            //    AddNotification("E-mail", Message.JA_EXISTE_UM_X0_CHAMADO_X1.ToFormat("e-mail", request.Email.Endereco));

            if (IsInvalid())
                return null;

            jogador = _repositoryJogador.Adicionar(jogador);

            return (AdicionarJogadorResponse)jogador;
        }

        public AlterarJogadorResponse AlterarJogador(AlterarJogadorRequest request)
        {
            if (request == null)
                AddNotification("AlterarJogadorRquest", Message.X0_E_OBRIGATORIO.ToFormat("AlterarJogadorRquest"));

            Jogador jogador = _repositoryJogador.ObterPorId(request.Id);
            if (jogador == null)
            {
                AddNotification("Id", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            var nome = new Nome(request.Nome.PrimeiroNome, request.Nome.UltimoNome);
            var email = new Email(request.Email.Endereco);

            jogador.AlterarJogador(nome, email, jogador.Status);

            AddNotifications(jogador, email);

            if (IsInvalid())
                return null;

            _repositoryJogador.Editar(jogador);

            return (AlterarJogadorResponse)jogador;
        }

        public AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRequest request)
        {
            if (request == null)
                AddNotification("AutenticarJogadorRquest", Message.X0_E_OBRIGATORIO.ToFormat("AutenticarJogadorRquest"));

            var email = new Email(request.Email);
            var jogador = new Jogador(email, request.Senha);

            AddNotifications(jogador, email);

            if (jogador.IsInvalid())
                return null;

            jogador = _repositoryJogador.ObterPor(x => x.Email.Endereco == jogador.Email.Endereco && x.Senha == jogador.Senha);

            return (AutenticarJogadorResponse)jogador;
        }

        public ResponseBase ExcluirJogador(Guid id)
        {
            Jogador jogador = _repositoryJogador.ObterPorId(id);
            if (jogador == null)
            {
                AddNotification("Id", Message.DADOS_NAO_ENCONTRADOS);
                return null;
            }

            _repositoryJogador.Remover(jogador);

            return new ResponseBase();
        }

        public IEnumerable<JogadorResponse> ListarJogador()
        {
            return _repositoryJogador.Listar().Select(jogador => (JogadorResponse)jogador).ToList();
        }
    }
}
