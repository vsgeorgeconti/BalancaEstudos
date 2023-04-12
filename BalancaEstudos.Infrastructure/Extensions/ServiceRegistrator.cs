using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BalancaEstudos.Infrastructure.Interfaces;
using BalancaEstudos.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BalancaEstudos.Infrastructure.Extensions
{
    public static class ServiceRegistrator
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IPesagemRepository, PesagemRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
            services.AddTransient<IBalancaRepository, BalancaRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}