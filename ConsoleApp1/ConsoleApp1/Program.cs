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
        private List<Aviary> _aviaries = new List<Aviary>();
        private int _aviariesAmount;

        public void Work()
        {
            CreateAviaries();
            bool isWorking = true;
            Console.WriteLine($"Добро пажаловать в зоопарк, у нас есть {_aviaries.Count} вальера с животными, какой вы хотите посмотреть?");

            while (isWorking)
            {
                Console.WriteLine($"Чтобы выйти нажмите {_aviaries.Count + 1}");
                string input = Console.ReadLine();
                int number;

                if (int.TryParse(input, out number))
                {
                    if (number > 0 && number <= _aviaries.Count)
                    {
                        _aviaries[number-1].ShowAviaryInfo();
                    }
                }
                if (number == _aviaries.Count + 1)
                {
                    isWorking = false;
                }
            }
        }

        private void CreateAviaries()
        {
            _aviariesAmount = 4;

            for (int i = 0; i < _aviariesAmount; i++)
            {
                _aviaries.Add(new Aviary());
            }
        }
    }

    class Aviary
    {
        private List<Animal> _aviary = new List<Animal>();
        private int _amount;

        public Aviary()
        {
            CreateAviary();
        }

        public void ShowAviaryInfo()
        {
            Console.WriteLine ($"В клетке {_aviary.Count} зверей");

            foreach (Animal animal in _aviary)
            {
                Console.WriteLine($"{animal.Name}, пола {animal.Gender}, звук;{animal.Sound}");
            }
        }

        private int ChooseAmount()
        {
            Random random = new Random();
            int minAmount = 1;
            int maxAmount = 6;
            int index = random.Next(minAmount, maxAmount);
            return index;
        }

        private void CreateAviary()
        {
            _amount = ChooseAmount();
            int minAmount = 1;
            Random random = new Random();
            int index = random.Next(minAmount, _amount);

            for (int i = 0; i < _amount; i++)
            {
                _aviary.Add(GetAnimal(index));
            
            }
        }

        private Animal GetAnimal(int index)
        {
            switch (index)
            {
                case 1 :
                    return new Animal("Лев", "РРРР");
                case 2:
                    return new Animal("Гусь", "Кря");
                case 3:
                    return new Animal("Крокодил", "Клац-клац");
                case 4:
                    return new Animal("Лягушка", "Квак");
                default:
                    break;
            }

            return null;
        }
    }

    class Animal
    {
        public string Name { get; private set; }
        public string Gender { get; private set; }
        public string Sound { get; private set; }

        public Animal(string name,string sound)
        {
            Name = name;
            Gender = ChooseGender();
            Sound = sound;
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