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
using Roomies.API.Domain.Persistence.Contexts;
using Roomies.API.Domain.Repositories;
using Roomies.API.Domain.Services;
using Roomies.API.Persistence.Repositories;
using Roomies.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roomies.API
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

            services.AddControllers();

            // DbContext Configuration
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });

            // Dependency Injection Configuration
            services.AddScoped<IConversationRepository, ConversationRepository>();
            services.AddScoped<IFavouritePostRepository, FavouritePostRepository>();
            services.AddScoped<ILandlordRepository, LandlordRepository>();
            services.AddScoped<ILeaseholderRepository, LeaseholderRepository>();
            services.AddScoped<IMessageRepository,MessageRepository >();
            services.AddScoped <IPaymentMethodRepository,PaymentMethodRepository>();
            services.AddScoped <IPlanRepository,PlanRepository>();
            services.AddScoped <IPostRepository,PostRepository>();
            services.AddScoped <IReviewRepository,ReviewRepository>();
            services.AddScoped <IUserPaymentMethodRepository,UserPaymentMethodRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IConversationService, ConversationService>();
            services.AddScoped<IFavouritePostService, FavouritePostService>();
            services.AddScoped<ILandlordService, LandlordService>();
            services.AddScoped<ILeaseholderService, LeaseholderService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped <IPaymentMethodService,PaymentMethodService > ();
            services.AddScoped <IPlanService,PlanService > ();
            services.AddScoped <IPostService,PostService > ();
            services.AddScoped <IReviewService,ReviewService > ();
            services.AddScoped <IUserPaymentMethodService,UserPaymentMethodService > ();
            //services.AddScoped <Iuser, > ();

            // Endpoints Case Conventions Configuration

            services.AddRouting(options => options.LowercaseUrls = true);

            // AutoMapper initialization
            services.AddAutoMapper(typeof(Startup));


            // Documentation Setup
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Roomies.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Roomies.API v1"));
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
