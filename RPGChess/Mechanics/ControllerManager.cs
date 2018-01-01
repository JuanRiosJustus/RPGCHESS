using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AuxiliaryInputManager
{
    public static string AuxiliaryText(Character cha)
    {
        if (cha.Mana < cha.ClassOfEntity.Ultimate.Mana)
        {
            int diff = cha.ClassOfEntity.Ultimate.Mana - cha.Mana;
            string str = diff + " mana needed till ultimate.";
            return cha.ExpGained + " experience was gained. " + str;
        }
        return "Ha";
    }
}
