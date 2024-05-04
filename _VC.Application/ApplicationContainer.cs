using _VC.Application.IHelper.StokeHolder;
using _VC.Application.Services.IServices.IChat;
using _VC.Application.Services.IServices.IEmployee;
using _VC.Application.Services.IServices.IHelpAndSupport;
using _VC.Application.Services.IServices.IPaymentManagement;
using _VC.Application.Services.IServices.IStokeHolder;
using _VC.Application.Services.IServices.ISupervisor;
using _VC.Application.Services.IServicesRepo.ChatService;
using _VC.Application.Services.IServicesRepo.EmployeeService;
using _VC.Application.Services.IServicesRepo.HelpAndSupport;
using _VC.Application.Services.IServicesRepo.PaymentManagement;
using _VC.Application.Services.IServicesRepo.StokeHolder;
using _VC.Application.Services.IServicesRepo.SupervisorService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application
{

    public static class ApplicationContainer
    {

        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


            services.AddScoped<IVirtualMachineService, VirtualMachineService>();
            services.AddScoped<IEmployeesManagementService, EmployeesManagementService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ITaskManagementService, TaskManagementService>();

            services.AddScoped<ITaskExecutionService, TaskExecutionService>();

            services.AddScoped<IChatService, ChatService>();

            services.AddScoped<IHelpAndSupportService, HelpAndSupportService>();

            services.AddScoped<IPaymentManagementService,PaymentManagementService>();  

            return services;
        }

    }
}
