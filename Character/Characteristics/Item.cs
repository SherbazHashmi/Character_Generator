using System;

namespace Roguelike
{
    public struct Item
    {
        public String Name;
        
        public Item(String name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}