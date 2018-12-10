using System;
using System.IO;

namespace Roguelike
{
    class Program
    {
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            TextReader reader = Console.In;
            TextWriter writer = Console.Out;
            Character character;

            String input = "";

            writer.WriteLine("Welcome to Roguelike Generator v1.0.0 \nLet's generate a character!");

            while (true) {
                writer.WriteLine("Would you like to name it yourself?\n [Y]es or [N]o");
                input = reader.ReadLine().ToString();

                if(input == "Y" || input == "N") {
                    break;
                }
            }

            switch (input)
            {
                case "Y":
                    writer.WriteLine("Please provide a name");
                    input = reader.ReadLine();
                    character = new Character(input);
                    break;
                case "N":
                    character = new Character();
                    break;
                default:
                    character = new Character();
                    break;
            }

            input = "";

            writer.WriteLine(character);

        }

    }
}
