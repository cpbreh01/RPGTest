using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GameEngine.Classes
{
    public class character
    {
        //character information
        string name;
        int age;
        string gender;
        string size;
        string eyeColor;
        string skinColor;
        string dominantHand; //left or right

        //Race
        racialClass racialClass;

        //Class
        charClass primaryClass;
        charClass secondaryClass;

        int xp;
        int spentXp; //Use xp to purchase levels, to gain abilities and modify base stats
       
        //Character BaseStats (increased based on level and class)
        int hp;
        int strength;
        int dexterity;
        int constitution;
        int intelligence;
        int wisdom;
        int charisma;

        ConsolidatedEquipment characterEquipment;

        public string Name
        {
            get { return name; }
        }
        public int Age
        {
            get { return age; }
        }
        public string Gender
        {
            get { return gender; }
        }
        public string Size
        {
            get { return size; }
        }
        public string EyeColor
        {
            get { return eyeColor; }
        }
        public string SkinColor
        {
            get { return skinColor; }
        }
        public string DominantHand
        {
            get { return dominantHand; }
        }
        public racialClass RacialClass
        {
            get { return racialClass; }
        }
        public charClass PrimaryClass
        {
            get { return primaryClass; }
        }
        public charClass SecondaryClass
        {
            get { return secondaryClass; }
        }

        public int Xp
        {
            get { return xp; }
            set {
                    if (value > 0)
                    {
                        xp = value;
                    }
                }
        }
        public int SpentXp
        {
            get { return spentXp; }
            set {
                    if (value > 0)
                    {
                        spentXp = value;
                    }
                }
        }
        public int Hp
        {
            get { return hp; }
            set {
                    if (value < 0)
                    {
                        hp = 0;
                    }
                    else
                    {
                        hp = value;
                    }
                }
        }
        public int Strength
        {
            get { return strength; }
            set
            {
                if (value < 0)
                {
                    strength = 0;
                }
                else
                {
                    strength = value;
                }
            }
        }
        public int Dexterity
        {
            get { return dexterity; }
            set
            {
                if (value < 0)
                {
                    dexterity = 0;
                }
                else
                {
                    dexterity = value;
                }
            }
        }
        public int Constitution
        {
            get { return constitution; }
            set
            {
                if (value < 0)
                {
                    constitution = 0;
                }
                else
                {
                    constitution = value;
                }
            }
        }
        public int Intelligence
        {
            get { return intelligence; }
            set
            {
                if (value < 0)
                {
                    intelligence = 0;
                }
                else
                {
                    intelligence = value;
                }
            }
        }
        public int Wisdom
        {
            get { return wisdom; }
            set
            {
                if (value < 0)
                {
                    wisdom = 0;
                }
                else
                {
                    wisdom = value;
                }
            }
        }
        public int Charisma
        {
            get { return charisma; }
            set
            {
                if (value < 0)
                {
                    charisma = 0;
                }
                else
                {
                    charisma = value;
                }
            }
        }
        internal ConsolidatedEquipment CharacterEquipment
        {
            get { return characterEquipment; }
            set { characterEquipment = value; }
        }
 
    }


    public class Ability
    {
        private bool isEnchantment;
        private List<Effects> AssocEffects;

    }

    public class Effects
    {
        //ChrisFLAG
    }


}
