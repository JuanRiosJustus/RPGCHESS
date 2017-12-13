using System;
using System.Collections;

/// <summary>
/// 
/// Defines the player.
/// 
/// </summary>
public class Player
{
    /// <summary>
    /// The list of characters assoiated with the player.
    /// </summary>
    private ArrayList Team;
    private string IP;
    private Relation _Relation;
    private string Name;
    
    public Player(Relation relation)
    {
        Team = new ArrayList();
        IP = null;
        _Relation = relation;
    }
    /// <summary>
    /// Adds a character to the players team.
    /// </summary>
    /// <param name="character">The character added to the team.</param>
    public void AddCharacterToTeam(Character character)
    {
        Team.Add(character);
    }
    /// <summary>
    /// Returns the character at the given index.
    /// </summary>
    /// <param name="index">The index to retrieve the character from.</param>
    /// <returns>The character at the given index.</returns>
    public Character GetCharacterFromTeam(int index)
    {
        return (Character)Team[index];
    }
    /// <summary>
    /// Returns the size of the players team.
    /// </summary>
    /// <returns></returns>
    public int TeamSize()
    {
        return Team.Count;
    }
    /// <summary>
    /// Sets the name if it has not already been set.
    /// </summary>
    /// <param name="name"></param>
    public void SetName(string name)
    {
        if (Name == null)
        {
            Name = name;
        }
    }
    /// <summary>
    /// Returns the name of the player.
    /// </summary>
    /// <returns></returns>
    public string GetName()
    {
        return Name;
    }
    /// <summary>
    /// Sets the ip of the player.
    /// </summary>
    /// <param name="ip"></param>
    public void SetIP(string ip)
    {
        IP = ip;
    }
}