using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WS_ScaneApp.Models.ProjectRequests;
using WS_ScaneApp.Models.ProjectResponses;
using WS_ScaneApp.Services;

namespace WS_ScaneApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        // POST api/<SaleController>
        [HttpPost]
        public IActionResult Post([FromBody] SaleRequest model)
        {
            ProjectResponse response = new();
            try
            {
                _saleService.AddSale(model);
                response.Success = 1;
            }
            catch (Exception)
            {
                response.Success = 0;
            }
            return Ok(response);
        }

        // GET: api/<SaleController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SaleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/<SaleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SaleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
