using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construt : MonoBehaviour
{
    //-----------TEMP CODE FOR BUILDING SPAWNING------------//
	public const int ATTRACTOR = 0;
	public const int BULLDOZER = 1;
	public const int MINE = 2;
	public const int ROAD = 3;

    [SerializeField] private Playerbase owner;

    private UI_Cursor cursor;
    public UI_Cursor Cursor
    {
        get { return cursor; }
        private set { }
    }

    private const string PLAYER = "Playerbase(Clone)";

	// Use this for initialization
	void Start ()
    {
        cursor = GetComponent<UI_Cursor>();
        owner = GameObject.Find(PLAYER).GetComponent<Playerbase>();
	}

    public void PlaceBuildingOnTile(int buildingIndex, Tile tile)
    {
        Building newBuilding = Instantiate(Services.Prefabs.BuildingTypes[buildingIndex], Services.Main.transform).GetComponent<Building>();

        Debug.Log(tile.coord.x + ", " + tile.coord.y);
        tile.PlaceBuilding(newBuilding);
        newBuilding.PlaceOnTile(tile, owner);
        Services.BuildingManager.AddBuilding(newBuilding);
        
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlaceBuildingOnTile(ATTRACTOR, Services.MapManager.map[Cursor.X, Cursor.Y]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlaceBuildingOnTile(BULLDOZER, Services.MapManager.map[Cursor.X, Cursor.Y]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PlaceBuildingOnTile(MINE, Services.MapManager.map[Cursor.X, Cursor.Y]);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            PlaceBuildingOnTile(ROAD, Services.MapManager.map[Cursor.X, Cursor.Y]);
        }
    }
}
