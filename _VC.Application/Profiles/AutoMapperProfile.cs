using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _VC.Application.Features.Account.Commends.Register;
using _VC.Application.Features.Account.Queries;
using _VC.Application.Services.Dto.Chat.Add;
using _VC.Application.Services.Dto.Chat.GetAllMesByVCId;
using _VC.Application.Services.Dto.Employee;
using _VC.Application.Services.Dto.HelpAndSupport.Add;
using _VC.Application.Services.Dto.PaymentManagement.Add;
using _VC.Application.Services.Dto.StokeHolder;
using _VC.Application.Services.Dto.StokeHolder.Department.Add;
using _VC.Application.Services.Dto.StokeHolder.Department.AddEmpToDep;
using _VC.Application.Services.Dto.StokeHolder.Department.Update;
using _VC.Application.Services.Dto.StokeHolder.EmployeesManagement.GetById;
using _VC.Application.Services.Dto.StokeHolder.VirtualCompany;
using _VC.Application.Services.Dto.StokeHolder.VirtualMachine.Add;
using _VC.Application.Services.Dto.StokeHolder.VirtualMachine.Get;
using _VC.Application.Services.Dto.StokeHolder.VirtualMachine.GetById;
using _VC.Application.Services.Dto.StokeHolder.VirtualMachine.Update;
using _VC.Application.Services.Dto.Supervisor.Task.Add;
using _VC.Application.Services.Dto.Supervisor.Task.GetAllTaskByEmpId;
using _VC.Domain.Contents.Identites;
using _VC.Domain.Data.Chat;
using _VC.Domain.Data.Department;
using _VC.Domain.Data.HelpAnSupport;
using _VC.Domain.Data.PaymentModel;
using _VC.Domain.Data.Task;
using _VC.Domain.Data.VM;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace _VC.Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // VM
            CreateMap<VirtualMachine, VirtualMachineAddRequest>().ReverseMap();


            CreateMap<VirtualMachineGetByIdResponse, VirtualMachine>().ReverseMap();

            CreateMap<VirtualMachineUpdateRequest, VirtualMachine>().ReverseMap();

            CreateMap<VirtualMachineGetResponse, VirtualMachine>().ReverseMap();

            CreateMap<VirtualCompanyUpdateRequest, VirtualCompany>().ReverseMap(); 

            // Employee

            CreateMap<EmployeesManagementGetByIdResponse, ApplicationUser>().ReverseMap();


            // Department

            CreateMap<DepartmentAddRequest, Department>().ReverseMap();
            CreateMap<DepartmentUpdateRequest, Department>().ReverseMap();
            CreateMap<EmployeeDepartment, AddEmployeeToDepartmentRequest>().ReverseMap();

            // task
            CreateMap<AddTask,TaskAddRequest>().ReverseMap();
            CreateMap<AddTask, TaskGetAllTaskByEmpoyeeIdResponse>().ReverseMap();

            // employee 
            CreateMap<AddTask, TaskUpdateOrExecuteRequest>().ReverseMap();

            // chat 
            CreateMap<AddMessage,MessageAddRequest>().ReverseMap();
            CreateMap<MessageGetAllMessageByVirtualCompanyId,AddMessage>().ReverseMap();

            // support

            CreateMap<Support,HelpAndSupportAddRequest>().ReverseMap();

            // payment
            CreateMap<Payment,PaymentRequest>().ReverseMap();



            #region Account 
            // Register
            //  CreateMap<AccountGeneralResponse, AccountRegisterRequest>().ReverseMap();
            #endregion
        }
    }
}
