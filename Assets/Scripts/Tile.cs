﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    private Coord coord;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Init(Coord coord_)
    {
        coord = coord_;
        transform.position = new Vector3(coord.x, 0, coord.y);
        Material mat = GetComponent<MeshRenderer>().material;
        if((coord.x + coord.y) % 2 == 0)
        {
            mat.color = Color.white;
        }
        else
        {
            mat.color = Color.gray;
        }
    }
}
