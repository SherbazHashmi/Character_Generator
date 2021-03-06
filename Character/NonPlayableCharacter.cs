using System;
using System.Collections.Generic;

namespace Roguelike
{
    public class NonPlayableCharacter : Character
    {
        public Inventory Inventory;
        public Dictionary<ConversationType, RandomList<String>> Responses;
        public int ID;
        
        public NonPlayableCharacter(Character character, Inventory inventory, Dictionary<ConversationType, RandomList<String>> responses, String title, int id) 
        {
            Name = character.Name;
            Age = character.Age;
            _characteristics = character._characteristics;
            Inventory = inventory;
            Title = title;
            ID = id;

            Responses = responses;
            
            // Adding Inventory Responses
            
            Responses.Add(ConversationType.INVENTORY, new RandomList<string>
            {
                "I am currently carrying the following: " + Inventory,
                "In my bag I have: " + Inventory,
                Inventory + " is all I have.",
                "I have :" + Inventory + ". And money ain't a problem."
            });
        }


        public NonPlayableCharacter(NonPlayableCharacter nonPlayableCharacter)
        {
            Name = nonPlayableCharacter.Name;
            Age = nonPlayableCharacter.Age;
            _characteristics = nonPlayableCharacter._characteristics;
            Inventory = nonPlayableCharacter.Inventory;
            Title = nonPlayableCharacter.Title;
            ID = nonPlayableCharacter.ID;
        }

    


        public override string ToString()
        {
            return  "[" + ID + "] " + Name + " " + Title;
        }
        

        public virtual string Reveal()
        {
            return Name + " is  not the killer...";
        }

        public void EquipItem(Item item)
        {
            Inventory.Add(item);
        }

        public String Respond (ConversationType conversationType)
        {
            RandomList<String> responses;

            switch (conversationType)
            {
                case ConversationType.QUESTION:
                    responses = Responses[ConversationType.QUESTION];
                    return responses.RollAndRemove();
                case ConversationType.INVENTORY:
                    responses = Responses[ConversationType.INVENTORY];
                    return responses.RollAndRemove();
                case ConversationType.CONFESSION:
                    responses = Responses[ConversationType.CONFESSION];
                    return responses.RollAndRemove();
                default:
                    return null;
            }
            
        }
        
        
        
    }
}