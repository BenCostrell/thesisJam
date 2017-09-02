using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulldozer : Building
{
    internal override void PlaceOnTile(Tile tile)
    {
        _buildingName = BuildingType.BULLDOZER;
        _tile = tile;
        if(Tile.containedBuilding)
        {
            Bulldoze(Tile.containedBuilding);
        }
    }

    internal override void Demolish()
    {
        base.Demolish();
    }

    private void Bulldoze(Building building)
    {
        building.Demolish();
    }
}
