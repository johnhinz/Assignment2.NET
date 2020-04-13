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
    [Route("api/customercloud/order/v1")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly BaseLogic<OrderEntity, OrderDTO> _logic;

        public OrderController()
        {
            _logic = new BaseLogic<OrderEntity, OrderDTO>();
        }

        [HttpGet]
        public ActionResult<OrderDTO> Get(Guid id)
        {
            OrderDTO dto = _logic.Read(id);
            if (dto != null)
            {
                return Ok(dto);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Post([FromBody] OrderDTO orderDTO)
        {
            try
            {
                _logic.Create(orderDTO);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] OrderDTO orderDTO)
        {
            try
            {
                _logic.Update(orderDTO);
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