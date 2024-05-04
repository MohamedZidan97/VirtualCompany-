using _VC.Application.Contents;
using _VC.Application.Features.GeneralResponsive;
using _VC.Application.IHelper.StokeHolder;
using _VC.Application.Services.Dto.StokeHolder.Department.Add;
using _VC.Application.Services.Dto.StokeHolder.Department.AddEmpToDep;
using _VC.Application.Services.Dto.StokeHolder.Department.Update;
using _VC.Application.Services.Dto.StokeHolder.EmployeesManagement.GetById;
using _VC.Application.Services.IServices.IStokeHolder;
using _VC.Domain.Data.Department;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Services.IServicesRepo.StokeHolder
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartment rep2;
        private readonly IBaseRepositories<Department> rep;
        private readonly IMapper mapper;

        public DepartmentService(IDepartment rep2, IBaseRepositories<Department> rep, IMapper mapper)
        {
            this.rep2 = rep2;
            this.rep = rep;
            this.mapper = mapper;
        }

        // Create Dep
        public async Task<GeneralResponse> AddDepartmentService(DepartmentAddRequest dto)
            => await rep.AddAsync(mapper.Map<Department>(dto));



        // update

        public async Task<GeneralResponse> UpdateDepartmentService(DepartmentUpdateRequest dto)
            => await rep.UpdateAsync(mapper.Map<Department>(dto));


        // delete

        public async Task<GeneralResponse> DeleteDepartmentService(int DepartmentId)
            => await rep.DeleteAsync(DepartmentId);

        /////
        ///
        // Get all
        public async Task<IEnumerable<DepartmentUpdateRequest>> GetAllDepartmentsService()
            => mapper.ProjectTo<DepartmentUpdateRequest>((await rep.GetAllAsync()).AsQueryable());



        // add employee to department
        public async Task<GeneralResponse> AddEmployeeToDepartemntService(AddEmployeeToDepartmentRequest request)
          => await rep2.AddEmployeeToDepartemntAsync(request);


        // delete employee 
        public async Task<GeneralResponse> DeleteEmployeeFromDepartemntService(string employeeId)
            => await rep2.DeleteEmployeeFromDepartemntAsync(employeeId);

        // get employee in department
        public async Task<IEnumerable<EmployeesManagementGetByIdResponse>> GetEmployeesFromDepartemntService(int departmentId)
            => await rep2.GetEmployeeFromDepartemntAsync(departmentId);

        // assgin supervisor 
        public async Task<GeneralResponse> AssignEmployeeToDepartemntService(AddEmployeeToDepartmentRequest request)
            => await rep2.AssignEmployeeToDepartemntAsync(request);



    }
}
