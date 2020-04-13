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
    [Route("api/customercloud/product/v1")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly BaseLogic<ProductEntity, ProductDTO> _logic;

        public ProductController()
        {
            _logic = new BaseLogic<ProductEntity, ProductDTO>();
        }

        [HttpGet]
        public ActionResult<ProductDTO> Get(Guid id)
        {
            ProductDTO dto = _logic.Read(id);
            if (dto != null)
            {
                return Ok(dto);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProductDTO productDTO)
        {
            try
            {
                _logic.Create(productDTO);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] ProductDTO productDTO)
        {
            try
            {
                _logic.Update(productDTO);
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