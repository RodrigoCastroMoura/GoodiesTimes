using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using GoodiesTime.IOC;
using GoodiesTime.Domain.Interfaces.Services;
using System.Security.Claims;


namespace GoodiesTimes.Library.web
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {

        private Itb_partnersServices partners;

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var Container = new UnityContainer();
            IoC.Resolve(Container);
            partners = Container.Resolve<Itb_partnersServices>();

            var user = partners.Autenticaçao(context.UserName, context.Password);
            Container.Dispose();

            if (user == null)
            {
                context.SetError("invalid_grant", "Not Found ");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Role, "Partners"));
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));
            identity.AddClaim(new Claim(ClaimTypes.Hash, user.id_partners.ToString()));


            var props = new AuthenticationProperties(new Dictionary<string, string>
            {
              { "id", user.id_partners.ToString()},

            });

            var ticket = new AuthenticationTicket(identity, props);

            context.Validated(ticket);
 
           
        }
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
    }
}
