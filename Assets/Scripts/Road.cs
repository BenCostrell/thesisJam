using UnityEngine;

public class Road : Building
{
    //  This class adds X amount of move speed to the agent

    internal override void PlaceOnTile(Tile tile)
    {
        _buildingName = BuildingType.ROAD;
        _tile = tile;
    }

    internal override void Demolish()
    {
        base.Demolish();
    }
}
