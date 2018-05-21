using System;

namespace XGame.Domain.Arguments.Jogador
{
    public class JogadorResponse
    {
        #region Propriedades

        public Guid Id { get; private set; }
        public string NomeCompleto { get; private set; }
        public string PrimeiroNome { get; private set; }
        public string UltimoNome { get; private set; }
        public string Email { get; private set; }
        public string Status { get; private set; }

        #endregion Propriedades

        public static explicit operator JogadorResponse(Entities.Jogador entidade)
        {
            return new JogadorResponse()
            {
                Email = entidade.Email.Endereco,
                PrimeiroNome = entidade.Nome.PrimeiroNome,
                UltimoNome = entidade.Nome.UltimoNome,
                Id = entidade.Id,
                NomeCompleto = entidade.ToString(),
                //Status = entidade.Status.ToString()
            };
        }
    }
}
