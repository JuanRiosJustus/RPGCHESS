using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public static class CombatManager
{
    private static Random rand = new Random(585);
    /// <summary>
    /// Handles the damage the tyoe if mouse input was selected for the respective ability.
    /// </summary>
    /// <param name="attacker">attacking character.</param>
    /// <param name="defender">defending character.</param>
    /// <param name="e">mouse event </param>
    /// <returns></returns>
    public static CombatResult Combat(Character attacker, Character defender, MouseEventArgs e)
    {
        // Player is using regular attack.
        if (e.Button == MouseButtons.Left)
        {
            string attackName = Ability.BasicAttack.Name;
            // do regular attack / basic attacl
            int damageDone = DoBasicAttackDamage(attacker, defender);
            return new CombatResult(attackName, damageDone);
        }
        // player is using ultimate.
        if (e.Button == MouseButtons.Right)
        {
            //player is using ultimate
            if (CanUseUltimate(attacker))
            {
                string attackName = attacker.ClassOfEntity.Ultimate.Name;
                // do ultimate attack
                int damageDone = DoUltimateDamage(attacker, defender);
                return new CombatResult(attackName, damageDone);
                
            }
        }
        return new CombatResult("Struggle", 0);
    }
    /// <summary>
    /// Does ultiate from a give character to another given character returning the amount done.
    /// </summary>
    public static int DoUltimateDamage(Character send, Character recieve)
    {
        int startHealth = recieve.Health;
        switch (send.ClassOfEntity.Name.ToLower())
        {
            case "cleric": DoClericUltimate(send, recieve); break;
            case "fighter": DoFighterUltimate(send, recieve); break;
            case "magician": DoMagicianUltimate(send, recieve); break;
            case "rogue": DoRogueUltimate(send, recieve); break;
            case "monk": DoMonkUltimate(send, recieve); break;
            case "ranger": DoRangerUltimate(send, recieve); break;
        }
        send.ExpendManaForUltimate();
        return startHealth - recieve.Health;
    }
    /// <summary>
    /// Heals the target based on damage.
    /// </summary>
    private static void DoClericUltimate(Character send, Character receive)
    {
        receive.TakeDamage = (((send.Damage + 1) * 3) * -1);
    }
    /// <summary>
    /// Deals damage based on armor and attack.
    /// </summary>
    private static void DoFighterUltimate(Character send, Character receive)
    {
        receive.TakeDamage = (send.Armor + send.Damage) - receive.Armor;
    }
    /// <summary>
    /// Deals half the targets health as damage.
    /// </summary>
    private static void DoMagicianUltimate(Character send, Character receive)
    {
        receive.TakeDamage = (receive.Health / 2) - receive.Armor;
    }
    /// <summary>
    /// Deals damage with a chance of dealing damage equal to targets health.
    /// </summary>
    private static void DoRogueUltimate(Character send, Character receive)
    {
        int chance = rand.Next(0, 100);
        if (chance < 10)
        {
            receive.TakeDamage = receive.Health + send.Damage;
        }
        else
        {
            receive.TakeDamage = (chance/2) - receive.Armor;
        }
    }
    /// <summary>
    /// Deals damage based on amount of mana target and user has and gains life based on current mana.
    /// </summary>
    private static void DoMonkUltimate(Character send, Character receive)
    {
        receive.TakeDamage = (receive.Mana + send.Mana) - receive.Armor;
        for (int i = 0; i < send.Mana; i++) { send.RegenHealth(); }
    }
    /// <summary>
    /// Deals damage randomly with a chance of doing 3x the damage
    /// </summary>
    private static void DoRangerUltimate(Character send, Character receive)
    {
        int b = rand.Next(1, 3);
        for (int i = 0; i < b; i++)
        {
            receive.TakeDamage = send.Damage - receive.Armor - receive.Level;
        }
    }
    /// <summary>
    /// Checks if the given player can use their ultimate.
    /// </summary>
    /// <param name="cha">character to check.</param>
    /// <returns></returns>
    private static bool CanUseUltimate(Character cha)
    {
        Ability abi = cha.ClassOfEntity.Ultimate;
        if (cha.Mana >= abi.Mana)
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// Performs the basic attack routine between two characters.
    /// </summary>
    /// <param name="attkr">attacking character.</param>
    /// <param name="dfndr">defending character.</param>
    /// <returns></returns>
    private static int DoBasicAttackDamage(Character attkr, Character dfndr)
    {
        int startHealth = dfndr.Health;
        dfndr.TakeDamage = attkr.Damage - dfndr.Armor;
        return startHealth - dfndr.Health;
    }
}