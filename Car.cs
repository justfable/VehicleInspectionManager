using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
namespace VehicleInspectionManager
{
    public class Car
    {
        public ObjectId Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Number { get; set; }
        public bool Inspection { get; set; }

        // Конструктор
        public Car(string mark, string model, int year, string number)
        {
            Mark = mark;
            Model = model;
            Year = year;
            Number = number;
            Inspection = false;
        }

    }
}
