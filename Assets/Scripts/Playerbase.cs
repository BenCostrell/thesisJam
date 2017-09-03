using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerbase : Attractor {

	/*
		have a reference to the player object;
		if base is owned by player, start position is 0,0 if base is owned by player2, start position is 9,0
	*/
	
	public int owner;
    [SerializeField] private int numResources_;
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
        }
    }
    public Color winnerColor;
    [SerializeField] private List<Building> ownedBuildings;
    public List<Building> OwnedBuildings
    {
        get { return ownedBuildings; }
    }

 
	public void Init(int owner_)
	{
        BuildingName = BuildingType.ATTRACTOR;
        attractiveForce = 10f;
        Owner = this;
 		owner = owner_;
		Material mat = GetComponent<MeshRenderer>().material;
		if (owner == 1) {
			mat.color = Color.magenta;
		} else {
			mat.color = Color.cyan;
		}
		winnerColor = mat.color;

 	}


 	void Start () {
	}
	
 	void Update () {
		
	}
		
	void OnTriggerEnter(Collider coll){
        if (coll.gameObject.GetComponent<Agent>() != null)
        {
			Services.SceneStackManager.Swap<WinScreen>(new TransitionData(owner, winnerColor));
        }
	}

}
