using System;
using System.Collections.Generic;
using flowers.Repositories;
using flowers.Models;
using Microsoft.AspNetCore.Mvc;

namespace flowers.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FlowersController : ControllerBase
  {
    private readonly FlowerRepository _fr;
    public FlowersController(FlowerRepository fr)
    {
      _fr = fr;
    }
    //GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
      try
      {
        return Ok(_fr.GetAll());
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }


    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
      return "value";
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
