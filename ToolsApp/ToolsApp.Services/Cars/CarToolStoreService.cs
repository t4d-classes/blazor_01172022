using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsApp.Models.Cars;

namespace ToolsApp.Services.Cars
{
  public class CarToolStoreService
  {
    private ICarsService _carsService;
    public int _editCarId = -1;

    public CarToolStoreService(ICarsService carsService) {
      _carsService = carsService;
    }

    public IEnumerable<Car> Cars {
      get {
        return _carsService.All();
      }
    }

    public int EditCarId {
      get {
        return _editCarId;
       }
    }

    public CarToolStoreService StartEditMode(int editCarId) {
      _editCarId = editCarId;
      return this;
    }

    public CarToolStoreService CancelEditMode()
    {
      _editCarId = -1;
      return this;
    }

    public CarToolStoreService AddCar(NewCar car) {
      _carsService.Append(car);
      CancelEditMode();
      return this;
		}

    public CarToolStoreService SaveCar(Car car)
    {
      _carsService.Replace(car);
      CancelEditMode();
      return this;
    }

    public CarToolStoreService DeleteCar(int carId)
    {
      _carsService.Remove(carId);
      CancelEditMode();
      return this;
    }

  }
}
