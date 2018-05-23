using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Unity;
using XGame.Domain.Arguments.Jogador;
using XGame.Domain.Interfaces.Services;
using System;

namespace XGame.Api.Security
{
    public class AuthorizationProvider : OAuthAuthorizationServerProvider
    {
        private readonly UnityContainer _container;

        public AuthorizationProvider(UnityContainer container)
        {
            _container = container;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {

                IServiceJogador serviceJogador = _container.Resolve<IServiceJogador>();

                AutenticarJogadorRequest request = new AutenticarJogadorRequest();
                request.Email = context.UserName;
                request.Senha = context.Password;

                AutenticarJogadorResponse response = serviceJogador.AutenticarJogador(request);

                if (serviceJogador.IsInvalid() && response == null)
                {
                    context.SetError("invalid_grant", "Preencha um e-mail válido e uma senha de no mónimo 6 caracteres.");
                    return;
                }

                serviceJogador.ClearNotifications();

                if (response == null)
                {
                    context.SetError("invalid_grant", "Jogador não encontrado!");
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                // Definindo as Claims - responsável por gerar o token
                identity.AddClaim(new Claim("Jogador", JsonConvert.SerializeObject(response)));

                var principal = new GenericPrincipal(identity, new string[] { });

                Thread.CurrentPrincipal = principal;

                context.Validated(identity);

            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", ex.Message);
                return;
            }
        }
    }
}