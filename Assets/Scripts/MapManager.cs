using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

    [SerializeField]
    private int mapWidth;
    [SerializeField]
    private int mapLength;
    private List<Tile> map;
    [SerializeField]
    private int numResources;
    [SerializeField]
    private int minResourceDist;
    [SerializeField]
    private int maxTriesProcGen;

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
        PlaceResources();
    }

    Tile GetRandomTile()
    {
        return map[Random.Range(0, map.Count)];
    }

    bool ValidateTile(Tile tile)
    {
        foreach(Tile otherTile in map)
        {
            if(otherTile.coord.Distance(tile.coord) < minResourceDist &&
                otherTile.containedResource != null)
            {
                return false;
            }
        }
        return true;
    }

    Tile PlaceResourceOnTile()
    {
        Tile tile;
        bool isValid;
        for (int i = 0; i < maxTriesProcGen; i++)
        {
            tile = GetRandomTile();
            isValid = ValidateTile(tile);
            if (isValid)
            {
                Resource resource = 
                    Instantiate(Services.Prefabs.Resource).GetComponent<Resource>();
                tile.PlaceResource(resource);
                return tile;
            }
        }
        return null;
    }

    void PlaceResources()
    {
        for (int i = 0; i < numResources; i++)
        {
            Tile resourceTile = PlaceResourceOnTile();
            if (resourceTile == null) break;
            Debug.Log("making resource number " + i);
        }
    }


}
