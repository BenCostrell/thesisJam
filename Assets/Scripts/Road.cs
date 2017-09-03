using UnityEngine;

public class Road : Building
{
    //  This class adds X amount of move speed to the agent

    internal override void PlaceOnTile(Tile tile)
    {
        base.PlaceOnTile(tile);
        _buildingName = BuildingType.ROAD;
        parentTile = tile;
        OnPlacedOnTile();
    }


    internal override void OnPlacedOnTile()
    {

    }

    internal override void Demolish()
    {
        base.Demolish();
    }
}
