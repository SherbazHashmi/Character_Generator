using System;
using System.Data;
using System.IO;

namespace Roguelike
{
    /// <summary>
    /// @author : Sherbaz Hashmi
    /// </summary>
    class Program
    {
        private static TextReader _reader;
        private static TextWriter _writer;
        private static TheRoom _room;
        
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            InitialiseWriterAndReader();
            _room = new TheRoom(CharacterSetup());
            SlowType("");
            Rules();
            SlowType("");
            
        }

        private static void RevealRoom()
        {
            SlowType("The suspects currently alive in the room are :  " +  _room);
        }

        public static void Rules()
        {
            SlowType("The rules are as follows : You're on the clock, the longer you take the more people will die. Time to guess who the killer is.");
            SlowType("");
            RevealRoom();
        }
        
        /// <summary>
        /// Initialises Writer And Reader
        /// </summary>
        private static void InitialiseWriterAndReader()
        {
            _reader = Console.In;
            _writer = Console.Out;
        }
        
        
        /// <summary>
        /// Character Setup
        /// </summary>
        /// <returns>Completed Character</returns>

        private static Character CharacterSetup()
        {
            Character character;

            String input = "";

            SlowType("Welcome to The Killer's Inn \nThere has recently been a murder! You've got all the suspects rounded up in a room shoulder to shoulder. You, the detective are tasked to find out who killed who");
           
            while (true) {
                SlowType("Do you know your name?\n [Y]es or [N]o");
                input = _reader.ReadLine();

                if(input == "Y" || input == "N") {
                    break;
                }
            }

            switch (input)
            {
                case "Y":
                    SlowType("Alright, what is it?");
                    input = _reader.ReadLine();
                    character = new Character(input,"The Detective");
                    break;
                case "N":
                    character = new Character();
                    break;
                default:
                    character = new Character();
                    break;
            }

            input = "";

            SlowType(character.ToString());

            return character;
        }

        /// <summary>
        /// TODO : Implement Slow Type
        /// </summary>
        /// <param name="input"></param>

        private static void SlowType(String input)
        {
            _writer.WriteLine(input);
        }
        
        
    }
}
