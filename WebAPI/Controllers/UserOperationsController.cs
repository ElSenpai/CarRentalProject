using Business.Abstract;
using Core.Entities.Concrete;
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
    public class UserOperationsController : ControllerBase
    {
        IUserOperationService _uOperationService;
        public UserOperationsController(IUserOperationService uOperationService)
        {
            _uOperationService = uOperationService;
        }

        [HttpPost("add")]
        public IActionResult Add(UserOperationClaim operation)
        {
            var result = _uOperationService.Add(operation);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(UserOperationClaim operation)
        {
            var result = _uOperationService.Delete(operation);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);

        }
        [HttpPut("update")]
        public IActionResult Update(UserOperationClaim operation)
        {
            var result = _uOperationService.Update(operation);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _uOperationService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
