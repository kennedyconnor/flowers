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
    public ActionResult<IEnumerable<Flower>> Get()
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
    public ActionResult<Flower> Get(int id)
    {
      try
      {
        return Ok(_fr.GetById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // POST api/values
    [HttpPost]
    public ActionResult<IEnumerable<Flower>> Post([FromBody] Flower data)
    {
      try
      {
        return Ok(_fr.Create(data));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public ActionResult<Flower> Put(int id, [FromBody] Flower data)
    {
      try
      {
        data.Id = id;
        return Ok(_fr.Update(data));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult<Flower> Delete(int id)
    {
      try
      {
        return Ok(_fr.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
  }
}
