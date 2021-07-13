using System.Collections.Generic;
using gregsdotnet.Models;
using gregsdotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace gregsdotnet.Controllers
{
  [ApiController]
  [Route("api/[controller]")]


  public class CarsController : ControllerBase
  {
    private readonly CarsService _cs;

    public CarsController(CarsService cs)
    {
      _cs = cs;
    }

    [HttpGet]
    public ActionResult<Car> GetAllCars()
    {
      try
      {
        var cars = _cs.getAllCars();
        if (cars == null)
        {
          return BadRequest("Car list not found");
        }
        return Ok(cars);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Car> GetCar(int id)
    {
      try
      {
        var car = _cs.GetCarById(id);
        if (car == null)
        {
          return BadRequest("Invalid Car Id");
        }
        return Ok(car);
      }
      catch (System.Exception e)
      {
        return Forbid(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Car> CreateCar([FromBody] Car carData)
    {
      try
      {
        var car = _cs.CreateCar(carData);
        return Created("api/cars/" + car.Id, car);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // [HttpPut("{id}")]
    // public ActionResult<Car> EditCar(int id, [FromBody] Car carData)
    // {
    //   try
    //   {
    // Car car = _cs.EditCar(carData, Id)
    // return Ok(car)
    //   }
    //   catch (System.Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }FIX FOR REAL DB

    [HttpDelete("{id}")]
    public ActionResult<Car> DeleteCar(int id)
    {
      try
      {
        var car = _cs.DeleteCar(id);
        return Ok(car);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}