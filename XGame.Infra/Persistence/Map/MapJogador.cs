using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using XGame.Domain.Entities;

namespace XGame.Infra.Persistence.Map
{
    public class MapJogador : EntityTypeConfiguration<Jogador>
    {
        public MapJogador()
        {
            ToTable("Jogador");

            Property(x => x.Nome.PrimeiroNome)
                .HasColumnName("PrimeiroNome")
                .HasMaxLength(20)
                .IsRequired();

            Property(x => x.Nome.UltimoNome)
                .HasColumnName("UltimoNome")
                .HasMaxLength(50)
                .IsRequired();
                
            Property(x => x.Email.Endereco)
                .HasMaxLength(200)
                .IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("UK_JOGADOR_EMAIL") { IsUnique = true })).HasColumnName("Email");

            Property(x => x.Senha).HasMaxLength(32).IsRequired();

            Property(x => x.Status).IsRequired();

        }
    }
}
