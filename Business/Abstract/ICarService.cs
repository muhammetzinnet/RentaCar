using Entities.Concrete;
using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetAllByDailyPrice(decimal min, decimal max);
        IDataResult<List<Car>> GetByBrandId(int brandId);
        IDataResult<List<Car>> GetByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<Car> GetById(int carId);
        IResult  Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IResult AddTransactionalTest(Car car);

    }
}
