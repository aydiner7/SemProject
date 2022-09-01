using Bussiness.Abstract;
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
    public class IpChecksController : ControllerBase
    {
        IIpCheckService _ipCheckService;

        public IpChecksController(IIpCheckService ipCheckService)
        {
            _ipCheckService = ipCheckService;
        }

        [HttpGet("getbyip")]
        public IActionResult GetById(string ip)
        {
            var result = _ipCheckService.GetById(ip);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpPost("add")]
        public IActionResult Add(IpCheck ipCheck)
        {
            var result = _ipCheckService.Add(ipCheck);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(IpCheck ipCheck)
        {
            var result = _ipCheckService.Update(ipCheck);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
