using System;
using System.Collections.Generic;
namespace Roguelike
{
    public class TheRoom
    {
        private Character _player;
        private RandomList<NonPlayableCharacter> _characters;
        public KillerNonPlayableCharacter _killer;

        public TheRoom(Character player)
        {
            _player = player;
            AddCharacters();
            SelectKiller();
        }


        public override string ToString()
        {
            return _characters.ToString();
        }

        public string Kill()
        {
            return _killer.Kill(_characters);
        }
        public NonPlayableCharacter SelectCharacter(int id)
        {
            foreach (var character in _characters)
            {
                if (character.ID == id)
                {
                    return character;
                }
            }

            throw new Exception("Character With That ID Not Found");
        }

        private void SelectKiller()
        {
            KillerNonPlayableCharacter killer = new KillerNonPlayableCharacter(_characters.RollAndRemove());
            _killer = killer;
            _characters.Add(killer);
        }
        

        private void AddCharacters()
        {
            _characters = new RandomList<NonPlayableCharacter>
            {
                // NPC 1: The Farmer
                
                new NonPlayableCharacter(
                    new Character(), 
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
                        {ConversationType.QUESTION, new RandomList<string>{
                            "I am just a farmer, trying to sell the few berries I have..",
                            "Hey, I swear I didn't do nothing.. I just herd the sheep to sleep",
                            "I 'ain't done nothing, just a humble farmer",
                            "If you 'ain't interested in the berries I suggest you bring yer business somewhere else matey..."
                        }}, {ConversationType.CONFESSION, new RandomList<string>
                        {
                            "That money hungry pig was trying to steal my land, take all my crops. I wasn't about to let my livelihood be taken away!",
                            "He stole my berries every year, when I approached him, we got into a fight and he slipped. I swear it was an accident..."
                        }}
                    }, "The Farmer", 1),
                
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
                        {ConversationType.QUESTION, new RandomList<string>{
                            "Oh my gosh! Did someone die? Can I see? *creepily stares*",
                            "You're looking pale... could be a case of scurvy. Might want to get it checked out",
                            "See me at the clinic if you need to buy any medicine",
                            "Better watch out for the flu season!"
                        }}, 
                        {ConversationType.CONFESSION, new RandomList<string>
                        {
                            "It was just one little mistake.. one ounce too much. Surely can't be that bad... can it? I guess it was... It was me",
                            "He said he wanted to serenade but I mistook it for cyanide... oops..."
                        }}
                    },"The Doctor", 2),
                
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
                        {ConversationType.QUESTION, new RandomList<string>{
                            "They say I look like Will from something.. I wonder what they mean...",
                            "Need anything forged? Well you're in trouble as this game doesn't have any forging",
                            "I do fancy jewelries and trinkets too, not just blades and shields",
                            "Gets pretty hot here down at the forge"
                        }}, 
                        {ConversationType.CONFESSION, new RandomList<string>
                        {
                            "I swear, I aimed at the shield but it flung out of my hand and hit his head... ",
                            "He stole my family heirloom, an emerald crested necklace from my great grandmother to The King, he deserved what he got."
                        }}
                    },"The Blacksmith", 3),
                
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
                        {ConversationType.QUESTION, new RandomList<string>{
                            "Need a place to stay? Get off that computer chair and do something then!",
                            "Fancy a glass of mead? A slice of cake no not a cake a bowl of soup no no non on ono no a grilled venison nononono wait fancy a glass of mead? um... uh... some leak soup maybe? yeah.",
                            "We've got warm beds if you're looking.. wait if you're looking.. wait NO! We've got warm uh.. too much social for a day",
                            "You're not from around here are you?"
                        }},
                        {ConversationType.CONFESSION, new RandomList<string>
                        {
                            "He wanted to stay a night, what I didn't know was that it was in my wife's room... He had it coming.",
                            "He threatened to defame my inn by spreading rumours that it was a whore house. I had to do what I did for my reputation"
                        }}
                    },"The Innkeeper", 4),
                
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
                        {ConversationType.QUESTION, new RandomList<string>{
                            "Hi! I am the seamstress and you seamstress-ed",
                            "Would you like a vest, a pretty dress for your partner perhaps?",
                            "Have you seen my pin-cushion anywhere?",
                            "Forgive me for being so distracted, I am not used to murders and all"
                        }},
                        {ConversationType.CONFESSION, new RandomList<string>
                        {
                            "I made him a jacket but forgot to take the needle out of the collar... Oops.",
                            "He stole my notebook from me, all my designs, all my work he claimed as his own. Then he made off with the money"
                        }}
                    },"The Seamstress", 5),
                
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
                        {ConversationType.QUESTION, new RandomList<string>{
                            "Where have I kept my book on solving murders... just a minute... nope don't have it",
                            "You look like a person of great taste",
                            "Might I suggest a book for your grievances?",
                            "You look like a worm... a book worm! Ha!"
                        }},
                        {ConversationType.CONFESSION, new RandomList<string>
                        {
                            "I was working in the library, putting books upon the highest shelf when one slipped.. and hit him on the head... ",
                            "He wouldn't stay quiet so somebody had to shut him up!"
                        }}
                    },"The Bookkeeper", 6),
                        
                     
                
                
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
                        {ConversationType.QUESTION, new RandomList<string>{
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
                    },"The Begger", 7),
                
                
                // NPC 8: The King
                
                new NonPlayableCharacter(new Character(),
                    new Inventory(new List<Item>
                    {
                        new Item("Ruby ring"),
                        new Item("Emerald necklace"),
                        new Item("Handkerchief"),
                        new Item("Rag")
                    }),
                    new Dictionary<ConversationType, RandomList<string>>
                    {
                        // Questions
                        {ConversationType.QUESTION, new RandomList<string>{
                            "What are you? A peasant with a raggedy suit and a monocle parading around as a det-ec-tive... ",
                            "Let me out of here! I have more pressing matters to attend to",
                            "You smell like a peasant... have some perfume. Better than bathing",
                            "You MUST LET ME OUT, I just came here to receive a necklace"
                        }}, 
                        {ConversationType.CONFESSION, new RandomList<string>
                        {
                            "He wanted to wed my daughter the princess and I wouldn't have scum like him breed within our royal family!",
                            "He was a spy I tell you.. reconnaissance of another land. He would have killed me if I hadn't have killed him first!"
                        }}
                    },"The King", 8),
                
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
                        {ConversationType.QUESTION, new RandomList<string>{
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
                    },"The Bartender", 9)
                
                
                
                    
            };
        }


        
    }
}