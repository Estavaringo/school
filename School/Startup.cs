using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using School.Helpers;
using School.Models.Database;
using School.Services;
using School.Services.Interfaces;
using System.Reflection;

namespace School
{
    public class Startup
    {

        private const string CurrentAppVersion = "v1";
        private string AppName { get; } = Assembly.GetExecutingAssembly().GetName().Name;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SchoolContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddControllers();

            services.AddLogging();

            services.AddTransient<IDataRepository<Aluno>, AlunoRepository>();
            services.AddTransient<IDataRepository<Professor>, ProfessorRepository>();
            services.AddTransient<IDataRepository<Grade>, GradeRepository>();
            services.AddTransient<IDataRepository<Matricula>, MatriculaRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(CurrentAppVersion, new OpenApiInfo { Title = AppName, Version = CurrentAppVersion });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{AppName} {CurrentAppVersion}");
                c.RoutePrefix = string.Empty;
            });


            app.UseMiddleware<ErrorHandlingMiddleware>();

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
