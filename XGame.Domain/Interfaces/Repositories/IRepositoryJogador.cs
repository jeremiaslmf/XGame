﻿using System;
using XGame.Domain.Arguments.Jogador;

namespace XGame.Domain.Interfaces.Repositories
{
    public interface IRepositoryJogador
    {
        AutenticarJogadorResponse AutenticarJogador(AutenticarJogadorRquest request);
        Guid AdicionarJogador(AdicionarJogadorRequest request);
    }
}
