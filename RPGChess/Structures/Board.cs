﻿using System;
using System.Collections.Generic;

/// <summary>
/// Decision enum, shows the options for the board.
/// </summary>
public enum BoardType
{
    Mountainous,
    Oceanic,
    Default,
};
/// <summary>
/// Represents the internal stucturing of the tiles.
/// </summary>

public class Board
{
    private readonly Tile[,] Map;
    private Random NumGenerator;
    private List<Entity> ListOfEveryEntity;
    /// <summary>
    /// Constructor for the board.
    /// </summary>
    public Board(BoardType type)
    {
        NumGenerator = new Random();
        ListOfEveryEntity = new List<Entity>();

        // constructs the board.
        {
            Map = new Tile[Global.Rows, Global.Columns];

            for (int row = 0; row < Map.GetLength(0); row++)
            {
                for (int column = 0; column < Map.GetLength(1); column++)
                {
                    int height = NumGenerator.Next(-1, 1);
                    Map[row, column] = new Tile(row, column, height);
                }
            }
        }
        // constructs tiles according to the board type.
        switch (type)
        {
            case BoardType.Default: Default(); break;
            case BoardType.Mountainous: Mountainous(); break;
            case BoardType.Oceanic: Oceanic(); break;
            default: Default(); break;
        }
    }
    public Tile[,] GetUnderlyingMap()
    {
        return Map;
    }
    /// <summary>
    /// Cycles through all characters of the baord.
    /// </summary>
    public void UpdateCharacterState()
    {
        for (int i = 0; i < ListOfEveryEntity.Count; i++)
        {
            Character cur = (Character)ListOfEveryEntity[i];
            cur.RegenHealth();
            IsDead(cur);
            // ambient exp gain
            cur.GainExp(NumGenerator.Next(cur.Level + 1));
            cur.GainMana();
        }
    }
    /// <summary>
    /// Checks the boards if any characters are below 0 health. If so, remove all references.
    /// </summary>
    private bool IsDead(Character cha)
    {
        if (cha.Health <= 0)
        {
            Tile t = cha.TileOfEntity;
            t.RemoveOccupant();
            ListOfEveryEntity.Remove(cha);
            Metadata.Player1Instance().RemoveCharater(cha);
            Metadata.Player2Instance().RemoveCharater(cha);
            return true;
        }
        return false;
    }
    /// <summary>
    /// Sets the given entity to a tile on the board,
    /// </summary>
    /// <param name="ent">Entity to be added on the baord.</param>
    /// <param name="row">row to add the entity to.</param>
    /// <param name="col">column to add entity to.</param>
    /// <returns></returns>
    public bool AddEntityToBoard(Entity ent, int row, int col)
    {
        if (TileManager.IsInBounds(row,col) == false) { return false; }
        if (ListOfEveryEntity.Contains(ent) == false)
        {
            ListOfEveryEntity.Add(ent);

            Tile tile = Map[row, col];

            ent.SetTile(tile);

            // assure we can travel
            //List<Tile> moves = TileManager.GetOccuableTiles(Map, ent);
            while (tile.IsOccupied())
            {
                row = NumGenerator.Next(Global.Rows);
                col = NumGenerator.Next(Global.Columns);
                tile = Map[row, col];
            }
            
            return true;
        }
        return false;
    }
    /// <summary>
    /// Moves the given entity to the given tile if capable.
    /// </summary>
    /// <param name="ent">entity to move.</param>
    /// <param name="newTile">tile to move entity to.</param>
    public void MoveEntity(Entity ent, Tile newTile)
    {
        if (newTile == null || newTile.IsOccupied()) { return; }
        Tile tile = ent.TileOfEntity;
        tile.RemoveOccupant();

        ent.SetTile(newTile);
    }
    /// <summary>
    /// Gets the board size of the given dimension.
    /// </summary>
    /// <param name="dimension"></param>
    /// <returns></returns>
    public int GetBoardSize(int dimension)
    {
        return Map.GetLength(dimension);
    }
    /// <summary>
    /// Returns a single tile given a row and column,
    /// </summary>
    /// <param name="row">row of the tile.</param>
    /// <param name="col">column of the tile.</param>
    /// <returns></returns>
    public Tile GetTile(int row, int col)
    {
        return Map[row, col];
    }
    /// <summary>
    /// Determines if the given entity can occupy the given tile.
    /// </summary>
    /// <param name="ent">entity to check.</param>
    /// <param name="newTile">the tile to try and occupy</param>
    /// <returns></returns>
    public bool IsOccuableByEntity(Entity ent, Tile newTile)
    {
        List<Tile> occuableTiles = PathManager.BasicPath2(Map, ent);
        return occuableTiles.Contains(newTile);
    }
    /// <summary>
    /// Returns the list of occuable tiles based off a given entity.
    /// </summary>
    /// <param name="ent">entity to base the tiles off.</param>
    /// <returns></returns>
    public List<Tile> GetOccuableTilesFromEntity(Entity ent)
    {
        return PathManager.BasicPath2(Map, ent);
    }
    /// <summary>
    /// Checks if the first given entity can target the second passize entity.
    /// </summary>
    /// <param name="active">the ectively participating enetity.</param>
    /// <param name="passive">the entity being acted on.</param>
    /// <returns></returns>
    public bool IsTargetableByEntity(Entity active, Entity passive)
    {
        Tile current = active.TileOfEntity;
        Tile to = passive.TileOfEntity;
        List<Entity> targets = LineOfSightManager.TargetableEntities(Map, active);
        return targets.Contains(passive);
    }
    /// <summary>
    /// Develops terrain specifically at a given terrain
    /// given an intensity.
    /// </summary>
    /// <param name="row"></param>
    /// <param name="col"></param>
    /// <param name="intensity"></param>
    private void GenerateDevelopAt(int row, int col, int intensity)
    {
        TileManager.DevelopAt(Map, row, col, intensity);
    }
    /// <summary>
    /// Returns a list of targetable entities for the given entity
    /// </summary>
    /// <param name="ent">entity to get targets from.</param>
    /// <returns></returns>
    public List<Entity> GetTargetableEntities(Entity ent)
    {
        return LineOfSightManager.TargetableEntities(Map, ent);
    }
    /// <summary>
    /// Generates a mountainous board.
    /// </summary>
    private void Mountainous()
    {
        Random rand = new Random();
        for (int i = 0; i < 400; i++)
        {
            int col = rand.Next(Global.Columns);
            int row = rand.Next(Global.Rows);
            int z = rand.Next(8);
            GenerateDevelopAt(row, col, z);
        }

        for (int i = 0; i < 10; i++)
        {
            int col = rand.Next(Global.Columns);
            int row = rand.Next(Global.Rows);
            int z = rand.Next(-4, 0);
            GenerateDevelopAt(row, col, z);
        }
        Quartify(-4);
    }
    /// <summary>
    /// Generates the defualt style board.
    /// </summary>
    private void Default()
    {
        Random rand = new Random();
        for (int i = 0; i < 50; i++)
        {
            int col = rand.Next(Global.Columns);
            int row = rand.Next(Global.Rows);
            int z = rand.Next(-4, 0);
            GenerateDevelopAt(row, col, z);
        }

        for (int i = 0; i < 50; i++)
        {
            int col = rand.Next(Global.Columns);
            int row = rand.Next(Global.Rows);
            int z = rand.Next(8);
            GenerateDevelopAt(row, col, z);
        }
        Quartify(2);
    }
    /// <summary>
    /// Generates a oceanic board.
    /// </summary>
    private void Oceanic()
    {
        Random rand = new Random();
        for (int i = 0; i < 400; i++)
        {
            int col = rand.Next(Global.Columns);
            int row = rand.Next(Global.Rows);
            int z = rand.Next(-4, 0);
            GenerateDevelopAt(row, col, z);
        }

        for (int i = 0; i < 10; i++)
        {
            int col = rand.Next(Global.Columns);
            int row = rand.Next(Global.Rows);
            int z = rand.Next(8);
            GenerateDevelopAt(row, col, z);
        }
        Quartify(3);
    }
    /// <summary>
    /// Divides the board into four sections.
    /// </summary>
    public void Quartify(int val)
    {
        for (int row = 0; row < Global.Rows; row++)
        {
            GenerateDevelopAt(row, Global.Columns / 2, val);
        }
        for (int col = 0; col < Global.Columns; col++)
        {
            GenerateDevelopAt(Global.Rows/2, col, val);
        }
    }
}