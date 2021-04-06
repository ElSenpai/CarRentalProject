using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public class BrandsController : ControllerBase
        {
            IOrderService _orderService;

            public BrandsController(IOrderService orderService)
            {
                _orderService = orderService;
            }

            [HttpPost("add")]
            public IActionResult Add(Order order)
            {
                var result = _orderService.Add(order);
                if (result.Success)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            [HttpPost("delete")]
            public IActionResult Delete(Order order)
            {
                var result = _orderService.Delete(order);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);

            }
            [HttpPost("update")]
            public IActionResult Update(Order order)
            {
                var result = _orderService.Update(order);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            [HttpGet("getall")]
            public IActionResult GetAll()
            {
                var result = _orderService.GetAll();
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            //[HttpGet("getbyid")]
            //public IActionResult GetByCardId(int id)
            //{
            //    var result = _orderService.GetByCarddId(id);
            //    if (result.Success)
            //    {
            //        return Ok(result);
            //    }
            //    return BadRequest(result);
            //}
        }
    }
}
