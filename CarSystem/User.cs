using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem
{
    internal abstract class User
    {
        public User()
        {
        }
        public User(string id, string name, string phone)
        {
            ID = id;
            Name = name;
            Phone = phone;
        }

        public string ID { set; get; }
        public string Name  { set; get; }
        private string phone;
        public string Phone
        {
            get => phone;
            set
            {
                if (!ContainsDigit(value))
                {
                    throw new InvalidOperationException("Phone number must contain at least one digit.");
                }
                phone = value;
            }
        }
        public abstract void Display();
        private bool ContainsDigit(string phone)
        {
            return (!string.IsNullOrEmpty(phone) && phone.Any(char.IsDigit));
        }
    }
}
