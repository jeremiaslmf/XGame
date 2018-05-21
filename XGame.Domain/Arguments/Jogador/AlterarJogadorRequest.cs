using System;
using XGame.Domain.ValueObjects;

namespace XGame.Domain.Arguments.Jogador
{
    public class AlterarJogadorRequest
    {
        public Guid Id { get; set; }
        public Nome Nome { get; set; }
        public Email Email { get; set; }
    }
}
