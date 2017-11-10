using Owin;
using IdentityServer3.Core.Configuration;

namespace IdSrv
{
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var options = new IdentityServerOptions
            {
                Factory = new IdentityServerServiceFactory()
                            .UseInMemoryClients(Clients.Get())
                            .UseInMemoryScopes(Scopes.Get())
                            .UseInMemoryUsers(Users.Get()),

                LoggingOptions = new LoggingOptions { EnableHttpLogging = true, EnableKatanaLogging = true, EnableWebApiDiagnostics = true },
                EventsOptions = new EventsOptions { RaiseErrorEvents = true, RaiseFailureEvents = true, RaiseInformationEvents = true, RaiseSuccessEvents = true },

                RequireSsl = false
            };

            app.UseIdentityServer(options);
        }
    }
}