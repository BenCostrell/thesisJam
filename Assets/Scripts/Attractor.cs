using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : Building
{
    //  This building attracts the agent using x amount of force
    [SerializeField]
    private bool isOn;
    public bool IsOn
    {
        get { return isOn; }
        protected set
        {
            isOn = value;
        }
    }

    public float AttractiveForce { get { return attractiveForce; } }
    private float attractiveForce = 100.0f;

    internal override void PlaceOnTile(Tile _tile, Playerbase _owner)
    {
        base.PlaceOnTile(_tile, _owner);
        _buildingName = BuildingType.ATTRACTOR;
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

    // Update is called once per frame
    void Update ()
    {
		
	}
}
