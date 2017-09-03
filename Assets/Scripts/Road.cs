using UnityEngine;

public class Road : Building
{
    //  This class adds X amount of move speed to the agent

    internal override void PlaceOnTile(Tile _tile, Playerbase _owner)
    {
        base.PlaceOnTile(_tile, _owner);
        _buildingName = BuildingType.ROAD;
        _parentTile = _tile;
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
