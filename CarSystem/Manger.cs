using System;

namespace CarSystem
{
    internal class Manager : User
    {
        public DateTime StartTime { get; private set; }
        public double Salary { get; private set; }

        public Manager(DateTime startTime, double salary, string id, string name, string phone)
            : base(id, name, phone)
        {
            StartTime = startTime;
            Salary = salary;
        }

        public Manager()
        {
        }

        public override void Display()
        {
            Console.WriteLine("MANAGER PROFILE");
            Console.WriteLine($"ID: {ID} | Name: {Name} | Phone: {Phone}");
            Console.WriteLine($"Salary: {Salary:C2} | Hired: {StartTime:dd/MM/yyyy}");
        }
    }
}