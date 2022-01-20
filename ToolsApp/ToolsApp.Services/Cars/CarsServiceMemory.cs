using ToolsApp.Models.Cars;

namespace ToolsApp.Services.Cars
{
  public class CarsServiceMemory : ICarsService
  {
    private List<Car> _cars = new();

    public IEnumerable<Car> All()
    {
      return _cars;
    }

    public ICarsService Append(NewCar car)
    {
      _cars.Add(
        new(
          _cars.Select(c => c.Id).DefaultIfEmpty(0).Max() + 1,
          car.Make,
          car.Model,
          car.Year,
          car.Color,
          car.Price
        )
      );

      return this;
    }

    public ICarsService Remove(int carId)
    {
      var carToRemove = _cars.Find(c => c.Id == carId);

      if (carToRemove is not null) {
        _cars.Remove(carToRemove);
      }

      return this;
    }

    public ICarsService Replace(Car car)
    {
      int carIndex = _cars.FindIndex(c => c.Id == car.Id);
      _cars[carIndex] = car;

      return this;
    }
  }
}
