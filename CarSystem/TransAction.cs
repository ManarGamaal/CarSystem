using System;

namespace CarSystem
{

    internal class TransAction
    {
        private static int transactionCounterid = 1000;
        public const double FeePerDay = 150;

        public int TransactionIDs { get; private set; }
        public DateTime Rented { get; private set; }
        public DateTime Due { get; private set; }
        public DateTime Returned { get; private set; }
        public double Fee { get; private set; }
        public Car Car { get; private set; }
        public TransStatues Status { get; private set; }
        public TransType Type { get; private set; }

        public TransAction(Car car, DateTime rented, DateTime due)
        {
            transactionCounterid++;
            TransactionIDs = transactionCounterid;
            Car = car;
            Rented = rented;
            Due = due;
            Fee = 0;
            Status = TransStatues.Active;
            Type = TransType.Ontime;
        }

        public double ProcessReturn(DateTime returnDate)
        {
            Returned = returnDate;
            Status = TransStatues.Returned;

            int lateDays = (returnDate.Date - Due.Date).Days;

            if (lateDays > 0)
            {
                Fee = lateDays * FeePerDay;
                Type = TransType.Late;
                Console.WriteLine($"Returned late by {lateDays} day(s). Fee: {Fee:F2} EGP.");
            }
            else
            {
                Fee = 0;
                Type = TransType.Ontime;
                Console.WriteLine("Returned on time. No late fee.");
            }

            return Fee;
        }

        public void Display()
        {
            Console.WriteLine($"Transaction : TX-{TransactionIDs}");
            Console.WriteLine($"Car         : {Car?.CarModel}");
            Console.WriteLine($"Car ID      : {Car?.CarID}");
            Console.WriteLine($"Rented      : {Rented:dd/MM/yyyy}");
            Console.WriteLine($"Due         : {Due:dd/MM/yyyy}");
            Console.WriteLine($"Returned    : {(Returned == DateTime.MinValue ? "Active / Not Returned" : Returned.ToString("dd/MM/yyyy"))}");
            Console.WriteLine($"Fee         : {(Fee == 0 ? "None" : $"{Fee:F2} EGP")}");
        }
    }
}