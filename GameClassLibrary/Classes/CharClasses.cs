using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameEngine.Classes
{
    public class racialClass
    {
        string racialName;

        //modifiers based on racial class
        int strMod;
        int dexMod;
        int conMod;
        int intMod;
        int wisMod;
        int chaMod;

        //abilities based on race here
        List<Ability> racialAbilities;

    }

    public class charClass
    {
        int level;

        //Base Stats intelligence
        int baseStr;
        int baseDex;
        int baseCon;
        int baseInt;
        int baseWis;
        int baseCha;

        List<Ability> abilities;

    }
}
