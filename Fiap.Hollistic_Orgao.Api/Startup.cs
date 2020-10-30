using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.Hollistic_Orgao.Web.Persistencia;
using Fiap.Hollistic_Orgao.Web.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Fiap.Hollistic_Orgao.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors();
           
            
            services.AddDbContext<DoacaoContext>(o => o.UseSqlServer(Configuration.GetConnectionString("conexao")));
            services.AddScoped<IPacienteRepository, PacienteRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IHospitalRepository, HospitalRepository>();
            services.AddScoped<IExameRepository, ExameRepository>();
            services.AddScoped<IOrgaoRepository, OrgaoRepository>();
            
            services.AddControllersWithViews();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

               
            app.UseCors(o => o.WithOrigins("*").WithMethods("*").WithHeaders("*"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("MyPolicy");

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllers();
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Usuario}/{action=Login}/{id?}");
            });

            app.UseStaticFiles();
            app.UseDefaultFiles();
        }
    }
}
