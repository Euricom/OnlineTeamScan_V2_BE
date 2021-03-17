using API.Validators.TeamValidators;
using BL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using API.Authentication;

namespace API
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
                options.AddDefaultPolicy(
                             builder =>
                             {
                                 builder.AllowAnyOrigin();
                                 builder.AllowAnyMethod();
                                 builder.AllowAnyHeader();
                             });
            });

            services.RegisterContext(Configuration.GetConnectionString("OnlineTeamScanConnectionString"));
            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<TeamCreateValidator>());
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.SetupRepositories();            
            services.AddServices();

            services.SetupAuthentication(Configuration);
        }
       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();
            /*app.UseCors(MyAllowSpecificOrigins);*/

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
