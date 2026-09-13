using System;

namespace CarSystem
{
    internal class Car
    {
        public string CarModel { get;  set; }
        public string CarID { get;  set; }
        public CarCondition Condition { get; set; }
        public CarRecord Record { get; set; }

        public Car() { }

        public Car(string carModel, string carID, CarCondition condition, CarRecord record)
        {
            CarModel = carModel;
            CarID = carID;
            Condition = condition;
            Record = record;
        }

        public void UpdateCondition(CarCondition newCondition)
        {
            Condition = newCondition;
        }

        public void UpdateRecord(CarRecord newRecord)
        {
            Record = newRecord;
        }

        public void DisplayData()
        {
            Console.WriteLine($"Car        : {CarModel}");
            Console.WriteLine($"Car ID     : {CarID}");
            Console.WriteLine($"Condition  : {Condition}");
            Console.WriteLine($"Status     : {Record}");
        }

        public bool ISAvalibale()
        {
            return Record == CarRecord.Available;
        }

        public void Rent()
        {
            if (ISAvalibale())
            {
                Record = CarRecord.Rented;
                Console.WriteLine($"Car {CarID} , {CarModel} Rented");
            }
            else
            {
                throw new InvalidOperationException($"Rental Failure: Car '{CarID}' ({CarModel}) cannot be rented. Current Status: '{Record}'");
            }
        }

        public void Return()
        {
            if (Record == CarRecord.Rented)
            {
                Record = CarRecord.Available;
                Console.WriteLine($"Car {CarID} , {CarModel} Available");
            }
            else
            {
                throw new InvalidOperationException($"Return Failure: Car '{CarID}' ({CarModel}) is not currently rented. Current Status: '{Record}'");
            }
        }
    }
}