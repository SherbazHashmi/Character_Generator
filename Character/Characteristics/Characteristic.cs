using System;
namespace Roguelike
{
    public class Characteristic
    {
        public String Description;

        public void SetDescription(String description) {
            Description = description;
        }

        public override string ToString()
        {
            Type t = this.GetType();
            return t + " : " + Description;
        }
    }
}
