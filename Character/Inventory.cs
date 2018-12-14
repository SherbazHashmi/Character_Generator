using System;
using System.Collections.Generic;

namespace Roguelike
{
    public class Inventory : List<Item>
    {
        public Inventory(List<Item> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }    
        }
        
        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < Count - 1; i++)
            {
                if (i == Count - 1)
                {
                    output += this[i];
                }
                else
                {
                    output += this[i] + ", " + this[i];
                }
                 
            }

            return output;
        }
    }
}