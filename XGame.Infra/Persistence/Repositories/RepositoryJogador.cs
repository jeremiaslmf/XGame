using System;
using System.Collections.Generic;
using XGame.Domain.Entities;
using XGame.Domain.Interfaces.Repositories;

namespace XGame.Infra.Persistence.Repositories
{
    public class RepositoryJogador :  IRepositoryJogador
    {
        protected readonly XGameContext _context;
        public RepositoryJogador(XGameContext context)
        {
            _context = context;
        }

        public Jogador AdicionarJogador(Jogador jogador)
        {
            _context.Jogadores.Add(jogador);
            _context.SaveChanges();
            return jogador;
        }

        public void AlterarJogador(Jogador joagdor)
        {
            _context.Jogadores.
        }

        public Jogador AutenticarJogador(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Jogador> ListarJogador()
        {
            throw new NotImplementedException();
        }

        public Jogador ObterJogadorPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
