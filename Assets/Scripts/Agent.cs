using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {

    private Vector3 startingLocation;
    private Vector3 endLocation;

    private List<NavQuad> path;

    private float baseSpeed = 0.05f;
    private float speed;
    private float startTime;
    private float journeyLength;
    private Vector3 prevPos;


    void Awake(){
        startingLocation = gameObject.transform.position;
        endLocation = new Vector3(7f, 0f, 8f);
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
            float distCovered = (Time.time - startTime) * baseSpeed;
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

    public void CalculatePath()
    {
        //Vector3 resultantForce = Vector3.zero;
        //foreach (Attractor attractor in Services.BuildingManager.attractors)
        //{
        //    Vector3 differenceVector = attractor.transform.position - transform.position;
        //    Vector3 differenceDirection = differenceVector.normalized;
        //    float distance = differenceVector.magnitude;
        //    Vector3 forceVector = differenceDirection * attractor.pullStrength *
        //        (1 / Mathf.Pow(distance, 2));
        //    resultantForce += forceVector;
        //}
        //Vector3 targetPos = transform.position + resultantForce;
        //targetPos = new Vector3(
        //    Mathf.Clamp(targetPos.x, 0, Services.MapManager.mapLength),
        //    targetPos.y,
        //    Mathf.Clamp(targetPos.z, 0, Services.MapManager.mapWidth));
        //speed = resultantForce.magnitude * baseSpeed;
    }
            
}
