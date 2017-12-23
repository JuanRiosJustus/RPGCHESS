using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public static class CombatManager
{
    /// <summary>
    /// Handles the damage the tyoe if mouse input was selected for the respective ability.
    /// </summary>
    /// <param name="attacker">attacking character.</param>
    /// <param name="defender">defending character.</param>
    /// <param name="e">mouse event </param>
    /// <returns></returns>
    public static CombatResult Combat(Character attacker, Character defender, MouseEventArgs e)
    {
        // check what player selected.
        
        // Player is using regula attack.
        if (e.Button == MouseButtons.Left)
        {
            string attackName = Ability.BASICATTACK.NAME;
            // do regular attack / basic attacl
            int damageDone = DoBasicAttackDamage(attacker, defender);
            return new CombatResult(attackName, damageDone);
        }
        // player is using ultimate.
        if (e.Button == MouseButtons.Right)
        {
            string attackName = attacker.CLASS_OF_ENTITY.ULTIMATE.NAME;
            // do ultimate attack
            int damageDone = DoUltimateDamage(attacker, defender);
            return new CombatResult(attackName, damageDone);

            if (CanUseUltimate(attacker))
            {
                // do ultimate
                Console.WriteLine("ULTIMATE WAS USED");
                
            }
        }
        return new CombatResult("BLANK", 0);
    }
    /// <summary>
    /// Does damage ultimate based on attacker
    /// </summary>
    /// <param name="attkr"></param>
    /// <param name="dfndr"></param>
    /// <returns></returns>
    public static int DoUltimateDamage(Character attkr, Character dfndr)
    {
        int damageReduced = dfndr.ARMOR + dfndr.LEVEL;
        int damage = attkr.CLASS_OF_ENTITY.ULTIMATE.POTENCY + attkr.DAMAGE;
        int damageDone = damage - damageReduced;

        // a cleric is using their ultimate.
        if (attkr.CLASS_OF_ENTITY == Archetype.CLERIC)
        {
            dfndr.TAKEDAMAGE = (damage + attkr.DAMAGE) * -1;
            attkr.ExpendManaForUltimate();
            return (damage + attkr.DAMAGE * -1);
        }

        
        dfndr.TAKEDAMAGE = damageDone;

        attkr.ExpendManaForUltimate();
        return damageDone;
    }
    /// <summary>
    /// Checks if the given player can use their ultimate.
    /// </summary>
    /// <param name="cha">character to check.</param>
    /// <returns></returns>
    private static bool CanUseUltimate(Character cha)
    {
        Ability abi = cha.CLASS_OF_ENTITY.ULTIMATE;
        if (cha.MANA >= abi.MANA && cha.LEVEL >= Global.LEVELFORULTIMATE)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// Given the attacking and defending character, respectively does damage/
    /// </summary>
    /// <param name="attkr">attacking character.</param>
    /// <param name="dfndr">defending character.</param>
    /// <returns></returns>
    private static int DoBasicAttackDamage(Character attkr, Character dfndr)
    {
        int damageDone = attkr.DAMAGE - dfndr.ARMOR - dfndr.LEVEL;
        dfndr.TAKEDAMAGE = damageDone;
        return damageDone;
    }
}