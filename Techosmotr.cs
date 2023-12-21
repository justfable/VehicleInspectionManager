using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
namespace VehicleInspectionManager
{
    public class Techosmotr
    {
        // Путь к файлу базы данных
        private readonly string _databasePath;

        // Конструктор
        public Techosmotr(string databasePath)
        {
            _databasePath = databasePath;
        }

        public void AddCar(Car car)
        {
            //using гарантирует, что объект базы данных будет корректно закрыт и освобожден после использования
            using (var db = new LiteDatabase(_databasePath))
            {
                var cars = db.GetCollection<Car>("MyDb");
                cars.Insert(car);
            }
        }

        public Car FindCarByNumber(string number)
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var cars = db.GetCollection<Car>("MyDb");
                return cars.FindOne(c => c.Number == number);
            }
        }


        public void UpdateCar(Car car)
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var cars = db.GetCollection<Car>("MyDb");
                var existingCar = cars.FindOne(c => c.Number == car.Number);
                if (existingCar != null)
                {
                    existingCar.Mark = car.Mark;
                    existingCar.Model = car.Model;
                    existingCar.Year = car.Year;
                    existingCar.Number = car.Number;
                    existingCar.Inspection = car.Inspection;

                    cars.Update(existingCar);
                }
                else
                {
                    cars.Insert(car);
                }
            }
        }

        public void RemoveCar(string number)
        {
            using (var db = new LiteDatabase(_databasePath))
            {
                var cars = db.GetCollection<Car>("MyDb");
                cars.DeleteMany(c => c.Number == number);
            }
        }

        public IEnumerable<Car> GetAllCars()
        {
            //using гарантирует, что объект базы данных будет корректно закрыт и освобожден после использования
            using (var db = new LiteDatabase(_databasePath))
            {
                return db.GetCollection<Car>("MyDb").FindAll().ToList();
            }
        }
    }
}
