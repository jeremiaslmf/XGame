using System;
using XGame.Domain.Entities;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Arguments.Jogador
{
    public class AlterarJogadorResponse
    {
        public Guid Id { get; set; }
        public Nome Nome { get; set; }
        public Email Email { get; set; }
        public string Message { get; set; }

        public static explicit operator AlterarJogadorResponse(Entities.Jogador entidade)
        {
            return new AlterarJogadorResponse()
            {
                Id = entidade.Id,
                Nome = entidade.Nome,
                Email = entidade.Email,
                Message = Resources.Message.OPERACAO_REALIZADA_COM_SUCESSO
            };
        }
    }
}
