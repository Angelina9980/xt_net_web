
using System;

namespace Domain
{
    public class Account
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int Balance { get; set; }
        public string[] CardInformation { get; set; }
        public int[] Number { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
    }
}
