using System;
using System.Linq;

namespace Roguelike
{
    public class Characteristic
    {
        public String Description;

        /// <summary>
        /// Sets the description.
        /// </summary>
        /// <param name="description">Description.</param>

        public void SetDescription(String description) {
            Description = description;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Roguelike.Characteristic"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Roguelike.Characteristic"/>.</returns>

        public override string ToString()
        {
            Type t = this.GetType();
            return CleanType(t.ToString()) + " : " + Description;
        }

        /// <summary>
        /// Cleans the Content Before the . in the Type
        /// </summary>
        /// <returns></returns>
        private String CleanType(String type)
        {
            if (type[0] == '.')
            {
                return type.Substring(1);
            }
            else
            {
                return CleanType(type.Substring(1));
            }
        }
    }
}
