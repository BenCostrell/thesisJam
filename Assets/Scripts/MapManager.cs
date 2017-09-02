﻿using System.Collections;
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
    private NavQuad[,] navQuads;

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
        GenerateNavQuads();
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


    void GenerateNavQuads()
    {
        int quadsPerTileSqrt = Mathf.RoundToInt(Mathf.Sqrt(NavQuad.quadsPerTile));
        navQuads = new NavQuad[quadsPerTileSqrt * mapWidth, quadsPerTileSqrt * mapLength];

        //make NavQuads
        foreach(Tile tile in map)
        {
            BoxCollider boxCol = tile.boxCol;
            for (int i = 0; i < quadsPerTileSqrt; i++)
            {
                for (int j = 0; j < quadsPerTileSqrt; j++)
                {
                    Vector3 pos = new Vector3(
                        boxCol.bounds.min.x + (boxCol.bounds.size.x * ((float)i / quadsPerTileSqrt)),
                        transform.position.y,
                        boxCol.bounds.min.z + (boxCol.bounds.size.z * ((float)j / quadsPerTileSqrt)));
                    NavQuad navQuad = new NavQuad(pos);

                    navQuads[(tile.coord.x * mapWidth) + i, (tile.coord.y * mapLength) + j] = 
                        (navQuad);
                    tile.navQuads.Add(navQuad);
                }
            }
        }

        //find all neighbors of each NavQuads
        for (int i = 0; i < quadsPerTileSqrt * mapWidth; i++)
        {
            for (int j = 0; j < quadsPerTileSqrt * mapLength; j++)
            {
                navQuads[i, j].neighbors = new List<NavQuad>();
                if (i > 0)
                {
                    navQuads[i, j].neighbors.Add(navQuads[i - 1, j]);
                }
                if (i < quadsPerTileSqrt * mapWidth - 1)
                {
                    navQuads[i, j].neighbors.Add(navQuads[i + 1, j]);
                }
                if (j > 0)
                {
                    navQuads[i, j].neighbors.Add(navQuads[i, j - 1]);
                }
                if (j < quadsPerTileSqrt * mapLength - 1)
                {
                    navQuads[i, j].neighbors.Add(navQuads[i, j + 1]);
                }
            }
        }
    }

    public NavQuad GetNavQuadClosestToPosition(Vector3 pos)
    {
        NavQuad closestNavQuad = null;
        float closestDist = Mathf.Infinity;
        foreach(NavQuad nq in navQuads)
        {
            if(Vector3.Distance(nq.position, pos) < closestDist)
            {
                closestNavQuad = nq;
                closestDist = Vector3.Distance(nq.position, pos);
            }
        }
        return closestNavQuad;
    }

}
