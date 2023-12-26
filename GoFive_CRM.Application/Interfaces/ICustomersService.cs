using GoFive_CRM.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFive_CRM.Application.Interfaces
{
    public interface ICustomersService
    {
        Task<IEnumerable<CustomerModel>> GetListAsync();
        Task<CustomerModel> GetListById(int Id);
        Task<CustomerModel> CreateAsync(CustomerModel newCustomer);
        Task<CustomerModel> UpdateAsync(int id, CustomerModel updatedCustomer);
        Task<CustomerModel> DeleteAsync(int id);
    }
}
