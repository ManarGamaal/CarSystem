using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem
{
    internal class Branch
    {
        public string ID { get; private set; }
        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; set; }
        public string Hours { get; set; }

        public Manager RManager { get; set; }
        public List<Customer> Customers { get; private set; }
        public List<Car> Cars { get; private set; }
        public Branch()
        {
            Customers = new List<Customer>();
            Cars = new List<Car>();
            RManager = new Manager();
        }
        public Branch(string id, string name, string phone, string Hours, string address)
        {
            Customers = new List<Customer>();
            Cars = new List<Car>();
            RManager = new Manager();
            Address = address;
            this.Hours = Hours;
            ID = id;
            Name = name;
            Phone = phone;

        }
        public void Display()
        {
            Console.WriteLine("RENTAL BRANCH INFO");
            Console.WriteLine($"Branch ID       : {ID}");
            Console.WriteLine($"Name            : {Name}");
            Console.WriteLine($"Address         : {Address}");
            Console.WriteLine($"Phone           : {Phone}");
            Console.WriteLine($"Hours           : {Hours}");
            Console.WriteLine($"Manager         : {RManager.Name}");
            Console.WriteLine($"Total Customers : {Customers.Count}");
            Console.WriteLine($"Total Vehicles  : {Cars.Count}");
        }
        public List<Car> GetAvailableCars()
        {
            List<Car> availableCars = new List<Car>();

            foreach (var car in Cars)
            {
                if (car.Record == CarRecord.Available)
                {
                    availableCars.Add(car);
                }
            }

            return availableCars;
        }
        public void AddCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer), "Customer cannot be null.");
            }
            if (Customers.Any(c => c.ID == customer.ID))
            {
                throw new InvalidOperationException($"Customer with ID {customer.ID} already exists.");
            }
            Customers.Add(customer);
        }
        public void AddCar(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car), "Car cannot be null.");
            }
            if (Cars.Any(c => c.CarID == car.CarID))
            {
                throw new InvalidOperationException($"Car with ID {car.CarID} already exists.");
            }
            Cars.Add(car);
        }
        
        public void FindCarById(string carId)
        { // (FirstOrDefault) => Get  the first element that matches the given condition.
            Car foundCar = Cars.FirstOrDefault(car => car.CarID == carId);
            if (foundCar != null)
            {
                Console.WriteLine($"Car ID: {foundCar.CarID}, Model: {foundCar.CarModel}, Record: {foundCar.Record}");
            }
            else
            {
                Console.WriteLine($"Car with ID {carId} not found.");
            }
        }
        public void FindCustomerById(string customerId)
        {
            Customer foundCustomer = Customers.FirstOrDefault(customer => customer.ID == customerId);
            if (foundCustomer != null)
            {
                Console.WriteLine($"Customer ID: {foundCustomer.ID}, Name: {foundCustomer.Name}, Phone: {foundCustomer.Phone}");
            }
            else
            {
                Console.WriteLine($"Customer with ID {customerId} not found.");
            }
        }
     /*   public Car FindCarById(string carId)
        {
            Car foundCar = Cars.FirstOrDefault(car => car.CarID == carId);
            if (foundCar != null)
            {
                Console.WriteLine($"Car ID: {foundCar.CarID}, Model: {foundCar.CarModel}, Record: {foundCar.Record}");
            }
            else
            {
                Console.WriteLine($"Car with ID {carId} not found.");
            }
            return foundCar;
        }

        public Customer FindCustomerById(string customerId)
        {
            Customer foundCustomer = Customers.FirstOrDefault(customer => customer.ID == customerId);
            if (foundCustomer != null)
            {
                Console.WriteLine($"Customer ID: {foundCustomer.ID}, Name: {foundCustomer.Name}, Phone: {foundCustomer.Phone}");
            }
            else
            {
                Console.WriteLine($"Customer with ID {customerId} not found.");
            }
            return foundCustomer;
        }*/
    }
}
    

