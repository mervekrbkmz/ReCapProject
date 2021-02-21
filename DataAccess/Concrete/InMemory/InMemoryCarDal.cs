using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> _cars;


        public InMemoryCarDal()
        {
            _cars = new List<Car> {
            new Car { CarId = 1, BrandId = 1, ColorId = 1, ModelYear = 2010, DailyPrice = 200, Description = "D SEGMENTTİR" },
            new Car { CarId = 2, BrandId = 2, ColorId = 1, ModelYear = 2007, DailyPrice = 300, Description = "C SEGMENTTİR" },
            new Car { CarId = 3, BrandId = 3, ColorId = 4, ModelYear = 2000, DailyPrice = 250, Description = "LÜKS ARAÇ" },
            new Car { CarId = 4, BrandId = 1, ColorId = 1, ModelYear = 2010, DailyPrice = 200, Description = "D SEGMENTTİR" }
            };
        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
           Car carToDelete = _cars.SingleOrDefault(c=>c.CarId==car.CarId);
            //singleordefault foreach yerine geçiyor tek tek ürünleri dolaşır.
            _cars.Remove(carToDelete);

        }

        public List<Car> GetAll()
        {

            return _cars;
        }

       
        public void Update(Car car)
        { //gönderdiğim ürün ıdsine sahip olan listedeki ürünü bul.
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;

        }
     

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();

        }
    }

}

