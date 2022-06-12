using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Zoo zoo = new Zoo();
            zoo.Work();
        }
    }

    class Zoo : Aviary
    {
        Aviary aviary = new Aviary();

        public void Work()
        {
            bool isWorking = true;
            CreateNewAnimals();
            Console.WriteLine($"Добро пажаловать в зоопарк, у нас есть {_aviarys.Count} вальера с животными, какой вы хотите посмотреть?");

            while (isWorking)
            {
                Console.WriteLine($"Чтобы выйти нажмите {_aviarys.Count + 1}");
                string input = Console.ReadLine();
                int number;

                if (int.TryParse(input, out number))
                {
                    if (number > 0 && number <= _aviarys.Count)
                    {
                        _aviarys[number-1].ShowInfo();
                    }
                }
                if (number == _aviarys.Count + 1)
                {
                    isWorking = false;
                }
            }
        }
    }

    class Aviary
    {
        protected List<Animal> _aviarys = new List<Animal>();

        protected void CreateNewAnimals()
        {
            _aviarys.Add(new Animal("Лев", "РРРР"));
            _aviarys.Add(new Animal("Гусь", "Кря"));
            _aviarys.Add(new Animal("Крокодил", "Клац-клац"));
            _aviarys.Add(new Animal("Лягушка", "Квак"));
        }
    }

    class Animal
    {
        public string Name { get; private set; }
        public string Gender { get; private set; }
        public string Sound { get; private set; }
        public int Amount { get; private set; }

        public Animal(string name,string sound)
        {
            Name = name;
            Gender = ChooseGender();
            Sound = sound;
            Amount = ChooseAmount();
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} в колличестве {Amount},пол: {Gender}, звук: {Sound}");
        }

        private int ChooseAmount()
        {
            Random random = new Random();
            int minAmount = 1;
            int maxAmount = 6;
            int index = random.Next(minAmount, maxAmount);
            return index;
        }

        private string ChooseGender() 
        {
            Random random = new Random();
            int maleIndex = 0;
            int femaleIndex = 2;
            int index = random.Next(maleIndex, femaleIndex);
            string gender;

            if (index == 1)
            {
                gender = "Мужской";
                return gender;
            }
            else
            {
                gender = "Женский";
                return gender;
            }
        }
    }
}