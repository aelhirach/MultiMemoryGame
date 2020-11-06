using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MemoryGame
{
    class AnimalsGrid : List<Animal>
    {
        private List<Animal> jokerList;
        private int firstAnimalPosition;
        private int secondAnimalPosition;
        //public List<string> EasyQList;
        public List<Animal> JokerList
        {
            get { return jokerList; }
            set { jokerList = value; }
        }
        public int FirstAnimalPosition
        {
            get { return firstAnimalPosition; }
            set { firstAnimalPosition = value; }
        }
        public int SecondAnimalPosition
        {
            get { return secondAnimalPosition; }
            set { secondAnimalPosition = value; }
        }
        //Constructor
        public AnimalsGrid(List<string> gate)
        {
            List<Animal> tempList = tempGate();

            List<Animal> SortedList = tempList.OrderBy(o => gate).ToList();
            
        }

        public AnimalsGrid()
        {
            Random rnd = new Random();
            var randomizedList = from item in tempGate() orderby rnd.Next() select item;
            this.AddRange(randomizedList);
            jokerList = new List<Animal>();
            jokerList.Add(this.ElementAt(49));
            jokerList.Add(this.ElementAt(50));
            jokerList.Add(this.ElementAt(51));

        }

        public  List<Animal> tempGate()
        {
            List<Animal> tempList = new List<Animal>();
            // 1- baboon
            Animal baboon = new Animal("baboon", MemoryGame.Properties.Resources.baboon);

            tempList.Add(baboon);

            // 2- butterfly
            Animal butterfly = new Animal("butterfly", MemoryGame.Properties.Resources.butterfly);
            tempList.Add(butterfly);

            // 3-cow
            Animal cow = new Animal("cow", MemoryGame.Properties.Resources.cow);
            tempList.Add(cow);


            // 4-crap
            Animal crap = new Animal("crap", MemoryGame.Properties.Resources.crap);

            tempList.Add(crap);

            // 5-crocodile
            Animal crocodile = new Animal("crocodile", MemoryGame.Properties.Resources.crocodile);
            tempList.Add(crocodile);

            // 6-delphi
            Animal delphin = new Animal("delphin", MemoryGame.Properties.Resources.delphin);
            tempList.Add(delphin);

            // 7-dog
            Animal dog = new Animal("dog", MemoryGame.Properties.Resources.dog);

            tempList.Add(dog);

            // 8-donkey
            Animal donkey = new Animal("donkey", MemoryGame.Properties.Resources.donkey);
            tempList.Add(donkey);

            // 9-duck
            Animal duck = new Animal("duck", MemoryGame.Properties.Resources.duck);
            tempList.Add(duck);

            // 10-elephent
            Animal elephent = new Animal("elephent", MemoryGame.Properties.Resources.elephent);
            tempList.Add(elephent);

            // 11-fish
            Animal fish = new Animal("fish", MemoryGame.Properties.Resources.fish);

            tempList.Add(fish);

            // 12-fly
            Animal fly = new Animal("fly", MemoryGame.Properties.Resources.fly);

            tempList.Add(fly);

            // 13-giraffe
            Animal giraffe = new Animal("giraffe", MemoryGame.Properties.Resources.giraffe);
            tempList.Add(giraffe);
            // 14-goose
            Animal goose = new Animal("goose", MemoryGame.Properties.Resources.goose);
            tempList.Add(goose);
            // 15-hippopotamus
            Animal hippopotamus = new Animal("hippopotamus", MemoryGame.Properties.Resources.hippopotamus);
            tempList.Add(hippopotamus);
            // 16-horse
            Animal horse = new Animal("horse", MemoryGame.Properties.Resources.horse);
            tempList.Add(horse);
            // 17-mouse
            Animal mouse = new Animal("mouse", MemoryGame.Properties.Resources.mouse);
            tempList.Add(mouse);
            // 18-panda
            Animal panda = new Animal("panda", MemoryGame.Properties.Resources.panda);
            tempList.Add(panda);
            // 19-pig
            Animal pig = new Animal("pig", MemoryGame.Properties.Resources.pig);
            tempList.Add(pig);
            // 20- shark
            Animal shark = new Animal("shark", MemoryGame.Properties.Resources.shark);
            tempList.Add(shark);
            // 21-snake
            Animal snake = new Animal("snake", MemoryGame.Properties.Resources.snake);
            tempList.Add(snake);
            // 22-swallow_bird
            Animal swallow_bird = new Animal("swallow_bird", MemoryGame.Properties.Resources.swallow_bird);
            tempList.Add(swallow_bird);
            // 23-tortoise
            Animal tortoise = new Animal("tortoise", MemoryGame.Properties.Resources.tortoise);
            tempList.Add(tortoise);
            // 24-walrus
            Animal walrus = new Animal("walrus", MemoryGame.Properties.Resources.walrus);
            tempList.Add(walrus);
            // 25-white_tiger
            Animal white_tiger = new Animal("white_tiger", MemoryGame.Properties.Resources.white_tiger);
            tempList.Add(white_tiger);
            // 26-zebra
            Animal zebra = new Animal("zebra", MemoryGame.Properties.Resources.zebra);
            tempList.Add(zebra);
            //creatGate
            tempList.AddRange(tempList);

            return tempList;

        }
        public List<string> NameGate()
        {
            List<string> nameList = new List<string>();
            foreach (Animal animal in this)
            {
                nameList.Add(animal.Name);
            }
            return nameList;
        }

    }
}
