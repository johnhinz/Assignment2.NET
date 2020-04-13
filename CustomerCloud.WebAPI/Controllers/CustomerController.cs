using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerCloud.DTOs;
using CustomerCloud.Entities;
using CustomerCloud.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerCloud.WebAPI.Controllers
{
    [Route("api/customercloud/customer/v1")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly BaseLogic<CustomerEntity, CustomerDTO> _logic;

        public CustomerController()
        {
            _logic = new BaseLogic<CustomerEntity, CustomerDTO>();
        }

        [HttpGet]
        public ActionResult<CustomerDTO> Get(Guid id)
        {
            CustomerDTO dto = _logic.Read(id);
            if (dto != null)
            {
                return Ok(dto);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Post([FromBody] CustomerDTO customerDTO)
        {
            try
            {
                _logic.Create(customerDTO);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] CustomerDTO customerDTO)
        {
            try
            {
                _logic.Update(customerDTO);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _logic.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(500);

            }


        }
    }
}