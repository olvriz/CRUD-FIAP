using Microsoft.Extensions.DependencyInjection;
using Fiap.Domain.Auth;
using Fiap.Domain.DomainService;
using Fiap.Domain.DomainServiceInterface;
using Fiap.Domain.RepositoryInterface;
using Fiap.Domain.ServiceInterface;
using Fiap.Infra.Data.Context;
using Fiap.Infra.Data.Repository;
using Fiap.Infra.Data.Service;

namespace Fiap.Infra.IoC
{
    public class Injector
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserLogged, UserLogged>();

            services.AddSingleton<OrcContext, OrcContext>();

            services.AddTransient<ICriminalRepository, CriminalRepository>();
            services.AddTransient<IVictimRepository, VictimRepository>();
            services.AddTransient<ICrimeRepository, CrimeRepository>();

            services.AddTransient<ICriminalDomainService, CriminalDomainService>();
            services.AddTransient<IVictimDomainService, VictimDomainService>();
            services.AddTransient<ICrimeDomainService, CrimeDomainService>();

            services.AddTransient<IAuthenticatorService, AuthenticatorService>();
        }
    }
}
