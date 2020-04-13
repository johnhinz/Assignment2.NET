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
    [Route("api/customercloud/address/v1")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly BaseLogic<AddressEntity, AddressDTO> _logic;

        public AddressController()
        {
            _logic = new BaseLogic<AddressEntity, AddressDTO>();
        }

        [HttpGet]
        public ActionResult<AddressDTO> Get(Guid id)
        {
            AddressDTO dto = _logic.Read(id);
            if (dto != null)
            {
                return Ok(dto);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Post([FromBody] AddressDTO addressDTO)
        {
            try
            {
                _logic.Create(addressDTO);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] AddressDTO addressDTO)
        {
            try
            {
                _logic.Update(addressDTO);
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