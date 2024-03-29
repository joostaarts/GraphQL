﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;

using Microsoft.AspNetCore.Hosting;
using GraphQlPlayground.Data;
using GraphQlPlayground.Data.Repositories;
using GraphQlPlayground.GraphQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQlPlayground.Services.Notification;

namespace GraphQlPlayground
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<CourseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CourseDatabase")));

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));

            services.AddSingleton<StudentAddedNotificationService>();
            services.AddScoped<EnrollmentRepository>();
            services.AddScoped<StudentRepository>();
            services.AddScoped<CourseSchema>();
            services
            .AddGraphQL(o =>
            {
                o.ExposeExceptions = true;
            }).AddGraphTypes(ServiceLifetime.Scoped)
            .AddDataLoader()
            .AddWebSockets();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseWebSockets();
            app.UseGraphQL<CourseSchema>();
            app.UseGraphQLWebSockets<CourseSchema>("/graphql");
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

    }
}
