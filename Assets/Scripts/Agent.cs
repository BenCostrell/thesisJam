using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {

    private Vector3 startingLocation;
    private Vector3 endLocation;

    private List<NavQuad> path;

    void Awake(){
        startingLocation = transform.position;
        endLocation = new Vector3(9f, 0f, 9f);

        path = new List<NavQuad>();
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if(path.Count != 0){
            transform.position = path[0].position;
            path.Remove(path[0]);

        }
	}

    public void Walk(){
        NavQuad startNavQuad = Services.MapManager.GetNavQuadClosestToPosition(startingLocation);
        NavQuad endNavQuad = Services.MapManager.GetNavQuadClosestToPosition(endLocation);

        path = AStarSearch.ShortestPath(startNavQuad, endNavQuad, false);

    }
}
