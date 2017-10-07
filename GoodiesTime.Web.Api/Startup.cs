using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Dependencies;
using GoodiesTime.IOC;
using GoodiesTime.Library;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Cors;
using Microsoft.Practices.Unity;
using Microsoft.Owin.Security.OAuth;

//[assembly: OwinStartup(typeof(GoodiesTime.Web.Api.Startup))]

namespace GoodiesTime.Web.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var httpConfiguration = new HttpConfiguration();

            // Enable Cors
            app.UseCors(CorsOptions.AllowAll);


            var container = new UnityContainer();
            IoC.Resolve(container);
            httpConfiguration.DependencyResolver = new UnityResolver(container);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(container);


            ConfigureOAuth(app);
            WebApiConfig.Register(httpConfiguration);
            //app.UseWebApi(httpConfiguration);
        }

        private void ConfigureOAuth(IAppBuilder app)
        {
            var oAuthOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/bearerToken"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(10),
                Provider = new AuthorizationServerProvider()
            };

            app.UseOAuthAuthorizationServer(oAuthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }

    }

    public class UnityResolver : IDependencyResolver
    {
        protected IUnityContainer container;

        public UnityResolver(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new UnityResolver(child);
        }

        public void Dispose()
        {
            container.Dispose();
        }
    }
}
