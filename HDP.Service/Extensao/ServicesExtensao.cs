﻿using HDP.Application;
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
            services.AddScoped<IDepartamentoService, DepartamentoService>();
            services.AddScoped<ICargoService, CargoService>();
            services.AddScoped<IPerfilService, PerfilService>();
            services.AddScoped<IAutenticationService, AutenticationService>();



            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



            return services;
        }
    }
}
