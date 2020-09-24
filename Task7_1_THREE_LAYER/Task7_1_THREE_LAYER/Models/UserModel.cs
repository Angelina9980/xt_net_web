using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<int> ListOfAwards { get; set; }
    }
}
