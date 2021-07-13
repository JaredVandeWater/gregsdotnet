using System;
using System.Collections.Generic;
using gregsdotnet.Data;
using gregsdotnet.Models;

namespace gregsdotnet.Services
{

  public class CarsService
  {
    public List<Car> getAllCars()
    {
      return FakeDb.Cars;
    }

    public Car GetCarById(int id)
    {
      return FakeDb.Cars.Find(c => c.Id == id);
    }

    public Car CreateCar(Car carData)
    {
      var r = new Random();
      carData.Id = r.Next(1, 99999);
      FakeDb.Cars.Add(carData);
      return carData;
    }

    public Car DeleteCar(int id)
    {
      var car = FakeDb.Cars.Find(c => c.Id == id);
      if (car == null)
      {
        throw new Exception("Invalid Id");
      }
      FakeDb.Cars.Remove(car);
      return car;
    }

    // public Car EditCar(Car carData, int id)
    // {
    //   Car OriginalCar = FakeDb.Cars.Find(c => c.Id == id);

    // } FIX THIS WHEN USING AN ACTUAL DB
  }
}