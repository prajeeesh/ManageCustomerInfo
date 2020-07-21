using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using CustomerInfo.Contracts;
using CustomerInfo.Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerInfo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private IRepositoryWrapper _repoWrapper;
        public CustomerController(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }
       /// <summary>
       /// Gets all the customers present in the Customer table
       /// </summary>
       /// <returns>List of Customers</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var customers = await _repoWrapper.Customer.FindAll().ToListAsync();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        /// <summary>
        /// Search for the customers based on first name or Last name
        /// </summary>
        /// <param name="Name">First or Last name</param>
        /// <returns>Customers with matching First/ Last name</returns>
        [HttpGet("{Name}")]
        public async Task<IActionResult> Search(string Name)
        {
            try
            {
                var customers = await _repoWrapper.Customer.FindByCondition(c => c.FirstName== Name || c.LastName == Name).ToListAsync();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        /// <summary>
        /// Add new Customer
        /// </summary>
        /// <param name="customer">New customer details</param>
        /// <returns></returns>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult>Add([FromBody] Customer customer)
        {
           try
            {
                if(customer == null)
                {
                    return BadRequest("Customer object is null");
                }

                await Task.Run(() => _repoWrapper.Customer.Create(customer));
                await Task.Run(() => _repoWrapper.Save());
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return StatusCode(201);
        }
        /// <summary>
        /// Updates the customer with the given Id
        /// </summary>
        /// <param name="Id">Customer Id whose details needs to be deleted</param>
        /// <param name="customer">Customer details</param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        public async Task<IActionResult>Edit(int Id,[FromBody] Customer customer)
        {
           try
            {
                var cust = _repoWrapper.Customer.FindByCondition(c => c.Id == Id);
                if(cust == null)
                {
                    return BadRequest("No customer found with the given Id");
                }
                await Task.Run(() => _repoWrapper.Customer.Update(customer));
                await Task.Run(() => _repoWrapper.Save());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok();
        }
        /// <summary>
        /// Delete customer
        /// </summary>
        /// <param name="Id">Customer Id whose details needs to be deleted</param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var customer = _repoWrapper.Customer.FindByCondition(c => c.Id == Id).FirstOrDefault();

                await Task.Run(() => _repoWrapper.Customer.Delete(customer));
                await Task.Run(() => _repoWrapper.Save());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok();
        }
    }
}