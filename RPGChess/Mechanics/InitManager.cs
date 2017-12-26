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
        private void SetEntitysInColumn(Board b, Player plyer, int col)
        {
            for (int i = 0; i < plyer.TeamSize(); i++)
            {
                if (i == Global.TEAMSIZE) { break; }
                Character c = plyer.GetCharacterFromTeam(i);
                b.AddEntityToBoard(c, 5 + (i * Global.TEAMSPACING), col);
            }
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
                SetEntitysInColumn(b, p1, 10);
                SetEntitysInColumn(b, p2, 40);
                SetUpGenerics(b, p2, 30);
                SetUpGenerics(b, p1, 20);
            }
            else
            {
                SetEntitysInColumn(b, p1, 40);
                SetEntitysInColumn(b, p2, 10);
                SetUpGenerics(b, p1, 30);
                SetUpGenerics(b, p2, 20);
            }
        }
    }
    /// <summary>
    /// Adds the generics for the team.
    /// </summary>
    /// <param name="b"></param>
    /// <param name="plyr"></param>
    /// <param name="col"></param>
    private static void SetUpGenerics(Board b, Player plyr, int col)
    {
        for (int i = 0; i < Global.TEAMSIZE+1; i++)
        {
            Character c = EntityFactory.BuildCharacter("Pawn " + (i + 1), "generic", plyr.RELATION);
            plyr.AddCharacterToTeam(c);
            b.AddEntityToBoard(c, 5 + (i * (Global.TEAMSPACING - 4)), col);
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