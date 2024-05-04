using _VC.Application.Contents;
using _VC.Application.Contents.MailServicesIntr;
using _VC.Application.IHelper.Chat;
using _VC.Application.IHelper.PaymentManagement;
using _VC.Application.IHelper.StokeHolder;
using _VC.Application.IHelper.Supervisor;
using _VC.Application.IHelper.VC;
using _VC.Application.Services.IServices.IStokeHolder;
using _VC.Application.Services.IServicesRepo.StokeHolder;
using _VC.Domain.Contents.Identites;
using _VC.Domain.Contents.MailEntities;
using _VC.Domain.Contents.TokenEntities;
using _VC.Persistance.Helper;
using _VC.Persistance.Helper.Chat;
using _VC.Persistance.Helper.PaymentManagement;
using _VC.Persistance.Helper.StokeHolder;
using _VC.Persistance.Helper.Supervisor;
using _VC.Persistance.Repositories;
using _VC.Persistance.Repositories.MailServicesRep;
using Humanizer;
using MailKit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Persistance
{
    public static class PersistenceContainer
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("connectionString")));


            #region Email 

            services.Configure<OutlookMailSettings>(configuration.GetSection("MailSetting"));
            services.AddScoped<IEmailServices, EmailServices>();

            #endregion

            #region JWT 
            services.Configure<JWT>(configuration.GetSection("JWT"));

            // Authorize for Bearer by Defualt without add to each controller

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = configuration["JWT:Issuer"],
                        ValidAudience = configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"])),
                        ClockSkew = TimeSpan.Zero
                    };
                });
            #endregion




            // DI Identity



            services.AddIdentity<ApplicationUser, IdentityRole>(
               options =>
               {
                   // Default Password settings.
                   options.Password.RequireDigit = true;
                   options.Password.RequireLowercase = true;
                   options.Password.RequireNonAlphanumeric = true;
                   options.Password.RequireUppercase = true;
                   options.Password.RequiredLength = 6;
                   options.Password.RequiredUniqueChars = 1;
               }
               ).AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders()
               .AddDefaultUI();




            // DI

            services.AddScoped(typeof(IBaseRepositories<>), typeof(BaseRepositories<>));
            //services.AddScoped<IHelper, HelperRepositories>();
             services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IForgetPassword, ForgetPassword>();

            // Repo
            services.AddScoped<IVirtualCompany, VirtualCompanyRepo>();
            services.AddScoped<SendListRepo, SendListRepo>();
            services.AddScoped<IEmployeeManagement,EmployeeManagementRepo>();

            services.AddScoped<IDepartment, DepartmentRepo>();
            services.AddScoped<ITaskManagement, TaskManagementRepo>();
            services.AddScoped<IChat, ChatRepo>();

            services.AddScoped<IPaymentManagement, PaymentManagementRepo>();



            // Json
            //services.AddControllers().AddJsonOptions(
            //    options =>
            //    {
            //        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            //    });

            //services.AddControllers().AddNewtonsoftJson(
            //    options =>
            //    {
            //        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //    });


            return services;

        }
    }
}
