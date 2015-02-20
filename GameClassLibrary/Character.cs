using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameClassLibrary
{
    public class CharacterBase
    {
        //http://www.dandwiki.com/wiki/SRD:Strength
        //http://www.wizards.com/default.asp?x=dnd/dnd/charactersheets
#region Member vars
        //CharacterInfo
        private string charactersName;
        private CharacterRace charactersRace;
        private CharacterAlignment characterAlignment;
        private CharacterClass characterClass;
        private CharacterRace characterRace;
        private CharacterDeity characterDeity;
        private string size;
        private decimal age;
        private string gender;
        private string height;
        private string weight;
        private string eyeColor;
        private string hairColor;
        private string skinColor;

        //CharacterGear
        private Wallet charactersWallet;
        private ItemBag charactersItems;

        private HandItem primaryHand;   //Item equipped to primary hand
        private HandItem offHand;       //Item equipped to off hand
        private Armor equipedArmor;
        private int maxNumberOfEquipedAccessories;  //MaxNumberOfAccesoryItemsThatCanBeEquipedByCharecter
        private List<Accessory> equipedAccessories;

        //Stats - These are calculated based on equipedItems, levels, abilities etc.
        private int healthPoints;
        private int maxHealthPoints;
        private StatsContainer cacluatedBaseStats;
        private StatsContainer cacluatedAggragatedStats;
#endregion


#region Properties

        public string CharactersName
        {
            get { return charactersName; }
        }
        public CharacterRace CharactersRace
        {
            get { return charactersRace; }
        }
        public CharacterAlignment CharacterAlignment
        {
            get { return characterAlignment; }
            set { characterAlignment = value; }
        }
        public CharacterClass CharacterClass
        {
            get { return characterClass; }
            set { characterClass = value; }
        }
        public CharacterRace CharacterRace
        {
            get { return characterRace; }
            set { characterRace = value; }
        }
        public CharacterDeity CharacterDeity
        {
            get { return characterDeity; }
            set { characterDeity = value; }
        }

        public string Size
        {
            get { return size; }
        }
        public decimal Age
        {
            get { return age; }
        }
        public string Gender
        {
            get { return gender; }
        }
        public string Height
        {
            get { return height; }
        }
        public string Weight
        {
            get { return weight; }
        }
        public string EyeColor
        {
            get { return eyeColor; }
            set { eyeColor = value; }
        }
        public string HairColor
        {
            get { return hairColor; }
            set { hairColor = value; }
        }
        public string SkinColor
        {
            get { return skinColor; }
        }
        public Wallet CharactersWallet
        {
            get { return charactersWallet; }
        }
        public ItemBag CharactersItems
        {
            get { return charactersItems; }
        }
        public int HealthPoints
        {
            get { return healthPoints; }
            set { healthPoints = value; }
        }
        public int MaxHealthPoints
        {
            get { return maxHealthPoints; }
            set { maxHealthPoints = value; }
        }
        public int MaxNumberOfEquipedAccessories
        {
            get { return maxNumberOfEquipedAccessories; }
            set { maxNumberOfEquipedAccessories = value; }
        }
        public StatsContainer CacluatedBaseStats
        {
            get { return cacluatedBaseStats; }
            set { cacluatedBaseStats = value; }
        }
        public StatsContainer CacluatedAggragatedStats
        {
            get { return cacluatedAggragatedStats; }
            set { cacluatedAggragatedStats = value; }
        }
#endregion

        //saving throws -> Need to figure out how to calculate these
        private int fortitude; //Base + Ability + Magic + Misc + temp (effects Constitution)
        private int reflex; //Base + Ability + Magic + Misc + temp (effects Dexterity)
        private int will; //Base + Ability + Magic + Misc + temp (effects Wisdom)

        private int spellResistance;
        public int SpellResistance
        {
            get { return spellResistance; }
            set { spellResistance = value; }
        }

        public HandItem PrimaryHand
        {
            get { return primaryHand; }
        }
        public HandItem OffHand
        {
            get { return offHand; }
        }
        public Armor EquipedArmor
        {
            get { return equipedArmor; }
        }
        public List<Accessory> EquipedAccessories
        {
            get { return equipedAccessories; }
        }

        //Methods

        public bool EquipPrimaryHand()
        {
            //Logic to equip items
            //If 2 handed item equip both hands
            return true;
        }
        public bool EquipOffHand()
        {
            //Logic to equip item
            //If 2 handed item equip both hands
            return true;
        }
        public bool EquipArmor()
        {
            //Logic to equip armor
            return true;
        }
        public bool UnEquipPrimaryHand()
        {
            primaryHand = null;
            return true;
        }
        public bool UnEquipOffHand()
        {
            offHand = null;
            return true;
        }
        public bool UnEquipArmor()
        {
            equipedArmor = null;
            return true;
        }
        public bool IsPrimaryHandEmpty()
        {
            if (PrimaryHand == null)
            {
                return true;
            }
            return false;
        }
        public bool IsOffHandEmpty()
        {
            if (OffHand == null)
            {
                return true;
            }
            return false;
        }
        public bool IsArmorEquiped()
        {
            if (EquipedArmor == null)
            {
                return true;
            }
            return false;
        }
        public bool EquipAccessory(Accessory AccessoryToEquip)
        {
            if (EquipedAccessories.Count < MaxNumberOfEquipedAccessories)
            {
                MaxNumberOfEquipedAccessories += 1;
                EquipedAccessories.Add(AccessoryToEquip);
            }
            else
            {
                if(ChooseAccessoryToRemove()) 
                {
                    return true;
                }
            }
            return false;

        }
        public bool ChooseAccessoryToRemove()
        {
            bool itemRemoved = false;

            //Logic here to remove item from equiped accessories list
            //If item removed set itemRemoved = true;

            if (itemRemoved)
            {
                return true;
            }
            return false;
        }

        //pull together stats based on: Class, Race, Alignment, and Deity
        public void CalculateBaseStats()
        {
            StatsContainer stats = new StatsContainer();
            stats.AddStats(characterClass.ClassStats);
            stats.AddStats(CharacterRace.RaceStats);
            stats.AddStats(CharacterAlignment.AlignmentStats);
            stats.AddStats(CharacterDeity.DeityStats);

            cacluatedBaseStats = stats;

        }

        //Aggregate 'CACLCUATED' base stats with those gathered from equipment and abilities
        public void CacluateAggragatedStats()
        {
            StatsContainer stats = new StatsContainer();
            stats.AddStats(CacluatedBaseStats);


            cacluatedAggragatedStats = stats;
        }

        //Get a list of abilities based on: Class, Race, Alignment, and Deity
        public void PullTogetherBaseAbilities()
        {

        }

        //Pull together a list containing BASE abilities plus those gained from equipment and items
        public void PullTogetherAllAbilities()
        {

        }


    }

    public class StatsContainer
    {
        private int strength;
        private int dexterity;
        private int constitution;
        private int intelligence;
        private int wisdom;
        private int charisma;
        private int speed;

        public int Strength
        {
            get { return strength; }
            set { strength = value; }
        }
        public int Dexterity
        {
            get { return dexterity; }
            set { dexterity = value; }
        }
        public int Constitution
        {
            get { return constitution; }
            set { constitution = value; }
        }
        public int Intelligence
        {
            get { return intelligence; }
            set { intelligence = value; }
        }
        public int Wisdom
        {
            get { return wisdom; }
            set { wisdom = value; }
        }
        public int Charisma
        {
            get { return charisma; }
            set { charisma = value; }
        }
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public StatsContainer(int str, int dex, int con, int inte, int wis, int cha, int spe)
        {
            strength = str;
            dexterity = dex;
            constitution = con;
            intelligence = inte;
            wisdom = wis;
            charisma = cha;
            speed = spe;
        }
        public StatsContainer()
        {
            strength = 0;
            dexterity = 0;
            constitution = 0;
            intelligence = 0;
            wisdom = 0;
            charisma = 0;
            speed = 0;
        }

        public void AddStats(StatsContainer StatsToAdd)
        {
            if (StatsToAdd.Strength > 0)
            {
                Strength += StatsToAdd.Strength;
            }
            if (StatsToAdd.Dexterity > 0)
            {
                Dexterity += StatsToAdd.Dexterity;
            }
            if (StatsToAdd.Constitution > 0)
            {
                Constitution += StatsToAdd.Constitution;
            }
            if (StatsToAdd.Intelligence > 0)
            {
                Intelligence += StatsToAdd.Intelligence;
            }
            if (StatsToAdd.Wisdom > 0)
            {
                Wisdom += StatsToAdd.Wisdom;
            }
            if (StatsToAdd.Charisma > 0)
            {
                Charisma += StatsToAdd.Charisma;
            }
            if (StatsToAdd.Speed > 0)
            {
                Speed += StatsToAdd.Speed;
            }
        }
    }

    public class CharacterClass
    {
        private string className;
        private string classDescription;
        private int classLevel;
        private List<Ability> classAbilities;
        private int experiencePoints;

        //Stats - These are the base stats for this class and level
        private int healthPoints;
        private int maxHealthPoints;
        private StatsContainer classStats;


        //properties
        public string ClassName
        {
            get { return className; }
        }
        public string ClassDescription
        {
            get { return classDescription; }
            set { classDescription = value; }
        }
        public int ClassLevel
        {
            get { return classLevel; }
        }
        public List<Ability> ClassAbilities
        {
            get { return classAbilities; }
        }
        public int ExperiencePoints
        {
            get { return experiencePoints; }
        }
        public StatsContainer ClassStats
        {
            get { return classStats; }
            set { classStats = value; }
        }

        public void gainExperience(int XP)
        {
            if (XP > 0)
            {
                experiencePoints += XP;
            }

            //Call level up here.
            while (experiencePoints > experienceRequiredToAdvanceLevel())
            {
                if (experiencePoints > experienceRequiredToAdvanceLevel())
                {
                    levelUp();
                }
            }
        }
        private void levelUp()
        {
            classLevel += 1;
            //Recalculate base stats and add abilities here
        }
        public int experienceRequiredToAdvanceLevel()
        {
            //ChrisFlag - Pull this from class
            return 0;
        }

    }

    public class CharacterRace
    {
        string raceName;
        StatsContainer raceStats;
        List<Ability> racialAbilities;
        string raceDescription;

        public CharacterRace(string RaceName, StatsContainer Stats,  List<Ability> RacialAbilities, string RaceDescription)
        {
            raceName = RaceName;
            raceStats = Stats;
            racialAbilities = RacialAbilities;
            raceDescription = RaceDescription;
        }

        public string RaceName
        {
            get { return raceName; }
        }
        public StatsContainer RaceStats
        {
            get { return raceStats; }
            set { raceStats = value; }
        }
        public List<Ability> RacialAbilities
        {
            get { return racialAbilities; }
        }
        public string RaceDescription
        {
            get { return raceDescription; }
            set { raceDescription = value; }
        }
    }

    public class CharacterAlignment
    {
        string alignmentName;
        StatsContainer alignmentStats;
        List<Ability> alignmentAbilities;
        string alignmentDescription;

        public CharacterAlignment(string AlignmentName, StatsContainer Stats,  List<Ability> AlignmentAbilities, string AlignmentDescription)
        {
            alignmentName = AlignmentName;
            alignmentStats = Stats;
            alignmentAbilities = AlignmentAbilities;
            alignmentDescription = AlignmentDescription;
        }

        public List<Ability> AlignmentAbilities
        {
            get { return alignmentAbilities; }
        }
        public StatsContainer AlignmentStats
        {
            get { return alignmentStats; }
            set { alignmentStats = value; }
        }
        public string AlignmentName
        {
            get { return alignmentName; }
        }
        public string AlignmentDescription
        {
            get { return alignmentDescription; }
        }

    }

    public class CharacterDeity
    {
        string deityName;
        StatsContainer deityStats;
        List<Ability> bestowedAbilities;
        string deityDescrption;

        public CharacterDeity(string DeityName, StatsContainer Stats, List<Ability> BestowedAbilities, string DeityDescription)
        {
            deityName = DeityName;
            deityStats = Stats;
            bestowedAbilities = BestowedAbilities;
            deityDescrption = DeityDescription;
        }

        public string DeityName
        {
            get { return deityName; }
        }
        public StatsContainer DeityStats
        {
            get { return deityStats; }
            set { deityStats = value; }
        }
        public List<Ability> BestowedAbilities
        {
            get { return bestowedAbilities; }
        }
        public string DeityDescrption
        {
            get { return deityDescrption; }
        }


    }

    public class Ability
    {
        string abilityName;
        StatsContainer abilityStats;
        string abilityDescription;
        bool passive;   //This ability is passive if it is active all the time, else you have to activate it
        bool active;    //Initialize this at true. If the ability isn't passive then you can turn it off.


        List<Effect> effects;

        public Ability(string AbilityName, StatsContainer stats, string AbilityDescription, List<Effect> Effects, bool Passive)
        {
            abilityName = AbilityName;
            abilityStats = stats;
            abilityDescription = AbilityDescription;
            effects = Effects;
            passive = Passive;
            active = true;  //initialize this as true
        }

        public string AbilityName
        {
            get { return abilityName; }
        }
        public StatsContainer AbilityStats
        {
            get { return abilityStats; }
            set { abilityStats = value; }
        }
        public string AbilityDescription
        {
            get { return abilityDescription; }
        }
        public List<Effect> Effects
        {
            get { return effects; }
        }
        public bool Passive
        {
            get { return passive; }
        }
        public bool Active
        {
            get { return active; }
            set
            {
                if (Passive)
                {
                    active = true;
                }
                else
                {
                    active = value;
                }
            }
        }


    }

    public class Effect
    {
        string effectName;
        string effectDescription;
        //Create way to track and resolve effects
    }
}
