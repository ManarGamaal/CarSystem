using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarSystem
{
    internal class Customer : User
    {


        public Customer()
        {

        }
        private string email;
        public string Email
        {
            get => email;
            set
            {
                if (value == "N/A" || ISValidEmail(value))
                {
                    email = value;
                }
                else
                {
                    throw new InvalidOperationException("Invalid email format. Must contain '@' and '.'.");


                }
            }

        }
        public Customer(string id, string name, string phone, DateTime joinedDate, string email)
            : base(id, name, phone)
        {
            JoinedDate = joinedDate;
            Email = string.IsNullOrWhiteSpace(email) ? "N/A" : email;
            ActiveRentals = 0;
        }
        public int ActiveRentals { set; get; }
        public DateTime JoinedDate { private set; get; }
        public override void Display()
        {
            Console.WriteLine("CUSTOMER PROFILE");  //{JoinedDate.Day}.{JoinedDate.Month}.{JoinedDate.Year}
            Console.WriteLine($"ID: {ID} | Name: {Name} | Joined: {JoinedDate.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Phone: {Phone} | Email: {Email} | Active Rentals: {ActiveRentals}");
        }

        private bool ISValidEmail(string Mail)
        {
            return Mail.Contains("@") && Mail.Contains(".") && !(string.IsNullOrWhiteSpace(Mail));




        }
    }
}
