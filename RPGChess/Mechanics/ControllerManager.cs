using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AuxiliaryInputManager
{
    public static string AuxiliaryText(Character cha)
    {
        if (cha.LEVEL < Global.LEVELFORULTIMATE)
        {
            string str = cha.CLASS_OF_ENTITY.ULTIMATE.MANA + " mana needed to use ultimate after level 4.";
            return cha.EXPGAINED + " experience was gained. " + str;
        }
        return "Ha";
    }
}
