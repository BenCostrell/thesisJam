using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour {

    private Tile parentTile;
    [SerializeField]
    private Vector3 placementOffset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlaceOnTile(Tile tile)
    {
        parentTile = tile;
        transform.position = tile.transform.position + placementOffset;
    }
}
