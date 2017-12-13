using System;

/// <summary>
/// 
/// Contains information pertaining to the players.
/// 
/// </summary>
public static class Metadata
{
    static Metadata()
    {
        
    }

    private static Player Player1 = null;
    private static Player Player2 = null;
    private static Boolean Localhost = false;

    /// <summary>
    /// Returns the instance of player 1 / this player.
    /// </summary>
    /// <returns></returns>
    public static Player Player1Instance()
    {
        if (Player1 == null)
        {
            Player1 = new Player(Relation.Friendly);
            Console.WriteLine("Player one was created");
        }
        return Player1;
    }
    /// <summary>
    /// Returns the instance of player 2 / opposing player.
    /// </summary>
    /// <returns></returns>
    public static Player Player2Instance()
    {
        if (Player2 == null)
        {
            Player2 = new Player(Relation.Enemy);
            Console.WriteLine("Player one was created");
        }
        return Player2;
    }
    /// <summary>
    /// Sets the value depending on whether the host is local or not.
    /// </summary>
    /// <param name="isHost"></param>
    public static void IsLocalHost(bool isHost)
    {
        Localhost = isHost;
    }
    /// <summary>
    /// Returns the host statis of local pc.
    /// </summary>
    /// <returns></returns>
    public static bool IsLocalHost()
    {
        return Localhost;
    }


}