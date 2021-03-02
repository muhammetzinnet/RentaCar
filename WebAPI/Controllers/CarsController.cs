using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            IDataResult<List<Car>> result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]

        public IActionResult GetById(int id)
        {
            IDataResult<Car> result = _carService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            IResult result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            IResult result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            IResult result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);
        }

        [HttpGet("getallbydaily")]
        public IActionResult GetAllByDailyPrice(Car car)
        {
            IDataResult<List<Car>> result = _carService.GetAllByDailyPrice(50,10000);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getcardetail")]
        public IActionResult GetCarDetail(Car car)
        {
            IDataResult<List<CarDetailDto>> result = _carService.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getcarbybrandid")]
        public IActionResult GetCarByBrandId(int id)
        {
            IDataResult<List<Car>> result = _carService.GetByBrandId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
