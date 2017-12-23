using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 
/// Defines the player.
/// 
/// </summary>
public class Player
{
    private List<Character> Team;
    private string IP;
    private Relation _Relation;
    private string Name;
    /// <summary>
    /// Constructor for the Player.
    /// </summary>
    /// <param name="relation">The relation of the player to the local host.</param>
    public Player(Relation relation)
    {
        Team = new List<Character>();
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
        return Team[index];
    }
    /// <summary>
    /// Remoces the given character from the list of characters.
    /// </summary>
    /// <param name="c">charaacter to remove</param>
    public void RemoveCharater(Character c)
    {
        Team.Remove(c);
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