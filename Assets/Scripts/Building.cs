﻿using UnityEngine;

//  TODO: BUILDING MANAGER

public abstract class Building : MonoBehaviour
{
    public enum BuildingType
    {
        ROAD,
        MINE,
        ATTRACTOR,
        BULLDOZER,
        ERROR
    }

    protected float MIN_BUILDTIME = 1.0f;
    protected float MAX_BUILDTIME = 2.0f;

    [SerializeField] protected bool _isActive;
    public bool IsActive
    {
        get { return _isActive; }
        protected set { _isActive = value; }
    }

    [SerializeField] protected BuildingType _buildingName;
    public BuildingType BuildingName
    {
        get { return _buildingName; }
        protected set { _buildingName = value; }
    }

    [SerializeField] protected Tile parentTile;
    public Tile ParentTile
    {
        get { return parentTile; }
        protected set
        {
            parentTile = value;
        }
    }

    private Vector3 placementOffset;

    [SerializeField] protected float _buildTimer;
    public float BuildTimer
    {
        get { return _buildTimer; }
        protected set
        {
            _buildTimer = value;
            if (_buildTimer < MIN_BUILDTIME)
            {
                _buildTimer = MIN_BUILDTIME;
            }
            else if (_buildTimer > MAX_BUILDTIME)
            {
                _buildTimer = MAX_BUILDTIME;
            }
        }

    }

    protected TaskManager _tm = new TaskManager();

    internal virtual void PlaceOnTile(Tile _tile)
    {
        parentTile = _tile;
        transform.position = _tile.transform.position + placementOffset;
    }

    internal virtual void OnPlacedOnTile() { }

    internal virtual void Demolish() { Destroy(this); }
}
