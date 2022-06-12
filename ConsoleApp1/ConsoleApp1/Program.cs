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

    class Zoo
    {
        private List<Animal> _animals = new List<Animal>();

        public void Work()
        {
            CreateNewAnimals();
            bool isWorking = true;

            while (isWorking)
            {
                Console.WriteLine($"Добро пажаловать в зоопарк, у нас есть {_animals.Count} вида животных, какой вы хотите посмотреть?");
                Console.WriteLine($"Чтобы выйти нажмите {_animals.Count + 1}");
                string input = Console.ReadLine();
                int number;
                int.TryParse(input, out number);

                switch (input)
                {
                    case "1":
                        _animals[number - 1].ShowInfo();
                        break;
                    case "2":
                        _animals[number - 1].ShowInfo();
                        break;
                    case "3":
                        _animals[number - 1].ShowInfo();
                        break;
                    case "4":
                        _animals[number - 1].ShowInfo();
                        break;
                    case "5":
                        isWorking = false;
                        break;
                    default:
                        Console.WriteLine("Ошибка");
                        break;
                }
            }
        }

        private void CreateNewAnimals()
        {
            _animals.Add(new Animal("Лев", "РРРР"));
            _animals.Add(new Animal("Гусь","Кря"));
            _animals.Add(new Animal("Крокодил", "Клац-клац"));
            _animals.Add(new Animal("Лягушка", "Квак"));
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