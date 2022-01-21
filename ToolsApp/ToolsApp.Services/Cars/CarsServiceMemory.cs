using System.Threading.Tasks;
using ToolsApp.Models.Cars;

namespace ToolsApp.Services.Cars
{
  public class CarsServiceMemory : ICarsService
  {
    private List<Car> _cars = new();

    public Task<IEnumerable<Car>> All()
    {
      return Task.FromResult<IEnumerable<Car>>(_cars);
    }

    public Task<ICarsService> Append(NewCar car)
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

      return Task.FromResult<ICarsService>(this);
    }

    public Task<ICarsService> Remove(int carId)
    {
      var carToRemove = _cars.Find(c => c.Id == carId);

      if (carToRemove is not null) {
        _cars.Remove(carToRemove);
      }

      return Task.FromResult<ICarsService>(this);
    }

    public Task<ICarsService> Replace(Car car)
    {
      int carIndex = _cars.FindIndex(c => c.Id == car.Id);
      _cars[carIndex] = car;

      return Task.FromResult<ICarsService>(this);
    }
  }
}
