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
    private int _editCarId = -1;

    public CarToolStoreService(ICarsService carsService) {
      _carsService = carsService;
    }

    public async Task<IEnumerable<Car>> Cars() {
       return await _carsService.All();
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

    public async Task<CarToolStoreService> AddCar(NewCar car) {
      await _carsService.Append(car);
      CancelEditMode();
      return this;
		}

    public async Task<CarToolStoreService> SaveCar(Car car)
    {
      await _carsService.Replace(car);
      CancelEditMode();
      return this;
    }

    public async Task<CarToolStoreService> DeleteCar(int carId)
    {
      await _carsService.Remove(carId);
      CancelEditMode();
      return this;
    }

  }
}
