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
                        _aviaries[number-1].ShowAnimalInfo();
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
            int aviariesAmount = 4;

            for (int i = 0; i < aviariesAmount; i++)
            {
                _aviaries.Add(new Aviary());
            }
        }
    }

    class Aviary
    {
        private List<Animal> _animals = new List<Animal>();
        private List<Animal> _animalSpecies = new List<Animal>();

        public Aviary()
        {
            CreateAnimals();
            AddAnimalsToAviary();
        }

        public void ShowAnimalInfo()
        {
            Console.WriteLine ($"В клетке {_animals.Count} зверей");

            foreach (Animal animal in _animals)
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

        private void AddAnimalsToAviary()
        {
            int amount = ChooseAmount();
            int minIndex = 0;
            int maxIndex = 4;
            Random random = new Random();
            int index = random.Next(minIndex, maxIndex);

            for (int i = 0; i < amount; i++)
            {
                _animals.Add(GetAnimal(index));
            
            }
        }

        private void CreateAnimals()
        {
            _animalSpecies.Add(new Animal("Лев", "РРРР"));
            _animalSpecies.Add(new Animal("Гусь", "Кря"));
            _animalSpecies.Add(new Animal("Крокодил", "Клац-клац"));
            _animalSpecies.Add(new Animal("Лягушка", "Квак"));
        }

        private Animal GetAnimal(int index)
        {
            return (_animalSpecies[index]);
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