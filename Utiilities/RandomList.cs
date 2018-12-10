using System;
using System.Collections.Generic;
namespace Roguelike
{
    /// <summary>
    /// Random List is a collection that extends List, it implements 
    /// RNG capabilities to the list collection. It also inherits
    /// clonable so it can be copied by value.
    /// </summary>
    public class RandomList<T> : List<T>, ICloneable
    {
        private Random _randomiser;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Roguelike.RandomList`1"/> class.
        /// </summary>

        public RandomList()
        {
            _randomiser = new Random();
        }


        public object Clone()
        {
            return (RandomList<T>)this.MemberwiseClone();
        }

        /// <summary>
        /// Roll generates random element from collection
        /// </summary>
        /// <returns> Random Element From Collection</returns>

        public T Roll() {
            int index = _randomiser.Next(Count);
            return this[index];
        }

        /// <summary>
        /// RollList generates random list of elements from a pre-existing list.
        /// </summary>
        /// <example>
        /// ["A","B","C","D"].RollList(2) -> ["A","D"]  
        /// </example>
        /// <returns>The list.</returns>
        /// <param name="size">Size.</param>

        public RandomList<T> RollList(int size) {
            if (size > this.Count) {
                Exception e = new Exception("Cannot generate random list of size :" + size + " from original list of size: " + this.Count);
                Console.Write(e);
                throw e;
            } else {
                // List That Will Have Elements Removed From To Prevent Duplicate Rolls
                RandomList<T> throwableList = (RandomList<T>)this.Clone();

                // List That Will Contain Random Elements and Be Returned
                RandomList<T> generatedList = new RandomList<T>();

                // Generate Member In Generated List (of size n) by 
                // Rolling on Throwable, adding to Generated and removing from
                // Throwable to mitigate any duplicate elements.

                for (int i = 0; (i < size - 1); i++)
                {
                    T element = throwableList.Roll();
                    generatedList.Add(element);
                    throwableList.Remove(element);
                }
                return generatedList;
            }
        }

        /// <summary>
        /// Adds all elements from input to List.
        /// </summary>
        /// <param name="elements">Elements.</param>
        /// 
        public void AddAll (T[] elements) {
            foreach ( T element in elements) {
                this.Add(element);
            }
        }


        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Roguelike.RandomList`1"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Roguelike.RandomList`1"/>.</returns>
       
        public override string ToString()
        {
            String output = "";
            foreach (var element in this)
            {
                if(output == "") {
                    output = element.ToString();
                } else {
                    output = output + "\n" + element;
                }
            }
            return output;
        }

    }
}
