using System;
using System.Collections.Generic;
namespace Roguelike
{
    public class TheRoom
    {
        private Character _player;
        private RandomList<NonPlayableCharacter> _characters;

        public TheRoom()
        {
            
        }

        private void AddCharacters()
        {
            _characters = new RandomList<NonPlayableCharacter>
            {
                // NPC 1: The Farmer
                
                new NonPlayableCharacter(new Character(),
                    new Inventory(new List<Item>
                    {
                        new Item("Rag"),
                        new Item("Spoon"),
                        new Item("A crust of bread"),
                        new Item("Hat"),
                        new Item("Satchel of berries")
                    }),
                    new Dictionary<ConversationType, RandomList<string>>
                    {
                        // Questions
                        {ConversationType.QUESTION, new RandomList<String>{
                            "I am just a farmer, trying to sell the few berries I have..",
                            "Hey, I swear I didn't do nothing.. I just herd the sheep to sleep",
                            "I 'ain't done nothing, just a humble farmer",
                            "If you 'ain't interested in the berries I suggest you bring yer business somewhere else matey..."
                        }}
                    }),
                
                // NPC 2: The Doctor
                
                new NonPlayableCharacter(new Character(),
                    new Inventory(new RandomList<Item>
                    {
                        new Item("Syringe"),
                        new Item("Bloody rag"),
                        new Item("Satchel of medicine"),
                        new Item("Mask")
                    }),
                    new Dictionary<ConversationType, RandomList<string>>
                    {
                        // Questions
                        {ConversationType.QUESTION, new RandomList<String>{
                            "Oh my gosh! Did someone die? Can I see? *creepily stares*",
                            "You're looking pale... could be a case of scurvy. Might want to get it checked out",
                            "See me at the clinic if you need to buy any medicine",
                            "Better watch out for the flu season!"
                        }}
                    }),
                
                // NPC 3: The Blacksmith
                
                new NonPlayableCharacter(new Character(),
                    new Inventory(new RandomList<Item>
                    {
                        new Item("Satchel of gold"),
                        new Item("Iron ingot"),
                        new Item("Broken handle"),
                        new Item("Rag")
                    }),
                    new Dictionary<ConversationType, RandomList<string>>
                    {
                        // Questions
                        {ConversationType.QUESTION, new RandomList<String>{
                            "They say I look like Will from something.. I wonder what they mean...",
                            "Need anything forged? Well you're in trouble as this game doesn't have any forging",
                            "I do fancy jewelries and trinkets too, not just blades and shields",
                            "Gets pretty hot here down at the forge"
                        }}
                    }),
                
                // NPC 4: The Innkeeper 
                
                new NonPlayableCharacter(new Character(),
                    new Inventory(new RandomList<Item>
                    {
                        new Item("Hearthstone"),
                        new Item("Keys"),
                        new Item("Roster of guests"),
                        new Item("Rag")
                    }),
                    new Dictionary<ConversationType, RandomList<string>>
                    {
                        // Questions
                        {ConversationType.QUESTION, new RandomList<String>{
                            "Need a place to stay? Get off that computer chair and do something then!",
                            "Fancy a glass of mead? A slice of cake no not a cake a bowl of soup no no non on ono no a grilled venison nononono wait fancy a glass of mead? um... uh... some leak soup maybe? yeah.",
                            "We've got warm beds if you're looking.. wait if you're looking.. wait NO! We've got warm uh.. too much social for a day",
                            "You're not from around here are you?"
                        }}
                    }),
                
                // NPC 5: The Seamstress
                
                new NonPlayableCharacter(new Character(),
                    new Inventory(new RandomList<Item>
                    {
                        new Item("Yarn"),
                        new Item("Blunt needle"),
                        new Item("Satchel of beads"),
                        new Item("Rag")
                    }),
                    new Dictionary<ConversationType, RandomList<string>>
                    {
                        // Questions
                        {ConversationType.QUESTION, new RandomList<String>{
                            "Hi! I am the seamstress and you seamstress-ed",
                            "Would you like a vest, a pretty dress for your partner perhaps?",
                            "Have you seen my pin-cushion anywhere?",
                            "Forgive me for being so distracted, I am not used to murders and all"
                        }}
                    }),
                
                // NPC 6: The Bookkeeper
                
                new NonPlayableCharacter(new Character(),
                    new Inventory(new RandomList<Item>
                    {
                        new Item("Self help book"),
                        new Item("Reading glasses"),
                        new Item("Leaky pen"),
                        new Item("Rag")
                    }),
                    new Dictionary<ConversationType, RandomList<string>>
                    {
                        // Questions
                        {ConversationType.QUESTION, new RandomList<String>{
                            "Where have I kept my book on solving murders... just a minute... nope don't have it",
                            "You look like a person of great taste",
                            "Might I suggest a book for your grievances?",
                            "You look like a worm... a book worm! Ha!"
                        }},
                        {ConversationType.CONFESSION, new RandomList<string>
                        {
                            "",
                            ""
                        }}
                    }),
                        
                     
                
                
                // NPC 7: The Beggar
                
                new NonPlayableCharacter(new Character(),
                    new Inventory(new RandomList<Item>
                    {
                        new Item("Dirty rag"),
                        new Item("Semi-dirty rag"),
                        new Item("Extremely dirty rag"),
                        new Item("Bowl")
                    }),
                    new Dictionary<ConversationType, RandomList<string>>
                    {
                        // Questions
                        {ConversationType.QUESTION, new RandomList<String>{
                            "Have any clean rags?",
                            "Spare a coin for a poor man",
                            "I ate my last clean rag",
                            "My bowl is looking empty.... *looks into your eyes*"
                        }}, {ConversationType.CONFESSION, new RandomList<string>
                        {
                            "He took everything from me: my house, my land and my farm. He deserved it.",
                            "I was minding my own business... one day he came to me and told me he'd kill me if I didn't get a job... so I killed him first"
                           }
                        }
                    }),
                
                
                // NPC 8: The King
                
                new NonPlayableCharacter(new Character(),
                    new Inventory(new List<Item>
                    {
                        new Item("Ruby ring"),
                        new Item("Jeweled locket"),
                        new Item("Handkerchief"),
                        new Item("Rag")
                    }),
                    new Dictionary<ConversationType, RandomList<string>>
                    {
                        // Questions
                        {ConversationType.QUESTION, new RandomList<String>{
                            "What are you? A peasant with a raggedy suit and a monocle parading around as a det-ec-tive... ",
                            "Let me out of here! I have more pressing matters to attend to",
                            "You smell like a peasant... have some perfume. Better than bathing",
                            "You MUST LET ME OUT"
                        }}, 
                        {ConversationType.CONFESSION, new RandomList<string>
                        {
                            "He wanted to wed my daughter the princess and I wouldn't have scum like him breed within our royal family!",
                            "He was a spy I tell you.. reconnaissance of another land. He would have killed me if I hadn't have killed him first!"
                        }}
                    }),
                
                // NPC 9: The Bartender
                
                new NonPlayableCharacter(new Character(),
                    new Inventory(new List<Item>
                    {
                        new Item("Notebook"),
                        new Item("Spoon"),
                        new Item("Tankard"),
                        new Item("Stained Rag")
                    }),
                    new Dictionary<ConversationType, RandomList<string>>
                    {
                        // Questions
                        {ConversationType.QUESTION, new RandomList<String>{
                            "Gosh, all drinks on me after this one",
                            "Yeah.. I am gonna need an extra glass after tonight",
                            "Never have I missed a limitless tap more than now..",
                            "Never have I ever seen someone get wasted like this before.."
                        }},
                        {ConversationType.CONFESSION, new RandomList<string>
                            {
                             "Fine! You caught me.. The man was trying to buy the bar and extend his horrific store there. Literally nobody wants it in this town",
                             "I did in fact kill him, but he had it coming, he had been stealing my kegs for years"
                            }
                        }
                    })
                
                
                
                    
            };
        }

        private void SelectKiller()
        {
            KillerNonPlayableCharacter killer = new KillerNonPlayableCharacter(_characters.RollAndRemove());
            _characters.Add(killer);
        }
        
    }
}