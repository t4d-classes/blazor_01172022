using ToolsApp.Models.Cars;

namespace ToolsApp.Services.Cars
{
  public interface ICarsService
  {
    IEnumerable<Car> All();
    ICarsService Append(NewCar car);
    ICarsService Replace(Car car);
    ICarsService Remove(int carId);
  }
}
