using System;
using System.Collections.Generic;

public class InitManager
{
    private static Singleton Logic = null;

    protected InitManager()
    {
        // constructor
    }

    private class Singleton
    {
        public Singleton()
        {
            // constructor
        }

        /// <summary>
        /// Determines the turn order of the game for players.
        /// </summary>
        /// <param name="p1">The local player.</param>
        /// <param name="p2">The remote player.</param>
        /// <returns></returns>
        public void DecideTurnOrder(Player p1, Player p2, Queue<Player> playerQueue)
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
            playerQueue = q;
        }
        /// <summary>
        /// Sets all characters of both given players on the given board.
        /// </summary>
        /// <param name="p1">The local player.</param>
        /// <param name="p2">The remote player.</param>
        /// <param name="b">The board to add characters to.</param>
        public void SetCharactersOnBoard(Player p1, Player p2, Board b)
        {
            if (Metadata.IsLocalHost())
            {
                for (int i = 0; i < p1.TeamSize(); i++)
                {
                    if (i == Global.TEAMSIZE) { break; }

                    Character c = p1.GetCharacterFromTeam(i);
                    b.AddEntityToBoard(c, 5 + (i * 3), 3);
                }

                for (int i = 0; i < p2.TeamSize(); i++)
                {
                    if (i == Global.TEAMSIZE) { break; }

                    Character c = p2.GetCharacterFromTeam(i);
                    b.AddEntityToBoard(c, 5 + (i * 3), 46);
                }
            }
            else
            {
                for (int i = 0; i < p1.TeamSize(); i++)
                {
                    if (i == Global.TEAMSIZE) { break; }

                    Character c = p1.GetCharacterFromTeam(i);
                    b.AddEntityToBoard(c, 5 + (i * 6), 46);
                }

                for (int i = 0; i < p2.TeamSize(); i++)
                {
                    if (i == Global.TEAMSIZE) { break; }

                    Character c = p2.GetCharacterFromTeam(i);
                    b.AddEntityToBoard(c, 5 + (i * 6), 3);
                }
            }
        }
    }
    private static Singleton GetSingletonInstance()
    {
        if (Logic == null)
        {
            Logic = new Singleton();
        }
        return Logic;
    }
    /// <summary>
    /// Determines the turn order of the game for players.
    /// </summary>
    /// <param name="p1">The local player.</param>
    /// <param name="p2">The remote player.</param>
    /// <returns></returns>
    public static void DetermineTurnOrder(Player p1, Player p2, Queue<Player> playerQueue)
    {
        GetSingletonInstance();
        Logic.DecideTurnOrder(p1, p2, playerQueue);
    }
    /// <summary>
    /// Sets all characters of both given players on the given board.
    /// </summary>
    /// <param name="p1">The local player.</param>
    /// <param name="p2">The remote player.</param>
    /// <param name="b">The board to add characters to.</param>
    public static void SetCharactersOnBoard(Player p1, Player p2, Board b)
    {
        GetSingletonInstance();
        Logic.SetCharactersOnBoard(p1, p2, b);
    }
    
}