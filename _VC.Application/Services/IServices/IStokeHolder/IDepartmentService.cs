using _VC.Application.Features.GeneralResponsive;
using _VC.Application.Services.Dto.StokeHolder.Department.Add;
using _VC.Application.Services.Dto.StokeHolder.Department.AddEmpToDep;
using _VC.Application.Services.Dto.StokeHolder.Department.Update;
using _VC.Application.Services.Dto.StokeHolder.EmployeesManagement.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Services.IServices.IStokeHolder
{
    public interface IDepartmentService
    {
        // Create Dep
        Task<GeneralResponse> AddDepartmentService(DepartmentAddRequest dto);

        // update
        Task<GeneralResponse> UpdateDepartmentService(DepartmentUpdateRequest dto);


        // delete
        Task<GeneralResponse> DeleteDepartmentService(int DepartmentId);


        /////
        ///
        // Get all
        Task<IEnumerable<DepartmentUpdateRequest>> GetAllDepartmentsService();


        // add employee to department
        Task<GeneralResponse> AddEmployeeToDepartemntService(AddEmployeeToDepartmentRequest request);



        // delete employee 
        Task<GeneralResponse> DeleteEmployeeFromDepartemntService(string employeeId);

        // get employee in department
        Task<IEnumerable<EmployeesManagementGetByIdResponse>> GetEmployeesFromDepartemntService(int departmentId);


        // assgin supervisor 
        Task<GeneralResponse> AssignEmployeeToDepartemntService(AddEmployeeToDepartmentRequest request);


    }
}
