using HDP.Application;
using HDP.Application.Interfaces;
using HDP.Core.Interface;
using HDP.Infra.Repositorio;

namespace HDP.Service.Extensao
{
    public static class ServicesExtensao
    {
        public static IServiceCollection AdicionarApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositorioGenerico<>), typeof(RepositorioGenerico<>));
            services.AddScoped<ICategoriaService, CategoriaService>();



            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



            return services;
        }
    }
}
