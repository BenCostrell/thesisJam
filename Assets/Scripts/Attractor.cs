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
            if (!value)
            {
                GetComponentsInChildren<MeshRenderer>()[1].material.color = Color.grey;
            }
            else
            {
                GetComponentsInChildren<MeshRenderer>()[1].material.color = baseColor;
            }
        }
    }
    protected Color baseColor;

    public float AttractiveForce { get { return attractiveForce; } }
    protected float attractiveForce = 100.0f;

    internal override void PlaceOnTile(Tile _tile, Playerbase _owner)
    {
        base.PlaceOnTile(_tile, _owner);
        _buildingName = BuildingType.ATTRACTOR;
        _parentTile = _tile;
        OnPlacedOnTile();
        baseColor = GetComponentsInChildren<MeshRenderer>()[1].material.color;
        IsOn = true;
    }

    internal override void OnPlacedOnTile()
    {
        
    }

    internal override void Demolish()
    {
        Services.BuildingManager.Attractors.Remove(this);
        base.Demolish();
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
