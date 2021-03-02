using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentaCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                IQueryable<CarDetailDto> result = from c in context.Cars
                    join b in context.Brands on c.BrandId equals b.Id
                    select new CarDetailDto
                        { Id = c.Id, CarName = c.CarName, BrandName = b.BrandName, DailyPrice = c.DailyPrice};
                return result.ToList();
            }
        }

    }
}
