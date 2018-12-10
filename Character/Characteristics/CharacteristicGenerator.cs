using System;
namespace Roguelike
{
	public class CharacteristicGenerator :  RandomList<Characteristic>
    {
        private Characteristic[] _allCharacteristics;
        private int _numberOfCharacteristics;
        public CharacteristicGenerator()
        {
            _allCharacteristics = new Characteristic[] { new Strong(), new Intelligent(), new Aimiable(), new Stealthy(), new Aggresive() };
            this.AddAll(_allCharacteristics);

            _numberOfCharacteristics = 3;
        }

        public RandomList<Characteristic> Generate () {
            return this.RollList(3);
        }
    }
}
