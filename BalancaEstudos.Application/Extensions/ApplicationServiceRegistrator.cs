using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalancaEstudos.Application.Interfaces;
using BalancaEstudos.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BalancaEstudos.Application.Extensions
{
    public static class ApplicationServiceRegistrator
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IPedidoService, PedidoService>();
            services.AddTransient<IPesagemService, PesagemService>();
            services.AddTransient<IBalancaService, BalancaService>();

        }
    }
}