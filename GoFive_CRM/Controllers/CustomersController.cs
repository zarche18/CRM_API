using Azure.Core;
using GoFive_CRM.Application.Interfaces;
using GoFive_CRM.Application.Models;
using GoFive_CRM.Application.Services;
using GoFive_CRM.Core.Entites;
using GoFive_CRM.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoFive_CRM.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomersController : ControllerBase
    {
        private ICustomersService _customerServices;
        public CustomersController(ICustomersService customerService)
        {
            _customerServices = customerService;
        } 

        [HttpGet("GetAllCustomerList")]
        public async Task<ActionResult<IEnumerable<CustomerModel>>> GetAllCustomerList( int page = 1,int pageSize = 10,string emailFilter = null,string sortBy = "Name",
        bool descending = false)
        {
            try
            { 
                if (page <= 0 || pageSize <= 0)
                {
                    return BadRequest("Invalid page or pageSize values");
                }
                var skip = (page - 1) * pageSize;
                var customers = await _customerServices.GetListAsync();                 
                if (!string.IsNullOrEmpty(emailFilter))
                {
                    customers = customers.Where(c => c.Email.Contains(emailFilter, StringComparison.OrdinalIgnoreCase));
                }
                 
                switch (sortBy.ToLower())
                {
                    case "name":
                        customers = descending ? customers.OrderByDescending(c => c.Name) : customers.OrderBy(c => c.Name);
                        break;
                    case "email":
                        customers = descending ? customers.OrderByDescending(c => c.Email) : customers.OrderBy(c => c.Email);
                        break; 
                    default: 
                        customers = customers.OrderBy(c => c.Name);
                        break;
                }
                 
                return Ok(customers.Skip(skip).Take(pageSize));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse
                {
                    IsSuccess = false,
                    ResponseMessage = e.Message
                });
            }
        }

        [HttpGet("GetCustomerById")]
        public async Task<ActionResult<Customers>> GetCustomerById(int id)
        {
            try
            {
                var customers = await _customerServices.GetListById(id);

                if (customers == null)
                {

                    return Ok(new ErrorResponse() { IsSuccess = false, ResponseCode = "003", ResponseMessage = $"Customer ID \"{id}\" not found" });
                }
                else
                {
                    return Ok(customers);
                }

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse
                {
                    IsSuccess = false,
                    ResponseMessage = e.Message
                });
            }
        }
       
        [HttpPost("CreateCustomer")]
        public async Task<ActionResult<CustomerModel>> CreateCustomer([FromBody] Customers customer)
        {
            try
            {
                if (customer == null)
                {
                    return Ok(new ErrorResponse() { IsSuccess = false, ResponseCode = "003", ResponseMessage = $"Invalid customer data" }); 
                }
                 
                var customerModel = new CustomerModel(customer);

                ModelState.Clear();
                TryValidateModel(customerModel);
                if (!ModelState.IsValid)
                    return Ok(new ErrorResponse<Dictionary<string, List<string>>>()
                    {
                        IsSuccess = false,
                        ResponseCode = "002",
                        ResponseMessage = $"Invalid request. {string.Join(" | ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))}",
                        Error = ModelState.ToDictionary(key => key.Key, value => value.Value.Errors.Select(i => i.ErrorMessage).ToList())
                    });


                var createdCustomer = await _customerServices.CreateAsync(customerModel);
                if (createdCustomer == null)
                    return Ok(new ErrorResponse() { IsSuccess = false, ResponseCode = "007", ResponseMessage = string.Format("An error occur during creating the customer.") });

                return Ok(new CreateCustomerResponse()
                {
                    IsSuccess = true,
                    ResponseCode = "0",
                    ResponseMessage = "Successfully Created Customer!",
                    Data = createdCustomer
                });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse
                {
                    IsSuccess = false,
                    ResponseMessage = e.Message
                });
            }
        }
        
        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] CustomerModel updatedCustomerModel)
        {
            try
            { 
                if (updatedCustomerModel == null)
                {
                    return BadRequest("Invalid customer data");
                }

                ModelState.Clear();
                TryValidateModel(updatedCustomerModel);
                if (!ModelState.IsValid)
                    return Ok(new ErrorResponse<Dictionary<string, List<string>>>()
                    {
                        IsSuccess = false,
                        ResponseCode = "002",
                        ResponseMessage = $"Invalid request. {string.Join(" | ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))}",
                        Error = ModelState.ToDictionary(key => key.Key, value => value.Value.Errors.Select(i => i.ErrorMessage).ToList())
                    });

                var updatedCustomer = await _customerServices.UpdateAsync(id, updatedCustomerModel);
                if (updatedCustomer != null)
                {
                    return Ok(updatedCustomer);
                }
                else
                {
                    // Handle the case where the customer with the given ID is not found
                    return NotFound("Customer not found");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse
                {
                    IsSuccess = false,
                    ResponseMessage = e.Message
                });
            }
        }
      
        [HttpDelete("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var deletedCustomer = await _customerServices.DeleteAsync(id);                 
                if (deletedCustomer == null)
                {
                    return NotFound("Customer not found");
                }
                
                return Ok(new BaseResponse<bool>
                {
                    IsSuccess = true,
                    Data = true // Indicate successful deletion
                });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse
                {
                    IsSuccess = false,
                    ResponseMessage = e.Message
                });
            }
        }
    }
}
