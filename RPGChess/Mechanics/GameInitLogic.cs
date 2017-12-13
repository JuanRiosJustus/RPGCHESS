using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class GameInitLogic
{
    /// <summary>
    /// Determines the turn order of the game for players.
    /// </summary>
    /// <param name="p1">The local player.</param>
    /// <param name="p2">The remote player.</param>
    /// <returns></returns>
    public static Queue<Player> DecideTurnOrder(Player p1, Player p2)
    {
        Queue<Player> q = new Queue<Player>();
        Random rand = new Random();
        int g = rand.Next(100);
        if (g % 2 == 0)
        {
            q.Enqueue(p1);
            q.Enqueue(p2);
        }
        else
        {
            q.Enqueue(p2);
            q.Enqueue(p1);
        }
        return q;
    }
    /// <summary>
    /// Sets the pieces of the characters on the given board.
    /// </summary>
    /// <param name="p1">The local player.</param>
    /// <param name="p2">The remote player.</param>
    /// <param name="b">The board to add characters to.</param>
    public static void SetCharactersOnBoard(Player p1, Player p2, Board b)
    {
        if (Metadata.IsLocalHost())
        {
            for (int i = 0; i < p1.TeamSize(); i++)
            {
                Character c = p1.GetCharacterFromTeam(i);
                b.AddCharacterToBoard(c, 5 + (i * 6), 3);
            }

            for (int i = 0; i < p2.TeamSize(); i++)
            {
                Character c = p2.GetCharacterFromTeam(i);
                b.AddCharacterToBoard(c, 5 + (i * 6), 46);
            }
        }
        else
        {
            for (int i = 0; i < p1.TeamSize(); i++)
            {
                Character c = p1.GetCharacterFromTeam(i);
                b.AddCharacterToBoard(c, 5 + (i * 6), 46);
            }

            for (int i = 0; i < p2.TeamSize(); i++)
            {
                Character c = p2.GetCharacterFromTeam(i);
                b.AddCharacterToBoard(c, 5 + (i * 6), 3);
            }
        }
    }
}