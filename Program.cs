using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

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
        private static int _numberOfInteractions;
        private static bool _gameOver;
        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            Initialise();
            _room = new TheRoom(CharacterSetup());
            SlowType("");
            Rules();
            SlowType("");
            GameplayLoop();
            

        }

        static void GameplayLoop()
        {
            while (true)
            {
                RevealRoom();
                NonPlayableCharacter selectedCharacter = CharacterSelection();
                CharacterInteraction(selectedCharacter);
                if (_gameOver)
                {
                    break;
                }
            
            }

        }

        private static NonPlayableCharacter CharacterSelection()
        {
            SlowType("Who would you like to interact with? [Enter Number]");
            
            
            int input;
            try
            {   
                input = int.Parse(_reader.ReadLine());
                return _room.SelectCharacter(input);
            }
            catch (Exception e)
            {
                SlowType("Invalid input, please try again.");
                SlowType(e.ToString());
                CharacterSelection();
            }
           
            throw new Exception("No character selectable");
        }

        private static void CharacterInteraction(NonPlayableCharacter character)
        {
        
            String conversationTypeResponse = PlayerInteractionResponse("Would you like to check "+ character +"'s [I]nventory,  [Q]uestion them or [A]ccuse them!", new []{"I","Q", "A"});

            switch (conversationTypeResponse) 
            {
                case "I":
                    SlowType(character.Respond(ConversationType.INVENTORY));
                    break;
                case "Q":
                    SlowType(character.Respond(ConversationType.QUESTION));
                    break;
                case "A":
                    
                    if (character is KillerNonPlayableCharacter)
                    {
                        SlowType(character.Respond(ConversationType.CONFESSION));
                        _gameOver = true;
                    }
                    break;
                        
            }
            
            _numberOfInteractions++;
            if (_numberOfInteractions == 2)
            {
                SlowType(_room.Kill());
                _numberOfInteractions = 0;

            }


        }

        /// <summary>
        /// Automates Player Interaction With Program.
        /// Simulates Following Prompt :
        /// Would you like to [A] [B] [C]
        /// And until the player types a valid option it loops.
        /// </summary>
        /// <param name="prompt"></param>
        /// <param name="expectedResponses"></param>
        /// <returns></returns>
        private static String PlayerInteractionResponse(String prompt, String[] expectedResponses)
        {
            String input = "";
            while (true)
            {
                SlowType(prompt);
                input = _reader.ReadLine();
                foreach (var expectedResponse in expectedResponses)
                {
                    if (expectedResponse == input)
                    {
                        return input;
                    } 
                }
            }
        }
        
        private static void RevealRoom()
        {
            SlowType("The suspects currently alive in the room are :  " +  _room);
        }

        public static void Rules()
        {
            SlowType("The rules are as follows : You're on the clock, the longer you take the more people will die. Time to guess who the killer is.");
            SlowType("");
        }
        
        /// <summary>
        /// Initialises Writer And Reader And Number of Interactions
        /// </summary>
        private static void Initialise()
        {
            _reader = Console.In;
            _writer = Console.Out;
            _numberOfInteractions = 0;
            _gameOver = false;
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


            input = PlayerInteractionResponse("Do you know your name? [Y]es or [N]o?", new []{"Y","N"});
            
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
        /// Simulates typing. Using thread timer approach. 
        /// </summary>
        /// <param name="input"></param>

        private static void SlowType(String input)
        {
            string[] words = input.Split(' ');
            Task t = Task.Run(() =>
            {
                foreach (string word in words) {
                    foreach (char letter in word) {
                        _writer.Write(letter);
                        Thread.Sleep(100);
                    }

                    _writer.Write(" ");
                    Thread.Sleep(250);
                }
            });
            t.Wait();
            _writer.WriteLine("");
        }
        
        
    }
}
