using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : Building
{
    //  This building attracts the agent using x amount of force
    private float attractiveForce = 1.0f;
    
    internal override void PlaceOnTile(Tile tile)
    {
        _buildingName = BuildingType.ATTRACTOR;
        _tile = tile;
    }

    internal override void Demolish()
    {
        base.Demolish();
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
