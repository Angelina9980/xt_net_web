using System;
using System.Collections.Generic;

namespace Domain
{
    public class User
    {

        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<int> ListOfAwards { get; set; }
    }
}
