using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Roguelike
{
    public class KillerNonPlayableCharacter : NonPlayableCharacter
    {
        public KillerNonPlayableCharacter(Character character, Inventory inventory, Dictionary<ConversationType, RandomList<String>> responses, String title, int id) : base(character, inventory, responses, title, id)
        {
            // Removes an item to make sure all characters have the same number of items
            //Inventory.RemoveAt(0);
        
            // Add Killing Weapon

            Inventory.Add(new Item("Knife"));
            
            // Add Inventory Responses

            Responses.Remove(ConversationType.INVENTORY);
            
            String list = Inventory.ToString();
            Responses.Add(ConversationType.INVENTORY, new RandomList<string>
            {
                "I am currently carrying the following " + list,
                "All I have is the following " + list,
                list + " are all the items I posses right now.",
                "I have " + list + ", and money ain't a problem."
            });
            
            
        }

        public KillerNonPlayableCharacter(NonPlayableCharacter nonPlayableCharacter) : base(nonPlayableCharacter)
        {
           
            Responses = nonPlayableCharacter.Responses;
            Responses.Remove(ConversationType.INVENTORY);
            Item knife = new Item("Knife");
            Inventory.Add(knife);
            
            
            Responses.Add(ConversationType.INVENTORY, new RandomList<string>
            {
                "I am currently carrying the following: " + Inventory,
                "In my bag I have: " + Inventory,
                Inventory+ " is all I have.",
                "I have :" + Inventory + ". And money ain't a problem."
            });
         
            // Removes an item to make sure all characters have the same number of items
            //Inventory.RemoveAt(0);
 
        }


        /// <summary>
        /// Reveal! 
        /// </summary>
        /// <returns></returns>

        public override string Reveal()
        {
            return Name + " is the killer!";
        }


        /// <summary>
        /// Kills The Character Adjacent To The Killer. 
        /// </summary>
        /// <param name="character"></param>
        /// <param name="characters"></param>
        /// <returns></returns>
        public string Kill(RandomList<NonPlayableCharacter> characters)
        {
            NonPlayableCharacter killedCharacter;
            int index = characters.IndexOf(this);
            // Handling First Character Case
            if (index == 0)
            {
                killedCharacter = KillCharacter(characters.Count -1, index +1, characters);
            }
            // Handling Boundary Case
            else if(index == characters.Count -1)
            {
                // Finding Characters
                
                NonPlayableCharacter leftCharacter = characters[index - 1];
                NonPlayableCharacter rightCharacter = characters[0];

                killedCharacter = KillCharacter(index - 1, 0, characters);

            }
            else
            {
                killedCharacter = KillCharacter(index - 1, index + 1, characters);
            }
            
            return killedCharacter + " dropped dead... Who is the killer...";
        }


        private NonPlayableCharacter KillCharacter(int leftCharacterIndex, int rightCharacterIndex, RandomList<NonPlayableCharacter> characters)
        {
            // Finding Characters That It Can Kill (Left and Right)
                
            NonPlayableCharacter leftCharacter = characters[leftCharacterIndex];
            NonPlayableCharacter rightCharacter = characters[rightCharacterIndex];
                
            // Making List with Two Potential Characters
                
            RandomList<NonPlayableCharacter> possibleKillableCharacters = new RandomList<NonPlayableCharacter>{leftCharacter, rightCharacter};

            // Generating Character That Dies
                
            NonPlayableCharacter killedCharacter = possibleKillableCharacters.Roll();
                
            // Killing Character
               
            characters.Remove(killedCharacter);
            
            // Returning Character (To Use For Printing)

            return killedCharacter;
        }
       
        

        
    }
}