using XGame.Domain.Arguments.Jogador;

namespace XGame.Domain.Interfaces.Services
{
    public interface IServiceJogador
    {
        AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRquest request);
        AdicionarJogadorResponse AdicionarJogador(AdicionarJogadorRequest request);
    }
}
