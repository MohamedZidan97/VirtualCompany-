using _VC.Application.Features.GeneralResponsive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _VC.Application.Contents
{
    public interface IBaseRepositories<T>
    {
        // Add
        Task<GeneralResponse> AddAsync(T entity);

        // Read
        Task<T> GetByIdAsync(int id);

        // Get all By Id

        //  Task<IEnumerable<T>> GetAllByIdAsync(int id);

        // Get all
        Task<IEnumerable<T>> GetAllAsync();

        // Update
        Task<GeneralResponse> UpdateAsync(T entity);

        // Delete
        Task<GeneralResponse> DeleteAsync(int id);


    }
}
