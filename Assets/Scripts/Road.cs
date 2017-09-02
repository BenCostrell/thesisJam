using UnityEngine;

public class Road : Buidling
{
    //  This class adds X amount of move speed to the agent

    internal override void Create(Tile tile)
    {
        _tile = tile;
    }

    internal override void Demolish()
    {
        base.Demolish();
    }
}
