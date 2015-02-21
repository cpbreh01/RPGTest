using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Classes
{
    //base information
    class EquipmentBase
    {
        private Guid id;
        private string name;
        private decimal weight;
        private string rarity;
        private bool equiped;

        //item stats
        private int strMod;
        private int dexMod;
        private int conMod;
        private int intMod;
        private int wisMod;
        private int chaMod;
        private int hpMod;

        private List<Ability> abilities;

        #region properties

        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
        }
        public decimal Weight
        {
            get { return weight; }
        }
        public string Rarity
        {
            get { return rarity; }
        }
        public int StrMod
        {
            get { return strMod; }
        }
        public int DexMod
        {
            get { return dexMod; }
        }
        public int ConMod
        {
            get { return conMod; }
        }
        public int IntMod
        {
            get { return intMod; }
        }
        public int WisMod
        {
            get { return wisMod; }
        }
        public int ChaMod
        {
            get { return chaMod; }
        }
        public List<Ability> Abilities
        {
            get { return abilities; }
            set { abilities = value; }
        }
        public int HpMod
        {
            get { return hpMod; }
            set { hpMod = value; }
        }
        #endregion

        //Null constructor
        public EquipmentBase()
        {
            Id = Guid.Empty;
            name = "Nothing Equipped";
            weight = 0;
            rarity = string.Empty;

             strMod = 0;
             dexMod = 0;
             conMod = 0;
             intMod = 0;
             wisMod = 0;
             chaMod = 0;
             hpMod = 0;

             abilities = new List<Ability>();

        }

        public void addEnchantment(Ability EnchantMentToAdd)
        {
            abilities.Add(EnchantMentToAdd);
        }

        public void removeEnchantment(Ability EnchantMentToRemove)
        {
            abilities.Remove(EnchantMentToRemove);
        }
        
    }

    class Helmet : EquipmentBase
    {
        string armorClass;

        public Helmet()
        {

        }
    }

    class Armor : EquipmentBase
    {
        string armorClass;

        public Armor()
        {

        }
    }

    class Gauntlets : EquipmentBase
    {
        string armorClass;

        public Gauntlets()
        {

        }
    }

    class Boots : EquipmentBase
    {
        string armorClass;

        public Boots()
        {

        }
    }

    class Accessory : EquipmentBase
    {
        string accessoryType;

        public Accessory()
        {

        }
    }

    class OffHandItem : EquipmentBase
    {
        string itemType;

        public OffHandItem()
        {
        }
    }

    class DominantHandItem : EquipmentBase
    {
        string itemType;

        public DominantHandItem()
        {
        }
    }

    class ConsolidatedEquipment
    {
        //ConsolidatedEquipmentStats (This is what we are keeping track of)
        private int eStr;
        private int eDex;
        private int eCon;
        private int eInt;
        private int eWis;
        private int eCha;
        private decimal eWeight;
        private int eHp;
        List<Ability> abilities;

        //Armor/Accessories (To be set through equip and un-equip Methods only)
        private Helmet equipedHelmet;
        private Armor equipedArmor;
        private Gauntlets equipedGauntlets;
        private Boots equipedBoots;
        private OffHandItem equipedOffHandItem;
        private DominantHandItem equipedDominantHandItem;
        private List<Accessory> equipedAccessories = new List<Accessory>();

        #region properties
        public int EStr
        {
            get { return eStr; }
        }
        public int EDex
        {
            get { return eDex; }
        }
        public int ECon
        {
            get { return eCon; }
        }
        public int EInt
        {
            get { return eInt; }
        }
        public int EWis
        {
            get { return eWis; }
        }
        public int ECha
        {
            get { return eCha; }
        }
        public decimal EWeight
        {
            get { return eWeight; }
        }
        internal List<Accessory> EquipedAccessories
        {
            get { return equipedAccessories; }
        }
        public int EHp
        {
            get { return eHp; }
            set { eHp = value; }
        }
        #endregion

        #region methods

        public void equipItem(Helmet _helmetToEquip)
        {
            equipedHelmet = _helmetToEquip;
            reComputeConsolidatedStats();
        }
        public void equipItem(Armor _armorToEquip)
        {
            equipedArmor = _armorToEquip;
            reComputeConsolidatedStats();
        }
        public void equipItem(Gauntlets _gauntletsToEquip)
        {
            equipedGauntlets = _gauntletsToEquip;
            reComputeConsolidatedStats();
        }
        public void equipItem(Boots _bootsToEquip)
        {
            equipedBoots = _bootsToEquip;
            reComputeConsolidatedStats();
        }
        public void equipItem(OffHandItem _offHandItemToEquip)
        {
            equipedOffHandItem = _offHandItemToEquip;
            reComputeConsolidatedStats();
        }
        public void equipItem(DominantHandItem _dominantHandItemToEquip)
        {
            equipedDominantHandItem = _dominantHandItemToEquip;
            reComputeConsolidatedStats();
        }
        public void equipItem(Accessory accessoryToEquip)
        {
            equipedAccessories.Add(accessoryToEquip);
            reComputeConsolidatedStats();
        }

        /// <summary>
        /// Looks for equipped item with matching GUID
        /// </summary>
        /// <param name="itemToRemove">Item to be unequipped</param>
        /// <returns>Guid of removed item, or GUID.null</returns>
        private Guid unEquipItem(EquipmentBase itemToRemove)
        {
            Guid GuidOfFormerlyEquipedItem = Guid.Empty; //set only if item is removed

            if (equipedHelmet.Id == itemToRemove.Id)
            {
                GuidOfFormerlyEquipedItem = itemToRemove.Id;
                equipedHelmet = new Helmet();
            }
            else if (equipedArmor.Id == itemToRemove.Id)
            {
                GuidOfFormerlyEquipedItem = itemToRemove.Id;
                equipedArmor = new Armor();
            }
            else if (equipedGauntlets.Id == itemToRemove.Id)
            {
                GuidOfFormerlyEquipedItem = itemToRemove.Id;
                equipedGauntlets = new Gauntlets();
            }
            else if (equipedBoots.Id == itemToRemove.Id)
            {
                GuidOfFormerlyEquipedItem = itemToRemove.Id;
                equipedBoots = new Boots();
            }
            else if (equipedOffHandItem.Id == itemToRemove.Id)
            {
                GuidOfFormerlyEquipedItem = itemToRemove.Id;
                equipedOffHandItem = new OffHandItem();
            }
            else if (equipedDominantHandItem.Id == itemToRemove.Id)
            {
                GuidOfFormerlyEquipedItem = itemToRemove.Id;
                equipedDominantHandItem = new DominantHandItem();
            }
            else
            {
                foreach (Accessory item in equipedAccessories)
                {
                    if (item.Id == itemToRemove.Id)
                    {
                        GuidOfFormerlyEquipedItem = itemToRemove.Id;
                        equipedAccessories.Remove(item);
                    }
                }
            }

            reComputeConsolidatedStats();
            return GuidOfFormerlyEquipedItem;

        }

        /// <summary>
        /// puts together a list of all equiped items
        /// </summary>
        /// <returns></returns>
        private List<EquipmentBase> GetListOfEquipedItems()
        {
            List<EquipmentBase> _equipedItems = new List<EquipmentBase>(); //Get a list of all Equipped items, cast as EquipmentBase

            foreach (Accessory item in equipedAccessories)
            {
                _equipedItems.Add(item);
            }
            _equipedItems.Add(equipedArmor);
            _equipedItems.Add(equipedBoots);
            _equipedItems.Add(equipedGauntlets);
            _equipedItems.Add(equipedHelmet);
            _equipedItems.Add(equipedDominantHandItem);
            _equipedItems.Add(equipedOffHandItem);

            return _equipedItems;
        }
        /// <summary>
        /// Update consolidated stats
        /// </summary>
        public void reComputeConsolidatedStats()
        {
            //Stats to compute
            int _str = 0;
            int _dex = 0;
            int _con = 0;
            int _int = 0;
            int _wis = 0;
            int _cha = 0;
            int _hp = 0;
            decimal _weight = 0;
            List<Ability> _abilities = new List<Ability>();

            List<EquipmentBase> _equipedItems = GetListOfEquipedItems();

            //get totals for equipped items
            foreach (EquipmentBase item in _equipedItems)
            {
                _str += item.StrMod;
                _dex += item.DexMod;
                _con += item.ConMod;
                _int += item.IntMod;
                _wis += item.WisMod;
                _cha += item.ChaMod;
                _hp += item.HpMod;
                _weight += item.Weight;

                foreach (Ability abl in item.Abilities)
                {
                    _abilities.Add(abl);
                }

            }

            //Set Totals and abilities
            eStr = _str;
            eDex = _dex;
            eCon = _con;
            eInt = _int;
            eWis = _wis;
            eCha = _cha;
            eHp = _hp;
            eWeight= _weight;
            abilities = _abilities;
        }

        #endregion
    }
}
