using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulldozer : Building
{
    internal override void PlaceOnTile(Tile tile)
    {
        base.PlaceOnTile(tile);
        _buildingName = BuildingType.BULLDOZER;
        parentTile = tile;
        OnPlacedOnTile();

    }

    internal override void OnPlacedOnTile()
    {
        if (parentTile.containedBuilding)
        {
            Bulldoze(parentTile.containedBuilding);
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
