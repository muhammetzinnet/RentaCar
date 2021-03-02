using System;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.CrossCuttinSource;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.CrossCuttingCorncerns.Validation;
using Core.Utilities.Results;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using DataAccess.Concrete.EntityFramework;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        ILogger _logger;
        IBrandService _brandService;
        EfCarDal _efCarDal;
        IBrandService _brandManager;

        public CarManager(ICarDal carDal, ILogger logger, IBrandService brandservice)
        {
            _carDal = carDal;
            _logger = logger;
            _brandService = brandservice;
        }

        public CarManager(EfCarDal efCarDal, BrandManager brandManager)
        {
            this._efCarDal = efCarDal;
            this._brandManager = brandManager;
        }

        [SecuredOperation("car.add, admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarCountOfBarandCorrect(car.BrandId), 
                CheckIfCarNameExists(car.CarName), CheckIfBrandLimitExists());

            if (result!=null)
            {
                return result;
            }
            
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        [SecuredOperation("car.delete, admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [SecuredOperation("car.update, admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            if (ValidateCarData(car))
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);
            }

            return new SuccessResult(Messages.CarDataInvalid);
        }

        public IDataResult<Car> GetById(int Id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == Id), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 03)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        private bool ValidateCarData(Car car)
        {
            if (car.CarName.Length > 2 && car.DailyPrice > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IDataResult<List<Car>> GetAllByDailyPrice(decimal min, decimal max)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice <= max && c.DailyPrice >= min), true);
        }

        private IResult CheckIfCarCountOfBarandCorrect(int brandId)
        {
            int result = _carDal.GetAll(c => c.BrandId == brandId).Count;
            if (result >= 8)
            {
                return new ErrorResult(Messages.CarCountOfCarBrandError);
            }
            return new SuccessResult(Messages.CarAdded);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour > 22 || DateTime.Now.Hour < 8)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarsListed);

        }

        public IDataResult<List<Car>> GetByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId), Messages.CarsListed);
        }
        private IResult CheckIfCarNameExists(string carName)
        {
            bool result = _carDal.GetAll(c => c.CarName == carName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExists);
            }
            return new SuccessResult(Messages.CarAdded);
        }

        private IResult CheckIfBrandLimitExists()
        {
            IDataResult<List<Brand>> result = _brandService.GetAll();
            if (result.Data.Count>6)
            {
                return new ErrorResult(Messages.BrandLimitExists);
            }
            return new SuccessResult();
        }
    }
}
