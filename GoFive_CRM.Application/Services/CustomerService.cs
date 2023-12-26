using AutoMapper.Internal.Mappers;
using GoFive_CRM.Application.Interfaces;
using GoFive_CRM.Application.Mapper;
using GoFive_CRM.Application.Models;
using GoFive_CRM.Core.Entites;
using GoFive_CRM.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GoFive_CRM.Application.Services
{
    public class CustomerService : ICustomersService
    {
        private readonly ICustomersRepository _customersRepository;

        public CustomerService(ICustomersRepository customerRepository)
        {
            _customersRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
        }

        public async Task<IEnumerable<CustomerModel>> GetListAsync()
        {
            try
            {
                var result = await _customersRepository.GetAllListAsync();

                var mapped = ObjectMapper.Mapper.Map<IEnumerable<CustomerModel>>(result);
                return mapped;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<CustomerModel> GetListById(int Id)
        {
            try
            {
                var result = await _customersRepository.GetCustomerById(Id);

                var mapped = ObjectMapper.Mapper.Map<CustomerModel>(result);
                return mapped;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<CustomerModel> CreateAsync(CustomerModel newCustomerModel)
        {
            var newCustomerEntity = new Customers
            { 
                Name = newCustomerModel.Name,
                Email = newCustomerModel.Email,
                Phone = newCustomerModel.Phone,
                Address = newCustomerModel.Address,
                Notes = newCustomerModel.Notes
            };

            var createdCustomerEntity = await _customersRepository.CreateAsync(newCustomerEntity); 
            return new CustomerModel(createdCustomerEntity);
        }
        public async Task<CustomerModel> UpdateAsync(int id, CustomerModel updatedCustomer)
        {
            var existingCustomer = await _customersRepository.GetCustomerById(id);

            if (existingCustomer == null)
            {
                return null;
            }

            existingCustomer.Name = updatedCustomer.Name;
            existingCustomer.Email = updatedCustomer.Email;
            existingCustomer.Phone = updatedCustomer.Phone;
            existingCustomer.Address = updatedCustomer.Address;
            existingCustomer.Notes = updatedCustomer.Notes;

            var updatedCustomerEntity = await _customersRepository.UpdateAsync(existingCustomer);

            return new CustomerModel(updatedCustomerEntity);
        }
        public async Task<CustomerModel> DeleteAsync(int id)
        { 
            var customerToDelete = await _customersRepository.GetCustomerById(id);             
            if (customerToDelete == null)
            {
                return null;
            }
             
            await _customersRepository.DeleteAsync(customerToDelete.ID);             
            return new CustomerModel(customerToDelete);
        }
    }
}
