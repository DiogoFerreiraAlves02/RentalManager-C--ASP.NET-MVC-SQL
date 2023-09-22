using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGestor {

    public class Startup {

        public IHostEnvironment _ihe { get; set; }
        public IConfiguration _ic { get; set; }

        public Startup(IConfiguration configuration, IHostEnvironment ihe) {
            _ihe = ihe;
            _ic = configuration;
            Program.ligacao = _ic.GetValue<string>("Ligacoes:LigacaoDefault");
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddSession(s => s.IdleTimeout = TimeSpan.FromMinutes(20));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(name: "default",
                    pattern: "{controller=Portal}/{action=Index}/{id?}");
            });
        }
    }
}
