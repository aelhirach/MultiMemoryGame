using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MemoryGame
{
    public class Animal
    {

        private string name;
        private Image picture;

        public Animal(string name, Image picture)
        {
            this.name = name;
            this.picture = picture;

        }

        public Image Picture
        {
            get { return picture; }
            set { picture = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


    }
}
