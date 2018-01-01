/// <summary>
/// Defines the results of combat.
/// </summary>
public class CombatResult
{
    public readonly int DamageDone;
    public readonly string AttackUsed;

    public CombatResult(string attack, int damage)
    {
        AttackUsed = attack;
        DamageDone = damage;
    }
}