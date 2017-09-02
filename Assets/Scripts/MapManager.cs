using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

    [SerializeField]
    private int mapWidth;
    [SerializeField]
    private int mapLength;
    private List<Tile> map;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GenerateMap()
    {
        map = new List<Tile>();
        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; j < mapLength; j++)
            {
                Tile tile = Instantiate(Services.Prefabs.Tile, Services.Main.transform)
                    .GetComponent<Tile>();
                tile.Init(new Coord(i, j));
                map.Add(tile);
            }
        }
    }


}
