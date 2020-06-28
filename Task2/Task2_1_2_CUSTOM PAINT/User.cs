using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1_2_CUSTOM_PAINT
{
    class User
    {
        private string name;
        private List<string> listOfFigures = new List<string>();

        public string Name {
        get
            {
                return name;
            }
            set
            {
                name = value;
            }
    }
        public List<string> ListOfFigures
        {
            get
            {
                return listOfFigures;
            }
        }

        public User(string name)
        {
            this.name = name;
        }

        public static User changeUser(string name)
        {
            return new User(name);
        }

        public void AddFigure(PointPlane figure)
        {
            listOfFigures.Add(figure.GetInfo());
        }

        public void ClearCanvas()
        {
            this.listOfFigures.Clear();
        }
    }
}
