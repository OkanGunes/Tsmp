using System.Reflection;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Swashbuckle.AspNetCore.Swagger;
using Tsmp.User.API.Behaviors;
using Tsmp.User.API.Filters;
using Tsmp.User.Domain;
using Tsmp.User.Infrastructure;
using FluentValidation;
using Tsmp.User.Domain.Services;
using Tsmp.User.Infrastructure.Services;

namespace Tsmp.User.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));

            services
                .AddMvcCore(options =>
                {
                    options.Filters.Add(typeof(CustomExceptionFilterAttribute));
                    options.ModelValidatorProviders.Clear();
                })
                .AddJsonFormatters()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddApiExplorer();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Tsmp User API", Version = "v1" });
            });

            var client = new MongoClient("mongodb://localhost:27017");
            var userDb = client.GetDatabase("User");
            services.AddSingleton(userDb);
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPasswordRepository, PasswordRepository>();

            services.AddSingleton<IPasswordHelper, SHA256PasswordHelper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tsmp User API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();
        }
    }
}
