using GoFive_CRM.Core.Entites;
using GoFive_CRM.Core.Repositories;
using GoFive_CRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFive_CRM.Infrastructure.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly GoFive_CRMDbContext _context;
        public CustomersRepository(GoFive_CRMDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customers>> GetAllListAsync()
        {
            return await _context.customers.ToListAsync();
        }
        public async Task<Customers> GetCustomerById(int Id)
        {
            try
            {
                var customers = await _context.customers.SingleOrDefaultAsync(i => i.ID == Id);

                if (customers != null)
                {
                    return customers;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Customers> CreateAsync(Customers newCustomer)
        {
            _context.customers.Add(newCustomer);
            await _context.SaveChangesAsync();

            return newCustomer; 
        }
        public async Task<Customers> UpdateAsync(Customers updatedCustomer)
        {
            _context.customers.Update(updatedCustomer);             
            await _context.SaveChangesAsync();

            return updatedCustomer;
        }
        public async Task<bool> DeleteAsync(int id)
        { 
            var customerToDelete = await _context.customers.FindAsync(id);
            if (customerToDelete == null)
            {
                return false;
            }
            _context.customers.Remove(customerToDelete);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
