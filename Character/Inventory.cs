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
            String output = "";

            foreach (var elem in this)
            {
                if (this[0].Name == elem.Name)
                {
                    output += elem + "";
                }
                else if (this[Count - 1].Name == elem.Name)
                {
                    output += " & a " + elem + "";
                }
                else
                {
                    output += ", " + elem;
                }
            }

            return output;
        }

       
    }
}