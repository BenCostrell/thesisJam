using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulldozer : Building
{
    internal override void PlaceOnTile(Tile _tile, Playerbase _owner)
    {
        base.PlaceOnTile(_tile, _owner);
        _buildingName = BuildingType.BULLDOZER;
        _parentTile = _tile;
        OnPlacedOnTile();

    }

    internal override void OnPlacedOnTile()
    {
        if (_parentTile.containedBuilding != null)
        {
            //Bulldoze(_parentTile.containedBuilding);
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
