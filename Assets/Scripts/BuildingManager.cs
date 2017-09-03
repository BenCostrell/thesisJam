using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{

    [SerializeField] private List<Building> buildingList;
    public List<Building> BuildingList
    {
        get { return buildingList; }
        private set { }
    }

    [SerializeField] private List<Attractor> attractors;
    public List<Attractor> Attractors
    {
        get { return attractors; }
        private set { }
    }


	// Use this for initialization
	void Start ()
    {
		
	}

    public void AddBuilding(Building building)
    {
        if (building.BuildingName == Building.BuildingType.ATTRACTOR)
        {
            AddAttractor((Attractor)building);
        }

        buildingList.Add(building);
    }

    private void AddAttractor(Attractor attractor)
    {
        attractors.Add(attractor);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
