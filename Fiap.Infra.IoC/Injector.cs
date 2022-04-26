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

            services.AddSingleton<MsSqlContext, MsSqlContext>();

            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IAccountDomainService, AccountDomainService>();
            services.AddTransient<IUserDomainService, UserDomainService>();

            services.AddTransient<IAuthenticatorService, AuthenticatorService>();
        }
    }
}
