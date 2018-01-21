using System;

/// <summary>
/// 
/// Contains information pertaining to the players.
/// 
/// </summary>
public class Metadata
{
    private Player LocalPlayer;
    private Player RemotePlayer;
    private bool _IsSurvival;
    private BoardType _TypeOfBoard;
    private bool _IsLocalHost;
    private Tile[,] map;
    
    public Metadata()
    {
        LocalPlayer = new Player(Relation.Friend);
        RemotePlayer = new Player(Relation.Foe);
        _IsSurvival = true;
        _IsLocalHost = false;
    }
    public bool IsSurvival { get { return _IsSurvival; } set { _IsSurvival = value; } }
    public Player GetLocalPlayer { get { return LocalPlayer; } }
    public Player GetRemotePlayer { get { return RemotePlayer; } }
    public BoardType TypeOfBoard { get { return _TypeOfBoard; } set { _TypeOfBoard = value; } }

    public void AddCharactorToLocalPlayer(Character c)
    {
        LocalPlayer.AddCharacterToTeam(c);
    }
    /// <summary>
    /// Sets the map.
    /// </summary>
    public Tile[,] MAP { get { return map; } set { map = value; } }
    /// <summary>
    /// Adds a character to the remote plater.
    /// </summary>
    public void AddCharactorToRemotePlayer(Character c) { RemotePlayer.AddCharacterToTeam(c); }
    /// <summary>
    /// Gets or sets the port of the remote player.
    /// </summary>
    public int RemotePlayerPort { get { return RemotePlayer.Port; } set { RemotePlayer.Port = value; } }
    /// <summary>
    /// Gets or sets the port of the local player.
    /// </summary>
    public int LocalPlayerPort { get { return LocalPlayer.Port; } set { LocalPlayer.Port = value; } }
    /// <summary>
    /// Gets or sets the local host of remote player 
    /// </summary>
    public bool IsLocalHost { get { return _IsLocalHost; } set { _IsLocalHost = value; } }
    /// <summary>
    /// Gets or sets the local player name.
    /// </summary>
    public string LocalPlayerName { get { return LocalPlayer.Name; } set { LocalPlayer.Name = value; } }
    /// <summary>
    /// Gets or sets the remote player name.
    /// </summary>
    public string RemotePlayerName { get { return RemotePlayer.Name; } set { RemotePlayer.Name = value; } }
    /// <summary>
    /// Gets or sets the ip of the remote player.
    /// </summary>
    public string RemotePlayerIP { get { return RemotePlayer.IP; } set { RemotePlayer.IP = value; } }
    /// <summary>
    /// Gets or sets the ip of the local player.
    /// </summary>
    public string LocalPlayerIP { get { return LocalPlayer.IP; } set { LocalPlayer.IP = value; } }
    /// <summary>
    /// Returns the current time represented by a string.
    /// </summary>
    /// <returns></returns>
    public static string GameTime()
    {
        return "[" + DateTime.Now.ToString("h:mm:ss tt") + "] >> \t" ;
    }

}