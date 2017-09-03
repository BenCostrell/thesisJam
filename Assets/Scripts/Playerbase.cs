using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerbase : Attractor {

	/*
		have a reference to the player object;
		if base is owned by player, start position is 0,0 if base is owned by player2, start position is 9,0
	*/
	
	public int owner;
	public Color winnerColor;

	private Vector3 startPos;
 
	public void Init(int width, int length, int owner_)
	{
 		owner = owner_;
		Material mat = GetComponent<MeshRenderer>().material;
		if (width + length != 0) {
			mat.color = Color.magenta;
		} else {
			mat.color = Color.cyan;
		}
		winnerColor = mat.color;
		startPos = new Vector3 (width, 0.5f, length); 
 	}


 	void Start () {
 		transform.position = startPos;
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
