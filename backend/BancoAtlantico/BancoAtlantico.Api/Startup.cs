using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BancoAtlantico.Domain.Commands;
using BancoAtlantico.Domain.Handlers;
using BancoAtlantico.Domain.Handlers.Contracts;
using BancoAtlantico.Domain.Repositories;
using BancoAtlantico.Infra.Contexts;
using BancoAtlantico.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace BancoAtlantico.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<DataContext>(c => c.UseInMemoryDatabase("Register"));

            services.AddTransient<ICedulaRepository, CedulaRepository>();
            services.AddTransient<ICedulaEstoqueRepository, CedulaEstoqueRepository>();
            services.AddTransient<ICaixaEletronicoRepository, CaixaEletronicoRepository>();
            services.AddTransient<IHandler<CriarCedulaCommand>, CriarCedulaCommandHandler>();
            services.AddTransient<IHandler<CriarCaixaEletronicoCommand>, CriarCaixaEletronicoCommandHandler>();
            services.AddTransient<IHandler<DesativarCaixaEletronicoCommand>, DesativarCaixaEletronicoCommandHandler>();
            services.AddTransient<IHandler<SaqueCommand>, SaqueCommandHandler>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BancoAtlantico.Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BancoAtlantico.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
