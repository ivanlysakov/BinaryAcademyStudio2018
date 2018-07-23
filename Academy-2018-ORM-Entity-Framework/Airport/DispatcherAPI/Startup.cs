using BL.Service.Services;
using DAL.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.DTO;
using DAL.Repository.Repositories;
using DAL.Repository.DataSourсes;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using DAL.Repository.EF;

namespace DAL
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
                                 
            services.AddMvc().AddFluentValidation(); 
            //services from BL
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IService<AirplaneDTO>, AirplanesService>();
            services.AddScoped<IService<AirplaneTypeDTO>, AirplaneTypesService>();
            services.AddScoped<IService<CrewDTO>, AirCrewsService>();
            services.AddScoped<IService<PilotDTO>, PilotsService>();
            services.AddScoped<IService<HostessDTO>, HostessesService>();
            services.AddScoped<IService<FlightDTO>, FlightsService>();
            services.AddScoped<IService<DepartureDTO>, DeparturesService>();
            services.AddScoped<IService<TicketDTO>, TicketsService>();
           
            //automapper
            services.AddAutoMapper();
           
            services.AddDbContext<AirportContext>(options => 
                    options.UseSqlServer(Configuration.GetConnectionString("AirportDatabase")));
          
            



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
