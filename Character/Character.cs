using System;
namespace Roguelike
{
    public class Character
    {
        // Declaring all global variables!
        public String Name;
        public RandomList<Characteristic> _characteristics;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Roguelike.Character"/> class if name is given.
        /// </summary>
        public Character(String name)
        {
            Name = name;
            InitialiseCharacteristics();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Roguelike.Character"/> class if name is not given.
        /// </summary>
        public Character() {
            Name = NameGenerator();
            InitialiseCharacteristics();
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
    }
}
