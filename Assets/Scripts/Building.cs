using UnityEngine;

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

    [SerializeField] protected Playerbase _owner;
    public Playerbase Owner
    {
        get { return _owner; }
        protected set { _owner = value; }
    }

    [SerializeField] protected Tile _parentTile;
    public Tile ParentTile
    {
        get { return _parentTile; }
        protected set
        {
            _parentTile = value;
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

    [SerializeField] protected int cost;
    public int Cost
    {
        get { return cost; }
    }


    protected TaskManager _tm = new TaskManager();

    internal virtual void PlaceOnTile(Tile tile)
    {
        _parentTile = tile;
        transform.position = tile.transform.position + placementOffset;
    }

    internal virtual void PlaceOnTile(Tile tile, Playerbase owner)
    {
        _owner = owner;
        _parentTile = tile;
        transform.position = tile.transform.position + placementOffset;
    }

    internal virtual void OnPlacedOnTile() { }

    internal virtual void Demolish() { Destroy(this.gameObject); }
}
