﻿using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using SportsStore.Infrastructure.Identity;

[assembly: OwinStartup(typeof(SportsStore.IdentityConfig))]
namespace SportsStore
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<StoreIdentityDbContext>(StoreIdentityDbContext.Create);
            app.CreatePerOwinContext<StoreUserManager>(StoreUserManager.Create);
            app.CreatePerOwinContext<StoreRoleManager>(StoreRoleManager.Create);

            //setea las cookies para los requests
            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            //});

            //use our authentication on StoreAuthProvider
            app.UseOAuthBearerTokens(new OAuthAuthorizationServerOptions
            {
                Provider = new StoreAuthProvider(),
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/Authenticate")
            });

        }
    }
}