using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {

    private Vector3 startingLocation;
    private Vector3 endLocation;

    private List<NavQuad> path;

    private float baseSpeed = 0.5f;
    private float speed;
    private float journeyLength;
    private float timeElapsedBetweenNodes;
    private float expectedNodeJourneyDuration;
    private Vector3 prevPos;
    private Vector3 targetPos;
    private bool pathStarted;


    void Awake(){
        startingLocation = gameObject.transform.position;
        endLocation = new Vector3(7f, 0f, 8f);
        prevPos = startingLocation;

        path = new List<NavQuad>();
    }

	// Use this for initialization
	void Start () {
        speed = baseSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        if (pathStarted && transform.position != targetPos)
        {
            timeElapsedBetweenNodes += Time.deltaTime;
            transform.position = Vector3.Lerp(prevPos, targetPos,
                timeElapsedBetweenNodes / expectedNodeJourneyDuration);
        }
        else if (path.Count != 0)
        {
            targetPos = path[0].position;
            timeElapsedBetweenNodes = 0;
            expectedNodeJourneyDuration =
                Vector3.Distance(targetPos, transform.position) / speed;
            Debug.Log(expectedNodeJourneyDuration);
            prevPos = transform.position;
            path.Remove(path[0]);
            pathStarted = true;
        }
        else
        {
            pathStarted = false;
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
        //    Vector3 forceVector = differenceDirection * attractor.attractiveForce *
        //        (1 / Mathf.Pow(distance, 2));
        //    resultantForce += forceVector;
        //}
        //Vector3 targetPos = transform.position + resultantForce;
        //targetPos = new Vector3(
        //    Mathf.Clamp(targetPos.x, 0, Services.MapManager.mapLength),
        //    targetPos.y,
        //    Mathf.Clamp(targetPos.z, 0, Services.MapManager.mapWidth));
        //speed = resultantForce.magnitude * baseSpeed;
        //path = AStarSearch.ShortestPath(
        //    Services.MapManager.GetNavQuadClosestToPosition(transform.position),
        //    Services.MapManager.GetNavQuadClosestToPosition(targetPos));
    }
            
}
