using System;
namespace Roguelike
{
    public class Character
    {
        // Declaring all global variables!
        public String Name;
        public RandomList<Characteristic> _characteristics;
        public int Age;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Roguelike.Character"/> class if name is given.
        /// </summary>
        public Character(String name)
        {
            InitialiseCharacteristics();
            InitialiseCharacterBaseAttributes(name);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Roguelike.Character"/> class if name is not given.
        /// </summary>
        public Character() {
            String name = NameGenerator();
            InitialiseCharacteristics();
            InitialiseCharacterBaseAttributes(name);
        }

        public String NameGenerator() { 
            RandomList<String> prefixes =  new RandomList<String> { "lo", "te", "soa", "co"};
            RandomList<String> suffixes = new RandomList<String> { "l", "as", "ud"};
            return prefixes.Roll() + suffixes.Roll();
        }

        public void InitialiseCharacteristics () {
            CharacteristicGenerator characteristicGenerator = new CharacteristicGenerator();
            _characteristics = characteristicGenerator.Generate();
        }

        public void InitialiseCharacterBaseAttributes(String name) {
            Name = name;
            Random r = new Random();
            Age = r.Next(70) + 18;
        }

        public override string ToString()
        {
            if (Age < 30)
            {
                return "You woke up for the first time about " + Age + " years ago. You go by " + Name + ". By your ripe young age you have achieved so much. You have the following characteristics : " + _characteristics;
            }
            else if (Age < 60)
            {
                return  "You woke up for the first time about " + Age + " years ago. You go by " + Name + ". By your middle young age you have achieved a lot. You have the following characteristics : " + _characteristics;
            }
            else {
                return "Creakkkkkk... Hear that creak? That was your hip... makes sense given you're " + Age + " years old.. You go by " + Name + ". While you may not be able to learn much more, it doesn't matter as you've mastered :" +_characteristics;
            }

        }

    }
}
