using GoFive_CRM.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFive_CRM.Core.Repositories
{
    public interface ICustomersRepository
    {
        Task<IEnumerable<Customers>> GetAllListAsync();
        Task<Customers> GetCustomerById(int Id);
        Task<Customers> CreateAsync(Customers newCustomer);
        Task<Customers> UpdateAsync(Customers updatedCustomer);
        Task<bool> DeleteAsync(int id);
    }
}
