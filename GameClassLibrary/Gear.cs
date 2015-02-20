using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameClassLibrary
{

    public class HandItem : Item
    {
        int healthPointsMod;
        int strengthMod;
        int dexterityMod;
        int constitutionMod;
        int intelligenceMod;
        int wisdomMod;
        int charismaMod;
        int speedMod;
    }

    public class Weapon : HandItem
    {
        int numberOfHandsToWield;
    }

    public class Sheild : HandItem
    {
        int numberOfHandsToWield;
    }

    public class Armor : Item
    {
        int healthPointsMod;
        int strengthMod;
        int dexterityMod;
        int constitutionMod;
        int intelligenceMod;
        int wisdomMod;
        int charismaMod;
        int speedMod;
    }

    public class Accessory : Item
    {
        int healthPointsMod;
        int strengthMod;
        int dexterityMod;
        int constitutionMod;
        int intelligenceMod;
        int wisdomMod;
        int charismaMod;
        int speedMod;
    }

    public class HeadGear : Item
    {
        int healthPointsMod;
        int strengthMod;
        int dexterityMod;
        int constitutionMod;
        int intelligenceMod;
        int wisdomMod;
        int charismaMod;
        int speedMod;
    }



    public class ItemBag
    {
        string bagName;
        List<Item> ItemsContained;

        public void AddItem(Item itemToAdd)
        {

        }

        public void RemoveItem(Item itemToRemove)
        {

        }

        public void useItem(Item itemToUse)
        {

        }

        public bool equipItem(Item itemToEquip)
        {
            return true;
        }
    }

    public class Item
    {
        string itemName;
        bool equipable;
        bool equiped;
        List<Ability> itemAbilities;
    }

    public class Wallet
    {
        string walletName;
        int walletMaxSize;
        int currentFunds;
    }

}
