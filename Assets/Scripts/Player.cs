using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player {

    public int playerNum;
    private int startingResources = 15;
    private int numResources_;
    public int numResources
    {
        get
        {
            return numResources_;
        }
        set
        {
            numResources_ = value;
            //resourceUI.text = value.ToString();
			Debug.Log(numResources);
        }
    }
    public List<Building> buildings { get; private set; }

    public Player(int playerNum_)
    {
        playerNum = playerNum_;
        buildings = new List<Building>();
        numResources = startingResources;
    }

    public void AddBuilding(Building building)
    {
        buildings.Add(building);
        numResources -= building.Cost;
    }

    public bool CanAfford(Building building)
    {
        if (numResources >= building.Cost) return true;
        else return false;
    }

}
