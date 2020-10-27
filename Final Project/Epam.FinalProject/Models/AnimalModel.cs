using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AnimalModel
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMineType { get; set; }
    }
}
