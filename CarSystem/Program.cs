using System;

namespace CarSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Manager manager = new Manager { ID = "M101", Name = " Hassan", Phone = "0100298110" };
                Branch branch = new Branch("M001", "MG Branch", "0223456789", "sat-fri 9 AM - 10 PM", "Downtown Cairo");

                branch.Display();
                Console.WriteLine();

                Car car1 = new Car { CarID = "CAR01", CarModel = "Toyota Corolla 2024", Record = CarRecord.Available };
                Car car2 = new Car { CarID = "CAR02", CarModel = "Hyundai Elantra 2023", Record = CarRecord.Available };

                branch.AddCar(car1);
                branch.AddCar(car2);

                Customer cust1 = new Customer { ID = "CUST01", Name = "Manar", Phone = "01092341710" };
                Customer cust2 = new Customer { ID = "CUST02", Name = "Osama ", Phone = "0101854500" };

                branch.AddCustomer(cust1);
                branch.AddCustomer(cust2);

                var available = branch.GetAvailableCars();
                Console.WriteLine("Available Cars Count: " + available.Count);

                branch.FindCarById("CAR01");
                branch.FindCustomerById("CUST01");

                Console.WriteLine();
                branch.Display();

                Car duplicateCar = new Car { CarID = "CAR01", CarModel = "Honda Civic" };
                branch.AddCar(duplicateCar);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}