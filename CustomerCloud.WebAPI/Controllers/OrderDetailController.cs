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
    [Route("api/customercloud/orderdetail/v1")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly BaseLogic<OrderDetailEntity, OrderDetailDTO> _logic;

        public OrderDetailController()
        {
            _logic = new BaseLogic<OrderDetailEntity, OrderDetailDTO>();
        }

        [HttpGet]
        public ActionResult<OrderDetailDTO> Get(Guid id)
        {
            OrderDetailDTO dto = _logic.Read(id);
            if (dto != null)
            {
                return Ok(dto);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Post([FromBody] OrderDetailDTO orderDetailsDTO)
        {
            try
            {
                _logic.Create(orderDetailsDTO);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] OrderDetailDTO orderDetailsDTO)
        {
            try
            {
                _logic.Update(orderDetailsDTO);
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