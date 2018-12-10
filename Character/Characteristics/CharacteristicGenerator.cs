using System;
namespace Roguelike
{
	public class CharacteristicGenerator :  RandomList<Characteristic>
    {
        private Characteristic[] _allCharacteristics;
        private int _numberOfCharacteristics;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Roguelike.CharacteristicGenerator"/> class.
        /// </summary>

        public CharacteristicGenerator()
        {
            _allCharacteristics = new Characteristic[] { new Strong(), new Intelligent(), new Aimiable(), new Stealthy(), new Aggresive() };
            this.AddAll(_allCharacteristics);

            _numberOfCharacteristics = 3;
        }

        /// <summary>
        /// Generate this instance.
        /// </summary>
        /// <returns>The generate.</returns>

        public RandomList<Characteristic> Generate () {
            return this.RollList(_numberOfCharacteristics);
        }
    }
}
