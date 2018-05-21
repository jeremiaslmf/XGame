using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using XGame.Domain.Entities;

namespace XGame.Infra.Persistence
{
    public class XGameContext : DbContext
    {
        public XGameContext() : base("XGameConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public IDbSet<Jogador> Jogadores { get; set; }
        public IDbSet<Plataforma> Plataformas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Seta o Schema default
            // modelBuilder.HasDefaultSchema("Apoio");

            // Remove a pluralização dos nomes das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Remove exclusão em cascata
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // Setar para usar varchar invés de nvarchar
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            // Seta o tamanho padrão para determinado campo caso não seja informado o tm em sua criação
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            // Mapeia as entidades
            // modelBuilder.Configurations.Add(new JogadorMap());
            // modelBuilder.Configurations.Add(new PlataformaMap());

            #region Adiciona entidades mapeadas Automaticamente via Assembly
            /// <summary>
            /// Isso facilita o mapeamento das entidades.
            /// O trecho comentado acima, não é necessário ser feito pois o Assembly faz isso sem o Add para cada mapeamento
            /// </summary>

            modelBuilder.Configurations.AddFromAssembly(typeof(XGameContext).Assembly);

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
