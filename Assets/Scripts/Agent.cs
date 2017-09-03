using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {

    private Vector3 startingLocation;
    private Vector3 endLocation;

    private List<NavQuad> path;

    private float speed = 0.001f;
    private float startTime;
    private float journeyLength;
    private Vector3 prevPos;


    void Awake(){
        startingLocation = gameObject.transform.position;
        endLocation = new Vector3(9f, 0f, 9f);
        prevPos = startingLocation;

        path = new List<NavQuad>();
    }

	// Use this for initialization
	void Start () {
        startTime = Time.time;
       // journeyLength = Vector3.Distance(startingLocation, endLocation);
	}
	
	// Update is called once per frame
	void Update () {
        
        if(path.Count != 0 && transform.position != path[0].position){
            float distCovered = (Time.time - startTime) * speed;
            journeyLength = Vector3.Distance(path[0].position, transform.position);
            /*if (path.Count > 1)
            {
                journeyLength = Vector3.Distance(path[0].position, path[1].position);
            } else{
                journeyLength = transform.
            }*/
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(prevPos, path[0].position, fracJourney);
            prevPos = transform.position;
        } //else if (path.Count != 0 && transform.position == path[0].position)
        else
        {
			path.Remove(path[0]);
        }
	}

    public void Walk(){
        NavQuad startNavQuad = Services.MapManager.GetNavQuadClosestToPosition(startingLocation);
        NavQuad endNavQuad = Services.MapManager.GetNavQuadClosestToPosition(endLocation);

        path = AStarSearch.ShortestPath(startNavQuad, endNavQuad, false);

    }
}
